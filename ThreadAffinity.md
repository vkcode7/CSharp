This is called **processor affinity** (or CPU pinning). In .NET, you can control which cores a thread runs on, though `Task` itself doesn't expose this directly — you go through the underlying `Thread`.

---

## .NET: Setting Thread Affinity

```csharp
using System.Diagnostics;
using System.Runtime.InteropServices;

// Set affinity for the current process
var process = Process.GetCurrentProcess();

// Use a bitmask — each bit represents a core
// 0b0000_0001 = core 0 only
// 0b0000_0011 = cores 0 and 1
// 0b1111_1111 = cores 0–7
process.ProcessorAffinity = (IntPtr)0b0000_0001; // pin to core 0
```

For **per-thread** affinity on Windows, you need a P/Invoke call:

```csharp
[DllImport("kernel32.dll")]
static extern IntPtr SetThreadAffinityMask(IntPtr hThread, IntPtr dwThreadAffinityMask);

[DllImport("kernel32.dll")]
static extern IntPtr GetCurrentThread();

// Pin current thread to core 3 (bit 3 = 0b00001000 = 8)
SetThreadAffinityMask(GetCurrentThread(), (IntPtr)(1 << 3));
```

---

## Using It with a Task

Since tasks run on thread pool threads, you need to force the affinity *inside* the task, before the work begins:

```csharp
Task.Factory.StartNew(() =>
{
    // Pin this thread to core 2
    SetThreadAffinityMask(GetCurrentThread(), (IntPtr)(1 << 2));

    // Your work here
}, TaskCreationOptions.LongRunning); // LongRunning = dedicated thread
```

`LongRunning` is important here — without it, a thread pool thread is reused and your affinity setting will persist for future unrelated tasks on that thread, which is a bug.

---

## On Linux

Linux doesn't have `SetThreadAffinityMask`. Use `sched_setaffinity` instead:

```csharp
[DllImport("libc", SetLastError = true)]
static extern int sched_setaffinity(int pid, IntPtr cpusetsize, ref ulong mask);

ulong mask = 1UL << 2; // core 2
sched_setaffinity(0, (IntPtr)8, ref mask); // 0 = current thread
```

Or use the `nuget` package **NativeMemory** / shell out to `taskset`.

---

## When Should You Do This?

| Use case | Worth it? |
|----------|-----------|
| Real-time / low-latency work | ✅ Yes |
| Avoiding cache thrashing on hot data | ✅ Yes |
| General compute tasks | ❌ Usually not — the OS scheduler is good |
| Game engines / trading systems | ✅ Common practice |

In most applications the OS scheduler does a fine job. CPU pinning is mainly useful in **latency-sensitive** or **high-performance** scenarios where cache locality and thread migration cost matter.

# Cache Aware Programming

Great topic. Cache-aware programming is one of the highest-leverage optimizations for low-latency C#. Here's a breakdown:

---

## The Cache Hierarchy (Quick Recap)

| Cache | Size (typical) | Latency |
|-------|---------------|---------|
| L1 | 32–64 KB per core | ~1–4 cycles |
| L2 | 256 KB – 1 MB per core | ~10–15 cycles |
| L3 | 8–64 MB shared | ~40–60 cycles |
| RAM | GBs | ~100–300 cycles |

The goal: **keep hot data in L1/L2 and avoid cache misses.**

---

## 1. Prefer Sequential / Contiguous Memory Access

Cache lines are **64 bytes**. The CPU prefetcher loves sequential reads.

```csharp
// ✅ Cache-friendly — walks memory linearly
for (int i = 0; i < array.Length; i++)
    sum += array[i];

// ❌ Cache-hostile — random jumps across memory (pointer chasing)
LinkedList<int> list = ...;
foreach (var node in list) // each node is a heap object scattered in RAM
    sum += node.Value;
```

Prefer **arrays** and `Span<T>` over linked lists, trees, and other pointer-heavy structures.

---

## 2. Data-Oriented Design — Pack Your Structs

```csharp
// ❌ Array of Objects (AoS) — each object is scattered on heap
class Particle { float X, Y, Z, VX, VY, VZ; }
Particle[] particles = new Particle[10000];

// ✅ Struct of Arrays (SoA) — all X values are contiguous
struct ParticlePool
{
    public float[] X, Y, Z;
    public float[] VX, VY, VZ;
}
```

If your loop only touches `X` and `Y`, SoA means you're loading only `X` and `Y` into cache — not wasting cache lines on unused fields.

---

## 3. Avoid False Sharing (Multi-core)

Two cores writing to different variables on the **same 64-byte cache line** causes the cache line to ping-pong between cores.

```csharp
// ❌ False sharing — Counter0 and Counter1 likely share a cache line
struct Counters
{
    public long Counter0;
    public long Counter1;
}

// ✅ Pad to force each counter onto its own cache line
[StructLayout(LayoutKind.Explicit)]
struct PaddedCounter
{
    [FieldOffset(0)]  public long Value;
    [FieldOffset(64)] public long _pad; // pushes next field to new cache line
}
```

.NET 8+ also has `[field: System.Runtime.InteropServices.StructLayout]` and you can use `Unsafe` tricks or `CACHE_LINE_SIZE` constants.

---

## 4. Use `Span<T>` and `Memory<T>` — Stay on Stack / Contiguous Heap

```csharp
// ✅ Stack allocated — never hits GC, lives in L1
Span<int> buffer = stackalloc int[64];

// ✅ Slicing without allocation
Span<byte> slice = bigBuffer.AsSpan(100, 64);
```

`Span<T>` avoids heap allocation and keeps data local. Avoids GC pauses that can evict your cache.

---

## 5. `ArrayPool<T>` — Reuse Buffers, Avoid GC Pressure

GC collections evict cache. Reuse buffers instead of allocating:

```csharp
var pool = ArrayPool<byte>.Shared;
byte[] buffer = pool.Rent(4096);
try
{
    // use buffer
}
finally
{
    pool.Return(buffer);
}
```

---

## 6. `NativeMemory` / Unmanaged Buffers — Bypass GC Entirely

```csharp
using System.Runtime.InteropServices;

void* ptr = NativeMemory.AlignedAlloc(byteCount, alignment: 64); // cache-line aligned
try
{
    var span = new Span<float>(ptr, count);
    // work directly on native memory
}
finally
{
    NativeMemory.AlignedFree(ptr);
}
```

Useful for large buffers you want to keep out of the GC heap entirely.

---

## 7. Control Struct Layout — Minimize Struct Size

Smaller structs = more fit in a cache line = fewer misses.

```csharp
// ❌ Wasteful — padding inserted by default
struct Bad  { byte A; int B; byte C; } // 12 bytes due to padding

// ✅ Reordered fields — 8 bytes
struct Good { int B; byte A; byte C; } 
```

Use `[StructLayout(LayoutKind.Sequential, Pack = 1)]` if you need tight packing, but be aware of alignment penalties on reads.

---

## 8. Prefetching (Advanced)

.NET doesn't expose `_mm_prefetch` directly, but you can hint the CPU via `Unsafe`:

```csharp
// Available in .NET 6+ via hardware intrinsics
if (Sse.IsSupported)
    Sse.Prefetch0(ptr); // prefetch to L1
    Sse.Prefetch1(ptr); // prefetch to L2
    Sse.Prefetch2(ptr); // prefetch to L3
```

Useful when you know you'll need data a few iterations ahead.

---

## 9. SIMD — Process a Full Cache Line at Once

If you've already got data in cache, use it maximally:

```csharp
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

// Process 8 floats at once (256-bit AVX)
var a = Vector256.Load(ptrA);
var b = Vector256.Load(ptrB);
var result = Avx.Add(a, b);
```

SIMD + cache-friendly layout is the combination used in game engines and HFT systems.

---

## Summary Cheat Sheet

| Technique | Targets |
|-----------|---------|
| Sequential access / arrays | Prefetcher, L1/L2 |
| SoA layout | L1/L2 cache utilization |
| Avoid false sharing | L1 per-core coherence |
| `stackalloc` / `Span<T>` | L1 stack locality |
| `ArrayPool<T>` | Reduce GC, preserve cache |
| Minimize struct size | Fit more in cache line |
| SIMD intrinsics | Maximize cache line usage |
| `NativeMemory` aligned alloc | Cache-line alignment |

The biggest wins in order: **eliminate pointer chasing → fix layout → avoid GC → then tune with SIMD/prefetch**.

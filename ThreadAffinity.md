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


# SIMD — Single Instruction, Multiple Data

## The Core Idea

Normal scalar code processes **one value per instruction**. SIMD processes **multiple values simultaneously** using wide registers.

```
Scalar:  [a0] + [b0] = [c0]   (1 operation)

SIMD:    [a0][a1][a2][a3]
       + [b0][b1][b2][b3]
       = [c0][c1][c2][c3]     (4 operations, 1 instruction)
```

The CPU has special wide registers and instructions that operate on all lanes at once — no loop needed.

---

## Register Widths

| ISA Extension | Register Width | Floats (32-bit) | Doubles (64-bit) | Ints (32-bit) |
|---------------|---------------|-----------------|------------------|---------------|
| SSE           | 128-bit        | 4               | 2                | 4             |
| AVX / AVX2    | 256-bit        | 8               | 4                | 8             |
| AVX-512       | 512-bit        | 16              | 8                | 16            |

On a 16-core CPU with AVX-512, you can theoretically process **16 floats × 16 cores = 256 floats per cycle**.

---

## How It Works Internally

Think of a 256-bit AVX register as a fixed-width container split into **lanes**:

```
256-bit register YMM0:
┌──────┬──────┬──────┬──────┬──────┬──────┬──────┬──────┐
│  f0  │  f1  │  f2  │  f3  │  f4  │  f5  │  f6  │  f7  │  ← 8 × 32-bit floats
└──────┴──────┴──────┴──────┴──────┴──────┴──────┴──────┘
```

A single `VADDPS` instruction adds two such registers lane-by-lane in **one clock cycle**.

---

## In C# — Three Levels of API

### Level 1: `Vector<T>` — Portable, Auto-width (simplest)

```csharp
using System.Numerics;

float[] a = { 1, 2, 3, 4, 5, 6, 7, 8 };
float[] b = { 8, 7, 6, 5, 4, 3, 2, 1 };
float[] result = new float[8];

int vectorSize = Vector<float>.Count; // 4 on SSE, 8 on AVX

for (int i = 0; i <= a.Length - vectorSize; i += vectorSize)
{
    var va = new Vector<float>(a, i);
    var vb = new Vector<float>(b, i);
    (va + vb).CopyTo(result, i);
}
```

`Vector<T>.Count` adapts to whatever the CPU supports. The JIT emits the best instructions automatically. Good default choice.

---

### Level 2: `Vector128<T>` / `Vector256<T>` — Explicit Width

```csharp
using System.Runtime.Intrinsics;

// Explicitly work with 256-bit vectors
Vector256<float> va = Vector256.Create(1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f);
Vector256<float> vb = Vector256.Create(8f, 7f, 6f, 5f, 4f, 3f, 2f, 1f);
Vector256<float> result = va + vb; // operator overloads in .NET 7+
```

You control the width explicitly. Still somewhat portable — JIT handles instruction selection.

---

### Level 3: Hardware Intrinsics — Full Control (most powerful)

```csharp
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

if (Avx.IsSupported)
{
    unsafe
    {
        fixed (float* pA = a, pB = b, pResult = result)
        {
            Vector256<float> va = Avx.LoadVector256(pA);
            Vector256<float> vb = Avx.LoadVector256(pB);
            Vector256<float> vc = Avx.Add(va, vb);
            Avx.Store(pResult, vc);
        }
    }
}
```

This maps **1:1 to CPU instructions**. `Avx.Add` compiles directly to `VADDPS`. Maximum control, maximum performance.

---

## A Real Example — Dot Product

```csharp
static float DotProductScalar(float[] a, float[] b)
{
    float sum = 0;
    for (int i = 0; i < a.Length; i++)
        sum += a[i] * b[i];
    return sum;
}

static unsafe float DotProductAVX(float[] a, float[] b)
{
    float result = 0;
    int vectorSize = 8; // AVX: 8 floats per register
    int i = 0;

    var accumulator = Vector256<float>.Zero;

    fixed (float* pA = a, pB = b)
    {
        for (; i <= a.Length - vectorSize; i += vectorSize)
        {
            var va = Avx.LoadVector256(pA + i);
            var vb = Avx.LoadVector256(pB + i);
            accumulator = Avx.Add(accumulator, Avx.Multiply(va, vb)); // or use FMA
        }
    }

    // Horizontal sum — reduce 8 lanes to 1 scalar
    var sum128 = Sse.Add(
        Avx.ExtractVector128(accumulator, 0),
        Avx.ExtractVector128(accumulator, 1));

    sum128 = Sse.Add(sum128, Sse.MoveHighToLow(sum128, sum128));
    sum128 = Sse.AddScalar(sum128, Sse.Shuffle(sum128, sum128, 1));
    result = sum128.ToScalar();

    // Scalar tail — handle remainder
    for (; i < a.Length; i++)
        result += a[i] * b[i];

    return result;
}
```

The SIMD version is typically **4–8× faster** on this kind of workload.

---

## FMA — Fused Multiply-Add

Instead of separate multiply + add (2 instructions, 2 roundings), FMA does it in **one instruction with one rounding** — faster and more accurate:

```csharp
using System.Runtime.Intrinsics.X86;

if (Fma.IsSupported)
{
    // result = a * b + c  (one instruction: VFMADD231PS)
    var result = Fma.MultiplyAdd(va, vb, accumulator);
}
```

FMA is critical for matrix multiply, neural networks, signal processing.

---

## Common Operations

| Operation | Scalar | SIMD Equivalent |
|-----------|--------|-----------------|
| Add | `a + b` | `Avx.Add(va, vb)` |
| Multiply | `a * b` | `Avx.Multiply(va, vb)` |
| FMA | `a*b + c` | `Fma.MultiplyAdd(va, vb, vc)` |
| Min/Max | `Math.Min` | `Avx.Min / Avx.Max` |
| Conditional | `if (a > b)` | `Avx.Compare(va, vb, ...)` + mask |
| Shuffle/Permute | manual index | `Avx.Permute / Avx2.Permute4x64` |
| Gather | `arr[indices[i]]` | `Avx2.GatherVector256(...)` |
| Horizontal sum | loop | extract + shuffle + add |

---

## Masking (AVX-512)

AVX-512 introduced **per-lane masking** — apply operations conditionally per lane without branching:

```csharp
using System.Runtime.Intrinsics.X86;

if (Avx512F.IsSupported)
{
    // Only write lanes where mask bit is set
    var mask = Avx512F.CompareGreaterThan(va, vb); // returns a bitmask
    Avx512F.Store(pResult, Avx512F.BlendVariable(va, vb, mask));
}
```

Eliminates branch mispredictions inside SIMD loops entirely.

---

## The Auto-Vectorization Alternative

Sometimes you don't need to write intrinsics at all — the JIT/RyuJIT can auto-vectorize simple loops:

```csharp
// RyuJIT may vectorize this automatically
for (int i = 0; i < a.Length; i++)
    result[i] = a[i] + b[i];
```

You can check by examining the JIT output with **BenchmarkDotNet + Disassembler** or **sharplab.io**. But complex loops with dependencies or conditionals usually need manual intrinsics.

---

## Pitfalls

**Alignment** — Unaligned loads (`LoadVector256`) work but aligned loads (`LoadAlignedVector256`) are faster. Use `NativeMemory.AlignedAlloc(size, 32)` for AVX or `64` for AVX-512.

**Horizontal reduction is expensive** — SIMD is fast for vertical (lane-wise) ops. Reducing across lanes (summing all 8 floats) requires shuffles and is relatively slow. Minimize it.

**Not all types vectorize equally** — `float` and `int` are ideal. `double` halves your lane count. `byte`/`short` can be very efficient for image processing.

**Check support at runtime** — Always guard with `Avx.IsSupported`, `Avx2.IsSupported`, etc. Ship a scalar fallback.

---

## When SIMD Shines

- Signal/audio/image processing
- Linear algebra (matrix multiply, dot products)
- Physics simulations (particle systems)
- HFT — scanning order books, pricing
- ML inference (before you offload to GPU)
- Compression / hashing / encryption

The combination of **cache-friendly data layout + SIMD** is what separates microsecond-level C# from nanosecond-level C# in performance-critical systems.

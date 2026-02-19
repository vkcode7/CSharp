# LINQ — Language Integrated Query

## What Is LINQ?

LINQ is a set of language features and APIs that lets you query **any data source** using a uniform syntax directly in C#. It was introduced in C# 3.0 / .NET 3.5.

The key insight: instead of writing different query logic for arrays, databases, XML, and collections — you write **one mental model** that works everywhere.

---

## Two Syntax Styles

Both compile to identical IL — purely a style preference.

```csharp
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Query syntax (SQL-like)
var result = from n in numbers
             where n % 2 == 0
             orderby n descending
             select n * n;

// Method syntax (fluent / lambda)
var result = numbers
    .Where(n => n % 2 == 0)
    .OrderByDescending(n => n)
    .Select(n => n * n);
```

Method syntax is more commonly used in practice as it exposes the full API surface.

---

## The Six Flavors of LINQ

### 1. LINQ to Objects
Queries in-memory collections — arrays, `List<T>`, `IEnumerable<T>`, etc.

```csharp
var names = new List<string> { "Alice", "Bob", "Charlie", "Dave" };

var result = names
    .Where(n => n.Length > 3)
    .OrderBy(n => n)
    .ToList();
```

Runs entirely in process. Uses `IEnumerable<T>` and deferred execution.

---

### 2. LINQ to SQL / LINQ to Entities (EF Core)
Queries get translated to **SQL** and executed on a database.

```csharp
// This never runs in C# — it's translated to SQL
var users = dbContext.Users
    .Where(u => u.Age > 18)
    .OrderBy(u => u.Name)
    .Select(u => new { u.Name, u.Email })
    .ToList(); // SQL executes HERE
```

Generated SQL:
```sql
SELECT Name, Email FROM Users WHERE Age > 18 ORDER BY Name
```

Uses `IQueryable<T>` under the hood, not `IEnumerable<T>`.

---

### 3. LINQ to XML (XLinq)
Query and construct XML using LINQ syntax.

```csharp
XDocument doc = XDocument.Load("data.xml");

var products = doc.Descendants("Product")
    .Where(p => (int)p.Element("Price") > 100)
    .Select(p => p.Element("Name")?.Value);
```

---

### 4. LINQ to DataSet
Query ADO.NET `DataTable` and `DataSet` objects.

```csharp
var rows = dataTable.AsEnumerable()
    .Where(r => r.Field<int>("Age") > 18)
    .Select(r => r.Field<string>("Name"));
```

---

### 5. Parallel LINQ (PLINQ)
Parallelizes LINQ queries across multiple CPU cores automatically.

```csharp
var result = numbers
    .AsParallel()
    .Where(n => IsPrime(n))
    .ToList();

// Control degree of parallelism
var result = numbers
    .AsParallel()
    .WithDegreeOfParallelism(4)
    .Where(n => IsPrime(n))
    .ToList();
```

Covered in detail below.

---

### 6. Custom LINQ Providers
You can implement `IQueryProvider` to make LINQ query **anything** — REST APIs, MongoDB, CSV files, etc. This is how EF Core works internally.

---

## The Interfaces — `IEnumerable<T>` vs `IQueryable<T>`

This is the most important distinction in LINQ.

```
IEnumerable<T>          IQueryable<T>
─────────────────       ──────────────────────────────
In-memory               Translatable to external query
Pull-based iteration    Expression tree → SQL/other
Executes in C#          Executes on data source
LINQ to Objects         EF Core, custom providers
```

```csharp
IEnumerable<User> a = dbContext.Users.Where(u => u.Age > 18);
// Downloads ALL users, filters in memory ❌ (if Users is IEnumerable)

IQueryable<User> b = dbContext.Users.Where(u => u.Age > 18);
// Translates WHERE to SQL, filters on DB ✅
```

Always make sure you're working with `IQueryable<T>` when using EF Core until you intentionally materialize with `ToList()` / `AsEnumerable()`.

---

## Deferred vs Immediate Execution

One of the most misunderstood aspects of LINQ.

### Deferred (Lazy) Execution
The query is **defined** but **not run** until you iterate it.

```csharp
var query = numbers.Where(n => n > 5); // nothing runs here

// Query executes here, on each iteration
foreach (var n in query)
    Console.WriteLine(n);
```

This means:
```csharp
var numbers = new List<int> { 1, 2, 3 };
var query = numbers.Where(n => n > 1); // not evaluated yet

numbers.Add(10); // modify source

foreach (var n in query)
    Console.WriteLine(n); // sees 2, 3, 10 — includes the added item!
```

Operators that are deferred: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `Take`, `Skip`, `SelectMany`, ...

### Immediate Execution
Forces the query to run and materializes the result.

```csharp
var list   = query.ToList();       // executes now, returns List<T>
var array  = query.ToArray();      // executes now, returns T[]
var count  = query.Count();        // executes now
var first  = query.First();        // executes now
var any    = query.Any(n => n > 5);// executes now
var dict   = query.ToDictionary(x => x.Id); // executes now
```

---

## Internal Working — How LINQ to Objects Works

### Iterator Pattern
Every deferred LINQ operator is implemented as a **state machine iterator** using `yield return`.

Under the hood, `Where` looks roughly like:

```csharp
public static IEnumerable<T> Where<T>(
    this IEnumerable<T> source, 
    Func<T, bool> predicate)
{
    foreach (var item in source)
        if (predicate(item))
            yield return item;
}
```

When you chain operators, you build a **pipeline of iterators**:

```
Source Array
    ↓
Where iterator (wraps source)
    ↓
Select iterator (wraps Where)
    ↓
OrderBy iterator (wraps Select)
    ↓
foreach / ToList() — pulls data through the pipeline
```

Each `MoveNext()` call on the outermost iterator pulls through the whole chain one item at a time. This is called a **pull-based pipeline**.

---

### How `IQueryable<T>` Works — Expression Trees

For `IQueryable<T>`, LINQ doesn't execute lambdas — it captures them as **expression trees** (data structures representing code).

```csharp
Expression<Func<User, bool>> expr = u => u.Age > 18;
// expr is NOT a delegate — it's an AST describing the lambda
```

The LINQ provider (e.g. EF Core) walks this tree and translates it:

```
u.Age > 18
    │
BinaryExpression (GreaterThan)
├── MemberExpression (u.Age)
└── ConstantExpression (18)
    │
    ▼
SQL: "Age > 18"
```

This is why you can't use arbitrary C# methods inside EF Core queries — they can't be translated to SQL:

```csharp
// ✅ Works — translatable
.Where(u => u.Name.StartsWith("A"))

// ❌ Crashes at runtime — EF can't translate MyCustomMethod
.Where(u => MyCustomMethod(u.Name))
```

---

## PLINQ — Parallel LINQ in Depth

PLINQ partitions the source, processes chunks on thread pool threads, then merges results.

```csharp
var result = source
    .AsParallel()
    .AsOrdered()                        // preserve order (has cost)
    .WithDegreeOfParallelism(8)         // max threads
    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
    .Where(x => Expensive(x))
    .Select(x => Transform(x))
    .ToList();
```

### Partitioning Strategies

PLINQ uses different strategies to split work:

```
Range partitioning   — chunk [0..N/4], [N/4..N/2], ...  (arrays, known size)
Chunk partitioning   — threads grab chunks dynamically   (IEnumerable)
Hash partitioning    — for GroupBy / Join operations
```

### When PLINQ Helps vs Hurts

```csharp
// ✅ Good — expensive per-item work, large collection
.AsParallel().Where(x => ExpensiveCPUWork(x))

// ❌ Bad — trivial work, overhead exceeds benefit
.AsParallel().Where(x => x > 5)

// ❌ Bad — I/O bound work (use async instead)
.AsParallel().Select(x => File.ReadAllText(x))
```

---

## Key Operators — Internal Behavior

### `OrderBy` — Full Buffering
`OrderBy` must **consume the entire source** before returning anything — it can't sort without seeing all elements.

```csharp
// This buffers everything into memory before yielding
.OrderBy(x => x.Name)
```

### `GroupBy` — Full Buffering
Same — must see all elements to form groups.

### `SelectMany` — Flattening
```csharp
var words = sentences.SelectMany(s => s.Split(' '));
// Flattens IEnumerable<IEnumerable<T>> → IEnumerable<T>
```

### `Join` — Hash Join
```csharp
var result = orders.Join(
    customers,
    o => o.CustomerId,   // outer key
    c => c.Id,           // inner key
    (o, c) => new { o.OrderId, c.Name });
```

Internally builds a **hash lookup** of the inner sequence, then probes it for each outer element. O(n + m) not O(n × m).

### `Aggregate`
The most general operator — everything else can be expressed with it:

```csharp
// Sum via Aggregate
var sum = numbers.Aggregate(0, (acc, x) => acc + x);

// Reverse via Aggregate
var reversed = numbers.Aggregate(
    new List<int>(),
    (acc, x) => { acc.Insert(0, x); return acc; });
```

---

## Common Mistakes and Pitfalls

### 1. Multiple Enumeration
```csharp
var query = source.Where(x => x > 5); // deferred

var count = query.Count();  // iterates once
var list  = query.ToList(); // iterates AGAIN

// ✅ Fix
var list  = source.Where(x => x > 5).ToList();
var count = list.Count;
```

### 2. N+1 Query Problem (EF Core)
```csharp
// ❌ Executes 1 query for orders + N queries for customers
foreach (var order in dbContext.Orders.ToList())
    Console.WriteLine(order.Customer.Name); // lazy load per row

// ✅ Fix — eager load
var orders = dbContext.Orders.Include(o => o.Customer).ToList();
```

### 3. Closing Over Loop Variables
```csharp
var funcs = new List<Func<int>>();
for (int i = 0; i < 5; i++)
    funcs.Add(() => i); // all capture the same 'i'!

// All print 5 — ❌
funcs.ForEach(f => Console.WriteLine(f()));

// ✅ Fix — capture a local copy
for (int i = 0; i < 5; i++)
{
    int local = i;
    funcs.Add(() => local);
}
```

### 4. `AsEnumerable()` Too Early in EF Core
```csharp
// ❌ Downloads entire table, filters in memory
dbContext.Users.AsEnumerable().Where(u => u.Age > 18)

// ✅ Filters on database
dbContext.Users.Where(u => u.Age > 18).AsEnumerable()
```

---

## Pros of LINQ

**Readability** — expressive, declarative code that reads like intent, not mechanics.

**Composability** — chain operators cleanly, build queries incrementally.

**Uniform API** — same mental model for arrays, databases, XML, and custom sources.

**Type safety** — compile-time checking of query structure (unlike raw SQL strings).

**Lazy evaluation** — deferred execution avoids unnecessary work.

**Testability** — pure functions and expression trees are easy to unit test.

---

## Cons of LINQ

**Performance overhead** — lambda allocation, iterator boxing, and delegate calls add cost vs raw loops. For hot paths, a manual `for` loop is faster.

**Debugging difficulty** — stepping through chained lambdas in a debugger is painful. Stack traces inside LINQ pipelines can be cryptic.

**Deferred execution surprises** — bugs from unexpected re-evaluation or capturing mutable state.

**EF Core translation limits** — not all C# is translatable. Runtime `InvalidOperationException` errors when EF can't translate your expression.

**Hidden complexity** — `OrderBy`, `GroupBy`, and `Join` do things behind the scenes (full buffering, hash tables) that aren't obvious from the syntax.

**PLINQ is not magic** — parallel overhead can easily exceed gains for small or cheap workloads.

---

## Performance Comparison

```csharp
// Benchmark: sum of even numbers, 10 million elements

// Raw for loop — baseline
long sum = 0;
for (int i = 0; i < arr.Length; i++)
    if (arr[i] % 2 == 0) sum += arr[i];
// ~8ms

// LINQ
long sum = arr.Where(x => x % 2 == 0).Sum();
// ~35ms  (~4x slower due to delegate overhead + iterator)

// PLINQ
long sum = arr.AsParallel().Where(x => x % 2 == 0).Sum();
// ~12ms on 8 cores (but coordination overhead limits gains)
```

For non-hot-path code, LINQ's overhead is irrelevant. For tight inner loops, avoid it.

---

## Summary

```
LINQ to Objects      → IEnumerable<T>, in-memory, iterator pipeline
LINQ to Entities     → IQueryable<T>, expression trees → SQL
LINQ to XML          → XDocument / XElement querying
PLINQ                → AsParallel(), multi-core, partition + merge

Deferred operators   → Where, Select, OrderBy, GroupBy, Join, ...
Immediate operators  → ToList, Count, First, Any, Sum, ToDictionary, ...

Key internals:
  IEnumerable → yield return state machines
  IQueryable  → expression trees → translated to target query language
```

LINQ is one of C#'s most powerful features. Use it freely for clarity in most code, and know when to drop down to raw loops, `Span<T>`, or SIMD for performance-critical paths.

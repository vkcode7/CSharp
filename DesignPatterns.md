Here is a practical overview of the **most important and frequently used design patterns in modern C#** (2024–2025 perspective), grouped by category with very concise explanations and realistic C# examples.

### Creational Patterns

| Pattern              | When to use it                                   | Most common C# idiom today                     | Quick code smell that screams for it          |
|----------------------|--------------------------------------------------|------------------------------------------------|-----------------------------------------------|
| Singleton            | Exactly one instance (logger, config, cache)     | `Lazy<T>` + static or .NET 8+ module initializer | Multiple `new MyConfig()` everywhere          |
| Factory Method       | Delegate creation to subclasses                  | `virtual CreateXXX()` in base class            | Large switch on type string/enum              |
| Abstract Factory     | Families of related objects                      | Interface with multiple creation methods       | Creating related objects in many places       |
| Builder              | Complex object construction, fluent API          | Fluent interface + optional Director           | Constructor with 8+ parameters                |
| Prototype            | Expensive cloning / deep copy                    | `ICloneable` (controversial) or record with `with` | Manual deep-copy logic repeated               |

**Most used in 2025 C#** → **Builder**, **Lazy<T> Singleton**, **Abstract Factory** (DI style)

### Structural Patterns

| Pattern              | Intent                                           | Typical C# realization                         | When you usually discover you need it         |
|----------------------|--------------------------------------------------|------------------------------------------------|-----------------------------------------------|
| Adapter              | Make incompatible interfaces work together       | Wrapper class / object adapter                 | 3rd-party library has wrong interface         |
| Bridge               | Decouple abstraction from implementation         | Two parallel hierarchies                       | Explosion of subclasses (Window × OS)         |
| Composite            | Treat individual objects and compositions uniformly | Tree structure with same interface             | Menu, file system, UI controls hierarchy      |
| Decorator            | Add responsibilities dynamically                 | Wrapper that implements same interface         | Many optional features (logging, caching, …)  |
| Facade               | Simplify complex subsystem                       | High-level coarse-grained interface            | Using 7 different services to do one thing    |
| Proxy                | Control access (lazy, remote, protection, cache) | Class that delegates to real subject           | Lazy loading, security checks, logging        |

**Most used today** → **Facade**, **Decorator**, **Proxy** (especially in libraries & middleware)

### Behavioral Patterns

| Pattern                  | When / why to use it                                   | Very common C# form today                         | Typical trigger phrase                        |
|--------------------------|--------------------------------------------------------|---------------------------------------------------|-----------------------------------------------|
| Strategy                 | Interchangeable algorithms                             | Interface + DI                                    | "depending on user choice / config…"          |
| Command                  | Encapsulate request as object (undo, queue, logging)   | `ICommand` with `Execute()` / `Undo()`            | Undo/redo, queued operations, macros          |
| Observer                 | One-to-many dependency (pub-sub)                       | `event` / `IObservable<T>` / Reactive Extensions  | "when something changes, notify many…"        |
| State                    | Object behavior changes with internal state            | State pattern or stateless library                | Large switch on status/enum                   |
| Template Method          | Algorithm skeleton in base, details in subclasses      | `virtual` / `abstract` methods                    | "same steps, different implementation"        |
| Chain of Responsibility  | Pass request along chain of handlers                   | Middleware pattern (ASP.NET Core)                 | Request filters, approval workflows           |
| Mediator                 | Reduce coupling between many objects                   | MediatR library (very popular)                    | "too many classes talking directly"           |
| Iterator                 | Traverse collection without exposing structure         | `IEnumerable<T>` + `yield return`                 | Almost never written manually today           |
| Visitor                  | Add operations to class hierarchy without modifying it | Double dispatch                                   | Rarely needed, but powerful in compilers/AST  |

### Top 10 Most Frequently Used Patterns in Modern C# Applications (2024–2025)

1. **Dependency Injection** (technically architectural, but behaves like pattern)
2. **Repository** + **Unit of Work** (data access)
3. **Mediator** (MediatR / Vertical Slice)
4. **Decorator** (logging, caching, validation middleware)
5. **Strategy** (payment methods, shipping calculators, discount rules)
6. **Factory** / **Abstract Factory** (DI factories)
7. **Builder** (configuration objects, complex DTOs, test data)
8. **Facade** (service layer, application services)
9. **Observer** (`INotifyPropertyChanged`, SignalR, events)
10. **Chain of Responsibility** (ASP.NET Core middleware pipeline)

### Very Quick Cheatsheet – One-liner + modern C# flavor

```csharp
// Singleton (lazy + thread-safe)
public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _instance = new(() => new AppConfig());
    public static AppConfig Instance => _instance.Value;
    private AppConfig() { ... }
}

// Builder (record + with expressions – very popular 2024+)
public record OrderRequestBuilder
{
    public string Customer { get; init; } = "";
    public decimal Amount { get; init; }
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.Today);

    public OrderRequest Build() => new(Customer, Amount, Date);
}

// Strategy + DI
services.AddScoped<IPriceCalculator, WeekendPriceCalculator>();
services.AddScoped<IPriceCalculator, HolidayPriceCalculator>(sp => 
    date.IsHoliday() ? sp.GetRequiredService<HolidayPriceCalculator>() : ...);

// Decorator pattern (ASP.NET style middleware)
app.Use(async (context, next) =>
{
    // before
    await next();
    // after
});

// Mediator (MediatR style)
public record CreateUserCommand(string Email, string Name) : IRequest<UserDto>;
```

Which pattern family or specific pattern would you like to see with a more complete, realistic example (including tests, DI registration, real-world trade-offs)?

- CQRS + Mediator
- Specification pattern
- Notification / Domain Events
- Pipeline behaviors (validation, caching, logging)
- Full vertical slice example
- State machine (classic vs stateless library)

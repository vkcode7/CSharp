**SOLID** is an acronym for five important principles of **object-oriented design** introduced by Robert C. Martin (Uncle Bob).  
These principles help developers write more **maintainable**, **flexible**, **testable** and **understandable** code — especially in medium-to-large systems.

Here are the five principles with clear C# explanations and examples:

| Letter | Principle                        | One-sentence meaning                                                                 | Most common violation smell                     |
|--------|----------------------------------|--------------------------------------------------------------------------------------|--------------------------------------------------|
| **S**  | Single Responsibility Principle  | A class should have only one reason to change                                   | “God class”, many unrelated methods              |
| **O**  | Open–Closed Principle            | Classes should be **open for extension**, **closed for modification**               | Massive switch/case or if-else chains            |
| **L**  | Liskov Substitution Principle    | Subtypes must be substitutable for their base types without breaking behavior       | Overriding that throws NotSupportedException     |
| **I**  | Interface Segregation Principle  | Many small, client-specific interfaces > one large/general-purpose interface        | Fat interfaces with many unused methods          |
| **D**  | Dependency Inversion Principle   | High-level modules should not depend on low-level modules — both depend on abstractions | Direct `new` of concrete classes inside business logic |

### 1. S – Single Responsibility Principle (SRP)

**Bad** (violates SRP)

```csharp
public class UserService
{
    public void RegisterUser(string email, string password)
    {
        // validation
        // save to database
        // send welcome email
        // write to log file
        // generate JWT token
        // update marketing system via HTTP
    }
}
```

**Good** (follows SRP)

```csharp
public class UserRegistrationService
{
    private readonly IUserRepository _repo;
    private readonly IEmailSender _emailSender;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public UserRegistrationService(IUserRepository repo, IEmailSender sender, IJwtTokenGenerator tokenGen)
    {
        _repo = repo;
        _emailSender = sender;
        _tokenGenerator = tokenGen;
    }

    public async Task RegisterAsync(string email, string password)
    {
        var user = new User { Email = email, /* ... */ };
        await _repo.SaveAsync(user);
        await _emailSender.SendWelcomeEmailAsync(email);
        var token = _tokenGenerator.Generate(user);
        // return token or whatever
    }
}
```

Each class has **one responsibility** → easier to test, reuse, change.

### 2. O – Open–Closed Principle (OCP)

**Bad** (violates OCP – every new payment type requires changing this class)

```csharp
public class PaymentProcessor
{
    public void ProcessPayment(string paymentType, decimal amount)
    {
        if (paymentType == "CreditCard") { /* ... */ }
        else if (paymentType == "PayPal") { /* ... */ }
        else if (paymentType == "ApplePay") { /* ... */ }
        // → new payment type → modify this class
    }
}
```

**Good** (follows OCP)

```csharp
public interface IPaymentMethod
{
    Task ProcessAsync(decimal amount);
}

public class CreditCardPayment : IPaymentMethod { /* ... */ }
public class PayPalPayment     : IPaymentMethod { /* ... */ }
public class ApplePayPayment   : IPaymentMethod { /* ... */ }

public class PaymentProcessor
{
    private readonly IPaymentMethod _method;

    public PaymentProcessor(IPaymentMethod method)  // injected
    {
        _method = method;
    }

    public async Task ProcessAsync(decimal amount)
    {
        await _method.ProcessAsync(amount);
    }
}
```

You can add new payment methods **without touching** `PaymentProcessor`.

### 3. L – Liskov Substitution Principle (LSP)

**Bad** (violates LSP)

```csharp
public class Bird
{
    public virtual void Fly() { Console.WriteLine("Flying..."); }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly!");
    }
}

// Client code breaks unexpectedly
void MakeBirdFly(Bird bird) => bird.Fly();   // ← boom when penguin
```

**Good** (follows LSP)

```csharp
public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : IFlyingBird { public void Fly() { /* ... */ } }
public class Eagle   : IFlyingBird { public void Fly() { /* ... */ } }

public class Penguin { /* no Fly method */ }
```

Now you cannot pass a `Penguin` where a flying bird is expected → type system helps prevent misuse.

### 4. I – Interface Segregation Principle (ISP)

**Bad** (fat interface)

```csharp
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
    void AttendMeeting();
}

public class Robot : IWorker
{
    public void Work() { /* ... */ }
    public void Eat()   { throw new NotImplementedException(); }
    public void Sleep() { throw new NotImplementedException(); }
    // ...
}
```

**Good** (segregated interfaces)

```csharp
public interface IWorkable     { void Work(); }
public interface IEatable      { void Eat(); }
public interface ISleepable    { void Sleep(); }
public interface IMeetingAware { void AttendMeeting(); }

public class Human : IWorkable, IEatable, ISleepable, IMeetingAware { /* ... */ }
public class Robot : IWorkable { /* ... */ }
```

Clients only depend on what they actually need.

### 5. D – Dependency Inversion Principle (DIP)

**Bad** (high-level module depends on low-level detail)

```csharp
public class OrderService
{
    private readonly SqlServerOrderRepository _repo = new SqlServerOrderRepository();

    public void SaveOrder(Order order)
    {
        _repo.Save(order);
    }
}
```

**Good** (both depend on abstraction)

```csharp
public interface IOrderRepository
{
    void Save(Order order);
}

public class SqlServerOrderRepository : IOrderRepository { /* ... */ }
public class InMemoryOrderRepository : IOrderRepository { /* for tests */ }

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)   // ← injected
    {
        _repository = repository;
    }

    public void SaveOrder(Order order)
    {
        _repository.Save(order);
    }
}
```

High-level policy (`OrderService`) **does not know** about concrete storage — very powerful for testing & changing infrastructure.

### Quick Mnemonic Summary (2025 style)

- **S** – One job per class  
- **O** – Extend, don’t modify  
- **L** – Child must behave like parent (no surprises)  
- **I** – Small interfaces → happy clients  
- **D** – Depend on abstractions, not concretions

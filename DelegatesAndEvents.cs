using System;
using System.Collections.Generic;

#region Part 1: Understanding Delegates

/*
Part 1: What Are Delegates?
Delegates are type-safe function pointers that can hold references to both static and instance methods. Think of them as "variables that hold methods."
Key Concepts:

Type Safety: Delegates can only reference methods with matching signatures
Multicast: Can hold multiple method references
Null Safety: Can be null, use ?.Invoke() for safe calling


Custom Delegates
================
public delegate int MathOperation(int x, int y);
public delegate void SimpleAction();

Built-in Delegates (Preferred)
==============================
Action<T>: Methods that return void
Func<T, TResult>: Methods that return a value
Predicate<T>: Methods that return bool

Lambda Expressions
==================
// Traditional method
Predicate<int> isEven1 = IsEven;

// Anonymous method (C# 2.0)
Predicate<int> isEven2 = delegate(int x) { return x % 2 == 0; };

// Lambda expression (C# 3.0+) - Preferred
Predicate<int> isEven3 = x => x % 2 == 0;

What Are Events?
================
Events are a special kind of multicast delegate with additional restrictions:

Encapsulation: Only the class that declares an event can raise it
Safety: External classes can only subscribe/unsubscribe, not assign or invoke
Publisher-Subscriber Pattern: Enable loose coupling between components

// Delegate - external classes can do anything
public Action<string> MyDelegate;

// Event - external classes can only subscribe/unsubscribe
public event Action<string> MyEvent;

Best Practices
==============
For Delegates:

Use built-in delegates (Action, Func, Predicate) instead of custom ones
Prefer lambda expressions for simple, one-off delegates
Use method groups when referencing existing methods
Check for null before invoking: myDelegate?.Invoke()

For Events:

Follow the standard pattern with EventHandler<T>
Create custom EventArgs for event data
Use protected virtual methods to raise events
Always check for null before raising events
Consider using weak references for long-lived publishers

Common Use Cases
================
Delegates:

Callbacks: Pass methods as parameters
Strategy Pattern: Different algorithms for same operation
Functional Programming: LINQ, Where, Select, etc.
Event Handling: Button clicks, property changes

Events:

UI Events: Button clicks, form closing
Progress Reporting: File processing, downloads
State Changes: Property changed notifications
System Notifications: Errors, warnings, status updates

Memory and Performance
======================
Memory Considerations:

Event Subscriptions can cause memory leaks if not unsubscribed
Closures in lambdas capture local variables, keeping them alive
Multicast delegates create a new delegate instance when combined

Performance Tips:

Method groups are more efficient than lambdas for existing methods
Static methods in delegates have less overhead than instance methods
Avoid frequent delegate creation in hot paths

Event Aggregator Pattern:
=========================
Central hub for loosely-coupled communication
Useful in MVVM and large applications

*/

// ================================
// PART 1: DELEGATES FUNDAMENTALS
// ================================

// Step 1: Basic delegate declaration
// A delegate is a type that defines the signature of methods it can reference

// Delegate Types:
// 1. Custom Delegates
// 2. Built In Delegates
public delegate int MathOperation(int x, int y); //A Custom Delegate
public delegate void SimpleAction();
public delegate string MessageFormatter(string message);

public class DelegateBasics
{
    // Methods that match the MathOperation delegate signature
    public static int Add(int x, int y) => x + y;
    public static int Subtract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;

    // Methods that match SimpleAction delegate signature
    public static void SayHello() => Console.WriteLine("Hello from static method!");
    public void SayGoodbye() => Console.WriteLine("Goodbye from instance method!");

    // Methods that match MessageFormatter delegate signature
    public static string ToUpper(string msg) => msg.ToUpper();
    public static string AddPrefix(string msg) => $"[INFO] {msg}";

    public static void DemonstrateBasics()
    {
        Console.WriteLine("=== DELEGATE BASICS ===\n");

        // Creating and using delegates
        MathOperation operation;
        
        // Method 1: Using constructor syntax
        operation = new MathOperation(Add);
        Console.WriteLine($"Add(5, 3) = {operation(5, 3)}");

        // Method 2: Direct assignment (preferred)
        operation = Subtract;
        Console.WriteLine($"Subtract(5, 3) = {operation(5, 3)}");

        // Method 3: Using method groups
        operation = Multiply;
        Console.WriteLine($"Multiply(5, 3) = {operation(5, 3)}");

        // Delegates can hold instance methods too
        var basics = new DelegateBasics();
        SimpleAction action = basics.SayGoodbye;
        action(); // Calls the instance method

        // Null delegates
        SimpleAction nullAction = null;
        nullAction?.Invoke(); // Safe call - won't throw if null

        Console.WriteLine();
    }
}

#endregion

#region Part 2: Multicast Delegates

public class MulticastDelegates
{
    public static void Method1() => Console.WriteLine("Method 1 executed");
    public static void Method2() => Console.WriteLine("Method 2 executed");
    public static void Method3() => Console.WriteLine("Method 3 executed");

    public static void DemonstrateMulticast()
    {
        Console.WriteLine("=== MULTICAST DELEGATES ===\n");

        SimpleAction multiAction = null;

        // Adding methods to delegate (multicast)
        multiAction += Method1;
        multiAction += Method2;
        multiAction += Method3;

        Console.WriteLine("Calling multicast delegate:");
        multiAction(); // Calls all three methods in order

        Console.WriteLine("\nRemoving Method2:");
        multiAction -= Method2;
        multiAction(); // Calls Method1 and Method3

        // Return values in multicast delegates
        // WARNING: Only the last method's return value is returned!
        MathOperation multiMath = null;
        multiMath += DelegateBasics.Add;
        multiMath += DelegateBasics.Multiply;

        Console.WriteLine($"\nMulticast with return values: {multiMath(5, 3)}");
        Console.WriteLine("Note: Only the last method's return value (Multiply) is returned!");

        Console.WriteLine();
    }
}

#endregion

#region Part 3: Built-in Delegates (Action, Func, Predicate)

/*
Action<T>: Methods that return void
Func<T, TResult>: Methods that return a value
Predicate<T>: Methods that return bool
*/
  
public class BuiltInDelegates
{
    public static void DemonstrateBuiltInDelegates()
    {
        Console.WriteLine("=== BUILT-IN DELEGATES ===\n");

        // Action<T> - delegates for methods that return void
        Action simpleAction = () => Console.WriteLine("Simple action executed");
        Action<string> actionWithParam = msg => Console.WriteLine($"Message: {msg}");
        Action<int, int> actionWithTwoParams = (x, y) => Console.WriteLine($"Sum: {x + y}");

        simpleAction();
        actionWithParam("Hello Action!");
        actionWithTwoParams(10, 20);

        // Func<T, TResult> - delegates for methods that return a value
        Func<int> getRandomNumber = () => new Random().Next(1, 100);
        Func<int, int, int> add = (x, y) => x + y;
        Func<string, bool> isLongString = str => str.Length > 10;

        Console.WriteLine($"Random number: {getRandomNumber()}");
        Console.WriteLine($"Add(15, 25): {add(15, 25)}");
        Console.WriteLine($"Is 'Hello World!' long? {isLongString("Hello World!")}");

        // Predicate<T> - special Func<T, bool> for testing conditions
        Predicate<int> isEven = x => x % 2 == 0;
        Predicate<string> startsWithA = str => str.StartsWith("A", StringComparison.OrdinalIgnoreCase);

        Console.WriteLine($"Is 42 even? {isEven(42)}");
        Console.WriteLine($"Does 'Apple' start with A? {startsWithA("Apple")}");

        // Using with collections
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenNumbers = numbers.FindAll(isEven);
        Console.WriteLine($"Even numbers: [{string.Join(", ", evenNumbers)}]");

        Console.WriteLine();
    }
}

#endregion

#region Part 4: Lambda Expressions and Anonymous Methods

public class LambdaExpressions
{
    public static void DemonstrateLambdas()
    {
        Console.WriteLine("=== LAMBDA EXPRESSIONS ===\n");

        // Evolution of delegate syntax
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1. Traditional method
        Predicate<int> isEvenTraditional = IsEven;
        
        // 2. Anonymous method (C# 2.0)
        Predicate<int> isEvenAnonymous = delegate(int x) { return x % 2 == 0; };
        
        // 3. Lambda expression (C# 3.0) - preferred
        Predicate<int> isEvenLambda = x => x % 2 == 0;

        // Different lambda syntaxes
        Func<int, int> square1 = x => x * x;                    // Single parameter, expression
        Func<int, int> square2 = (x) => x * x;                  // Parentheses optional for single param
        Func<int, int, int> add1 = (x, y) => x + y;             // Multiple parameters
        Func<int, string> format1 = x => $"Number: {x}";        // Different return type
        
        // Statement lambdas (multiple statements)
        Func<int, string> complexLambda = x =>
        {
            if (x < 0) return "Negative";
            if (x == 0) return "Zero";
            return "Positive";
        };

        // Action lambdas
        Action<string> print = msg => Console.WriteLine($"Lambda says: {msg}");

        // Demonstration
        Console.WriteLine("Finding even numbers using different approaches:");
        Console.WriteLine($"Traditional: [{string.Join(", ", numbers.FindAll(isEvenTraditional))}]");
        Console.WriteLine($"Anonymous: [{string.Join(", ", numbers.FindAll(isEvenAnonymous))}]");
        Console.WriteLine($"Lambda: [{string.Join(", ", numbers.FindAll(isEvenLambda))}]");

        print("Lambda expressions are powerful!");

        // Closure example - capturing local variables
        int multiplier = 5;
        Func<int, int> multiplyBy = x => x * multiplier; // Captures 'multiplier'
        Console.WriteLine($"10 * {multiplier} = {multiplyBy(10)}");

        multiplier = 10; // Changing captured variable
        Console.WriteLine($"10 * {multiplier} = {multiplyBy(10)}"); // Uses updated value

        Console.WriteLine();
    }

    private static bool IsEven(int x) => x % 2 == 0;
}

#endregion

#region Part 5: Events - The Basics

/*
What Are Events?
Events are a special kind of multicast delegate with additional restrictions:

- Encapsulation: Only the class that declares an event can raise it
- Safety: External classes can only subscribe/unsubscribe, not assign or invoke
- Publisher-Subscriber Pattern: Enable loose coupling between components
*/

// Publisher class that raises events
public class NewsPublisher
{
    // Event declaration using built-in EventHandler delegate
    public event EventHandler<NewsEventArgs> NewsPublished;

    // Custom event with custom delegate
    public delegate void BreakingNewsHandler(string news, DateTime timestamp);
    public event BreakingNewsHandler BreakingNews;

    private string _name;

    public NewsPublisher(string name)
    {
        _name = name;
    }

    public void PublishNews(string headline, string content)
    {
        Console.WriteLine($"\n[{_name}] Publishing: {headline}");
        
        // Raise the event - note the null check and local copy
        var handler = NewsPublished;
        handler?.Invoke(this, new NewsEventArgs(headline, content));
    }

    public void PublishBreakingNews(string news)
    {
        Console.WriteLine($"\n[{_name}] BREAKING NEWS: {news}");
        
        // Raise breaking news event
        BreakingNews?.Invoke(news, DateTime.Now);
    }

    // Protected virtual method pattern for raising events
    protected virtual void OnNewsPublished(NewsEventArgs e)
    {
        NewsPublished?.Invoke(this, e);
    }
}

// Custom EventArgs class
public class NewsEventArgs : EventArgs
{
    public string Headline { get; }
    public string Content { get; }
    public DateTime PublishedAt { get; }

    public NewsEventArgs(string headline, string content)
    {
        Headline = headline;
        Content = content;
        PublishedAt = DateTime.Now;
    }
}

// Subscriber classes
public class NewsSubscriber
{
    private string _name;

    public NewsSubscriber(string name)
    {
        _name = name;
    }

    public void Subscribe(NewsPublisher publisher)
    {
        // Subscribe to events
        publisher.NewsPublished += OnNewsReceived;
        publisher.BreakingNews += OnBreakingNewsReceived;
    }

    public void Unsubscribe(NewsPublisher publisher)
    {
        // Unsubscribe from events
        publisher.NewsPublished -= OnNewsReceived;
        publisher.BreakingNews -= OnBreakingNewsReceived;
    }

    private void OnNewsReceived(object sender, NewsEventArgs e)
    {
        Console.WriteLine($"[{_name}] Received news: {e.Headline} at {e.PublishedAt:HH:mm:ss}");
    }

    private void OnBreakingNewsReceived(string news, DateTime timestamp)
    {
        Console.WriteLine($"[{_name}] ALERT: {news} (received at {timestamp:HH:mm:ss})");
    }
}

#endregion

#region Part 6: Advanced Event Patterns

// Custom event accessor example
public class AdvancedEventPublisher
{
    private EventHandler<string> _customEvent;

    // Custom event with add/remove accessors
    public event EventHandler<string> CustomEvent
    {
        add
        {
            Console.WriteLine("Subscriber added to CustomEvent");
            _customEvent += value;
        }
        remove
        {
            Console.WriteLine("Subscriber removed from CustomEvent");
            _customEvent -= value;
        }
    }

    public void RaiseCustomEvent(string message)
    {
        _customEvent?.Invoke(this, message);
    }
}

// Event aggregator pattern
public class EventAggregator
{
    private readonly Dictionary<Type, List<Delegate>> _eventHandlers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        var eventType = typeof(T);
        if (!_eventHandlers.ContainsKey(eventType))
        {
            _eventHandlers[eventType] = new List<Delegate>();
        }
        _eventHandlers[eventType].Add(handler);
    }

    public void Publish<T>(T eventData)
    {
        var eventType = typeof(T);
        if (_eventHandlers.TryGetValue(eventType, out var handlers))
        {
            foreach (Action<T> handler in handlers.Cast<Action<T>>())
            {
                handler(eventData);
            }
        }
    }
}

#endregion

#region Part 7: Real-World Examples

// File processor with progress events
public class FileProcessor
{
    public event EventHandler<ProgressEventArgs> ProgressChanged;
    public event EventHandler ProcessingCompleted;
    public event EventHandler<ErrorEventArgs> ErrorOccurred;

    public void ProcessFiles(string[] filePaths)
    {
        try
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                // Simulate file processing
                Console.WriteLine($"Processing: {filePaths[i]}");
                System.Threading.Thread.Sleep(100); // Simulate work

                // Report progress
                var progress = (int)((double)(i + 1) / filePaths.Length * 100);
                OnProgressChanged(new ProgressEventArgs(progress, filePaths[i]));

                // Simulate occasional error
                if (filePaths[i].Contains("error"))
                {
                    OnErrorOccurred(new ErrorEventArgs($"Error processing {filePaths[i]}"));
                    continue;
                }
            }

            OnProcessingCompleted();
        }
        catch (Exception ex)
        {
            OnErrorOccurred(new ErrorEventArgs($"Fatal error: {ex.Message}"));
        }
    }

    protected virtual void OnProgressChanged(ProgressEventArgs e)
    {
        ProgressChanged?.Invoke(this, e);
    }

    protected virtual void OnProcessingCompleted()
    {
        ProcessingCompleted?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnErrorOccurred(ErrorEventArgs e)
    {
        ErrorOccurred?.Invoke(this, e);
    }
}

public class ProgressEventArgs : EventArgs
{
    public int PercentComplete { get; }
    public string CurrentFile { get; }

    public ProgressEventArgs(int percentComplete, string currentFile)
    {
        PercentComplete = percentComplete;
        CurrentFile = currentFile;
    }
}

public class ErrorEventArgs : EventArgs
{
    public string Message { get; }

    public ErrorEventArgs(string message)
    {
        Message = message;
    }
}

#endregion

#region Main Program

public class Program
{
    public static void Main()
    {
        // Part 1: Delegate Basics
        DelegateBasics.DemonstrateBasics();

        // Part 2: Multicast Delegates
        MulticastDelegates.DemonstrateMulticast();

        // Part 3: Built-in Delegates
        BuiltInDelegates.DemonstrateBuiltInDelegates();

        // Part 4: Lambda Expressions
        LambdaExpressions.DemonstrateLambdas();

        Console.WriteLine(new string('=', 80));

        // Part 5: Events Demo
        DemonstrateEvents();

        Console.WriteLine(new string('=', 80));

        /*
        Event Aggregator Pattern:

        Central hub for loosely-coupled communication
        Useful in MVVM and large applications
        */
      
        // Part 6: Advanced Patterns
        DemonstrateAdvancedPatterns();

        Console.WriteLine(new string('=', 80));

        // Part 7: Real-world Example
        DemonstrateRealWorldExample();
    }

    private static void DemonstrateEvents()
    {
        Console.WriteLine("\n=== EVENTS DEMONSTRATION ===\n");

        var publisher = new NewsPublisher("TechNews");
        var subscriber1 = new NewsSubscriber("Alice");
        var subscriber2 = new NewsSubscriber("Bob");

        // Subscribe to events
        subscriber1.Subscribe(publisher);
        subscriber2.Subscribe(publisher);

        // Publish some news
        publisher.PublishNews("C# 12 Released", "Microsoft announces new features...");
        publisher.PublishBreakingNews("Major Security Update Available");

        // Unsubscribe one subscriber
        Console.WriteLine("\n--- Bob unsubscribes ---");
        subscriber2.Unsubscribe(publisher);

        // Publish more news
        publisher.PublishNews("New Framework Update", "Performance improvements...");
    }

    private static void DemonstrateAdvancedPatterns()
    {
        Console.WriteLine("\n=== ADVANCED EVENT PATTERNS ===\n");

        // Custom event accessors
        var advancedPublisher = new AdvancedEventPublisher();
        advancedPublisher.CustomEvent += (sender, message) => 
            Console.WriteLine($"Received: {message}");
        
        advancedPublisher.RaiseCustomEvent("Hello from custom event!");

        // Event aggregator
        Console.WriteLine("\n--- Event Aggregator Pattern ---");
        var aggregator = new EventAggregator();
        
        aggregator.Subscribe<string>(message => 
            Console.WriteLine($"String handler: {message}"));
        aggregator.Subscribe<int>(number => 
            Console.WriteLine($"Int handler: {number}"));

        aggregator.Publish("Hello Event Aggregator!");
        aggregator.Publish(42);
    }

    private static void DemonstrateRealWorldExample()
    {
        Console.WriteLine("\n=== REAL-WORLD EXAMPLE: FILE PROCESSOR ===\n");

        var processor = new FileProcessor();

        // Subscribe to events
        processor.ProgressChanged += (sender, e) =>
            Console.WriteLine($"Progress: {e.PercentComplete}% - {e.CurrentFile}");

        processor.ProcessingCompleted += (sender, e) =>
            Console.WriteLine("All files processed successfully!");

        processor.ErrorOccurred += (sender, e) =>
            Console.WriteLine($"ERROR: {e.Message}");

        // Process some files
        var files = new[]
        {
            "document1.txt",
            "image.jpg",
            "error_file.dat",  // This will cause an error
            "data.csv",
            "presentation.ppt"
        };

        processor.ProcessFiles(files);
    }
}

#endregion

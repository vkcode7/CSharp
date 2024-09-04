# Lambdas and LINQ:
```c#
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExamples
{
   public class EntryPoint
   {
       static void Main()
       {
           string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
           List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
           object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

           Console.WriteLine(new string('-', 40));
           // 1. Extract odd numbers with Lambda
           List<int> oddNumbers = numbers.Where(n => (n % 2) == 1).ToList();

           Console.WriteLine("The odd numbers are: " + string.Join(", ", oddNumbers));

           Console.WriteLine(new string('-', 40));
           // 2. Average Lambda
           double average = catNames.Average(c => c.Length);

           Console.WriteLine($"The average length of the cat names is: {average}");

           Console.WriteLine(new string('-', 40));
           // 3. Min, Max Lambda
           double minCatNameLength = catNames.Min(c => c.Length);
           double maxCatNameLength = catNames.Max(c => c.Length);
           double sumOfCatNameLengths = catNames.Sum(c => c.Length);

           Console.WriteLine($"Cat names length and sum - Min: {minCatNameLength}, Max: {maxCatNameLength}, Sum: {sumOfCatNameLengths}");

           Console.WriteLine(new string('-', 40));
           // 4. OfType Lambda
           var allInts = mix.OfType<int>();
           var allIntsLessThanThree = mix.OfType<int>().Where(i => i < 3);
           var containsIntLists = mix.OfType<List<int>>().ToList();

           Console.WriteLine("All numbers: " + string.Join(", ", allInts));
           Console.WriteLine("All numbers less than 3: " + string.Join(", ", allIntsLessThanThree));

           for (int i = 0; i < containsIntLists.Count; i++)
           {
               Console.WriteLine($"Int list[{i}]: " + string.Join(", ", containsIntLists[i]));
           }

           Console.WriteLine(new string('-', 40));
           // 5. Select vs Where
           List<Warrior> warriors = new List<Warrior>()
           {
               new Warrior() { Height = 100 },
               new Warrior() { Height = 80 },
               new Warrior() { Height = 100 },
               new Warrior() { Height = 70 },
           };

           List<int> heights = warriors.Where(wh => wh.Height == 100)
                                       .Select(wh => wh.Height)
                                       .ToList();

           Console.WriteLine("Heights: " + string.Join(", ", heights));

           Console.WriteLine(new string('-', 40));
           // 6. ForEach
           Console.WriteLine("Short ForEach heights");
           heights.ForEach(h => Console.WriteLine(h));

           Console.WriteLine("Short ForEach heights from Warriors");
           warriors.ForEach(wh => Console.WriteLine(wh.Height)); // can't do it with string.Join
       }
   }

   internal class Warrior
   {
       public int Height { get; set; }
   }
}
```

<p id="gdcalert1" ><span style="color: red; font-weight: bold">>>>>>  gd2md-html alert: inline image link here (to images/image1.jpg). Store image on your image server and adjust path/filename/extension if necessary. </span><br>(<a href="#">Back to top</a>)(<a href="#gdcalert2">Next alert</a>)<br><span style="color: red; font-weight: bold">>>>>> </span></p>


![alt_text](images/image1.jpg "image_tooltip")


### Async Programming
```c#
using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
   class EntryPoint
   {
       static void Main()
       {
           int count = 200000;
           char charToConcatenate = '1';

           // Asynchronous call of the async ConcatenateChars method
           Task<string> t = ConcatenateCharsAsync(charToConcatenate, count);

           // This line of code will be executed asynchronously
           Console.WriteLine("In progress");


           Console.WriteLine("The length of the result is " + t.Result.Length);

           // Normal Synchronous Call of the ConcatenateChars method
           ConcatenateChars(charToConcatenate, count);
       }

       public static string ConcatenateChars(char charToConcatenate, int count)
       {
           string concatenatedString = string.Empty;

           for (int i = 0; i < count; i++)
           {
               concatenatedString += charToConcatenate;
           }

           return concatenatedString;
       }

       public async static Task<string> ConcatenateCharsAsync(char charToConcatenate, int count)
       {
           return await Task<string>.Factory.StartNew(() =>
           {
               return ConcatenateChars(charToConcatenate, count);
           });
       }
   }
}
```

### Extension Methods

Extension methods enable you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. Extension methods are static methods, but they're called as if they were instance methods on the extended type.

Extension methods are defined as static methods but are called by using instance method syntax. Their first parameter specifies which type the method operates on. The parameter is preceded by the [this](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/this) modifier. Extension methods are only in scope when you explicitly import the namespace into your source code with a `using` directive.
```c#
namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

using ExtensionMethods;

string s = "Hello Extension Methods";
int i = s.WordCount();
```



### c# Indexer

Indexers allow instances of a class or struct to be indexed just like arrays. The indexed value can be set or retrieved without explicitly specifying a type or instance member. Indexers resemble [properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties) except that their accessors take parameters.


```c#
using System;

class SampleCollection<T>
{
   // Declare an array to store the data elements.
   private T[] arr = new T[100];

   // Define the indexer to allow client code to use [] notation.
   public T this[int i]
   {
      get => arr[i];
      set => arr[i] = value;
   }

  //above can be written in old style as below too:
  // Define the indexer to allow client code to use [] notation.
   public T this[int i]
   {
      get { return arr[i]; }
      set { arr[i] = value; }
   }
}

class Program
{
   static void Main()
   {
      var stringCollection = new SampleCollection<string>();
      stringCollection[0] = "Hello, World.";
      Console.WriteLine(stringCollection[0]);
   }
}

Can a class have multiple indexers? YES.
public T this[int i]
public T this[float i]
```



### **Make a Visual C# class usable in a foreach statement**

This article demonstrates how to use the `IEnumerable` and the `IEnumerator` interfaces to create a class that you can use in a `foreach` statement.


### **IEnumerator interface**

`IEnumerable` and `IEnumerator` are frequently used together. Although these interfaces are similar (and have similar names), they have different purposes.

The `IEnumerator` interface provides iterative capability for a collection that is internal to a class. `IEnumerator` requires that you implement three methods:



* The `MoveNext` method, which increments the collection index by 1 and returns a bool that indicates whether the end of the collection has been reached.
* The `Reset` method, which resets the collection index to its initial value of -1. This invalidates the enumerator.
* The `Current` method, which returns the current object at `position`.

The `IEnumerable` interface permits enumeration by using a `foreach` loop. In summary, the use of `IEnumerable` requires that the class implement `IEnumerator`. If you want to provide support for `foreach`, implement both interfaces.


```c#
using System;
using System.Collections;
namespace ConsoleEnum
{
    public class cars : IEnumerator,IEnumerable
    {
       private car[] carlist;
       int position = -1;
       //Create internal array in constructor.
       public cars()
       {
           carlist= new car[6]
           {
               new car("Ford",1992),
               new car("Fiat",1988),
               new car("Buick",1932),
               new car("Ford",1932),
               new car("Dodge",1999),
               new car("Honda",1977)
           };
       }
       //IEnumerable require these methods.
       public IEnumerator GetEnumerator()
       {
           return (IEnumerator)this;
       }
       //IEnumerator
       public bool MoveNext()
       {
           position++;
           return (position < carlist.Length);
       }
       //IEnumerable
       public void Reset()
       {
           position = -1;
       }
       //IEnumerable
       public object Current
       {
           get { return carlist[position];}
       }
    }
  }

Called as:

using System;
namespace ConsoleEnum
{
   class host
   {
       [STAThread]
       static void Main(string[] args)
       {
           cars C = new cars();
           Console.WriteLine("\nInternal Collection (Unsorted - IEnumerable,Enumerator)\n");
           foreach(car c in C)
           		Console.WriteLine(c.Make + "\t\t" + c.Year);
           Console.ReadLine();
       }
   }
}
```



### Boxing and Unboxing:

Boxing is the process of converting a [value type](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types) to the type `object` or to any interface type implemented by this value type. When the common language runtime (CLR) boxes a value type, it wraps the value inside a [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) instance and stores it on the managed heap. Unboxing extracts the value type from the object. Boxing is implicit; unboxing is explicit. The concept of boxing and unboxing underlies the C# unified view of the type system in which a value of any type can be treated as an object.


```c#
int i = 123;
// The following line boxes i.
object o = i;

o = 123;
i = (int)o;  // unboxing
```



### C# Arrays:


```c#
       // Declare a single-dimensional array of 5 integers.
        int[] array1 = new int[5];

        // Declare and set array element values.
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        // Alternative syntax.
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        // Declare a two dimensional array.
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values.
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array.
```


`	  //`A jagged array is an array whose elements are arrays, possibly of different sizes. A jagged array is sometimes called an "array of arrays." 


```c#
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure.
        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

ArrayList: Not sorted by default. Make sure to call sort() before calling binarysearch on that.

// Creates and initializes a new ArrayList.
      ArrayList myAL = new ArrayList();
      myAL.Add("Hello");
      myAL.Add("World");
      myAL.Add("!");
```


`ArrayList` belongs to the days that C# didn't have generics. It's deprecated in favor of `List&lt;T>`. ArrayList can have a mix of data types.


### IComparable: 

Defines a generalized type-specific comparison method that a value type or class implements to order or sort its instances. This interface is implemented by types whose values can be ordered or sorted. It requires that implementing types define a single method, [CompareTo(Object)](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable.compareto?view=net-6.0#system-icomparable-compareto(system-object)).


### C# string is immutable

C# string is immutable. Instances of immutable types are inherently thread-safe, since no thread can modify it, the risk of a thread modifying it in a way that interferes with another is removed (the reference itself is a different matter).


### Delegate vs Events


<table>
  <tr>
   <td>Delegate
   </td>
   <td>Event
   </td>
  </tr>
  <tr>
   <td>A delegate is declared using the delegate keyword.
   </td>
   <td>An event is declared using the event keyword.
   </td>
  </tr>
  <tr>
   <td>Delegate is a function pointer. It holds the reference of one or more methods at runtime.
   </td>
   <td>The event is a notification mechanism that depends on delegates
   </td>
  </tr>
  <tr>
   <td>Delegate is independent and not dependent on events.
   </td>
   <td>An event is dependent on a delegate and cannot be created without delegates. Event is a wrapper around delegate instance to prevent users of the delegate from resetting the delegate and its invocation list and only allows adding or removing targets from the invocation list.
   </td>
  </tr>
</table>



```c#
// Define a custom delegate that has a string parameter and returns void.
delegate void CustomDel(string s);

class TestClass
{
    // Define two methods that have the same signature as CustomDel.
    static void Hello(string s)
    {
        Console.WriteLine($"  Hello, {s}!");
    }

    static void Goodbye(string s)
    {
        Console.WriteLine($"  Goodbye, {s}!");
    }

    static void Main()
    {
        // Declare instances of the custom delegate.
        CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;

        // In this example, you can omit the custom delegate if you
        // want to and use Action<string> instead.
        //Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

        // Create the delegate object hiDel that references the
        // method Hello.
        hiDel = Hello;

        // Create the delegate object byeDel that references the
        // method Goodbye.
        byeDel = Goodbye;

        // The two delegates, hiDel and byeDel, are combined to
        // form multiDel.
        multiDel = hiDel + byeDel;

        // Remove hiDel from the multicast delegate, leaving byeDel,
        // which calls only the method Goodbye.
        multiMinusHiDel = multiDel - hiDel;

        Console.WriteLine("Invoking delegate hiDel:");
        hiDel("A");
        Console.WriteLine("Invoking delegate byeDel:");
        byeDel("B");
        Console.WriteLine("Invoking delegate multiDel:");
        multiDel("C");
        Console.WriteLine("Invoking delegate multiMinusHiDel:");
        multiMinusHiDel("D");
    }
}
```



### ThreadStatic attribute:

Indicates that the value of a static field is unique for each thread.


```c$
using System;
using System.Threading;

public class Example
{
   [ThreadStatic] static double previous = 0.0;
   [ThreadStatic] static double sum = 0.0;
   [ThreadStatic] static int calls = 0;
   [ThreadStatic] static bool abnormal;
   static int totalNumbers = 0;
   static CountdownEvent countdown;
   private static Object lockObj;
   Random rand;
};
```



### Access Modifiers:


<table>
  <tr>
   <td><strong>Caller's location</strong>
   </td>
   <td><strong><code>public</code></strong>
   </td>
   <td><strong><code>protected internal</code></strong>
   </td>
   <td><strong><code>protected</code></strong>
   </td>
   <td><strong><code>internal</code></strong>
   </td>
   <td><strong><code>private protected</code></strong>
   </td>
   <td><strong><code>private</code></strong>
   </td>
  </tr>
  <tr>
   <td>Within the class
   </td>
   <td>✔️️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
  </tr>
  <tr>
   <td>Derived class (same assembly)
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>❌
   </td>
  </tr>
  <tr>
   <td>Non-derived class (same assembly)
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>❌
   </td>
   <td>✔️
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
  </tr>
  <tr>
   <td>Derived class (different assembly)
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>✔️
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
  </tr>
  <tr>
   <td>Non-derived class (different assembly)
   </td>
   <td>✔️
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
   <td>❌
   </td>
  </tr>
</table>



### Finalizer aka Destructor, FInalize:


```
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/finalizers?source=recommendations
```


Finalizers (historically referred to as **destructors**) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector. 



* Finalizers cannot be defined in structs. They are only used with classes.
* A class can only have one finalizer.
* Finalizers cannot be inherited or overloaded.
* Finalizers cannot be called. They are invoked automatically.
* A finalizer does not take modifiers or have parameters.


### Satellite Assemblies:



1. A satellite assembly is a compiled library (DLL) that contains “localizable” resources specific to a given culture such as strings, bitmaps, etc.
2. You are likely to use satellite assemblies when creating a multilingual UI application. They are used to deploy applications in multiple cultures, with 1 satellite assembly per culture (default behavior)


### ReferenceEquals vs Equals

For **reference types** **<code>object.ReferenceEquals(a, b) </code></strong>returns <code>true </code>if and only if <code>a</code> and <code>b</code> have the same underlying memory address.


```
a.Equals(b): 
```


**Value Types: **For value types this method is overridden to do a value (equivalence) comparison. In particular, `System.ValueType `itself, the root of all value types, contains an override that will compare two objects by reflecting over their internal fields to see if they are all equal. If you inherit this (by setting up a struct) your struct will get this override by default. 

**Reference Types: **For reference types, as discussed above, the situation is trickier. In general we expect `Equals() `for reference types to do an identity comparison (to check whether the objects actually are the same in memory).


### Const vs readonly:

Apart from the apparent difference of
* having to declare the value at the time of a definition for a const VS readonly values can be computed dynamically but need to be assigned before the constructor exits.. after that it is frozen.
* const's are implicitly static. You use a ClassName.ConstantName notation to access them.


### Constants
* Constants are static by default
* They must have a value at compilation-time (you can have e.g. 3.14 * 2, but cannot call methods)
* Could be declared within functions
* Are copied into every assembly that uses them (every assembly gets a local copy of values)
* Can be used in attributes

### Readonly instance fields

* Must have set value, by the time constructor exits
* Are evaluated when instance is created

***Question*** Can a derived class have parameterless constructor if the base class doesn't have a parameterless constructor, if you don't call any constructor from derived constructor?<br>
Answer: YES but you need to make sure that all your constructors call the base class constructor with parameters.

Example:
```c#
class A

{

    public A(int x, int y)

    {

        // do something

    }

}

class A2 : A

{

    public A2() : base(1, 5)

    {

        // do something

    }

    public A2(int x, int y) : base(x, y)

    {

        // do something

    }

    // This would not compile:

    public A2(int x, int y)

    {

        // the compiler will look for a constructor A(), which doesn't exist

    }

}

You can also use **this** keyword to invoke a constructor from another constructor

class sample

{

    public int x;

    public sample(int value) 

    {

        x = value;

    }

    public sample(sample obj) : **this(obj.x) **

    {

    }

}
```

### Anonymous Types:

 Anonymous types provide a convenient way to encapsulate a set of read-only properties into a single object without having to explicitly define a type first. 

You create anonymous types by using the [new](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator) operator together with an object initializer. 

**var v = new { Amount = 108, Message = "Hello" };**

// Rest the mouse pointer over v.Amount and v.Message in the following

// statement to verify that their inferred types are int and string.

Console.WriteLine(v.Amount + v.Message);

So, the properties of anonymous type are read-only means **you cannot change their values**.


### C# Generics

Generic is a class which **allows the user to define classes and methods with the placeholder**. Generics were added to version 2.0 of the C# language. The basic idea behind using Generic is to allow type (Integer, String, … etc and user-defined types) to be a parameter to methods, classes, and interfaces.


### Explicit Interface implementation: 

**Explicitly telling the compiler that a particular member belongs to that particular interface is called Explicit interface implementation. **


```c#
// C# Program to show the use of
// Explicit interface implementation
using System;


interface I1 {


    void printMethod();
}


interface I2 {


    void printMethod();
}


// class C implements two interfaces
class C : I1, I2 {


    // Explicitly implements method of I1
    void I1.printMethod()
    {
        Console.WriteLine("I1 printMethod");
    }


    // Explicitly implements method of I2
    void I2.printMethod()
    {
        Console.WriteLine("I2 printMethod");
    }
}

// Driver Class
class GFG {


    // Main Method
    static void Main(string[] args)
    {
        I1 i1 = new C();
        I2 i2 = new C();


        // call to method of I1
        i1.printMethod();


        // call to method of I2
        i2.printMethod();
    }
}
```



### [AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception?view=net-7.0) 

is used to consolidate multiple failures into a single, throwable exception object. It is used extensively in the [Task Parallel Library (TPL)](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl) and [Parallel LINQ (PLINQ)](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/parallel-linq-plinq). 


### Types of Threads

Basically, there are two types of threads which fall into:



* Foreground Thread
* Background Thread


### Foreground Thread

Foreground threads are threads which will continue to run until the last foreground thread is terminated. In another way, the application is closed when all the foreground threads are stopped.

So the application won't wait until the background threads are completed, but it will wait until all the foreground threads are terminated. 

By default, the threads are foreground threads. So when we create a thread the default value of IsBackground property would be false.


### Background Thread

Background threads are threads which will get terminated when all foreground threads are closed. The application won't wait for them to be completed.

We can create a background thread like following:

1. <code>Thread backgroundThread = <strong>new</strong> Thread(threadStart);  </code>
2. <code>backgroundThread.IsBackground = <strong>true</strong>;  </code>
3. <code>backgroundThread.Start(); </code>


### ThreadPool

Threadpool is suitable only when you use it for operations that takes less time to complete. Threadpool threads are not suitable for long running operations, as it can easily lead to thread starvation. 

If you require your thread to have a specific priority, then threadpool thread is not suitable. 

You have tasks that cause the thread to block for long periods of time. The thread pool has a maximum number of threads, so a large number of blocked thread pool threads might prevent tasks from starting.

if you start a Task with TaskCreationOptions.LongRunning then a new Thread will be started to run the Task.

For most IO tasks, there are asynchronous versions of the framework methods that you should really use. These make use of kernel functions and mean that you won't be blocking any thread.

Unhandled exceptions that are thrown by user code that is running inside a task are propagated back to the calling thread. Exceptions are propagated when you use one of the static or instance [Task.Wait](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.wait) methods, and you handle them by enclosing the call in a `try`/`catch` statement. 

To propagate all the exceptions back to the calling thread, the Task infrastructure wraps them in an [AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception) instance. The [AggregateException](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception) exception has an [InnerExceptions](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception.innerexceptions) property that can be enumerated to examine all the original exceptions that were thrown, and handle (or not handle) each one individually. You can also handle the original exceptions by using the [AggregateException.Handle](https://learn.microsoft.com/en-us/dotnet/api/system.aggregateexception.handle) method.
```c#
public static partial class Program

{

    public static void HandleThree()

    {

        var task = Task.Run(

            () => throw new CustomException("This exception is expected!"));

        try

        {

            task.Wait();

        }

        catch (AggregateException ae)

        {

            foreach (var ex in ae.InnerExceptions)

            {

                // Handle the custom exception.

                if (ex is CustomException)

                {

                    Console.WriteLine(ex.Message);

                }

                // Rethrow any other exception.

                else

                {

                    throw ex;

                }

            }

        }

    }

}

// The example displays the following output:

//        This exception is expected!
```

### Running a task on UI thread

Just use **InvokeAsync** instead of Invoke then return the Task&lt;int> inside the DispatcherOperation&lt;int> the function returns.

```c#
//Coding conventions say async functions should end with the word Async.

public Task&lt;int> RunOnUiAsync(Func&lt;int> f)
{

    var dispatcherOperation = Application.Current.Dispatcher.InvokeAsync(f);

    return dispatcherOperation.Task;
}
```
The RegisterWaitForSingleObject method **checks the current state of the specified object's WaitHandle**. If the object's state is unsignaled, the method registers a wait operation. The wait operation is performed by a thread from the thread pool.

### Mutex vs Event:
An event is more like a quantum, whereas a mutex is like a toggle.  A event would be used when you want to awaken one or more threads when an action need be performed.  A mutex locks out all but one thread from executing code.

The problem with Windows is that a waiting thread can be "borrowed" by the system to service to perform certain tasks.  If that thread is being "borrowed" when the event is set (keeping in mind it's a quantum) then that event does not get handled.

Practically speaking the functional difference between an Event and a Mutex is that, an event is generally used in situations where one thread performs some initialization work, and then signals other threads to perform rest of the work.
On the other hand, a mutex is generally used when we need to safeguard a common resource against simultaneous read/write operations from multiple threads. Hence the concept of ownership by a thread. The thread which ows the mutex (which means the threadID field of the mutex structure is set to the threadId of the calling thread) has exclusive rights to read/write on the common resource, while other thread wait for bieng scheduled.


### Lazy&lt;T> vs LazyInitializer:
Lazy&lt;T> ([MSDN](http://msdn.microsoft.com/en-us/library/dd642331.aspx)) is a generic wrapper which allows creating an instance of T on demand by holding a T factory method (Func&lt;T>) and calling it when Value property getter is accessed.

LazyInitializer - static class with a set of static methods, this is just a helper which uses [Activator.CreateInstance()](http://msdn.microsoft.com/en-us/library/system.activator.createinstance.aspx) (reflection) able to instantiate a given type instance. It does not keep any local private fields and does not expose any properties, so no memory usage overheads.

Worth noting that both classes uses Func&lt;T> as instance factory.

### Dependency Injection

The [Dependency Injection pattern](https://www.dotnettricks.com/learn/dependencyinjection/implementation-of-dependency-injection-pattern-in-csharp) uses a builder object to initialize objects and provide the required dependencies to the object means it allows you to "inject" a dependency from outside the class.

For example, Suppose your Client class needs to use two service classes, then the best you can do is to make your Client class aware of abstraction i.e. IService interface rather than implementation i.e. Service1 and Service2 classes. In this way, you can change the implementation of the IService interface at any time (and for how many times you want) without changing the client class code.
```c#
public interface IService {

 void Serve();

}

public class Service1 : IService {

 public void Serve() { 

 Console.WriteLine("Service1 Called"); 

 }

}

public class Service2 : IService {

 public void Serve() { 

 Console.WriteLine("Service2 Called"); 

 }

}

public class Client {

 private IService _service;

 public Client(IService service) {

 this._service = service;

 }

 public ServeMethod() { 

 this._service.Serve(); 

 }

}

class Program

{

 static void Main(string[] args)

 {

 //creating object

 Service1 s1 = new Service1(); 

 //passing dependency

 Client c1 = new Client(s1);

 //TO DO:

 c1.ServeMethod();

 

 Service2 s2 = new Service2(); 

 //passing dependency

 c1 = new Client(s2);

 //TO DO:

 c1.ServeMethod();

 }
}
```

### Algorithmic complexity of collections
When choosing a [collection class](https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class), it's worth considering potential tradeoffs in performance. Use the following table to reference how various mutable collection types compare in algorithmic complexity to their corresponding immutable counterparts. Often immutable collection types are less performant but provide immutability - which is often a valid comparative benefit.
<table>
  <tr>
   <td><strong>Mutable</strong>
   </td>
   <td><strong>Amortized</strong>
   </td>
   <td><strong>Worst Case</strong>
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>Stack&lt;T>.Push</code>
   </td>
   <td>O(1)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>Queue&lt;T>.Enqueue</code>
   </td>
   <td>O(1)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>List&lt;T>.Add</code>
   </td>
   <td>O(1)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>List&lt;T>.Item[Int32]</code>
   </td>
   <td>O(1)
   </td>
   <td>O(1)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>List&lt;T>.Enumerator</code>
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>HashSet&lt;T>.Add</code>, lookup
   </td>
   <td>O(1)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>SortedSet&lt;T>.Add</code>
   </td>
   <td>O(log <code>n</code>)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>Dictionary&lt;T>.Add</code>
   </td>
   <td>O(1)
   </td>
   <td>O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>Dictionary&lt;T></code> lookup
   </td>
   <td>O(1)
   </td>
   <td>O(1) – or strictly O(<code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><code>SortedDictionary&lt;T>.Add</code>
   </td>
   <td>O(log <code>n</code>)
   </td>
   <td>O(<code>n</code> log <code>n</code>)
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
</table>

### **Dictionary&lt;TKey,TValue> Class**
The [Dictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0) generic class provides a mapping from a set of keys to a set of values. Each addition to the dictionary consists of a value and its associated key. Retrieving a value by using its key is very fast, close to O(1), because the [Dictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0) class is implemented as a hash table.

```c#
using System;
using System.Collections.Generic;
// Create a new dictionary of strings, with string keys.
//
Dictionary<string, string> openWith =
    new Dictionary<string, string>(100); << Initial capacity of 100

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

// ContainsKey can be used to test keys before inserting
// them.
if (!openWith.ContainsKey("ht"))
{
    openWith.Add("ht", "hypertrm.exe");
    Console.WriteLine("Value added for key = \"ht\": {0}",
        openWith["ht"]);
}

// When you use foreach to enumerate dictionary elements,
// the elements are retrieved as KeyValuePair objects.
Console.WriteLine();
foreach( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine("Key = {0}, Value = {1}",
        kvp.Key, kvp.Value);
}
```

### **List&lt;T> Class**

Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists. The [List&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0) class is the generic equivalent of the [ArrayList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=net-6.0) class. It implements the [IList&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1?view=net-6.0) generic interface by using an array whose size is dynamically increased as required.

You can add items to a [List&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0) by using the [Add](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add?view=net-6.0) or [AddRange](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange?view=net-6.0) methods.


```c#
        // Create a list of parts.
        List<Part> parts = new List<Part>();

        // Add parts to the list.
        parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
        parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
        parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

       // Check the list for part #1734. This calls the IEquatable.Equals method
        // of the Part class, which checks the PartId for equality.
        Console.WriteLine("\nContains(\"1734\"): {0}",
        parts.Contains(new Part { PartId = 1734, PartName = "" }));

        // Insert a new item at position 2.
        Console.WriteLine("\nInsert(2, \"1834\")");
        parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });

        //Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        Console.WriteLine("\nParts[3]: {0}", parts[3]);

       parts.RemoveAt(3);
```

### **SortedList&lt;TKey,TValue> Class**
Represents a collection of key/value pairs that are sorted by key based on the associated [IComparer&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-6.0) implementation. The [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0) generic class is an array of key/value pairs with O(log `n`) retrieval, where n is the number of elements in the dictionary. In this, it is similar to the [SortedDictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0) generic class. The two classes have similar object models, and both have O(log `n`) retrieval. Where the two classes differ is in memory use and speed of insertion and removal:

* [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0) uses less memory than [SortedDictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0).
* [SortedDictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0) has faster insertion and removal operations for unsorted data, O(log `n`) as opposed to O(`n`) for [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0).
* If the list is populated all at once from sorted data, [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0) is faster than [SortedDictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0).

Another difference between the [SortedDictionary&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0) and [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0)classes is that [SortedList&lt;TKey,TValue>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0) supports efficient indexed retrieval of keys and values through the collections returned by the [Keys](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2.keys?view=net-6.0) and [Values](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2.values?view=net-6.0) properties. It is not necessary to regenerate the lists when the properties are accessed, because the lists are just wrappers for the internal arrays of keys and values. 

```c#
       // Create a new sorted list of strings, with string
        // keys.
        SortedList<string, string> openWith =
            new SortedList<string, string>();

        // Add some elements to the list. There are no
        // duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");

       // The indexer can be used to change the value associated
        // with a key.
        openWith["rtf"] = "winword.exe";
        Console.WriteLine("For key = \"rtf\", value = {0}.",
            openWith["rtf"]);

        // If a key does not exist, setting the indexer for that key
        // adds a new key/value pair.
        openWith["doc"] = "winword.exe";

       // ContainsKey can be used to test keys before inserting
        // them.
        if (!openWith.ContainsKey("ht"))
        {
            openWith.Add("ht", "hypertrm.exe");
            Console.WriteLine("Value added for key = \"ht\": {0}",
                openWith["ht"]);
        }

        // When you use foreach to enumerate list elements,
        // the elements are retrieved as KeyValuePair objects.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}",
                kvp.Key, kvp.Value);
        }

       // To get the values alone, use the Values property.
        IList<string> ilistValues = openWith.Values;
```

### **HashSet&lt;T> Class**
The [HashSet&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-6.0) class provides high-performance set operations. A set is a collection that contains no duplicate elements, and whose elements are in no particular order.

```c#
// Create a new HashSet populated with even numbers.
HashSet<int> numbers = new HashSet<int>(evenNumbers);
Console.WriteLine("numbers UnionWith oddNumbers...");
numbers.UnionWith(oddNumbers);

Other key members are Count, Add, Clear, Contains, Remove, TrimExcess
```

### **SortedSet&lt;T> Class**
Represents a collection of objects that is maintained in sorted order. A [SortedSet&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=net-6.0) object maintains a sorted order without affecting performance as elements are inserted and deleted. Duplicate elements are not allowed. 

Same methods as in HashSet, plus Max, Min, Reverse, GetViewBetween(t1, t2)

### **Queue&lt;T> Class**
FIFO: This class implements a generic queue as a circular array.
```c#
       Queue<string> numbers = new Queue<string>();
        numbers.Enqueue("one");
        numbers.Enqueue("two");
        numbers.Enqueue("three");
        numbers.Enqueue("four");
        numbers.Enqueue("five");

       Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
        Console.WriteLine("Peek at next item to dequeue: {0}",
            numbers.Peek());
        Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

Key methods: Count, Contains, Cear, Enqueue, Dequeue, Peek
```

### **Stack&lt;T> Class**
<code>LIFO: </code>[Stack&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-6.0) is implemented as an array.
```c#
       Stack<string> numbers = new Stack<string>();
        numbers.Push("one");
        numbers.Push("two");
        numbers.Push("three");
        numbers.Push("four");
        numbers.Push("five");

        // A stack can be enumerated without disturbing its contents.
        foreach( string number in numbers )
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nPopping '{0}'", numbers.Pop());
        Console.WriteLine("Peek at next item to destack: {0}",
            numbers.Peek());
        Console.WriteLine("Popping '{0}'", numbers.Pop());
```

### **LinkedList&lt;T> Class**
[LinkedList&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0) provides separate nodes of type [LinkedListNode&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1?view=net-6.0), so insertion and removal are O(1) operations.

You can remove nodes and reinsert them, either in the same list or in another list, which results in no additional objects allocated on the heap. Because the list also maintains an internal count, getting the [Count](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1.count?view=net-6.0) property is an O(1) operation.

Each node in a [LinkedList&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0) object is of the type [LinkedListNode&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1?view=net-6.0). Because the [LinkedList&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0) is doubly linked, each node points forward to the [Next](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1.next?view=net-6.0) node and backward to the [Previous](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1.previous?view=net-6.0) node.


### **ObservableCollection&lt;T> Class**
Represents a dynamic data collection that provides notifications when items get added or removed, or when the whole list is refreshed.

### **IEnumerable Interface**
The following code example demonstrates the best practice for iterating a custom collection by implementing the [IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-6.0) and [IEnumerator](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-6.0) interfaces. In this example, members of these interfaces are not explicitly called, but they are implemented to support the use of `foreach` (`For Each` in Visual Basic) to iterate through the collection. This example is a complete Console app. To compile the Visual Basic app, change the **Startup object** to **Sub Main** in the project's **Properties**page.
```c#
using System;
using System.Collections;

// Simple business object.
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}

// Collection of Person objects. This class
// implements IEnumerable so that it can be used
// with ForEach syntax.
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

// Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator()
    {
       return (IEnumerator) GetEnumerator();
    }

    public PeopleEnum GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}

// When you implement IEnumerable, you must also implement IEnumerator.
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class App
{
    static void Main()
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);
    }
}

/* This code produces output similar to the following:
 *
 * John Smith
 * Jim Johnson
 * Sue Rabon
 *
 */
```

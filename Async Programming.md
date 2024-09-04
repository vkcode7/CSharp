# C# Threading

Threads can give the illusion of multitasking even though the CPU is executing only one thread at any given point in time. Each thread gets a slice of time on the CPU and then gets switched out either because it initiates a task which requires waiting and not utilizing the CPU or it completes its time slot on the CPU.

# Benefits of Threads

1. Higher throughput, though in some pathetic scenarios it is possible to have the overhead of context switching among threads steal away any throughput gains and result in worse performance than a single-threaded scenario. 
2. Responsive applications that give the illusion of multitasking.
3. Efficient utilization of resources. Note that thread creation is lightweight in comparison to spawning a brand new process. 

Example: As a concrete example, consider the example code below. The task is to ***compute*** the sum of all the integers from 0 to <strong><em><code>Int32.MaxValue</code></em></strong>. In the first scenario, we have a single thread doing the summation while in the second scenario, we split the range into two parts and have one thread sum for each range.

```c#
using System;
using System.Threading;
using System.Diagnostics;

class Demonstration
{
    static void Main()
    {
        new SingleVsMultipleThreads().runTest();
    }
}

public class SingleVsMultipleThreads
{
    private static readonly long END = Int32.MaxValue;
    private static readonly long START = 1;

    long sum(long start, long end)
    {
        long sum = 0;

        for (long i = start; i <= end; i++)
        {
            sum += i;
        }

        return sum;
    }

    void runSingleThreadTest()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Thread thread = new Thread(() =>
        {
            long result = sum(START, END);
            Console.WriteLine(String.Format("Single thread summed to {0}", result));
        });

        thread.Start();
        thread.Join();

        stopwatch.Stop();
        Console.WriteLine(String.Format("Single thread took {0} milliseconds to complete", stopwatch.ElapsedMilliseconds));
    }

    void runMultiThreadTest()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        long result1 = 0;
        long result2 = 0;

        Thread thread1 = new Thread(() =>
        {
            result1 = sum(START, END / 2);
        });

        Thread thread2 = new Thread(() =>
        {
            result2 = sum(1 + (END / 2), END);
        });

        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();

        stopwatch.Stop();
        Console.WriteLine(String.Format("Multiple threads summed to {0}", result1 + result2));
        Console.WriteLine(String.Format("Multiple threads took {0} milliseconds to complete", stopwatch.ElapsedMilliseconds));
    }

    public void runTest()
    {
        runSingleThreadTest();
        runMultiThreadTest();
    }
}
```
```
Single thread summed to 2305843008139952128
Single thread took 648 milliseconds to complete
Multiple threads summed to 2305843008139952128
Multiple threads took 322 milliseconds to complete
```

## Program vs Process vs Thread
A program is a set of instructions and associated data that resides on the disk and is loaded by the operating system to perform a task.<br>
A process is a program in execution. A process is an execution environment that consists of instructions, user-data, and system-data segments, as well as lots of other resources such as CPU, memory, address-space, disk and network I/O acquired at runtime. A program can have several copies of it running at the same time but a process necessarily belongs to only one program.<br>

A thread is the smallest unit of execution in a process which simply executes instructions serially. A process can have multiple threads running as part of it.<br>

Processes don't share any resources amongst themselves whereas threads of a process can share the resources allocated to that particular process, including memory address space. However, languages do provide facilities to enable inter-process communication.

## Concurrency vs Parallelism

A system capable of running several distinct programs or more than one independent unit of the same program in overlapping time intervals is called a concurrent system.<br>

A parallel system is one which necessarily has the ability to execute multiple programs at the same time. Usually, this capability is aided by hardware in the form of multicore processors on individual machines or as computing clusters where several machines are hooked up to solve independent pieces of a problem simultaneously.<br>

From the above discussion it should be apparent that a concurrent system need not be parallel, whereas a parallel system is indeed concurrent. Additionally, a system can be both concurrent and parallel, e.g. a multitasking operating system running on a multicore machine.

## Cooperative vs Preemptive Multitasking
In preemptive multitasking, the operating system preempts a program to allow another waiting task to run on the CPU.<br>

Cooperative Multitasking involves well-behaved programs voluntarily giving up control back to the scheduler so that another program can run.<br>

Early versions of both Windows and Mac OS used cooperative multitasking. Later on, preemptive multitasking was introduced in Windows NT 3.1 and in Mac OS X. However, preemptive multitasking has always been a core feature of Unix based systems.

## Synchronous vs Asynchronous
Synchronous execution refers to line-by-line execution of code.<br>

Asynchronous programming is a means of parallel programming in which a unit of work runs separately from the main application thread and notifies the calling thread of its completion, failure or progress. An asynchronous program doesn't wait for a task to complete before moving on to the next task.

## Throughput vs Latency
Throughput is defined as the rate of doing work or how much work gets done per unit of time.<br>

Latency is defined as the time required to complete a task or produce a result. Latency is also referred to as response time. 

## Critical Section & Race Conditions

Critical section is any piece of code that has the possibility of being executed concurrently by more than one thread of the application and exposes any shared data or resources used by the application for access.<br>

Race conditions happen when threads run through critical sections without thread synchronization. The threads "race" through the critical section to write or read shared resources and depending on the order in which threads finish the "race", the program output changes.

# Deadlocks, Liveness & Reentrant Locks

Deadlocks occur when two or more threads aren't able to make any progress because the resource required by the first thread is held by the second and the resource required by the second thread is held by the first.<br>

Ability of a program or an application to execute in a timely manner is called liveness. If a program experiences a deadlock then it's not exhibiting liveness.<br>

Other than a deadlock, an application thread can also experience starvation when it never gets CPU time or access to shared resources.<br>

Reentrant locks allow for re-locking or re-entering of a synchronization lock.Consider the snippet below that creates a Mutex object and attempts to acquire it twice. Since the lock is reentrant the second print statement is also printed. If the lock were non-reentrant, we would not see the second statement print in the output.
```c#
using System.Threading;

class ReentrantLockExample
{
    static void Main()
    {
        Mutex mutex = new Mutex();
        
        mutex.WaitOne();
        System.Console.WriteLine("Acquired once");

        mutex.WaitOne();
        System.Console.WriteLine("Acquired twice");
    }
}
```

## **Mutex vs Semaphore**

Mutex as the name hints implies **_mutual exclusion_**. A mutex is used to guard shared data such as a linked-list, an array, or any primitive type. A mutex allows only a single thread to access a resource or critical section.<br>

Semaphore, on the other hand, is used for limiting access to a collection of resources. Think of semaphore as having a limited number of permits to give out. <br>

**A mutex is owned by the thread acquiring it till the point the owning-thread releases it, whereas for a semaphore there's no notion of ownership.**

Mutex, if locked, must necessarily be unlocked by the same thread. A semaphore can be acted upon by different threads. This is true even if the semaphore has a permit of one.


## **Mutex vs Monitor**

Concisely, a monitor is a mutex and then some. Monitors are generally language-level constructs whereas mutex and semaphore are lower-level or OS-provided constructs.<br>

You can think of a monitor as a _mutex with a wait set_. Monitors allow threads to exercise mutual exclusion as well as cooperation by allowing them to wait and signal on conditions. A monitor is made up of a mutex and a condition variable. One can think of a mutex as a subset of a monitor.

## **Semaphore vs Monitor**

A semaphore can allow several threads access to a given resource or critical section. However, only a single thread can **own** the monitor and access associated resource at any point.<br>

Threads - **Passing Arguments with Type Safety**<br>

One way to deliver data to the method we want executed is to bundle the method and the data together in a separate class.<br>
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
        GreetingClass gc = new GreetingClass("Fahim");
        ThreadStart ts = new ThreadStart(gc.sayHello);
        Thread thread = new Thread(ts);
        thread.Start();
        thread.Join();
    }
}

public class GreetingClass {

    private String name;

    public GreetingClass(String name) {
      this.name = name;
    }

    public void sayHello()
    {
        Console.WriteLine("Hello " + name + " from instance method");
    }
}
```

### **Retrieving Results from Threads**

We saw a type-safe way to pass arguments to methods we want to execute using threads. We may also want to retrieve results from threads. One approach is to use the same class that we used to pass in arguments to store results and retrieve later on. Another one could be to specify a callback that the thread executes when it is done. This approach is shown below:
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
        RetrieveResults retrieveResults = new RetrieveResults(10, (double res) =>
        {
            Console.WriteLine("Result = " + res);
        });

        ThreadStart ts = new ThreadStart(retrieveResults.square);
        Thread thread = new Thread(ts);

        thread.Start();
        thread.Join();
    }
}

// Delegate that defines the signature of the callback method.
public delegate void ResultCallback(double result);

public class RetrieveResults
{
    private int x;
    ResultCallback callback;

    public RetrieveResults(int x, ResultCallback callback)
    {
        this.x = x;
        this.callback = callback;
    }


    public void square()
    {
        double result = x * x;

        if (callback != null)
            callback(result);
    }
}
```

## Using Lambda Expressions to Create Threads
```c#
  Thread thread = new Thread(()=>{
    // Do something imporant
  });
 
  thread.Start();
  thread.Join();
```
Apart from being a shorthand, the lambda expression also allows us to capture outer variables in the current scope.
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
      String name = "Educative";

      Thread thread = new Thread(()=>{
        Console.WriteLine(name + " says Hi!");
      });

      thread.Start();
      thread.Join();
    }
}
```

## Using ThreadPools

Threadpools are an abstraction offered by several programming languages to manage and handle threads on behalf of the user. Imagine an application that creates threads to undertake several thousand short-lived tasks. The application would incur a performance penalty for first creating hundreds of threads and then tearing down the allocated resources for each thread at the ends of its life. The general way programming frameworks solve this problem is by creating a pool of threads, which are handed out to execute each concurrent task and once completed, the thread is returned to the pool.<br>

Threadpools in C# are tunable in that they allow a user to specify the maximum and the minimum number of threads. However, the caveat with using a thread pool is that all threads in the pool are background threads and therefore if all the foreground threads of an application exit, the application exits too whether or not the threads in the pool have completed. A thread is considered a background thread if the property <strong><code>IsBackground</code></strong> is set to true.<br>

We use <strong><code>QueueUserWorkItem()</code></strong> method of the <strong><code>ThreadPool</code></strong> class to enqueue a method to execute. Specifically, the method <strong><code>QueueUserWorkItem()</code></strong> takes in a delegate parameter of type <strong><code>WaitCallback</code></strong>. This is defined as:
```c#
public delegate void WaitCallback(object state);
```

It implies that whatever method you enqueue to be executed on the thread pool must match the signature of the **<code>WaitCallback</code></strong> delegate. Additionally, an argument of type <strong><code>Object</code></strong> can also be passed-in to the <strong><code>QueueUserWorkItem()</code></strong> method, which in turn passes it on to the method intended to run on the thread pool.

Consider the example below:
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
        new ThreadPoolExample().runTest();
        Thread.Sleep(5000);
    }
}

public class ThreadPoolExample
{

    void work(object state)
    {
        Console.WriteLine((string)state);
        Thread.Sleep(5000);
    }

    public void runTest()
    {
        ThreadPool.QueueUserWorkItem(work, "hello world");        
    }
}
```

## Pausing and Interrupting Threads

Threads can be paused using the static **<code>Thread.Sleep()</code></strong> method. The method accepts an integer representing the number of milliseconds to sleep or an object of type <strong><code>TimeSpan</code></strong>.<br>

We can also interrupt a blocked thread by either interrupting or aborting it.
```c#
using System;
using System.Threading;

class AbrotDemonstration
{
    static void Main()
    {
        new ThreadAbortExample().runTest();
    }
}

public class ThreadAbortExample
{

    void childThread()
    {
        try
        {
            Thread.Sleep(Timeout.Infinite);
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("caught exception");
        }
        finally
        {
            // empty block
        }
        Console.WriteLine("Child thread exiting");
    }


    public void runTest()
    {
        Thread child = new Thread(() =>
        {
            childThread();
        });

        child.Start();

        // wait for child thread to block on Sleep

        Thread.Sleep(1000);

        // now interrupt the child thread
        child.Interrupt();

        // wait for child thread to finish
        child.Join();

        Console.WriteLine("Main thread exiting");
    }
}
```

## **Managed vs Unmanaged Threads**

Threads created under the CLR are managed threads and represented by the class <strong><code>Thread</code></strong>. We can have a situation where threads created in unmanaged code execute managed code. The runtime monitors all the threads in its process that have ever executed code within the managed execution environment. It does not track any other threads. 

## **Mutex**

A <strong><code>Mutex</code></strong> object can be acquired by a thread to exercise mutual exclusion. Protected resources or critical sections can be guarded by a <strong><code>Mutex</code></strong> object to allow a single thread to access a protected resource or execute within a critical section.

The most important characteristic of the <strong><code>Mutex</code></strong> class is that it enforces thread identity. A mutex can be released only by the thread that acquired it. By contrast, the <strong><code>Semaphore</code></strong> class does not enforce thread identity. A mutex can also be passed across application domain boundaries and used for interprocess synchronization.
```c#
        // Class variable mutex
        Mutex mutex = new Mutex();

        // snippet within some method
        mutex.WaitOne();
        try {
            // ...
            // ... Critical Section
            // ...
        }
        catch (Exception e) {
            // Handle exception
        }
        finally {
            // Unlock in a finally block
            mutex.ReleaseMutex();
        }
```

If there's an exception in the critical section, the acquired mutex will not be released and if the thread that locked it, is still alive, no other thread will be able to acquire the mutex, potentially causing a deadlock.<br>

Remember to always unlock the mutex in a <strong><code>finally</code></strong> block when appropriate.

### **Named Mutex**

We can also create named system mutexes, that span multiple applications and are visible throughout the operating system. They can be used for coordinating across multiple processes. Unnamed mutexes are also known as local mutexes and restricted to a single process.
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
        // First argument is name of the mutex
        // and second specifies if the thread
        // creating the mutex should also own it
        Mutex mutex = new Mutex("", false);
        try {
            mutex.WaitOne();
            // Critical section
        }
        catch(Exception e) {
            // Handle exceptions here
        }
        finally {
            // REMEMBER TO RELEASE THE MUTEEX IN THE
            // FINALLY BLOCK
            mutex.ReleaseMutex();
        }

    }
}
```

## **Semaphore**

A semaphore is nothing more than an atomic counter that gets incremented by one whenever <strong><code>Release()</code></strong> is invoked and decremented by one whenever <strong><code>WaitOne()</code></strong> is called. The semaphore is initialized with an initial count value. The count value specifies the maximum permits available to give out.
```c#
Semaphore semaphore = new Semaphore(0, 1);
```
The first argument is the number of permits to start the semaphore with and the second argument is the maximum number of permits the semaphore can hold.

### **Semaphore Across the OS**
There are two types of semaphores:

* local
* system

Local semaphores are only visible within a process and can be used to coordinate amongst the threads of the same process. Named system semaphores are visible throughout the operating system and can be used to synchronize the activities of processes.<br>

One of the constructors of the <strong><code>Semaphore</code></strong> class takes in a string as the third parameter and creates a named system semaphore with the passed-in name.

## **Interlocked**

The Interlocked class offers a number of methods that perform atomic operations that otherwise can't be atomically performed atomically.
```c#
j++; // can be rewritten as

Interlocked.Add(ref j, 1);
```

## **Monitor**
The **<code>Monitor</code></strong> class exposes static methods to synchronize access to objects. The following static methods are commonly used to work with the <strong><code>Monitor</code></strong> class:

* **<code>Enter()</code></strong>
* <strong><code>Exit()</code></strong>
* <strong><code>Wait()</code></strong>
* <strong><code>Pulse()</code></strong>
* <strong><code>PulseAll()</code></strong>

Synchronization on an object means that an exclusive lock is acquired on an object by a thread that invokes <strong><code>Enter()</code></strong>. All other threads invoking <strong><code>Enter()</code></strong> get blocked till the first thread exits the monitor by invoking <strong><code>Exit()</code></strong>. As a consequence, the code block sandwiched between the enter and exit calls becomes a critical section with only one thread active in the block at any given time.
```c#
    public void example()
    {
        Monitor.Enter(this);

        // Critical section
        Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " enters the critical section.");
        Thread.Sleep(3000);
        Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " exits the critical section.");

        Monitor.Exit(this);
    }
```

The monitor synchronizes on the this object in th example above. We could have used any reference object other than this with the same results.
```c#
public class QuizQuestion
{
    private readonly Object obj = new Object();

    public void enterTwice()
    {
        Monitor.Enter(obj);
        Console.WriteLine("Hello");
        Monitor.Exit(obj);
    }

    public void run()
    {
        Thread thread = new Thread(new ThreadStart(enterTwice));
        thread.Start();
        thread.Join();
    }
}
```

## **lock Statement**
The lock statement is really just syntactic sugar over idiomatic <strong><code>Monitor</code></strong> usage. Starting in C# 4.0 a lock statement such as below:
```c#
lock(myObj) {
    // ... critical section
}
```
is translated as follows:
```c#
object myObj = x;
bool wasLockTaken = false;

try
{
    System.Threading.Monitor.Enter(myObj, ref wasLockTaken);
    // ... crtiical section
}
finally
{
    if (wasLockTaken) System.Threading.Monitor.Exit(myObj);
}
```

## **SpinLock & SpinWait**

C# provides a class <strong><code>SpinLock</code></strong> which makes a thread wait in a loop repeatedly checking until the lock becomes available.

The **<code>SpinWait</code></strong> class can be used to busy wait. Note that <strong><code>SpinWait</code></strong> is not simply an empty loop. It is carefully implemented to provide correct spinning behavior for the general case, and will itself initiate context switches if it spins long enough. The idea behind spin wait is to spend a few cycles spinning for a resource to become available. If it does then we will have saved ourselves several thousand cycles that would have otherwise been expended in context-switching and kernel transitions.

```c#
// The sw variable is a SpinWait object
void ping()
{
    SpinWait sw = new SpinWait();
    while (true)
    {


        while (flag)
        {
            sw.SpinOnce();
        }

        Console.WriteLine("Ping");
        flag = true;

    }
}
```

The <strong><code>SpinWait</code></strong> class also offers static methods that can be used to wait for a condition to become true. For instance the method <strong><code>SpinUntil()</code></strong> accepts a delegate that is executed over and over again until it returns true.
```c#
   private volatile bool flag = false;

   void ping()
   {
       while (true)
       {
           SpinWait.SpinUntil(() => { return !flag; });

           Console.WriteLine("Ping");
           flag = true;
       }
   }
```

## **ThreadLocal**

A <strong><code>ThreadLocal&lt;T></code></strong> object creates a copy of the type parameter <strong><code>T</code></strong> for every thread that accesses it. Since each thread receives a copy of its own to manipulate, no locking constructs are required when a thread mutates its own copy. However, the <strong><code>ThreadLocal&lt;T></code></strong> class does offer methods to make each copy accessible across all threads.

## **Tasks**

Tasks fall under the realm of parallel programming.<br>

Over the years as processor speeds peaked, multicore systems have become ubiquitous. Having more than one processor on a system allows two threads of a process to execute in parallel, i.e. programs can be parallel and concurrent at the same time. With a single processor, a multithreaded program can only be concurrent. The APIs in the **<code>System.Threading.Tasks</code></strong> namespace facilitate programming on multicore machines and makes more efficient use of the thread pool. <br>

There are two ways to divide work amongst threads:<br>
* Data Parallelism: Divide the data among threads to work on and combine the partial results at the end to get the final outcome. Usually, all the threads run the same algorithm on distinct pieces of data.
* Task Parallelism: Divide differing tasks to be performed among threads. Usually, each task executes a different algorithm to achieve an uber common goal.


## Tasks vs Threading API

Some of the reasons to use the task API vs the threading API are:

* Tasks can have parent/child relationships between themselves.
* Tasks are tuned for high performance on multicore machines.
* When creating tasks, we can specify one of the **<code>TaskCreationOptions</code></strong> enum values to hint the scheduler how we want the task run.
* We can wait for tasks to complete without requiring any signaling primitives. For instance, if we wait for a parent task to complete, we indirectly wait for all its child tasks to complete. Additionally, static methods <strong><code>Task.WaitAll()</code></strong> and <strong><code>Task.WaitAny()</code></strong> can be used to wait for more than one task.
* We can create a cascading chain of tasks using continuations. 
* Exceptions occurring in tasks can be propagated to the parent task or to continuations. A spawned thread can't seamlessly forward an exception it experiences to the thread that spawned it.

A <strong><code>Task</code></strong> object can be defined as an asynchronous operation that is executed on the thread pool. A task represents a unit of work that can be executed independently in parallel. 
```c#
    Task task = new Task(()=> {
        Console.WriteLine("Hello World");
    });

    task.Start();
    task.Wait();
```

### **Passing Arguments and Returning Values**
It is easy to pass arguments and retrieve results from tasks. Recall, that threads don't return values. The <strong><code>Task&lt;TResult></code></strong> class can be used to have tasks return values. The following example demonstrates this capability.
```c#
using System;
using System.Threading;
using System.Threading.Tasks;

class Demonstration
{
    static void Main()
    {
        TaskExample te = new TaskExample();
        te.runTest();

        Console.WriteLine("Done");
    }
}

public class TaskExample
{
    public void runTest()
    {

        Task<String> task = new Task<String>((Object obj) =>
        {
            String name = (String)obj;
            Console.WriteLine("Hello " + name);
            Thread.Sleep(5000);
            return "Task Completed Successfully";
        }, "Reader", TaskCreationOptions.None);

        task.Start();
        Console.WriteLine(task.Result);
    }
}
```

Note that in the above code, asking for a task's <strong><code>Result</code></strong> property blocks the calling thread until the asynchronous operation is complete. It is equivalent of invoking <strong><code>Wait()</code></strong> on the task.<br>

We can also use the **<code>Task.Factory</code></strong> static object to start tasks as the following example demonstrates:
```c#
using System;
using System.Threading;
using System.Threading.Tasks;

class Demonstration
{
    static void Main()
    {
        Task task = Task.Factory.StartNew((object obj) => { 

          Console.WriteLine("Hello " + obj);

        }, "Reader");
        task.Wait();
    }
}
```

Last but not the least, we demonstrate an example thats chains two tasks to execute one after another.
```c#
using System;
using System.Threading;
using System.Threading.Tasks;

class Demonstration
{
    static void Main()
    {
        Task task1 = Task.Factory.StartNew((object obj) =>
        {
            Console.WriteLine("Hello " + obj);
            Console.WriteLine("First task executed by thread with id " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);

        }, "Reader");

        Task task2 = task1.ContinueWith((prevTask) =>
         {
             Thread.Sleep(3000);
             Console.WriteLine("Second task in progress");
             Console.WriteLine("Second task executed by thread with id " + Thread.CurrentThread.ManagedThreadId);
         });

        Thread.Sleep(100);

        Task.WaitAll(task1, task2);
        Console.WriteLine("Both tasks finished");
    }
}
```

```
Output
Hello Reader
First task executed by thread with id 4
Second task in progress
Second task executed by thread with id 5
Both tasks finished
```

# Brief Intro to Asynchronous Programming

Concurrency can be defined as dealing with multiple things at once. You can concurrently run several processes or threads on a machine with a single CPU but you'll not be parallel when doing so. Concurrency allows us to create an illusion of parallel execution even though the single CPU machine runs one thread or process at a time.<br>

Parallelism is when we execute multiple things at once. True parallelism can only be achieved with multiple CPUs.<br>

We can achieve asynchrony using a single thread or multiple threads but multithreading doesn't imply asynchrony. We can have a multithreaded system with no asynchrony at all.<br>

Incorporating asynchrony improves the throughput of a system - more work gets done with the same resources.<br>

A brief overview of the various patterns is presented below:
* **Task-based Asynchronous Pattern (TAP)**: Introduced in .NET 4.0 and is the recommended approach to asynchronous programming.
* **Event-based Asynchronous Pattern (EAP)**: Introduced in .NET 2.0 and requires "Async" as a suffix in the method and associated events. Legacy pattern.
* **Asynchronous Programming Model (APM)**: This is the **<code>IAsyncResult</code></strong> interface based pattern. Legacy pattern.

We'll now delve into task-based asynchronous programming model in the next few lessons.

# **Async/Await**

This lesson introduces the async and await keywords and works through an example using the two.<br>

The language keywords <strong><code>async</code></strong> and <strong><code>await</code></strong> are at the center of asynchronous programming in C#.<br>

The **<code>async</code></strong> keyword can be added to the signature of a method. It is syntactic sugar that hides away a lot of complexity that gets added for an <strong><code>async</code></strong> marked method. Under the hood, the compiler creates a state machine for an async method. We'll shortly explain the working of the state machine.<br>

A method marked async has restrictions on what it can return. We can return the following from an <strong><code>async</code></strong> method:
* void
* Task
* Task&lt;T>
* Starting in C# 7.0, we can also return generic types that satisfy the requirements for a type to be awaitable (more on that later).<br>

Asynchronous methods either return tasks or nothing. Tasks are awaitable. Note that when a type is said to be awaitable, it implies that it can be legally used as an argument to the <strong><code>await</code></strong> expression.

### **State Machine for Async Methods**

When the compiler comes across a method marked as <strong><code>async</code></strong>, it generates a state machine for the method. The state machine does the following:
* Synchronously execute the method up until the first occurrence of <strong><code>await</code></strong>.
* Check if the method being awaited is complete or not.
* If the awaited method is complete, then carry-on executing the rest of the method
* If the method isn't completed yet then the control is yielded back to the caller of the <strong><code>async</code></strong> method. The rest of the <strong><code>async</code></strong> method will get executed as a continuation once the awaited method is complete.
```c#
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

class Demonstration
{
    static async void sleep() {
      // wait for 3 seconds
      await Task.Delay(3000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);

    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        sleep();
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");

    }
}
```

```
Main thread id 1 program execution took = 0.005 seconds
```
When we return void from async methods, there's no way to query the status of such a method. Such async methods act as fire-and-forget methods.<br>
We can change the return type to Task for the async sleep method. The async sleep method will look like as follows:
```c#
class Demonstration
{
    static async Task sleep() {
      // wait for 3 seconds
      Console.WriteLine("Thread id before: " + Thread.CurrentThread.ManagedThreadId);      
      await Task.Delay(3000);
      Console.WriteLine("Thread id after: " + Thread.CurrentThread.ManagedThreadId);
    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Task sleepTask = sleep();
        Console.WriteLine("About to wait in main method for sync sleep method to finish.");
        sleepTask.Wait();
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");

    }
}
```

```
Thread id before: 1
About to wait in main method for sync sleep method to finish.
Thread id after: 5
Main thread id 1 program execution took = 3.009 seconds
```

Note that the part in the async sleep method up until the await call is executed by the same thread that executes the main thread. That verifies that the execution of an asyn method is synchronous up until the first await it encounters. The print statement in the async sleep method after the Task.Delay() is executed by a different thread from the thread pool. The thread that executes the rest of an async method after an await expression is governed by the synchronization context concept, which we'll discuss later.<br>
Lastly, we use the blocking sleepTask.Wait() call in the main method. <br>
Continuing with our example from the previous lesson, we'll now make changes to return a string from the async sleep() method. Earlier, the return type of the method was set to Task, we'll now change it to Task<String> and add a return statement. The changes appear as highlighted lines in the code widget below:
```c#
class Demonstration
{
    static async Task<String> sleep() {
      // wait for 3 seconds
      Console.WriteLine("Thread id before: " + Thread.CurrentThread.ManagedThreadId);      
      await Task.Delay(3000);
      Console.WriteLine("Thread id after: " + Thread.CurrentThread.ManagedThreadId);
      return "I slept well!";
    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Task<String> sleepTask = sleep();
        Console.WriteLine("About to wait in main method for sync sleep method to finish.");
        String retVal = sleepTask.Result;
        sw.Stop();
        Console.WriteLine("Received from asyn method " + retVal);
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");
    }
}
```

### **Multiple await**

Now we'll add more than one <strong><code>await</code></strong> statement to our sleep method. We'll break the three-second wait into three await calls to wait for one second each. The main method will still take three seconds to execute because it waits for the async sleep method to finish, which only finishes when it reaches the end of its function body after executing each of the await expressions.<br>

If you run the code widget below enough times, you'll notice that a different thread may execute the portion of the method after each **<code>await</code></strong> expression. Though this may not always happen.<br>
```c#
class Demonstration
{
    static async Task sleep() {

      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);

      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
   
      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Task sleepTask = sleep();
        sleepTask.Wait();
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");

    }
}
```
```
Thread id 5
Thread id 5
Thread id 5
Main thread id 1 program execution took = 3.01 seconds
```
Next, we'll make multiple invocations of the async sleep() method from within the main method. Each invocation will returns us a task that we'll wait on.<br>
Note that when we run the code widget, the execution time is still three seconds even though the main method invokes the async sleep method three times, which in case of synchronous execution would amount to nine seconds. The three asynchronous calls don't block the main thread and happen in parallel thus the total execution time is still three seconds.
```c#
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Task t1 = sleep();
        Task t2 = sleep();
        Task t3 = sleep();
        t1.Wait();
        t2.Wait();
        t3.Wait();
        
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");
    }
}
```

```
Thread id 7
Thread id 6
Thread id 5
Thread id 7
Thread id 6
Thread id 5
Thread id 6
Thread id 7
Thread id 5
Main thread id 1 program execution took = 3.009 seconds
```
Next, we'll refactor all the calls to the async sleep method into an uber sleep method SuperSleep() that is invoked from the main method. The method is shown below:
```c#
class Demonstration
{
    static async Task sleep() {
      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);

      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
   
      // wait for 1 second
      await Task.Delay(1000);
      Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
    }

    static async Task SuperSleep() {
        
        Task t1 = sleep();
        Task t2 = sleep();
        Task t3 = sleep();

        Task combinedTask = Task.WhenAll(t1, t2, t3);
        await combinedTask;
    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Task superSleepTask = SuperSleep();
        superSleepTask.Wait();
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");
    }
}
```

```
Thread id 5
Thread id 7
Thread id 6
Thread id 7
Thread id 5
Thread id 7
Thread id 5
Thread id 6
Main thread id 1 program execution took = 3.011 seconds
```
The System.Threading.Task namespace provides convenience static methods such as Tasks.WhenAny() and Tasks.WhenAll() for easing operations on several task objects.


# Awaitable
This lesson explains the awaitable concept in C#.<br>

In our previous example, we have used the await operator with objects of type Task. What types are allowed to be used with the await operator? The requirements are as follows:

* <code>The type should have a method <strong>GetAwaiter()</strong> that returns an instance of a class satisfying specific properties. Say if the return type is class <strong>X</strong> then it must meet the following bullet points.</code>
* <strong><code>X must implement the interface INotifyCompletion and optionally the ICriticalNotifyCompletion interface.</code></strong>
* <strong><code>X must have an accessible, readable instance property IsCompleted of type bool.</code></strong>
* <strong><code>X must have an accessible instance method GetResult() with no parameters and no type parameters.</code></strong>

A type which satisfies the above requirements can be used in an await expression. The Task class meets all the above requirements.<br>

What happens when an await expression is evaluated? The official documentation offers the most succint and comprehensive description which we preesent verbatime as below:<br>

"The await operator suspends evaluation of the enclosing async method until the asynchronous operation represented by its operand completes. When the asynchronous operation completes, the await operator returns the result of the operation, if any. When the await operator is applied to the operand that represents already completed operation, it returns the result of the operation immediately without suspension of the enclosing method. The await operator doesn't block the thread that evaluates the async method. When the await operator suspends the enclosing method, the control returns to the caller of the method."<br>

Think about await as points defined in a program from which threads can leave and return to at some later time in the future.<br>

Now that we understand the basic working of await/async, we'll write a class that we can await. In our example from the previous section, we used the method Task.Delay() to asynchronously wait for a specific duration. Now we'll build a class that can be passed-in the number of milliseconds to sleep.
```c#
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

class Demonstration
{
    static async Task<String> SuperSleep() {
        
        MyAwaitableType t1 = new MyAwaitableType(1000);
        MyAwaitableType t2 = new MyAwaitableType(1000);
        MyAwaitableType t3 = new MyAwaitableType(1000);

        await t1;
        await t2;
        return await t3;
    }

    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Task<String> superSleepTask = SuperSleep();
        Console.WriteLine(superSleepTask.Result);
        sw.Stop();
        Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds/1000.0) + " seconds");
    }
}

public class MyAwaitableType : INotifyCompletion
{
    bool completed = false;
    int sleepFor = 0;


    public MyAwaitableType(int sleepFor)
    {
        this.sleepFor = sleepFor;
    }

    public bool IsCompleted
    {
        get { return completed; }
    }

    public void OnCompleted(Action continuation)
    {
        Thread thread = new Thread(()=> {
            Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(sleepFor);
            completed = true;
            continuation();
        });
        thread.Start();

    }

    public MyAwaitableType GetAwaiter()
    {
        return this;
    }

    public String GetResult()
    {
      return "Hello World";
    }
}
```

```
Thread id 3
Thread id 4
Thread id 5
Hello World
Main thread id 1 program execution took = 3.008 seconds
```

The control flow is detailed below:

1. <code>When <strong>await awaitable</strong> is called, the <strong>GetAwaiter()</strong> method is invoked.</code><br>
2. <strong><code>IsCompleted() is invoked on the object returned in the previous step.</code></strong><br>
3. <code>If <strong>IsCompleted()</strong> returns true then control is passed back to the caller and the <strong>OnCompleted()</strong> method isn't invoked.</code><br>
4. <code>If <strong>IsCompleted()</strong> returns false, then the continuation delegate is passed to the awaiter via the <strong>OnCompleted()</strong> method. Within this method, we create another thread to sleep for the duration requested and then invoke the continuation. If the continuation is never invoked execution will never resume from after the <strong>await</strong> expression. Additionally, if we invoke the continuation without creating a new thread, the execution becomes synchronous. </code>


## Using Task as Awaitables
The discussion in the previous section was from an instructional standpoint. In most instances, you should never have the need to roll out your own awaitable type. We can wrap any snippet we would like to await in a task and then await the task object.
```c#
Task MySnippet()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("I am being run asynchronously");
        });
    }
```
We can now await the above task as follows:
```c#
    await MySnippet();
```

Using <strong><code>Task</code></strong> or <strong><code>Task&lt;TResult></code></strong> is by far the easiest way to create an awaitable.<br>

Caveats:<br>

Behind the scenes, we sleep a thread and invoke the continuation when the sleep period finishes. Does this mean we are simply shifting the burden from one thread to another? We are not blocking the thread that executes the **<code>await</code></strong> expression but blocking another on the <strong><code>Thread.Sleep()</code></strong> invocation. Indeed our implementation does that and only exists for demonstration purposes. In reality, the entire premise of async programming is to not block threads. In fact, when we invoke <strong><code>Task.Delay()</code></strong> there is no thread that gets blocked or is waiting for the timespan that we intend to sleep for. Under the hood, a timer is scheduled to fire after the intended delay. During that delay period, no thread is waiting, no thread is blocked!<br>

On a similar note, when we make asynchronous disk or network I/O calls, the request is handed off to the operating system and device drivers. The thread that made the request doesn't block, waiting for data to come back. Only when the OS comes back notifying the runtime that the requested data is ready to consume, then the .NET runtime allocates the same or another thread to pick-up execution immediately after the **<code>await</code></strong>-ed call. This simplified explanation, in essence, captures the spirit of async programming. It allows a single thread to <strong>await</strong> ten I/O calls rather than have ten threads <strong>wait</strong> ten I/O calls.<br>

However, it should be obvious that if we run CPU bound operations in a task then there are indeed other threads perform the operation but that is not the case with I/O operations.<br>

**SynchronizationContext**

The last item we'll briefly touch upon is the <strong><code>SynchronizationContext</code></strong>. Every thread is associated with an object of class <strong><code>SynchronizationContext</code></strong>, which can be accessed using the property <strong><code>SynchronizationContext.Current</code></strong>. If you run the code widget below, the context for the thread will be printed null. If a thread’s current <strong><code>SynchronizationContext</code></strong> is null, then it implicitly has a default synchronization context and runs on a threadpool thread.
```c#
using System;
using System.Threading;

class Demonstration
{
    static void Main()
    {
        Console.WriteLine(SynchronizationContext.Current == null ? "context is null" : "context is non-null");
    }
}
```

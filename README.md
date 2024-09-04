## Links:

[https://dotnettutorials.net/lesson/multithreading-in-csharp/](https://dotnettutorials.net/lesson/multithreading-in-csharp/)`1

[https://www.tutorialsteacher.com/ioc/ioc-container](https://www.tutorialsteacher.com/ioc/ioc-container)


## C# Application Types

You can use the C# language to develop four types of applications:

* Console applications, which display no graphics
* Windows applications, which use the standard Windows interface
* Web applications, which can be accessed with a browser
* Web services, which can be accessed using standard Internet protocols and which provide services such as current stock quotes, ISBN to title conversions, etc., that can be used by other applications

The .NET platform is web-centric. The C# language was developed to allow .NET programmers to create very large, powerful, high-quality web applications quickly and easily. **The .NET technology for creating web applications and web services is called ASP.NET**.

**The .NET tools for building Windows applications are called Windows Forms.**

The compiler reads your source code and produces IL. When you run the program, the .NET Just In Time (JIT) compiler reads your IL code and produces an executable application in memory.

The IL code is actually stored in a .exe file, but this file does not contain executable code. It contains the information needed by the JIT to execute the code when you run it.

The other style of comment apart from C++ is that C# comment uses three forward slashes (///). This is an XML-style comment and is used for advanced documentation techniques. The other two are normal as used in C++/Java.


## Data Types

<table>
  <tr>
   <td>
   </td>
   <td>
   </td>
   <td>
   </td>
   <td>The intrinsic types
   </td>
  </tr>
  <tr>
   <td><strong>C# type</strong>
   </td>
   <td><strong>Size (in bytes)</strong>
   </td>
   <td><strong>.NET type</strong>
   </td>
   <td><strong>Description</strong>
   </td>
  </tr>
  <tr>
   <td>byte
   </td>
   <td>1
   </td>
   <td>Byte
   </td>
   <td>Unsigned (values 0-255).
   </td>
  </tr>
  <tr>
   <td>char
   </td>
   <td>2
   </td>
   <td>Char
   </td>
   <td>Unicode characters.
   </td>
  </tr>
  <tr>
   <td>bool
   </td>
   <td>1
   </td>
   <td>Boolean
   </td>
   <td>True or false only
   </td>
  </tr>
  <tr>
   <td>sbyte
   </td>
   <td>1
   </td>
   <td>SByte
   </td>
   <td>Signed (values -128 to 127).
   </td>
  </tr>
  <tr>
   <td>short
   </td>
   <td>2
   </td>
   <td>Int16
   </td>
   <td>Signed (short) (values -32,768 to 32,767).
   </td>
  </tr>
  <tr>
   <td>ushort
   </td>
   <td>2
   </td>
   <td>UInt16
   </td>
   <td>Unsigned (short) (values 0 to 65,535).
   </td>
  </tr>
  <tr>
   <td>int
   </td>
   <td>4
   </td>
   <td>Int32
   </td>
   <td>Signed integer values between -2,147,483,648 and 2,147,483,647.
   </td>
  </tr>
  <tr>
   <td>uint
   </td>
   <td>4
   </td>
   <td>UInt32
   </td>
   <td>Unsigned integer values between 0 and 4,294,967,295.
   </td>
  </tr>
  <tr>
   <td>float
   </td>
   <td>4
   </td>
   <td>Single
   </td>
   <td>Floating point number. Holds the values from approximately +/-1.5 * 10<sup>-45</sup> to approximately +/-3.4 * 10<sup>38</sup> with 7 significant figures. 6-7 digits precision.
   </td>
  </tr>
  <tr>
   <td>double
   </td>
   <td>8
   </td>
   <td>Double
   </td>
   <td>Double-precision floating point; holds the values from approximately +/-5.0 * 10<sup>-324</sup> to approximately +/-1.8 * 10<sup>308</sup> with 1516 significant figures. 15-17 digits precision.
   </td>
  </tr>
  <tr>
   <td>decimal
   </td>
   <td>12
   </td>
   <td>Decimal
   </td>
   <td>Fixed-precision up to 28 digits and the position of the decimal point. This is typically used in financial calculations. Requires the suffix "m" or "M."
   </td>
  </tr>
  <tr>
   <td>long
   </td>
   <td>8
   </td>
   <td>Int64
   </td>
   <td>Signed integers ranging from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.
   </td>
  </tr>
  <tr>
   <td>ulong
   </td>
   <td>8
   </td>
   <td>UInt64
   </td>
   <td>Unsigned integers ranging from 0 to approximately 1.85 * 10<sup>19</sup>.
   </td>
  </tr>
  <tr>
   <td>string
   </td>
   <td>varies
   </td>
   <td>
   </td>
   <td>
   </td>
  </tr>
</table>



## Memory

* The **stack** is used to track local variables and the program’s state.
* The **heap** is used to store data that can be accessed anytime and from anywhere in the program.

Data types are either value or reference types. The most common reference types are strings, arrays, and objects that are on the heap; everything else is a value type on the stack. Reference types can be assigned a **null reference**, meaning that a reference can point to nothing at all. This is accomplished using the null keyword. We can’t assign null to ordinary value types.


## Naming Conventions

MS defines two types of naming conventions: Camel notation and Pascal notation .

Camel notation: myButton., Pascal notation: FreezingPoint.

Microsoft suggests that variables be written with Camel notation and constants with Pascal notation. In later chapters, you'll learn that member variables are named using Camel notation, while methods and classes are named using Pascal notation.


## Main() Method signatures

```c#
//parameterless Main() methods
public static void Main() { }
public static int Main() { }
public static async Task Main() { }
public static async Task<int> Main() { }

//Main() methods with string[] parameter
public static void Main(string[] args) { } ← DEFAULT MAIN
public static int Main(string[] args) { }
public static async Task Main(string[] args) { }
public static async Task<int> Main(string[] args) { }

//Starting from C# 9 (.NET 5), you can use the top-level statements feature to omit the Main() method.
//However, you can write top-level statements in one cs file only.

using System;
Console.WriteLine("This is considered as an entry point in 9.0+");
```

## Diff between String vs string

Essentially, there is no difference between string and String (capital S) in C#.
String (capital S) is a class in the .NET framework in the System namespace. The fully qualified name is System.String. Whereas, the lower case string is an alias of System.String.

## Quick Ops Tricks

```c#
//Convert string to Enum
Enum.Parse()
Week weekDay1 = (Week) Enum.Parse(typeof(Week), "Monday");

//comma sep string from int array
int[] nums = { 1, 2, 3, 4 }; or int[] nums = new int[3] { 1, 2, 3 };

var str = String.Join(",", nums);

//combine 2 arrays removing duplicates
int[] num1 = { 1, 2, 3, 4, 3, 55, 23, 2 }; 
int[] num2 = { 55, 23, 45, 50, 80 }; 
var all = num1.Union(num2).ToArray();

//remove duplicates from an array
int[] nums = { 1, 2, 3, 4, 3, 55, 23, 2 }; 
int[] dist = nums.Distinct().ToArray();

//searching in Array
public static T Find<T>(T[] array, Predicate<T> match);

string[] names = { "Steve", "Ravi", "Salman", "Boski" }; 
var stringToFind = "Bill"; 
var result = Array.Find(names,element => element == stringToFind); 
// returns "Bill"

var result = Array.Find(names, element => element.StartsWith("B")); 
// returns Bill

var result = Array.Find(names, element => element.Length >= 5); 
// returns Steve
```

Notice that the `Array.Find()` method only returns the first occurrence and not all matching elements. Use the `Array.FindAll()` method to retrieve all matching elements.

```c#
//comparer class
class PersonComparer : IComparer 
{ 
    public int Compare(object x, object y) 
    { 
    return 
    (new CaseInsensitiveComparer()).Compare(((Person)x).LastName, ((Person)y).LastName); 
    } 
}

Person[] people = { 
new Person(){ FirstName="Steve", LastName="Jobs"}, 
new Person(){ FirstName="Bill", LastName="Gates"}, 
new Person(){ FirstName="Lary", LastName="Page"} 
}; 
Array.Sort(people, new PersonComparer());

//Split
string phrase = "The quick brown fox jumps over the lazy dog.";
string[] words = phrase.Split(' ');

foreach (var word in words)
{
    System.Console.WriteLine($"<{word}>");
}
```

## Ref and Out Parameter in Method Overloading

Both ref and out are treated the same as compile-time but different at runtime. We cannot define an overloaded method that differs only on 'ref' and 'out' parameter. 

The following will give a compiler error.
```c#
void ProcessNumber(ref int k, int j); 
void ProcessNumber(out int k, int j);
```
Following works:
```c#
void ProcessNumber(int k, int j); 
void ProcessNumber(ref int k, int j); 
void ProcessNumber(int k, ref int j); }
```

C# 7 introduced a new way of declaring the out parameters. In C# 7 onwards, you don't need to declare out variable before passing to parameters. It can now be declared while calling the method.
```c#
OutParamExample(out int a);// declare out variable while calling method
```

## Using StopWatch to calc execution time

```c#
var watch = new System.Diagnostics.Stopwatch(); 
watch.Start(); 
for (int i = 0; i < 1000; i++) 
{ 
Console.Write(i); 
} 
watch.Stop(); 
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
```

## Enumeration

The base-type is the underlying type for the enumeration. You might specify that you are declaring constant ints, constant longs, or something else. If you leave out this optional value (and often you will), it defaults to int, but you are free to use any of the integral types (ushort, long) except for char. For example, the following fragment declares an enumeration with unsigned integers (uint) as the base-type:

```c#
enum ServingSizes : uint
{
Small = 1,
Regular = 2,
Large = 3
}
```

**Using an enum**

```c#
System.Console.WriteLine("Test enum: {0}",
(int) ServingSizes.Large );
```

Each constant in an enumeration corresponds to a numerical value. If you don't specifically set it otherwise, the enumeration begins at 0 and each subsequent value counts up from the previous. Thus, if you create the following enumeration:

```c#
enum SomeValues
{
First,
Second,
Third = 20,
Fourth
}
```

the value of `First` will be 0, `Second` will be 1, `Third` will be 20, and `Fourth` will be 21.
```c#
// Declare an enum
enum Direction { North, East, South, West };
Direction PlayerDirection = Direction.North;
```

C# also offers the ability to switch on a `string`.

## Directives

The #region and #endregion directives

The #region directive is used to indicate a certain block of code. This keeps our code organized as blocks.

#define, #if, #else, and #endif

Below is a list of preprocessor directives:

**Conditional compilation:** #if, #else, #elif, #endif, #define, and #undef

**Other:** #warning, #error, #line, #region, #endregion, #pragma, #pragma warning, and #pragma checksum

## Namespace

A **namespace** helps organize a large group of related code. To use a namespace, call it with the using directive or include it before the class name.
```c#
namespace NamespaceExample1Console
{
  // Empty Namespace
}

// In C# 10 file scoped namespaces were introduced. The namespace below does the same as the above namespace and will include everything in the file.
namespace NamespaceExample2Console;

using System; // C# 10 comes with ImplicitUsings, meaning the most popular using namespaces such as System are already built in so there is no need to declare them
```

### Global in C#
```c#
Global usings were introduced in C# version 10. When the word global appears before the using directive, that using statement applies to the entire project. It's common to create a GlobalUsings.cs file and include all the global usings in one location.
global using System.Console;
```

### Using static directive
```c#
The static members of a static class can be accessed without specifying the type name, so Console.WriteLine() can be simplified to WriteLine(). This is done with the using static directive. You can combine both modifiers (global and static) to import the static members from a type in all source files in your project.
using static System.Console;
global using static System.Console;
You can also create an alias for a namespace or a type with a using alias directive
using aliasname = PC.MyCompany.Project;
```


_The following example shows how to define a <code>using</code> directive and a <code>using</code> alias for a class:</em>
```c#
// Using alias directive for a class.
using AliasToMyClass = NameSpace1.MyClass;
// Using alias directive for a generic class.
using UsingAlias = NameSpace2.MyClass<int>;
namespace NameSpace2
{
    class MyClass<T>
    {
        public override string ToString()
        {
            return "You are in NameSpace2.MyClass.";
        }
    }
}
var instance1 = new AliasToMyClass();
Console.WriteLine(instance1);
var instance2 = new UsingAlias();
Console.WriteLine(instance2);
```

## Casting

Implicit vs Explicit (required for wider type to narrower type)

### Parse/TryParse

Used to convert one datatype to another, say string to int. If conversion fails, 0 is assigned instead of crash.
```c#
string textExample = "7";

int textExampleInt;
int.TryParse(textExample, out textExampleInt);
The int.TryParse function returns a boolean value that can be used in an if statement to make a condition on it.
```

## Access modifiers
<table>
  <tr>
   <td><strong>Access modifier</strong>
   </td>
   <td><strong>Restrictions</strong>
   </td>
  </tr>
  <tr>
   <td><code>public</code>
   </td>
   <td>No restrictions. Members that are marked <code>public</code> are visible to any method of any class.
   </td>
  </tr>
  <tr>
   <td><code>private</code>
   </td>
   <td>The members in class A that are marked <code>private</code> are accessible only to methods of class A.
   </td>
  </tr>
  <tr>
   <td><code>protected</code>
   </td>
   <td>The members in class A that are marked <code>protected</code> are accessible to methods of class A and also to methods of classes derived from class A.
   </td>
  </tr>
  <tr>
   <td><code>internal</code>
   </td>
   <td>The members in class A that are marked <code>internal</code> are accessible to methods of any class in A's assembly. An assembly is a collection of files that appear to the programmer as a single executable or DLL.
   </td>
  </tr>
  <tr>
   <td><code>protected internal</code>
   </td>
   <td>In same assembly any class can access it (being internal). Outside of assembly only derived class can access it.
   </td>
  </tr>
  <tr>
   <td><code>Private protected</code>
   </td>
   <td>Only with in base class or derived class in the same assembly can access it. 
   </td>
  </tr>
</table>

**Class members are declared <code>private</code> by default, making their access explicit indicates a conscious decision and is self-documenting.</strong>

```c#
class A {};
```

In C#, when a class is declared without specifying an access modifier, the default access modifier is internal. This means that the class is accessible within the same assembly (or project), but not from outside the assembly. The above is equivalent to:

```c#
internal class A {}
```

If you explicitly want to specify the access modifier, you can use `public`, `private`, `protected`, `internal`, or `protected internal`, depending on the desired visibility and accessibility of the class.

In C#, a **<code>private class A {}</code></strong> declaration means that the class <code>A</code> is only accessible within the containing class or struct. This is a rarely used construct in C# because nested private classes are typically used for implementation details that should not be exposed outside of their containing class.

Here's a brief explanation of how it works:

```c#
public class OuterClass
{
    private class A
    {
        // This is a private nested class A.
        // It can only be accessed within the scope of the OuterClass.
    }
}
```

In C#, a `protected class A {}` declaration is not allowed at the top level. However, a protected access modifier can be applied to nested classes within other classes.

Here's how it works:
```c#
public class OuterClass
{
 protected class A
 {
 // This is a protected nested class A.
 // It can only be accessed from within OuterClass or its derived classes.
 }
}
```

In C#, a `protected internal class A {}` declaration defines a class `A` with access that is a combination of `protected` and `internal`. This means that `A` is accessible within the same assembly (project) and also by any derived classes, regardless of whether they are in the same assembly or in a different assembly. So you cant use it in a other assemblies unless you create a DerivedClass deriving from it first.

```c#
using Assembly1; // Reference to Assembly1 where BaseClass is written
// Derived class in a different assembly (Assembly 2)
public class DerivedClass : BaseClass
{
    // Access the protected method from the base class
    public void AccessProtectedMethod()
    {
        // This method can access the protected method from the base class
        ProtectedMethod();
    }
}
```

Other KeyWords that can be used while declaring a class in c#:

1. **abstract**: Specifies that the class cannot be instantiated directly and must be derived.
2. **sealed**: Prevents the class from being inherited by other classes.
3. **static**: Indicates that the class cannot be instantiated and can only contain static members. static classes cannot be used as base classes in C#, they are sealed by default.
4. **partial**: Allows the class to be split across multiple files.
5. **unsafe**: Allows the class to contain code that uses pointer types and performs unsafe operations.

```c#
public unsafe class Example
{
    // Readonly field
    private readonly int readonlyField = 10;

    // Unsafe code block
    public void UnsafeMethod()
    {
        int* p;
        int value = 20;
        p = &value;

        Console.WriteLine("Unsafe value: " + *p);
    }
```

### Keywords for class members:

1. **static**: Indicates that the member belongs to the type itself, rather than to instances of the type.
2. **readonly**: Specifies that the member can only be assigned a value during initialization or in a constructor and cannot be modified afterwards.
3. <code>public <strong>readonly</strong> int ReadOnlyField = 10;</code>
4. <strong>const</strong>: Declares a constant member whose value cannot be changed.
5. <code>public <strong>const</strong> int ConstField = 100;</code>
6. <strong>abstract</strong>: Indicates that the member does not have implementation in the current class and must be implemented by derived classes.
7. <strong>virtual</strong>: Allows the member to be overridden in derived classes.
8. <strong><code>public virtual void VirtualMethod(){...}</code></strong>
9. <strong>override</strong>: Overrides a virtual member inherited from a base class.
10. <strong><code>public override void VirtualMethod(){...}</code></strong>
11. <strong>extern</strong>: Specifies that the method is implemented externally in native code (usually used in conjunction with DllImport).
12. <strong>unsafe</strong>: Indicates that the member contains unsafe code that uses pointer types and performs unsafe operations.
13. <strong>volatile</strong>: Indicates that the member may be modified by multiple threads that are executing at the same time. 
14. <code>private <strong>volatile</strong> bool isRunning = true;</code>
15. <code>volatile</code> ensures visibility of the most up-to-date value across threads, you still need synchronization mechanisms to ensure atomicity for compound operations.

```c#
public class ExternalClass
{
    // External method declaration
    [DllImport("user32.dll")]
    public static extern int MessageBox(int hWnd, string text, string caption, uint type);
}

// Calling external method
ExternalClass.MessageBox(0, "Hello from C#!", "Message", 0);

public static double Pi => Math.PI;
```

`Pi` is defined using an expression-bodied property. This syntax allows us to define a property with a getter only, and it implicitly returns the result of the expression following the `=>` arrow.

This syntax is more concise than using a traditional property with a getter method:
```c#
public static double Pi
{
    get { return Math.PI; }
}
```

## Declaring Arrays
```c#
string[] foods = new string[5];
foods[0] = "Pizza"; // Arrays start at value 0 
foods[1] = "Burger";

string[] drinks = new string[5] { "Pepsi", "Sprite", "", "", "" };
// The additional "" are holding the place for the remaining 3 items

string[] cars = new string[] { "Ford", "Toyota" }; 
string[] animals = { "Cat", "Dog" };
foreach (string food in foods)
{
   Console.WriteLine($"The food item is {food}.");
}

int[] someNumbers = { 21, 22, 50, 3, 6 };
Array.Sort(someNumbers); // Sort the numbers in ascending order
//Reverse() - reverse sorts
```

For example, to declare and instantiate a two-dimensional rectangular array named `myRectangularArray` that contains two rows and three columns of integers, you would write:

```c#
int [,] myRectangularArray = new int[2,3];

// imply a 4x3 array
int[,] rectangularArray =
{
{0,1,2}, {3,4,5}, {6,7,8}, {9,10,11}
};

// 2-D Array for a game map
// Place a comma between the brackets[,] to use a 2-D Array
string [,] myGameMap = new string [,]
{
   {"Scary Room1", "Safe Room2", "Safe Room3"}, // Row 0
   {"Dangerous Room4", "Safe Room5", "Safe Room6"}, // Row 1
   {"Safe Room7", "Scary Room8", "Safe Room9"} // Row 2
};

// Add 2 commas between the square brackets toindicate a 3-D array
string [,,] arrayExample3D = new string [,,]
{
   {
       {"This is ", "a 3-D "},         // Row 0 , Column 0, Depth is 0 or 1
       {"array ", "example."}          // Row 0 , Column 1, Depth is 0 or 1
   },
   {
       {"They can ", "become "},       // Row 1 , Column 0, Depth is 0 or 1
       {"complex ", "very quickly."}   // Row 1 , Column 1, Depth is 0 or 1
   }
};

Console.Write(arrayExample3D[0, 0, 0]);  // Output: This is
Console.Write(arrayExample3D[0, 0, 1]);  // Output: a 3-D
Console.Write(arrayExample3D[0, 1, 0]);  // Output: array
Console.Write(arrayExample3D[0, 1, 1]);  // Output: example.
```

## Jagged Arrays

A jagged array is an array of arrays. It is called "jagged" because each of the rows need not be the same size as all the others, and thus a graphical representation of the array would not be square.

```c#
const int rows = 4;

// declare the jagged array as 4 rows high
int[][] jaggedArray = new int[rows][];

// the first row has 5 elements
jaggedArray[0] = new int[5];

// a row with 2 elements
jaggedArray[1] = new int[2];

// a row with 3 elements
jaggedArray[2] = new int[3];

// the last row has 5 elements
jaggedArray[3] = new int[5];
```

Outputting the values would be to use two nested `for` loops, and use the `Length` property of the array to control the loop:

```c#
for (int i = 0; i < jaggedArray.Length; i++ )
{
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
    Console.WriteLine("jaggedArray[{0}][{1}] = {2}",
        i, j, jaggedArray[i][j]);
    }
}
```

## Operators
```c#
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
```

### Null-conditional operators ?. and ?[]
* If `a` evaluates to `null`, the result of `a?.x` or `a?[x]` is `null`.
* If `a` evaluates to non-null, the result of `a?.x` or `a?[x]` is the same as the result of `a.x` or `a[x]`, respectively.

Use the `?.` operator to check if a delegate is non-null and invoke it in a thread-safe way (for example, when you [raise an event](https://learn.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events)), as the following code shows:

```c#
PropertyChanged?.Invoke(…)

Above is equal to:

var handler = this.PropertyChanged;
if (handler != null)
{
    handler(…);
}
```

### Index from end operator ^ (System.Index)

The `^` operator indicates the element position from the end of a sequence.

```c#
int[] xs = new[] { 0, 10, 20, 30, 40 };
int last = xs[^1];
Console.WriteLine(last);  // output: 40

var lines = new List<string> { "one", "two", "three", "four" };
string prelast = lines[^2];
Console.WriteLine(prelast);  // output: three

string word = "Twenty";
Index toFirst = ^word.Length;
char first = word[toFirst];
Console.WriteLine(first);  // output: T
```

### Range operator .. (System.Range)

The `..` operator specifies the start and end of a range of indices as its operands. The left-hand operand is an _inclusive_ start of a range. The right-hand operand is an _exclusive_ end of a range. 

```c#
int[] numbers = new[] { 0, 10, 20, 30, 40, 50 };
int start = 1;
int amountToTake = 3;
int[] subset = numbers[start..(start + amountToTake)];
Display(subset);  // output: 10 20 30

int margin = 1;
int[] inner = numbers[margin..^margin];
Display(inner);  // output: 10 20 30 40

string line = "one two three";
int amountToTakeFromEnd = 5;
Range endIndices = ^amountToTakeFromEnd..^0;
string end = line[endIndices];
Console.WriteLine(end);  // output: three

void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
```

You can omit any of the operands of the `..` operator to obtain an open-ended range:

* `a..` is equivalent to `a..^0`
* `..b` is equivalent to `0..b`
* `..` is equivalent to `0..^0`


### Operator overloadability

The `.`, `()`, `^`, and `..` operators can't be overloaded. The `[]` operator is also considered a non-overloadable operator. Use [indexers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/) to support indexing with user-defined types.

The `is`, `as`, and `typeof` operators can't be overloaded.

A user-defined type can't overload the pointer related operators `&`, `*`, `->`, and `[]`.

## is operator

The `is` operator checks if the run-time type of an expression result is compatible with a given type. The `is` operator also tests an expression result against a pattern.
```c#
int i = 23;
object iBoxed = i;
int? jNullable = 7; //Nullable int; means null can be assigned to it
if (iBoxed is int a && jNullable is int b)
{
    Console.WriteLine(a + b);  // output 30
}
```

## as operator

The `as` operator explicitly converts the result of an expression to a given reference or nullable value type.
```c#
E as T //same as 
E is T ? (T)(E) : (T)null
```

## typeof operator

The `typeof` operator obtains the [System.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type) instance for a type.
```c#
Console.WriteLine(typeof(List<string>)); //System.Collections.Generic.List`1[System.String]
```

The argument mustn't be a type that requires metadata annotations. Examples include the following types:
* `dynamic`
* `string?` (or any nullable reference type)

## Pointer related operators - &, *, ->, [] 
```c#
unsafe
{
    int number = 27;
    int* pointerToNumber = &number;

    Console.WriteLine($"Value of the variable: {number}");
    Console.WriteLine($"Address is:{(long)pointerToNumber:X}");
}

// Output is similar to:
// Value of the variable: 27
// Address is: 6C1457DBD4
```

The operand of the `&` operator must be a fixed variable. _Fixed_ variables are variables that reside in storage locations that are unaffected by operation of the [garbage collector](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/). In the preceding example, the local variable `number` is a fixed variable, because it resides on the stack. Variables that reside in storage locations that can be affected by the garbage collector (for example, relocated) are called _movable_ variables. Object fields and array elements are examples of movable variables. You can get the address of a movable variable if you "fix", or "pin", it with a [fixed statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/fixed). The obtained address is valid only inside the block of a `fixed` statement. The following example shows how to use a `fixed` statement and the `&` operator:

```c#
unsafe
{
    byte[] bytes = { 1, 2, 3 };
    fixed (byte* pointerToFirst = &bytes[0])
    {
        // The address stored in pointerToFirst
        // is valid only inside this fixed statement block.
    }
}
```

## For an expression `p` of a pointer type, a pointer element access of the form `p[n]` is evaluated as `*(p + n)`

A `stackalloc` expression allocates a block of memory on the stack. A stack allocated memory block created during the method execution is automatically discarded when that method returns. You can't explicitly free the memory allocated with `stackalloc`. A stack allocated memory block isn't subject to [garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/) and doesn't have to be pinned with a [fixed statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/fixed).

```c#
unsafe
{
    char* pointerToChars = stackalloc char[123];

    for (int i = 65; i < 123; i++)
    {
        pointerToChars[i] = (char)i;
    }

    Console.Write("Uppercase letters: ");
    for (int i = 65; i < 91; i++)
    {
        Console.Write(pointerToChars[i]);
    }
}
// Output:
// Uppercase letters: ABCDEFGHIJKLMNOPQRSTUVWXYZ
```

## ! (null-forgiving) operator

The unary postfix `!` operator is the null-forgiving, or null-suppression, operator. In an enabled [nullable annotation context](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts), you use the null-forgiving operator to suppress all nullable warnings for the preceding expression but at runtime it will throw exceptions as expected for null cases.

```c#
#nullable enable
public class Person
{
    public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

    public string Name { get; }
}

[TestMethod, ExpectedException(typeof(ArgumentNullException))]
public void NullNameShouldThrowTest()
{
    var person = new Person(null!);
}
```

Without the null-forgiving operator, the compiler generates the following warning for the preceding code: `Warning CS8625: Cannot convert null literal to non-nullable reference type`. By using the null-forgiving operator, you inform the compiler that passing `null` is expected and shouldn't be warned about.

## ?? and ??= operators - the null-coalescing operators

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null`; otherwise, it evaluates the right-hand operand and returns its result. 
```c#
private static void Display<T>(T a, T backup)
{
    Console.WriteLine(a ?? backup);
}

List<int> numbers = null;
int? a = null;

Console.WriteLine((numbers is null)); // expected: true
// if numbers is null, initialize it. Then, add 5 to numbers
(numbers ??= new List<int>()).Add(5);
Console.WriteLine(string.Join(" ", numbers));  // output: 5
Console.WriteLine((numbers is null)); // expected: false        

Console.WriteLine((a is null)); // expected: true
Console.WriteLine((a ?? 3)); // expected: 3 since a is still null 
// if a is null then assign 0 to a and add a to the list
numbers.Add(a ??= 0);
Console.WriteLine((a is null)); // expected: false        
Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
Console.WriteLine(a);  // output: 0	    
```

## nameof

A `nameof` expression produces the name of a variable, type, or member as the string constant. A `nameof` expression is evaluated at compile time and has no effect at run time. 
```c#
Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
Console.WriteLine(nameof(List<int>));  // output: List
Console.WriteLine(nameof(List<int>.Count));  // output: Count
Console.WriteLine(nameof(List<int>.Add));  // output: Add

var numbers = new List<int> { 1, 2, 3 };
Console.WriteLine(nameof(numbers));  // output: numbers
Console.WriteLine(nameof(numbers.Count));  // output: Count
Console.WriteLine(nameof(numbers.Add));  // output: Add
```

## Operator overloading - predefined unary, arithmetic, equality and comparison operators

Use the `operator` keyword to declare an operator. An operator declaration must satisfy the following rules:
* It includes both a `public` and a `static` modifier.
* A unary operator has one input parameter. A binary operator has two input parameters. In each case, at least one parameter must have type `T` or `T?` where `T` is the type that contains the operator declaration.
```c#
public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        }
        num = numerator;
        den = denominator;
    }

    public static Fraction operator +(Fraction a) => a;
    public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

    public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

    public static Fraction operator -(Fraction a, Fraction b)
        => a + (-b);

    public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a.num * b.num, a.den * b.den);

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.num == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(a.num * b.den, a.den * b.num);
    }

    public override string ToString() => $"{num} / {den}";
}

public static class OperatorOverloading
{
    public static void Main()
    {
        var a = new Fraction(5, 4);
        var b = new Fraction(1, 2);
        Console.WriteLine(-a);   // output: -5 / 4
        Console.WriteLine(a + b);  // output: 14 / 8
        Console.WriteLine(a - b);  // output: 6 / 8
        Console.WriteLine(a * b);  // output: 5 / 8
        Console.WriteLine(a / b);  // output: 10 / 4
    }
}
```

## What is a named argument?

Using named arguments helps clarify which parameters should be used when calling a method. Without named arguments, a long list of numbers can quickly become confusing.
```c#
// Without named arguments, it is not clear what the numbers represent.
CharacterDescription("Bob", 42, 72, 61);
CharacterDescription("Bob", 42, 72, level: 61); // With 1 named argument
CharacterDescription("Bob", age: 42, height: 72, level: 61); // With 3 named arguments
CharacterDescription(name: "Bob", age: 42, height: 72, level: 61); // With all named arguments

// TIP: Method arguments can be entered on multiple lines for additional clarity
CharacterDescription(
   name: "Bob",
   age: 42,
   height: 72,
   level: 61
   );

static void CharacterDescription(string name, int age, int height, int level)
{
   Console.WriteLine($"{name}: level {level}, {age} years old, and height of {height} inches.");
}
```

## Method Arguments

### Parameter arrays (params)

By using the `params` keyword to indicate that a parameter is a parameter array, you allow your method to be called with a variable number of arguments. The parameter tagged with the `params` keyword must be an array type, and it must be the last parameter in the method's parameter list.

A caller can then invoke the method in either of four ways:

* By passing an array of the appropriate type that contains the desired number of elements.
* By passing a comma-separated list of individual arguments of the appropriate type to the method.
* By passing `null`.
* By not providing an argument to the parameter array.

```c#
class ParamsExample
{
    static void Main()
    {
        string fromArray = GetVowels(new[] { "apple", "banana", "pear" });
        Console.WriteLine($"Vowels from array: '{fromArray}'");

        string fromMultipleArguments = GetVowels("apple", "banana", "pear");
        Console.WriteLine($"Vowels from multiple arguments: '{fromMultipleArguments}'");


        string fromNull = GetVowels(null);
        Console.WriteLine($"Vowels from null: '{fromNull}'");

        string fromNoValue = GetVowels();
        Console.WriteLine($"Vowels from no value: '{fromNoValue}'");
    }

    static string GetVowels(params string[] input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        var vowels = new char[] { 'A', 'E', 'I', 'O', 'U' };
        return string.Concat(
            input.SelectMany(
                word => word.Where(letter => vowels.Contains(char.ToUpper(letter)))));
    }
}

// The example displays the following output:
//     Vowels from array: 'aeaaaea'
//     Vowels from multiple arguments: 'aeaaaea'
//     Vowels from null: ''
//     Vowels from no value: ''
```

### default keyword

You can use the `default` literal, as the compiler can infer the type from the parameter's declaration.
```c#
public class Options
{
    public void ExampleMethod(int required, int optionalInt = default,
                              string? description = default)
   {
        var msg = $"{description ?? "N/A"}: {required} + {optionalInt} = {required + optionalInt}";
        Console.WriteLine(msg);
   }
}
```

### Passing Arrays

If a method is passed an array as an argument and modifies the value of individual elements, it isn't necessary for the method to return the array, although you may choose to do so for good style or functional flow of values. 
```c#
using System;

public class ArrayValueExample
{
   static void Main(string[] args)
   {
      int[] values = { 2, 4, 6, 8 };
      DoubleValues(values);
      foreach (var value in values)
         Console.Write("{0}  ", value); //updated value is printed
   }

   public static void DoubleValues(int[] arr) //passed as address
   {
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
         arr[ctr] = arr[ctr] * 2;
   }`
}
// The example displays the following output:
//       4  8  12  16
```

### Expression (Lambda) bodies members
```c#
public Point Move(int dx, int dy) => new Point(x + dx, y + dy);
public void Print() => Console.WriteLine(First + " " + Last);
// Works with operators, properties, and indexers too.
public static Complex operator +(Complex a, Complex b) => a.Add(b);
public string Name => First + " " + Last;
public Customer this[long id] => store.LookupCustomer(id);
```

## Class
```c#
// DeckOfCards Array holds objects of type Card (Card class created in previous examples)
Card[] DeckOfCards = new Card[]
{
   // Create objects of each card needed for a deck of cards
   new Card {Name = "Ace", Value = 1, Suit = "Heart"},
   new Card {Name = "Two", Value = 2, Suit = "Heart"},
   new Card {Name = "Three", Value = 3, Suit = "Heart"}
   // Continue adding cards...
};

// Calling DisplayCard method
DeckOfCards[0].DisplayCard();
DeckOfCards[1].DisplayCard();
DeckOfCards[2].DisplayCard();

class Card
{
   // Note: This example uses get-set properties. The upcoming section
   // "Get-Set Properties" covers why and how they are used.
   public string Name{ get; set; }
   public int Value { get; set; }
   public string Suit { get; set; } = "Heart"; // Set a default value of "Heart"

   public void DisplayCard()
   {
       Console.WriteLine($"Card Suit: {Suit}, Name: {Name}, Value: {Value}");
   }
}
```

### get/set
```c#
public class Vehicle{
   private string car;
   public string Car
   {
       get { return car; }
       set { car = value; }
   }
}

Auto implemented property => public string MyProperty{ get; set; } = 5;
Get Only property (or readonly)=> public string MyProperty{ get; }
Private set => public int CarID { get; private set; }
```

### Static

A [static](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static) class is basically the same as a non-static class, but there is one difference: a static class cannot be instantiated. In other words, you cannot use the [new](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator) operator to create a variable of the class type. It is a sealed class too.

```c#
OnlyOneHouse.Height = 10;
OnlyOneHouse.Size = OnlyOneHouse.Height * OnlyOneHouse.Width;
OnlyOneHouse.DisplayHouse(); // Output: Size of House: 50 and color Red

static class OnlyOneHouse
{
   // Default attributes for House class
   public static int Height { get; set; }
   public static int Width { get; set; } = 5;
   public static int Size { get; set; } = 25;
   public static string Color { get; set; } = "Red";

   public static void DisplayHouse()
   {
       Console.WriteLine($"Size of House: {Size} and color {Color}");
   }
}
```

## Classes

### Inheritance:

Classes can inherit all class features from another class using inheritance. With **class inheritance**, the derived class acquires all of the features from the base class. C# only supports single inheritance, meaning that it can only inherit one class at a time.
```c#
public class ASecondClass : TheFirstClass
{ 

  // ASecondClass inherits all the features from the base class TheFirstClass 

}
```

### What is a virtual method?

To redefine a method in a _derived class_, we use a **virtual method**. Virtual methods are redefined using the virtual keyword in the _base class_ and the override keyword in the _derived class_.
```c#
Animal anyAnimal = new();
anyAnimal.Sound(); // Output: Generic Noise

Dog aDog= new();
aDog.Sound(); // Output: Bark

anyAnimal = aDog;
anyAnimal.Sound(); //Output: Bark

class Animal
{
   public virtual void Sound()
   {
       Console.WriteLine("Generic Noise");
   }
}

class Dog : Animal
{
   public override void Sound()
   {
       Console.WriteLine("Bark");
   }
}
```

### What is an abstract class?[#](https://www.educative.io/courses/programming-fundamentals-csharp-dotnet/qVBr7zxKnBG#What-is-an-abstract-class?)

**Abstract classes** are commonly used for _inheritance_ and can’t be _instantiated_. **Abstract methods** within an abstract class must be contained in the _child class_ or the program won’t compile. Virtual methods are not required to be overridden in _child classes_.

```c#
SpanishLanguage languageSelected = new();
languageSelected.Greeting(); // Output: Hola
languageSelected.Goodbye(); // Output: Goodbye!  

public abstract class Talk
{
   // Abstract must be implemented in child class
   public abstract void Greeting();

   // Virtual is NOT required to be in child class but may be optionally overridden.
   public virtual void Goodbye()
   {
       Console.WriteLine("Goodbye!");
   }
}

public class SpanishLanguage : Talk
{
   public override void Greeting()
   {
       Console.WriteLine("Hola");
   }
}
```

### Calling Base Class Constructors
```c#
public ListBox( int theTop, int theLeft, string theContents):
base(theTop, theLeft) // call base constructor
```

Because classes cannot inherit constructors, a derived class must implement its own constructor and can only make use of the constructor of its base class by calling it explicitly.

If the base class has an accessible default constructor, the derived constructor is not required to invoke the base constructor explicitly; instead, the default constructor is called implicitly as the object is constructed. However, if the base class does not have a default constructor, every derived constructor must explicitly invoke one of the base class constructors using the `base` keyword. The keyword `base` identifies the base class for the current object.


### Abstract Method

Designating a method as abstract is accomplished by placing the `abstract` keyword at the beginning of the method definition:

`abstract public void DrawWindow( ); `(Because the method can have no implementation, there are no braces, only a semicolon.)

If one or more methods are abstract, the class definition must also be marked `abstract`, as in the following:
```c#
abstract public class Window
```

### Sealed Classes

A sealed class does not allow classes to derive from it at all. 

### What are generics?

**Generics** define _type-safe classes_ without committing to any specific data types. They’re essentially a placeholder until a specified data type is declared. There are many prebuilt classes that use generics. 

**Generic type names** are usually a single capital letter, `T` being the most common, or a simple name starting with `T`, such as `TKey` or `TValue`.
```c#
AGenericClass<int> intExample = new(5);
// Output: The value is 5 and is a System.Int32

class AGenericClass<T>
{
   private T aVariable;

   public AGenericClass(T aValue)
   {
       aVariable = aValue;
       Console.WriteLine($"The value is {aVariable} and is a {typeof(T).ToString()}");
        // Output: The value is 5 and is a System.Int32
   }

   public void DisplayTypeOnly(T aValue)
   {
       Console.WriteLine($"A {typeof(T).ToString()}"); // Output: A System.String
   }
}
```

### What’s an extension method?

**Extension methods** are those that appear to belong to a class, but they don’t actually. Extension methods must be defined in static classes and be static methods.

The built-in string class contains methods such as ToLower() and Length(). In the example below, an extension method called ToStarBox() is created and can be used like the previous string methods mentioned. It will appear to be in the string class, when it is actually not.

Extension method parameters must start with the this keyword followed by the type that’s being created, in our example, this is the string data type.
```c#
string aWord= "Hello";
aWord.ToStarBox();
// Output:
// *******
// *Hello*
// *******

public static class StringExtensionExample
{
   public static void ToStarBox(this string text)
   {
       string starLine= "**";
       for (int i = 0; i < text.Length; i++)
       {
           starLine += "*";
       }
       Console.WriteLine(starLine);
       Console.WriteLine($"*{text}*");
       Console.WriteLine(starLine);
   }
}
```

### What is an `interface`?

An `interface` behaves as a contract between itself and any class where it’s used. A class that implements an interface must now implement all its members. These `interfaces` are usually named with a capital `I`, though it isn’t required. These `interfaces` can only contain declarations, and all members are implicitly abstract and public. Beginning with **C# version 8.0**, however, an interface may define default implementations for some or all of its members.
```c#
Cake exampleCake = new(); 
Pasta examplePasta = new();

// Cake and Pasta classes both use the IFood interface so both can be stored in a List of IFood
List<IFood> foodList = new()
{
    exampleCake,
    examplePasta 
};

foreach (IFood food in foodList)
{
    food.Prepare();
}

// here is where the interface is defined
interface IFood
{
    void Prepare();
}

// interface is implemented in class Cake
public class Cake : IFood
{
    public void Prepare()
    {
        Console.WriteLine("Bake cake 20 mins");
        Console.WriteLine("Frost Cake"); 
    }
}

// interface is also implemented in class Pasta
public class Pasta : IFood
{
    public void Prepare()
    {
        Console.WriteLine("Boil pasta for 12 minutes");
        Console.WriteLine("Strain water and add sauce"); 
    }
}
```

C# doesn’t allow for multiple inheritances in classes but multiple interfaces are allowed. If interfaces are added to a class that’s also inheriting from a base class, the interfaces must follow the base class.

```c#
public class DeckOfCards : ABaseClass, IInterface, IAnotherInterface
{
  // Empty Class
}
```

## Iterators

[https://learn.microsoft.com/en-us/dotnet/csharp/iterators](https://learn.microsoft.com/en-us/dotnet/csharp/iterators)

An _iterator_ is an object that traverses a container, particularly lists. Iterators can be used for:

* Performing an action on each item in a collection.
* Enumerating a custom collection.
* Extending [LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq/) or other libraries.
* Creating a data pipeline where data flows efficiently through iterator methods.

The return type of an iterator can be [IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable), [IEnumerable&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1), [IAsyncEnumerable&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1), [IEnumerator](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator), or [IEnumerator&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1).

### The IEnumerable and IEnumerator

There are useful built-in interfaces, such as IEnumerable, IList, IDictionary, and IComparable. Adding the interface, IEnumerable, to a class means that it will iterate. The class must now also contain IEnumerator. In the example below, a class for a deck of cards is created and iterated over.
```c#
using System.Collections; 

DeckOfCards theDeck = new();

foreach (Card itemCard in theDeck)
{
  Console.WriteLine($"Card: {itemCard.Suit} {itemCard.Name} ({itemCard.Value})");
}

class Card
{ // Setup the properties of a playing card
  public string Name { get; set; } 
  public int Value { get; set; } 
  public string Suit { get; set; }

  public Card(string name, int value, string suit)
  {
    Name = name; 
    Value = value; 
    Suit = suit;
  } 
}

class DeckOfCards : IEnumerable // This class can now be iterated over to display a deck of cards
{
  private List<Card> deckList = new();

  public DeckOfCards()
  {
    deckList.Add(new Card("Two", 2, "Spade")); 
    deckList.Add(new Card("Three", 3, "Spade")); 
    deckList.Add(new Card("Four", 4, "Spade"));
  }

  // IEnumerator must be used, because DeckOfCards inherits IEnumerable
  public IEnumerator GetEnumerator()
  {
    return deckList.GetEnumerator();
  } 
}
```

### Iterator Methods: The `yield return` and `yield break`

Another great feature of the C# language enables you to build methods that create a source for an enumeration. These methods are referred to as** _iterator methods_**. An iterator method defines how to generate the objects in a sequence when requested. You use the `yield return` contextual keywords to define an iterator method.

The `yield return` and `yield break` are used when implementing an iterator (`IEnumerable`). The `yield return` statement returns the next element in the sequence, whereas `yield break` ends the iteration.
```c#
Console.WriteLine( "Output all numbers greater than 5, stop if number is 7");

List<int > MyNumbers = new() { 9, 4, 20, 3, 7, 12 };

foreach (int item in GreaterThan5StopIf7())
{ 
  Console.Write( $" {item} "); // Output: 9 20 
}

IEnumerable<int> GreaterThan5StopIf7() 
{ 
  foreach (int item in MyNumbers)
  { 
    if (item == 7)
    { 
      yield break; // End iteration
    }
    else if (item > 5)
    { 
      yield return item; // Return element and continue iteration
    }
  }
}
```

The compiler translates the `foreach` loop into something similar to this construct:
```c#
{
    var enumerator = collection.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            Console.WriteLine(item.ToString());
        }
    }
    finally
    {
        // dispose of enumerator.
  	  (enumerator as IDisposable)?.Dispose();
    }
}
```

### Async counterpart of above:
```c#
public async IAsyncEnumerable<int> GetSetsOfNumbersAsync()
{
    int index = 0;
    while (index < 10)
        yield return index++;

    await Task.Delay(500);

    yield return 50;

    await Task.Delay(500);

    index = 100;
    while (index < 110)
        yield return index++;
}

await foreach (var item in GetSetsOfNumbersAsync())
{
Console.WriteLine(item?.ToString());
}
```

## Data Structures - struct, record, List, LinkedList, Dictionary, Tuple

### What is a struct?

A `struct` is similar to a `class` and is useful for _lightweight objects_, such as a point, rectangle, or color. Lightweight objects can also be created with classes, but it’s often more memory efficient to use a `struct`. Unlike `classes`, `structs` are value types, not reference types.

A `struct` can be declared without using the `new` keyword. This is unique to `structs`, and wouldn’t work if it were a `class`. All value types (`int`, `char`, `bool`) are `structs`, which is why we can declare them without using the `new` keyword.

When you create a struct object using the new operator, it gets created and the <span style="text-decoration:underline;">appropriate constructor is called</span>. Unlike classes, structs can be instantiated without using the new operator. If you do not use new, the fields will remain unassigned and the object cannot be used until all of the fields are initialized.

```c#
With new()
TheLocation theLocation1 = new();
Console.WriteLine($"Location1: x = {theLocation1.X}, y = {theLocation1.Y}"); 
// Output: Location1: x = 0, y = 0
TheLocation theLocation2 = new(23, 6);
Console.WriteLine($"Location2: x = {theLocation2.X}, y = {theLocation2.Y}"); 
// Output: Location2: x = 23, y = 6

Without new()
TheLocation theLocation3;
theLocation3.X = 23;
theLocation3.Y = 6;
Console.WriteLine( $"Location1: x = {theLocation3.X} , y = {theLocation3.Y} ");

public struct TheLocation
{
    public int X;
    public int Y;

    public TheLocation(int point1, int point2)
    {
        X = point1;
        Y = point2; 
    }
}
```

**<span style="text-decoration:underline;">Limitations of Struct</span>**

1. Class is a reference type, whereas Struct is a value type.
2. A default constructor or destructor cannot be created in Struct.
3. Structs inherit from System.ValueType, cannot be inherited from another Struct or Class, and cannot be a base class.
4. Struct types cannot be abstract and are always sealed implicitly.
5. Struct members cannot be abstract, sealed, virtual, or protected.
6. Structs copy the entire value on the assignment, whereas reference types copy the reference on assignment. So, large reference type assignments are cheaper than the value types.
7. Instance field declarations in Struct cannot include variable initializers. But, static fields in Struct can include variable initializers.
8. A null value can be assigned to a struct as it can be used as a nullable type.
9. Structs are allocated either on the stack or inline in containing types and deallocated when the stack or the containing type gets deallocated. But, reference types are allocated on the heap and garbage-collected. So, the allocation and deallocation of structs are cheaper than classes.

### What is a record?

A **record (C# 9)** is a reference type that makes it easier to create _immutable reference types_ and provides _equality comparisons_. C# 10 introduces **<span style="text-decoration:underline;">record struct</span>** types too.

It’s important to point out that, when records are created in the above manner, they’re immutable, meaning that they cannot be changed. This can be seen in the following code: \
`Student student1 = new("Pablo", "Exam 1", 97);`
```c#
student1.Grade = 98; // Error because the value can not be changed
Console.WriteLine(student1);

public record Student(string Name, string Assignment, int Grade);
```

#### The with keyword
```c#
The with keyword can be used to create a copy of a record and change its properties as needed.
Student student1 = new("Pablo", "Exam 1", 97);
Console.WriteLine(student1);

Student student2 = student1 with { Grade = 98 };
// All the original properties of student1 are copied to student2, only Grade is changed
Console.WriteLine(student2);

public record Student(string Name, string Assignment, int Grade);
```

#### Deconstruct

Records can also use the **deconstruct** method to separate the record into component properties.
```c#
Student student1 = new("Pablo", "Exam 1", 97);
Console.WriteLine(student1);

var (studentName, studentAssignment, studentGrade) = student1; // Deconstruct 
Console.WriteLine(studentName); // Output: Pable
Console.WriteLine(studentAssignment); // Output: Exam 1
Console.WriteLine(studentGrade); // Output: 97

public record Student(string Name, string Assignment, int Grade);
```

A method can be added to the `record` class. These methods are similar to class methods and are called with `record` objects. Records can _inherit_ from other records too.
```c#
Student student1 = new("Pablo", "Exam 1", 97);        
student1.DisplayMessage(); // Output: Hello

public record Student(string Name, string Assignment, int Grade)
{
    public void DisplayMessage()
    {
        Console.WriteLine("Hello");
    }
}
```

### What is a `list`? (part of `using System.Collections.Generic)`

**Lists** and arrays are similar in that they both hold items. Lists can easily _search_, _sort_, _add_, and _remove_ items because of built-in functionalities. Lists can constantly be changed to include or disclude additional items, unlike an array that has a set number of items.

A `List` uses an internal array to handle its data, and automatically resizes the array when adding more elements to the `List` than its current capacity, which makes it more easy to use than an array, where you need to know the capacity beforehand.

Methods: Add, Remove, Insert, RemoveAt, Sort, Clear, ToArray
```c#
List<string> foods = new(); 
foods.Add("Pizza"); 
foods.Add("Burger");

Console.WriteLine(foods[0]); // Output: Pizza
Console.WriteLine(foods[1]); // Output: Burger

List<int> evenNumbers = new() {2, 4, 6, 8, 10};
Console.WriteLine(evenNumbers[2]); // Output: 6
// looping through a list
foreach(var number in evenNumbers)
{
   Console.WriteLine(number);
}

string[] foodsArray = foods.ToArray();
```

### What’s a `LinkedList`?

A **LinkedList** is generally slower than a regular list, but it can be beneficial when adding or removing items in the middle of a `list`. As with lists, a `LinkedList` uses _generics_. It is a doubly LL so Next and Previous are supported. Other important properties are Count(), First, Last. Key methods are AddFirst, AddLast, AddBefore, AddAfter, Contains, Find, Remove, RemoveFirst, RemoveLast. Every node in a LinkedList&lt;T> object is of the type LinkedListNode&lt;T>
```c#
        // Using LinkedList class
        LinkedList<String> my_list = new LinkedList<String>();


        // Adding elements in the LinkedList
        // Using AddLast() method
        my_list.AddLast("Zoya");
        my_list.AddLast("Shilpa");
```

### What is a `dictionary`?

A **dictionary** consists of a _key_ and a _value_. In an array, the key is created automatically (0, 1, and so on). With dictionaries, the key name can be set to something meaningful. As with lists, **dictionaries** use _generics_
```c#
Dictionary <string , int> myInventory = new(); 
myInventory.Add( "Pens", 7); 
myInventory.Add( "Computers", 2);

Console.WriteLine($"myInventory[\"Pens\"]: {myInventory["Pens"]}");
// Output: myInventory["Pens"]: 7
Console.WriteLine($"myInventory[\"Computers\"]: {myInventory["Computers"]}");
// Output: myInventory["Computers"]: 2

// Instantiate and assign items to a dictionary
Dictionary <int , string > dayNames = new()
{ 
    { 1, "Monday" },
    { 2, "Tuesday" },
    { 3, "Wednesday" },
    { 4, "Thursday" },
    { 5, "Friday" },
    { 6, "Saturday" },
    { 7, "Sunday" }
};

Console.WriteLine($"dayNames[3]: {dayNames[3]}");
// Output: dayNames[3]: Wednesday
foreach (KeyValuePair<string, int> theItem in myInventory)
{
   Console.WriteLine($"{theItem.Key}: quantity {theItem.Value} ");
}
```

### What is a `tuple`?

A `Tuple` can be thought of much like an array, but a `Tuple` collection can contain different data types. Classes of the `Tuple` type are _generic containers_ and can hold `1`-`8` items.
```c#
// Instantiate a 3-Item Tuple: Int, String, and an Array of Ints
Tuple<int,string,int[]> myTuple = Tuple.Create(101, "Hello", new int[] { 41, 52 });

// Access a Tuple item 
Console.WriteLine(myTuple.Item1); // Output: 101 
Console.WriteLine(myTuple.Item2); // Output: Hello

foreach (int theNumber in myTuple.Item3)
{ 
    Console.Write( $"{theNumber} "); // Output: 41 52
}
```

We can use a `Tuple` as the return type in a method. The following example returns a `Tuple`.
```c#
int num1 = 10;
int num2 = 4;

Tuple <int , int > answer = DivideGetQuotientAndRemainder(num1, num2);
Console.WriteLine( $"{num1} / {num2} = {answer.Item1} , with remainder of {answer.Item2} "); 
// Output: 10 / 4 = 2, with remainder of 2

static Tuple <int , int> DivideGetQuotientAndRemainder(int dividend, int divisor) 
{ 
  int quotient = dividend / divisor;
  int remainder = dividend % divisor; // Uses the modulus operator (%) to get remainder 
  return Tuple.Create(quotient, remainder);
}
```

Sometimes, you want your method to return more than a single value. You can do this easily by using _tuple types_ and _tuple literals_.
```c#
public (string, string, string, int) GetPersonalInfo(string id)
{
    PersonInfo per = PersonInfo.RetrieveInfoById(id);
    return (per.FirstName, per.MiddleName, per.LastName, per.Age);
}
```

The caller can then consume the returned tuple with code like the following:
```c#
var person = GetPersonalInfo("111111111");
Console.WriteLine($"{person.Item1} {person.Item3}: age = {person.Item4}");
```

Names can also be assigned to the tuple elements in the tuple type definition. The following example shows an alternate version of the `GetPersonalInfo` method that uses named elements:

```c#
public (string FName, string MName, string LName, int Age) GetPersonalInfo(string id)
{
    PersonInfo per = PersonInfo.RetrieveInfoById(id);
    return (per.FirstName, per.MiddleName, per.LastName, per.Age);
}
```

The previous call to the `GetPersonalInfo` method can then be modified as follows:
```c#
var person = GetPersonalInfo("111111111");
Console.WriteLine($"{person.FName} {person.LName}: age = {person.Age}");

(double, int) t1 = (4.5, 3);
Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");
// Output:
// Tuple with elements 4.5 and 3.

(double Sum, int Count) t2 = (4.5, 3);
Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
// Output:
// Sum of 3 elements is 4.5.

var t =
(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
11, 12, 13, 14, 15, 16, 17, 18,
19, 20, 21, 22, 23, 24, 25, 26);
Console.WriteLine(t.Item26);  // output: 26

//tuple field names
var t = (Sum: 4.5, Count: 3);
Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

(double Sum, int Count) d = (4.5, 3);
Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");

//Tuples as Out params
var limitsLookup = new Dictionary<int, (int Min, int Max)>()
{
    [2] = (4, 10),
    [4] = (10, 20),
    [6] = (0, 23)
};

if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
{
    Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
}
// Output:
// Found limits: min is 10, max is 20
```

#### Tuples vs System.Tuple

C# tuples, which are backed by [System.ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple) types, are different from tuples that are represented by [System.Tuple](https://learn.microsoft.com/en-us/dotnet/api/system.tuple) types. The main differences are as follows:

* `System.ValueTuple` types are [value types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types). `System.Tuple` types are [reference types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types).
* `System.ValueTuple` types are mutable. `System.Tuple` types are immutable.
* Data members of `System.ValueTuple` types are fields. Data members of `System.Tuple` types are properties.

## Boxing and Unboxing Types

Boxing and unboxing degrade the performance. So, avoid using it. Use generics to avoid boxing and unboxing. For example, use List instead of ArrayList.

Boxing and unboxing are the processes that enable value types (such as, integers) to be treated as reference types (objects). The value is "boxed" inside an `Object` and subsequently "unboxed" back to a value type. Basically moving from stack to heap (boxing) and vice versa (unboxing)

Boxing is an implicit conversion of a value type to the type `Object`. Boxing a value allocates an instance of `Object` and copies the value into the new object instance.

<p id="gdcalert1" ><span style="color: red; font-weight: bold">>>>>>  gd2md-html alert: inline image link here (to images/image1.png). Store image on your image server and adjust path/filename/extension if necessary. </span><br>(<a href="#">Back to top</a>)(<a href="#gdcalert2">Next alert</a>)<br><span style="color: red; font-weight: bold">>>>>> </span></p>

![alt_text](images/image1.png "image_tooltip")

Boxing is implicit when you provide a value type where a reference is expected. The runtime notices that you've provided a value type and silently boxes it within an object. You can, of course, first cast the value type to a reference type, as in the following:
```c#
int myIntegerValue = 5;
object myObject = myIntegerValue; // cast to an object //boxing
myObject.ToString();
int c = (int)myObject; //unboxing
```

### Unboxing Must Be Explicit

To return the boxed object back to a value type, you must explicitly unbox it. For the unboxing to succeed, the object being unboxed must really be of the type you indicate when you unbox it. A boxing conversion makes a copy of the value. So, changing the value of one variable will not impact others.

You should accomplish unboxing in two steps:

1. Make sure the object instance is a boxed value of the given value type.
2. Copy the value from the instance to the value-type variable.

### Example of boxing and unboxing
```c#
using System;
public class UnboxingTest
{
public static void Main( )
{
int myIntegerVariable = 123;

//Boxing
object myObjectVariable = myIntegerVariable;
Console.WriteLine( "myObjectVariable: {0}",
myObjectVariable.ToString( ) );

// unboxing (must be explicit)
int anotherIntegerVariable = (int)myObjectVariable;
Console.WriteLine( "anotherIntegerVariable: {0}",
anotherIntegerVariable );
}
}
```

Output:
myObjectVariable: 123
anotherIntegerVariable: 123

## What is a Thread?
Threads let us run multiple sections of code simultaneously. Threading allows the code to run on multiple processors, boosting performance.

### Thread with a join
```c#
Thread aThread = new Thread(CountTo200); 
Thread bThread = new Thread(CountTo200); 

aThread.Start();
aThread.Join(); // Wait until aThread is finished 

bThread.Start();
bThread.Join(); // Wait until bThread is finished 

static void CountTo200()
{ 
    for (int i = 1; i <= 200; i++)
    { 
        Console.WriteLine(i); 
    }
}
```

### Thread with one parameter
```c#
Thread aThread = new Thread(CountTo);
aThread.Start(45); // 1 parameter 

static void CountTo(object count)
{ 
    for (int i = 1; i <= (int) count; i++)
    { 
        Console.WriteLine(i); 
    }
}
```

## What's asynchronous programming? using System.Threading.Tasks;
[https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)

Asynchronous programming enhances the responsiveness of applications by using non-blocking operations to prevent bottlenecks that could slow down or freeze an application. The two main components of asynchronous programming are the keyword modifiers, async and await.
A method using the async modifier enables the use of the await operator, which now must be included at least once within the method. The original caller method continues when the await operator is reached, and the async method processes until it's completed.
The async methods must have a return type of void, Task, Task<T>, or any other type that has a GetAwaiter method. The naming convention for async methods is to append them with an async suffix.

### The async void method
In the example below, the method, FirstMethodAsync(), contains a delay that would generally freeze a program for 3 seconds. Because this is an async method, the original caller of the method continues and the async method keeps processing when await is reached.
```c#
FirstMethodAsync();

Console.WriteLine( "System is not Frozen"); 

Console.ReadLine();

static async void FirstMethodAsync()
{ 
    Console.WriteLine( "Task Started");
    await Task.Delay(3000); // Delays the method for 3 seconds
    Console.WriteLine( "Task Finished");
}

// Output: 
// Task Started
// System is not Frozen
// Task Finished
```

### The `async Task` method

The `async` methods can return with `void` as demonstrated previously. They generally return with `Task` or `Task&lt;T Result>`,however, which encapsulates information. A `Task` is used if there is no return statement, and `Task&lt;T Result>` is used if there’s a return statement.
```c++
FirstMethodAsync();
Console.WriteLine( "System is not Frozen"); 

Console.ReadLine();

static async void FirstMethodAsync()
{ 

    Console.WriteLine( "Task Started"); 
    await SecondMethodAsync();
    Console.WriteLine( "First Task Finished"); 
}

static async Task SecondMethodAsync()
{ 
    await Task.Delay(3000); // Delays the method for 3 seconds 
    Console.WriteLine( "Second Task Finished");
}

// Output: Task Started
// System is not Frozen 
// Second Task Finished 
// First Task Finished
```

### The `async Task &lt;T Result>` method

FirstMethodAsync(); 

Console.WriteLine("System is not Frozen"); 

Console.ReadLine();

static async void FirstMethodAsync()

{

    Console.WriteLine("Task Started"); 

    Console.WriteLine(await SecondMethodAsync()); 

    Console.WriteLine("First Task Finished");

}

static async Task&lt;**string**> SecondMethodAsync()

{

    await Task.Delay(3000); // Delays the method for 3 seconds

    return ("Second Task Finished");

}

// Output:

// Task Started

// System is not Frozen

// Second Task Finished

// First Task Finished

**Operator overloading**

The `Object` class (which is the root of every class in C#) offers a virtual method called `Equals( )`. If you overload the equals operator (`==`), it is recommended that you also override the `Equals( )` method.

Overriding the `Equals( )` method allows your class to be compatible with other .NET languages that do not overload operators (but do support method overloading).


## Attributes

Every .NET application contains code, data, and metadata. Attributes are objects that are embedded in your program (invisible at run time) that contain metadata that is, data about your classes and about your program. Attributes can be made visible with ILDasm the tool for looking at the Microsoft Intermediate Language (MSIL) that the C# compiler produces.

The `is` operator lets you query whether an object implements an interface (or derives from a base class). The form of the `is` operator is:


```
if ( myObject is ICompressible )
```


The `as` operator tries to cast the object to the type, and if an exception would be thrown, it instead returns null:


```
ICompressible myCompressible = myObject as ICompressible
if ( myCompressible != null )
```



## Explicit Interface Implementation

Because both `IStorable` and `ITalk` have a `Read( )` method, the implementing `Document` class must use explicit implementation for at least one of the methods. With explicit implementation, the implementing class (`Document`) explicitly identifies the interface for the method:


```
void ITalk.Read( )
```


Marking the `Read( )` method as a member of the `ITalk` interface resolves the conflict between the identical `Read( )` methods. There are some additional aspects you should keep in mind.

First, the explicit implementation method cannot have an access modifier:


```
void ITalk.Read( )
```


This method is implicitly public. In fact, a method declared through explicit implementation cannot be declared with the `abstract`, `virtual`, `override`, or `new` keywords.

Most importantly, you cannot access the explicitly implemented method through the object itself. When you write:


```
theDoc.Read( );
```


the compiler assumes you mean the implicitly implemented interface for `IStorable`. The only way to access an explicitly implemented interface is through a cast to the interface:


```
ITalk itDoc = theDoc as ITalk;
if (itDoc != null)
{
itDoc.Read( );
}
```



## Collection Interfaces

The .NET Framework provides a number of interfaces , such as `IEnumerable` and `ICollection`, that the designer of a collection must implement to provide full collection semantics. For example, `ICollection` allows your collection to be enumerated in a `foreach` loop.

An indexer is a C# construct that allows you to treat a class as if it were an array. In the preceding example, you are treating the `ListBox` as if it were an array of strings, even though it is more than that. An indexer is a special kind of property, but like all properties, it includes `get` and `set` accessors to specify its behavior.

You declare an indexer property within a class using the following syntax:


```
type this [type argument ]{get; set;}
```


**eg:**


```
namespace SimpleIndexer
{
// a simplified ListBox control
public class ListBoxTest
{
```



<p id="gdcalert2" ><span style="color: red; font-weight: bold">>>>>>  gd2md-html alert: Definition &darr;&darr; outside of definition list. Missing preceding term(s)? </span><br>(<a href="#">Back to top</a>)(<a href="#gdcalert3">Next alert</a>)<br><span style="color: red; font-weight: bold">>>>>> </span></p>


**::**


<p id="gdcalert3" ><span style="color: red; font-weight: bold">>>>>>  gd2md-html alert: Definition &darr;&darr; outside of definition list. Missing preceding term(s)? </span><br>(<a href="#">Back to top</a>)(<a href="#gdcalert4">Next alert</a>)<br><span style="color: red; font-weight: bold">>>>>> </span></p>


**::**


```
public string this[int index]
{
    get
    {
        if ( index < 0 || index >= strings.Length )
        {
        // handle bad index
        }
        return strings[index];
    }
    set
    {
        // add only through the add method
        if ( index >= ctr )
        {
        // handle error
        }
        Else {
        strings[index] = value;
        }
    }
```


**}**


```
public class Tester
{
static void Main( )
{
// create a new list box and initialize
ListBoxTest lbt =
new ListBoxTest( "Hello", "World" );

// add a few strings
lbt.Add( "Proust" );
lbt.Add( "Faulkner" );
lbt.Add( "Mann" );
lbt.Add( "Hugo" );

// test the access
string subst = "Universe";
lbt[1] = subst;

// access all the strings
for ( int i = 0; i < lbt.GetNumEntries( ); i++ )
{
Console.WriteLine( "lbt[{0}]: {1}", i, lbt[i] );
}
}
}


<table>
  <tr>
   <td>```


<h3>Generic collection interfaces</h3>


   </td>
   <td>
   </td>
  </tr>
  <tr>
   <td><strong>Interface</strong>
   </td>
   <td><strong>Purpose</strong>
   </td>
  </tr>
  <tr>
   <td><code>ICollection&lt;T></code>
   </td>
   <td>Base interface for generic collections
   </td>
  </tr>
  <tr>
   <td><code>IEnumerator&lt;T></code>
<p>
<code>IEnumerable&lt;T></code>
   </td>
   <td>Required for collections that will be enumerated with foreach
   </td>
  </tr>
  <tr>
   <td><code>IComparer&lt;T></code>
<p>
<code>IComparable&lt;T></code>
   </td>
   <td>Required for collections that will be sorted
   </td>
  </tr>
  <tr>
   <td><code>IList&lt;T></code>
   </td>
   <td>Used by indexable collections (see the section "<span style="text-decoration:underline;">Generic Lists: List&lt;T></span>")
   </td>
  </tr>
  <tr>
   <td><code>IDictionary&lt;K,V></code>
   </td>
   <td>Used for key/value-based collections (see the section "<span style="text-decoration:underline;">Dictionaries</span>")
   </td>
  </tr>
</table>



#### Dictionaries

A dictionary is a collection that associates a key to a value. A language dictionary, such as Webster's, associates a word (the key) with its definition (the value)

A .NET Framework dictionary can associate any kind of key (string, integer, object) with any kind of value (string, integer, object). Typically, the key is fairly short and the value fairly complex, though in this case, we'll use short strings for both.

The most important attributes of a good dictionary are that it is easy to add values and it is quick to retrieve values.


### Creating Strings

C# treats strings as if they were built-in types (much as it does with arrays). C# strings are flexible, powerful, and easy to use.

In .NET, each string object is an immutable sequence of Unicode characters. In other words, methods that appear to change the string actually return a modified copy; the original string remains intact (and if no longer used, is collected by the Garbage Collector).

The declaration of the `System.String` class is (in part):


```
public sealed class String :
IComparable, ICloneable, IConvertible, IEnumerable
```


This declaration reveals that the class is `sealed`, meaning that it is not possible to derive from the `String` class. The class also implements four system interfaces`IComparable`, `ICloneable`, `IConvertible`, and `IEnumerable`which dictate functionality that `System.String` shares with other classes in the .NET Framework: the ability to be sorted, copied, converted to other types, and enumerated in `foreach` loops, respectively.


#### The StringBuilder Class

You can use the `System.Text.StringBuilder` class for creating and modifying strings. Unlike `String`, `StringBuilder` is mutable; when you modify an instance of the `StringBuilder` class, you modify the actual string, not a copy.


### The Regex Class

The .NET Framework provides an object-oriented approach to regular expression pattern matching and replacement.


## Throwing Exceptions

[https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements)

All exceptions are either of type `System.Exception` or of types derived from `System.Exception`. Microsoft suggests that all the exceptions you use in your program derive from `System.Exception`, though you are also free to derive from `System.ApplicationException` (which was the previous recommended strategy).

The CLR System namespace includes a number of pre-defined exception types that you can use in your own programs. These exception types include `ArgumentNullException`, `InvalidCastException`, and `OverflowException`, as well as many others. You can guess their use based on their name. For example, `ArgumentNull` exception is thrown when an argument to a method is null when that is not an expected (or acceptable) value.


### The throw Statement

To signal an abnormal condition in a C# program, throw an exception by using the `tHRow` keyword. The following line of code creates a new instance of `System.Exception` and then throws it:


```
throw new System.Exception( );
```



### The finally Statement

In some instances, throwing an exception and unwinding the stack can create a problem. For example, if you opened a file or otherwise committed a resource, you might need an opportunity to close the file or flush the buffer.

If there is some action you must take regardless of whether an exception is thrown, such as closing a file, you have two strategies to choose from. One approach is to enclose the dangerous action in a `try` block and then to perform the necessary action (close the file) in both the `catch` and `TRy` blocks. However, this is an ugly duplication of code, and it's error prone. C# provides a better alternative in the `finally` block.

A `finally` block can be created with or without `catch` blocks, but a `finally` block requires a `try` block to execute. It is an error to exit a `finally` block with `break`, `continue`, `return`, or `goto`.

The `System.Exception` class provides a number of useful methods and properties.

The `Message` property provides information about the exception, such as why it was thrown. The `Message` property is read-only; the code throwing the exception can pass in the message as an argument to the exception constructor, but the `Message` property cannot be modified by any method once set in the constructor.

The `HelpLink` property provides a link to a help file associated with the exception. This property is read/write.

The read-only `StackTrace` property is set by the CLR. This property is used to provide a stack trace for the error statement.


### How to catch a non-CLS exception?

Within a `catch(RuntimeWrappedException e)` block, access the original exception through the [RuntimeWrappedException.WrappedException](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimewrappedexception.wrappedexception) property.


```
// Class library written in C++/CLI.
var myClass = new ThrowNonCLS.Class1();
try
{
    // throws gcnew System::String(  
    // "I do not derive from System.Exception!");  
    myClass.TestThrow();
}
catch (RuntimeWrappedException e)
{
    String s = e.WrappedException as String;
    if (s != null)
    {
        Console.WriteLine(s);
    }
}

using System;
class Program{
  public static void Main(){
    double num = 0;
    try{
      num = Convert.ToDouble("63.5-4");
    }
    catch (Exception){
      Console.WriteLine("Another Exception");
      throw;  // rethrowing
    }
    catch (FormatException){
      Console.WriteLine("We encountered a FormatException");
    }

    Console.WriteLine(num);
  }
}
```


The above code will cause a compilation error: `main.cs(15,5): error CS0160: A previous catch clause already catches all exceptions of this or a super type `System.Exception'`


#### The partial Keyword

Your code file (_Form1.cs_) has only the `using directives` and the constructor and event handler. If you have experience with previous versions of C#, you may be wondering where the code to initialize the controls is hiding. The class definition contains the keyword `partial`. This indicates that the rest of the class definition is contained in another file. If you click the Show All Files button at the top of the Solution Explorer (as shown in <span style="text-decoration:underline;">Figure 18-7</span>), you will see that the designer has revealed another file, _Form1.Designer.cs_, that contains the boiler-plate code and the initialization for all the controls.

**Programming ASP.NET Applications**

The .NET technology for building web applications (and dynamic web sites) is ASP. NET 2.0, which provides a rich collection of types for building web applications in its `System.Web` and `System.Web.UI` namespaces. There is a great deal to learn about ASP.NET, but much of it is language-independent. ASP.NET offers a rich suite of controls and related tools, including tools to validate data, display dates, present advertisements, interact with users, and so forth. Most of these require no coding whatsoever.

The role of the C# programmer in ASP.NET development is to write the event handlers that respond to user interaction. Many of the event handlers will either add data to a database or retrieve data and make it available to the controls.

Web Forms divide the user interface into two parts: the visual part or user interface (UI), and the logic that lies behind it. This is very similar to developing Windows Forms. This is called _code separation_ ; all examples in this book use code separation, though it is possible to write the C# code in the same file with the user interface.

The UI page is stored in a file with the extension ._aspx_. When you run the form, the server generates HTML sent to the client browser. This code uses the rich Web Forms types found in the `System.Web` and `System.Web.UI` namespaces of the .NET Framework Class Library (FCL ).

Web Forms are event-driven. An _event_ represents the idea that "something happened." An event is generated (or _raised_) when the user clicks a button, or selects from a `ListBox`, or otherwise interacts with the UI. Events can also be generated by the system starting or finishing work. For example, open a file for reading, and the system raises an event when the file has been read into memory.

By convention, ASP.NET event handlers return `void` and take two parameters. The first parameter represents the object raising the event. The second, called the _event argument_, contains information specific to the event, if any. For most events, the event argument is of type `EventArgs`, which has no members and serves as a placeholder and as the base class for more specialized objects that provide properties needed by the event handler.


#### State

The web does not maintain state. By design, it is a stateless environment. That means that the server would normally have no idea that a second post from a given user has any association with previous posts by that same user. That is fine if all you have are one or two pages that are information only, with no interaction, but it is obviously limiting if you want to create an interactive application.

ASP.NET solves this problem by maintaining three types of state: view state, session state, and application state:

View state


    Maintains the value of controls (what you've filled into text boxes, which choices you've made in lists) when you post a page to the server. There was a time you had to write code to do this, but it is now done for you in an efficient and reliable manner.

Session state


    Creates an artificial "connection" with the application, simulating the idea of an ongoing session for an individual user within a single application. This is so natural, you hardly notice it. You go to a site, and as you interact with it, remembers your input and responds accordingly, just like working with a desktop application. Sessions typically end by "timing out" after about 20 minutes of inactivity; but in most cases, this is invisible to the user.

Application state


    Preserves values across users within a given web application. Application state is beyond the scope of this chapter.


#### Code-Behind Files

Code-behind is the default coding model used by Visual Studio 2005. When a new web site is created, Visual Studio automatically creates two files: the content file, with a default name, such as _Default.aspx_, and a code-behind file with a matching name, such as _Default.aspx.cs_ (assuming you are using C# as your programming language). If you change the name of the content file (highly recommended), the code-behind file will automatically assume the new name.

**Protecting Code by Using the Monitor Class**

The System.Monitor class enables you to serialize the access to blocks of code by means of locks and signals.


```
using System;
using System.Threading;

class Database
{
    public void SaveData(string text)
    {
```



        `Console.WriteLine("[SaveData] Started");`


        `try`


        `{`


            `Monitor.Enter(this);`


            `Console.WriteLine("[SaveData] Working");`


            `throw new Exception("ERROR!");`


            `for (int i = 0; i &lt; 50; i++)`


            `{`


                `Thread.Sleep(100);`


                `Console.Write(text);`


            `}`


        `}`


        `finally`


        `{`


            `Monitor.Exit(this);`


        `}`


        `Console.WriteLine("\n[SaveData] Ended");`


    }

}


```
class ThreadMonitor3App
{
```


    `public static Database db = new Database();`

    `public static void WorkerThreadMethod1()`

    `{`

        `Console.WriteLine("[WorkerThreadMethod1] Started");`

        `Console.WriteLine("[WorkerThreadMethod1] " +`

            `"Calling Database.SaveData");`

        `try`

        `{`

            `db.SaveData("x");`

        `}`

        `catch{}`

        `Console.WriteLine("[WorkerThreadMethod1] Finished");`

    `}`

    `public static void WorkerThreadMethod2()`

    `{`

        `Console.WriteLine("[WorkerThreadMethod2] Started");`

        `Console.WriteLine("[WorkerThreadMethod2] " +`

            `"Calling Database.SaveData");`

        `try`

        `{`

            `db.SaveData("o");`

        `}`

        `catch{}`

        `Console.WriteLine("[WorkerThreadMethod2] Finished");`

    `}`

    `public static void Main()`

    `{`

        `ThreadStart worker1 =`

            `new ThreadStart(WorkerThreadMethod1);`

        `ThreadStart worker2 =`

            `new ThreadStart(WorkerThreadMethod2);`

        `Console.WriteLine("[Main] Creating and starting " +`

            `"worker threads");`

        `Thread t1 = new Thread(worker1);`

        `Thread t2 = new Thread(worker2);`

        `t1.Start();`

        `t2.Start();`

        `Console.ReadLine();`

    `}`

}

If you’re going to use the Monitor class, you must be sure to place the Monitor.Exit call in a finally block. Otherwise, you might hang up other threads upon an exception being caught.

**Using Monitor Locks with the C# lock Statement**

To use the lock statement, simply specify the statement with the code being serialized in braces. The braces indicate the starting point and the stopping point of the code being protected, so there’s no need for an unlock statement.


```
class Database
{
```


    `public void SaveData(string text)`

    `{`

        `lock(this)`

        `{`

            `Console.WriteLine("Database.SaveData - Started");`

            `Console.WriteLine("Database.SaveData - Working");`

            `for (int i = 0; i &lt; 100; i++)`

            `{`

                `Console.Write(text);`

            `}`

            `Console.WriteLine("\nDatabase.SaveData - Ended");`

        `}`

    `}`


```
}
```


The generated Microsoft intermediate language (MSIL), is what’s interesting here. The first thing to look at is the fact that the lock statement actually does generate code to use the Monitor class. The second item of note is that the lock statement resulted in a try..finally block being inserted into our code, preventing us from hanging the system when a Monitor object is left locked.

**Synchronizing Code by Using the Mutex Class**

The Mutex class—defined in the System.Threading namespace—is a run-time representation of the Win32 system primitive of the same name. You can use a mutex to serialize access to code just as you’d use a monitor lock, but mutexes are much slower because of their increased flexibility.

You can create a mutex in C# with the following three constructors:


```
Mutex( )
Mutex(bool initiallyOwned)
Mutex(bool initiallyOwned, string mutexName)
```


The first constructor creates a mutex with no name and makes the current thread the owner of that mutex. Therefore, the current thread locks the mutex. The second constructor takes only a Boolean flag that designates whether the thread creating the mutex wants to own it (lock it). And the third constructor allows you to specify whether the current thread owns the mutex as well as allowing you to specify the name of the mutex.


```
using System;
using System.Threading;

class Database
{
```


    `static Mutex mutex = new Mutex(false);`

    `public static void SaveData(string text)`

    `{`

        `mutex.WaitOne();`

        `Console.WriteLine("Database.SaveData - Started");`

        `Console.WriteLine("Database.SaveData - Working");`

        `for (int i = 0; i &lt; 100; i++)`

        `{`

            `Console.Write(text);`

        `}`

        `Console.WriteLine("\nDatabase.SaveData - Ended");`

        `mutex.Close();`

    `}`


```
}
```


Now the Database class defines a Mutex field. We don’t want the thread to own the mutex just yet because we’d have no way of getting into the SaveData method.

The WaitOne method is also overloaded to provide more flexibility in terms of allowing you to define how much time the thread will wait for the mutex to become available. Here are the overloads:


```
WaitOne( )
WaitOne(TimeSpan time, bool exitContext)
WaitOne(int milliseconds, bool exitContext)
```


The basic difference between these overloads is that the first version—used in the example—will wait indefinitely, while the second and third versions will wait for the specified amount of time, expressed with either a TimeSpan value or an int value.


## What is a `delegate`?[#](https://www.educative.io/courses/programming-fundamentals-csharp-dotnet/gkz9V1vPzmj#What-is-a-delegate?)

[https://learn.microsoft.com/en-us/dotnet/csharp/delegates-overview](https://learn.microsoft.com/en-us/dotnet/csharp/delegates-overview)

A `delegate` is a variable that can store a method and can then be passed around as needed.


```
public delegate string MathExample(int num1, int num2);
int number1 = 3;
int number2 = 7;

MathExample calculateMath = AddNumbers; // Store method AddNumbers
Console.WriteLine(calculateMath(number1, number2)); // Output: 3 + 7

static string AddNumbers(int a, int b)
{
    return $"{a} + {b} = {a + b}";
}



##     What is an event?
```


[https://learn.microsoft.com/en-us/dotnet/csharp/events-overview](https://learn.microsoft.com/en-us/dotnet/csharp/events-overview)


```
Events allow classes to notify other classes when something occurs. One example is when a button is pressed and another class is listening to handle that event. An event needs to be defined inside a class. Using the event keyword enables others to attach to this event. Specify the delegate type for the type of methods that can be attached to the event. In the example below, a predefined delegate called EventHandler is used. The EventHandler delegate returns void and has two parameters (object, EventArgs). The object is the sender (what sent the event) and the EventArgs object(contains basic information about the event).
Greetings welcomeMessage = new();

// Attach event handler to event
welcomeMessage.WelcomeChanged += welcomeMessage.HandleWelcomeChanged; 

welcomeMessage.TheMessage = "Adam";
Console.WriteLine(welcomeMessage.TheMessage);

class Greetings
{
    private string theMessage; 
    public string TheMessage 
    {
        get
        {
            return theMessage;
        }
        set
        {
            theMessage= $"Hello, {value}";
            OnWelcomeChanged(); // Call OnWelcomeChanged when the value is changed }
        }
    }

    public event EventHandler WelcomeChanged; // Define the event
    //Public delegate void EventHandler(object, EventArgs);
    // EventHandler is a predefined delegate that returns void and has 2 parameters. 
    // The first parameter is an object and the second is an EventArgs object

    public void OnWelcomeChanged() // Methods that raise events usually start with the "On"
    {
        // The code below raises the event if the event is not null (verifies an event handler 
        // is attached to the event)
        WelcomeChanged?.Invoke(this, EventArgs.Empty);
    }

    // This method handles what to do when the change is detected
    public void HandleWelcomeChanged(object sender, EventArgs eventArgs)
    {
        Console.WriteLine("The welcome message has changed!!");
    } 
}
```



### Delegate vs Event


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
  <tr>
   <td>Delegate includes Combine() and Remove() methods to add methods to the invocation list.
   </td>
   <td><a href="https://docs.microsoft.com/en-us/dotnet/api/system.reflection.eventinfo?view=netframework-4.8">EventInfo</a> class inspect events and to hook up event handlers that include methods AddEventHandler() and RemoveEventHandler() methods to add and remove methods to invocation list, respectively.
   </td>
  </tr>
  <tr>
   <td>A delegate can be passed as a method parameter.
   </td>
   <td><strong>An event is raised but cannot be passed as a method parameter.</strong>
   </td>
  </tr>
  <tr>
   <td>= operator is used to assigning a single method, and += operator is used to assign multiple methods to a delegate.
   </td>
   <td>= operator cannot be used with events, and only += and -= operator can be used with an event that adds or remove event handler. These methods internally call AddEventHandler and RemoveEventHandler methods.
   </td>
  </tr>
</table>


In a way, an event is a delegate only. The program code will work even if you remove the event keyword and only use a delegate. However, using the event keyword, we prevent subscribers to register with an event by using = operator and thereby removing all handlers.


```
public delegate void Notify(); 
public Notify MyDelegate; 
MyDelegate = MyMethod;// valid 
MyDelegate += MyMethod;// valid 
public delegate void Notify(); 
public event Notify MyEvent; 
MyEvent = MyEventHandler;// Error 
MyEvent += MyEventHandler;// valid
```



## Using Delegates as Callback Methods

Used extensively in programming for Microsoft Windows, callback methods enable you to pass a function pointer to another function that will then call you back (via the passed pointer). For example, the Win32 API EnumWindows function enumerates all the top-level windows on the screen, calling the supplied function for each window. Callbacks serve many purposes, but the following are the most common:



* Asynchronous processing

    Callback methods are used in asynchronous processing when the code being called will take a good deal of time to process the request. Typically, the scenario works like this: Client code makes a call to a method, passing to it the callback method. The method being called starts a thread and returns immediately. The thread then does the majority of the work, calling the callback function as needed. This has the obvious benefit of allowing the client to continue processing without being blocked on a potentially lengthy synchronous call.

* Injecting custom code into a class’s code path

    Callback methods are also commonly used when a class allows the client to specify a method that will be called to perform custom processing. For example a callback method for custom sorting


Now let’s look at an example of defining and using a delegate. In this example, we have a database manager class that keeps track of all active connections to the database and provides a method for enumerating those connections. Assuming that the database manager is on a remote server, it might be a good design decision to make the method asynchronous and allow the client to provide a callback method. Note that for a real-world application, you’d typically create this as a multithreaded application to make it truly asynchronous. However, to keep the example simple—and because we haven’t covered multithreading yet—let’s leave multithreading out.

To get started, let’s see how you would define a delegate in the class that’s publishing the callback:


```
class DBManager
{
```


    `static DBConnection[] activeConnections;`

    `public delegate void EnumConnectionsCallback(`

        `DBConnection connection);`

    `public static void EnumConnections(`

        `EnumConnectionsCallback callback)`

    `{`

        `foreach (DBConnection connection in activeConnections)`

        `{`

            `callback(connection);`

        `}`

    `}`


```
}
```


The class (server) must perform two steps to define a delegate as a callback. The first step is to define the actual delegate—EnumConnectionsCallback, in this case—that will be the signature of the callback method. The syntax for defining a delegate takes the following form:


```
<access modifier> delegate <returnType> MethodName ([parameters])
```


The second step is to define a method that takes as one of its parameters the delegate. In this case, the EnumConnections method takes as its only parameter an instance of the EnumConnectionsCallback delegate.

Now the user of this class (the client) simply needs to define a method that has the same signature as the delegate and—using the new operator—instantiate the delegate, passing it the name of the method. Here’s an example of that:


```
public static void PrintConnections(DBConnection connection)
{
}
```


 


```
DBManager.EnumConnectionsCallback printConnections 
```


    `= new DBManager.EnumConnectionsCallback(PrintConnections);`

Finally, the client simply calls the desired class’s method, passing the instantiated delegate:


```
DBManager.EnumConnections(printConnections);
```


That’s all there is to the basic syntax of delegates. Now let’s look at the full example application:


```
using System;
using System.Collections;

class DBConnection
{
```


    `protected static int NextConnectionNbr = 1;`

    `protected string connectionName;`

    `public string ConnectionName`

    `{`

        `get`

        `{`

            `return connectionName;`

        `}`

    `}`

    `public DBConnection()`

    `{`

        `connectionName = "Database Connection "`

            `+ DBConnection.NextConnectionNbr++;`

    `}`


```
}

class DBManager
{
```


    `protected ArrayList activeConnections;`

    `public DBManager()`

    `{`

        `activeConnections = new ArrayList();`

        `for (int i = 1; i &lt; 6; i++)`

        `{`

            `activeConnections.Add(new DBConnection());`

        `}`

    `}`

    `public delegate void EnumConnectionsCallback(`

        `DBConnection connection);`

    `public void EnumConnections(EnumConnectionsCallback callback)`

    `{`

        `foreach (DBConnection connection in activeConnections)`

        `{`

            `callback(connection);`

        `}`

    `}`


```
};

class InstanceDelegate
{
```


    `public static void PrintConnections(DBConnection connection)`

    `{`

        `Console.WriteLine("[InstanceDelegate.PrintConnections] {0}",`

            `connection.ConnectionName);`

    `}`

    `public static void Main()`

    `{`

        `DBManager dbManager = new DBManager();`

        `Console.WriteLine("[Main] Instantiating the " +`

            `"delegate method");`

        `DBManager.EnumConnectionsCallback printConnections =`

            `new DBManager.EnumConnectionsCallback(`

            `PrintConnections);`

        `Console.WriteLine("[Main] Calling EnumConnections " +`

            `"- passing the delegate");`

        `dbManager.EnumConnections(printConnections);`

        `Console.ReadLine();`

    `}`


```
};
```


If you come from a C++ background, you probably noticed that delegates are very similar to C++ function pointers. In fact, many books describe them as type-safe function pointers.

delegates are better defined as the .NET equivalent of a functor, or function object, concept. Functors are C++ classes that overload the parenthesis operators so that the result looks like a function but is actually a type-safe, polymorphic class.


### Defining Delegates as Static Members

In addition to defining instances of delegates, C# allows you to define as a static class member the method that will be used in the creation of the delegate. Following is the example from the previous section, changed to use this format. Note that the delegate is now defined as a static member of the class named printConnections and that this member can be used in the Main method without the need for the client to instantiate the delegate.


```
using System;
using System.Collections;

class DBConnection
{
```


    `protected static int NextConnectionNbr = 1;`

    `protected string connectionName;`

    `public string ConnectionName`

    `{`

        `get`

        `{`

            `return connectionName;`

        `}`

    `}`

    `public DBConnection()`

    `{`

        `connectionName = "Database Connection "`

            `+ DBConnection.NextConnectionNbr++;`

    `}`


```
}

class DBManager
{
```


    `protected ArrayList activeConnections;`

    `public DBManager()`

    `{`

        `activeConnections = new ArrayList();`

        `for (int i = 1; i &lt; 6; i++)`

        `{`

            `activeConnections.Add(new DBConnection());`

        `}`

    `}`

    `public delegate void EnumConnectionsCallback(`

        `DBConnection connection);`

    `public void EnumConnections(EnumConnectionsCallback callback)`

    `{`

        `foreach (DBConnection connection in activeConnections)`

        `{`

            `callback(connection);`

        `}`

    `}`


```
};

class StaticDelegate
{
```


    `static DBManager.EnumConnectionsCallback printConnections `

        `= new DBManager.EnumConnectionsCallback(`

        `PrintConnections);`

    `public static void PrintConnections(DBConnection connection)`

    `{`

        `Console.WriteLine("[StaticDelegate.PrintConnections] {0}",`

            `connection.ConnectionName);`

    `}`

    `public static void Main()`

    `{`

        `DBManager dbManager = new DBManager();`

        `Console.WriteLine("[Main] Calling EnumConnections – " +`

            `"passing the delegate");`

        `dbManager.EnumConnections(printConnections);`

        `Console.ReadLine();`

    `}`


```
};
```



### Multicast Delegates

Combining multiple delegates into a single delegate creates what’s referred to as a multicast delegate and is one of those subtle features of the .NET Framework that doesn’t seem very handy at first. However, it’s also a feature that you’ll be happy the Common Language Infrastructure design team thought of if you ever do need it. Let’s look at some examples in which delegate multicasting is useful. In the first example, we have a distribution system and a class that iterates through the parts for a given location, calling a callback method for each part that has an “on-hand” value of less than 50. In a more realistic distribution example, the formula not only would take into account “on-hand” values, it would also take into account “on order” and “in transit” values (which describe the items’ lead times), it would subtract the safety stock level, and so on. But let’s keep this simple: if a part’s on-hand value is less than 50, an exception has occurred.

The twist is that we want two distinct methods to be called if a given part falls below stock: we want to log the event, and then we want to e-mail the purchasing manager. Let’s take a look at how you programmatically create a single aggregate delegate from multiple delegates:


```
using System;
using System.Threading;

class Part
{
```


    `public Part(string sku)`

    `{`

        `this.Sku = sku;`

        `Random r = new Random(DateTime.Now.Millisecond);`

        `double d = r.NextDouble() * 100;`

        `this.OnHand = (int)d;`

    `}`

    `protected string sku;`

    `public string Sku`

    `{`

        `get { return this.sku; }`

        `set { this.sku = value; }`

    `}`

    `protected int onHand;`

    `public int OnHand`

    `{`

        `get { return this.onHand; }`

        `set { this.onHand = value; }`

    `}`


```
};

class InventoryManager
{
```


    `protected const int MIN_ONHAND = 50;`

    `public Part[] parts;`

    `public InventoryManager()`

    `{`

        `Console.WriteLine("[InventoryManager.InventoryManager]" +`

            `" Adding parts..."); `

        `parts = new Part[5];`

        `for (int i = 0; i &lt; 5; i++)`

        `{`

            `Part part = new Part("Part " + (i + 1));`

            `Thread.Sleep(10); // Randomizer is seeded by time.`

            `parts[i] = part;`

            `Console.WriteLine("\tPart '{0}' on-hand = {1}", `

                `part.Sku, part.OnHand);`

        `}`

    `}`

    `public delegate void OutOfStockExceptionMethod(Part part);`

    `public void ProcessInventory(`

        `OutOfStockExceptionMethod exception)`

    `{`

        `Console.WriteLine("\n[InventoryManager.ProcessInventory]" +`

            `" Processing inventory...");`

        `foreach (Part part in parts)`

        `{`

            `if (part.OnHand &lt; MIN_ONHAND)`

            `{`

                `Console.WriteLine("\n\t{0} ({1} units) is " +`

                    `"below minimum on-hand {2}", `

                    `part.Sku, `

                    `part.OnHand, `

                    `MIN_ONHAND);`

                `exception(part);`

            `}`

        `}`

    `}`


```
};

class CompositeDelegate
{
```


    `public static void LogEvent(Part part)`

    `{`

        `Console.WriteLine("\t[CompositeDelegate.LogEvent] " +`

            `"logging event...");`

    `}`

    `public static void EmailPurchasingMgr(Part part)`

    `{`

        `Console.WriteLine("\t[CompositeDelegate" +`

            `".EmailPurchasingMgr] emailing Purchasing " +`

            `"manager...");`

    `}`

    `public static void Main()`

    `{`

        `InventoryManager mgr = new InventoryManager();`

        `InventoryManager.OutOfStockExceptionMethod`

            `LogEventCallback = new `

            `InventoryManager.OutOfStockExceptionMethod(LogEvent);`

        `InventoryManager.OutOfStockExceptionMethod `

            `EmailPurchasingMgrCallback = new `

            `InventoryManager.OutOfStockExceptionMethod(`

            `EmailPurchasingMgr);`

        `InventoryManager.OutOfStockExceptionMethod `

            `OnHandExceptionEventsCallback = `

            `EmailPurchasingMgrCallback + LogEventCallback;`

        `mgr.ProcessInventory(OnHandExceptionEventsCallback);`

        `Console.ReadLine();`

    `}`


```
};

Action<T1,T2…T16>(T1,T2…T16), Func<t1,t2…t16,R1> and Predicate<T>
```



#### <span style="text-decoration:underline;">Func delegate with an Anonymous Method: </span>


```
It can have 0 - 16 input parameters.
Func<int,int,int> Addition = delegate (int param1, int param2)    
{    
    return param1 + param2;    
};    

int result = Addition(10, 20);    
Console.WriteLine($"Addition = {result}"); 


Func with Lambda Expression:
Func<int, int, int> Addition = (param1, param2) => param1 + param2;  
            int result = Addition(10, 20);  
            Console.WriteLine($"Addition = {result}");
```



#### <span style="text-decoration:underline;">Action delegate</span>


```


Here, method AddNumbers takes 2 parameters but returns nothing. The results are assigned to an instance variable result.


Even an ion delegate can have 0 - 16 input parameters.
private static int result;  
        static void Main(string[] args)  
        {  
            Action<int, int> Addition = AddNumbers;  
            Addition(10, 20);  
            Console.WriteLine($"Addition = {result}");  
        }  


        private static void AddNumbers(int param1, int param2 )  
        {  
            result = param1 + param2;  
        } 

Action with an Anonymous method:
private static int result;  
       static void Main(string[] args)  
       {  
           Action<int, int> Addition = delegate (int param1, int param2)  
           {  
               result = param1 + param2;  
           };  
           Addition(10, 20);  
           Console.WriteLine($"Addition = {result}");  
       } 
```



#### <span style="text-decoration:underline;">Predicate delegate</span>

Syntax difference between predicate & func is that here in predicate, you don't specify a return type because it is always a bool.


```
A predicate with Anonymous method:
Predicate < string > CheckIfApple = delegate(string modelName) {  
    if (modelName == "I Phone X") return true;  
    else return false;  
};  

bool result = CheckIfApple("I Phone X");  
if (result) Console.WriteLine("It's an IPhone");   
A predicate with Lambda expressions:
Predicate < string > CheckIfApple = modelName => {  
    if (modelName == "I Phone X") return true;  
    else return false;  
};  
bool result = CheckIfApple("I Phone X");  
if (result) Console.WriteLine("It's an IPhone");  
```



## Partial Methods:

A partial method has its signature defined in one part of a partial type, and its implementation defined in another part of the type. Partial methods enable class designers to provide method hooks, similar to event handlers, that developers may decide to implement or not. If the developer does not supply an implementation, the compiler removes the signature at compile time. The following conditions apply to partial methods:



* Declarations must begin with the contextual keyword [partial](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/partial-type).
* Signatures in both parts of the partial type must match.

The `partial` keyword isn't allowed on constructors, finalizers, overloaded operators, property declarations, or event declarations.


## Expression Trees: 

Expression trees represent code in a tree-like data structure,

where each node is an expression,

for example, a method call or a binary operation such as x &lt; y.

You create expression trees in your code. You build the tree by creating each node and attaching the nodes into a tree structure. You learn how to create expressions in the article on building expression trees.

Expression trees are immutable. If you want to modify an expression tree,

you must construct a new expression tree by copying the existing one and replacing nodes in it.

You use an expression tree visitor to traverse the existing expression tree. 


```
var nArgument = Expression.Parameter(typeof(int), "n");
var result = Expression.Variable(typeof(int), "result");

// Creating a label that represents the return value
LabelTarget label = Expression.Label(typeof(int));

var initializeResult = Expression.Assign(result, Expression.Constant(1));

// This is the inner block that performs the multiplication,
// and decrements the value of 'n'
var block = Expression.Block(
    Expression.Assign(result,
        Expression.Multiply(result, nArgument)),
    Expression.PostDecrementAssign(nArgument)
);

// Creating a method body.
BlockExpression body = Expression.Block(
    new[] { result },
    initializeResult,
    Expression.Loop(
        Expression.IfThenElse(
            Expression.GreaterThan(nArgument, Expression.Constant(1)),
            block,
            Expression.Break(label, result)
        ),
        label
    )
);
```



## == vs Equals

In C#, the [equality operator ==](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators) checks whether two operands are equal or not, and the [Object.Equals()](https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-6.0#system-object-equals(system-object)) method checks whether the two object instances are equal or not.

Internally, == is implemented as the operator overloading method, so the result depends on how that method is overloaded. In the same way, Object.Equals() method is a virtual method and the result depends on the implementation. For example, the == operator and .Equals() compare the values of the two built-in value types variables. if both values are equal then returns true; otherwise returns false.

For the reference type variables, == and .Equals() method by default checks whether two two object instances are equal or not. However, for the string type, == and .Equals() method are implemented to compare values instead of the instances.


```
        A a1 = new A();
        A a2 = new A();
        Console.WriteLine(a1 == a2); //False
        Console.WriteLine(a1.Equals(a2)); //False

        Console.WriteLine(object.ReferenceEquals(a1, a2)); //False

        A a3 = a1;
        Console.WriteLine(object.ReferenceEquals(a1, a3)); //True
        Console.WriteLine(a1.Equals(a3)); //True
```



## [Static](https://www.tutorialsteacher.com/csharp/csharp-static), Readonly, and constant in C#.


<table>
  <tr>
   <td>static
   </td>
   <td>readonly
   </td>
   <td>const
   </td>
  </tr>
  <tr>
   <td>Declared using the <code>static</code> keyword.
   </td>
   <td>Declared using the <code>readonly</code> keyword.
   </td>
   <td>Declred using the <code>const</code> keyword. By default a const is static that cannot be changed.
   </td>
  </tr>
  <tr>
   <td>Classes, constructors, methods, variables, properties, event and operators can be static. The struct, indexers, enum, destructors, or finalizers cannot be static.
   </td>
   <td>Only the class level fields can be readonly. The local variables of methods cannot be readonly.
   </td>
   <td>Only the class level fields or variables can be constant.
   </td>
  </tr>
  <tr>
   <td>Static members can only be accessed within the static methods. The non-static methods cannot access static members.
   </td>
   <td>Readonly fields can be initialized at declaration or in the constructor.
<p>
Therefore, readonly variables are used for the run-time constants.
   </td>
   <td>The constant fields must be initialized at the time of declaration.
<p>
Therefore, const variables are used for compile-time constants.
   </td>
  </tr>
  <tr>
   <td>Value of the static members can be modified using <code>ClassName.StaticMemberName</code>.
   </td>
   <td>Readonly variable cannot be modified at run-time. It can only be initialized or changed in the constructor.
   </td>
   <td>Constant variables cannot be modified after declaration.
   </td>
  </tr>
  <tr>
   <td>Static members can be accessed using <code>ClassName.StaticMemberName</code>, but cannot be accessed using object.
   </td>
   <td>Readonly members can be accessed using object, but not <code>ClassName.ReadOnlyVariableName</code>.
   </td>
   <td>Const members can be accessed using <code>ClassName.ConstVariableName</code>, but cannot be accessed using object.
   </td>
  </tr>
</table>



## Setting default value of a C# property


```
// C#6.0 or higher version
public string Name { get; set; } = "unknown";

//using property setter
private string _name = "unknown";
public string Name
{
    get
    {
        return _name;
    }
    set
    {
        _name = value;
    }
}

//using DefaultValue attribute
private string _name;
[DefaultValue("unknown")]
public string Name
{
    get
    {
        return _name;
    }
    set
    {
        _name = value;
    }
}
```



## Indexers

_Indexers_ are similar to properties. In many ways indexers build on the same language features as [properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties). Indexers enable _indexed_ properties: properties referenced using one or more arguments. Those arguments provide an index into some collection of values.


```
public int this[string key]
{
    get { return storage.Find(key); }
    set { storage.SetAt(key, value); }
}

var item = someObject["key"];
someObject["AnotherKey"] = item;

Other examples:
   public int this [double x, double y]
   {
	get {
		return ….; //based on x and y
	}
   }

   public Action this[string s]
    {
        get
        {
            Action action;
            Action defaultAction = () => {} ;
            return argsActions.TryGetValue(s, out action) ? action : defaultAction; //argsActions is a map of string and Action delegates
        }
    }
```



## The object type

The `object` type is an alias for [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) in .NET. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object). 


```
string a = "hello";
string b = "h";
// Append to contents of 'b'
b += "ello";
Console.WriteLine(a == b); <<-- returns True
Console.WriteLine(object.ReferenceEquals(a, b)); <<-- returns False
```



## Conditional ref expression: `condition ? ref consequent : ref alternative`

Like the original conditional operator, a conditional ref expression evaluates only one of the two expressions: either `consequent` or `alternative`.


```
var smallArray = new int[] { 1, 2, 3, 4, 5 };
var largeArray = new int[] { 10, 20, 30, 40, 50 };

int index = 7;
ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
refValue = 0;

index = 2;
((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

Console.WriteLine(string.Join(" ", smallArray));
Console.WriteLine(string.Join(" ", largeArray));
// Output:
// 1 2 100 4 5
// 10 20 0 40 50
```



## when (C# reference)

You use the `when` contextual keyword to specify a filter condition in the following contexts:



* In a catch clause of a [try-catch](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-catch-statement) or [try-catch-finally](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements#the-try-catch-finally-statement) statement.
* As a [case guard](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#case-guards) in the [switch statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement).
* As a [case guard](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression#case-guards) in the [switch expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression).

`In a try-catch: `The following example uses the `when` keyword to conditionally execute handlers for an [HttpRequestException](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception) depending on the text of the exception message.


```
   public static async Task<string> MakeRequest()
    {
        var client = new HttpClient();
        var streamTask = client.GetStringAsync("https://localHost:10000");
        try
        {
            var responseText = await streamTask;
            return responseText;
        }
        catch (HttpRequestException e) when (e.Message.Contains("301"))
        {
            return "Site Moved";
        }
        catch (HttpRequestException e) when (e.Message.Contains("404"))
        {
            return "Page Not Found";
        }
        catch (HttpRequestException e)
        {
            return e.Message;
        }
    }
```



## Switch statement:


```
void DisplayMeasurement(double measurement)
{
    switch (measurement)
    {
        case < 0.0:
            Console.WriteLine($"Measured value is {measurement}; too low.");
            break;

        case > 15.0:
            Console.WriteLine($"Measured value is {measurement}; too high.");
            break;

        case double.NaN:
            Console.WriteLine("Failed measurement.");
            break;

        default:
            Console.WriteLine($"Measured value is {measurement}.");
            break;
    }
}
```


**<code><span style="text-decoration:underline;">Case guard using when: </span></code></strong>A case pattern may be not expressive enough to specify the condition for the execution of the switch section. In such a case, you can use a <em>case guard</em>. That is an additional condition that must be satisfied together with a matched pattern. A case guard must be a Boolean expression. You specify a case guard after the <code>when</code> keyword that follows a pattern, as the following example shows:


```
DisplayMeasurements(3, 4);  // Output: First measurement is 3, second measurement is 4.
DisplayMeasurements(5, 5);  // Output: Both measurements are valid and equal to 5.

void DisplayMeasurements(int a, int b)
{
    switch ((a, b))
    {
        case (> 0, > 0) when a == b:
            Console.WriteLine($"Both measurements are valid and equal to {a}.");
            break;

        case (> 0, > 0):
            Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
            break;

        default:
            Console.WriteLine("One or both measurements are not valid.");
            break;
    }
}
```


The following C# expressions and statements support pattern matching:



* [is expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is)
* [switch statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)
* [switch expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression)` \
`

You use **declaration and type patterns** to check if the run-time type of an expression is compatible with a given type. 


```
object greeting = "Hello, World!";
if (greeting is string message)
{
    Console.WriteLine(message.ToLower());  // output: hello, world!
}

var numbers = new int[] { 10, 20, 30 };
Console.WriteLine(GetSourceLabel(numbers));  // output: 1

var letters = new List<char> { 'a', 'b', 'c', 'd' };
Console.WriteLine(GetSourceLabel(letters));  // output: 2

static int GetSourceLabel<T>(IEnumerable<T> source) => source switch
{
    Array array => 1,
    ICollection<T> collection => 2,
    _ => 3,
};

int? xNullable = 7;
int y = 23;
object yBoxed = y;
if (xNullable is int a && yBoxed is int b)
{
    Console.WriteLine(a + b);  // output: 30
}
```


If you want to check only the type of an expression, you can use a discard `_` in place of a variable's name, as the following example shows:


```
public abstract class Vehicle {}
public class Car : Vehicle {}
public class Truck : Vehicle {}

public static class TollCalculator
{
    public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
    {
        Car _ => 2.00m,
        Truck _ => 7.50m,
        null => throw new ArgumentNullException(nameof(vehicle)),
        _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
    };
}
```


To check for non-null, you can use a [negated](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#logical-patterns) `null` [constant pattern](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#constant-pattern), as the following example shows:


```
if (input is not null)
{
    // ...
}
```


You use a **_constant pattern_** to test if an expression result equals a specified constant, as the following example shows:


```
public static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
{
    1 => 12.0m,
    2 => 20.0m,
    3 => 27.0m,
    4 => 32.0m,
    0 => 0.0m,
    _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}", nameof(visitorCount)),
};
```


In a constant pattern, you can use any constant expression, such as:



* an [integer](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types) or [floating-point](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types) numerical literal
* a [char](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char)
* a [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type) literal.
* a Boolean value `true` or `false`
* an [enum](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) value
* the name of a declared [const](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const) field or local
* `null`

Beginning with C# 9.0, you use a **_relational pattern_** to compare an expression result with a constant, as the following example shows:


```
static string Classify(double measurement) => measurement switch
{
    < -4.0 => "Too low",
    > 10.0 => "Too high",
    double.NaN => "Unknown",
    _ => "Acceptable",
};
```


In a **relational pattern**, you can use any of the [relational operators](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators) `&lt;`, `>`, `&lt;=`, or `>=`. The right-hand part of a relational pattern must be a constant expression. The constant expression can be of an [integer](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types), [floating-point](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types), [char](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char), or [enum](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) type.

Beginning with C# 9.0, you use the `not`, `and`, and `or` pattern combinators to create the following _logical patterns_:

To check if an expression result is in a certain range, match it against a [conjunctive and pattern](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#logical-patterns), as the following example shows:


```
static string GetCalendarSeason(DateTime date) => date.Month switch
{
    >= 3 and < 6 => "spring",
    >= 6 and < 9 => "summer",
    >= 9 and < 12 => "autumn",
    12 or (>= 1 and < 3) => "winter",
    _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
};

static string GetCalendarSeason(DateTime date) => date.Month switch
{
    3 or 4 or 5 => "spring",
    6 or 7 or 8 => "summer",
    9 or 10 or 11 => "autumn",
    12 or 1 or 2 => "winter",
    _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
};

static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

byte b = ...;
int x = b switch { <100 => 0, 100 => 1, 101 => 2, >101 => 3 };

Precedence: not, and, or
```


You use a **_property pattern_** to match an expression's properties or fields against nested patterns, as the following example shows:


```
Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc

static string TakeFive(object input) => input switch
{
    string { Length: >= 5 } s => s.Substring(0, 5),
    string s => s,

    ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
    ICollection<char> symbols => new string(symbols.ToArray()),

    null => throw new ArgumentNullException(nameof(input)),
    _ => throw new ArgumentException("Not supported input type."),
};
```


You use a **_positional pattern_** to deconstruct an expression result and match the resulting values against the corresponding nested patterns, as the following example shows:


```
public readonly struct Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

static string Classify(Point point) => point switch
{
    (0, 0) => "Origin",
    (1, 0) => "positive X basis end",
    (0, 1) => "positive Y basis end",
    _ => "Just a point",
};

static decimal GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate)
    => (groupSize, visitDate.DayOfWeek) switch
    {
        (<= 0, _) => throw new ArgumentException("Group size must be positive."),
        (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
        (>= 5 and < 10, DayOfWeek.Monday) => 20.0m,
        (>= 10, DayOfWeek.Monday) => 30.0m,
        (>= 5 and < 10, _) => 12.0m,
        (>= 10, _) => 15.0m,
        _ => 0.0m,
    };

public record Point2D(int X, int Y);
public record Point3D(int X, int Y, int Z);

static string PrintIfAllCoordinatesArePositive(object point) => point switch
{
    Point2D (> 0, > 0) p => p.ToString(),
    Point3D (> 0, > 0, > 0) p => p.ToString(),
    _ => string.Empty,
};
```


A **<code>var</code> pattern</strong> is useful when you need a temporary variable within a Boolean expression to hold the result of intermediate calculations. You can also use a <code>var</code> pattern when you need to perform more checks in <code>when</code> case guards of a <code>switch</code> expression or statement, as the following example shows:


```
public record Point(int X, int Y);

static Point Transform(Point point) => point switch
{
    var (x, y) when x < y => new Point(-x, y),
    var (x, y) when x > y => new Point(x, -y),
    var (x, y) => new Point(x, y),
};

static void TestTransform()
{
    Console.WriteLine(Transform(new Point(1, 2)));  // output: Point { X = -1, Y = 2 }
    Console.WriteLine(Transform(new Point(5, 2)));  // output: Point { X = 5, Y = -2 }
}
```


You use a **_discard pattern_** `_` to match any expression, including `null`, as the following example shows:


```
Console.WriteLine(GetDiscountInPercent(DayOfWeek.Friday));  // output: 5.0
Console.WriteLine(GetDiscountInPercent(null));  // output: 0.0
Console.WriteLine(GetDiscountInPercent((DayOfWeek)10));  // output: 0.0

static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
{
    DayOfWeek.Monday => 0.5m,
    DayOfWeek.Tuesday => 12.5m,
    DayOfWeek.Wednesday => 7.5m,
    DayOfWeek.Thursday => 12.5m,
    DayOfWeek.Friday => 5.0m,
    DayOfWeek.Saturday => 2.5m,
    DayOfWeek.Sunday => 2.0m,
    _ => 0.0m,
};
```


**Parenthesized Pattern: **Beginning with C# 9.0, you can put **parentheses** around any pattern. Typically, you do that to emphasize or change the precedence in [logical patterns](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#logical-patterns), as the following example shows:


```
if (input is not (float or double))
{
    return;
}
```


**List patterns: **Beginning with C# 11, you can match an array or a list against a _sequence_ of patterns, as the following example shows:


```
int[] numbers = { 1, 2, 3 };

Console.WriteLine(numbers is [1, 2, 3]);  // True
Console.WriteLine(numbers is [1, 2, 4]);  // False
Console.WriteLine(numbers is [1, 2, 3, 4]);  // False
Console.WriteLine(numbers is [0 or 1, <= 2, >= 3]);  // True

—---

List<int> numbers = new() { 1, 2, 3 };

if (numbers is [var first, _, _])
{
    Console.WriteLine($"The first element of a three-item list is {first}.");
}
// Output:
// The first element of a three-item list is 1.
```


—--


```
Console.WriteLine(new[] { 1, 2, 3, 4, 5 } is [> 0, > 0, ..]);  // True
Console.WriteLine(new[] { 1, 1 } is [_, _, ..]);  // True
Console.WriteLine(new[] { 0, 1, 2, 3, 4 } is [> 0, > 0, ..]);  // False
Console.WriteLine(new[] { 1 } is [1, 2, ..]);  // False

Console.WriteLine(new[] { 1, 2, 3, 4 } is [.., > 0, > 0]);  // True
Console.WriteLine(new[] { 2, 4 } is [.., > 0, 2, 4]);  // False
Console.WriteLine(new[] { 2, 4 } is [.., 2, 4]);  // True

Console.WriteLine(new[] { 1, 2, 3, 4 } is [>= 0, .., 2 or 4]);  // True
Console.WriteLine(new[] { 1, 0, 0, 1 } is [1, 0, .., 0, 1]);  // True
Console.WriteLine(new[] { 1, 0, 1 } is [1, 0, .., 0, 1]);  // False

—-----
```


A slice pattern matches zero or more elements. You can use at most one slice pattern in a list pattern. The slice pattern can only appear in a list pattern.

You can also nest a subpattern within a slice pattern, as the following example shows:


```
void MatchMessage(string message)
{
    var result = message is ['a' or 'A', .. var s, 'a' or 'A']
        ? $"Message {message} matches; inner part is {s}."
        : $"Message {message} doesn't match.";
    Console.WriteLine(result);
}

MatchMessage("aBBA");  // output: Message aBBA matches; inner part is BB.
MatchMessage("apron");  // output: Message apron doesn't match.

void Validate(int[] numbers)
{
    var result = numbers is [< 0, .. { Length: 2 or 4 }, > 0] ? "valid" : "not valid";
    Console.WriteLine(result);
}

Validate(new[] { -1, 0, 1 });  // output: not valid
Validate(new[] { -1, 0, 0, 1 });  // output: valid
```



## Pinning and Memory Management

Pinning is one aspect of memory management, and memory management in C# code can be divided into two broad categories: managing object lifetime in cooperation with the common language runtime and accessing memory directly through pointers.


### Garbage Collection

Although there’s a new operator in C#, there’s no equivalent to the delete operator as there is in C++. This means that in C# you can explicitly allocate heap memory with new, but you can’t explicitly deallocate it.

Unlike COM, the common language runtime doesn’t use reference counting to govern object lifetime. Instead, the GC traces object references and identifies objects that can no longer be reached by running code.

The GC doesn’t take up processor resources by running constantly, but it kicks in periodically. If your application has lots of free heap memory available to it, there’s clearly no need to recover any potentially collectable memory. One situation in which the GC will run occurs when you attempt to allocate some memory with new and fail because there isn’t enough available.

A consequence of this last point is that heap memory garbage collection—and, by extension, object destruction—is nondeterministic. That is, under normal circumstances, you can’t be absolutely sure when the GC will run and therefore when your object will finally be destroyed. This behavior leads to the one disadvantage of the GC: if your object is holding some unmanaged resources (window handles, database connections, and so on), you must be very careful to release these resources before your last reference to the object is lost. In C++, this type of behavior was traditionally the job of the class destructor, and you triggered this behavior in a deterministic manner by using the delete operator on the object reference. But in C# we don’t have a delete operator.

**Overriding Finalize**

The Finalize method is called automatically after an object becomes inaccessible, unless you’ve protected the object against finalization—we’ll see how to do that later in this chapter, in the section “Overriding Finalize.” During the shutdown of an application domain, Finalize is called automatically on all objects that you haven’t protected against finalization, even those that are still accessible. Finalize is called automatically only once on a given instance—unless you reregister the object for finalization. So, we can’t have a destructor in our class, but we’ve inherited a Finalize method, and presumably we can override this—even though it might not look like we can. In fact, to override Finalize, you must write a destructor. Let’s be clear on this. The C# language doesn’t strictly support destructors. On the other hand, it does support overriding the Object.Finalize method. The only twist in the tale is that to override Finalize, you must write a method that’s syntactically identical to a destructor.


```
public class Thing
{
```


    `private string name;`

    `public Thing(string name) { this.name = name; }`

    `override public string ToString() { return name; }`

    `~Thing() { Console.WriteLine("~Thing()"); }`


```
}
```


So that we’re clear on when the Finalize is called, let’s add another line to the end of Main:


```
static void Main(string[] args)
{
```


    `DoSomething();`

    `Console.WriteLine("end of Main");`


```
}
```


This time, when the application runs, we get the following output:


```
Foo
end of Main
~Thing()
```


Therefore, in this application, our Finalize method is called as the very last operation before the application terminates. That means, of course, that we can’t assume in our Finalize method that we have access to anything that was alive during the run of the application. This includes variables of all kinds as well as the console—thus, printing a message to the console window is a little risky. Normally, most of your Finalize methods will run at some other point during the run of the application and not at the very end. For a console application, it’s usually safe to assume that we have access to the console as long as the application is running. Nonetheless, the point stands: make sure your Finalize method doesn’t attempt to access anything that might not be available any longer because of the nondeterministic nature of the garbage collection mechanism.

We’ve been insisting that the ~Thing method isn’t a destructor but an override of Finalize, even though it looks like a destructor. To clear this up, let’s look at the metadata for this application

The ~Thing method isn’t listed in the type metadata, but Finalize is. If we also examine the Microsoft intermediate language (MSIL) for this Finalize method, we’ll see that it’s in fact the MSIL for our ~Thing method.

OK, so through the ability to override Finalize, C# does offer—for all intents and purposes—the same functionality as destructors in C++. The only coding quirk is that we write what looks and behaves like a destructor but is in fact an override for Finalize. Indeed, it’s common to call the Finalize method either a destructor or a finalizer. The mechanism works very well, and the compiler supports it with some behind-the-scenes cleverness.

This is what actually happens at run time: when you use the new operator to allocate heap memory for some object, the common language runtime determines whether this object is of a type that supports the Finalize method. If it does support Finalize, the runtime tracks the reference to this object by putting a copy of it in an internal finalization queue. Later, when a garbage collection has been triggered for unreferenced objects, the runtime calls the Finalize method for each object on the finalization queue before deallocating the objects’ memory.

Clearly, having a finalizer in a class increases the overhead of object creation. The GC will run only when all managed threads in an application reach a safe state (for example, suspended). The reason for this behavior is that during the garbage collection process, the runtime will defragment memory on the application’s managed heap, which therefore invalidates the references to objects that have been moved as part of this defragmentation. The runtime updates these references so that they are once again valid after defragmentation.

Each application has a logical collection of root references—namely, the managed object references for global and static objects and local variables that are currently on the stack and in registers. When the GC sweeps memory, it builds a graph of reachable objects, starting with all objects referenced by a root reference and recursively adding objects that are referenced by any added object. Before an object is added to the graph, the runtime checks that the object isn’t already in the graph, thus avoiding an infinite loop caused by circular references.

It’s very nice that we don’t have to track our object references and make sure we call delete in all the right places. However, being able to determine the exact point at which an object is destroyed can be useful. If C# provides a destructor-like mechanism, does C# offer us anything that behaves as operator delete does? We’ll answer this question in two stages: first, we’ll consider how we can force garbage collection, and then we’ll look at a design pattern that supports the semantics of deterministic object destruction.

<span style="text-decoration:underline;">34</span>

Forcing Garbage Collection

The .NET Framework offers a class that exposes some of the functionality of the garbage collector: the GC class. You can force a garbage collection operation at any time with the GC.Collect method. However, bear in mind that the garbage collector runs finalizers on a separate thread of execution, so even if GC.Collect has returned, it doesn’t mean that a particular finalizer has been called yet. This is really a standard thread-synchronization issue and can be resolved if you call WaitForPendingFinalizers to suspend the current thread until the queue of finalizers waiting to run on that thread is empty. In the following example, we’ll enhance our simple Thing-based application to force a garbage collection:


```
public class Thing
{
```


    `private string name;`

    `public Thing(string name) { this.name = name; }`

    `override public string ToString() { return name; }`

    `~Thing() { Console.WriteLine("~Thing()"); }`


```
}

public class ForceCollectApp
{
```


    `public static void Main(string[] args)`

    `{`

        `DoSomething();`

        `Console.WriteLine("some stuff");`

        `GC.Collect();`

        `GC.WaitForPendingFinalizers();`

        `Console.WriteLine("end of Main");`

    `}`

    `public static void DoSomething()`

    `{`

        `Thing t = new Thing("Foo");`

        `Console.WriteLine(t);`

    `}`


```
}
```


The result is that if we force a collection and wait for the finalizers to be called, we can introduce a degree of determinism to our code. However, this arrangement seems a little cumbersome to be useful on a broad scale. Also, the processing involved in actually sweeping heap memory for garbage collection does involve a certain amount of overhead—a performance penalty that you can’t always justify. The normal trigger for a garbage collection sweep is heap exhaustion, and we don’t normally want to force a garbage collection unless we really have to. In addition, if you do override Finalize in your class, you set up some extra work for the runtime to do at an indeterminate point in the future. So is there any other way to control object destruction? The final piece of this particular puzzle is the Dispose pattern.

**The Dispose Pattern**

Class instances often encapsulate control over resources not managed by the runtime. The .NET Framework supports both an implicit and an explicit way to free those resources. The implicit control is provided by implementing a finalizer. The GC calls this finalizer at some point after no valid references to the object remain—but as you’ll recall, although you can force a garbage collection, you have no control over exactly when the finalizer call is made.

To achieve the necessary explicit control and precise determinism in the destructor-like cleanup of unmanaged resources, you’re encouraged to implement an arbitrary Dispose method. The consumer of the object should call this method when the object is no longer required. This call can be made even if other references to the object are alive. Unlike the finalizer, the Dispose method is arbitrary—in terms of its name, signature, access modifiers, and attributes. In other words, you can invent any method you want that internally will clean up unmanaged resources the way that a C++ destructor traditionally would. You then can let everyone know what this method does and encourage developers using your class to call this method when they’ve finished with an instance of your class. Clearly, if every author of a class were to invent a different method to do this job, we’d be little further along in the development of reusable classes. For this reason, you’re encouraged to use a public nonstatic method named Dispose, with a void return and no parameters. This is only a convention, but it’s a sensible convention that most people are happy to adopt. Moreover—and interestingly—the C# language has explicit support for this arbitrary method.

Let’s enhance our previous Thing example with a Dispose method—again, to simulate some cleanup operation, we’ll simply print out an arbitrary message. Clearly, if we plan to dispose of the object, we must do so before we set its reference to null (or before the reference goes out of scope and is lost):


```
public class Thing
{
```


    `private string name;`

    `public Thing(string name) { this.name = name; }`

    `override public string ToString() { return name; }`

    `~Thing() { Console.WriteLine("~Thing()"); }`

    `public void Dispose()`

    `{`

        `Console.WriteLine("Dispose()");`

    `}`


```
}

public class GarbageDisposalApp
{
```


    `public static void Main(string[] args)`

    `{`

        `DoSomething();`

        `Console.WriteLine("end of Main");`

    `}`

    `public static void DoSomething()`

    `{`

        `Thing t = new Thing("Foo");`

        `Console.WriteLine(t);`

        `t.Dispose();`

        `t = null;`

        `GC.Collect();`

        `GC.WaitForPendingFinalizers();`

    `}`


```
}
```


The output from this code is shown here:


```
Foo
Dispose()
~Thing()
end of Main
```


Two issues arise from this code. First, if we’ve moved the cleanup operations to the Dispose method, there’s no longer anything meaningful for the finalizer to do, but—as you can see from the output just shown—the finalizer is called anyway. Second, if we now perform our cleanup in the Dispose method, what happens if the object is finalized through some branch of code that bypasses the call to Dispose?

The standard strategy used to resolve the first issue is to add a statement to the Dispose method that will suppress the GC’s call to the Finalize method:


```
public void Dispose()
{
```


    `Console.WriteLine("Dispose()");`

    `GC.SuppressFinalize(this);`


```
}
```


GC.SuppressFinalize will remove the object from the finalization queue, so although the memory for the object will get collected, the Finalize method won’t be called. Note that the parameter passed to this method should be this current object, but the compiler doesn’t enforce this.

Now let’s now address the second issue I mentioned earlier: what happens if the object is finalized—for example, as a result of a conditional branch in our code, or as an exception that gets thrown—and bypasses the call to Dispose? Fixing this little snag is a simple matter: just call the Dispose in the finalizer. Therefore, if the developer has remembered to call Dispose and that branch of the code is executed, all’s well. Equally, if the developer’s explicit call to Dispose is bypassed in some way, the finalizer will be called (because it of course hasn’t been suppressed by the Dispose) and will call the Dispose:


```
~Thing() 
{ 
```


    `Dispose();`

    `Console.WriteLine("~Thing()"); `


```
}
```


It’s possible that after you’ve suppressed finalization of an object, a condition will arise in your application that makes you want to reinstate the garbage collector’s call to Finalize. The GC class supports this (admittedly somewhat remote) possibility through the ReRegisterForFinalize method.


```
public static void DoSomething()
```


    `{`

        `Thing t = new Thing("Foo");`

        `Console.WriteLine(t);`

        `t.Dispose();`

        `// Some condition arises.`

        `GC.ReRegisterForFinalize(t);`

        

    `}`

**The IDisposable Interface**

The Dispose pattern discussed in the previous section suffers from being arbitrary. To strengthen the support for this strategy, Microsoft introduced the IDisposable interface. This interface offers only one method: Dispose. You implement this interface in any class where you need to perform cleanup in order to expose a standard Dispose method for potential clients to use. Many of the .NET Framework classes implement this interface—most notably those involved in GDI, controls, containers, components, stream-readers and stream-writers, and so on, where there’s a strong likelihood that resources (such as window handles, file handles, and so forth) will need to be released when the object dies. Besides standardizing the Dispose method and formalizing the strategy, implementing IDisposable has the added benefit of an application being able to test an object for this interface using the is or as operator. This practice in turn will tend to make your class more generically reusable.

**Derived Disposable Classes**

Recall that that when you derive a finalizable class from a finalizable base class, the compiler will generate MSIL to call the base class Finalize. Of course, the compiler doesn’t do any such thing in the case of the Dispose method. So, if you adopt the Dispose pattern and put your cleanup code in the Dispose method, you might end up in a situation where both your base class and derived class are independently holding some unmanaged resources that need cleaning up. In this case, you’d have to be careful to call the Dispose base class at an appropriate point during the execution of the Dispose derived class.

The following code illustrates this scenario:


```
public class Thing : IDisposable
{
```


    `protected string name;`

    `public Thing(string name) { this.name = name; }`

    `override public string ToString() { return name; }`

    `~Thing() { Dispose(); Console.WriteLine("~Thing()"); }`

    `public void Dispose() `

    `{ `

        `Console.WriteLine("Thing.Dispose()"); `

        `GC.SuppressFinalize(this);`

    `}`


```
}
public class SonOfThing : Thing, IDisposable
{
```


    `public SonOfThing(string name) : base(name) { }`

    `override public string ToString() { return name; }`

    `~SonOfThing() `

    `{ Dispose(); Console.WriteLine("~SonOfThing()"); }`

    `new public void Dispose()`

    `{ `

        `Console.WriteLine("SonOfThing.Dispose()"); `

        `base.Dispose();`

        `GC.SuppressFinalize(this);`

    `}`


```
}

class DerivedDisposeApp
{
```


    `static void Main(string[] args)`

    `{`

        `DoSomething();`

    `}`

    `static void DoSomething()`

    `{`

        `SonOfThing s = new SonOfThing("Bar");`

        `Console.WriteLine(s);`

        `s.Dispose();`

    `}`


```
}
```


If you want the derived class to implement the IDisposable interface, you must declare it to do so and implement the Dispose method of that interface—merely relying on the inherited base class implementation isn’t enough. However, this leads to the situation where we have an identically signatured Dispose method in both the base class and the derived class, and the compiler will warn us about this situation unless we add the new keyword to the derived class declaration. You’ll also notice from the output that both the derived class finalizer and base class finalizer are suppressed:


```
Bar
SonOfThing.Dispose()
Thing.Dispose()
```


**Protecting Against Double Disposal**

Because the developer is responsible for calling Dispose, suppressing finalization if he or she has called Dispose, calling Dispose from the class finalizer, and perhaps calling the base class Dispose, he or she is also responsible for ensuring that Dispose doesn’t get called more than once per object. If Dispose is called more than once, the developer must ensure that there are no consequences.

The following enhancement to our Thing system illustrates one way to satisfy these requirements. We simply set a Boolean field in our Dispose and test it at the beginning of the method:


```
public class Thing : IDisposable
{
```


    `private string name;`

    `public Thing(string name) { this.name = name; }`

    `override public string ToString() { return name; }`

    `~Thing() `

    `{ `

        `Dispose();`

        `Console.WriteLine("~Thing()"); `

    `}`

    `private bool AlreadyDisposed = false;`

    `public void Dispose()`

    `{`

        `if (!AlreadyDisposed)`

        `{`

            `AlreadyDisposed = true;`

            `Console.WriteLine("Dispose()");`

            `GC.SuppressFinalize(this);`

        `}`

    `}`


```
}
```


**Language Support for Dispose**

Using conventional coding constructs, the best way to ensure that an object’s lifetime is controlled and that resources are cleaned up deterministically is by enclosing the object in a try and finally block:


```
static void Main(string[] args)
{
```


    `Thing t1 = new Thing("Ethel");`

    `try`

    `{`

        `Console.WriteLine(t1);`

    `}`

    `finally`

    `{`

        `if (t1 != null)`

            `((IDisposable)t1).Dispose();`

    `}`


```
}
```


This pattern is so standard that the C# language supports it through the use of the using statement. The previous code with a try..finally block can be rewritten as follows:


```
using (Thing t2 = new Thing("JimBob")) 
{
```


    `Console.WriteLine(t2);`


```
}
```


The using statement requires that the class implement IDisposable.

**Garbage Collector Generations**

As a performance optimization measure, the GC is written to use the concept of object generations. Every object on the heap is assigned to a generation, arbitrarily starting at zero and increasing to a maximum of three on current versions of the .NET Framework. If a given object survives a garbage collection sweep, it’s promoted to the next generation. This way, the newest objects are collected first—in other words, an object more local in scope will have a shorter lifetime than an object in a less local scope.

Remember that the primary reason for garbage collection is to ensure that sufficient memory is always available for a process’s needs. When garbage collection is performed, the GC sweeps all generation 0 objects first. If this sweep results in sufficient memory, all remaining objects are promoted to the next available generation (0 to 1, 1 to 2, and so on). If, however, there’s still not sufficient memory, all generation 1 objects will be swept and collected, followed by all generation 2 objects, and so forth.

**Weak References**

When would you need to use a weak reference? One obvious use is for objects that are costly to set up and consume lots of memory. Say you’ve set up a large object and then the user switches to a different part of the application where the object isn’t needed. We might want to release the memory, so we destroy all strong references. But what if the user switches back to the original part of the application he or she was using and needs the object again? Remember, it’s costly to set up. So let’s destroy all strong references as we did earlier, but let’s get a weak reference first. Then the GC will collect the memory if we’re low on memory (and won’t collect the memory if we’re not low on memory). And if the user switches back, we can use the weak reference to get back a strong reference, thereby avoiding the cost of setup. Now isn’t that neat?

Recall that when you write a statement such as this


```
Thing t = new Thing("Foo");
```


you’re declaring an instance of the Thing class, for which the runtime will allocate memory on the heap. The t variable isn’t the object itself, but rather a reference to the object. This is what’s known as a strong reference.

The WeakReference class is a wrapper for establishing a weak reference to an object. Objects referenced through the WeakReference class are kept alive only as long as there’s at least one strong (that is, normal) reference to the object. For example, you can have a collection of weak references to objects, each of which stays alive only as long as something else has a strong reference to those objects.

The common language runtime supports two styles of weak reference: short weak references and long weak references. The distinction between the two styles is whether the reference is zeroed before or after finalization of the target object. The constructor for WeakReference takes a Boolean named trackResurrection and determines which of the two styles to use. By default, trackResurrection is set to false so that the object is tracked only until finalization—that is, the object was zeroed before finalization.

In the following example, we create a strong reference, t1, to a Thing and then get a weak reference to it while it’s still alive. From the weak reference, we can create a second strong reference, t2, and print it out. We then destroy both strong references, force a garbage collection, and then test to see whether the weak reference is still alive (which, of course, it isn’t).


```
public class WeakRefsApp
{
```


    `public static void Main(string[] args)`

    `{`

        `Thing t1 = new Thing("Foo");`

        `WeakReference wr = new WeakReference(t1, false);`

        `if (wr.IsAlive)`

        `{`

            `Thing t2 = (Thing) wr.Target;`

            `Console.WriteLine("new WeakReference: {0}", t2);`

            `t2.Dispose();`

            `t2 = null;`

        `}`

        `t1.Dispose();`

        `t1 = null;`

        `GC.Collect();`

        `GC.WaitForPendingFinalizers();`

        `if (wr.IsAlive)`

        `{`

            `Thing t3 = (Thing) wr.Target;`

            `Console.WriteLine("using old WR: {0}", t3);`

        `}`

        `else`

            `Console.WriteLine("WeakReference is dead");`

    `}`


```
}
```


Here’s the output:


```
new WeakReference: Foo
Dispose
Dispose
WeakReference is dead
```



### Unsafe Code

Programmers who come to C# from C or C++ are sometimes concerned about the degree of control—or the lack of it—that they might have over memory. If you’re used to dealing with raw pointers, you’ll know how powerful—and potentially dangerous—they can be. The C# language addresses this concern by providing the option to use pointers. The one caveat is that you can use only pointers in code marked unsafe. Despite its ominous name, unsafe code isn’t inherently unsafe or untrustworthy—rather, it’s C# code that bypasses the compiler’s type checking and allows the use of raw pointers. A related concept is unmanaged code: code for which the .NET runtime doesn’t control the allocation and deallocation of memory. Unmanaged code includes code written in earlier versions of Microsoft Visual Basic or in C++ without the managed extensions.


```
public class TestUnsafeApp
{
```


    `unsafe public static void Swap(int* pi, int* pj)`

    `{`

        `int tmp = *pi;`

        `*pi = *pj;`

        `*pj = tmp;`

    `}`

    `public static void Main(string[] args)`

    `{`

        `int i = 3;`

        `int j = 4;`

        `Console.WriteLine("BEFORE: i = {0}, j = {1}", i, j);`

        `unsafe { Swap(&i, &j); }`

        `Console.WriteLine("AFTER:  i = {0}, j = {1}", i, j);`

    `}`


```
}
```


Note that the unsafe keyword must be used in both the declaration of the unsafe method and the call to the unsafe method because both the & and * pointer operators can be used only in an unsafe context. Because the call is an otherwise undelimited statement (or block of statements), you must delimit it with a pair of curly braces. All code within these curly braces is considered unsafe. This code needs to be compiled with the /unsafe compiler option.


### Pinning

Another technique used in unsafe code is pinning, for which you use the keyword fixed. This technique is permitted only in an unsafe context. The fixed keyword is responsible for the pinning of managed objects. Pinning is the act of specifying to the GC that the object in question can’t be moved.

To reduce the degree to which memory becomes fragmented, the .NET runtime moves objects around during garbage collection to try to consolidate used blocks of memory, thereby freeing up larger contiguous blocks. This system is clearly beneficial in making the most efficient use of the memory available. On the other hand, it’s less useful when you have a pointer to a specific memory address and then—unbeknownst to you—the .NET runtime moves the object from that address, leaving you with an invalid pointer. This situation is why you have the option to pin a variable in memory if you want—but bear in mind that the reason the GC moves things around in memory is to increase application efficiency. Thus, you should pin variables only if you can’t avoid doing so.

Note that you need only pin variables that might otherwise be moved by the runtime—therefore, this applies only to reference variables on the heap. The GC doesn’t move value-type variables.

        `unsafe`

        `{`

            `fixed (int* pi = &i.id, pj = &j.id)`

            `{`

                `Swap(pi, pj);`

            `}`

        `}`


### Using stackalloc

As an alternative strategy to pinning, we can allocate data on the stack instead of on the heap by using the keyword stackalloc. This keyword will allocate a block of memory of sufficient size to contain the specified number of elements of the specified type; the address of the block is returned by the expression. Because this memory is on the stack, it isn’t subject to garbage collection and therefore doesn’t have to be pinned. For example, we could modify our earlier application that worked on an array of integers to put this array on the stack by using stackalloc:

    `static void Main(string[] args)`

    `{`


```
/*        int[] ia = new int[5]{12,34,56,78,90};
```


        `unsafe`

        `{`

            `fixed (int* pa = ia)`

            `{`

                `Foo(pa);`

            `}`

        `}`


```
*/
```


        `unsafe`

        `{`

            `int* pa = stackalloc int[5];`

            `pa[0] = 12;`

            `pa[1] = 34;`

            `pa[2] = 56;`

            `pa[3] = 78;`

            `pa[4] = 90;`

            `Foo(pa);`

        `}`

    `}`


## Static vs Singleton


```
public class VoteMachine
{
    private static VoteMachine _instance = null;
    private int _totalVotes = 0;
    private static readonly object lockObj = new object();


    private VoteMachine(){}

    public static VoteMachine Instance
    {
        get
        {
            if (_instance == null) //no need to enter and lock if not null
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new VoteMachine();
                    }
                }
            }
            return _instance;
        }
    }

    public void RegisterVote()
    {
        _totalVotes += 1;
        Console.WriteLine("Registered Vote #" + _totalVotes);
    }

    public int TotalVotes
    {
        get
        {
            return _totalVotes;
        }
    }
}
```



## <span style="text-decoration:underline;">Singleton Class using Static Constructor</span>

You can create a singleton class by using the static constructor. The static constructor runs only once per app domain when any static member of a class is accessed.


```
public class VoteMachine
{
	private static readonly VoteMachine _instance = new VoteMachine();
	private int _totalVotes = 0;

	static VoteMachine()
	{
	}

	private VoteMachine()
	{
	}

	public static VoteMachine Instance
	{
		get
		{
			return _instance;
		}
	}

	public void RegisterVote()
	{
		_totalVotes += 1;
		Console.WriteLine("Registered Vote #" + _totalVotes);
	}

	public int TotalVotes
	{
		get
		{
			return _totalVotes;
		}
	}
}
```



## Singleton Class with Lazy Instantiation

If you use .NET 4 or higher, use [Lazy&lt;T>](https://docs.microsoft.com/en-us/dotnet/api/system.lazy-1) to create an instance only when needed.


```
public sealed class VoteMachine
{
	private static readonly Lazy<VoteMachine> _instance = new Lazy<VoteMachine>(() => new VoteMachine());
	private int _totalVotes = 0;


      private VoteMachine(){}
	public static VoteMachine Instance
	{
		get
		{
			return _instance.Value;
		}
	}

	public void RegisterVote()
	{
		_totalVotes += 1;
		Console.WriteLine("Registered Vote #" + _totalVotes);
	}

	public int TotalVotes
	{
		get
		{
			return _totalVotes;
		}
	}
}

public class Program
{
    public static void Main(string[] args)
    {
        var numbers = Enumerable.Range(0, 10);
        Parallel.ForEach(numbers, i =>
        {                
            var vm = VoteMachine.Instance;
            vm.RegisterVote();
        });
        Console.WriteLine(VoteMachine.Instance.TotalVotes);
    }
}

//static
public class VoteMachine
{
	private static int _totalVotes = 0;


	static VoteMachine()
	{
	}

	public static void RegisterVote()
	{
		_totalVotes += 1;
		Console.WriteLine("Registered Vote #" + _totalVotes);
	}

	public static int TotalVotes
	{
		get
		{
			return _totalVotes;
		}
	}
}

public class Program
{
	public static void Main()
	{
		var numbers = Enumerable.Range(0, 10);
		Parallel.ForEach(numbers, i =>
		{			
			VoteMachine.RegisterVote();
		});
		Console.WriteLine(VoteMachine.TotalVotes);
	}
}
```


So, a static class can be a singleton class. It is thread-safe and performs well because we don't need to use locks.


<table>
  <tr>
   <td>Static Class
   </td>
   <td>Singleton Class
   </td>
  </tr>
  <tr>
   <td>Cannot inherit the static class in other classes. No Polymorphism.
   </td>
   <td>Can inherit and extend singleton class by having a protected constructor.
   </td>
  </tr>
  <tr>
   <td>Cannot implement an interface.
   </td>
   <td>Can implement an interface.
   </td>
  </tr>
  <tr>
   <td>Cannot create and assign an instance to another variable.
   </td>
   <td>Can create one instance and assign it to multiple variables.
   </td>
  </tr>
  <tr>
   <td>Cannot pass as an argument to a method.
   </td>
   <td>Can be passed as an argument.
   </td>
  </tr>
  <tr>
   <td>Cannot be serialized.
   </td>
   <td>Can be serialized.
   </td>
  </tr>
</table>



## stackalloc

A `stackalloc` expression allocates a block of memory on the stack. A stack allocated memory block created during the method execution is automatically discarded when that method returns. You can't explicitly free the memory allocated with `stackalloc`. A stack allocated memory block isn't subject to [garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/) and doesn't have to be pinned with a [fixed statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/fixed).


```
stackalloc int[3]				// currently allowed
stackalloc int[3] { 1, 2, 3 }
stackalloc int[] { 1, 2, 3 }
stackalloc[] { 1, 2, 3 }
```


You can assign the result of a `stackalloc` expression to a variable of one of the following types:



* [System.Span&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)<span style="text-decoration:underline;"> or [System.ReadOnlySpan&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1), as the following example shows:</span>


```
int length = 3;
Span<int> numbers = stackalloc int[length];
for (var i = 0; i < length; i++)
{
    numbers[i] = i;
}
```


You don't have to use an [unsafe](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe) context when you assign a stack allocated memory block to a [Span&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) or [ReadOnlySpan&lt;T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1) variable.

int length = 1000;

Span&lt;byte> buffer = length &lt;= 1024 ? stackalloc byte[length] : new byte[length];



* <span style="text-decoration:underline;">A [pointer type](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/unsafe-code#pointer-types), as the following example shows:</span>


```
unsafe
{
    int length = 3;
    int* numbers = stackalloc int[length];
    for (var i = 0; i < length; i++)
    {
        numbers[i] = i;
    }
}
```


The content of the newly allocated memory is undefined. You should initialize it before the use. For example, you can use the [Span&lt;T>.Clear](https://learn.microsoft.com/en-us/dotnet/api/system.span-1.clear) method that sets all the items to the default value of type `T`.

Span&lt;int> first = stackalloc int[3] { 1, 2, 3 };

Span&lt;int> second = stackalloc int[] { 1, 2, 3 };

ReadOnlySpan&lt;int> third = stackalloc[] { 1, 2, 3 };


## Fixed-size buffers

You can use the `fixed` keyword to create a buffer with a fixed-size array in a data structure. Fixed-size buffers are useful when you write methods that interoperate with data sources from other languages or platforms. The fixed-size buffer can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.


```
internal unsafe struct Buffer
{
    public fixed char fixedBuffer[128];
}

internal unsafe class Example
{
    public Buffer buffer = default;
}

private static void AccessEmbeddedArray()
{
    var example = new Example();

    unsafe
    {
        // Pin the buffer to a fixed location in memory.
        fixed (char* charPtr = example.buffer.fixedBuffer)
        {
            *charPtr = 'A';
        }
        // Access safely through the index:
        char c = example.buffer.fixedBuffer[0];
        Console.WriteLine(c);

        // Modify through the index:
        example.buffer.fixedBuffer[0] = 'B';
        Console.WriteLine(example.buffer.fixedBuffer[0]);
    }
}
```



## Properties


```
initializations
public class Person
{
    public string? FirstName { get; set; }

    // Omitted for brevity.
}

public class Person
{
    public string FirstName { get; set; } = string.Empty;

    // Omitted for brevity.
}

public class Person
{
    public string? FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    private string? _firstName;

    // Omitted for brevity.
}

public class Person
{
    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }
    private string? _firstName;

    // Omitted for brevity.
}

Validation:
public class Person
{
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name must not be blank");
            _firstName = value;
        }
    }
    private string? _firstName;

    // Omitted for brevity.
}
```


Beginning in C# 11, you can _require_ callers to set that property:


```
public class Person
{
    public Person() { }

    [SetsRequiredMembers]
    public Person(string firstName) => FirstName = firstName;

    public required string FirstName { get; init; }

    // Omitted for brevity.
}

Used as:
var person = new VersionNinePoint2.Person("John");
person = new VersionNinePoint2.Person{ FirstName = "John"};

// Error CS9035: Required member `Person.FirstName` must be set:
//person = new VersionNinePoint2.Person();
```


Computed properties`:`


```
public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string FullName { get { return $"{FirstName} {LastName}"; } }

    public string FullName2 => $"{FirstName} {LastName}"; //Lambda based
}
```



## Implementing INotifyPropertyChanged

A final scenario where you need to write code in a property accessor is to support the [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged) interface used to notify data binding clients that a value has changed. When the value of a property changes, the object raises the [INotifyPropertyChanged.PropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged) event to indicate the change. The data binding libraries, in turn, update display elements based on that change. 


```
public class Person : INotifyPropertyChanged
{
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name must not be blank");
            if (value != _firstName)
            {
                _firstName = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
    }
    private string? _firstName;

    public event PropertyChangedEventHandler? PropertyChanged;
}
```


The `?.` operator is called the _null conditional operator_. It checks for a null reference before evaluating the right side of the operator. The end result is that if there are no subscribers to the `PropertyChanged` event, the code to raise the event doesn't execute.

This example also uses the new `nameof` operator to convert from the property name symbol to its text representation. Using `nameof` can reduce errors where you've mistyped the name of the property.


## Using COM Components from C#

Therefore, the .NET Framework does support a feature that allows for complete interoperation between COM components and code written using .NET compilers. This feature—named, appropriately enough, **COM interop**.


### Consuming a COM Component from a .NET Application

A .NET application that needs to talk to our COM component can’t directly consume the functionality that the component exposes. Therefore, we need to generate some metadata. As you’ve learned throughout this book, metadata is used by the common language runtime to glean type information. In this case, the metadata is being used to dynamically generate something named a Runtime Callable Wrapper (RCW). The RCW handles the actual activation of the COM object and handles the marshaling requirements when the .NET application interacts with the object. The RCW also performs many other chores such as managing object identity, managing object lifetime, and managing interface caching. Object lifetime management is a very critical issue here because the .NET runtime moves objects around and garbage collects them. The RCW gives the .NET application the notion that it’s interacting with a managed .NET component. The RCW also gives the COM component in the unmanaged space the impression that it’s being called by a standard COM client. The RCW’s creation and behavior varies depending on whether you’re early binding or late binding to the COM object. Under the hood, the RCW does all the heavy lifting required to thunk the method invocations down to corresponding v-table calls into the COM component that lives in the unmanaged world. It’s an ambassador of goodwill between the managed world and the unmanaged IUnknown world.

To generate the metadata wrapper for COM component we’ll use a tool named the Type Library Importer (TLBIMP.EXE). This application ships with the .NET Framework SDK and can be located in the Bin subfolder of your SDK installation.


```
TLBIMP AirlineInformation.tlb /out:AirlineMetadata.dll
```


This command tells the type library importer to read your AirlineInfo COM type library and generate a corresponding metadata wrapper named AirlineMetadata.dll.

If everything went through fine, you should see a message indicating that the metadata proxy has been generated from the type library:


```
Type library imported to E:\COMInteropWithDOTNET\AirlineMetadata.dll
```


Under the hood, the runtime fabricates an RCW, which maps the metadata proxy’s class methods and fields to methods and properties exposed by the interface that the COM object implements. One RCW instance is created for each instance of the COM object. With regards to its interaction with the RCW, the .NET runtime cares only about managing its lifetime and handling garbage collection duties. The RCW takes care of maintaining reference counts on the COM object that the object is mapped to, thereby shielding the .NET runtime from managing the reference counts on the actual COM object.

All you need to do is create an instance of the Air­lineInfo class using the new operator and call the public class methods of the created object. When a given method is invoked, the RCW thunks down the call to the corresponding COM method. The RCW also handles all the marshaling and object lifetime issues. From the .NET client’s viewpoint, the client appears to create a managed object and calls one of the object’s public class members.

Anytime the COM method raises an error, the COM error is trapped by the RCW and the error is converted into an equivalent COMException class—found in the System.Runtime.InteropServices namespace. Of course, the COM object still needs to implement the ISupportErrorInfo and IErrorInfo interfaces for this error propagation to work so that the RCW knows that the object provides extended error information. The .NET client catches the error with the usual try-catch exception handling mechanism, and the client has access to the actual error number, description, source of the exception, and other details that would have been available to any COM-aware client.

If you return standard HRESULT values, the RCW will map them to the corresponding .NET exceptions that are thrown back to the client. For example, if you return an HRESULT of E_NOTIMPL from your COM method, the RCW will map this value to the .NET NotImplementedException exception and throw an exception of that type.


### Dynamic Type Discovery with COM Components

How does the QueryInterface scenario work from the perspective of the .NET client when QueryInterface needs to check whether a COM object implements a specific interface? To call QueryInterface for another interface, you simply cast the object to the interface that you’re querying for, and if the cast succeeds—voilà—your QueryInterface succeeds as well. In case you attempt to cast the object to some arbitrary interface that the object doesn’t support, a System.InvalidCastException exception is thrown, indicating that the QueryInterface call has failed. The process is that simple. Again, the RCW does all the hard work under the covers. It’s similar to the way the Microsoft Visual Basic runtime shields us from having to write any explicit QueryInterface-related code by simply calling QueryInterface for you when you set one object type to an object of another associated type.

An alternate way to check whether the object instance that you’re currently holding supports or implements a specific interface type is to use C#’s is operator.


### Late Binding to COM Objects

The examples that you just saw used the metadata proxy to early bind the .NET client to the COM object. Though early binding provides a smorgasbord of benefits—such as strong type checking at compile time, autocompletion capabilities from type information for development tools, and of course, better performance—there might be instances in which you really need to late bind to a COM object but don’t have the compile-time metadata for that COM object. You can late bind to a COM object through a mechanism known as reflection. This process doesn’t apply to COM objects alone. Even .NET managed objects can be late bound and loaded using reflection. Also, if your object implements a pure dispinterface only, you’re pretty much limited to using reflection to activate your object and invoke methods on its interface.

When late binding to a COM object, you need to know the object’s ProgID or CLSID. The CreateInstance static method of the System.Activator class allows you to specify the Type information for a specific class and will automatically create an object of that specific type. Instead of true .NET Type information, what we really have is a COM ProgID and COM CLSID for our COM object. Therefore, we need to get the Type information from the ProgID or CLSID using the GetTypeFromProgID or GetTypeFromCLSID static methods of the System.Type class. The System.Type class is one of the core enablers of reflection.

After creating an instance of the object using Activator.CreateInstance, you can invoke any of the methods and properties supported by the object using the System.Type.InvokeMember method of the Type object that you got back from Type.GetTypeFromProgID or Type.GetTypeFromCLSID. All you need to know is the name of the method or property and the kind of parameters that the method call accepts. The parameters are bundled into a generic System.Object array and passed to the method. You’d also need to set the appropriate binding flags depending on whether you’re invoking a method or getting or setting the value of a property. That’s all there is to late binding to a COM object. Here’s how the code looks:


```
try
{
```


    `object objAirlineLateBound;`

    `Type objTypeAirline;`

   

    `// Create an object array containing the input`

    `// parameters for the method.`

    `object[] arrayInputParams= { "Air Scooby IC 5678" };`

   

    `// Get the type information from the ProgID.`

    `objTypeAirline = Type.GetTypeFromProgID(`

        `"AirlineInformation.AirlineInfo");`

   

    `// Here's how you use the COM CLSID to get`

    `// the associated .NET System.Type:`

    `// objTypeAirline = Type.GetTypeFromCLSID(new Guid(`

    `//  "{F29EAEEE-D445-403B-B89E-C8C502B115D8}"));`

   

    `// Create an instance of the object.`

    `objAirlineLateBound = Activator.CreateInstance(`

        `objTypeAirline);`

    `// Invoke the GetAirlineTiming method.`

    `String str =  (String)objTypeAirline.InvokeMember(`

        `"GetAirlineTiming",`

        `BindingFlags.Default │ BindingFlags.InvokeMethod, `

        `null, `

        `objAirlineLateBound, `

        `arrayInputParams);`

    `System.Console.WriteLine("Late Bound Call - Air Scooby " +`

        `"Arrives at : {0}",str);`

    `// Get the value of the LocalTimeAtOrlando property.`

    `String strTime = (String)objTypeAirline.InvokeMember(`

        `"LocalTimeAtOrlando",`

        `BindingFlags.Default │ BindingFlags.GetProperty, `

        `null, `

        `objAirlineLateBound,`

        `new object[]{});`

    `Console.WriteLine ("Late Bound Call - Local Time at " +`

        `"Orlando, Florida is: {0}", strTime);`


```
}/* end try */
catch(COMException e)
{
```


    `System.Console.WriteLine("Error code : {0},`

        `Error message : {1}", `

        `e.ErrorCode, e.Message);`


```
}/* end catch */
```



### A .NET View on COM Threading Models and Apartments

As you know, a thread must declare its affiliation to an STA or MTA before it can call into a COM object. STA client threads call CoInitialize(NULL) or CoInitializeEx(0, COINIT_APARTMENTTHREADED) to enter an STA. MTA threads call CoInitializeEx(0, COINIT_MULTITHREADED) to enter an MTA. Similarly, in the .NET managed world, you have the option of allowing the calling thread in the managed space declare its apartment affinity.

By default, the calling thread in a managed application chooses to live in an MTA. It’s as though the calling thread initialized itself by calling CoInitialize­Ex(0, COINIT_MULTITHREADED). But think about the overhead and performance penalties you’d incur if the application were calling an STA COM component that was designed to be apartment threaded. The incompatible apartments would incur the overhead of an additional proxy/stub pair, which is certainly a performance penalty.

You can override the default choice of apartment for a managed thread in a .NET application by using the ApartmentState property of the System.Threading.Thread class. The ApartmentState property takes one of the following enumeration values: MTA, STA, or Unknown. The ApartmentState.Unknown value is equivalent to the default MTA behavior. You’ll need to specify the ApartmentState for the calling thread before you make any calls to the COM object. It’s not possible to change the ApartmentState after the COM object has been created. Therefore, it makes sense to set the thread’s ApartmentState as early as possible in your code, as shown here:


```
// Set the client thread's ApartmentState to enter an STA.
Thread.CurrentThread.ApartmentState = ApartmentSTate.STA;

// Create our COM object through the COM interop.
MySTA objSTA = new MySTA();
objSTA.MyMethod()
```


You can also tag your managed client’s Main entry point method with the STAThread attribute or the MTAThread attribute to start the client with the desired threading affiliation for consuming COM components. For example, take a look at this code snippet:


```
public class HelloThreadingModelApp {
```


    `[STAThread]`

    `static public void Main(String[] args) {`

  

        `System.Console.WriteLine("The apartment state is: {0}", `

            `Thread.CurrentThread.ApartmentState.ToString());`

    `}/* end Main */`


```
}/* end class */
```


Here’s the output from this program:


```
The apartment state is: STA 
```


If you set the MTAThread attribute, the client’s ApartmentState property is set to MTA. If no thread state attribute is specified in the client’s Main entry point or if the ApartmentState property isn’t set for the thread from which the COM component is created, the ApartmentState property is set to Unknown, which defaults to MTA behavior.

**Chapter 22 skipped from Inside C#**


### Code Access Security

Code access security (CAS) is a feature of the .NET Framework that allows you to establish and enforce security restrictions on assemblies and the code within them. As it loads an assembly, the .NET Framework grants that assembly a set of permissions to access system resources—such as the file system, the Registry, printers, the environment table, and so on. A group of permissions is known as a permission set, and these permissions are based on security policy. There’s a standard set of permission sets, and an administrator can create new permission sets. There’s also a standard set of code groups, and an administrator can create new code groups. A code group maps assemblies to permission sets. This mapping is done by gathering evidence about an assembly, including its strong-named identity. The result is that an assembly with a particular identity is mapped to a specific set of access permissions. The security policy system is entirely open-ended and configurable through administrative tools supplied with the .NET Framework SDK. Your code can also make programmatic checks and requests for permissions.


### Configuring Security

Two tools shipped with the .NET Framework SDK allow you to configure security: CASpol.exe and MSCorCfg.msc. The first is a command-line utility, the second a Microsoft Management Console (MMC) snap-in. The graphical user interface of the MSCorCfg MMC snap-in is easier to use and allows you to visualize the overall security configuration more readily. CASpol is quicker and can be used in scripts or batch files. To explore the use of these tools, we’ll set up a new permission set and a new code group hierarchy and test this structure with a specific assembly. We’ll do this test first with MSCorCfg and then tear the structure down and set it up again with CASpol.


## Assemblies

In .NET, Assemblies are components. Assemblies, which may be composed of one or more DLL or EXE files, are the unit of deployment. You do not deploy individual DLLs or EXEs. Security evidence and versioning are based on the assembly. Assemblies contain Microsoft Intermediate Language (MSIL) instructions, resource data, and metadata. Since metadata describes the content of the assembly, the assembly does not require any external description, such as in the system registry. .NET components are much simpler and less error prone to install and uninstall than traditional COM components, which had extensive registry entries.

A digital signature is required before an assembly can be deployed in the global assembly cache. Digitally signed assemblies provide cryptographically generated verification information that can be used by the CLR to enforce crucial dependency rules when locating and loading assemblies. This is distinct from the security verification that is done to make sure that code is type safe.

The identity of an unsigned assembly is defined simply as a human-readable name, along with a version number. The identity of a digitally signed assembly is defined by a unique cryptographic key pair. Optionally, an assembly's identity may also include a culture code for supporting culturally specific character sets and string formats.

An assembly's version can be checked, so that the CLR can insure that the same assembly version with which the client was built and tested is loaded. This eliminates the infamous "DLL Hell" problem, where Windows applications could easily break when an older version was replaced with a newer version (or vice versa). A digitally signed assembly can be used to verify that the assembly contents were not altered after it was digitally signed. Not only will you not accidentally use the wrong version, but you will not be tricked into using a maliciously tampered component that could do serious harm.

Although there is often a one-to-one correspondence between namespace and assembly, an assembly may contain multiple namespaces, and one namespace may be distributed among multiple assemblies. While there is often a one-to-one correspondence between assembly and binary code file (i.e., DLL or EXE), one assembly can span multiple binary code files. An assembly is the unit of deployment; an application is the unit of configuration.


### Manifests

As part of its metadata, every assembly has a manifest . This describes what is in the assembly: identification information (name, version, etc.), a list of the types and resources in the assembly, a list of modules, a map to connect public types with the implementing code, and a list of assemblies referenced by this assembly.

Even the simplest program has a manifest. You can examine that manifest using `ILDasm`, which is provided as part of your development environment.


### Multimodule Assemblies

Assemblies can consist of more than one module, though this isn't supported by Visual Studio 2005.

A single-module assembly has a single file that can be an EXE or DLL file. This single module contains all the types and implementations for the application. The assembly manifest is embedded within this module.

Each module has a manifest of its own that is separate from the assembly manifest. The module manifest lists the assemblies referenced by that particular module. In addition, if the module declares any types, these are listed in the manifest along with the code to implement the module. A module can also contain resources, such as the images needed by that module.

A multimodule assembly consists of multiple files (zero or one EXE and zero or more DLL files, though you must have at least one EXE or DLL). The assembly manifest in this case can reside in a standalone file, or it can be embedded in one of the modules. When the assembly is referenced, the runtime loads the file containing the manifest and then loads the required modules as needed.

Assemblies come in two flavors: private and shared. Private assemblies are intended to be used by only one application; shared assemblies are intended to be shared among many applications.

All the assemblies you've built so far are private. By default, when you compile a C# application, a private assembly is created. The files for a private assembly are all kept in the same folder (or in a tree of subfolders). This tree of folders is isolated from the rest of the system, as nothing other than the one application depends on it, and you can redeploy this application to another machine just by copying the folder and its subfolders.

A private assembly can have any name you choose. It doesn't matter if that name clashes with assemblies in another application; the names are local only to a single application.


## LINQ

[https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-a-collection-of-objects](https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-a-collection-of-objects)

NUnit Framework:

Add NUnit and NUnit3TestAdapter.

Create a NUnit type project

Add code:

namespace NUnitTestProject;

public class Tests

{

    [SetUp]

    public void Setup()

    {

    }

    [Test]

    public void Test1()

    {

        string myString = "Test 123 \n \t.";

        string result = myString.ToUpper();

        Assert.AreEqual("TEST 123 \n \t.", result);

    }

    [Test]

    public void Test2()

    {

        string myString = "Test 1234 \n \t.";

        string result = myString.ToUpper();

        Assert.AreEqual("TEST 1231 \n \t.", result);

    }

}

Run from console using: “dotnet test”.

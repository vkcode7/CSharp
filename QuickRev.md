```c#
// Declare an enum
enum Direction { North, East, South, West };
Direction PlayerDirection = Direction.North;
```

#### Using static directive
The static members of a static class can be accessed without specifying the type name, so Console.WriteLine() can be simplified to WriteLine(). This is done with the using static directive. You can combine both modifiers (global and static) to import the static members from a type in all source files in your project.

```c#
using static System.Console;
global using static System.Console; //now it can be accessed in other code files too in the project

// you can create an alias too with "using"
using aliasname = PC.MyCompany.Project;

WriteLine("No need to use Console.WriteLine because of static keyword");
```

#### Access modifiers
<table>
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

#### class access specifier
In C#, when a class is declared without specifying an access modifier, the default access modifier is internal. This means that the class is accessible within the same assembly (or project), but not from outside the assembly. The above is equivalent to:
```c#
internal class A {}
```

In C#, a <strong><code>private class A {}</code></strong> declaration means that the class <code>A</code> is only accessible within the containing class or struct. This is a rarely used construct in C# because nested private classes are typically used for implementation details that should not be exposed outside of their containing class.

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

Other KeyWords that can be used while declaring a class in c#: static, unsafe, abstract, sealed, partial. <strong><code>public static class A {}</code></strong>

#### Keywords for class members:

1. **static**: Indicates that the member belongs to the type itself, rather than to instances of the type.
2. **readonly**: Specifies that the member can only be assigned a value during initialization or in a constructor and cannot be modified afterwards.
   <code>public <strong>readonly</strong> int ReadOnlyField = 10;</code>
3. <strong>const</strong>: Declares a constant member whose value cannot be changed.
   <code>public <strong>const</strong> int ConstField = 100;</code>
4. <strong>abstract</strong>: Indicates that the member does not have implementation in the current class and must be implemented by derived classes.
5. <strong>virtual</strong>: Allows the member to be overridden in derived classes.
   <strong><code>public virtual void VirtualMethod(){...}</code></strong>
6. <strong>override</strong>: Overrides a virtual member inherited from a base class.
   <strong><code>public override void VirtualMethod(){...}</code></strong>
7. <strong>extern</strong>: Specifies that the method is implemented externally in native code (usually used in conjunction with DllImport).
8. <strong>unsafe</strong>: Indicates that the member contains unsafe code that uses pointer types and performs unsafe operations.
9. <strong>volatile</strong>: Indicates that the member may be modified by multiple threads that are executing at the same time. 
    <code>private <strong>volatile</strong> bool isRunning = true;</code>
    <code>volatile</code> ensures visibility of the most up-to-date value across threads, you still need synchronization mechanisms to ensure atomicity for compound operations.


#### Null-conditional operators ?. and ?[]
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

#### ?? and ??= operators - the null-coalescing operators

The null-coalescing operator `??` returns the value of its left-hand operand if it isn't `null`; otherwise, it evaluates the right-hand operand and returns its result. 
```c#
private static void Display<T>(T a, T backup)
{
    Console.WriteLine(a ?? backup);
}

List<int> numbers = null;
int? a = null;

Console.WriteLine((numbers is null)); // expected: true
```

??=<br>
if numbers is null, initialize it. Then, add 5 to numbers, otherwise keep the numbers as is.
```c#
(numbers ??= new List<int>()).Add(5);
```

#### Nullable ?
```c#
int i = 23;
object iBoxed = i;
int? jNullable = 7; //Nullable int; means null can be assigned to it
if (iBoxed is int a && jNullable is int b)
{
    Console.WriteLine(a + b);  // output 30
}
```

#### Pointer related operators - &, *, ->, [] 
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

The operand of the `&` operator must be a fixed variable. _Fixed_ variables are variables that reside in storage locations that are unaffected by operation of the [garbage collector]

You can get the address of a movable variable if you "fix", or "pin", it with a [fixed statement]

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

#### stackalloc
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

#### Arrays
```c#
string[] drinks = new string[5] { "Pepsi", "Sprite", "", "", "" };
// The additional "" are holding the place for the remaining 3 items

string[] cars = new string[] { "Ford", "Toyota" };

int [,] myRectangularArray = new int[2,3];

// imply a 4x3 array
int[,] rectangularArray =
{
{0,1,2}, {3,4,5}, {6,7,8}, {9,10,11}
};

\\ Jagged Arrays
const int rows = 2;

// declare the jagged array as 2 rows high
int[][] jaggedArray = new int[rows][];

// the first row has 5 elements
jaggedArray[0] = new int[5];

// a row with 2 elements
jaggedArray[1] = new int[2];
```

#### Operator overloading - predefined unary, arithmetic, equality and comparison operators
Use the operator keyword to declare an operator. An operator declaration must satisfy the following rules:

It includes both a public and a static modifier.
A unary operator has one input parameter. A binary operator has two input parameters. In each case, at least one parameter must have type T or T? where T is the type that contains the operator declaration.

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
```

#### Named arguments

```c#
// TIP: Method arguments can be entered on multiple lines for additional clarity
// Order does NOT matter

CharacterDescription(
   height: 72,
   level: 61,
   name: "Bob",
   age: 42
   );

static void CharacterDescription(string name, int age, int height, int level)
{
   Console.WriteLine($"{name}: level {level}, {age} years old, and height of {height} inches.");
}
```

#### Parameter arrays (params)
The parameter tagged with the params keyword must be an array type, and it must be the last parameter in the method's parameter list.

```c#
    string fromMultipleArguments = GetVowels("apple", "banana", "pear");

    string fruits[] = new string[] {"apple", "banana", pear"};
    string fromArray = GetVowels(fruits);
    string fromNull = GetVowels(null);

    static string GetVowels(params string[] input)
    {
	//
    }
```

#### Passing Arrays
```c#
   public static void DoubleValues(int[] arr) //passed as address
   {
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
         arr[ctr] = arr[ctr] * 2; //caller will now see the updated values
   }
```



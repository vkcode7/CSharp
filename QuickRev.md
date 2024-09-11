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

Other KeyWords that can be used while declaring a class in c#: static, unsafe, abstract, sealed, partial. <strong><code>public static class A {}</code></strong><br>
If one or more methods in a calss are abstract, the class definition must also be marked abstract as in <strong><code>abstract public class Window {}</code></strong>

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

# Expression Lambdas
```c#
public Point Move(int dx, int dy) => new Point(x + dx, y + dy);
public void Print() => Console.WriteLine(First + " " + Last);
// Works with operators, properties, and indexers too.
public static Complex operator +(Complex a, Complex b) => a.Add(b);
public string Name => First + " " + Last;
public Customer this[long id] => store.LookupCustomer(id);
```

#### get/set
```c#
public class Vehicle{
   private string car;
   public string Car
   {
       get { return car; }
       set { car = value; }
   }
}

// Auto implemented property =>
public string MyProperty{ get; set; } = 5;

// Get Only property (or readonly)=>
public string MyProperty{ get; }

Private set => public int CarID { get; private set; }
```

#### Calling Base Class Constructors
```c#
public ListBox( int theTop, int theLeft, string theContents):
base(theTop, theLeft) // call base constructor
```

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

#### Interface
```c#
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
```

The `interfaces` can only contain declarations, and all members are implicitly abstract and public. Beginning with **C# version 8.0**, however, an interface may define default implementations for some or all of its members.

C# doesn’t allow for multiple inheritances in classes but multiple interfaces are allowed. If interfaces are added to a class that’s also inheriting from a base class, the interfaces must follow the base class.

```c#
public class DeckOfCards : ABaseClass, IInterface, IAnotherInterface
{
  // Empty Class
}
```

#### Iterators
An iterator is an object that traverses a container, particularly lists.

The return type of an iterator can be IEnumerable, IEnumerable<T>, IAsyncEnumerable<T>, IEnumerator, or IEnumerator<T>.

##### The IEnumerable and IEnumerator
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

#### Yield 
The yield return and yield break are used when implementing an iterator (IEnumerable). The yield return statement returns the next element in the sequence, whereas yield break ends the iteration.
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

#### What is a struct?

Unlike classes, structs are value types, not reference types.

A struct can be declared without using the new keyword. All value types (int, char, bool) are structs, which is why we can declare them without using the new keyword.

Structs inherit from System.ValueType, cannot be inherited from another Struct or Class, and cannot be a base class. A null value can be assigned to a struct as it can be used as a nullable type.

#### What is a record?
A record (C# 9) is a reference type that makes it easier to create immutable reference types and provides equality comparisons. C# 10 introduces record struct types too.

It’s important to point out that, when records are created in the above manner, they’re immutable, meaning that they cannot be changed. This can be seen in the following code:
```c#
Student student1 = new("Pablo", "Exam 1", 97);

student1.Grade = 98; // Error because the value can not be changed
Console.WriteLine(student1);

public record Student(string Name, string Assignment, int Grade);
```
Records can also use the ***deconstruct*** method to separate the record into component properties.
```c#
var (studentName, studentAssignment, studentGrade) = student1; // Deconstruct
```
A method can be added to the record class. These methods are similar to class methods and are called with record objects. Records can inherit from other records too.
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

#### List
```c#
// Methods: Add, Remove, Insert, RemoveAt, Sort, Clear, ToArray

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

### A LinkedList 
is generally slower than a regular list, but it can be beneficial when adding or removing items in the middle of a list.<br>
Key methods are AddFirst, AddLast, AddBefore, AddAfter, Contains, Find, Remove, RemoveFirst, RemoveLast. Every node in a LinkedList<T> object is of the type LinkedListNode<T>
```c#

        // Using LinkedList class
        LinkedList<String> my_list = new LinkedList<String>();


        // Adding elements in the LinkedList
        // Using AddLast() method
        my_list.AddLast("Zoya");
        my_list.AddLast("Shilpa");
```

#### What is a dictionary?
A dictionary consists of a key and a value. In an array, the key is created automatically (0, 1, and so on). With dictionaries, the key name can be set to something meaningful. As with lists, dictionaries use generics
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

#### What is a tuple?
A Tuple can be thought of much like an array, but a Tuple collection can contain different data types. Classes of the Tuple type are generic containers and can hold 1-8 items.
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
We can use a Tuple as the return type in a method. 
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

```c#
public (string FName, string MName, string LName, int Age) GetPersonalInfo(string id)
{
    PersonInfo per = PersonInfo.RetrieveInfoById(id);
    return (per.FirstName, per.MiddleName, per.LastName, per.Age);
}

var person = GetPersonalInfo("111111111");
Console.WriteLine($"{person.FName} {person.LName}: age = {person.Age}");
```

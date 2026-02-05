When you create a class in C#, it automatically inherits several interfaces and methods. Here's a comprehensive overview:

```c#
employees.Sort(Comparer<Employee>.Create((x, y) => x.Name.CompareTo(y.Name)));  //IComparer

#region IComparable<T> Implementation (Recommended for sortable objects) - implemented within the class:

public int CompareTo(PersonExample other)
{
    if (other == null) return 1;
    
    int nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
    return nameComparison != 0 ? nameComparison : Age.CompareTo(other.Age);
}
```



## What Every C# Class Automatically Inherits
From System.Object (automatically inherited):

```bash
ToString() - String representation of the object
Equals(object) - Reference equality by default
GetHashCode() - Hash code for collections
GetType() - Runtime type information
ReferenceEquals() - Reference comparison (static)
MemberwiseClone() - Shallow copy (protected)
Finalize() - Destructor (protected, virtual)
```
## Recommended Interfaces to Implement
### Essential (High Priority)

#### Override ToString()

Always recommended for debugging and logging
Provides meaningful string representation

#### IEquatable<T>
- Type-safe equality comparison
- Better performance than object.Equals()
- Must also override Equals(object) and GetHashCode()

### Very Common (Medium Priority)

#### IComparable<T>
- For objects that have natural ordering
- Enables sorting in collections
- Required for SortedSet<T>, SortedList<T>, etc.

#### Override GetHashCode() and Equals(object)
- MANDATORY if you implement IEquatable<T>
- Required for proper behavior in hash-based collections (Dictionary, HashSet)

You must override GetHashCode() in these cases:

- You override Equals(): To ensure the hash code contract is maintained. If 2 objects are equal, they should return same hash code.
- Your type is used in hash-based collections: If your objects will be keys in a Dictionary or elements in a HashSet, a consistent GetHashCode() is required.
- You want deterministic behavior: The default GetHashCode() for reference types might vary between runs or .NET versions, which can be problematic for persistence or distributed systems.

### Situational (Based on Needs)
INotifyPropertyChanged
- For data binding scenarios (WPF, WinForms, etc.)
- Notifies UI when properties change

ICloneable
- When you need to create copies of objects
- Consider typed Clone() methods instead

IDisposable
- When your class holds unmanaged resources
- Files, network connections, database connections, etc.

IFormattable
- For custom string formatting
- Works with string.Format() and interpolation

### Specialized Interfaces
- IEnumerable<T> - For collection-like classes
- ICollection<T> - For modifiable collections
- IComparer<T> - For custom comparison logic
- IConvertible - For type conversion scenarios

### Best Practices
```bash
Always override ToString() - Makes debugging much easier
If you override Equals(), also override GetHashCode() - Critical for collections
Implement IEquatable<T> for value semantics - Better performance and type safety
Consider immutability - Simpler equality and hash code implementation
Use HashCode.Combine() in .NET Core 2.1+ - Safer hash code generation
Implement operator overloads when you implement equality/comparison interfaces
```

```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;

// Every class in C# automatically inherits from System.Object
// This means every class gets these methods for free:
// - ToString()
// - Equals(object)
// - GetHashCode()
// - GetType()
// - ReferenceEquals()
// - MemberwiseClone() [protected]
// - Finalize() [destructor, protected]

public class PersonExample : IEquatable<PersonExample>, 
                            IComparable<PersonExample>, 
                            ICloneable,
                            INotifyPropertyChanged
{
    private string _name;
    private int _age;

    public string Name 
    { 
        get => _name; 
        set 
        { 
            _name = value; 
            OnPropertyChanged(nameof(Name));
        }
    }
    
    public int Age 
    { 
        get => _age; 
        set 
        { 
            _age = value; 
            OnPropertyChanged(nameof(Age));
        }
    }

    public PersonExample(string name, int age)
    {
        Name = name;
        Age = age;
    }

    #region Object Overrides (Inherited from System.Object)
    
    // Override ToString() - highly recommended
    public override string ToString()
    {
        return $"{Name}, Age: {Age}";
    }

    // Override Equals(object) - recommended when you implement IEquatable<T>
    public override bool Equals(object obj)
    {
        return Equals(obj as PersonExample);
    }

    // Override GetHashCode() - MUST override when you override Equals
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }

    #endregion

    #region IEquatable<T> Implementation (Recommended)
    
    // Provides type-safe equality comparison
    public bool Equals(PersonExample other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name, StringComparison.Ordinal) && Age == other.Age;
    }

    // Operator overloads (optional but often useful)
    public static bool operator ==(PersonExample left, PersonExample right)
    {
        return EqualityComparer<PersonExample>.Default.Equals(left, right);
    }

    public static bool operator !=(PersonExample left, PersonExample right)
    {
        return !(left == right);
    }

    #endregion

    #region IComparable<T> Implementation (Recommended for sortable objects)
    
    public int CompareTo(PersonExample other)
    {
        if (other == null) return 1;
        
        int nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
        return nameComparison != 0 ? nameComparison : Age.CompareTo(other.Age);
    }

    // Optional: Comparison operators
    public static bool operator <(PersonExample left, PersonExample right)
    {
        return left?.CompareTo(right) < 0;
    }

    public static bool operator >(PersonExample left, PersonExample right)
    {
        return left?.CompareTo(right) > 0;
    }

    public static bool operator <=(PersonExample left, PersonExample right)
    {
        return left?.CompareTo(right) <= 0;
    }

    public static bool operator >=(PersonExample left, PersonExample right)
    {
        return left?.CompareTo(right) >= 0;
    }

    #endregion

    #region ICloneable Implementation (Optional)
    
    public object Clone()
    {
        // Shallow copy for this simple example
        return new PersonExample(Name, Age);
    }

    // Better: Add typed Clone method
    public PersonExample CloneTyped()
    {
        return new PersonExample(Name, Age);
    }

    #endregion

    #region INotifyPropertyChanged Implementation (For data binding scenarios)
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}

// Example of a value-type-like class (immutable)
public class ImmutablePerson : IEquatable<ImmutablePerson>, IComparable<ImmutablePerson>
{
    public string Name { get; }
    public int Age { get; }

    public ImmutablePerson(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    // For immutable objects, equality and hash code are simpler
    public override bool Equals(object obj) => Equals(obj as ImmutablePerson);
    
    public bool Equals(ImmutablePerson other)
    {
        return other != null && Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Age);
    
    public int CompareTo(ImmutablePerson other)
    {
        if (other == null) return 1;
        int nameComp = string.Compare(Name, other.Name, StringComparison.Ordinal);
        return nameComp != 0 ? nameComp : Age.CompareTo(other.Age);
    }

    public override string ToString() => $"{Name} ({Age})";

    // Equality operators
    public static bool operator ==(ImmutablePerson left, ImmutablePerson right) =>
        EqualityComparer<ImmutablePerson>.Default.Equals(left, right);
    
    public static bool operator !=(ImmutablePerson left, ImmutablePerson right) => !(left == right);
}

// Example usage and demonstrations
public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Automatic Object Inheritance Demo ===");
        
        var person1 = new PersonExample("Alice", 30);
        var person2 = new PersonExample("Alice", 30);
        var person3 = new PersonExample("Bob", 25);

        // ToString() override in action
        Console.WriteLine($"person1.ToString(): {person1}");
        Console.WriteLine($"person1.GetType(): {person1.GetType()}");
        Console.WriteLine($"person1.GetType().BaseType: {person1.GetType().BaseType}");

        Console.WriteLine("\n=== Equality Comparisons ===");
        
        // Object.Equals vs IEquatable<T>.Equals
        Console.WriteLine($"person1.Equals(person2): {person1.Equals(person2)}");
        Console.WriteLine($"person1 == person2: {person1 == person2}");
        Console.WriteLine($"ReferenceEquals(person1, person2): {ReferenceEquals(person1, person2)}");

        Console.WriteLine("\n=== Hash Codes ===");
        Console.WriteLine($"person1.GetHashCode(): {person1.GetHashCode()}");
        Console.WriteLine($"person2.GetHashCode(): {person2.GetHashCode()}");
        Console.WriteLine($"person3.GetHashCode(): {person3.GetHashCode()}");

        Console.WriteLine("\n=== Sorting with IComparable ===");
        var people = new List<PersonExample> { person3, person1, person2 };
        people.Sort();
        
        Console.WriteLine("Sorted people:");
        people.ForEach(p => Console.WriteLine($"  {p}"));

        Console.WriteLine("\n=== Using in Collections ===");
        
        // Works in HashSet because we implemented Equals and GetHashCode
        var uniquePeople = new HashSet<PersonExample> { person1, person2, person3 };
        Console.WriteLine($"Unique people count: {uniquePeople.Count}"); // Should be 2

        // Works in SortedSet because we implemented IComparable
        var sortedPeople = new SortedSet<PersonExample> { person3, person1, person2 };
        Console.WriteLine("SortedSet contents:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"  {person}");
        }

        Console.WriteLine("\n=== Property Change Notifications ===");
        person1.PropertyChanged += (sender, args) => 
            Console.WriteLine($"Property {args.PropertyName} changed on {sender}");
        
        person1.Age = 31; // Triggers PropertyChanged event

        Console.WriteLine("\n=== Cloning ===");
        var clonedPerson = person1.CloneTyped();
        Console.WriteLine($"Original: {person1}");
        Console.WriteLine($"Clone: {clonedPerson}");
        Console.WriteLine($"Are same reference: {ReferenceEquals(person1, clonedPerson)}");
        Console.WriteLine($"Are equal: {person1.Equals(clonedPerson)}");
    }
}
```


This comprehensive example shows different ways to implement and use IComparer<T>:
## Key IComparer<T> Concepts
### 1. Purpose

- IComparer<T> defines external comparison logic
- Unlike IComparable<T> (which is implemented by the class being compared), IComparer<T> is implemented separately
- Allows multiple different sorting strategies for the same type

### 2. Compare Method Contract
The Compare(T x, T y) method must return:

- Negative value: x is less than y
- Zero: x equals y
- Positive value: x is greater than y

### 3. Common Use Cases

```c#
// Single Property Sorting:
public class EmployeeNameComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y) =>
        string.Compare(x.Name, y.Name, StringComparison.Ordinal);
}

// Reverse/Descending Order:
// Note: y.CompareTo(x) instead of x.CompareTo(y)
return y.Salary.CompareTo(x.Salary);

// Multi-level Sorting:
// Sort by Dept, then Salary (desc), then Name
int deptComp = string.Compare(x.Department, y.Department);
if (deptComp != 0) return deptComp;
// ... continue with next criteria

// Modern Alternative: Lambda Expressions
// Instead of creating a class:
employees.Sort(Comparer<Employee>.Create((x, y) => x.Name.CompareTo(y.Name)));
```

### 4. Where IComparer is Used
```c#
List<T>.Sort(IComparer<T>)
Array.Sort<T>(T[], IComparer<T>)
SortedSet<T> constructor
SortedDictionary<TKey, TValue> constructor
LINQ OrderBy() and OrderByDescending()
```

### 5. IComparer vs IComparable
- IComparable<T>: Implemented by the class itself, Defines natural ordering, one comparison per class, obj.CompareTo(other)
- IComparer<T>: Implemented separately, Defines custom ordering, Multiple comparisons possible, comparer.Compare(obj1, obj2)
  
### 6. When to use each:

- IComparer classes: Complex logic, reusability, performance-critical scenarios
- Lambda expressions: Simple, one-off comparisons

### 7. Matrix and Tuples
The correct way to create an array of direction tuples in C#:
```c#
    var directions = new (int, int)[]
    {
        (-1, 0),  // up
        (1, 0),   // down  
        (0, -1),  // left
        (0, 1)    // right
    };
    //or
    (int, int)[] directions =
    {
        (-1, 0),
        (1, 0),
        (0, -1),
        (0, 1)
    };
    
    foreach (var (di, dj) in directions)
    {
        Console.WriteLine($"{di}: {dj}");
    }

    // Empty matrix, specify dimensions
    int[,] matrix1 = new int[3, 4];  // 3 rows, 4 columns
    
    // With values (dimensions inferred from initializer)
    int[,] matrix2 = new int[,]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
    };
```

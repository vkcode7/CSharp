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

\\you can create an alias too with "using"
using aliasname = PC.MyCompany.Project;

WriteLine("No need to use Console.WriteLine because of static keyword");
```

## Access modifiers
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

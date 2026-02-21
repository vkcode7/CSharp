### C#: Customer Orders

**Description**

Implement a customer order reporting system with the following requirements.

**Predefined Classes (provided in the header):**

**Customer** class:
- `Id` (int)
- `Name` (string)

**Order** class:
- `Customer` (Customer)
- `Amount` (int)
- `Date` (DateTime)

Create a `Reporting` class that implements the `IReporting` interface.  
Declare a field of type `List<Order>` to store the orders.

Implement the following methods:

1. `AddOrder(Order order)`  
   Adds an order to the orders list.

2. `TotalOrderAmountPerCustomer(int customerId)`  
   Calculates and returns the total order amount for a specific customer.

3. `TotalOrderAmountOnDate(DateTime date)`  
   Calculates and returns the total order amount for a specific date.

4. `GetOrders(int customerId)`  
   Retrieves the orders associated with a specific customer.

**Sample Behavior / Expected Output Format (from examples)**

The testing system appears to:
- First read number of customers (n), then n lines of customer data (id + name)
- Then read number of orders (m), then m lines of order data (customerId amount date)
- Then read one date to query `TotalOrderAmountOnDate()`
- Then (implicitly) calls `TotalOrderAmountPerCustomer()` for each customer and prints results

**Sample Output Format**

```
4/4/2023:0
Customer-1:193
Customer-2:752
```

or

```
4/4/2023:0
Alex:752
Robin:193
```

or

```
2/2/2023:0
Customer-01:970
```

**Key Observations from Samples**
- Date is printed in M/d/yyyy format (e.g. 4/4/2023)
- Followed by colon and the total amount for that date
- Then one line per customer in format: `Customer-X:amount` or using actual name
- When no orders exist on the queried date → shows `:0`
- Customer lines seem to be printed for all customers (even those with 0 total)
- Order of customer lines appears to follow the order they were input

**Note**
I/O and method calls are handled by the provided code stubs / testing framework.  
You only need to implement the `Reporting` class with the four required methods.

```c#
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Order
{
    public Customer Customer { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}
interface IReporting
{
    void AddOrder(Order order);
    int TotalOrderAmountPerCustomer(int customerId);
    int TotalOrderAmountOnDate(DateTime date);
    (List<Order> order, int customerId) GetOrder(int customerId);
}
class Reporting : IReporting
{

    /*
     * Implement the 'IReporting' interface below..
     */

    public Reporting()
    {
        m_orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        m_orders.Add(order); 
    }

    public int TotalOrderAmountPerCustomer(int customerId)
    {
        var (orders, Id) = GetOrder(customerId);
        
        int totalAmt = 0;
        
        foreach(var order in orders)
            totalAmt += order.Amount;
        
        return totalAmt;
    }

    public int TotalOrderAmountOnDate(DateTime date)
    {
        var orders = m_orders.Where( (order) => 
            order.Date.Date == date.Date).ToList();
        
        int totalAmt = 0;
        
        foreach(var order in orders)
            totalAmt += order.Amount;
        
        return totalAmt;
    }
    
    public (List<Order> order, int customerId) GetOrder(int customerId)
    {
        var orders = m_orders.Where( (order) => 
            order.Customer.Id == customerId
        ).ToList();
        
        return (orders, customerId);
    }
 

    private List<Order> m_orders;
}


class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        List<Customer> customers = new List<Customer>();
        IReporting reporting = new Reporting();
        int cCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= cCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            Customer e = new Customer();
            e.Id = Convert.ToInt32(a[0]);
            e.Name = a[1];
            customers.Add(e);
        } 
        int oCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= oCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            var customerId = Convert.ToInt32(a[0]);
            var customer = customers.FirstOrDefault(x=>x.Id == customerId);
            Order e = new Order();
            e.Customer = customer;
            e.Amount = Convert.ToInt32(a[1]);
            e.Date = Convert.ToDateTime(a[2]);
            reporting.AddOrder(e);
        }
        var b = Console.ReadLine().Trim();
        var totalOrderAmountOnDate = reporting.TotalOrderAmountOnDate(Convert.ToDateTime(b));
        textWriter.WriteLine(b + ":" + totalOrderAmountOnDate);
        
        foreach (var c in customers)
        {
            int totalOrderAmount = reporting.TotalOrderAmountPerCustomer(c.Id);
            textWriter.WriteLine(c.Name + ":" + totalOrderAmount);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
```

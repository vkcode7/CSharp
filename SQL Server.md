
## SQL SERVER

### INNER JOIN

The `INNER JOIN` keyword selects records that have matching values in both tables.
```sql
SELECT column_name(s)
FROM table1
INNER JOIN table2
ON table1.column_name = table2.column_name
```

### LEFT JOIN
```sql
SELECT column_name(s)
FROM table1
LEFT JOIN table2
ON table1.column_name = table2.column_name;
```

The `LEFT JOIN` keyword returns all records from the left table (table1), and the matching records from the right table (table2). The result is 0 records from the right side, if there is no match.

### RIGHT JOIN
```sql
SELECT column_name(s)
FROM table1
RIGHT JOIN table2
ON table1.column_name = table2.column_name;
```

The `RIGHT JOIN` keyword returns all records from the right table (table2), and the matching records from the left table (table1). The result is 0 records from the left side, if there is no match.

The `FULL OUTER JOIN` keyword returns all records when there is a match in left (table1) or right (table2) table records.

Tip: `FULL OUTER JOIN` and `FULL JOIN` are the same.

```sql
SELECT column_name(s)
FROM table1
FULL OUTER JOIN table2
ON table1.column_name = table2.column_name
WHERE condition;

SELF JOIN - on same tables
SELECT column_name(s)
FROM table1 T1, table1 T2
WHERE condition;
```

### UNION
The `UNION` operator is used to combine the result-set of two or more `SELECT` statements.
```sql
SELECT City FROM Customers
UNION
SELECT City FROM Suppliers
ORDER BY City;
```

### UNION ALL: 
The `UNION` operator selects only distinct values by default. To allow duplicate values, use `UNION ALL`:

### RANK:
```sql
SELECT Studentname,
   	Subject,
   	Marks,
   	RANK() OVER(PARTITION BY StudentName ORDER BY Marks ) Rank
FROM ExamResult
ORDER BY Studentname,
     	Rank;
```

### DENSE_RANK
```sql
SELECT Studentname,
   	Subject,
   	Marks,
   	DENSE_RANK() OVER(PARTITION BY StudentName ORDER BY Marks ) Rank
FROM ExamResult
ORDER BY Studentname,
     	Rank
```

Similar values are ranked same (say n) in both but next value will be ranked n+1 in dense rank but n+2 in rank (assuming there were rows with same value). There will be gaps in rank when RANK is used, no gaps with DENSE_RANK.

**<span style="text-decoration:underline;">To Find Nth Highest Salary Using A Sub-Query</span>**
1. **<code>SELECT TOP 1 SALARY  </code></strong>
2. <strong><code>FROM (  </code></strong>
3. <code>      <strong>SELECT</strong> <strong>DISTINCT</strong> <strong>TOP</strong> 1 SALARY  </code>
4. <code>      <strong>FROM</strong> tbl_Employees  </code>
5. <code>      <strong>ORDER</strong> <strong>BY</strong> SALARY <strong>DESC</strong>  </code>
6. <code>      ) RESULT  </code>
7. <strong><code>ORDER BY SALARY </code></strong>

```sql
SELECT top 1 OrderID FROM (select top 3 orderid from orders order by orderid desc) order by orderid asc
```

### To Find The Nth Highest Salary Using CTE
1. **<code>WITH RESULT AS  </code></strong>
2. <code>(  </code>
3. <code>    <strong>SELECT</strong> SALARY,  </code>
4. <code>           DENSE_RANK() OVER (<strong>ORDER</strong> <strong>BY</strong> SALARY <strong>DESC</strong>) <strong>AS</strong> DENSERANK  </code>
5. <code>    <strong>FROM</strong> tbl_Employees  </code>
6. <code>)  </code>
7. <strong><code>SELECT TOP 1 SALARY  </code></strong>
8. <strong><code>FROM RESULT  </code></strong>
9. <strong><code>WHERE DENSERANK = 1 &lt;<--- use 3 for 3rd highest</code></strong>

### 2nd highest salary:

```sql
WITH CTE AS
(
select Name, Salary, RN = ROW_NUMBER()
OVER (ORDER BY Salary desc)
FROM Employee
)

select Name, salary from CTE where RN = 2
```

A **common table expression**, or CTE, is a temporary named result set created from a simple `SELECT` statement that can be used in a subsequent `SELECT` statement. Each SQL CTE is like a **named query**, whose result is stored in a virtual table (a CTE) to be referenced later in the main query.

```sql
WITH my_cte AS (
  SELECT a,b,c
  FROM T1
)
SELECT a,c
FROM my_cte
WHERE ....
```

SQL Server tries always to generate the most optimized execution plan for each stored procedure the first time that the stored procedure is executed. The SQL Server Engine looks at the stored procedure passed parameter values when compiling the stored procedure, the first execution, in order to create the optimal plan including the parameters and keep that plan for future use in the plan cache. This parameter analysis process is called the **Parameter Sniffing**. It can be disabled at database level.

To overcome parameter sniffing performance issue that could occur due to forcing the same plan usage for all stored procedures parameters values we can use the **WITH RECOMPILE** option in the stored procedure definition, which will force the stored procedure compilation at each execution, creating a new execution plan for each parameter value. 

A **clustered index** defines the order in which data is physically stored in a table. Table data can be sorted in only one way, therefore, there can be only one clustered index per table. In SQL Server, the primary key constraint automatically creates a clustered index on that particular column.

To see all the indexes on a particular table execute “sp_helpindex” stored procedure. 

PRIMARY KEY constraint differs from the UNIQUE constraint in that; you can create multiple UNIQUE constraints in a table, with the ability to define only one SQL PRIMARY KEY per each table. Another difference is that **the UNIQUE constraint allows for one NULL value, but the PRIMARY KEY does not allow NULL values**

**Order of execution for SQL keywords:**

**FROM, WHERE, SELECT, ORDER BY**

**With Group BY/HAVING**

**FROM, WHERE, GROUP BY, HAVING, SELECT, ORDER BY**

```sql
CREATE VIEW view_name AS
SELECT column1, column2, ...
FROM table_name
WHERE condition;
```

**Exception Handling:**

```sql
USE AdventureWorks2014
GO
-- Basic example of TRY...CATCH

BEGIN TRY
-- Generate a divide-by-zero error  
  SELECT
    1 / 0 AS Error;
END TRY
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO
```

**IN Vs EXISTS - performance EXISTS is faster bcoz it exits when condition is met**

**DELETE duplicate rows:**

**Let Table has 4 columns ID, FirstName, LastName, Country. ID is unique PK.**

```sql
DELETE FROM [SampleDB].[dbo].[Employee]
    WHERE ID NOT IN
    (
        SELECT MAX(ID) AS MaxRecordID
        FROM [SampleDB].[dbo].[Employee]
        GROUP BY [FirstName],
             	[LastName],
             	[Country]
    );

WITH CTE([FirstName],
    [LastName],
    [Country],
    DuplicateCount)
AS (SELECT [FirstName],
       	[LastName],
       	[Country],
       	ROW_NUMBER() OVER(PARTITION BY [FirstName],
                                          [LastName],
                                          [Country]
       	ORDER BY ID) AS DuplicateCount
    FROM [SampleDB].[dbo].[Employee])
DELETE FROM CTE
WHERE DuplicateCount > 1;
```

![alt_text](table.png "image_tooltip")


**Scalar Functions: A scalar function accepts any number of parameters and returns one value.The term scalar differentiates a single, "flat" value from more complex structured values, such as arrays or result sets.  This pattern is much like that of traditional functions written in common programming language.**

**Table-Valued Functions: This type of functions returns a result set, much like a view. How ever ,unlike a view,functions can accept parameters. The inline function's syntax is quite simple.In the function definition, the return type is set to a table. A return statement is used with a select query in parenthesis.**

**Table-valued functions are "just" parameterized views. This makes them extremely powerful for encapsulating logic that would otherwise be hidden behind an opaque stored procedure.**

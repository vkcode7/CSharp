using System;
using static System.Console;

namespace dotnet
{
	public class Linq
	{
		public Linq()
		{
		}

        class Student
        {
            public int ID { get; set; }
            public string FullName { get; set; }
        }

        class Enrollment
        {
            public int StudentID { get; set; }
            public string ClassName { get; set; }
        }

        public static void LinqMain()
        {
            var students = new Student[]
            {
            new Student{ID = 0, FullName = "Jane Doe"},
            new Student{ID = 10, FullName = "John Doe"}
            };

            var classes = new Enrollment[]
            {
            new Enrollment{StudentID = 10, ClassName = "Biology"},
            new Enrollment{StudentID = 0, ClassName = "History"},
            new Enrollment{StudentID = 0, ClassName = "Chemistry"}
            };


            var query0 = (from c in classes
                          join s in students
                          on c.StudentID equals s.ID
                          select new
                          {
                              ID = c.StudentID,
                              FullName = s.FullName,
                              ClassName = c.ClassName
                          }).ToList().OrderBy(s => s.ID);

            var query1 = (from c in classes
                          join s in students
                          on c.StudentID equals s.ID
                          select new
                          {
                              s.ID,
                              s.FullName,
                              c.ClassName
                          }).ToList().OrderBy(s => s.ID);

            var query2 = from s in students
                         join c in classes
                         on s.ID equals c.StudentID
                         select new
                         {
                             s.FullName,
                             c.ClassName
                         };


            var query3 = students.Join(classes, s => s.ID, c => c.StudentID,
                        (s, c) => new
                        {
                            s.FullName,
                            c.ClassName
                        });

            foreach (var enrollment in query3)
                WriteLine($"{enrollment.FullName} is enrolled in {enrollment.ClassName}");

            /* All 4 queries return same output as below:
                Jane Doe is enrolled in History
                Jane Doe is enrolled in Chemistry
                John Doe is enrolled in Biology
            */

        }
    }
}


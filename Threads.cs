using System;
using System.Diagnostics;
using static System.Console;

namespace dotnet
{
    class ProcessTasks
    {
        static async Task<string> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            Console.WriteLine("Fire! Toast is ruined!");
            await Task.Delay(1000);
            Console.WriteLine("Remove toast from toaster");

            return "Toast is ready";
        }

        static async Task DelayTask(int time)
        {
            await Task.Delay(time);
            return;
        }

        static public void TasksDemo()
        {
            List<Task<string>> tasks = new List<Task<string>>();

            //public delegate TResult Func<in T, out TResult> (T arg);
            Func<object?, string> taskAction = (t) =>
            {
                Task delayT = DelayTask((int)t * 1000);
                delayT.Wait();

                return t.ToString() + ":" + DateTime.Now.ToLongTimeString();
            };

            for (int i = 0; i < 10; i++)
            {
                Task<string> task = Task.Factory.StartNew<string>(taskAction, i);
                tasks.Add(task);
            }

            /*
            for (int i = 0; i < 10; i++)
            {
                Task<string> task = Task.Factory.StartNew<string>((t) =>
                {
                    Task delayT = DelayTask((int)t * 1000);
                    delayT.Wait();

                    return t.ToString() + ":" + DateTime.Now.ToLongTimeString();
                }, i);
                tasks.Add(task);
            }
            */

            //Task.WaitAll(tasks.ToArray()); <- Not needed as t.Result will do the same

            foreach (var t in tasks)
                Console.WriteLine(t.Result);
        }


        public static void ThreadMain()
        {

            Console.WriteLine("initiating sleep tasks");

            Task<string> t = ToastBreadAsync(10);
            //t.Wait();
            Console.WriteLine("initiating toast");

            Console.WriteLine(t.Result);

            TasksDemo();

            Console.WriteLine("done with sleep tasks");

        }
    }

    public class Threads
	{
		public Threads()
		{
		}


        static void ThreadExample()
        {
            Thread aThread = new Thread(CountTo);
            aThread.Start(45); // 1 parameter 

            static void CountTo(object count)
            {
                for (int i = 1; i <= (int)count; i++)
                {
                    Console.WriteLine(i);
                }
            }


            Stopwatch sw = Stopwatch.StartNew();

            Thread thread = new Thread(() =>
            {
                long sum = 0;
                for (int i = 0; i < int.MaxValue; i++)
                    sum += i;

                WriteLine("Sum is: " + sum.ToString());
            });

            thread.Start();
            thread.Join();

            sw.Stop();
            WriteLine("ThreadExample: Elapsed Time: " + sw.ElapsedMilliseconds);
        }


        static void ThreadExampleWithParams(int k)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Action<object?> sumTo = delegate (object? to)
            {
                long sum = 0;
                for (int i = 0; i < (int?)to; i++)
                    sum += i;

                WriteLine("Sum is: " + sum.ToString());
            };

            ParameterizedThreadStart pts = new ParameterizedThreadStart(sumTo);
            Thread thread = new Thread(pts);

            thread.Start(k);
            thread.Join();

            sw.Stop();
            WriteLine("ThreadExampleWithParams: Elapsed Time: " + sw.ElapsedMilliseconds);
        }

        public static Task<long> TaskExample(int start, int end)
        {
            long sum = 0;

            Task<long> task = new Task<long>(() =>
            {
                for (int i = start; i < end; i++)
                    sum += i;

                WriteLine("TaskExample: Sum is: " + sum.ToString());

                return sum;
            });

            task.Start();
            return task;
        }

        public static Task<long> TaskFactoryStartNewExample(int start, int end)
        {
            Func<object?, long> taskAction = (t) =>
            {
                WriteLine(t?.ToString());
                long sum = 0;

                for (int i = start; i < end; i++)
                    sum += i;

                WriteLine("TaskFactoryStartNewExample: Sum is: " + sum.ToString());

                return sum;
            };

            Task<long> task = Task.Factory.StartNew<long>(taskAction, DateTime.Now.ToLongTimeString());
            return task;
        }

        public static void ThreadsMain()
        {
            //ThreadExample();
            ThreadExampleWithParams(int.MaxValue / 2);

            Stopwatch sw = Stopwatch.StartNew();

            Task<long> l1 = TaskExample(0, int.MaxValue / 2);
            Task<long> l2 = TaskExample(1 + (int.MaxValue / 2), int.MaxValue);

            WriteLine("TaskExample: Total Sum is: " + (l1.Result + l2.Result));

            sw.Stop();
            WriteLine("ThreadExample: Elapsed Time: " + sw.ElapsedMilliseconds);

            Stopwatch sw2 = Stopwatch.StartNew();

            Task<long> l11 = TaskFactoryStartNewExample(0, int.MaxValue / 2);
            Task<long> l22 = TaskFactoryStartNewExample(1 + (int.MaxValue / 2), int.MaxValue);

            WriteLine("TaskFactoryStartNewExample: Total Sum is: " + (l11.Result + l22.Result));

            sw2.Stop();
            WriteLine("TaskFactoryStartNewExample: Elapsed Time: " + sw2.ElapsedMilliseconds);
        }
    }
}


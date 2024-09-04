using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace dotnet
{
    //Extension method on Stack<T> class
    static class UniqueStaticPushClass
    {
        public static void UniquePush<T>(this Stack<T> _s, T t)
        {
            if (!_s.Contains(t))
                _s.Push(t);
        }
    }

    class UniqueStackDemo
    {
        //Create a Stack class that only allows unique elements
        class UniqueStack<T> : Stack<T> 
        {
            public new void Push(T t)
            {
                if (!Contains(t))
                    base.Push(t);
            }
        }

        class UniqueStack2<T>
        {
            public UniqueStack2()
            {
                _s = new Stack<T>();
            }

            public void Push(T t)
            {
                if (!_s.Contains(t))
                    _s.Push(t);
            }

            public T Pop()
            {
                return _s.Pop();
            }

            public int Count { get { return _s.Count; } }

            Stack<T> _s;
        }

        public static void TestMain()
        {
            //UniqueStack<int> us = new UniqueStack<int>();
            UniqueStack2<int> us = new UniqueStack2<int>();
            us.Push(1);
            us.Push(2);
            us.Push(2);
            us.Push(3);

            while (us.Count > 0)
                Console.WriteLine(us.Pop());

            Stack<int> stack = new Stack<int>();
            stack.UniquePush(100);
            stack.UniquePush(200);
            stack.UniquePush(200);
            stack.UniquePush(300);

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }
    }

    class MyStack
    {
        IEnumerable<object> ls = new List<object>();        // keep these two fields as they​​​​​​‌​‌​​​​‌​‌​‌​‌‌​‌​‌​‌‌​‌‌ are
        private Object[] elements;
        private int size = 0;

        public MyStack(int initialCapacity)
        {
            elements = new Object[initialCapacity];
        }

        public void Push(object o)
        {
            //0,1,2
            EnsureCapacity(); //0-1-2
            elements[size++] = o;
        }

        public object Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException();
            }


            return elements[--size];

        }

        private void EnsureCapacity()
        {
            if (elements.Length == size)
            {

                Object[] old = elements;
                elements = new Object[2 * size + 1];
                old.CopyTo(elements, 0);
            }
        }


        public static void Test2()
        {
            Console.WriteLine("test");
        }

        public static void TestMain()
        {
            MyStack stack = new MyStack(10000);

            Console.WriteLine("Memory Use (approx.): " + (GC.GetTotalMemory(true) / 1024) + " KBytes");

            for (int i = 0; i < 10000; i++) // fill the stack
                stack.Push("a large, large, large, large, string " + i);

            for (int i = 0; i < 10000; i++) // empty the stack
                stack.Pop();

            Console.WriteLine("Memory Use (approx.): " + (GC.GetTotalMemory(true) / 1024) + " KBytes");
        }
    }



    public class Collections
	{
        public static void DemoMain(string[] args)
        {
            //  var descendingComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            //  var ascendingComparer = Comparer<int>.Create((x, y) => x.CompareTo(y));

            DemoLinkedList(); //heap, collection of nodes
            DemoList(); //array
            DemoStack(); //array
            DemoQueue(); //array
            DemoHashtable(); //array; ht.Add(1, "one"); order is not maintained
            DemoPriorityQueue(); //array; PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            WriteLine("Last stone weight is: " +
                LastStoneWeight(new int[] { 2,5,6,7,9,3,5,7,9,10,3,2,8}));
            DemoDictionary(); //array and hashtable; order is maintained
            DemoSortedSet(); //tree; sortedSetNumbers.Add(10);
            DemoHashSet(); //similar to dictionary, array, order is maintained; myhash1.Add("C");
            DemoSortedList(); // sl.Add(1, "one"); //implemented using array

            // implmented as a tree using SortedSet internally
            DemoSortedDictionary(); //SortedDictionary<int, string> sd = new SortedDictionary<int, string>(descendingComparer);

            //in SL elements are stored in continuous block in memory, not the case with SortedDictionary
            //in SL elements can be accessed by index
            //by default sorts in Asc order

            DemoJaggedArray();

            var t1 = Tuple.Create<int, string>(1, "hello");

            WriteLine("\nSomeEvenNumbers:");
            foreach (var i in SomeEvenNumbers(10))
                Console.Write(i + ", ");
        }

        public Collections()
		{
            //TreeSet
		}

        static void DemoLinkedList()
        {
            /* on heap, a collection of LinkedListNode
             A LinkedList is a linear data structure which stores element in the non-contiguous location.
            The elements in a linked list are linked with each other using pointers.
            Or in other words, LinkedList consists of nodes where each node contains a data field
            and a reference(link) to the next node in the list.

            It is a doubly linked list, therefore, each node points forward to the Next node and backward
            to the Previous node. It is a dynamic collection which grows, according to the need of your
            program. It also provides fast inserting and removing elements.

            Every node in a LinkedList<T> object is of the type LinkedListNode<T>

            If the LinkedList is empty, the First and Last properties contain null.

            LinkedList(): This constructor is used to create an instance of the LinkedList class that is empty.
            LinkedList(IEnumerable): This constructor is used to create an instance of the LinkedList class
            that contains elements copied from the specified IEnumerable and has sufficient
            capacity to accommodate the number of elements copied.

            AddFirst, AddLast, Clear, Remove, RemoveFirst, RemoveLast, Contains
             */
            // Create the link list.
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            Console.WriteLine("\nLinkedList Elements: ");
            foreach (string word in sentence)
            {
                Console.Write(word + " "); //prints: the fox jumps over the dog 
            }
        }

        static void DemoList()
        {
            /*
            A list is a generic whereas ArrayList is a non-generic collection.
            It is dynamic in nature means the size of the list grows, according to the need.
            If the Count becomes equal to Capacity, then the capacity of the List increased
            automatically by reallocating the internal array. The existing elements will
            be copied to the new array before the addition of the new element.

            In C#, a list is a dynamic data structure that allows elements to be added,
            removed, and accessed by index. There are several ways to implement a list in C#, including:

            The List class implements the ICollection<T>, IEnumerable<T>, IList<T>,
            IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IEnumerable, and IList interface.

            The elements present in the list are not sorted by default and elements
            are accessed by zero-based index.

            Notable methods: Remove, RemoveAll(Predicate<T>), RemoveAt(index), Clear, Sort
             */
            // Creating list using List class
            // and List<T>() Constructor
            List<int> my_list = new List<int>();

            // Adding elements to List
            // Using Add() method
            my_list.Add(496);
            my_list.Add(1000);
            my_list.Add(100);
            my_list.Add(10);
            my_list.Add(10000);

            Console.WriteLine("\nList Elements: ");

            // Accessing elements of my_list
            // Using foreach loop
            foreach (int a in my_list)
            {
                Console.Write(a + ", "); //prints: 496, 1000, 100, 10, 10000, 
            }
        }


        static void DemoStack()
        {
            /* uses Array internally: T[] _array;
            A Stack represents a last-in, first-out collection of objects.
            A stack is used to create a dynamic collection that grows, according to the
            need of your program.

            Notable methods: Push, Pop, Peek, Contains, Count, Capacity
             */
            Stack<int> st = new Stack<int>();
            st.Push(1);
            st.Push(10);
            st.Push(5);
            st.Push(4);

            Console.WriteLine("\nStack Elements: ");
            foreach (var item in st)
            {
                Console.Write(item + ", "); //prints: 4, 5, 10, 1, 
            }
        }


        static void DemoQueue()
        {
            /* uses Array internally: T[] _array;
            A Queue is used to represent a first-in, first out(FIFO) collection of objects.
            It is used when you need first-in, first-out access of items.

            When you add an item in the list, it is called enqueue.
            When you remove an item, it is called dequeue.

            Methods: Clear, Enqueue, Dequeue, Peek, Contains, Count, Capacity
            */
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(10);
            q.Enqueue(5);
            q.Enqueue(4);

            Console.WriteLine("\nQueue Elements: ");
            foreach (var item in q)
            {
                Console.Write(item + ", "); //prints: 1, 10, 5, 4, 
            }
        }

        static void DemoPriorityQueue()
        {
            //implemented as Array, private (TElement Element, TPriority Priority)[] _nodes;
            //PQ is available in .NET 6+ only
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            queue.Enqueue("Item A", 0);
            queue.Enqueue("Item B", 60);
            queue.Enqueue("Item C", 2);
            queue.Enqueue("Item D", 1);

            Console.WriteLine("\nPriorityQueue Elements: ");

            while (queue.TryDequeue(out string item, out int priority))
            {
                Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
            }
        }


        static int LastStoneWeight(int[] stones)
        {
            var heap = new PriorityQueue<int, int>();

            foreach (var stone in stones)
                heap.Enqueue(stone, 0 - stone);

            while (heap.Count > 1)
            {
                var newStone = heap.Dequeue() - heap.Dequeue();
                if (newStone > 0)
                    heap.Enqueue(newStone, 0 - newStone);
            }

            return heap.Count > 0 ? heap.Dequeue() : 0;
        }

        static void DemoHashtable()
        {
            /* 
            Internally maintains an array of Bucket, hash_coll is used in case of collisions
                private struct Bucket
                {
	                public object key;
	                public object val;
	                public int hash_coll;
                } 
             
            A Hashtable is a collection of key/value pairs that are arranged based on the
            hash code of the key. In Hashtable, the key cannot be null, but value can be.
            In hashtable, you can store elements of the same type and of the different types.

            The elements of hashtable that is a key/value pair are stored in DictionaryEntry,
            so you can also cast the key/value pairs to a DictionaryEntry.
            In Hashtable, key must be unique. Duplicate keys are not allowed.

            Methods: Clear, Remove, Add, Contains, ContainsKey, ContainsValue
            */

            Hashtable ht = new Hashtable();
            ht.Add(1, "one");
            ht.Add(5, "five");
            ht.Add("three", 3);
            ht.Add(4, "four");
            Console.WriteLine("\nHashtable Elements: "); //order is not maintained
            foreach (var item in ht.Keys)
            {
                Console.Write(item + ", "); //prints: 5, 4, three, 1, 
            }
        }

        static void DemoDictionary()
        {
            /*
                private int[] _buckets;
	            private Entry[] _entries;
                private struct Entry
                {
	                public uint hashCode;
	                public int next;
	                public TKey key;
	                public TValue value;
                }

             * 
            In C#, Dictionary is a generic collection which is generally used to store key/value pairs.
            The working of Dictionary is quite similar to the non-generic hashtable.
            The advantage of Dictionary is, it is generic type.

            It is dynamic in nature means the size of the dictionary is grows according to the need.

            Methods: Clear, Remove, ContainsKey, ContainsValue, Count, Item[], TryAdd, TryGetValue
            */
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "one");
            d.Add(5, "five");
            d.Add(3, "three");
            d.Add(4, "four");
            Console.WriteLine("\nDictionary Elements: "); //order is maintained
            foreach (var item in d.Keys)
            {
                Console.Write(item + ", "); //prints: 1, 5, 3, 4, 
            }
        }

        static void DemoSortedSet()
        {
            /* Looks like that it is implemented as Red-Black Tree - with Node
             *  internal sealed class Node
                {
	                public T Item { get; set; }
	                public Node Left { get; set; }
	                public Node Right { get; set; }
	                public NodeColor Color { get; set; }
	                public bool IsBlack => Color == NodeColor.Black;
	                public bool IsRed => Color == NodeColor.Red;
                }
             * 
            In C#, SortedSet is a collection of objects in sorted order.
            It also provides many mathematical set operations, such as intersection, union,
            and difference. It is a dynamic collection means the size of the SortedSet is
            automatically increased when the new elements are added.

            In SortedSet, the elements must be unique.
            In SortedSet, the order of the element is ascending.
            It is generally used when we want to use SortedSet class if you have to store unique
            elements and maintain ascending order.
            */
            //Creating an Instance of SortedSet class to store Integer values
            SortedSet<int> sortedSetNumbers = new SortedSet<int>();
            //Adding Elements to SortedSet using Add Method
            sortedSetNumbers.Add(10);
            sortedSetNumbers.Add(5);
            sortedSetNumbers.Add(50);
            sortedSetNumbers.Add(37);
            sortedSetNumbers.Add(18);
            sortedSetNumbers.Add(37);
            //Accessing the SortedSet Elements using For Each Loop
            Console.WriteLine("\nSortedSet Elements");
            foreach (var item in sortedSetNumbers)
            {
                Console.Write(item + ", "); //sorted in asc order, prints: 5, 10, 18, 37, 50, 
            }
        }

        static void DemoHashSet()
        {
            /* implemented using Entry and buckets array similar to dictionary
             * 
            In C#, HashSet is an unordered collection of unique elements.
            It is generally used when we want to prevent duplicate elements from being
            placed in the collection. The performance of the HashSet is much better in
            comparison to the list.

            In HashSet, the order of the element is not defined. You cannot sort the elements of HashSet.
            In HashSet, the elements must be unique.
            In HashSet, duplicate elements are not allowed.
            Is provides many mathematical set operations, such as intersection, union, and difference.
            */
            HashSet<string> myhash1 = new HashSet<string>();

            // Add the elements in HashSet
            // Using Add method
            myhash1.Add("C");
            myhash1.Add("Java");
            myhash1.Add("Ruby");
            myhash1.Add("C++");
            myhash1.Add("C#");

            Console.WriteLine("\nElements of HashSet:");

            // Accessing elements of HashSet
            // Using foreach loop
            foreach (var val in myhash1)
            {
                Console.Write(val + ", "); //order is maintained
                                           //prints: C, Java, Ruby, C++, C#, 
            }
        }


        static void DemoSortedList()
        {
            /*  implemented using:
                private TKey[] keys;
                private TValue[] values;
            */
        //Predicate<int> isEven = (x) => x % 2 == 0;
        var isEven = (int x) => x % 2 == 0;

            var descendingComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            var ascendingComparer = Comparer<int>.Create((x, y) => x.CompareTo(y));

            //in SL elements are stored in continuous block in memory, not the case with SortedDictionary
            //in SL elements can be accessed by index
            //by default sorts in Asc order

            WriteLine("\nPrinting SortedList:");

            SortedList<int, string> sl = new SortedList<int, string>(descendingComparer);
            sl.Add(3, "three");
            sl.Add(1, "one");
            sl.Add(5, "five");
            sl.Add(2, "two");
            sl.Add(4, "four");

            foreach (var kvp in sl)
            {
                Console.Write(kvp.Key + ": " + kvp.Value + ", "); //prints 5,4,3,2,1
                //prints: 5: five, 4: four, 3: three, 2: two, 1: one, isEven(10): True
            }

            Console.WriteLine("\nisEven(10): " + isEven(10));
            //prints: isEven(10): True
        }


        static void DemoSortedDictionary()
        {
            //implmented as a tree using SortedSet internally

            var descendingComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            var ascendingComparer = Comparer<int>.Create((x, y) => x.CompareTo(y));

            WriteLine("\nPrinting SortedDictionary:");
            SortedDictionary<int, string> sd = new SortedDictionary<int, string>(descendingComparer);
            sd.Add(3, "three");
            sd.Add(1, "one");
            sd.Add(5, "five");
            sd.Add(2, "two");
            sd.Add(4, "four");

            foreach (var kvp in sd)
            {
                Console.Write(kvp.Key + ": " + kvp.Value + ", ");
                //prints: 5: five, 4: four, 3: three, 2: two, 1: one, 
            }
        }

        public static IEnumerable SomeEvenNumbers(int K)
        {
            for (int i = 1; i <= K; i++)
                if (i % 2 == 0)
                    yield return i;
        }

        public static void DemoJaggedArray()
        {
            WriteLine("\nPrinting JaggedArray:");

            var numberSets = new List<int[]>
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 0, 0, 0 },
                new[] { 9, 8 },
                new[] { 1, 0, 1, 0, 1, 0, 1, 0 }
            };

            int[][] test = numberSets.ToArray();
            foreach (var row in test)
            {
                foreach (var c in row)
                    Console.Write(c + " ");

                Console.WriteLine("");
            }

            /* prints:
                1 2 3 4 5 
                0 0 0 
                9 8 
                1 0 1 0 1 0 1 0 
             */
        }
    }
}


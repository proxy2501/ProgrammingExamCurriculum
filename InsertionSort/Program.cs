using System;
using System.Collections.Generic;

namespace InsertionSort
{
    class Program
    {
        private static Random rnd = new Random();
        private static InsertionSorter sorter = new InsertionSorter();

        static void Main(string[] args)
        {
            while (true)
            {
                // Array.
                Console.WriteLine("USING ARRAY\n");
                int[] array = new int[10];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(0, 500);
                }

                Console.WriteLine("Unsorted numbers:");
                PrintNumbers(array);

                sorter.Sort(array);

                Console.WriteLine("\nSorted numbers:");
                PrintNumbers(array);

                Console.ReadKey();
                Console.Clear();

                // List.
                Console.WriteLine("USING LIST\n");
                List<int> list = new List<int>();

                for (int i = 0; i < 10; i++)
                {
                    list.Add(rnd.Next(0, 500));
                }

                Console.WriteLine("Unsorted numbers:");
                PrintNumbers(list);

                sorter.Sort(list);

                Console.WriteLine("\nSorted numbers:");
                PrintNumbers(list);

                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Prints the numbers in collection to console.
        /// </summary>
        private static void PrintNumbers(IList<int> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }
    }
}

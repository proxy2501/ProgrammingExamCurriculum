using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        private static Random rnd = new Random();
        private static SortingMachine sortingMachine = new SortingMachine(new BubbleSorter());

        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list1.Add(rnd.Next(0, 500));
                list2.Add(rnd.Next(0, 500));
                list3.Add(rnd.Next(0, 500));
            }

            sortingMachine.Sort(list1);
            
            Console.ReadKey();
            Console.WriteLine();

            sortingMachine.Strategy = new InsertionSorter();
            sortingMachine.Sort(list2);
            
            Console.ReadKey();
            Console.WriteLine();

            sortingMachine.Strategy = new Quicksorter();
            sortingMachine.Sort(list3);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class InsertionSorter : ISortingStrategy
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 1; i < collection.Count; i++)
            {
                T unsortedValue = collection[i];

                int j = i - 1;

                while (j >= 0 && collection[j].CompareTo(unsortedValue) == 1)
                {
                    collection[j + 1] = collection[j];

                    j--;
                }

                collection[j + 1] = unsortedValue;
            }

            Console.WriteLine("Result using insertion sort:");

            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }
    }
}

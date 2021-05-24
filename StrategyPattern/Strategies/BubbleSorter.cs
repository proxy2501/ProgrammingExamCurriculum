using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class BubbleSorter : ISortingStrategy
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            int elementsToCompare = collection.Count;

            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < elementsToCompare; i++)
                {
                    if (collection[i - 1].CompareTo(collection[i]) == 1)
                    {
                        T temp = collection[i];
                        collection[i] = collection[i - 1];
                        collection[i - 1] = temp;

                        swapped = true;
                    }
                }

                elementsToCompare--;

            } while (swapped);

            Console.WriteLine("Result using bubble sort:");

            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }
    }
}

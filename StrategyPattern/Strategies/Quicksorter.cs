using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Quicksorter : ISortingStrategy
    {
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            Sort(collection, 0, collection.Count - 1);

            Console.WriteLine("Result using quicksort:");

            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }

        public void Sort<T>(IList<T> collection, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex >= endIndex) return;

            int pivotIndex = Partition(collection, startIndex, endIndex);

            Sort(collection, startIndex, pivotIndex - 1);
            Sort(collection, pivotIndex + 1, endIndex);
        }

        private int Partition<T>(IList<T> collection, int start, int end) where T : IComparable<T>
        {
            int pivot = end;

            int i = start;

            for (int j = start; j < end; j++)
            {
                if (collection[j].CompareTo(collection[pivot]) == -1)
                {
                    T temp1 = collection[j];
                    collection[j] = collection[i];
                    collection[i] = temp1;

                    i++;
                }
            }

            T temp2 = collection[i];
            collection[i] = collection[end];
            collection[end] = temp2;

            return i;
        }
    }
}

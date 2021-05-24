using System;
using System.Collections.Generic;

namespace InsertionSort
{
    public class InsertionSorter
    {
        /// <summary>
        /// Sorts an IList collection in order of lowest to highest.
        /// </summary>
        /// <param name="collection">An IList collection of items that impletent the generic IComparable interface.</param>
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 1; i < collection.Count; i++)
            {
                T unsortedValue = collection[i]; // Cache the value to be sorted during this pass.

                int j = i - 1; // Set the first element to compare with unsorted value.

                while (j >= 0 && collection[j].CompareTo(unsortedValue) == 1) // Move left & compare until smaller value found, or start of collection reached.
                {
                    collection[j + 1] = collection[j];

                    j--;
                }

                collection[j + 1] = unsortedValue; // Insert unsorted value in the place where algorithm stopped.
            }
        }
    }
}

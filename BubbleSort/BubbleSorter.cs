using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class BubbleSorter
    {
        /// <summary>
        /// Sorts an IList collection of items in order of lowest to highest.
        /// </summary>
        /// <param name="collection">An IList collection of items that implement the generic IComparable interface.</param>
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            int elementsToCompare = collection.Count; // Set number of elements to compare in first pass.

            bool swapped;

            do
            {
                swapped = false; // Toggle 'swapped' false for new pass.

                for (int i = 1; i < elementsToCompare; i++) // Move up indexes, comparing elements and swapping the larger one upwards.
                {
                    if (collection[i - 1].CompareTo(collection[i]) == 1)
                    {
                        T temp = collection[i];
                        collection[i] = collection[i - 1];
                        collection[i - 1] = temp;

                        swapped = true; // Toggle 'swapped' true for this pass, if a swap occured.
                    }
                }

                elementsToCompare--; // Decrease number of elements to compare in next pass.

            } while (swapped); // Continue making passes until no swaps were made.
        }
    }
}

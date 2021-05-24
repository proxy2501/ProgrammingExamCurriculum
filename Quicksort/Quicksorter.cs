using System;
using System.Collections.Generic;

namespace Quicksort
{
    public class Quicksorter
    {
        /// <summary>
        /// Sorts an IList collection in order of lowest to highest.
        /// </summary>
        /// <param name="collection">An IList collection of items that implement the generic IComparable interface.</param>
        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            Sort(collection, 0, collection.Count - 1);
        }

        /// <summary>
        /// Sorts the specified range of an IList collection in order of lowest to highest.
        /// </summary>
        /// <param name="collection">An IList collection of items that implement the generic IComparable interface.</param>
        /// <param name="startIndex">An integer indicating the starting index of the range.</param>
        /// <param name="endIndex">An integer indicating the ending index of the range.</param>
        public void Sort<T>(IList<T> collection, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex >= endIndex) return; // If 1 element or less, the specified range is already sorted.

            int pivotIndex = Partition(collection, startIndex, endIndex); // Arrange the collection into 2 partitions. Get index of pivot.

            Sort(collection, startIndex, pivotIndex - 1); // Call Sort recursively on "smaller than" partition.
            Sort(collection, pivotIndex + 1, endIndex); // Call Sort recursively on "larger than" partition.
        }

        /// <summary>
        /// Arranges the specified range of an IList collection into partitions
        /// of "lower than" and "higher than" with a a pivot value in between.
        /// </summary>
        /// <param name="collection">An IList collection of items that implement the generic IComparable interface.</param>
        /// <param name="start">An integer indicating the starting index of the range.</param>
        /// <param name="end">An integer indicating the ending index of the range.</param>
        /// <returns>An integer indicating the index of the pivot element after partitioning.</returns>
        private int Partition<T>(IList<T> collection, int start, int end) where T : IComparable<T>
        {
            int pivot = end; // Set pivot to the last index of the range.

            int i = start; // Tracks where the next element should go, if found to be lower than pivot.

            for (int j = start; j < end; j++) // Compare each element to pivot, swapping if needed.
            {
                if (collection[j].CompareTo(collection[pivot]) == -1)
                {
                    T temp1 = collection[j];
                    collection[j] = collection[i];
                    collection[i] = temp1;

                    i++;
                }
            }

            // Swap pivot with the element in index i. This places it between the two partitions.
            T temp2 = collection[i];
            collection[i] = collection[end];
            collection[end] = temp2;

            return i; // Return the final index of pivot.
        }
    }
}

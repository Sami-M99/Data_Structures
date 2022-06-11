using System;

namespace BinarySearch
{
    public class RecursiveBinarySearch
    {
        /// <summary>
        /// The array must be in order, to make searching for value and return the index of the value. !!!!
        /// </summary>
        public static int Search<T>(T[] array, int first, int last, T key)
            where T : IComparable<T>
        {
            int middle = (first + last) / 2;
            if (array[middle].Equals(key))
                return middle;
            else if (first >= last)
                return -1;
            else if (key.CompareTo(array[middle]) > 0)
                return Search<T>(array, middle + 1, last, key);  // Go right
            else
                return Search<T>(array, first, middle, key);     // Go left
        }
    }
}

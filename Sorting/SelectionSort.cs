using Sorting.Utilities;
using System;
using System.Collections.Generic;

namespace Sorting
{
    public class SelectionSort  // O(n^2)
    {
        public static void Selection_Sort<T>(T[] array)
           where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min].CompareTo(array[j]) > 0)
                        min = j;
                }
                if (min != i)
                    Swap.swap(array, min, i);


            }
        }

        public static void Selection_Sort<T>(T[] array, SortDirection sortDirection = SortDirection.Ascending)
            where T : IComparable<T>
        {
            var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) >= 0)
                        Swap.swap(array, i, j);
                }
            }
        }

    }

}

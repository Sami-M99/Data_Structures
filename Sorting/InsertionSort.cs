using Sorting.Utilities;
using System;
using System.Collections.Generic;

namespace Sorting
{
    public class InsertionSort  // O(n^2)
    {
        public static void Insertion_Sort<T>(T[] array)
           where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                        Swap.swap(array, j, j - 1);
                    else
                        break;
                }

            }
        }
        
        public static T[] Insertion_Sort<T>(T[] array, SortDirection sortDirection = SortDirection.Ascending)
                where T : IComparable
        {
            var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (comparer.Compare(array[j], array[j - 1]) < 0)
                    {
                        Swap.swap<T>(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }
    }

}

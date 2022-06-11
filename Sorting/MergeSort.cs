using Sorting.Utilities;
using System;
using System.Collections.Generic;

namespace Sorting
{
    public class MergeSort  // O(n (log n))
    {
        public static void Sort<T>(T[] array)
            where T : IComparable<T>
        {
            Merge_Sort<T>(array, 0, array.Length - 1);
        }

        private static void Merge_Sort<T>(T[] array, int first, int last)
            where T : IComparable<T>
        {
            if (first < last)
            {
                int mid = first + (last - first) / 2;

                // Divide
                Merge_Sort(array, first, mid);
                Merge_Sort(array, mid + 1, last);

                // Conquer "Merge"
                Merge(array, first, mid, last);

            }
        }

        private static void Merge<T>(T[] array, int first, int mid, int last)
            where T : IComparable<T>
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = mid - first + 1;  // for First subArray is  array[firat ... mid]
            int n2 = last - mid;       // for Second subArray is array[mid+1 ... last]

            // Create temp arrays
            T[] Lift = new T[n1];
            T[] Right = new T[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                Lift[i] = array[first + i];
            for (j = 0; j < n2; ++j)
                Right[j] = array[mid + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = first;
            while (i < n1 && j < n2)
            {
                if (Lift[i].CompareTo(Right[j]) < 0)
                {
                    array[k] = Lift[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                array[k] = Lift[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                array[k] = Right[j];
                j++;
                k++;
            }


            ///* In another way*/
            //T[] leftArray = new T[mid - first + 1];
            //T[] rightArray = new T[last - mid];

            //System.Array.Copy(array, first, leftArray, 0, mid - first + 1);
            //System.Array.Copy(array, mid + 1, rightArray, 0, last - mid);

            //int i = 0;
            //int j = 0;
            //for (int k = first; k < last + 1; k++)
            //{
            //    if (i == leftArray.Length)
            //    {
            //        array[k] = rightArray[j];
            //        j++;
            //    }
            //    else if (j == rightArray.Length)
            //    {
            //        array[k] = leftArray[i];
            //        i++;
            //    }
            //    else if (leftArray[i].CompareTo(rightArray[j]) < 0)
            //    {
            //        array[k] = leftArray[i];
            //        i++;
            //    }
            //    else
            //    {
            //        array[k] = rightArray[j];
            //        j++;
            //    }
            //}


        }

        public static void Merge_Sort<T>(T[] array, int first, int last, SortDirection sortDirection)
           where T : IComparable<T>
        {
            if (first < last)
            {
                int mid = first + (last - first) / 2;

                // Divide
                Merge_Sort(array, first, mid, sortDirection);
                Merge_Sort(array, mid + 1, last, sortDirection);

                // Conquer "Merge"
                Merge(array, first, mid, last, sortDirection);

            }
        }

        private static void Merge<T>(T[] array, int first, int mid, int last, SortDirection sortDirection)
            where T : IComparable<T>
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = mid - first + 1;  // for First subArray is  array[firat ... mid]
            int n2 = last - mid;       // for Second subArray is array[mid+1 ... last]

            // Create temp arrays
            T[] Lift = new T[n1];
            T[] Right = new T[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                Lift[i] = array[first + i];
            for (j = 0; j < n2; ++j)
                Right[j] = array[mid + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;


            // /// Comparer ASC or DEASC  ///
            var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

            // Initial index of merged
            // subarray array
            int k = first;
            while (i < n1 && j < n2)
            {
                if (comparer.Compare(Lift[i], Right[j]) < 0)
                {
                    array[k] = Lift[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                array[k] = Lift[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                array[k] = Right[j];
                j++;
                k++;
            }
        }

    }

}

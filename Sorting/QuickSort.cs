using System;

namespace Sorting
{
    public class QuickSort  // O(n^2) , O(n (log n))
    {
        public static void Quick_Sort<T>(T[] array)
            where T : IComparable<T>
        {
            Quick_Sort<T>(array, 0, array.Length - 1);
        }

        public static void Quick_Sort<T>(T[] array, int start, int end)
            where T : IComparable<T>
        {
            if (start < end)
            {
                int i = Partition(array, start, end);

                Quick_Sort(array, start, i - 1);
                Quick_Sort(array, i + 1, end);
            }
        }

        private static int Partition<T>(T[] array, int start, int end)
            where T : IComparable<T>
        {
            T p = array[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (array[j].CompareTo(p) < 0)
                {
                    i++;
                    Swap.swap<T>(array, i, j);

                }
            }

            Swap.swap<T>(array, i + 1, end);
            return i + 1;

            ///* In another way */
            //int i = start;
            //int j = end;

            //T pivot = array[start];
            //do
            //{
            //    while (array[i].CompareTo(pivot) < 0) { i++; }
            //    while (array[j].CompareTo(pivot) > 0) { j--; }
            //    if (i >= j) break;
            //    Swap.swap<T>(array, i, j);
            //} while (i <= j);

            //return j;


        }
    }
}

using System;

namespace Sorting
{
    public class BubbleSort  // O(n^2)
    {
        public static void Bubble_Sort<T>(T[] array)
            where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)   // Length - 1 - i
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                        Swap.swap(array, j, j + 1);
                }
            }

        }

    }
}

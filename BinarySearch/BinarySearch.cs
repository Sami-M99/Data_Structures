using System;

namespace BinarySearch
{
    /// <summary>
    /// The array must be in order, to make searching for value and return the index of the value. !!!!
    /// </summary>
    public class BinarySearch
    {
        public static int Search<T>(T[] input, T key)
            where T : IComparable<T>
        {
            int first = 0;
            int last = input.Length - 1;

            while (true)
            {
                if (first == last)
                    return (input[last].Equals(key)) ? last : -1;

                int middle = (first + last) / 2;

                if (input[middle].CompareTo(key) == 0)
                    return middle;
                else if (input[middle].CompareTo(key) < 0)
                    first = middle + 1;
                else
                    last = middle;

            }
        }
    }
}

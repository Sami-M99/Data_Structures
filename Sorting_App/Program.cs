using Sorting;
using Sorting.Utilities;
using System;

namespace Sorting_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { -8, 44, 0, 4, 2, -20, 18, 6, -54, 0, -100, 6 };
            Quick_Sort(numbers, 0, numbers.Length - 1);
            foreach (int i in numbers)
                Console.Write(i + "  ");

            Console.WriteLine();

            Insertion_Sort();
            Console.WriteLine();

            Selection_Sort();
            Console.WriteLine();

            Bubble_Sort();
            Console.WriteLine();


            ///*  Used SortingAlgorithms classes  */ 
            var arr = new int[] { 40, 50, 10, 30, 20 };
            PrintArray(arr);
            MergeSort.Sort(arr);
            PrintArray(arr);


            var names = new string[] { "Tom", "Ali", "Qasim", "Ahmed", "Ziad" };
            PrintArray(names);
            SelectionSort.Selection_Sort(names, SortDirection.Descending);
            PrintArray(names);

            Console.ReadKey();

        }



        static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write($"{item,-10}");
            }
            Console.WriteLine();
        }

        private static void Insertion_Sort()  // O(n^2)
        {
            int[] numbers = new int[] { 8, 1, 70, 0, -15, -25 };

            for (int i = 0; i < numbers.Length - 1; i++)  // Length-1 
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        var temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            foreach (int i in numbers)
                Console.Write(i + "  ");
        }

        private static void Selection_Sort() // O(n^2)
        {
            var numbers = new int[] { 7, -2, -8, 44, 0, 5, 25, -10 };
            int start = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                int x = i;

                for (int j = start; j < numbers.Length; j++)
                {
                    if (numbers[x] > numbers[j])
                        x = j;
                }

                if (x != i)
                {
                    var t = numbers[i];
                    numbers[i] = numbers[x];
                    numbers[x] = t;
                }

                start++;
            }
            foreach (int i in numbers)
                Console.Write(i + "  ");
        }

        private static void Bubble_Sort() // O(n^2)
        {
            var numbers = new int[] { -8, 44, 0, 4, 2, -20, 18, 6, -54, 0 };
            var length = numbers.Length;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < length - 1; j++)   // Length-1
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }

                }

                length--;
            }
            foreach (int i in numbers)
                Console.Write(i + "  ");
        }

        private static void Quick_Sort(int[] arr, int start, int end)  // O(n^2) , O(n (log n))
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                Quick_Sort(arr, start, i - 1);
                Quick_Sort(arr, i + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end) // with Quick_Sort
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

    }
}

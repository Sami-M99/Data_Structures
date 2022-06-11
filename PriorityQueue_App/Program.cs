using PriorityQueue;
using System;

namespace PriorityQueue_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Min Heap */
            var minHeap = new MinHeap<int>(new int[] { 10, 8, 4, 5, 6, 7, 1, 9 });

            minHeap.printArray();
            Console.WriteLine();

            minHeap.Add(7);

            minHeap.printArray();
            Console.WriteLine();

            //minHeap.DeleteMinMax();
            //minHeap.printArray();

            Console.WriteLine(minHeap.Peek());
            Console.WriteLine();


            Console.WriteLine(new String('*', 20));
            /* Max Heap */
            var maxHeap = new MaxHeap<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            maxHeap.printArray();
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}

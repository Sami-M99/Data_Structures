using DataStructures.Queue;
using System;

namespace Queue_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var queue = new ArrayQueue<ToDo>();
            //var queue = new DataStructures.Queue.Queue<ToDo>();
            //var queue = new DataStructures.Queue.Queue<ToDo>(QueueType.ArrayQueue);
            var queue = new DataStructures.Queue.Queue<ToDo>(QueueType.LinkedListQueue);

            queue.Enqueue(new ToDo()
            {
                Describe = "Wake Up",
                Time = 7
            });
            queue.Enqueue(new ToDo()
            {
                Describe = "Go to School",
                Time = 10
            });
            queue.Enqueue(new ToDo()
            {
                Describe = "Meet some frindes",
                Time = 17
            });

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            Console.WriteLine(queue.Dequeue() + "   => Done");
            Console.WriteLine(queue.Dequeue() + "   => Done");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}

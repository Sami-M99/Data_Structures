using DataStructures.Queue.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> _queue;

        public ArrayQueue()
        {
            _queue = new List<T>();
        }

        public ArrayQueue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public int Count => _queue.Count;

        public void Enqueue(T value)
        {
            _queue.Add(value);
        }

        public T Dequeue()
        {
            if (Count == 0) throw new EmptyQueueException("Queue Empty!!");  // Exception class

            var temp = _queue[0];
            _queue.RemoveAt(0);
            return temp;
        }

        public T Peek()
        {
            return Count == 0 ? default(T) : _queue[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

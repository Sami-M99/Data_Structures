using DataStructures.Queue.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    /* FIFO : First In First Out  */
    public class Queue<T> : IQueue<T>
    {
        private readonly IQueue<T> _queue;

        public Queue(QueueType type = QueueType.LinkedListQueue)
        {
            switch (type)
            {
                case QueueType.ArrayQueue:
                    _queue = new ArrayQueue<T>();
                    break;
                case QueueType.LinkedListQueue:
                    _queue = new LinkedListQueue<T>();
                    break;
                default:
                    throw new Exception("Unsupported Queue Type");
            }
        }
        public int Count => _queue.Count;

        public void Enqueue(T value)
        {
            _queue.Enqueue(value);
        }

        public T Dequeue()
        {
            return _queue.Dequeue();
        }

        public T Peek()
        {
            return _queue.Peek();
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

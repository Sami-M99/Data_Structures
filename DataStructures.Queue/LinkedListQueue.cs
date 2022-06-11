using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.Queue.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> _likedList;
        public LinkedListQueue()
        {
            _likedList = new DoublyLinkedList<T>();
        }

        public LinkedListQueue(IEnumerable<T> collection) : this()
        {
            foreach (T item in collection)
                Enqueue(item);
        }

        public int Count => _likedList.Count;

        public void Enqueue(T value)
        {
            _likedList.AddLast(value);
        }

        public T Dequeue()
        {
            if (Count == 0) throw new EmptyQueueException();  // Exception class

            return _likedList.RemoveFirst();
        }

        public T Peek()
        {
            return Count == 0 ? default(T) : _likedList.Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _likedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

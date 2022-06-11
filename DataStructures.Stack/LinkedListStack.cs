using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Stack.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> _list;

        public LinkedListStack()
        {
            _list = new SinglyLinkedList<T>();
        }

        public LinkedListStack(IEnumerable<T> collection) : this()
        {
            foreach (T item in collection)
                Push(item);
        }
        public int Count => _list.Count;

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (Count == 0) throw new ArgumentNullException("Empty Stack");
            return _list.RemoveFirst();
        }

        public T Peek()
        {
            return Count == 0 ? default(T) : _list.Head.Value;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}

using DataStructures.Array.Generic;
using DataStructures.Stack.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly Array<T> _array;

        public ArrayStack()
        {
            _array = new Array<T>();
        }

        public ArrayStack(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public int Count => _array.Count;

        public void Push(T value)
        {
            _array.Add(value);
        }

        public T Pop()
        {
            if (Count == 0) throw new ArgumentNullException("Empty Stack");

            return _array.Remove();
        }

        public T Peek()
        {
            if (Count == 0)
                return default(T);

            return _array.GetValue(_array.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

using DataStructures.Stack.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    /* FILO : First In Last out  */
    public class Stack<T> : IStack<T>
    {
        private readonly IStack<T> _stack;

        public Stack(StackType type = StackType.LinkedList)
        {
            switch (type)
            {
                case StackType.LinkedList:
                    _stack = new LinkedListStack<T>();
                    break;
                case StackType.Array:
                    _stack = new ArrayStack<T>();
                    break;
                default:
                    throw new Exception();
            }
        }

        public int Count => _stack.Count;

        public void Push(T value)
        {
            _stack.Push(value);
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}

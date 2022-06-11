using System;
using System.Collections.Generic;


namespace DataStructures.Stack.Contracts
{
    public interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        void Push(T value);
        T Pop();
        T Peek();
    }
}

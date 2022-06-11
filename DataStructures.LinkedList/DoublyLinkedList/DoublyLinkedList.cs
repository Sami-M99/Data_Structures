using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public DbNode<T> Head { get; private set; }
        public DbNode<T> Tail { get; private set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DbNode<T>(value);

            if (Head is null)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }

            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            Count++;

        }

        public void AddLast(T value)
        {
            var newNode = new DbNode<T>(value);

            if (Head is null)
            {
                AddFirst(value);
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            Count++;
        }

        public void AddBefore(DbNode<T> node, T value)
        {
            if (node is null) throw new ArgumentNullException();

            if (Head is null || node.Equals(Head))
            {
                AddFirst(value);
                return;
            }

            var newNode = new DbNode<T>(value);
            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Prev = prev;
                    newNode.Next = current;
                    prev.Next = newNode;
                    current.Prev = newNode;  // newNode.Next.Prev = newNode;
                    Count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }

            throw new ArgumentException();
        }

        public void AddAfter(DbNode<T> node, T value)
        {
            if (node is null) throw new ArgumentNullException();

            if (Head is null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DbNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Prev = current;
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    newNode.Next.Prev = newNode;
                    Count++;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException();
        }

        public T RemoveFirst()
        {
            if (Head is null) throw new ArgumentNullException();

            var temp = Head;

            if (Head.Next is null)
            {
                Head = null;
                Count--;
                return temp.Value;
            }
            Head = Head.Next;
            Head.Prev = null;
            Count--;
            return temp.Value;
        }

        public T RemoveLast()
        {
            if (Head is null) throw new ArgumentNullException();

            if (Head.Next is null)
            {
                var te = Head;
                Head = null;
                Count--;
                return te.Value;
            }

            var temp = Tail;
            Tail = Tail.Prev;
            Tail.Next = null;
            return temp.Value;
        }

        public T Remove(T value)
        {
            if (Head is null || value is null) throw new ArgumentNullException();

            if (Head.Value.Equals(value))
                return RemoveFirst();

            if (Tail.Value.Equals(value))
                return RemoveLast();

            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    var temp = current;
                    prev.Next = current.Next;
                    prev.Next.Prev = prev;
                    current = null;
                    Count--;
                    return temp.Value;
                }
                prev = current;
                current = current.Next;
            }

            throw new ArgumentException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);

            // return new DoublyLinkedListEnumeratorReverse<T>(Tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> ToList() => new List<T>(this);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;


namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        public int Count { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public SinglyLinkedList(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        /* here we don't write AddFirst<T> , because T at All class SinglyLinkedList<T> */
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (Head is null)
            {
                Head = newNode;
                Count++;
                return;
            }

            newNode.Next = Head;
            Head = newNode;
            Count++;

        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (Head is null)
            {
                Head = newNode;
                Count++;
                return;
            }

            var Current = Head;
            while (Current.Next != null)
            {
                Current = Current.Next;
            }

            Current.Next = newNode;
            Count++;
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (Head is null || node.Equals(Head))
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);

            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    Count++;
                    return;
                }

                prev = current;
                current = current.Next;
            }

            throw new Exception("There is no same node in this Linked list.");

        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException();

            if (Head is null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    /* لازم نكتب هذه الاسطر بنفس الترتيب والا خطأ وراح تصير دوامة الى ملا نهاية */
                    /* We must write these lines in the same order, or it will be wrong and it will become a loop to infinity */ 
                    newNode.Next = current.Next;
                    current.Next = newNode;
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

            Head = Head.Next;
            Count--;

            return temp.Value;
        }

        public T RemoveLast()
        {
            if (Head is null) throw new ArgumentNullException();

            ///* whit out return a value */
            //if(Head.Next is null)
            //{
            //    Head = null;
            //    Count--;
            //    return;
            //}

            //var current = Head;
            //while (current.Next.Next != null)
            //{
            //    current = current.Next;
            //}
            //current.Next = null;
            //return;

            if (Head.Next is null)
            {
                var temp = Head;
                Head = null;
                Count--;
                return temp.Value;
            }

            var current = Head;
            var prev = current;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = null;
            Count--;
            return current.Value;
        }

        public T Remove(T value)
        {
            if (Count == 0 || Head == null) throw new ArgumentNullException();

            if (Head.Value.Equals(value))
            {
                var temp = Head;
                Head = Head.Next;
                Count--;
                return temp.Value;
            }

            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    prev.Next = current.Next;
                    Count--;
                    return current.Value;
                }
                prev = current;
                current = current.Next;
            }

            throw new ArgumentException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> ToList() => new List<T>(this);
    }


    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        public SinglyLinkedListNode<T> Curr { get; set; }
        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            Curr = null;
        }
        public T Current => Curr.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (Head == null)
                return false;

            if (Curr == null)
            {
                Curr = Head;
                return true;
            }

            if (Curr.Next != null)
            {
                Curr = Curr.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Curr = null;
            Head = null;
        }
    }

}

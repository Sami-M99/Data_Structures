using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        public DbNode<T> Head { get; set; }
        public DbNode<T> Curr { get; set; }

        public DoublyLinkedListEnumerator(DbNode<T> head)
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
            if (Head is null)
                return false;

            if (Curr is null)
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
            Head = null;
            Curr = null;
        }
    }
}

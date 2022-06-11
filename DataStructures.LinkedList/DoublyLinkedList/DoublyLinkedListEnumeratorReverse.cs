using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListEnumeratorReverse<T> : IEnumerator<T>
    {
        public DbNode<T> Tail { get; set; }
        public DbNode<T> Curr { get; set; }

        public DoublyLinkedListEnumeratorReverse(DbNode<T> tail)
        {
            Tail = tail;
            Curr = null;
        }

        public T Current => Curr.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Tail = null;
        }

        public bool MoveNext()
        {
            if (Tail is null)
                return false;

            if (Curr is null)
            {
                Curr = Tail;
                return true;
            }

            if (Curr.Prev != null)
            {
                Curr = Curr.Prev;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Tail = null;
            Curr = null;
        }
    }
}

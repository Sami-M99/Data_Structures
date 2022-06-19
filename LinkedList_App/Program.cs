using DataStructures.LinkedList.SinglyLinkedList;
using System;
using System.Collections.Generic;

namespace LinkedList_App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var linkedlist = new SinglyLinkedList<char>("Samsun".ToCharArray());
            Console.WriteLine(GetCount<char>(linkedlist.Head));
            Console.WriteLine(GetCount<char>(linkedlist.Head.Next));

            /////////////////////////////////////////////

            //var node1 = new SinglyLinkedListNode<char>('a');
            //var node2 = new SinglyLinkedListNode<char>('b');
            //var node3 = new SinglyLinkedListNode<char>('c');
            //var node4 = new SinglyLinkedListNode<char>('z');

            //node1.Next = node2;
            //node2.Next = node3;
            //node3.Next = node4;

            //AddFirst<char>('s', ref node1);
            //AddLast<char>('9', node1);
            //Traverse<char>(node1); // foreach  // s a b c z 9 

            /////////////////////////////////////////////

            //var linkedList = new SinglyLinkedList<int>();
            //linkedList.AddFirst(1);
            //linkedList.AddLast(2);
            //linkedList.AddLast(3);

            //linkedList.AddAfter(linkedList.Head, 50);
            //linkedList.AddBefore(linkedList.Head, 50);

            //linkedList.RemoveLast();

            //foreach (var item in linkedList.ToList())
            //{
            //    Console.WriteLine(item);  //  50 1 50 2
            //}


            /////////////////////////////////////////////

            /* Example */
            //// input  : 1,2,2,3,4,5,3
            //// output : 5,4,3,2,1
            //var c1 = new CustomLinkedList<char>("Wellcomee".ToCharArray());
            //var c2 = new CustomLinkedList<int>(new int[] { 1, 2, 3, 4, 4, 5, 2 });

            //foreach (var i in c1) Console.Write(i + " ");

        }

        static int GetCount<T>(SinglyLinkedListNode<T> entryPoint)
        {
            int count = 0;

            var Current = entryPoint;
            while (Current != null)
            {
                Current = Current.Next;
                count++;
            }
            return count;

        }

        static void Traverse<T>(SinglyLinkedListNode<T> Head)
        {
            if (Head is null)
                throw new ArgumentNullException(nameof(Head));

            var Current = Head;
            while (Current != null)
            {
                Console.WriteLine(Current.Value);
                Current = Current.Next;
            }
        }

        static void AddFirst<T>(T value, ref SinglyLinkedListNode<T> Head) // ref because we change a Head position
        {
            if (Head is null)
                throw new ArgumentNullException();

            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;

        }

        static void AddLast<T>(T value, SinglyLinkedListNode<T> Head)
        {
            if (Head is null)
                throw new ArgumentNullException();

            var newNode = new SinglyLinkedListNode<T>(value);
            var Current = Head;
            while (Current.Next != null)
            {
                Current = Current.Next;
            }
            Current.Next = newNode;
        }

    }

    //public class SinglyLinkedListNode<T>
    //{
    //    public T Value;
    //    public SinglyLinkedListNode<T> Next; // Reference type , default value null 
    //    public SinglyLinkedListNode(T value)
    //    {
    //        Value = value;
    //    }

    //    // public override string ToString() => $"{Value}";
    //}


}

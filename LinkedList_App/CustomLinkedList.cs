using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList_App
{
    ///* Pratic Example */
    // input  : 1,2,2,3,4,5,3
    // output : 5,4,3,2,1
    public class CustomLinkedList<T> : IEnumerable
    {
        LinkedList<T> list { get; set; }

        public CustomLinkedList(T[] value)
        {
            list = new LinkedList<T>();
            foreach (var item in value)
                if (!list.Contains(item))
                    list.AddFirst(item);

            ///* Or like this */
            //list = new LinkedList<T>();
            //var hashSet = new HashSet<T>(value);
            //var stack = new Stack<T>(hashSet);
            //int n = stack.Count;
            //for (int i = 0; i < n; i++)
            //    list.AddLast(stack.Pop());

        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }

}

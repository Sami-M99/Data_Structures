using DataStructures.Stack;
using System;

namespace Stack_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "SamiM";

            var stack = new ArrayStack<char>();
            //var stack = new Stack<char>();
            //var stack = new Stack<char>(DataStructures.Stack.StackType.Array);
            //var stack = new Stack<char>(DataStructures.Stack.StackType.LinkedList);

            for (int i = 0; i < name.Length; i++)
            {
                stack.Push(name[i]);
            }

            var n = stack.Count; //لازم نكتب عدد العناصر لداخل متغير مو في الحلقة لانه يتناقص مع كل عملية اخراج 
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}

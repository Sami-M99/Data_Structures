using System;
using System.Collections.Generic;
using System.Linq;
using Trees.BinaryTree;

namespace BinaryTree_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var root = new Node<int>();
            //root.Value = 1;

            //root.Left = new Node<int>(2);
            //root.Right = new Node<int>(3);

            //root.Left.Left = new Node<int>(4);
            //root.Left.Right = new Node<int>() { Value = 5 };
            //LevelOredrTraverse<int>(root);



            var binarTree = new BinaryTree<int>();
            new int[] { 1, 2, 3, 4, 5 }.ToList().ForEach(value => binarTree.Insert(value));

            BinaryTree<int>.LevelOredrTraverse(binarTree.Root)
                .ForEach(value => Console.WriteLine(value.Value));

            Console.WriteLine();

            var b = new BinaryTree<int>(new int[] { 10, 20, 30, 50 });
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(BinaryTree<int>.IsLeaf(binarTree.Root.Left.Left));
            Console.WriteLine(BinaryTree<int>.IsLeaf(binarTree.Root.Left));




            Console.ReadKey();
        }


        static void LevelOredrTraverse<T>(Node<T> root)
        {
            if (root == null) throw new ArgumentNullException("Root is Null");

            var list = new List<Node<T>>();
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                list.Add(temp);
                if (temp.Left != null) queue.Enqueue(temp.Left);
                if (temp.Right != null) queue.Enqueue(temp.Right);
            }


            list.ForEach(node => Console.WriteLine(node.Value));
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trees.BinaryTree
{
    public class BinaryTree<T> : IEnumerable
        where T : IComparable
    {
        public Node<T> Root { get; set; }

        public int Count { get; set; }

        public BinaryTree()
        {
            Count = 0;
        }

        public BinaryTree(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
                Insert(item);
        }

        public T Insert(T value)
        {
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
                Count++;
                return value;

            }

            else
            {
                var queue = new Queue<Node<T>>();
                queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);
                    else
                    {
                        temp.Left = newNode;
                        Count++;
                        return value;
                    }

                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                    else
                    {
                        temp.Right = newNode;
                        Count++;
                        return value;
                    }
                }
            }

            throw new Exception("Insertion Operator is failed...");
        }

        public static List<Node<T>> LevelOredrTraverse(Node<T> root)
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

            return list;
        }

        public static bool IsLeaf(Node<T> node) => (node.Left == null && node.Right == null) ? true : false;

        public IEnumerator GetEnumerator()
        {
            return LevelOredrTraverse(this.Root).ToList().GetEnumerator();
        }

        public static List<T> InOrderIterationTraverse(Node<T> root)
        {

            if (root == null)
                return null;

            var list = new List<T>();
            var stack = new Stack<Node<T>>();
            bool done = false;
            Node<T> currentNode = root;
            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode.Value);
                        currentNode = currentNode.Right;
                    }
                }
            }

            return list;
        }

        public T Delete()
        {
            var list = LevelOredrTraverse(Root);
            var x = 1;
            var con = Count;
            T result = Root.Value;
            foreach (Node<T> node in list)
            {
                if (con == x)
                    result = node.Value;
                x++;
            }

            return Delete(result);
        }

        public T Delete(T node)
        {
            Delete(Root, node);
            return node;
        }

        public T Delete(Node<T> node)
        {
            Delete(Root, node.Value);
            return node.Value;
        }

        public Node<T> Delete(Node<T> root, T key)
        {
            if (root == null)
                throw new Exception("Empty tree!");

            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Delete(root.Left, key);
            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right = Delete(root.Right, key);
            }
            else
            {
                /* Deletion procedure */

                // if it has one child Or nothing
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // if it has two children
                // Find a min Value and equal it with root.Value
                var current = root.Right;
                while (current.Left != null)
                    current = current.Left;
                root.Value = current.Value;

                root.Right = Delete(root.Right, root.Value);
            }
            return root;
        }

        public bool IsInOrder(Node<T> root)
        {

            var current = root;
            if (current.Left != null || current.Right != null)
            {
                if (current.Value.CompareTo(current.Left.Value) > 0 && current.Value.CompareTo(current.Right.Value) < 0)
                {
                    if (current.Left != null && current.Value.CompareTo(current.Left.Value) > 0)
                        IsInOrder(current.Left);
                    if (current.Right != null && current.Value.CompareTo(current.Right.Value) < 0)
                        IsInOrder(current.Right);
                }
                else
                    return false;
            }

            return true;

        }

        //public T FindMin(Node<T> node)
        //{
        //    var current = node;
        //    while (current.Left != null)
        //        current = current.Left;
        //    return current.Value;

        //}

    }

}

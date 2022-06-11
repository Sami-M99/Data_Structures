using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.BinaryTree.BinarySearchTree
{
    public class BST<T>
         where T : IComparable
    {
        public Node<T> Root { get; set; }

        public BST()
        {
            Root = null;
        }

        public BST(Node<T> node)
        {
            Root = node;
        }

        public BST(IEnumerable<T> collection) : this()
        {
            foreach (T item in collection)
                Add(item);
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root;
            Node<T> parent;
            while (true)
            {
                parent = current;
                // Left
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                // Right
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = newNode;
                        return;
                    }

                }

            }

        }

        public T FindMin(Node<T> root)
        {
            T minValue = root.Value;
            while (root.Left != null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }

            return minValue;
        }

        public T FindMin()
        {
            var root = Root;
            var minValue = root.Value;
            while (root.Left != null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }

            return minValue;
        }

        public T FindMax()
        {
            var current = Root;
            while (current.Right != null)
                current = current.Right;
            return current.Value;

        }

        public Node<T> Find(T key)
        {
            if (key == null) throw new ArgumentNullException("Empty Tree...");

            Node<T> current = Root;
            while (!(current.Value.Equals(key)))
            {
                if (key.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;

                if (current == null)
                    throw new Exception("Could not found parameter ket!!!");
            }

            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null)
                throw new Exception("Empty tree!");

            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, key);
            }
            else
            {
                // deletion procedure
                // with or without a child => 0 or 1 child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // with two children  => 2 children
                root.Value = FindMin(root.Right);
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }

        public bool IsInOrder(Node<T> root)
        {
            bool order = false;
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

    }
}

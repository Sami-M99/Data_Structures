﻿namespace BinaryTree_App
{
    public class Node<T>
    {
        public Node()
        {

        }
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

}

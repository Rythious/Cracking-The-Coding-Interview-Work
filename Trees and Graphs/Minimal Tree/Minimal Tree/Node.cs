using System;
using System.Collections;
using System.Collections.Generic;

namespace Minimal_Tree
{
    public class Node
    {
        public int Value { get; }
        private Node Left { get; set; }
        private Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public void InsertValueIntoTree(int value)
        {
            if (value < Value)
            {
                if (Left == null)
                {
                    Left = new Node(value);
                }
                else
                {
                    Left.InsertValueIntoTree(value);
                }
            }
            else if (value > Value)
            {
                if (Right == null)
                {
                    Right = new Node(value);
                }
                else
                {
                    Right.InsertValueIntoTree(value);
                }
            }
            else
            {
                Console.WriteLine($"Value {value} matches the value of another node, invalidating the data.");
            }
        }

        internal void OutputOrderBreadthFirst()
        {
            var queue = new Queue<Node>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine(node.Value);

                AddChildrenToQueue(node, queue);
            }
        }

        private void AddChildrenToQueue(Node node, Queue<Node> queue)
        {
            if (node.Left != null)
            {
                queue.Enqueue(node.Left);
            }

            if (node.Right != null)
            {
                queue.Enqueue(node.Right);
            }
        }
    }
}
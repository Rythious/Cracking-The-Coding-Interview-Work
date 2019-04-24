using System;

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
    }
}
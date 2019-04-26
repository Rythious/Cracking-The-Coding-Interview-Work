using System.Collections.Generic;

namespace ListOfDepths
{
    public class Node
    {
        public int Value { get; set; }
        private Node Left { get; set; }
        private Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public void InsertValue(int value)
        {
            if (value > Value)
            {
                if (Right == null)
                {
                    Right = new Node(value);
                }
                else
                {
                    Right.InsertValue(value);
                }
            }
            else if (value < Value)
            {
                if (Left == null)
                {
                    Left = new Node(value);
                }
                else
                {
                    Left.InsertValue(value);
                }
            }
        }

        public LinkedList<int>[] SplitTreeByDepths()
        {
            var resizingListOfLinkedLists = new List<LinkedList<int>>();

            var queue = new Queue<Node>();
            queue.Enqueue(this);
            queue.Enqueue(null);

            var linkedListAtCurrentDepth = new LinkedList<int>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    resizingListOfLinkedLists.Add(linkedListAtCurrentDepth);

                    linkedListAtCurrentDepth = new LinkedList<int>();

                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    linkedListAtCurrentDepth.AddLast(node.Value);

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

            var arrayOfLinkedLists = new LinkedList<int>[resizingListOfLinkedLists.Count];

            for (var i = 0; i < resizingListOfLinkedLists.Count; i++)
            {
                arrayOfLinkedLists[i] = resizingListOfLinkedLists[i];
            }

            return arrayOfLinkedLists;
        }
    }
}
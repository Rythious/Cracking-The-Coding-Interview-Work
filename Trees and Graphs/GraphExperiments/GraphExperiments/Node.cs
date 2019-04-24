using System;
using System.Collections.Generic;

namespace GraphExperiments
{
    public class Node
    {
        public int Value { get; set; }
        public bool Visited { get; set; }
        public Node[] Children { get; set; }
        public static int OperationCount { get; set; }

        public Node(int value)
        {
            Value = value;
            Children = new Node[4];
        }

        public void SetDirectedChild(Node node)
        {
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i] == null)
                {
                    Children[i] = node;
                    break;
                }
            }
        }

        public bool PathUsingDepthFirstSearch(Node targetNode)
        {
            var isImmediateEndState = CheckCommonConditions(this, targetNode);

            if (isImmediateEndState.HasValue)
            {
                return isImmediateEndState.Value;
            }

            Console.Write($"{Value} goes to ");

            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i] != null && !Children[i].Visited)
                {
                    Console.WriteLine($"{Children[i].Value} which hasn't been visited yet.");

                    var foundIt = Children[i].PathUsingDepthFirstSearch(targetNode);

                    if (foundIt)
                    {
                        return true;
                    }
                }
            }
            
            Console.WriteLine("nowhere or everywhere has already been visited.");
            return false;
        }

        public bool PathUsingBreadthFirstSearch(Node targetNode)
        {
            var isImmediateEndState = CheckCommonConditions(this, targetNode);

            if (isImmediateEndState.HasValue)
            {
                return isImmediateEndState.Value;
            }

            var queueOfChildren = new Queue<Node>();

            AddNonNullChildrenToQueue(this, queueOfChildren);

            while (queueOfChildren.Count > 0)
            {
                var nodeToEvaluate = queueOfChildren.Dequeue();

                isImmediateEndState = CheckCommonConditions(nodeToEvaluate, targetNode);

                if (isImmediateEndState.HasValue)
                {
                    return isImmediateEndState.Value;
                }

                AddNonNullChildrenToQueue(nodeToEvaluate, queueOfChildren);
            }

            Console.WriteLine("Everywhere has already been visited.");
            return false;
        }

        private void AddNonNullChildrenToQueue(Node node, Queue<Node> queue)
        {
            for (int i = 0; i < node.Children.Length; i++)
            {
                if (node.Children[i] != null && !node.Children[i].Visited)
                {
                    Console.WriteLine($"Added {node.Children[i].Value} to queue.");
                    queue.Enqueue(node.Children[i]);
                }
            }
        }

        private bool? CheckCommonConditions(Node visitingNode, Node targetNode)
        {
            OperationCount++;

            Console.WriteLine($"Checking {visitingNode.Value}.");
            visitingNode.Visited = true;

            if (visitingNode == null)
            {
                Console.WriteLine("PathTo node cannot be null.");
                return false;
            }

            if (visitingNode == targetNode)
            {
                Console.WriteLine($"It took {OperationCount} comparisons, but I'm {visitingNode.Value}, which is the node you're looking for!");
                return true;
            }

            return null;
        }
    }
}

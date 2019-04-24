using System;

namespace GraphExperiments
{
    public class Graph
    {
        public Node[] Nodes { get; set; }

        public Graph()
        {
            Console.WriteLine("Building graph...");

            Nodes = new Node[]
            {
                /*
                37 ->  2 -> 54 -> 10 <-  7     1
                 ^           V     V     ^     ^
                 8 <-  9    40 <- 55 -> 17 ->  4
                       ^     V     ^     V     V
                34    35 -> 96    51 <- 27 ->  5
                 ^     ^     V     ^     ^   
                 6 -> 22 <- 97 -> 74    23 <- 11
                 ^     V     ^     ^           ^
                 3 <- 57 <- 14 -> 58 <- 32 <- 12
                       V     ^     V           ^
                13 <- 15    16 <- 18 -> 19 -> 20
                */

                 new Node(37), new Node(2), new Node(54), new Node(10), new Node(7), new Node(1),
                 new Node(8), new Node(9), new Node(40), new Node(55), new Node(17), new Node(4),
                 new Node(34), new Node(35), new Node(96), new Node(51), new Node(27), new Node(5),
                 new Node(6), new Node(22), new Node(97), new Node(74), new Node(23), new Node(11),
                 new Node(3), new Node(57), new Node(14), new Node(58), new Node(32), new Node(12),
                 new Node(13), new Node(15), new Node(16), new Node(18), new Node(19), new Node(20)
            };

            DirectNodeToNode(37, 2); DirectNodeToNode(2, 54); DirectNodeToNode(54, 10); DirectNodeToNode(7, 10);
            DirectNodeToNode(8, 37); DirectNodeToNode(54, 40); DirectNodeToNode(10, 55); DirectNodeToNode(17, 7); DirectNodeToNode(4, 1);
            DirectNodeToNode(9, 8);  DirectNodeToNode(55, 40); DirectNodeToNode(55, 17); DirectNodeToNode(17, 4);
            DirectNodeToNode(35, 9); DirectNodeToNode(40, 96); DirectNodeToNode(51, 55); DirectNodeToNode(17, 27); DirectNodeToNode(4, 5);
            DirectNodeToNode(35, 96); DirectNodeToNode(27, 51); DirectNodeToNode(27, 5);
            DirectNodeToNode(6, 34); DirectNodeToNode(22, 35); DirectNodeToNode(96, 97); DirectNodeToNode(74, 51); DirectNodeToNode(23, 27);
            DirectNodeToNode(6, 22); DirectNodeToNode(97, 22); DirectNodeToNode(97, 74); DirectNodeToNode(11, 23);
            DirectNodeToNode(3, 6); DirectNodeToNode(22, 57); DirectNodeToNode(14, 97); DirectNodeToNode(58, 74); DirectNodeToNode(12, 11);
            DirectNodeToNode(57, 3); DirectNodeToNode(14, 57); DirectNodeToNode(14, 58); DirectNodeToNode(32, 58); DirectNodeToNode(12, 32);
            DirectNodeToNode(57, 15); DirectNodeToNode(16, 14); DirectNodeToNode(58, 18); DirectNodeToNode(20, 12);
            DirectNodeToNode(15, 13); DirectNodeToNode(18, 16); DirectNodeToNode(18, 19); DirectNodeToNode(19, 20);

            Console.WriteLine("Graph building complete.");
        }

        private void DirectNodeToNode(int number, int pointsAt)
        {
            FindNode(number).SetDirectedChild(FindNode(pointsAt));
        }

        // This is a linear search, O(N)
        private Node FindNode(int searchValue)
        {
            foreach (var node in Nodes)
            {
                if (node.Value == searchValue)
                {
                    return node;
                }
            }

            return null;
        }

        public void FindPath(int from, int to)
        {
            var fromNode = FindNode(from);

            if (fromNode == null)
            {
                Console.WriteLine("Could not find starting node.");
                return;
            }

            var toNode = FindNode(to);
            if (toNode == null)
            {
                Console.WriteLine("Could not find ending node.");
                return;
            }

            fromNode.PathUsingDepthFirstSearch(toNode);

            ResetGraph();

            fromNode.PathUsingBreadthFirstSearch(toNode);

            ResetGraph();
        }

        private void ResetGraph()
        {
            Node.OperationCount = 0;
            foreach (var node in Nodes)
            {
                node.Visited = false;
            }
        }
    }
}

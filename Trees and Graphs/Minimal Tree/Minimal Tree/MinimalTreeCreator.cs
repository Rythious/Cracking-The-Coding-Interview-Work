using System;

namespace Minimal_Tree
{
    internal class MinimalTreeCreator
    {
        internal static void Create(int[] intArray)
        {
            // Since the array is sorted and unique, the median value should be the root node.
            var rootIndex = intArray.Length / 2;

            // Our rootIndex doesn't account for the 0-based array yet.  If the length was odd, we already rounded down because of the integer division.  
            // Even lengths need adjusted though.
            if (intArray.Length % 2 == 0)
            {
                rootIndex--;
            }

            var rootValue = intArray[rootIndex];

            Console.WriteLine($"Decided that {rootValue} should be the root node");
            var rootNode = new Node(rootValue);

            AddMedianValueToTheTree(intArray, rootNode);

            rootNode.OutputOrderBreadthFirst();
        }

        private static void AddMedianValueToTheTree(int[] intArray, Node rootNode)
        {
            if (intArray.Length == 1)
            {
                Console.WriteLine($"Decided that {intArray[0]} is the next value to add.");
                rootNode.InsertValueIntoTree(intArray[0]);
                return;
            }

            var medianIndex = intArray.Length / 2;

            if (intArray.Length % 2 == 0)
            {
                medianIndex--;
            }

            if (rootNode.Value != intArray[medianIndex])
            {
                Console.WriteLine($"Decided that {intArray[medianIndex]} is the next value to add.");
                rootNode.InsertValueIntoTree(intArray[medianIndex]);
            }

            // Size of non-inclusive left array happens to be the index of the median node.
            var sizeOfLeftArray = medianIndex;

            if (sizeOfLeftArray > 0)
            {
                var leftArray = new int[sizeOfLeftArray];
                Array.Copy(intArray, 0, leftArray, 0, sizeOfLeftArray);

                Console.WriteLine($"Left array is now [{string.Join(", ", leftArray)}].");

                AddMedianValueToTheTree(leftArray, rootNode);
            }

            var sizeOfRightArray = intArray.Length - 1 - medianIndex;

            if (sizeOfRightArray > 0)
            {
                var rightArray = new int[sizeOfRightArray];
                Array.Copy(intArray, medianIndex + 1, rightArray, 0, sizeOfRightArray);

                Console.WriteLine($"Right array is now [{string.Join(", ", rightArray)}].");

                AddMedianValueToTheTree(rightArray, rootNode);
            }
        }
    }
}
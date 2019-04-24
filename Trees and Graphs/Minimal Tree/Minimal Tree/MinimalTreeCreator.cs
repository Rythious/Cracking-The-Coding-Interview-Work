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

            // Size of non-inclusive left array happens to be the index of the median node.
            var sizeOfLeftArray = rootIndex;

            if (sizeOfLeftArray > 0)
            {
                var leftArray = new int[sizeOfLeftArray];
                Array.Copy(intArray, 0, leftArray, 0, sizeOfLeftArray);

                Console.WriteLine($"Left array is now [{string.Join(", ", leftArray)}].");
            }

            var sizeOfRightArray = intArray.Length - 1 - rootIndex;

            if (sizeOfRightArray > 0)
            {
                var rightArray = new int[sizeOfRightArray];
                Array.Copy(intArray, rootIndex + 1, rightArray, 0, sizeOfRightArray);

                Console.WriteLine($"Right array is now [{string.Join(", ", rightArray)}].");
            }

            //TODO: Set this up to recursively call this, or nearly this, method.
        }
    }
}
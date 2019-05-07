using System.Collections.Generic;

namespace FlipBitToWin
{
    public class FlipBitToWin
    {
        public int FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(int binaryNumber)
        {
            var sumOfOnesList = SumOnesWhileMaintainingZeroes(binaryNumber);

            var maxCount = 0;

            var currentNode = sumOfOnesList.First;

            while(currentNode.Next != null)
            {
                if (currentNode.Value == 0)
                {
                    var sumOfSurroundingOnes = (currentNode?.Previous?.Value ?? 0) + 1 + currentNode.Next.Value;

                    if (sumOfSurroundingOnes > maxCount)
                    {
                        maxCount = sumOfSurroundingOnes;
                    }
                }

                currentNode = currentNode.Next;
            }

            if (maxCount < sumOfOnesList.First.Value)
            {
                maxCount = sumOfOnesList.First.Value;
            }

            return maxCount;
        }

        private LinkedList<int> SumOnesWhileMaintainingZeroes(int binaryNumber)
        {
            var list = new LinkedList<int>();

            for (var i = 0; i < 32; i++)
            {
                var valueToAdd = GetCountOfContinuousOnes(binaryNumber, i, 0);

                if (valueToAdd > 0 && list.Last != null && list.Last.Value > valueToAdd)
                {
                    valueToAdd = list.Last.Value;
                }

                list.AddLast(valueToAdd);
            }

            return list;
        }

        private int GetBit(int binaryNumber, int bitIndex)
        {
            var bitMask = 1 << bitIndex;
            return binaryNumber & bitMask;
        }

        private int GetCountOfContinuousOnes(int binaryNumber, int bitIndex, int currentCount)
        {
            var currentBit = GetBit(binaryNumber, bitIndex);

            if (currentBit == 0)
            {
                return 0;
            }

            var nextBit = GetBit(binaryNumber, bitIndex + 1);

            if (nextBit == 0)
            {
                return currentCount + 1;
            }

            if (bitIndex == 31)
            {
                return currentCount;
            }

            return GetCountOfContinuousOnes(binaryNumber, bitIndex + 1, currentCount + 1);
        }
    }
}

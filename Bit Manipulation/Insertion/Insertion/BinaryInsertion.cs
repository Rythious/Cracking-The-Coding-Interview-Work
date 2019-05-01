namespace Insertion
{
    public class BinaryInsertion
    {
        public static int InsertNumberIntoOtherNumber(int largerNumber, int shorterNumber, int startingPosition, int endingPosition)
        {
            //Problem states to assume startingPosition and endingPosition are valid and allow enough room for shorterNumber in largerNumber.

            int unchangingLeastSignificantNumber = 0;
            if (startingPosition > 0)
            {
                unchangingLeastSignificantNumber = ~(0 << startingPosition) & largerNumber;
            }

            var mask = -1 << (endingPosition + 1);
            largerNumber &= mask;

            var leftShiftedShorterNumber = shorterNumber << startingPosition;

            largerNumber |= leftShiftedShorterNumber;

            largerNumber |= unchangingLeastSignificantNumber;

            return largerNumber;
        }
    }
}
using Xunit;

namespace Insertion.UnitTests
{
    public class BinaryInsertionUnitTests
    {
        [Fact]
        public void ExampleProblem()
        {
            //Arrange & Act
            var result = BinaryInsertion.InsertNumberIntoOtherNumber(0b100_0000_0000, 0b1_0011, 2, 6);

            //Assert
            Assert.Equal(0b100_0100_1100, result);
        }

        [Fact]
        public void FullReplace()
        {
            //Arrange & Act
            var result = BinaryInsertion.InsertNumberIntoOtherNumber(0b100_0000_0000, 0b001_1010_1110, 0, 10);

            //Assert
            Assert.Equal(0b001_1010_1110, result);
        }

        [Fact]
        public void AllButFirstBit()
        {
            //Arrange & Act
            var result = BinaryInsertion.InsertNumberIntoOtherNumber(0b100_0000_0000, 0b01_1010_1110, 0, 9);

            //Assert
            Assert.Equal(0b101_1010_1110, result);
        }
    }
}
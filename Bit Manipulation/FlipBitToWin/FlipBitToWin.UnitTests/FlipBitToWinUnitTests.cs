using Xunit;

namespace FlipBitToWin.UnitTests
{
    public class FlipBitToWinUnitTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var flipBitToWin = new FlipBitToWin();

            //Act
            var result = flipBitToWin.FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(0b0001_0010_1011_1011_0101_0001);

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            var flipBitToWin = new FlipBitToWin();

            //Act
            var result = flipBitToWin.FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(0b1110_0000_1100_0000_1110_0001);

            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            var flipBitToWin = new FlipBitToWin();

            //Act
            var result = flipBitToWin.FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(0b0001_1101_0011_1010_1000_1101);

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            var flipBitToWin = new FlipBitToWin();

            //Act
            var result = flipBitToWin.FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(0b0);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test5()
        {
            //Arrange
            var flipBitToWin = new FlipBitToWin();

            //Act
            var result = flipBitToWin.FindMaxCountOfContinuousOnesInBinaryStringIfOneBitIsFlipped(0b111_1111_1111_1111_1111_1111_1111_1111);

            //Assert
            Assert.Equal(31, result);
        }
    }
}
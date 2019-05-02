using Xunit;

namespace BinaryToString.UnitTests
{
    public class BinaryFractionToStringUnitTests
    {
        [Fact]
        public void NormalCase()
        {
            //Arrange
            var decimalFraction = 0.625D;

            //Act
            var result = BinaryFractionToString.GetStringRepresentation(decimalFraction);

            //Assert
            Assert.Equal("0.101", result);
        }

        [Fact]
        public void OverflowCase()
        {
            //Arrange
            var decimalFraction = 0.911D;

            //Act
            var result = BinaryFractionToString.GetStringRepresentation(decimalFraction);

            //Assert
            Assert.Equal("ERROR", result);
        }

        [Fact]
        public void MaxCaseWithoutOverflow()
        {
            //Arrange
            var decimalFraction = 0.6004077394027263D;

            //Act
            var result = BinaryFractionToString.GetStringRepresentation(decimalFraction);

            //Assert
            Assert.Equal("0.10011001101101000101001001010101", result);
        }
    }
}
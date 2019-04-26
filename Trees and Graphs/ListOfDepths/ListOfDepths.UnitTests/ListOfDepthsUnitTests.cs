using System.Collections.Generic;
using Xunit;

namespace ListOfDepths.UnitTests
{
    public class ListOfDepthsUnitTests
    {
        [Fact]
        public void GivenAnUnbalancedTreeWithFiveDepthsThereShouldBeFiveListsWithTheCorrectValues()
        {
            //Arrange

            /*  Generating this tree...
                                  50
                                /    \
                              30      70
                             /  \    /  \
                            10  40  60  80
                                          \
                                          90
                                          /
                                         85
            */
            var root = new Node(50);
            root.InsertValue(30);
            root.InsertValue(70);
            root.InsertValue(10);
            root.InsertValue(40);
            root.InsertValue(60);
            root.InsertValue(80);
            root.InsertValue(90);
            root.InsertValue(85);

            //Act
            LinkedList<int>[] listArray = root.SplitTreeByDepths();

            //Assert
            Assert.True(listArray.Length == 5);
            Assert.True(listArray[0].Count == 1);
            Assert.Equal(50, listArray[0].First.Value);
            Assert.True(listArray[1].Count == 2);
            Assert.Equal(30, listArray[1].First.Value);
            Assert.Equal(70, listArray[1].Last.Value);
            Assert.True(listArray[2].Count == 4);
            Assert.Equal(10, listArray[2].First.Value);
            Assert.Equal(40, listArray[2].First.Next.Value);
            Assert.Equal(60, listArray[2].First.Next.Next.Value);
            Assert.Equal(80, listArray[2].Last.Value);
            Assert.True(listArray[3].Count == 1);
            Assert.Equal(90, listArray[3].First.Value);
            Assert.True(listArray[4].Count == 1);
            Assert.Equal(85, listArray[4].First.Value);
        }

        [Fact]
        public void GivenATreeWithOneDepthThereShouldBeOneListWithTheCorrectValue()
        {
            //Arrange

            /*  Generating this tree...
                                  50
            */
            var root = new Node(50);

            //Act
            LinkedList<int>[] listArray = root.SplitTreeByDepths();

            //Assert
            Assert.True(listArray.Length == 1);
            Assert.True(listArray[0].Count == 1);
            Assert.Equal(50, listArray[0].First.Value);
        }
    }
}

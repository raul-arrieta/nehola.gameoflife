using Moq;
using nehola.gameoflife.entities.Abstract;
using nehola.gameoflife.Entities;
using Xunit;

namespace nehola.gameoflife.entities.tests
{
    public class CellTests
    {
        [Fact]
        public void Cell_Location()
        {
            Mock<ILocation> locationMock = new Mock<ILocation>();

            var cell = new Cell(locationMock.Object);

            Assert.Equal(
                cell.Location,
                locationMock.Object
            );
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Cell_isAlive(bool isAlive)
        {
            Mock<ILocation> locationMock = new Mock<ILocation>();

            var cell = new Cell(locationMock.Object) { IsAlive = isAlive };

            Assert.Equal(
                cell.IsAlive,
                isAlive
            );
        }

        [Theory]
        [InlineData(true,true)]
        [InlineData(true,false)]
        [InlineData(false,true)]
        [InlineData(false, false)]
        public void Cell_isAlive_IsAliveNeightbor(bool isAlive, bool isNeightBor)
        {
            Mock<ILocation> locationMock = new Mock<ILocation>();
            locationMock.Setup(x => x.IsNeightbor(It.IsAny<ILocation>())).Returns(isNeightBor);

            var cell1 = new Cell(locationMock.Object) { IsAlive = isAlive };
            var cell2 = new Cell(locationMock.Object);

            Assert.Equal(
                cell1.IsAliveNeightbor(cell2),
                isAlive && isNeightBor
            );
        }

        
    }
}

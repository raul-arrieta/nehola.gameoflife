using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using nehola.gameoflife.entities.Abstract;
using nehola.gameoflife.Entities;
using Xunit;

namespace nehola.gameoflife.entities.tests
{
    public class LocationTests
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(-1,-1)]
        [InlineData(0,0)]
        public void Location_X(int x, int y)
        {
            var location = new Location(x,y);

            Assert.Equal(location.X,x);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        public void Location_Y(int x, int y)
        {
            var location = new Location(x, y);

            Assert.Equal(location.Y, y);
        }

        [Theory]
        [InlineData(1, 1,false)]
        [InlineData(1, 2,false)]
        [InlineData(1, 3, false)]
        [InlineData(1, 4, false)]
        [InlineData(1, 5, false)]
        [InlineData(1, 6, false)]
        [InlineData(1, 7, false)]
        [InlineData(2, 1, false)]
        [InlineData(2, 2, false)]
        [InlineData(2, 3, false)]
        [InlineData(2, 4, false)]
        [InlineData(2, 5, false)]
        [InlineData(2, 6, false)]
        [InlineData(2, 7, false)]
        [InlineData(3, 1, false)]
        [InlineData(3, 2, false)]
        [InlineData(3, 3, true)]
        [InlineData(3, 4, true)]
        [InlineData(3, 5, true)]
        [InlineData(3, 6, false)]
        [InlineData(3, 7, false)]
        [InlineData(4, 1, false)]
        [InlineData(4, 2, false)]
        [InlineData(4, 3, true)]
        [InlineData(4, 4, false)]
        [InlineData(4, 5, true)]
        [InlineData(4, 6, false)]
        [InlineData(4, 7, false)]
        [InlineData(5, 1, false)]
        [InlineData(5, 2, false)]
        [InlineData(5, 3, true)]
        [InlineData(5, 4, true)]
        [InlineData(5, 5, true)]
        [InlineData(5, 6, false)]
        [InlineData(5, 7, false)]
        [InlineData(6, 1, false)]
        [InlineData(6, 2, false)]
        [InlineData(6, 3, false)]
        [InlineData(6, 4, false)]
        [InlineData(6, 5, false)]
        [InlineData(6, 6, false)]
        [InlineData(6, 7, false)]
        [InlineData(7, 1, false)]
        [InlineData(7, 2, false)]
        [InlineData(7, 3, false)]
        [InlineData(7, 4, false)]
        [InlineData(7, 5, false)]
        [InlineData(7, 6, false)]
        [InlineData(7, 7, false)]
        public void Cell_isAlive_IsAliveNeightbor(int x, int y, bool isNeightBor)
        {
            var location1 = new Location(4,4);
            var location2 = new Location(x,y);

            Assert.Equal(
                location1.IsNeightbor(location2),
                isNeightBor
            );
        }
    }
}

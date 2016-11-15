using System;
using nehola.gameoflife.entities.Abstract;

namespace nehola.gameoflife.Entities
{
    public class Cell : ICell
    {
        public Cell(ILocation location)
        {
            Location = location;
        }

        public ILocation Location { get; set; }

        public bool IsAlive { get; set; }

        public bool IsAliveNeightbor(ICell cell)
        {
            return IsAlive && Location.IsNeightbor(cell.Location);
        }
    }
}
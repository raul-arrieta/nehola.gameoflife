namespace nehola.gameoflife.Entities
{
    public class Cell
    {
        public Cell(Location location)
        {
            Location = location;
        }

        private Location Location { get; }

        public bool IsAlive { get; set; }

        public bool IsAliveNeightbor(Cell cell)
        {
            return IsAlive && Location.IsNeightbor(cell.Location);
        }
    }
}
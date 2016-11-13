namespace nehola.gameoflife.Entities
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        private int X { get; }
        private int Y { get; }

        public bool IsNeightbor(Location location)
        {
            return !IsSameLocation(location) &&
                   (
                       IsPreviousRowNeightbor(location) ||
                       IsSameRowNeightbor(location) ||
                       IsNextRowNeightbor(location)
                   );
        }

        protected bool IsSameLocation(Location location)
        {
            return (X == location.X) && (Y == location.Y);
        }

        protected bool IsPreviousRowNeightbor(Location location)
        {
            return (X - 1 == location.X) &&
                   ((Y + 1 == location.Y) || (Y == location.Y) || (Y - 1 == location.Y));
        }

        protected bool IsSameRowNeightbor(Location location)
        {
            return (X == location.X) && ((Y + 1 == location.Y) || (Y - 1 == location.Y));
        }

        protected bool IsNextRowNeightbor(Location location)
        {
            return (X + 1 == location.X) &&
                   ((Y + 1 == location.Y) || (Y == location.Y) || (Y - 1 == location.Y));
        }
    }
}
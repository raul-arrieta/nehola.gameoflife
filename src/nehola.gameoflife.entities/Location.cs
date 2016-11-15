using nehola.gameoflife.entities.Abstract;

namespace nehola.gameoflife.Entities
{
    public class Location: ILocation
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsNeightbor(ILocation location)
        {
            return !IsSameLocation(location) &&
                   (
                       IsPreviousRowNeightbor(location) ||
                       IsSameRowNeightbor(location) ||
                       IsNextRowNeightbor(location)
                   );
        }

        protected bool IsSameLocation(ILocation location)
        {
            return (X == location.X) && (Y == location.Y);
        }

        protected bool IsPreviousRowNeightbor(ILocation location)
        {
            return (X - 1 == location.X) &&
                   ((Y + 1 == location.Y) || (Y == location.Y) || (Y - 1 == location.Y));
        }

        protected bool IsSameRowNeightbor(ILocation location)
        {
            return (X == location.X) && ((Y + 1 == location.Y) || (Y - 1 == location.Y));
        }

        protected bool IsNextRowNeightbor(ILocation location)
        {
            return (X + 1 == location.X) &&
                   ((Y + 1 == location.Y) || (Y == location.Y) || (Y - 1 == location.Y));
        }
    }
}
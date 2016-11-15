
namespace nehola.gameoflife.entities.Abstract
{
    public interface ICell
    {
        ILocation Location { get; set; }
        bool IsAlive { get; set; }

        bool IsAliveNeightbor(ICell cell);
    }
}

using nehola.gameoflife.Entities;

namespace nehola.gameoflife.Logger
{
    public interface IWorldLogger
    {
        void PrintGeneration(int generation);
        void PrintSeparator();
        void PrintForCell(Cell cell);
        void PrintForRow(int row);
    }
}
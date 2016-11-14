
namespace nehola.gameoflife.Entities.Logger
{
    public interface IWorldLogger
    {
        void PrintGeneration(int generation);
        void PrintSeparator();
        void PrintForCell(Cell cell);
        void PrintForRowBegin(int row);
        void PrintForRowEnd(int row);
    }
}
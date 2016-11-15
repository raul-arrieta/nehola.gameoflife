using nehola.gameoflife.entities.Abstract;

namespace nehola.gameoflife.Entities.Logger
{
    public interface IWorldLogger
    {
        void PrintGeneration(int generation);
        void PrintSeparator();
        void PrintForCell(ICell cell);
        void PrintForRowBegin(int row);
        void PrintForRowEnd(int row);
    }
}
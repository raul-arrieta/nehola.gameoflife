using nehola.gameoflife.entities.Abstract;
using System;

namespace nehola.gameoflife.Entities.Logger
{
    public class ConsoleWorldLogger : IWorldLogger
    {
        public void PrintGeneration(int generation)
        {
            Console.WriteLine(String.Format("Generation #{0}", generation));
        }

        public void PrintSeparator()
        {
            Console.WriteLine("----------------------------------------------------------");
        }

        public void PrintForCell(ICell cell)
        {
            Console.Write(cell.IsAlive ? "#" : " ");
        }
        
        public void PrintForRowBegin(int row)
        {

        }

        public void PrintForRowEnd(int row)
        {
            Console.WriteLine();
        }
    }
}
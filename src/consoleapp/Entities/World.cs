using System;
using nehola.gameoflife.Logger;

namespace nehola.gameoflife.Entities
{
    public class World
    {
        private int Generation { get; set; }

        public World(int sizeX, int sizeY)
        {
            Cells = new Cell[sizeX, sizeY];
            IterateAndDo((x, y) => { Cells[x, y] = new Cell(new Location(x, y)); }, x => { });
        }

        private Cell[,] Cells { get; }

        public void Populate()
        {
            var rand = new Random();
            IterateAndDo((x, y) => { Cells[x, y].IsAlive = rand.Next(0, 2) == 0; }, x => { });
        }

        public World Evolve()
        {
            var nextGeneration = new World(Cells.GetLength(0), Cells.GetLength(1))
            {
                Generation = Generation + 1
            };

            IterateAndDo(
                (x, y) => { nextGeneration.Cells[x, y].IsAlive = CalculateLiveInNextGeneration(Cells[x, y]); },
                x => { }
            );
            return nextGeneration;
        }

        internal void Print(IWorldLogger logger)
        {
            logger.PrintGeneration(Generation);
            logger.PrintSeparator();
            IterateAndDo(
                (x, y) => { logger.PrintForCell(Cells[x, y]); },
                logger.PrintForRow
            );
            logger.PrintSeparator();
        }

        private void IterateAndDo(Action<int, int> actionForCell, Action<int> actionForRow)
        {
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                    actionForCell(x, y);
                actionForRow(x);
            }
        }

        /// <summary>
        ///     Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        ///     Any live cell with two or three live neighbours lives on to the next generation.
        ///     Any live cell with more than three live neighbours dies, as if by overcrowding.
        ///     Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>
        private bool CalculateLiveInNextGeneration(Cell cell)
        {
            var numberOfAliveNeighbors = 0;
            IterateAndDo(
                (x, y) =>
                {
                    if (Cells[x, y].IsAliveNeightbor(cell))
                        numberOfAliveNeighbors++;
                }, x => { }
            );

            return (cell.IsAlive && ((numberOfAliveNeighbors == 2) || (numberOfAliveNeighbors == 3)))
                   //Any live cell with two or three live neighbours lives on to the next generation.
                   || (!cell.IsAlive && (numberOfAliveNeighbors == 3));
                //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        }
    }
}
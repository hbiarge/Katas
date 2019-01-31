using System;
using System.Linq;

namespace Game.Presenters
{
    public class ConsolePresenter
    {
        public void PrintBoard(Board board)
        {
            Console.Clear();

            var rows = board.Cells.GroupBy(c => c.Coordinate.X);

            foreach (var row in rows)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.IsAlive ? "X" : "-");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public sealed class Board
    {
        public const int MaxNumberOfRows = 99;
        public const int MaxNumberOfColumns = 99;

        private readonly HashSet<Cell> _cells = new HashSet<Cell>();

        public Board(int rows, int columns, HashSet<Coordinate> liveCells = null)
        {
            // Validate rows and columns
            if (rows < 1 || rows > MaxNumberOfRows)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(rows),
                    message: "Invalid number of rows. The valid values should be between 1 and 99 and the current is {0}",
                    actualValue: rows);
            }

            if (columns < 1 || columns > MaxNumberOfColumns)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(columns),
                    message: "Invalid number of columns. The valid values should be between 1 and 99 and the current is {0}",
                    actualValue: columns);
            }

            Rows = rows;
            Columns = columns;

            if (liveCells == null)
            {
                liveCells = new HashSet<Coordinate>();
            }

            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    var coordinate = new Coordinate(row, column);

                    if (liveCells.Contains(coordinate))
                    {
                        _cells.Add(new AliveCell(coordinate));
                    }
                    else
                    {
                        _cells.Add(new NotAliveCell(coordinate));
                    }
                }
            }
        }

        public int Rows { get; }

        public int Columns { get; }

        public IEnumerable<Cell> Cells => _cells
            .OrderBy(c => c.Coordinate.X)
            .ThenBy(c => c.Coordinate.Y);

        public int NumberOfCells => _cells.Count;

        public int NumberOfLiveCells => _cells.Count(c => c.IsAlive);

        public int CountAliveNeighbours(Cell cell)
        {
            int neighbours = 0;

            // Filter valid coordinates that exist in the board
            var neighboursCoordinates = cell.GetNeighbours()
                .Where(c => c.X <= Rows && c.Y <= Columns);

            foreach (var neighboursCoordinate in neighboursCoordinates)
            {
                if (IsCellAlive(neighboursCoordinate))
                {
                    neighbours++;
                }
            }

            return neighbours;
        }

        private bool IsCellAlive(Coordinate coordinate)
        {
            if (CanManageCoordinate(coordinate) == false)
            {
                return false;
            }

            var cell = _cells.First(c => c.Coordinate.Equals(coordinate));
            return cell.IsAlive;
        }

        private bool CanManageCoordinate(Coordinate coordinate)
        {
            if (coordinate.X > Columns)
            {
                return false;
            }

            if (coordinate.Y > Rows)
            {
                return false;
            }

            return true;
        }
    }
}
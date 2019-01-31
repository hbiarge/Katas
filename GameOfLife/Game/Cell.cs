using System.Collections.Generic;

namespace Game
{
    public abstract class Cell
    {
        protected Cell(Coordinate coordinate, bool isAlive = false)
        {
            Coordinate = coordinate;
            IsAlive = isAlive;
        }

        public Coordinate Coordinate { get; }

        public bool IsAlive { get; }

        public override bool Equals(object obj)
        {
            var instance = obj as Cell;

            return instance != null
                   && Coordinate.Equals(instance.Coordinate);
        }

        public override int GetHashCode()
        {
            return Coordinate.GetHashCode();
        }

        public IEnumerable<Coordinate> GetNeighbours()
        {
            // 1,1      2,1     3,1
            // 1,2      2,2     3,2
            // 1,3      2,3     3,3

            // Return only valid coordinates
            if (Coordinate.X - 1 > 0)
            {
                if (Coordinate.Y - 1 > 0)
                {
                    yield return new Coordinate(Coordinate.X - 1, Coordinate.Y - 1);
                }

                yield return new Coordinate(Coordinate.X - 1, Coordinate.Y);

                if (Coordinate.Y + 1 <= Board.MaxNumberOfRows)
                {
                    yield return new Coordinate(Coordinate.X - 1, Coordinate.Y + 1);
                }
            }

            if (Coordinate.Y - 1 > 0)
            {
                yield return new Coordinate(Coordinate.X, Coordinate.Y - 1);
            }

            if (Coordinate.Y + 1 <= Board.MaxNumberOfRows)
            {
                yield return new Coordinate(Coordinate.X, Coordinate.Y + 1);
            }

            if (Coordinate.X + 1 <= Board.MaxNumberOfColumns)
            {
                if (Coordinate.Y - 1 > 0)
                {
                    yield return new Coordinate(Coordinate.X + 1, Coordinate.Y - 1);
                }

                yield return new Coordinate(Coordinate.X + 1, Coordinate.Y);

                if (Coordinate.Y + 1 <= Board.MaxNumberOfRows)
                {
                    yield return new Coordinate(Coordinate.X + 1, Coordinate.Y + 1);
                }
            }
        }
    }
}

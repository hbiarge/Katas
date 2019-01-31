using System;

namespace Game
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            if (x < 1 || x > Board.MaxNumberOfColumns)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(x),
                    actualValue: x,
                    message: "The value x should be between 1 and 99. The current value is {0}");
            }

            if (y < 1 || y > Board.MaxNumberOfRows)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(y),
                    actualValue: y,
                    message: "The value y should be between 1 and 99. The current value is {0}");
            }

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}
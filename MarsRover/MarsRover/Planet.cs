using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover
{
    public class Planet
    {
        private readonly HashSet<Point> _obstacles = new HashSet<Point>();

        public Planet(int maxX, int maxY)
        {
            MaxX = maxX - 1;
            MaxY = maxY - 1;
        }

        public int MaxX { get; }

        public int MaxY { get; }

        public int ObstaclesNumber => _obstacles.Count;

        public void AddObstacle(Point coordinate)
        {
            if (coordinate.X > MaxX
                || coordinate.X < 0
                || coordinate.Y > MaxY
                || coordinate.Y < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "The coordinate is not valid for the planet");
            }

            _obstacles.Add(coordinate);
        }

        public bool HasObstacleAtCoordinate(Point coordinate)
        {
            return _obstacles.Contains(coordinate);
        }
    }
}

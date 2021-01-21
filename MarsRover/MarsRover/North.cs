﻿using System.Drawing;

namespace MarsRover
{
    public class North : Direction
    {
        public override string Name => "N";

        public override Location TurnRight(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new East());
        }

        public override Location TurnLeft(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new West());
        }

        public override Location TryMoveForward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.Y < planet.Y)
            {
                return new Location(
                    new Point(currentCoordinates.X, currentCoordinates.Y + 1),
                    new North());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new North());
        }

        public override Location TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.Y > 0)
            {
                return new Location(
                    new Point(currentCoordinates.X, currentCoordinates.Y - 1),
                    new North());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new North());
        }
    }
}
using System.Drawing;

namespace MarsRover.Locations
{
    public class East : Direction
    {
        protected override string Name => "E";

        public override Location TurnRight(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new South());
        }

        public override Location TurnLeft(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new North());
        }

        public override Location TryMoveForward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.X < planet.MaxX)
            {
                return new Location(
                    new Point(
                        x: currentCoordinates.X + 1,
                        y: currentCoordinates.Y),
                    new East());
            }

            // Wraps over the world
            return new Location(
                new Point(
                    x: 0,
                    y: currentCoordinates.Y),
                new East());
        }

        public override Location TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.X > 0)
            {
                return new Location(
                    new Point(
                        x: currentCoordinates.X - 1,
                        y: currentCoordinates.Y),
                    new East());
            }

            // Wraps over the world
            return new Location(
                new Point(
                    x: 0,
                    y: currentCoordinates.Y),
                new East());
        }
    }
}
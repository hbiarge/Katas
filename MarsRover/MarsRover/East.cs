using System.Drawing;

namespace MarsRover
{
    public class East : Direction
    {
        public override string Name => "E";

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
            if (currentCoordinates.X < planet.X)
            {
                return new Location(
                    new Point(currentCoordinates.X + 1, currentCoordinates.Y),
                    new East());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new East());
        }

        public override Location TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.X > 0)
            {
                return new Location(
                    new Point(currentCoordinates.X - 1, currentCoordinates.Y),
                    new East());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new East());
        }
    }
}
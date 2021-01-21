using System.Drawing;

namespace MarsRover
{
    public class West : Direction
    {
        public override string Name => "W";

        public override Location TurnRight(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new North());
        }

        public override Location TurnLeft(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new South());
        }

        public override Location TryMoveForward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.X > 0)
            {
                return new Location(
                    new Point(currentCoordinates.X - 1, currentCoordinates.Y),
                    new West());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new West());
        }

        public override Location TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.X < planet.X)
            {
                return new Location(
                    new Point(currentCoordinates.X + 1, currentCoordinates.Y),
                    new West());
            }

            return new Location(
                new Point(currentCoordinates.X, currentCoordinates.Y),
                new West());
        }
    }
}
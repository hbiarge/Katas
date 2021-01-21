using System.Drawing;

namespace MarsRover.Locations
{
    public class North : Direction
    {
        protected override string Name => "N";

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
            if (currentCoordinates.Y < planet.MaxY)
            {
                return new Location(
                    new Point(
                        x: currentCoordinates.X,
                        y: currentCoordinates.Y + 1),
                    new North());
            }

            // Wraps over the world
            return new Location(
                new Point(
                    x: currentCoordinates.X,
                    y: 0),
                new North());
        }

        public override Location TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            if (currentCoordinates.Y > 0)
            {
                return new Location(
                    new Point(
                        x: currentCoordinates.X, 
                        y: currentCoordinates.Y - 1),
                    new North());
            }

            // Wraps over the world
            return new Location(
                new Point(currentCoordinates.X, planet.MaxY),
                new North());
        }
    }
}
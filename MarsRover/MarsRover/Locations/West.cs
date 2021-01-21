using System.Drawing;

namespace MarsRover.Locations
{
    public class West : Direction
    {
        protected override string Name => "W";

        public override Location TurnRight(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new North());
        }

        public override Location TurnLeft(Point currentCoordinates)
        {
            return new Location(currentCoordinates, new South());
        }

        public override MovementResult TryMoveForward(Planet planet, Point currentCoordinates)
        {
            Point candidateCoordinate;

            if (currentCoordinates.X > 0)
            {
                candidateCoordinate = new Point(
                    x: currentCoordinates.X - 1,
                    y: currentCoordinates.Y);
            }
            else
            {
                // Wraps over the world
                candidateCoordinate = new Point(
                    x: planet.MaxX,
                    y: currentCoordinates.Y);
            }

            return CreateMovementResult(
                planet: planet,
                candidateCoordinate: candidateCoordinate,
                direction: new West());
        }

        public override MovementResult TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            Point candidateCoordinate;

            if (currentCoordinates.X < planet.MaxX)
            {
                candidateCoordinate = new Point(
                    x: currentCoordinates.X + 1,
                    y: currentCoordinates.Y);
            }
            else
            {
                // Wraps over the world
                candidateCoordinate = new Point(
                    x: 0,
                    y: currentCoordinates.Y);
            }

            return CreateMovementResult(
                planet: planet,
                candidateCoordinate: candidateCoordinate,
                direction: new West());
        }
    }
}
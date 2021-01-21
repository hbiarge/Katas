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

        public override MovementResult TryMoveForward(Planet planet, Point currentCoordinates)
        {
            Point candidateCoordinate;

            if (currentCoordinates.Y < planet.MaxY)
            {
                candidateCoordinate = new Point(
                    x: currentCoordinates.X,
                    y: currentCoordinates.Y + 1);
            }
            else
            {
                // Wraps over the world
                candidateCoordinate = new Point(
                    x: currentCoordinates.X,
                    y: 0);
            }

            return CreateMovementResult(
                planet: planet,
                candidateCoordinate: candidateCoordinate,
                direction: new North());
        }

        public override MovementResult TryMoveBackward(Planet planet, Point currentCoordinates)
        {
            Point candidateCoordinate;

            if (currentCoordinates.Y > 0)
            {
                candidateCoordinate = new Point(
                    x: currentCoordinates.X,
                    y: currentCoordinates.Y - 1);
            }
            else
            {
                // Wraps over the world
                candidateCoordinate = new Point(
                    x: currentCoordinates.X,
                    y: planet.MaxY);
            }
            
            return CreateMovementResult(
                planet: planet,
                candidateCoordinate: candidateCoordinate,
                direction: new North());
        }
    }
}
using System.Drawing;

namespace MarsRover.Locations
{
    public abstract class Direction
    {
        protected abstract string Name { get; }

        public abstract Location TurnRight(Point currentCoordinates);

        public abstract Location TurnLeft(Point currentCoordinates);

        public abstract MovementResult TryMoveForward(Planet planet, Point currentCoordinates);

        public abstract MovementResult TryMoveBackward(Planet planet, Point currentCoordinates);

        public override string ToString()
        {
            return Name;
        }

        protected MovementResult CreateMovementResult(
            Planet planet,
            Point candidateCoordinate,
            Direction direction)
        {
            if (planet.HasObstacleAtCoordinate(candidateCoordinate))
            {
                return MovementResult.ObstacleFound(candidateCoordinate);
            }

            return MovementResult.Success(
                new Location(candidateCoordinate, direction));
        }
    }
}
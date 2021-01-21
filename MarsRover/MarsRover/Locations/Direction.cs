using System.Drawing;

namespace MarsRover.Locations
{
    public abstract class Direction
    {
        protected abstract string Name { get; }

        public abstract Location TurnRight(Point currentCoordinates);

        public abstract Location TurnLeft(Point currentCoordinates);

        public abstract Location TryMoveForward(Planet planet, Point currentCoordinates);

        public abstract Location TryMoveBackward(Planet planet, Point currentCoordinates);

        public override string ToString()
        {
            return Name;
        }
    }
}
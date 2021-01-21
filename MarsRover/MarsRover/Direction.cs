using System.Drawing;

namespace MarsRover
{
    public abstract class Direction
    {
        public abstract string Name { get; }

        public abstract Location TurnRight(Point coordinates);

        public abstract Location TurnLeft(Point coordinates);

        public override string ToString()
        {
            return Name;
        }
    }
}
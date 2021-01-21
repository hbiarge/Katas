using System.Drawing;

namespace MarsRover
{
    public class East : Direction
    {
        public override string Name => "E";

        public override Location TurnRight(Point coordinates)
        {
            return new Location(coordinates, new South());
        }

        public override Location TurnLeft(Point coordinates)
        {
            return new Location(coordinates, new North());
        }
    }
}
using System.Drawing;

namespace MarsRover
{
    public class North : Direction
    {
        public override string Name => "N";

        public override Location TurnRight(Point coordinates)
        {
            return new Location(coordinates, new East());
        }

        public override Location TurnLeft(Point coordinates)
        {
            return new Location(coordinates, new West());
        }
    }
}
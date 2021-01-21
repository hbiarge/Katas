using System.Drawing;

namespace MarsRover
{
    public class South : Direction
    {
        public override string Name => "S";

        public override Location TurnRight(Point coordinates)
        {
            return new Location(coordinates, new West());
        }

        public override Location TurnLeft(Point coordinates)
        {
            return new Location(coordinates, new East());
        }
    }
}
using System.Drawing;

namespace MarsRover
{
    public class West : Direction
    {
        public override string Name => "W";
        
        public override Location TurnRight(Point coordinates)
        {
            return new Location(coordinates, new North());
        }

        public override Location TurnLeft(Point coordinates)
        {
            return new Location(coordinates, new South());
        }
    }
}
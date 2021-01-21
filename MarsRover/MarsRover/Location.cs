using System.Drawing;

namespace MarsRover
{
    public class Location
    {
        private readonly Point _coordinates;
        private readonly Direction _direction;

        public Location(Point coordinates, Direction direction)
        {
            _coordinates = coordinates;
            _direction = direction;
        }

        public Location TurnLeft()
        {
            return _direction.TurnLeft(_coordinates);
        }

        public Location TurnRight()
        {
            return _direction.TurnRight(_coordinates);
        }

        public override string ToString()
        {
            return $"{_coordinates.X},{_coordinates.Y},{_direction}";
        }
    }
}
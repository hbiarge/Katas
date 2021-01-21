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

        public Location TryMoveForward(Planet planet)
        {
            return _direction.TryMoveForward(planet, _coordinates);
        }

        public Location TryMoveBackward(Planet planet)
        {
            return _direction.TryMoveBackward(planet, _coordinates);
        }

        public override string ToString()
        {
            return $"{_coordinates.X},{_coordinates.Y},{_direction}";
        }

        public static Location Default()
        {
            return new Location(
                coordinates: new Point(x: 0, y: 0),
                direction: new North());
        }
    }
}
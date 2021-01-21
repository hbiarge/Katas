using System.Drawing;

namespace MarsRover
{
    public class Rover
    {
        private Planet _planet;
        private Location _currentLocation;

        public void Land(Planet planet)
        {
            _planet = planet;
            _currentLocation = new Location(
                coordinates: new Point(x: 0, y: 0),
                direction: new North());
        }

        public string Command(string parameter)
        {
            if (parameter == Commands.TurnLeft)
            {
                _currentLocation = _currentLocation.TurnLeft();
            }

            if (parameter == Commands.TurnRight)
            {
                _currentLocation = _currentLocation.TurnRight();
            }

            return _currentLocation.ToString();
        }

        public static class Commands
        {
            public const string Default = "";
            public const string TurnLeft = "l";
            public const string TurnRight = "r";
        }
    }
}
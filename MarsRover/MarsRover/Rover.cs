using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MarsRover.Locations;

namespace MarsRover
{
    public class Rover
    {
        private readonly Dictionary<string, Func<Location, Planet, Location>> _commandsLookup = new Dictionary<string, Func<Location, Planet, Location>>
        {
            [Commands.TurnLeft] = (location, planet) => location.TurnLeft(),
            [Commands.TurnRight] = (location, planet) => location.TurnRight(),
            [Commands.MoveForward] = (location, planet) => location.TryMoveForward(planet),
            [Commands.MoveBackward] = (location, planet) => location.TryMoveBackward(planet),
        };

        private Planet _planet;
        private Location _currentLocation;

        public void Land(Planet planet)
        {
            _planet = planet;
            _currentLocation = Location.Default();
        }

        public string Command(string parameters)
        {
            var commands = parameters
                .AsEnumerable()
                .Select(x => new string(x, 1));

            foreach (var command in commands)
            {
                if (_commandsLookup.TryGetValue(command, out var func))
                {
                    _currentLocation = func(_currentLocation, _planet);
                }
            }

            return _currentLocation.ToString();
        }

        public static class Commands
        {
            public const string Default = "";
            public const string TurnLeft = "l";
            public const string TurnRight = "r";
            public const string MoveForward = "f";
            public const string MoveBackward = "b";
        }
    }
}
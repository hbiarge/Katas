using System.Drawing;
using MarsRover.Locations;

namespace MarsRover
{
    public class MovementResult
    {
        private MovementResult(bool isSuccess, Location location, string obstacle)
        {
            IsSuccess = isSuccess;
            Location = location;
            Obstacle = obstacle;
        }

        public bool IsSuccess { get; }
        
        public Location Location { get; }
        
        public string Obstacle { get; }

        public static MovementResult Success(Location location)
        {
            return new MovementResult(
                isSuccess: true, 
                location: location, 
                obstacle: null);
        }

        public static MovementResult ObstacleFound(Point coordinate)
        {
            return new MovementResult(
                isSuccess: false, 
                location: null, 
                obstacle: $"({coordinate.X},{coordinate.Y})");
        }
    }
}
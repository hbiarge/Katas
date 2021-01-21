using System.Drawing;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverInPlanetWithObstaclesTests
    {
        private readonly Rover _sut;

        public RoverInPlanetWithObstaclesTests()
        {
            var planet = new Planet(maxX: 10, maxY: 10);
            planet.AddObstacle(new Point(2, 2));
            planet.AddObstacle(new Point(2, 1));
            _sut = new Rover();
            _sut.Land(planet);
        }

        [Theory]
        [InlineData("ffrfff", "(1,2,E) (2,2)")]
        [InlineData("ffrfffrflf", "(1,1,E) (2,2) (2,1)")]
        public void RoverReportObstacles(string command, string expectedResult)
        {
            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }
    }
}
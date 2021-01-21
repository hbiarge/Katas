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
            _sut = new Rover();
            _sut.Land(planet);
        }

        [Fact]
        public void RoverReportOneObstacle()
        {
            var result = _sut.Command("ffrfff");

            result.Should().Be("(1,2,E) (2,2)");
        }
    }
}
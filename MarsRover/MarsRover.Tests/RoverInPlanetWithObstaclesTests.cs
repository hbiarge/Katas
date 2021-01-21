using System.Drawing;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverInPlanetWithObstaclesTests
    {
        private readonly Rover _sut;
        private readonly Planet _planet;

        public RoverInPlanetWithObstaclesTests()
        {
            _planet = new Planet(maxX: 6, maxY: 6);
            _sut = new Rover();
            _sut.Land(_planet);
        }

        [Theory]
        [InlineData("ffrfff", "(1,2,E) (2,2)")]
        [InlineData("ffrfffrflf", "(1,1,E) (2,2) (2,1)")]
        public void RoverReportObstacles(string command, string expectedResult)
        {
            _planet.AddObstacle(new Point(2, 2));
            _planet.AddObstacle(new Point(2, 1));

            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void RoverCanDoALapAroundTheWorld()
        {
            _planet.AddObstacle(new Point(2, 2));
            _planet.AddObstacle(new Point(0, 5));
            _planet.AddObstacle(new Point(5, 0));

            var result = _sut.Command("ffrfffrbbblllfrfrbbl");

            result.Should().Be("(0,0,N) (2,2) (0,5) (5,0)");
        }
    }
}
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        private readonly Planet _planet;
        private readonly Rover _sut;

        public RoverTests()
        {
            _planet = new Planet(x: 100, y: 100);
            _sut = new Rover();
            _sut.Land(_planet);
        }

        [Fact]
        public void RoverLands_InDefaultPosition()
        {
            var result = _sut.Command(Rover.Commands.Default);

            result.Should().Be("0,0,N");
        }

        [Theory]
        [InlineData(Rover.Commands.TurnLeft, "0,0,W")]
        [InlineData(Rover.Commands.TurnRight, "0,0,E")]
        public void RoverTurns_ChangeDirection(string command, string expectedResult)
        {
            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(Rover.Commands.MoveForward, "0,1,N")]
        [InlineData(Rover.Commands.MoveBackward, "0,0,N")]
        public void RoverMoves_ChangePosition(string command, string expectedResult)
        {
            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }
    }
}
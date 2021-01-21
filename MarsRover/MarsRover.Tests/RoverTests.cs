using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        private readonly Rover _sut;

        public RoverTests()
        {
            var planet = new Planet(maxX: 10, maxY: 10);
            _sut = new Rover();
            _sut.Land(planet);
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
        [InlineData(Rover.Commands.MoveBackward, "0,9,N")]
        public void RoverMoves_ChangePosition(string command, string expectedResult)
        {
            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("ffrff", "2,2,E")]
        [InlineData("ffbfbfbfb", "0,1,N")]
        [InlineData("ffrrff", "0,0,S")]
        [InlineData("bbllffrrff", "0,8,N")]
        public void RoverCombinedCommands_ChangePosition(string command, string expectedResult)
        {
            var result = _sut.Command(command);

            result.Should().Be(expectedResult);
        }
    }
}
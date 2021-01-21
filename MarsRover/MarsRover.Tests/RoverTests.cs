using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void RoverLands_InDefaultPosition()
        {
            var sut = new Rover();
            sut.Land(new Planet(x: 100, y: 100));

            var result = sut.Command(string.Empty);

            result.Should().Be("0,0,N");
        }
    }
}
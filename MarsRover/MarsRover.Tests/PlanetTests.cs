using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class PlanetTests
    {
        [Fact]
        public void Planet_ShouldHaveDimensions()
        {
            var sut = new Planet(x: 100, y: 100);

            sut.X.Should().Be(100);
            sut.Y.Should().Be(100);
        }
    }
}

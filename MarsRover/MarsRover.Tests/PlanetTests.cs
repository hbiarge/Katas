using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class PlanetTests
    {
        [Fact]
        public void Planet_ShouldHaveDimensions()
        {
            var sut = new Planet(maxX: 100, maxY: 100);

            sut.MaxX.Should().Be(99);
            sut.MaxY.Should().Be(99);
        }
    }
}

using System;
using System.Drawing;
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

        [Fact]
        public void Planet_CanHaveValidObstacles()
        {
            var sut = new Planet(maxX: 100, maxY: 100);

            sut.AddObstacle(new Point(1, 1));
            sut.AddObstacle(new Point(1, 1));

            sut.ObstaclesNumber.Should().Be(1);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(100, 100)]
        public void Planet_CanNotHaveInvalidObstacles(int x, int y)
        {
            var sut = new Planet(maxX: 100, maxY: 100);

            Action action = () => sut.AddObstacle(new Point(x, y));

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}

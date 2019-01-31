using System;
using FluentAssertions;
using Xunit;

namespace Game.UnitTest
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(99, 99, true)]
        [InlineData(100, 99, false)]
        [InlineData(99, 100, false)]
        public void Can_Create_A_New_Coordinate(int x, int y, bool isValid)
        {
            Action action = () => new Coordinate(x, y);

            if (isValid == false)
            {
                action.Should().Throw<ArgumentOutOfRangeException>();
            }
            else
            {
                action.Should().NotThrow();
            }
        }
    }
}
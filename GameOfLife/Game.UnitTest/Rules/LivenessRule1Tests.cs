using FluentAssertions;
using Game.Rules;
using Xunit;

namespace Game.UnitTest.Rules
{
    public class LivenessRule1Tests
    {
        [Fact]
        public void Apply_Should_Not_Be_Applied_For_Non_Live_Cells()
        {
            var sut = new LivenessRule1();
            var nonAliveCell = new NotAliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(nonAliveCell, 3);

            willBeAlive.RuleApplied.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Be_False_For_Live_Cells_With_Less_Than_2_Neighbours()
        {
            var sut = new LivenessRule1();
            var liveCell = new AliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 1);

            willBeAlive.RuleApplied.Should().BeTrue();
            willBeAlive.CellWillBeAlive.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Not_Be_Applied_For_Live_Cells_With_2_Or_More_Neighbours()
        {
            var sut = new LivenessRule1();
            var liveCell = new AliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 2);

            willBeAlive.RuleApplied.Should().BeFalse();
        }
    }
}

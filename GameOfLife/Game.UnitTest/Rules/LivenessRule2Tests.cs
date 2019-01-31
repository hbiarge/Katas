using FluentAssertions;
using Game.Rules;
using Xunit;

namespace Game.UnitTest.Rules
{
    public class LivenessRule2Tests
    {
        [Fact]
        public void Apply_Should_Be_Null_For_Non_Live_Cells()
        {
            var sut = new LivenessRule2();
            var nonAliveCell = new NotAliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(nonAliveCell, 3);

            willBeAlive.RuleApplied.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Be_False_For_Live_Cells_With_More_Than_3_Neighbours()
        {
            var sut = new LivenessRule2();
            var liveCell = new AliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 4);

            willBeAlive.RuleApplied.Should().BeTrue();
            willBeAlive.CellWillBeAlive.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Be_Null_For_Live_Cells_With_3_Or_Less_Neighbours()
        {
            var sut = new LivenessRule2();
            var liveCell = new AliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 3);

            willBeAlive.RuleApplied.Should().BeFalse();
        }
    }
}
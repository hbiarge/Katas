using FluentAssertions;
using Game.Rules;
using Xunit;

namespace Game.UnitTest.Rules
{
    public class LivenessRule4Tests
    {
        [Fact]
        public void Apply_Should_Not_Be_Applied_For_Live_Cells()
        {
            var sut = new LivenessRule4();
            var aliveCell = new AliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(aliveCell, 3);

            willBeAlive.RuleApplied.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Be_True_For_Non_Live_Cells_With_3_Neighbours()
        {
            var sut = new LivenessRule4();
            var liveCell = new NotAliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 3);

            willBeAlive.RuleApplied.Should().BeTrue();
            willBeAlive.CellWillBeAlive.Should().BeTrue();
        }

        [Fact]
        public void Apply_Should_Not_Be_Applied_For_NotLive_Cells_With_2_Or_Less_Neighbours()
        {
            var sut = new LivenessRule4();
            var liveCell = new NotAliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 2);

            willBeAlive.RuleApplied.Should().BeFalse();
        }

        [Fact]
        public void Apply_Should_Not_Be_Applied_For_NotLive_Cells_With_4_Or_More_Neighbours()
        {
            var sut = new LivenessRule4();
            var liveCell = new NotAliveCell(new Coordinate(2, 2));

            var willBeAlive = sut.Apply(liveCell, 4);

            willBeAlive.RuleApplied.Should().BeFalse();
        }
    }
}
using FluentAssertions;
using Xunit;

namespace Game.UnitTest
{
    public class BoardTests
    {
        [Fact]
        public void A_New_Board_Contains_The_Expected_Number_Of_Cells()
        {
            var board = new Board(rows: 10, columns: 10);

            board.NumberOfCells.Should().Be(100);
            board.NumberOfLiveCells.Should().Be(0);
        }
    }
}

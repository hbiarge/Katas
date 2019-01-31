using System.Collections.Generic;
using FluentAssertions;
using Game.Rules;
using Xunit;

namespace Game.UnitTest
{
    public class UniverseTests
    {
        private readonly Universe _sut;

        public UniverseTests()
        {
            _sut = new Universe(new ILivenessRule[]
            {
                new LivenessRule1(),
                new LivenessRule2(),
                new LivenessRule3(),
                new LivenessRule4()
            });
        }

        [Fact]
        public void NextGeneration_Of_An_Empty_Board_Is_An_Empty_Board()
        {
            var sourceBoard = new Board(rows: 10, columns: 10);

            var nextGenerationBoard = _sut.NextGeneration(sourceBoard);

            nextGenerationBoard.NumberOfCells.Should().Be(100);
            nextGenerationBoard.NumberOfLiveCells.Should().Be(0);
        }

        [Fact]
        public void NextGeneration_Cell_Without_Neighbours_Produces_An_Empty_Board()
        {
            var sourceBoard = new Board(
                rows: 10,
                columns: 10,
                liveCells: new HashSet<Coordinate>
                {
                    new Coordinate(5, 5)
                });

            sourceBoard.NumberOfLiveCells.Should().Be(1);

            var nextGenerationBoard = _sut.NextGeneration(sourceBoard);

            nextGenerationBoard.NumberOfLiveCells.Should().Be(0);
        }

        [Fact]
        public void NextGeneration_Cell_With_One_Neighbour_Produces_An_Empty_Board()
        {
            var sourceBoard = new Board(
                rows: 10,
                columns: 10,
                liveCells: new HashSet<Coordinate>
                {
                    new Coordinate(5, 5),
                    new Coordinate(5, 6)
                });

            sourceBoard.NumberOfLiveCells.Should().Be(2);

            var nextGenerationBoard = _sut.NextGeneration(sourceBoard);

            nextGenerationBoard.NumberOfLiveCells.Should().Be(0);
        }

        [Fact]
        public void NextGeneration_Cell_With_Two_Neighbour_Live()
        {
            var sourceBoard = new Board(
                rows: 10,
                columns: 10,
                liveCells: new HashSet<Coordinate>
                {
                    new Coordinate(5, 5),
                    new Coordinate(5, 6),
                    new Coordinate(6, 5),
                });

            sourceBoard.NumberOfLiveCells.Should().Be(3);

            var nextGenerationBoard = _sut.NextGeneration(sourceBoard);

            nextGenerationBoard.NumberOfLiveCells.Should().Be(4);
        }
    }
}
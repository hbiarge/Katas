using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Game.UnitTest
{
    public class CellTests
    {
        [Fact]
        public void GetNeighbours_Coordinates_For_TopLeft_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 1, y: 1));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(3);
            neighbours.Should().Contain(new Coordinate(1, 2));
            neighbours.Should().Contain(new Coordinate(2, 1));
            neighbours.Should().Contain(new Coordinate(2, 2));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_TopSide_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 2, y: 1));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(5);
            neighbours.Should().Contain(new Coordinate(1, 1));
            neighbours.Should().Contain(new Coordinate(1, 2));
            neighbours.Should().Contain(new Coordinate(2, 2));
            neighbours.Should().Contain(new Coordinate(3, 1));
            neighbours.Should().Contain(new Coordinate(3, 2));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_TopRight_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 99, y: 1));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(3);
            neighbours.Should().Contain(new Coordinate(98, 1));
            neighbours.Should().Contain(new Coordinate(98, 2));
            neighbours.Should().Contain(new Coordinate(99, 2));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_LeftSide_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 1, y: 2));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(5);
            neighbours.Should().Contain(new Coordinate(1, 1));
            neighbours.Should().Contain(new Coordinate(2, 1));
            neighbours.Should().Contain(new Coordinate(2, 2));
            neighbours.Should().Contain(new Coordinate(1, 3));
            neighbours.Should().Contain(new Coordinate(2, 3));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_RightSide_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x:99, y: 2));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(5);
            neighbours.Should().Contain(new Coordinate(98, 1));
            neighbours.Should().Contain(new Coordinate(99, 1));
            neighbours.Should().Contain(new Coordinate(98, 2));
            neighbours.Should().Contain(new Coordinate(98, 3));
            neighbours.Should().Contain(new Coordinate(99, 3));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_Center_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 2, y: 2));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(8);
            neighbours.Should().Contain(new Coordinate(1, 1));
            neighbours.Should().Contain(new Coordinate(2, 1));
            neighbours.Should().Contain(new Coordinate(3, 1));
            neighbours.Should().Contain(new Coordinate(1, 2));
            neighbours.Should().Contain(new Coordinate(3, 2));
            neighbours.Should().Contain(new Coordinate(1, 3));
            neighbours.Should().Contain(new Coordinate(2, 3));
            neighbours.Should().Contain(new Coordinate(3, 3));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_BottomLeft_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 1, y: 99));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(3);
            neighbours.Should().Contain(new Coordinate(1, 98));
            neighbours.Should().Contain(new Coordinate(2, 98));
            neighbours.Should().Contain(new Coordinate(2, 99));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_BottomSide_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 2, y: 99));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(5);
            neighbours.Should().Contain(new Coordinate(1, 98));
            neighbours.Should().Contain(new Coordinate(2, 98));
            neighbours.Should().Contain(new Coordinate(3, 98));
            neighbours.Should().Contain(new Coordinate(1, 99));
            neighbours.Should().Contain(new Coordinate(3, 99));
        }

        [Fact]
        public void GetNeighbours_Coordinates_For_BottomRight_Cell()
        {
            var cell = new NotAliveCell(new Coordinate(x: 99, y: 99));

            var neighbours = new HashSet<Coordinate>(cell.GetNeighbours());

            neighbours.Count.Should().Be(3);
            neighbours.Should().Contain(new Coordinate(98, 98));
            neighbours.Should().Contain(new Coordinate(98, 99));
            neighbours.Should().Contain(new Coordinate(98, 99));
        }
    }
}
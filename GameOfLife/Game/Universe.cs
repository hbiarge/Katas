using System.Collections.Generic;

namespace Game
{
    public class Universe
    {
        private readonly IEnumerable<ILivenessRule> _rules;

        public Universe(IEnumerable<ILivenessRule> rules)
        {
            _rules = rules;
        }

        public Board NextGeneration(Board board)
        {
            var liveCellsInNextIteration = new HashSet<Coordinate>();

            foreach (var cell in board.Cells)
            {
                var aliveNeighboursCount = board.CountAliveNeighbours(cell);
                var cellWillBeAlive = ApplyLivenessRules(cell, aliveNeighboursCount);

                if (cellWillBeAlive)
                {
                    liveCellsInNextIteration.Add(cell.Coordinate);
                }
            }

            return new Board(board.Rows, board.Columns, liveCellsInNextIteration);
        }

        private bool ApplyLivenessRules(Cell cell, int aliveNeighboursCount)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Apply(cell, aliveNeighboursCount);

                if (result.RuleApplied)
                {
                    return result.CellWillBeAlive;
                }
            }

            return cell.IsAlive;
        }
    }
}
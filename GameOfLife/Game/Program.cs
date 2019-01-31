using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Presenters;
using Game.Rules;

namespace Game
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var universe = new Universe(new ILivenessRule[]
            {
                new LivenessRule1(),
                new LivenessRule2(),
                new LivenessRule3(),
                new LivenessRule4()
            });

            var board = new Board(
                rows: 10,
                columns: 10,
                liveCells: new HashSet<Coordinate>
                {
                    new Coordinate(5, 4),
                    new Coordinate(5, 5),
                    new Coordinate(5, 6),
                });

            var presenter = new ConsolePresenter();

            presenter.PrintBoard(board);

            for (int i = 0; i < 100; i++)
            {
                board = universe.NextGeneration(board);
                presenter.PrintBoard(board);
                await Task.Delay(200);
            }
        }
    }
}

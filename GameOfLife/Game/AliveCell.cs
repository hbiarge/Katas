namespace Game
{
    public sealed class AliveCell : Cell
    {
        public AliveCell(Coordinate coordinate)
            : base(coordinate, isAlive: true)
        {
        }
    }
}
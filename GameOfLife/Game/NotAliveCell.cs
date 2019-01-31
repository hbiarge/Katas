namespace Game
{
    public sealed class NotAliveCell : Cell
    {
        public NotAliveCell(Coordinate coordinate)
            : base(coordinate, isAlive: false)
        {
        }
    }
}
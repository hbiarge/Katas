namespace MarsRover
{
    public class Planet
    {
        public Planet(int maxX, int maxY)
        {
            MaxX = maxX - 1;
            MaxY = maxY - 1;
        }

        public int MaxX { get; }

        public int MaxY { get; }
    }
}

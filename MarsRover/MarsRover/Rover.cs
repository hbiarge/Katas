namespace MarsRover
{
    public class Rover
    {
        private Planet _planet;

        public void Land(Planet planet)
        {
            _planet = planet;
        }

        public string Command(string parameter)
        {
            return "0,0,N";
        }
    }
}
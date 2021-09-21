namespace NotAPlanetRover.Models
{
    public class Rover : IRover
    {
        public Position Position { get; private set; }

        public Rover()
        {
            Position = new Position(0, 0, Orientation.North);
        }

        public Rover(int x, int y, Orientation orientation)
        {
            Position = new Position(x, y, orientation);
        }
    }
}

using System.ComponentModel;

namespace NotAPlanetRover.Models
{
    public record Position(int x, int y, Orientation orientation)
    {
        public override string ToString()
        {
            return $"({x}, {y}, {orientation})";
        }
    }

    public enum Orientation
    {
        North,
        West,
        South,
        East
    }
}

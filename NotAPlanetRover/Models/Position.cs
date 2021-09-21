namespace NotAPlanetRover.Models
{
    public record Position(uint x, uint y, Heading orientation)
    {
        public override string ToString()
        {
            return $"({x}, {y}, {orientation})";
        }
    }

    /// <summary>
    /// Possible rover headings.
    /// This could be replaced with 90/180/etc degrees from the start to allow any angle,
    /// but for simplicity we keep it like this.
    /// </summary>
    public enum Heading
    {
        North,
        West,
        South,
        East,
        DirectionsCount
    }
}

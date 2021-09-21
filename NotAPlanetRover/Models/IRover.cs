namespace NotAPlanetRover.Models
{
    public interface IRover
    {
        /// <summary>
        /// Current rover position
        /// </summary>
        public Position Position { get; }

        //
        /// <summary>
        /// Move the given distance on the map
        /// </summary>
        /// <param name="moveDistance">Distance in grid cells</param>
        public void Move(int moveDistance);

        //
        /// <summary>
        /// Rotate the given amount (number of quadrants) around the axis trigonometrically
        /// </summary>
        /// <param name="rotateAmount">Number of quadrants to rotate</param>
        public void Rotate(int rotateAmount);
    }
}

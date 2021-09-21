namespace NotAPlanetRover.Models
{
    public interface IRover
    {
        /// <summary>
        /// Current rover position
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// Map height
        /// </summary>
        public uint MapHeight { get; }

        /// <summary>
        /// Map width
        /// </summary>
        public uint MapWidth { get; }

        /// <summary>
        /// Move the given distance on the map
        /// </summary>
        /// <param name="moveDistance">Distance in grid cells</param>
        /// <returns>Returns true if rover can do the move, false otherwise</returns>
        public bool Move(int moveDistance);

        /// <summary>
        /// Rotate the given amount (number of quadrants) around the axis trigonometrically
        /// </summary>
        /// <param name="rotateAmount">Number of quadrants to rotate</param>
        /// <returns>Returns true if rover can do the move, false otherwise</returns>
        public bool Rotate(int rotateAmount);
    }
}

namespace NotAPlanetRover.Models
{
    public interface IMap
    {
        /// <summary>
        /// Indicates if the grid cell at (x,y) coords is clear or has an obstacle
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>True if there's an obstacle, false otherwise</returns>
        /// <remarks>Coordinates could be implemented as class or tuple if needed instead of this.
        /// Dimensions can also be moved to ulong if needed</remarks>
        bool HasObstacle(uint x, uint y);

        /// <summary>
        /// Get grid cell content at (x,y)
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns></returns>
        Obstacle GetCell(uint x, uint y);

        uint Width { get; }

        uint Height { get; }
    }
}

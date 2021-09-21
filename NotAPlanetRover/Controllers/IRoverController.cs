using NotAPlanetRover.Models;

namespace NotAPlanetRover.Controllers
{
    public interface IRoverController
    {
        /// <summary>
        /// Navigation function to handle moving the rover on the map
        /// </summary>
        /// <param name="commands">String of movements to make, such as FFRFF</param>
        public void Navigate(string commands);

        /// <summary>
        /// Gets the current rover position on the map
        /// </summary>
        /// <returns></returns>
        public Position GetRoverPosition();
    }
}

namespace NotAPlanetRover.Models
{
    public interface ICommand
    {
        /// <summary>
        /// Execute any command on any rover
        /// </summary>
        /// <param name="rover">Rover to command</param>
        /// <returns>True if the command was successful, false otherwise</returns>
        bool Execute(IRover rover);

        //Using this pattern allows applying commands to any target
        // and extending this with things like "undo" functionality
    }
}

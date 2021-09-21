namespace NotAPlanetRover.Models
{
    public interface ICommand
    {
        //Execute any command on any rover
        void Execute(IRover rover);

        //Using this pattern allows applying commands to any target
        // and extending this with things like "undo" functionality
    }
}

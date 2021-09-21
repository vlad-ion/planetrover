namespace NotAPlanetRover.Models
{
    public abstract class Command : ICommand
    {
        protected int moveDistance = 1;
        protected int rotateAmount = 1;

        ///<inheritdoc/>
        public abstract bool Execute(IRover rover);
    }

    public class Forward : Command
    {
        public override bool Execute(IRover rover)
        {
            return rover.Move(moveDistance);
        }
    }

    public class Backward : Command
    {
        public override bool Execute(IRover rover)
        {
            //moving backwards is the same as moving forwards a negative distance
            return rover.Move(-moveDistance);
        }
    }

    public class RotateLeft : Command
    {
        public override bool Execute(IRover rover)
        {
            return rover.Rotate(rotateAmount);
        }
    }

    public class RotateRight : Command
    {
        public override bool Execute(IRover rover)
        {
            //rotating right is the same as rotating left a negative ammount
            return rover.Rotate(-rotateAmount);
        }
    }
}

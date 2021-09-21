namespace NotAPlanetRover.Models
{
    public abstract class Command : ICommand
    {
        protected int moveDistance = 1;
        protected int rotateAmount = 1;
        public abstract void Execute(IRover rover);
    }

    public class Forward : Command
    {
        public override void Execute(IRover rover)
        {
            rover.Move(moveDistance);
        }
    }

    public class Backward : Command
    {
        public override void Execute(IRover rover)
        {
            //moving backwards is the same as moving forwards a negative distance
            rover.Move(-moveDistance);
        }
    }

    public class RotateLeft : Command
    {
        public override void Execute(IRover rover)
        {
            rover.Rotate(rotateAmount);
        }
    }

    public class RotateRight : Command
    {
        public override void Execute(IRover rover)
        {
            //rotating right is the same as rotating left a negative ammount
            rover.Rotate(-rotateAmount);
        }
    }
}

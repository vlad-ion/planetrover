namespace NotAPlanetRover.Models
{
    public class Rover : IRover
    {
        public Position Position { get; private set; }

        public Rover()
        {
            Position = new Position(0, 0, Heading.North);
        }

        public Rover(int x, int y, Heading orientation)
        {
            Position = new Position(x, y, orientation);
        }

        public void Move(int moveDistance)
        {
            int newX = Position.x;
            int newY = Position.y;
            switch (Position.orientation)
            {
                case Heading.North: newY += moveDistance; break;
                case Heading.South: newY -= moveDistance; break;
                case Heading.East: newX += moveDistance; break;
                case Heading.West: newX -= moveDistance; break;
            }

            Position = new Position(newX, newY, Position.orientation);
        }

        public void Rotate(int rotateAmount)
        {
            //use the fact that enums are ints and some modulo math to compute new heading directly
            Heading newHeading = (Heading)(((int)Position.orientation + rotateAmount)
                % (int)Heading.DirectionsCount);
            if (newHeading < 0)
            {
                newHeading += (int)Heading.DirectionsCount;
            }
            Position = new Position(Position.x, Position.y, newHeading);
        }
    }
}

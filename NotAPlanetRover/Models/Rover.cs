using Microsoft.Extensions.Logging;

namespace NotAPlanetRover.Models
{
    public class Rover : IRover
    {
        public Position Position { get; private set; }

        public Rover(IMap map, ILogger<Rover> logger)
        {
            m_map = map;
            m_logger = logger;
            Position = new Position(0, 0, Heading.North);
        }

        public Rover(IMap map, uint x, uint y, Heading orientation, ILogger<Rover> logger)
            : this(map, logger)
        {
            Position = new Position(x, y, orientation);
        }

        public bool Move(int moveDistance)
        {
            int newX = (int)Position.x;
            int newY = (int)Position.y;
            switch (Position.orientation)
            {
                case Heading.North: newY += moveDistance; break;
                case Heading.South: newY -= moveDistance; break;
                case Heading.East: newX += moveDistance; break;
                case Heading.West: newX -= moveDistance; break;
            }

            // do some module math to wrap x and y around the map when needed
            // we know/test the math is correct so the casts from and to uint are safe
            newX %= (int)m_map.Width;
            newY %= (int)m_map.Height;
            if (newX < 0) { newX += (int)m_map.Width; }
            if (newY < 0) { newY += (int)m_map.Height; }

            if (m_map.HasObstacle((uint)newX, (uint)newY))
            {
                var obstacle = m_map.GetCell((uint)newX, (uint)newY);
                m_logger.LogError($"Rover hit obstacle {obstacle} and can't continue");
                return false;
            }
            else
            {
                Position = new Position((uint)newX, (uint)newY, Position.orientation);
                return true;
            }
        }

        public bool Rotate(int rotateAmount)
        {
            //use the fact that enums are ints and some modulo math to compute new heading directly
            Heading newHeading = (Heading)(((int)Position.orientation + rotateAmount)
                % (int)Heading.DirectionsCount);
            if (newHeading < 0)
            {
                newHeading += (int)Heading.DirectionsCount;
            }
            Position = new Position(Position.x, Position.y, newHeading);

            //rotation is always possible in the current implementation
            return true;
        }

        public uint MapHeight { get { return m_map.Height; } }

        public uint MapWidth { get { return m_map.Width; } }

        private IMap m_map;

        private ILogger<Rover> m_logger;
    }
}

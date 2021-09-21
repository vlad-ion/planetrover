using System;

namespace NotAPlanetRover.Models
{
    public class Map : IMap
    {
        public Map(uint width, uint height, bool withObstacles = false)
        {
            grid = new Obstacle[width, height];
            Height = height;
            Width = width;

            if (withObstacles)
            {
                //Add a decent amount of obstacles, ~OBSTACLE_PERCENT% of the map
                Random rnd = new Random(DateTime.Now.Millisecond);
                int obstaclesCount = (int)Obstacle.ObstaclesCount;
                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        int rand = rnd.Next(obstaclesCount * (100 / OBSTACLE_PERCENT));
                        if (rand == 0) { rand++; } // more BigRocks instead of nothing
                        grid[i, j] = rand < obstaclesCount ? (Obstacle)rand : Obstacle.None;
                    }
                }
            }

            // TODO would be nice to print the map to console before start,
            // or after each command, including rover position
        }

        ///<inheritdoc/>
        public bool HasObstacle(uint x, uint y)
        {
            return grid[x, y] != Obstacle.None;
        }

        ///<inheritdoc/>
        public Obstacle GetCell(uint x, uint y)
        {
            return grid[x, y];
        }

        ///<inheritdoc/>
        public uint Height { get; }

        ///<inheritdoc/>
        public uint Width { get; }

        //allow derived classes to customize the grid content if needed
        //grid cells could also interact differently with the rover based on content
        protected readonly Obstacle[,] grid;

        private const int OBSTACLE_PERCENT = 10;
    }

    public enum Obstacle
    {
        None,
        BigRock,
        SmallRock,
        Alien,
        PlasmaRifle,
        ObstaclesCount
    }
}

namespace NotAPlanetRover.Models
{
    public class Map
    {
        public Map(int width, int height)
        {
            grid = new Obstacle?[width, height];
        }

        public bool HasObstacle(int x, int y)
        {
            return grid[x, y].HasValue;
        }

        //if the grid content becomes editable then remove readonly
        //grid cells could also interact differently with the rover based on content
        private readonly Obstacle?[,] grid;
    }

    public enum Obstacle
    {
        BigRock,
        SmallRock,
        Alien,
        PlasmaRifle
    }
}

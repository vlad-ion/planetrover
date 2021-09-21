namespace NotAPlanetRover.Models
{
    public class Map : IMap
    {
        public Map(uint width, uint height)
        {
            grid = new Obstacle[width, height];
            Height = height;
            Width = width;

            //TODO add a decent amount of obstacles, maybe 10% of the map
        }

        public bool HasObstacle(uint x, uint y)
        {
            return grid[x, y] != Obstacle.None;
        }

        public Obstacle GetCell(uint x, uint y)
        {
            return grid[x, y];
        }

        public uint Height { get; }

        public uint Width { get; }

        //if the grid content becomes editable then remove readonly
        //grid cells could also interact differently with the rover based on content
        protected readonly Obstacle[,] grid;
    }

    public enum Obstacle
    {
        None,
        BigRock,
        SmallRock,
        Alien,
        PlasmaRifle
    }
}

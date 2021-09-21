using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotAPlanetRover.Controllers;
using NotAPlanetRover.Models;

namespace RoverTests
{
    [TestClass]
    public class ObstacleMapTests
    {
        [TestMethod]
        public void BumpIntoObstacle()
        {
            var controller = CreateController();
            controller.Navigate("FFF");

            var position = controller.GetRoverPosition();
            //If there was no obstacle the position would be (0,1, North)
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void BumpIntoObstacleAfterTurn()
        {
            var controller = CreateController();
            controller.Navigate("RFLFLFL");

            var position = controller.GetRoverPosition();
            //If there was no obstacle the position would be (0,1, West)
            Assert.AreEqual(new Position(1, 1, Heading.West), position);
        }

        private IRoverController CreateController()
        {
            //Objects are simple enough that we don't need to mock anything for the tests here
            IMap map = new ObstacleTestMap(2, 2);
            IRover rover = new Rover(map, NullLogger<Rover>.Instance);
            IRoverController controller = new RoverController(rover,
                NullLogger<RoverController>.Instance);

            return controller;
        }

        private class ObstacleTestMap : Map
        {
            public ObstacleTestMap(uint width, uint height)
                :base(width, height)
            {
                grid[0, 0] = Obstacle.None;
                grid[0, 1] = Obstacle.BigRock;
                grid[1, 0] = Obstacle.None;
                grid[1, 1] = Obstacle.None;
            }
        }
    }
}

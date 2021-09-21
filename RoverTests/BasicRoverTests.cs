using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotAPlanetRover.Controllers;
using NotAPlanetRover.Models;

namespace RoverTests
{
    [TestClass]
    public class BasicRoverTests
    {
        [TestMethod]
        public void StaysPutOnNoCommand()
        {
            var controller = CreateController();
            controller.Navigate("");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void MoveNorth()
        {
            var controller = CreateController();
            controller.Navigate("F");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 1, Heading.North), position);
        }

        private IRoverController CreateController()
        {
            //Objects are simple enough that we don't need to mock anything for the tests here
            IRover rover = new Rover();
            IRoverController controller = new RoverController(rover,
                NullLogger<RoverController>.Instance);

            return controller;
        }
    }
}

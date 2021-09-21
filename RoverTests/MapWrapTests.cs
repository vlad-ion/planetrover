using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotAPlanetRover.Controllers;
using NotAPlanetRover.Models;

namespace RoverTests
{
    [TestClass]
    public class MapWrapTests
    {
        [TestMethod]
        public void WrapForward()
        {
            var controller = CreateController();
            controller.Navigate("FF");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void WrapBackward()
        {
            var controller = CreateController();
            controller.Navigate("BB");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void WrapLeft()
        {
            var controller = CreateController();
            controller.Navigate("LFF");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.West), position);
        }

        [TestMethod]
        public void WrapRight()
        {
            var controller = CreateController();
            controller.Navigate("LBB");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.West), position);
        }

        [TestMethod]
        public void MoveInLoop()
        {
            var controller = CreateController();
            controller.Navigate("frfrfrfr");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void MoveInLargerLoop()
        {
            var controller = CreateController();
            controller.Navigate("ffrffrffrffr");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        private IRoverController CreateController()
        {
            //Objects are simple enough that we don't need to mock anything for the tests here
            IMap map = new Map(2, 2);
            IRover rover = new Rover(map, NullLogger<Rover>.Instance);
            IRoverController controller = new RoverController(rover,
                NullLogger<RoverController>.Instance);

            return controller;
        }
    }
}

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
        public void MoveForward()
        {
            var controller = CreateController();
            controller.Navigate("F");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 1, Heading.North), position);
        }


        [TestMethod]
        public void MoveBackward()
        {
            var controller = CreateController();
            controller.Navigate("B");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, -1, Heading.North), position);
        }

        [TestMethod]
        public void MoveBackAndForth()
        {
            var controller = CreateController();
            controller.Navigate("BF");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
        }

        [TestMethod]
        public void RotateLeft()
        {
            var controller = CreateController();
            controller.Navigate("L");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.West), position);
        }


        [TestMethod]
        public void RotateRight()
        {
            var controller = CreateController();
            controller.Navigate("R");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.East), position);
        }

        [TestMethod]
        public void RotateLeftAnd()
        {
            var controller = CreateController();
            controller.Navigate("LR");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
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
        public void MoveInLoopClockwise()
        {
            var controller = CreateController();
            controller.Navigate("lflflflf");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Heading.North), position);
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

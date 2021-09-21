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
            //Objects are simple enough that we don't need to mock anything for the tests here
            IRover rover = new Rover();
            IRoverController controller = new RoverController(rover);

            controller.Navigate("");

            var position = controller.GetRoverPosition();
            Assert.AreEqual(new Position(0, 0, Orientation.North), position);
        }
    }
}

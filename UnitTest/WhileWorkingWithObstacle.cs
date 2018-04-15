using Dungeon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class WhileWorkingWithObstacle : GivenObstacle
    {
        [TestMethod]
        public void WhenCalculatingObstructedFinalPosition_ThenLocationWillNotChange()
        {
            var currentPosition = new Point(9, 10);
            var desiredPosition = new Point(10, 10);
            var finalPosition = _maze.CalculateFinalPosition(currentPosition, desiredPosition, out string message);
            Assert.IsTrue(finalPosition.Equals(currentPosition));
        }

        [TestMethod]
        public void WhenCalculatingFinalPosition_ThenLocationWillEqualExpectedPostion()
        {
            var currentPosition = new Point(0, 0);
            var desiredPosition = new Point(50, 50);
            var finalPosition = _maze.CalculateFinalPosition(currentPosition, desiredPosition, out string message);
            Assert.IsTrue(finalPosition.Equals(desiredPosition));
        }

        [TestMethod]
        public void WhenCheckingIsValidPositon_ThenValidPositionsShouldBeTrue()
        {
            bool isValid = _maze.IsValidPosition(new Point(1, 1));
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void WhenCheckingIsValidPositon_ThenInvalidPositionsShouldBeFalse()
        {
            bool isValid = _maze.IsValidPosition(_obstacleLocation);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ThenItMustContainObstacles()
        {
            Assert.IsTrue(_maze.Obstacles.Any(o => o.Equals(_obstacle)));
        }
    }
}

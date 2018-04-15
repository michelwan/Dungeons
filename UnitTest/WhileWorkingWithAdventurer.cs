using Dungeon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class WhileWorkingWithAdventurer : GivenAdventurer
    {
        [TestMethod]
        public void WhenAdventurerIsCreated_ThenLocationShouldBeTheCenterOfMaze()
        {
            var expectedLocation = _maze.CenterOfMaze;
            Assert.IsTrue(_adventurer.Location.Equals(expectedLocation));
        }

        [TestMethod]
        public void WhenMovingBeyondBoundsOfTheMaze_ThenNothing()
        {
            _adventurer.Location = new Point(1, 1);
            _adventurer.GoForward(out string message);
            Assert.IsTrue(_adventurer.Location.Equals(new Point(1, 1)));
        }
    }
}

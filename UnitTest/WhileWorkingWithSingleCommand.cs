using Dungeon;
using Dungeon.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class WhileWorkingWithSingleCommand : GivenProgrammer
    {
        [TestMethod]
        public void WhenAdventurerGoForward_ThenHeShouldGoForward()
        {
            SetAdventurerLocation(new Point(24, 24));
            AddCommandToProgrammer(new ForwardCommand(_adventurer));
            ExecuteCommands(out string message);

            Assert.IsTrue(_adventurer.Location.Equals(new Point(24, 23)));
        }

        [TestMethod]
        public void WhenAdventurerGoBackward_ThenHeShouldGoBackward()
        {
            SetAdventurerLocation(new Point(24, 24));
            AddCommandToProgrammer(new BackwardCommand(_adventurer));
            ExecuteCommands(out string message);

            Assert.IsTrue(_adventurer.Location.Equals(new Point(24, 25)));
        }

        [TestMethod]
        public void WhenAdventurerGoLeft_ThenHeShouldGoLeft()
        {
            SetAdventurerLocation(new Point(24, 24));
            AddCommandToProgrammer(new LeftCommand(_adventurer));
            ExecuteCommands(out string message);

            Assert.IsTrue(_adventurer.Location.Equals(new Point(23, 24)));
        }

        [TestMethod]
        public void WhenAdventurerGoRight_ThenHeShouldGoRight()
        {
            SetAdventurerLocation(new Point(24, 24));
            AddCommandToProgrammer(new RightCommand(_adventurer));
            ExecuteCommands(out string message);

            Assert.IsTrue(_adventurer.Location.Equals(new Point(25, 24)));
        }
    }
}

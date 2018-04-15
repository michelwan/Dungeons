using Dungeon;
using Dungeon.Command;
using Dungeon.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class WhileWorkingWithMultipleCommands : GivenProgrammer
    {

        protected List<ICommand> _listOfCommands;

        public WhileWorkingWithMultipleCommands()
        {
            _listOfCommands = new List<ICommand>()
            {
                new ForwardCommand(_adventurer),
                new ForwardCommand(_adventurer),
                new RightCommand(_adventurer)
            };

            foreach (var command in _listOfCommands)
                _programmer.Accept(command);
        }

        [TestMethod]
        public void ThenItWillContainAllCommands()
        {
            Assert.AreEqual(_programmer.Commands.Count, _listOfCommands.Count);
        }

        [TestMethod]
        public void WhenThereAreNoObstacles()
        {
            var adventurerX = _adventurer.Location.X;
            var adventurerY = _adventurer.Location.X;
            _programmer.ExecuteCommands(out string message);
            if (!_maze.Obstacles.Any(o => o.Location.X == adventurerX && o.Location.Y == adventurerY - 1))
            {
                if (!_maze.Obstacles.Any(o => o.Location.X == adventurerX && o.Location.Y == adventurerY - 2))
                {
                    if (!_maze.Obstacles.Any(o => o.Location.X == adventurerX + 1 && o.Location.Y == adventurerY - 2))
                        Assert.IsTrue(_adventurer.Location.Equals(new Point(adventurerX + 1, adventurerY - 2)));
                    else
                        Assert.IsTrue(_adventurer.Location.Equals(new Point(adventurerX, adventurerY - 2)));
                }
                else
                    Assert.IsTrue(_adventurer.Location.Equals(new Point(adventurerX, adventurerY - 1)));
            }
            else
                Assert.IsTrue(_adventurer.Location.Equals(new Point(adventurerX, adventurerY)));
        }
    }
}

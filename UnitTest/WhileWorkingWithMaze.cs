using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class WhileWorkingWithMaze : GivenMaze
    {
        [TestMethod]
        public void WhenMazeIsCreated_ThenSurfaceBoundsShouldBeDefined()
        {
            Assert.AreEqual(_maze.Bounds.Height, 50);
            Assert.AreEqual(_maze.Bounds.Width, 50);
        }
    }
}

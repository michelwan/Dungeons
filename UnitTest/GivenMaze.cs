using Dungeon;

namespace UnitTest
{
    public class GivenMaze
    {
        protected Maze _maze;

        public GivenMaze()
        {
            _maze = new Maze(new Size(50, 50));
            _maze.CreateExit();
        }
    }
}

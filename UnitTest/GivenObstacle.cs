using Dungeon;
using Dungeon.Generic;

namespace UnitTest
{
    public class GivenObstacle : GivenMaze
    {
        protected Obstacle _obstacle;
        protected Point _obstacleLocation;

        public GivenObstacle()
        {
            _obstacleLocation = new Point(10, 10);
            _obstacle = new Wall(new Point(10, 10));
            _maze.AddObstacle(_obstacle);
        }
    }
}

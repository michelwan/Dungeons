using Dungeon.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Dungeon
{
    public class Maze
    {
        public Size Bounds { get; protected set; }
        public Point CenterOfDungeons { get; protected set; }

        private readonly List<IObstacle> _obstacles;
        public IReadOnlyList<IObstacle> Obstacles { get { return _obstacles; } }

        public Maze() : this(new Size(25, 25)) { }

        public Maze(Size bounds)
        {
            Bounds = bounds;
            CenterOfDungeons = new Point(Bounds.Width / 2, Bounds.Height / 2);
            _obstacles = new List<IObstacle>();
            InitBorder();
        }

        private void InitBorder()
        {
            for (var x = 0; x < Bounds.Width; x++)
            {
                AddObstacle(new Wall(new Point(x, 0)));
                AddObstacle(new Wall(new Point(x, Bounds.Height - 1)));
            }

            for (var y = 0; y < Bounds.Height; y++)
            {
                AddObstacle(new Wall(new Point(0, y)));
                AddObstacle(new Wall(new Point(Bounds.Width - 1, y)));
            }
        }

        public void AddObstacle(IObstacle obstacle)
        {
            if (!_obstacles.Any(o => o.Location.X == obstacle.Location.X && o.Location.Y == obstacle.Location.Y))
                _obstacles.Add(obstacle);
        }

        public Point CalculateFinalPosition(Point from, Point desired, out string message)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);
            if (!IsValidPosition(newDestination))
            {
                message = GetObstacle(newDestination).GetType().Name.ToString();
                return from;
            }
            message = string.Empty;

            return newDestination;
        }

        private Point CalculatePositionX(Point desired, Point newDestination)
        {
            if (desired.X > Bounds.Width)
                newDestination = new Point(0, desired.Y);
            if (desired.X < 0)
                newDestination = new Point(Bounds.Width, desired.Y);
            return newDestination;
        }

        private Point CalculatePositionY(Point desired, Point newDestination)
        {
            if (desired.Y > Bounds.Height)
                newDestination = new Point(desired.X, 0);
            if (desired.Y < 0)
                newDestination = new Point(desired.X, Bounds.Height);
            return newDestination;
        }

        public bool IsValidPosition(Point point)
        {
            return !_obstacles.Any(x => x.Location.Equals(point));
        }

        public IObstacle GetObstacle(Point point)
        {
            if (_obstacles.Any(x => x.Location.Equals(point)))
                return _obstacles.Single(x => x.Location.Equals(point));
            return null;
        }
    }
}

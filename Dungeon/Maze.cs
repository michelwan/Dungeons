using Dungeon.Generic;
using Dungeon.Helper;
using System.Collections.Generic;
using System.Linq;

namespace Dungeon
{
    public class Maze
    {
        public Size Bounds { get; protected set; }
        public Point CenterOfMaze { get; protected set; }
        public Point EscapeGate { get; private set; }

        private readonly List<IObstacle> _obstacles;
        public IReadOnlyList<IObstacle> Obstacles { get { return _obstacles; } }

        public Maze() : this(new Size(25, 25)) { }

        public Maze(Size bounds)
        {
            Bounds = bounds;
            CenterOfMaze = new Point(Bounds.Width / 2, Bounds.Height / 2);
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

            if (IsEscapeGate(newDestination))
                message = Constants.ExitFound;
            else
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

        public void CreateExit()
        {
            for (var x = 1; x < Bounds.Width - 1; x++)
                if (!_obstacles.Any(o => o.Location.X == x && o.Location.Y == 1)
                 && !_obstacles.Any(o => o.Location.X == x - 1 && o.Location.Y == 1)
                 && !_obstacles.Any(o => o.Location.X == x + 1 && o.Location.Y == 1)
                 && !_obstacles.Any(o => o.Location.X == x && o.Location.Y == 2))
                {
                    _obstacles.Remove(_obstacles.Single(o => o.Location.X == x && o.Location.Y == 0));
                    EscapeGate = new Point(x, 0);
                    return;
                }

            //if fail to create a escape gate, we remove obstacles
            for (var y = 1; y < 4; y++)
                if (_obstacles.Any(o => o.Location.X == CenterOfMaze.X && o.Location.Y == y))
                    RemoveObstacle(_obstacles.Single(o => o.Location.X == CenterOfMaze.X && o.Location.Y == y));

            EscapeGate = new Point(CenterOfMaze.X, 0);
        }

        public void RemoveObstacle(IObstacle obstacle)
        {
            _obstacles.Remove(obstacle);
        }

        public bool IsEscapeGate(Point point)
        {
            return EscapeGate.Equals(point);
        }
    }
}

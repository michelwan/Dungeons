using Dungeon.Command;
using Dungeon.Enumeration;
using Dungeon.Generic;
using Dungeon.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dungeon
{
    public class World
    {
        private readonly Programmer _programmer;

        public Adventurer Adventurer { get; private set; }
        public Maze Maze { get; private set; }

        public World(Adventurer adventurer)
        {
            Adventurer = adventurer;
            Maze = adventurer.Dungeons;
            AddRandomObstacles();
            _programmer = new Programmer();
        }

        public bool AcceptCommands(String commandString)
        {
            _programmer.Commands = new List<ICommand>();

            var commands = commandString.ToLower().ToCharArray();
            bool success = true;
            foreach (Char command in commands)
                success = AcceptCommand(success, command);

            return success;
        }

        private bool AcceptCommand(bool success, Char command)
        {
            if (!Enum.TryParse(typeof(CommandEnum), command.ToString(), out object commandObj))
                return false;
            switch ((CommandEnum)commandObj)
            {
                case CommandEnum.z:
                    _programmer.Accept(new ForwardCommand(Adventurer));
                    break;
                case CommandEnum.s:
                    _programmer.Accept(new BackwardCommand(Adventurer));
                    break;
                case CommandEnum.q:
                    _programmer.Accept(new LeftCommand(Adventurer));
                    break;
                case CommandEnum.d:
                    _programmer.Accept(new RightCommand(Adventurer));
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool ExecuteActions(out string message)
        {
            var result = _programmer.ExecuteCommands(out message);
            if (message == Constants.ExitFound)
                return false;
            return true;
        }

        public void AddObstacles(Dictionary<Point, Type> obstacles)
        {
            if (obstacles.Any(o => o.Key.X == Adventurer.Location.X && o.Key.Y == Adventurer.Location.Y))
                obstacles.Remove(Adventurer.Location);
            foreach (var obstacle in obstacles)
                Maze.AddObstacle(CreateObstacle(obstacle.Key, obstacle.Value));
        }

        private void AddRandomObstacles(int nbObstacles = 200)
        {
            var random = new Random();
            for (var nbObstacle = 0; nbObstacle < nbObstacles; nbObstacle++)
            {
                var x = random.Next(Maze.Bounds.Width);
                var y = random.Next(Maze.Bounds.Height);
                //Check if no obstacle already on this point
                if (!Maze.Obstacles.Any(o => o.Location.X == x && o.Location.Y == y))
                    //Check if no obstacles before on x or y
                    if (!Maze.Obstacles.Any(o => (o.Location.X == x - 1 && o.Location.Y == y) && (o.Location.X == x && o.Location.Y == y - 1)))
                        Maze.AddObstacle(new Wall(new Point(x, y)));
            }
        }

        private IObstacle CreateObstacle(Point location, Type type)
        {
            if (type == typeof(Wall))
                return new Wall(location);
            else
                return null;
        }
    }
}

using Dungeon.Enumeration;
using System;
using System.Linq;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            var myWorld = new World(new Adventurer(new Maze()));
            Console.WriteLine("World created!");

            DisplayCommands();
            Console.WriteLine("Let's start the journey!");
            var input = string.Empty;
            while (!input.Equals(CommandEnum.x.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                if (input.Equals(CommandEnum.h.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    DisplayCommands();
                else
                {
                    var commandMessage = myWorld.AcceptCommands(input);
                    if (!commandMessage)
                        Console.WriteLine("Wrong command");
                    var result = myWorld.ExecuteActions(out string message);
                    if (!string.IsNullOrEmpty(message))
                        Console.WriteLine(message);
                }
                DisplayMaze(myWorld.Maze, myWorld.Adventurer);
                Console.WriteLine("Enter more commands to continue moving: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Game over... [some random music sound]");
            Console.WriteLine("Press [Enter] to exit");
            input = Console.ReadLine();
        }

        private static void DisplayCommands()
        {
            Console.Write("Commands: ");
            Console.Write($"{CommandEnum.z.ToString()}: Forward | ");
            Console.Write($"{CommandEnum.s.ToString()}: Backward | ");
            Console.Write($"{CommandEnum.d.ToString()}: Right | ");
            Console.Write($"{CommandEnum.q.ToString()}: Left | ");
            Console.Write($"{CommandEnum.x.ToString()}: Exit | ");
            Console.WriteLine($"{CommandEnum.h.ToString()}: Help");
        }

        private static void DisplayMaze(Maze maze, Adventurer adventurer)
        {
            for (var y = 0; y < maze.Bounds.Height; y++)
            {
                for (var x = 0; x < maze.Bounds.Width; x++)
                {
                    if (adventurer.Location.X == x && adventurer.Location.Y == y)
                    {
                        Console.Write("A");
                    }
                    else if (maze.Obstacles.Any(o => o.Location.X == x && o.Location.Y == y))
                    {
                        if (maze.Obstacles.Single(o => o.Location.X == x && o.Location.Y == y).GetType() == typeof(Wall))
                            Console.Write("█");
                        else
                            Console.Write("O");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

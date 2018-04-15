using Dungeon.Enumeration;
using System;

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
                    Console.WriteLine("Do something");
                }
                DisplayDungeons(myWorld.Dungeons, myWorld.Adventurer);
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

        private static void DisplayDungeons(Maze dungeons, Adventurer adventurer)
        {
            for (var y = 0; y < dungeons.Bounds.Height; y++)
            {
                for (var x = 0; x < dungeons.Bounds.Width; x++)
                {
                    if (adventurer.Location.X == x && adventurer.Location.Y == y)
                        Console.Write("A");
                    else
                        Console.Write("-");
                }
                Console.WriteLine();
            }
        }
    }
}

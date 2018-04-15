using Dungeon.Command;
using Dungeon.Enumeration;
using Dungeon.Generic;
using System;
using System.Collections.Generic;

namespace Dungeon
{
    public class World
    {
        private readonly Programmer _programmer;

        public Adventurer Adventurer { get; private set; }
        public Maze Dungeons { get; private set; }

        public World(Adventurer adventurer)
        {
            Adventurer = adventurer;
            Dungeons = adventurer.Dungeons;
            _programmer = new Programmer();
        }

        public string AcceptCommands(String commandString)
        {
            _programmer.Commands = new List<ICommand>();

            var commands = commandString.ToLower().ToCharArray();
            bool success = true;
            foreach (Char command in commands)
                success = AcceptCommand(success, command);

            return success ? String.Empty : "The adventurer look around him to kill time...";
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
            return result;
        }
    }
}

using Dungeon.Generic;
using Dungeon.Helper;
using System.Collections.Generic;

namespace Dungeon
{
    public class Programmer
    {
        public List<ICommand> Commands { get; set; }

        public Programmer()
        {
            Commands = new List<ICommand>();
        }

        public void Accept(ICommand command)
        {
            Commands.Add(command);
        }

        public bool ExecuteCommands(out string message)
        {
            foreach (var command in Commands)
            {
                var success = command.Execute(out string commandMessage);
                if (commandMessage == Constants.ExitFound)
                {
                    message = Constants.ExitFound;
                    return false;
                }
                if (!success)
                {
                    message = commandMessage;
                    return false;
                }
            }
            message = string.Empty;
            return true;
        }
    }
}

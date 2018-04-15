using Dungeon;
using Dungeon.Generic;

namespace UnitTest
{
    public class GivenProgrammer : GivenAdventurer
    {
        protected Programmer _programmer;
        protected ICommand _command;

        public GivenProgrammer()
        {
            _programmer = new Programmer();
        }

        protected void AddCommandToProgrammer(ICommand aCommand)
        {
            _command = aCommand;
            _programmer.Accept(_command);
        }

        protected void ExecuteCommands(out string message)
        {
            _programmer.ExecuteCommands(out message);
        }
    }
}

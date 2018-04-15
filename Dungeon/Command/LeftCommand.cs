using Dungeon.Generic;

namespace Dungeon.Command
{
    public class LeftCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public LeftCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute(out string message)
        {
            return Movable.GoLeft(out message);
        }
    }
}

using Dungeon.Generic;

namespace Dungeon.Command
{
    public class RightCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public RightCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute(out string message)
        {
            return Movable.GoRight(out message);
        }
    }
}

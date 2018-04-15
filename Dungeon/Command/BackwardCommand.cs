using Dungeon.Generic;

namespace Dungeon.Command
{
    public class BackwardCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public BackwardCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute(out string message)
        {
            return Movable.GoBackward(out message);
        }
    }
}

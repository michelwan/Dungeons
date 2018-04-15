using Dungeon.Generic;

namespace Dungeon.Command
{
    public class ForwardCommand : ICommand
    {
        private IMovable Movable { get; set; }

        public ForwardCommand(IMovable movable)
        {
            Movable = movable;
        }

        public bool Execute(out string message)
        {
            return Movable.GoForward(out message);
        }
    }
}

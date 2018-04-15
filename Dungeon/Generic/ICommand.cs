namespace Dungeon.Generic
{
    public interface ICommand
    {
        bool Execute(out string message);
    }
}

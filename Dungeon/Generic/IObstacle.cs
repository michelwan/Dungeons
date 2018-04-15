namespace Dungeon.Generic
{
    public interface IObstacle
    {
        Point Location { get; }
        bool IsDestructable { get; }
    }
}

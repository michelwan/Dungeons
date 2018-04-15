namespace Dungeon.Generic
{
    public abstract class Obstacle : IObstacle
    {
        public Point Location { get; protected set; }

        public Obstacle(Point location)
        {
            Location = location;
        }

        public virtual bool IsDestructable { get { return false; } }
    }
}

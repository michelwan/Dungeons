using Dungeon.Generic;

namespace Dungeon
{
    public class Wall : Obstacle
    {
        public Wall(Point location)
            : base(location)
        {
            Location = location;
        }
    }
}

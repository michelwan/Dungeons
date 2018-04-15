using Dungeon.Generic;

namespace Dungeon
{
    public class Monster : Obstacle
    {
        public Monster(Point location)
            : base(location)
        {
            Location = location;
        }

        public override bool IsDestructable { get { return true; } }
    }
}

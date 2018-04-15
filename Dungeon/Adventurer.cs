using Dungeon.Generic;

namespace Dungeon
{
    public class Adventurer : Movable
    {
        public Adventurer(Maze dungeons)
            : this(dungeons, dungeons.CenterOfDungeons)
        { }

        public Adventurer(Maze dungeons, Point gatePoint)
            : base(dungeons, gatePoint)
        {
        }
    }
}

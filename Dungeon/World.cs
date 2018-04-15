namespace Dungeon
{
    public class World
    {
        public Adventurer Adventurer { get; private set; }
        public Maze Dungeons { get; private set; }

        public World(Adventurer adventurer)
        {
            Adventurer = adventurer;
            Dungeons = adventurer.Dungeons;
        }
        
    }
}

using Dungeon;

namespace UnitTest
{
    public class GivenAdventurer : GivenMaze
    {
        protected Adventurer _adventurer;

        public GivenAdventurer() : base()
        {
            _adventurer = new Adventurer(_maze);
        }

        protected void SetAdventurerLocation(Point aLocation)
        {
            _adventurer.Location = aLocation;
        }
    }
}

namespace Dungeon
{
    public class Point
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

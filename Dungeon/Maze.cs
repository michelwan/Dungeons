namespace Dungeon
{
    public class Maze
    {
        public Size Bounds { get; protected set; }
        public Point CenterOfDungeons { get; protected set; }
        public Point EscapeGate { get; protected set; }

        public Maze() : this(new Size(25, 25)) { }

        public Maze(Size bounds)
        {
            Bounds = bounds;
            CenterOfDungeons = new Point(Bounds.Width / 2, Bounds.Height / 2);
        }
    }
}

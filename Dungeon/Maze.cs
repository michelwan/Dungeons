namespace Dungeon
{
    public class Maze
    {
        public Size Bounds { get; protected set; }
        public Point CenterOfDungeons { get; protected set; }

        public Maze() : this(new Size(25, 25)) { }

        public Maze(Size bounds)
        {
            Bounds = bounds;
            CenterOfDungeons = new Point(Bounds.Width / 2, Bounds.Height / 2);
        }

        public Point CalculateFinalPosition(Point from, Point desired, out string message)
        {
            Point newDestination = desired;
            newDestination = CalculatePositionY(desired, newDestination);
            newDestination = CalculatePositionX(desired, newDestination);

            message = string.Empty;

            return newDestination;
        }

        private Point CalculatePositionX(Point desired, Point newDestination)
        {
            if (desired.X > Bounds.Width)
                newDestination = new Point(0, desired.Y);
            if (desired.X < 0)
                newDestination = new Point(Bounds.Width, desired.Y);
            return newDestination;
        }

        private Point CalculatePositionY(Point desired, Point newDestination)
        {
            if (desired.Y > Bounds.Height)
                newDestination = new Point(desired.X, 0);
            if (desired.Y < 0)
                newDestination = new Point(desired.X, Bounds.Height);
            return newDestination;
        }
    }
}

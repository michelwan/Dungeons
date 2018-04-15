using System;

namespace Dungeon
{
    public class Point : IEquatable<Point>
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public bool Equals(Point other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}

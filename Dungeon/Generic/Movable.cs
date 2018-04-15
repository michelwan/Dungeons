using Dungeon.Enumeration;
using System;
using System.Collections.Generic;

namespace Dungeon.Generic
{
    public abstract class Movable : IMovable
    {
        public Point Location { get; set; }
        public Maze Dungeons { get; private set; }

        private static readonly Dictionary<DirectionEnum, Point> PositionalAdjustments = new Dictionary<DirectionEnum, Point>
        {
            { DirectionEnum.Forward, new Point(0, 1) },
            { DirectionEnum.Backward, new Point(0, -1) },
            { DirectionEnum.Right, new Point(1, 0) },
            { DirectionEnum.Left, new Point(-1, 0) }
        };

        protected Movable(Maze dungeons, Point location)
        {
            Dungeons = dungeons;
            Location = location;
        }

        public bool GoForward(out string message)
        {
            return Move(DirectionEnum.Backward, out message);
        }

        public bool GoBackward(out string message)
        {
            return Move(DirectionEnum.Forward, out message);
        }

        public bool GoRight(out string message)
        {
            return Move(DirectionEnum.Right, out message);
        }

        public bool GoLeft(out string message)
        {
            return Move(DirectionEnum.Left, out message);
        }

        private bool Move(DirectionEnum direction, out string message)
        {
            throw new NotImplementedException();
        }
    }
}

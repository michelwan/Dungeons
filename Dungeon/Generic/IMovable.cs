using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon.Generic
{
    public interface IMovable
    {
        Point Location { get; }
        bool GoBackward(out string message);
        bool GoForward(out string message);
        bool GoRight(out string message);
        bool GoLeft(out string message);
    }
}

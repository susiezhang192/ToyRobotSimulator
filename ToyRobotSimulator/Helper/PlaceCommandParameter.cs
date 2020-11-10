using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public class PlaceCommandParameter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }

        public PlaceCommandParameter(int x, int y, DirectionType direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}

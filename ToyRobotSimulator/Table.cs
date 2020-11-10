using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public class Table: ITable
    {
        public int width;
        public int length;
        public Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public bool IsValidPosition(int? x, int? y)
        {
            if (x == null || y == null)
                return false;
            else
            {
                return x >= 0 && x < width && y >= 0 && y < length;
            }
        }
    }
}

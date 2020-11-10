using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public interface ITable
    {
        bool IsValidPosition(int? x, int? y);
    }
}

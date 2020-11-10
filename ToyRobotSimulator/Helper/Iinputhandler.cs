using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public interface Iinputhandler
    {
        string[] getCommands(string filePath);
    }
}

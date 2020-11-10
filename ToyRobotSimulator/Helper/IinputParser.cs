using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Helper
{
    public interface IinputParser
    {
        CommandType ParseCommand(string[] rawInput);
        PlaceCommandParameter ParseCommandParameters(string[] input);
    }
}

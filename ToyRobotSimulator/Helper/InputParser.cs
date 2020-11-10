using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public class InputParser
    {
        private const int ParameterCount = 3;

        private const int CommandInputCount = 2;
        public CommandType ParseCommand(string[] rawInput)
        {
            CommandType command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }
    
        public PlaceCommandParameter ParseCommandParameters(string[] input)
        {
            DirectionType direction;
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Incorrect command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Incorrect command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
      
            return new PlaceCommandParameter(x, y, direction);
        }
    }
}

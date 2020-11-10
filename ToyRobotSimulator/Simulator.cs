using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ToyRobotSimulator
{
    public class Simulator
    {
        public Toy toy { get; private set; }
        public ITable table { get; private set; }

        public string message = string.Empty;

        public Simulator(Toy _toy, ITable _table)
        {
            toy = _toy;
            table = _table;
        }
        public string Start(string[] commands)
        {
            foreach (string command in commands)
            {
                if (toy.IsPlaced())
                {
                    message = ProcessCommand(command.Split(' '));
                }
                else if (Regex.IsMatch(command, "[PLACE]"))
                {
                   message = ProcessCommand(command.Split(' '));
                }
                
                if (message.Length > 1)
                {
                    Console.WriteLine(message);
                    message = string.Empty;
                }
            }
            return message;
        }

        public string ProcessCommand(string[] rawInput)
        {
            try
            {
                var inputParser = new InputParser();
                var command = inputParser.ParseCommand(rawInput);

                switch (command)
                {
                    case CommandType.Place:
                        var placeCommandParameter = inputParser.ParseCommandParameters(rawInput);
                        if (table.IsValidPosition(placeCommandParameter.X, placeCommandParameter.Y))
                            toy.Place(placeCommandParameter.X, placeCommandParameter.Y, placeCommandParameter.Direction);
                        break;
                    case CommandType.Move:
                        var newPosition = toy.GetNextPosition();
                        if (table.IsValidPosition(newPosition.X, newPosition.Y))
                            toy.Move(newPosition.X, newPosition.Y);
                        break;
                    case CommandType.Left:
                        toy.TurnLeft();
                        break;
                    case CommandType.Right:
                        toy.TurnRight();
                        break;
                    case CommandType.Report:
                        return toy.Report();
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            return string.Empty;
        }

    }
}

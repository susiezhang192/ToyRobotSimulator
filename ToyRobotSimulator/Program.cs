using System;
using System.IO;

namespace ToyRobotSimulator
{
    class Program
    {
        private const int tableWidth = 5;

        private const int tableLength = 5;
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
           
            Iinputhandler inputhandler = new Inputhandler();

            string[] commands = inputhandler.getCommands(args[0]);

            if (commands != null)
            {
                if (commands.Length > 0)
                {
                    Toy toy = new Toy();
                    ITable table = new Table(tableWidth, tableLength);
                    Simulator simulator = new Simulator(toy, table);
                    var message = simulator.Start(commands);
                    Console.WriteLine(message);
                }else
                {
                    Console.WriteLine(@"Please enter the commands. The correct command formats are as follows:
PLACE X,Y,DIRECTION
MOVE
RIGHT
LEFT
-------------
Please review your input file and try again.");
                }
            }
        }

    }
}

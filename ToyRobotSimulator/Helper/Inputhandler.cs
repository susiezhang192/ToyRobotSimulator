using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ToyRobotSimulator
{
    public class Inputhandler: Iinputhandler
    {
        public string[] getCommands(string filePath)
        {
            if (File.Exists(filePath) && (Path.GetExtension(filePath) == ".txt"))
            {
                string[] commands = File.ReadAllLines(filePath);
                return commands;
            }
            else
            {
                Console.WriteLine("There is no .txt file. Please try again.");
                return null;
            }
        }
    }
}

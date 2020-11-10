using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;
using System;

namespace ToyRobotSimulatorTest
{
    [TestClass]
    public class InputParserTests
    {
        [TestMethod]
        public void TestValidPlaceCommand()
        {
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 1,2,EAST".Split(' ');
            var command = inputParser.ParseCommand(rawInput);
            Assert.AreEqual(CommandType.Place, command);
        }


        [TestMethod]
        public void TestInvalidPlaceCommand()
        {
            var inputParser = new InputParser();
            string[] rawInput = "PLACETOYROBOT".Split(' ');

            var exception = Assert.ThrowsException<ArgumentException>(delegate { inputParser.ParseCommand(rawInput); });
            Assert.AreEqual(exception.Message, "Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
        }

        [TestMethod]
        public void TestValidPlaceCommandAndParams()
        {
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');
            var placeCommandParameter = inputParser.ParseCommandParameters(rawInput);

            Assert.AreEqual(4, placeCommandParameter.X);
            Assert.AreEqual(3, placeCommandParameter.Y);
            Assert.AreEqual(DirectionType.WEST, placeCommandParameter.Direction);
        }

        [TestMethod]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate
            { var placeCommandParameter = inputParser.ParseCommandParameters(rawInput); });
            Assert.AreEqual(exception.Message, "Incorrect command. Please ensure that the PLACE command is using format: PLACE X,Y,F");
        }
    }
}
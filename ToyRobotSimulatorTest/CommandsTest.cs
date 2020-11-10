using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTest
{
    [TestClass]
    public class CommandsTest
    {
        [TestMethod]
        public void ProcessValidPlaceCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 0,0,EAST".Split(' '));
            Assert.AreEqual(0, toy.X);
            Assert.AreEqual(0, toy.Y);
            Assert.AreEqual(DirectionType.EAST, toy.Direction);
        }

        [TestMethod]
        public void ProcessInValidPlaceCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE -1,0,EAST".Split(' '));
            Assert.IsNull(toy.X);
            Assert.IsNull(toy.Y);
            Assert.IsNull(toy.Direction);
        }

        [TestMethod]
        public void ProcessValidMoveCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 0,0,EAST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            Assert.AreEqual(1, toy.X);
            Assert.AreEqual(0, toy.Y);
            Assert.AreEqual(DirectionType.EAST, toy.Direction);
        }

        [TestMethod]
        public void ProcessInValidMoveCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 4,4,EAST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            Assert.AreEqual(4, toy.X);
            Assert.AreEqual(4, toy.Y);
            Assert.AreEqual(DirectionType.EAST, toy.Direction);
        }

        [TestMethod]
        public void ProcessLeftCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 4,4,NORTH".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            Assert.AreEqual(4, toy.X);
            Assert.AreEqual(4, toy.Y);
            Assert.AreEqual(DirectionType.WEST, toy.Direction);
        }

        [TestMethod]
        public void ProcessRightCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 4,4,EAST".Split(' '));
            simulator.ProcessCommand("RIGHT".Split(' '));
            Assert.AreEqual(4, toy.X);
            Assert.AreEqual(4, toy.Y);
            Assert.AreEqual(DirectionType.SOUTH, toy.Direction);
        }

        [TestMethod]
        public void ProcessReportCommand()
        {
            Toy toy = new Toy();
            ITable table = new Table(5, 5);
            Simulator simulator = new Simulator(toy, table);
            simulator.ProcessCommand("PLACE 2,3,WEST".Split(' '));
            Assert.AreEqual("2,3,WEST", toy.Report());
        }


    }
}

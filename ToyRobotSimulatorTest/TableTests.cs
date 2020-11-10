using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;


namespace ToyRobotSimulatorTest
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void TestValidPosition()
        {
            Toy toy = new Toy();
            toy.X = 2;
            toy.Y = 3;
            ITable table = new Table(5, 5);
            Assert.AreEqual(true, table.IsValidPosition(toy.X, toy.Y));
        }

        [TestMethod]
        public void TestInValidPosition()
        {
            Toy toy = new Toy();
            toy.X = 6;
            toy.Y = 6;
            ITable table = new Table(5, 5);
            Assert.AreEqual(false, table.IsValidPosition(toy.X, toy.Y));
        }
    }
}
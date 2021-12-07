namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CtorValidation()
        {
            var robots = new RobotManager(4);
            Assert.AreEqual(4, robots.Capacity);
        }

        [Test]
        public void CtorThrowException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void CountValidation()
        {
            var robots = new RobotManager(10);
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void CountValidation1()
        {
            var robots = new RobotManager(10);
            robots.Add(new Robot("P1", 100));
            Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void AddMethodThrowException()
        {
            var robots = new RobotManager(10);
            robots.Add(new Robot("P1", 100));
            
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("P1", 100)));
        }

        [Test]
        public void AddMethodThrowExceptionForCapacity()
        {
            var robots = new RobotManager(1);
            robots.Add(new Robot("P1", 100));

            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("P2", 100)));
        }

        [Test]
        public void AddMethodWorkCorrect()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void RemoveMethodWorkCorrectly()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            robots.Remove("P1");
            robots.Remove("P2");

            Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void RemoveMethodThrowException()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            robots.Remove("P1");
            robots.Remove("P3");
            robots.Remove("P2");

            Assert.Throws<InvalidOperationException>(() => robots.Remove("P4"));
        }

        [Test]
        public void WorkMethodThrowExceptionForExist()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            Assert.Throws<InvalidOperationException>(() => robots.Work("P4", "any", 50));
        }

        [Test]
        public void WorkMethodThrowExceptionForBattery()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            Assert.Throws<InvalidOperationException>(() => robots.Work("P3", "any", 150));
        }

        [Test]
        public void ChargeMethodThrowExceptionForName()
        {
            var robots = new RobotManager(3);

            robots.Add(new Robot("P1", 100));
            robots.Add(new Robot("P2", 100));
            robots.Add(new Robot("P3", 100));

            Assert.Throws<InvalidOperationException>(() => robots.Charge("P4"));
        }

        [Test]
        public void ChargeMethodWorkCorrectly()
        {
            var robots = new RobotManager(1);
            var robot = new Robot("P1", 100);

            robots.Add(robot);
            robots.Work("P1", "something", 50);
            robots.Charge("P1");

            Assert.AreEqual(100, robot.Battery);
        }
    }
}

using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void TestCtor()
        {
            var name = "WestGym";
            var capacity = 10;
            var gym = new Gym(name, capacity);

            Assert.AreEqual(gym.Name, name);
            Assert.AreEqual(gym.Capacity, capacity);
        }

        [Test]
        public void NameThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Gym(string.Empty, 1));
        }

        [Test]
        public void CapacityThrowExc()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Rado", -1));
        }

        [Test]
        public void CountTest()
        {
            var gym = new Gym("west", 1);
            var expectedCount = 1;
            gym.AddAthlete(new Athlete("Rado"));

            Assert.AreEqual(expectedCount, gym.Count);
        }

        [Test]
        public void MethodAddThrowException()
        {
            var gym = new Gym("west", 0);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Spiro")));
        }

        [Test]
        public void MethodRemoveThrowException()
        {
            var gym = new Gym("Rado", 1);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(null));
        }

        [Test]
        public void MethodRemoveWorkCorrect()
        {
            var gym = new Gym("Rado", 3);
            gym.AddAthlete(new Athlete("Spiro"));
            gym.AddAthlete(new Athlete("Miro"));
            gym.AddAthlete(new Athlete("Kiro"));

            gym.RemoveAthlete("Spiro");
            gym.RemoveAthlete("Miro");

            Assert.AreEqual(gym.Count, 1);
        }

        [Test]
        public void TestInjuredThrowException()
        {
            var gym = new Gym("west", 1);
            gym.AddAthlete(new Athlete("Miro"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void TestInjuredCorrect()
        {
            var gym = new Gym("west", 1);
            gym.AddAthlete(new Athlete("Miro"));
            var athlete = gym.InjureAthlete("Miro");

            Assert.AreEqual(gym.InjureAthlete("Miro"), athlete);
        }

        [Test]
        public void MethodReport()
        {
            var gym = new Gym("west", 1);
            gym.AddAthlete(new Athlete("Spiro"));
            var expectedMsg = $"Active athletes at west: Spiro";
            Assert.AreEqual(expectedMsg, gym.Report());
        }
    }
}

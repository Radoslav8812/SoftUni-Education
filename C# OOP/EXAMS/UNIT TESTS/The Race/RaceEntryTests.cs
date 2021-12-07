using System;
using System.Linq;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverThrowExceptionForNull()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverThrowExceptionForExist()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("Honda", 280, 3.2);
            var driver = new UnitDriver("Pesho", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverWorkCorrectly()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("Honda", 280, 3.2);
            var driver = new UnitDriver("Pesho", car);

            var result = raceEntry.AddDriver(driver);

            Assert.AreEqual("Driver Pesho added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHPThrowExceptionForLessParticipants()
        {
            var raceEntry = new RaceEntry();

            var car = new UnitCar("Honda", 280, 3.2);
            var driver = new UnitDriver("Pesho", car);

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHPWorkCorrect()
        {
            var raceEntry = new RaceEntry();

            var car = new UnitCar("Honda", 300, 3.2);
            var driver = new UnitDriver("Pesho", car);
            raceEntry.AddDriver(driver);

            var car1 = new UnitCar("Nissan", 300, 2.6);
            var driver1 = new UnitDriver("Rado", car1);
            raceEntry.AddDriver(driver1);

            var car2 = new UnitCar("Toyota", 300, 3.0);
            var driver2 = new UnitDriver("Spiro", car2);
            raceEntry.AddDriver(driver2);

            var result = raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(300, result);
        }
    }
}
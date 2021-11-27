namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void CtorValidation()
        {
            var name = "Rado";
            var capacity = 1;
            var aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);
        }

        [Test]
        public void PropertyNameThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium( null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 1));
        }

        [Test]
        public void PropertyCapacityThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Rado", -1));
        }

        [Test]
        public void CountTest()
        {
            var aquarium = new Aquarium("Rado", 1);
            var expectedCount = 1;
            aquarium.Add(new Fish("Rado"));

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void MethodAddThrowException()
        {
            var aquarium = new Aquarium("Rado", 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Spiro")));
        }

        [Test]
        public void MethodRemoveWorkCorrect()
        {
            var aquarium = new Aquarium("Rado", 3);
            aquarium.Add(new Fish("Spiro"));
            aquarium.Add(new Fish("Miro"));
            aquarium.Add(new Fish("Kiro"));

            aquarium.RemoveFish("Spiro");
            aquarium.RemoveFish("Miro");

            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void MethodRemoveThrowException()
        {
            var aquarium = new Aquarium("Rado", 1);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void MethodSellFishCorrect()
        {
            var aquarium = new Aquarium("Rado", 3);
            aquarium.Add(new Fish("Spiro"));
            aquarium.Add(new Fish("Miro"));
            aquarium.Add(new Fish("Kiro"));

            var fish = aquarium.SellFish("Spiro");

            Assert.AreEqual(fish.Name, "Spiro");
            Assert.AreEqual(fish.Available, false);
        }

        [Test]
        public void MethodSellFishThrowException()
        {
            var aquarium = new Aquarium("Rado", 1);
            aquarium.Add(new Fish("Miro"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void MethodReport()
        {
            var aquarium = new Aquarium("Rado", 1);
            aquarium.Add(new Fish("Spiro"));
            var expectedMsg = $"Fish available at Rado: Spiro";
            Assert.AreEqual(expectedMsg, aquarium.Report());
        }
    }
}

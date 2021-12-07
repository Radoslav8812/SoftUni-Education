using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddWhileCountIsLessThan16()
        {
            //Arrange
            var database = new Database();
            //Act
            database.Add(10);
            database.Add(10);
            database.Add(10);
            //Assert
            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void AddShouldThrowExceptionAbove16()
        {
            var database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }

        [Test]
        public void ValidateCtor()
        {
            int[] elementsArray = Enumerable.Range(1, 15).ToArray();
            var database = new Database(elementsArray);
            Assert.AreEqual(15, database.Count);
        }

        [Test]
        [TestCase(1, 25)]
        [TestCase(1, 17)]
        public void CtorThrowExceptionWithMoreItemsThan16(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(1, 10, 1, 9)]
        [TestCase(1, 5, 4, 1)]

        public void RemoveMustWorkIfElementsAreMoreThanZero(int start, int count, int toRemove, int result)
        {
            var elementsArray = Enumerable.Range(start, count).ToArray();
            var database = new Database(elementsArray);

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveThrowExceptionWhenElementsAreEqualToZero()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void IsFetchWorkCorrectly()
        {
            var database = new Database(1, 2, 3);

            database.Add(4);
            database.Add(5);
            database.Remove();
            database.Remove();
            database.Remove();

            var FetchedArray = database.Fetch();
            var expectedArray = new int[] { 1, 2 };

            Assert.AreEqual(expectedArray, FetchedArray);
        }
    }
}
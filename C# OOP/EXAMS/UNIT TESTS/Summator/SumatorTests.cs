using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting;

namespace UnitTest.Tests
{
    [TestFixture]
    public class SumatorTests
    {
        [Test]
        public void SumOfDigitsShouldWorkCorrectlyForSingleDigit()
        {
            var sumator = new Summator();
            var result = sumator.SumOfDigits(1);

            Assert.AreEqual(1, result);
        }
        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithMillions()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(9876543210);

            Assert.AreEqual(45, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithZero()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(0);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithNegativeNum()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(-123);

            Assert.AreEqual(6 ,result);
        }
    }
}

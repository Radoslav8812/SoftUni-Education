using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorValidation()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodSouldAddWarriorIfDoesntExist()
        {
            var arena = new Arena();

            var warrior = new Warrior("Spiro", 50, 80);
            var warrior2 = new Warrior("Miro", 100, 180);
            var warrior3 = new Warrior("Kiro", 250, 280);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);

            bool warriorExist = arena.Warriors.Contains(warrior);
            bool warrior2Exist = arena.Warriors.Contains(warrior2);
            bool warrior3Exist = arena.Warriors.Contains(warrior3);

            Assert.True(warriorExist);
            Assert.True(warrior2Exist);
            Assert.True(warrior3Exist);
        }

        [Test]
        public void EnrollMethodSouldThrowExceptionForDublication()
        {
            var arena = new Arena();
            var warrior = new Warrior("Spiro", 50, 80);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodThrowExceptionForInvalidWarriors()
        {
            var arena = new Arena();

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Spiro"));
        }

        [Test]
        public void FightMethodThrowExceptionForInvalidAttacker()
        {
            var arena = new Arena();
            var warrior = new Warrior("Spiridon", 100, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Spiridon", "Spiro"));
        }

        [Test]
        public void FightMethodThrowExceptionForInvalidDeffender()
        {
            var arena = new Arena();
            var defender = new Warrior("Spiridon", 100, 100);

            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiril", "Spiridon"));
        }

        [Test]
        public void FightShouldReduceHealthPull()
        {
            var arena = new Arena();
            var attacker = new Warrior("Spiro", 100, 50);
            var defender = new Warrior("Kiro", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(attacker.HP, defender.HP);
        }
    }
}

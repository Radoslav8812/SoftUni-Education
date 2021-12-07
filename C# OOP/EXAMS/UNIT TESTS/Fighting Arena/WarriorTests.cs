using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Rado", 50, 70)]
        [TestCase("Spiro", 10, 20)]
        [TestCase("Kiril", 1, 0)]
        public void CtorValidation(string name, int dmg, int hp)
        {
            var warrior = new Warrior(name, dmg, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        public void CtorShouldThrowExceptionForName(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 40, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-54)]
        public void CtorShouldThrowExceptionForDMG(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Spiro", dmg, 50));
        }

        [Test]
        [TestCase(-50)]
        [TestCase(-1)]
        public void CtorShouldThrowExceptionForHP(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Spiro", 40, hp));
        }

        [Test]
        [TestCase("Spiro", 20, 50, "Nikolai", 50, 40)]
        [TestCase("Spiro", 30, 50, "Nikolai", 50, 40)]
        [TestCase("Spiro", 50, 50, "Nikolai", 30, 40)]
        public void AttackMethodThrowExceptionWhenHpIsLessOrEqualTo30(string name, int dmg, int hp, string enemyName, int enemyDmg, int enemyHp)
        {
            var warrior = new Warrior(name, dmg, hp);
            var enemy = new Warrior(enemyName, enemyDmg, enemyHp);
            warrior.Attack(enemy);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        [TestCase("Spiro", 50, 50, "Nikolai", 40, 90)]
        public void AttackMethodThrowExceptionWhenHPIsLessThanEnemyDMG(string name, int dmg, int hp, string enemyName, int enemyDmg, int enemyHp)
        {
            var warrior = new Warrior(name, dmg, hp);
            var enemy = new Warrior(enemyName, enemyDmg, enemyHp);
            warrior.Attack(enemy);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        [TestCase("Spiro", 50, 100, 50, "Nikolai", 50, 100, 50)]
        [TestCase("Spiro", 100, 100, 50, "Nikolai", 50, 100, 0)]
        [TestCase("Spiro", 120, 100, 50, "Nikolai", 50, 100, 0)]
        public void AttackMethodShouldReduceHpForBothEnemies(string name, int dmg, int hp,int resultHp, string enemyName, int enemyDmg, int enemyHp, int resultEnemyHp)
        {
            var warrior = new Warrior(name, dmg, hp);
            var enemy = new Warrior(enemyName, enemyDmg, enemyHp);

            warrior.Attack(enemy);
            Assert.AreEqual(resultHp, warrior.HP);
            Assert.AreEqual(resultEnemyHp, enemy.HP);
        }
    }
}
using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void ValidationCtor()
    {
        var heroRepository = new HeroRepository();

        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void CreateMethodThrowException()
    {
        var heroRepository = new HeroRepository();

        Assert.Throws <ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateMethodThrowExceptionForExists()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("Spiro", 99);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodValidCase()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("Spiro", 99);

        var expecteMsg = heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);
        var msg = "Successfully added hero Spiro with level 99";
        Assert.AreEqual(expecteMsg, msg);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void RemoveShouldThrowNullException(string name)
    {
        var heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));
    }

    [Test]
    public void RemoveShouldWorkCorrectly()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("Rado", 99);
        heroRepository.Create(hero);
        var isRemoved = heroRepository.Remove("Rado");

        Assert.IsTrue(isRemoved);
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void HighestLvlHero()
    {
        var heroRepository = new HeroRepository();

        var hero1 = new Hero("Spiro", 99);
        var hero2= new Hero("Miro", 88);
        var hero3 = new Hero("Kiro", 77);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);

        var highestHero = heroRepository.GetHeroWithHighestLevel();
        Assert.AreSame(hero1, highestHero);
    }

    [Test]
    public void GetHeroMethod()
    {
        var heroRepository = new HeroRepository();

        var hero1 = new Hero("Spiro", 99);
        var hero2 = new Hero("Miro", 88);
        var hero3 = new Hero("Kiro", 77);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);

        var hero = heroRepository.GetHero("Spiro");
        Assert.AreSame(hero, hero1);
    }
}
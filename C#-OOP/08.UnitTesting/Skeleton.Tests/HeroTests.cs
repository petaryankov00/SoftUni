using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private string name = "Pesho";
    private int experience;
    private Axe weapon;
    private Hero hero;
    private Dummy target;
    [SetUp]
    public void SetUp()
    {
        hero = new Hero(name);
        experience = hero.Experience;
        weapon = hero.Weapon;
        target = new Dummy(5, 5);
    }

    [Test]
    public void When_NameIsGiven_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(hero.Name, name);
    }
    [Test]
    public void When_ExperienceIsGiven_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(hero.Experience, experience);
    }
    [Test]
    public void When_WeaponIsGiven_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(hero.Weapon, weapon);
    }

    [Test]
    public void When_HeroAttackAndTargetIsDead_ShouldIncreaseExperience()
    {
        hero.Attack(target);
        Assert.AreEqual(hero.Experience, experience + target.GiveExperience());
    }
  

}

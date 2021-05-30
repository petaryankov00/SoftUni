using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private int health = 5;
    private int experience = 10;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_HealthIsSet_ShouldBeSetCorrectly()
    {
        Assert.That(dummy.Health, Is.EqualTo(health));
    }

    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {
        dummy.TakeAttack(3);
        Assert.AreEqual(dummy.Health, health - 3);
    }

    [Test]
    public void When_AttackedDead_ShouldThrow()
    {
        dummy = new Dummy(-1, 5);
        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.TakeAttack(3);
        });
    }

    [Test]
    public void When_HealthIsPossitive_ShouldBeAlive()
    {
        Assert.That(dummy.IsDead, Is.EqualTo(false));
    }

    [Test]
    public void When_HealthIsZero_ShouldBeDead()
    {
        dummy = new Dummy(0, 5);
        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void When_HealthIsNegative_ShouldBeDead()
    {
        dummy = new Dummy(-1, 5);
        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void When_Dead_ShouldGiveExperience()
    {
        dummy = new Dummy(-1, experience);
        Assert.AreEqual(dummy.GiveExperience(), experience);
    }

    [Test]
    public void When_Alive_ShouldThrow()
    {      
        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        });
    }
}

using NUnit.Framework;
using System;
using System.Data;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }

    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShoudlBeSetCorrectly()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void When_AxeAttacks_ShouldLooseDurabillity()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }
    [Test]
    public void When_AxeAttacksWithZeroDurability_ShouldTrowException()
    {
        dummy = new Dummy(50, 50);
        Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });
      
    }
}
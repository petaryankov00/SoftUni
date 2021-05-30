
using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_InitiliazeWarriors()
        {
            Assert.That(arena.Warriors,Is.Not.Null);
        }

        [Test]
        public void When_ArenaIsEmptyCount_ShouldBeZero()
        {
            Assert.AreEqual(arena.Count, 0);
        }

        [Test]
        public void When_WarriorExistEnroll_ShouldThrowException()
        {
            Warrior warrior = new Warrior("sasa", 10, 50);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("sasa", 2123, 1233));
            });
        }

        [Test]
        public void When_Enroll_ShouldIncreaseArenaCount()
        {
            Warrior warrior = new Warrior("sasa", 10, 50);
            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_Enroll_ShouldAddToWarriorsReadOnly()
        {
            Warrior warrior = new Warrior("sasa", 10, 50);
            arena.Enroll(warrior);

            Assert.That(arena.Warriors.Any(x=>x.Name == "sasa"), Is.True);
        }

        [Test]
        [TestCase("Attacker","Defender")]
        [TestCase("Defender", "Attacker")]
        public void When_WarriorDoesNotExist_ShouldThrowException(string existingName,string missingName)
        {
            arena.Enroll(new Warrior(existingName, 50, 50));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(existingName, missingName);
            });
        }

        [Test]
        public void When_BothDoesNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("pEHSO", "SASA");
            });
        }

        [Test]
        public void Fight_BothWarriorsLooseHpInFights()
        {
            Warrior attacker = new Warrior("Attacker", 10, 50);
            Warrior defender = new Warrior("Defender", 10, 50);

            int health = 50;

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(health-defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(health - attacker.Damage));
        }

    }
}

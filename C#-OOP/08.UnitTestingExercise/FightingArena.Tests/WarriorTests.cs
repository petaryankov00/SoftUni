
using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("",10,100)]
        [TestCase(" ",10,100)]
        [TestCase(null,10,100)]
        [TestCase("Pesho", 0, 100)]
        [TestCase("Pesho", -10, 100)]
        [TestCase("Pesho", 10, -1)]
        public void When_InputDataIsInvalid_ShouldThrowExceptuion(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void When_InputDataIsValid()
        {
            string name = "Name";
            int damage = 10;
            int hp = 100;
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);
        }

        [Test]
        public void When_AttackHpIsTooLow_ShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 10, 20);
            Warrior warriorToAttack = new Warrior("Pesho", 10, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void When_AttackHpOfEnemyIsTooLow_ShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 10, 50);
            Warrior warriorToAttack = new Warrior("Pesho", 10, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void When_AttackHpOfEnemyIsBiggerThanOurs_ShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 10, 50);
            Warrior warriorToAttack = new Warrior("Pesho", 70, 80);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void When_AttackIsValid_ShouldDecreaseOurHp()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            Warrior warriorToAttack = new Warrior("Pesho", 20, 80);

            int decreasedHp = warrior.HP - warriorToAttack.Damage;

            warrior.Attack(warriorToAttack);

            Assert.That(warrior.HP, Is.EqualTo(decreasedHp));
               
        }

        [Test]
        public void When_OurDamageIsGreaterThanEnemies_ShouldBeZero()
        {
            Warrior warrior = new Warrior("Pesho", 90, 100);
            Warrior warriorToAttack = new Warrior("Pesho", 20, 80);

            warrior.Attack(warriorToAttack);

            Assert.That(warriorToAttack.HP, Is.EqualTo(0));

        }

        [Test]
        public void When_AttackIsValid_ShouldDecreaseEnemiesHp()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            Warrior warriorToAttack = new Warrior("Pesho", 20, 80);

            int decreasedHp = warriorToAttack.HP - warrior.Damage;

            warrior.Attack(warriorToAttack);

            Assert.That(warriorToAttack.HP, Is.EqualTo(decreasedHp));

        }


    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void When_AddComputerThatExist()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);
            });
        }
        [Test]
        public void When_AddComputer_ShouldIncreaseCount()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_GetComputerThatDoesNotExist()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer("Dell", "520");
            });
           
        }

        [Test]
        public void When_GetComputerThatExist()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            computerManager.AddComputer(computer);

            Assert.That(computerManager.GetComputer("sasa", "happy"), Is.EqualTo(computer));

        }

        [Test]
        public void When_RemoveComputer()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            computerManager.AddComputer(computer);

            Assert.That(computerManager.RemoveComputer("sasa", "happy"), Is.EqualTo(computer));
        }

        [Test]
        public void When_GetComputerByManufacturer()
        {
            Computer computer = new Computer("sasa", "happy", 20);
            Computer computer2 = new Computer("sasa", "dell", 40);
            Computer computer3 = new Computer("laptopbg", "asus", 60);
            List<Computer> computersTest = new List<Computer> { computer, computer2 };
            
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            var computers = computerManager.GetComputersByManufacturer("sasa");

            Assert.That(computers, Is.EqualTo(computersTest));        
        }

        [Test]
        public void When_AddComputerNull()
        {
            Computer computer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(computer);
            });
        }

        [Test]
        public void When_GetComputerWithManufacturerNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer(null,"sasa");
            });
        }

        [Test]
        public void When_GetComputerWithModelNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer("sasa", null);
            });
        }

        [Test]
        public void When_GetComputersByManufacturesWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            });
        }
        [Test]
        public void RemoveComputerExceptionIfComputerNull()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            Assert.That(() => list.RemoveComputer(null, null), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveComputerDecreaseCount()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            list.RemoveComputer("HP", "Proliant");
            Assert.AreEqual(1, list.Computers.Count);
        }
    }
}

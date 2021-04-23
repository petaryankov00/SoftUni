namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        [Test]
        public void When_CreateAquarimWithNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 10);
            });
        }

        [Test]
        public void When_CreateAquarimWithEmptyName_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium("", 10);
            });
        }

        [Test]
        public void When_CreateAquarimNegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Pesho", -10);
            });
        }

        [Test]
        public void When_CreateAquarium_ShouldSetCorrect()
        {
            string name = "Pesho";
            int capacity = 10;
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.That(name, Is.EqualTo(aquarium.Name));
            Assert.That(capacity, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        public void When_AddFishToFullAquarium()
        {
            Aquarium aquarium = new Aquarium("sasa", 1);
            Fish fish = new Fish("sas");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void When_AddFishIncreaseCount()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_RemoveFishThatDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("pESHO");
            });
        }

        [Test]
        public void When_RemoveFish_ShouldDecreaseCount()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            Fish fish2 = new Fish("sasa");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            aquarium.RemoveFish("sasa");

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_SellFishThatDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("pESHO");
            });
        }

        [Test]
        public void When_SellFishThatExist_ReturnFish()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            Fish fish2 = new Fish("sasa");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.That(fish2, Is.EqualTo(aquarium.SellFish("sasa")));
        }

        [Test]
        public void When_SellFishThatExist_ReturnFalse()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            Fish fish = new Fish("sas");
            Fish fish2 = new Fish("sasa");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.SellFish("sasa");

            Assert.That(fish2.Available, Is.EqualTo(false));
        }

        [Test]
        public void TestReport()
        {
            Aquarium aquarium = new Aquarium("sasa", 3);
            List<Fish> fishTest = new List<Fish>();
            Fish fish = new Fish("sas");
            Fish fish2 = new Fish("sasa");

            fishTest.Add(fish);
            fishTest.Add(fish2);

            aquarium.Add(fish);
            aquarium.Add(fish2);

            string fishNames = string.Join(", ", fishTest.Select(f => f.Name));
            string report = $"Fish available at {aquarium.Name}: {fishNames}";
            Assert.That(report, Is.EqualTo(aquarium.Report()));
        }
    }
}

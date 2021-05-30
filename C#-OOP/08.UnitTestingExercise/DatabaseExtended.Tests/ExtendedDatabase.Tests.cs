
using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void When_AddMoreElementsThanCapcity_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    extendedDatabase.Add(new Person(i, $"Username{i}"));
                }
            });
        }

        [Test]
        public void When_AddPersonThatNameExist_ShouldThrowException()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new Person(2, "Pesho");
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void When_AddPersonThatIdExist_ShouldThrowException()
        {
            extendedDatabase.Add(new Person(1, "Ivan"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new Person(1, "Pesho");
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void When_AddIsValid_ShouldIncreaseCount()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(3, "Ivan"));
            int count = extendedDatabase.Count;

            Assert.That(count, Is.EqualTo(2));
        }    

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_LookingForUsernameNull_ShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                extendedDatabase.FindByUsername(name);
            });
        }

        [Test]
        public void When_LookingForUsernameThatDoesNotExist_ShouldThrowException()
        {
            string name = "Pesho";
            extendedDatabase.Add(new Person(2, "Ivan"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindByUsername(name);
            });
        }

        [Test]
        public void When_LookingForIdThatIsNegative_ShouldThrowException()
        {
            extendedDatabase.Add(new Person(2, "Ivan"));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                extendedDatabase.FindById(-2);
            });
        }

        [Test]
        public void When_LookingForIdIsNotFound_ShouldThrowException()
        {
            extendedDatabase.Add(new Person(2, "Ivan"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindById(3);
            });
        }

        [Test]
        public void When_IdIsMatched()
        {
            Person person = new Person(2, "Ivan");
            extendedDatabase.Add(person);
            Person lookingPerson = extendedDatabase.FindById(2);
            Assert.That(lookingPerson, Is.EqualTo(person));
        }

        [Test]
        public void When_NameIsMatched()
        {
            Person person = new Person(2, "Ivan");
            extendedDatabase.Add(person);
            Person lookingPerson = extendedDatabase.FindByUsername("Ivan");
            Assert.That(lookingPerson, Is.EqualTo(person));
        }

        [Test]
        public void When_RemovePersonFromEmptyCollection_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Remove();
            });
        }

        [Test]
        public void When_RemoveIsValid_ShouldDecreaseCount()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(3, "Ivan"));
            extendedDatabase.Remove();
            int count = extendedDatabase.Count;
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void When_RemoveIsValid_ShouldRemoveLastPerson()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(3, "Ivan"));
            extendedDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindByUsername("Ivan");
            });
        }

        [Test]
        public void When_DatabaseIsEmpty_ShouldReturnCountEqualToZero()
        {
            Assert.AreEqual(extendedDatabase.Count, 0);
        }

        [Test]
        public void When_DatabaseCountIsMoreThan16_ShouldThrowException()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void When_AddPeopleToCollectionFromCtor()
        {
            Person[] people = new Person[5];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.AreEqual(extendedDatabase.Count, people.Length);

            foreach (var person in people)
            {
                Person dbPerson = extendedDatabase.FindById(person.Id);
                Assert.AreEqual(person, dbPerson);
            }
        }

    }
    
}
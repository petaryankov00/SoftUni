using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void When_AddMoreElementsThanCapcity_ShouldThrowException()
        {
            int n = 17;
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    database.Add(i);
                }
            });
        }

        [Test]
        public void When_AddIsValid_ShouldIncreaseCount()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(database.Count, n);
        }

        [Test]
        public void Add_ElementsToArray()
        {
            int element = 123;
            database.Add(element);
            int[] elements = database.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }
        [Test]
        public void When_CollectionIsEmpty_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void When_RemoveElement_ShouldDecreaseCount()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            Assert.AreEqual(database.Count, n - 1);
        }

        [Test]
        public void When_RemoveElement_ShouldRemoveLastElement()
        {
            int n = 5;
            for (int i = 1; i <= n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            int[] elements = database.Fetch();
            Assert.IsFalse(elements.Contains(5));
        }

        [Test]
        public void When_CollectionIsFetched_ShouldReturnCopyNotReference()
        {
            database.Add(1);
            database.Add(2);

            int[] firstCopy = database.Fetch();
            database.Add(3);

            int[] secondCopy = database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void When_DatabaseIsEmpty_ShouldReturnCountEqualToZero()
        {
            Assert.AreEqual(database.Count, 0);
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsMoreThan16()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8);

            });
        }


        [Test]
        public void Ctor_AddsElements()
        {
            int[] arr = new int[] { 1, 2, 3 };
            database = new Database.Database(arr);
            Assert.That(this.database.Count, Is.EqualTo(arr.Length));
            Assert.That(this.database.Fetch(),Is.EquivalentTo(arr));
        }
    }
}
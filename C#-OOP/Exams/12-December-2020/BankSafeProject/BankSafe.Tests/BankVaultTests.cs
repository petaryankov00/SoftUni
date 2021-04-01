using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Pesho", "6969");

        }

        [Test]
        public void Ctor_ShouldSetCorretclyDictionary()
        {
            Assert.That(bankVault.VaultCells, Is.TypeOf<ImmutableDictionary<string, Item>>());
        }

        [Test]
        public void When_CellDoesNotExist_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("J5", item);
            });
        }

        [Test]
        public void When_AddItemToTakenCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("A1", item);
            });
        }

        [Test]
        public void When_AddAlreadyExistedItem_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem("A2", item);
            });
        }

        [Test]
        public void When_AddItemCorrectly()
        {
            Assert.That(bankVault.AddItem("A1", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void When_RemoveItemAndCellDoesNotExist_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("J5", item);
            });
        }

        [Test]
        public void When_ItemDoesNotExistToRemove_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A1", item);
            });
        }

        [Test]
        public void When_RemoveItemCorrectly()
        {
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }

        [Test]
        public void When_RemoveItem_ShouldSetNull()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }

        [Test]
        public void When_AddItem_ShouldSetItem()
        {
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(item));
        }

    }
}
using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Rado", "87");
        }

        [Test]
        public void WhenCellIsNotExistThrowException()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("null", item));
        }

        [Test]
        public void ThrowExceptionForBusyCell()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Pesho", "3"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void ThrowExceptionForAddSameItem()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("C2", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void ValidationForCorrectSavingItem()
        {
            var result = vault.AddItem("A2", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenCellToRemoveIsNotExistThrowException()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("any", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellToRemoveRemoveUnexistItem()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveCorrectlyItem()
        {
            vault.AddItem("C1", item);
            var result = vault.RemoveItem("C1", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }

        [Test]
        public void RemoveCorrectlyItemWithNullCheck()
        {
            vault.AddItem("C1", item);
            var savedItem = vault.VaultCells["C1"];
            var result = vault.RemoveItem("C1", item);

            Assert.AreEqual(null, vault.VaultCells["C1"]);
        }
    }
}
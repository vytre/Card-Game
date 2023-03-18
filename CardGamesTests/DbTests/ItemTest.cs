using CardGames.Database;
using CardGames.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.DbTests {
    //I am doing tests on the production DB and therefore i delete everything i create in the same method

    [TestClass]
    public class ItemTests {


        [SetUp]
        public void SetUp() {
        }

        [Test]
        public void ShouldCreateItem() {
            using GamblingDbContext db = new();

            string name = "name";
            string description = "yes";
            int price = 10;

            Item testItem = ItemUtil.CreateItem(name, description, price);
            Item? returnedItem = db.Item.SingleOrDefault(i => i.Id == testItem.Id);
            Assert.AreEqual(testItem, returnedItem);

            AfterEach(testItem);
        }

        [Test]
        public void ShouldDeleteItem() {
            using GamblingDbContext db = new();

            Item testItem = BeforeEach();

            ItemUtil.DeleteItem(testItem.Id);

            Item? nullItem = db.Item.SingleOrDefault(i => i.Id == testItem.Id);

            Assert.IsNull(nullItem);

        }

        [Test]
        public void ShouldChangeItemValues() {
            using GamblingDbContext db = new();

            Item testItem = BeforeEach();

            string newName = "newName";
            string newDesc = "smooth";
            int newPrice = 20;

            ItemUtil.ChangeItemPrice(testItem.Id, newPrice);
            ItemUtil.ChangeItemDesc(testItem.Id, newDesc);
            ItemUtil.ChangeItemName(testItem.Id, newName);

            Assert.AreEqual(testItem.Name, newName);
            Assert.AreEqual(testItem.Description, newDesc);
            Assert.AreEqual(testItem.Price, newPrice);

            AfterEach(testItem);
        }

        public Item BeforeEach() {
            using GamblingDbContext db = new();

            string name = "name";
            string description = "yes";
            int price = 10;

            Item testItem = ItemUtil.CreateItem(name, description, price);

            return testItem;
        }

        public void AfterEach(Item testItem) {
            using GamblingDbContext db = new();

            ItemUtil.DeleteItem(testItem.Id);
        }
    }
}
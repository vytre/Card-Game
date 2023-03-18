using CardGames.Database;
using CardGames.Entities;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.DbTests {
    //I am doing tests on the production DB and therefore i delete everything i create in the same method

    [TestClass]
    public class InventoryTests {
        [SetUp]
        public void SetUp() {
        }

        [Test]
        public void ShouldCreateNewInventory() {
            using GamblingDbContext db = new();

            string userName = "Ola";
            string password = "password";
            User testUser = UserUtil.CreateUser(userName, password);

            string itemName = "testItem";
            string description = "tedst";
            int price = 10;

            Item testItem = ItemUtil.CreateItem(itemName, description, price);

            Inventory expectedInventory = InventoryUtil.AddItemToInventory(testUser.Id, testItem.Id);
            Inventory? actualInventory = db.Inventory.SingleOrDefault(i => i.Id == expectedInventory.Id);


            Assert.AreEqual(expectedInventory, actualInventory);

            AfterEach(expectedInventory);
        }

        [Test]
        public void ShouldDeleteInventory() {
            using GamblingDbContext db = new();

            Inventory expectedInventory = BeforeEach();

            InventoryUtil.DeleteInventory(expectedInventory);

            Inventory? nullInventory = db.Inventory.SingleOrDefault(u => u.Id == expectedInventory.Id);

            Assert.IsNull(nullInventory);

        }

        [Test]
        public void ShouldChangeInventoryValues() {
            using GamblingDbContext db = new();

            Inventory expectedInventory = BeforeEach();

            string otherName = "notLisa";
            string otherPassword = "notPassword";
            User otherTestUser = UserUtil.CreateUser(otherName, otherPassword);

            string itemName = "testItemmmmm";
            string description = "tedstttt";
            int price = 100;
            Item otherItem = ItemUtil.CreateItem(itemName, description, price);

            InventoryUtil.ChangeItemId(expectedInventory, otherItem.Id);
            InventoryUtil.ChangeUserId(expectedInventory, otherTestUser.Id);

            Assert.AreEqual(expectedInventory.ItemId, otherItem.Id);
            Assert.AreEqual(expectedInventory.UserId, otherTestUser.Id);

            ItemUtil.DeleteItem(otherItem.Id);
            UserUtil.DeleteUser(otherTestUser.Id);
            AfterEach(expectedInventory);
        }

        public Inventory BeforeEach() {
            using GamblingDbContext db = new();

            string userName = "Ola";
            string password = "password";
            User testUser = UserUtil.CreateUser(userName, password);

            string itemName = "testItem";
            string description = "tedst";
            int price = 10;
            Item testItem = ItemUtil.CreateItem(itemName, description, price);

            Inventory expectedInventory = InventoryUtil.AddItemToInventory(testUser.Id, testItem.Id);

            UserUtil.DeleteUser(testUser.Id);
            ItemUtil.DeleteItem(testItem.Id);

            return expectedInventory;
        }

        public void AfterEach(Inventory expectedInventory) {
            using GamblingDbContext db = new();

            InventoryUtil.DeleteInventory(expectedInventory);
        }

    }
}
using CardGames.Database;
using CardGames.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.DbTests { 
    //I am doing tests on the production DB and therefore i delete everything i create in the same method

    [TestClass]
    public class UserTests {


        [SetUp]
        public void SetUp() {

        }

        [Test]
        public void ShouldCreateUser() {
            using GamblingDbContext db = new();

            string name = "Ola";
            string password = "password";

            User testUser = UserUtil.CreateUser(name, password);
            User? returnedUser = db.User.SingleOrDefault(u => u.Id == testUser.Id);

            Assert.AreEqual(testUser, returnedUser);

            AfterEach(testUser);
        }

        [Test]
        public void ShouldDeleteUser() {
            using GamblingDbContext db = new();

            User testUser = BeforeEach();

            UserUtil.DeleteUser(testUser.Id);

            User? nullUser = db.User.SingleOrDefault(u => u.Id == testUser.Id);

            Assert.IsNull(nullUser);

        }

        [Test]
        public void ShouldChangeUserValues() {
            using GamblingDbContext db = new();

            User testUser = BeforeEach();

            string newName = "notOla";
            string newPassword = "notPassword";

            UserUtil.ChangeUsername(testUser.Id, newName);
            UserUtil.ChangePassword(testUser.Id, newPassword);

            Assert.AreEqual(testUser.Name, newName);
            Assert.AreEqual(testUser.Password, newPassword);

            AfterEach(testUser);
        }

        [Test]
        public void shouldReadUser() {
            using GamblingDbContext db = new();

            User testUser = BeforeEach();

            string actualString = UserUtil.ReadUserName(testUser.Id);
            string expectedString = $"Name: {testUser.Name}";

            Assert.AreEqual(expectedString, actualString);

            AfterEach(testUser);
        }


        public User BeforeEach() {
            using GamblingDbContext db = new();

            string name = "Ola";
            string password = "password";

            User testUser = UserUtil.CreateUser(name, password);

            return testUser;
        }

        public void AfterEach(User testUser) {
            using GamblingDbContext db = new();

            UserUtil.DeleteUser(testUser.Id);
        }
    }
}
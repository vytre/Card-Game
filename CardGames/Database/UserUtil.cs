using CardGames.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Database {
    public class UserUtil {
        #region CRUD methods

        //CREATE
        public static User CreateUser(string name, string password) {
            using GamblingDbContext db = new();

            User user = new() { Name = name, Password = password, Balance = 10000 };
            db.Add(user);
            db.SaveChanges();
            return user;
        }

        //READ

        public static string ReadUserName(int Id) {
            using GamblingDbContext db = new();


            User user = db.User.SingleOrDefault(u => u.Id == Id);

            string userString = $"Name: {user.Name}";

            return userString;
        }

        public static List<string> ReadUserNames() {
            using GamblingDbContext db = new();

            return db.User.Select(u => u.Name).ToList();
        }

        public static int ReadBalance(int Id) {
            using GamblingDbContext db = new();

            User user = db.User.SingleOrDefault(u => u.Id == Id);

            return user.Balance;
        }

        //UPDATE
        public static User? ChangeUsername(int Id, string Name) {

            using GamblingDbContext db = new();

            User? user = db.User.SingleOrDefault(u => u.Id == Id);
            if (user != null) {
                user.Name = Name;
                db.Update(user);
                db.SaveChanges();
            }
            return user;

        }

        //UPDATE
        public static User? ChangePassword(int id, string password) {

            using GamblingDbContext db = new();

            User? user = db.User.SingleOrDefault(u => u.Id == id);
            if (user != null) {
                user.Password = password;
                db.Update(user);
                db.SaveChanges();
            }
            return user;

        }

        //UPDATE
        public static User? ChangeBalanceFromBet(int id, int betOutcome) {

            using GamblingDbContext db = new();

            User? user = db.User.SingleOrDefault(u => u.Id == id);



            if (betOutcome < 0) {
                user.Balance = user.Balance + betOutcome;
            } else {
                user.Balance = user.Balance + betOutcome;
            }


            db.Update(user);
            db.SaveChanges();

            return user;

        }

        //UPDATE
        public static void ChangeBalanceFromShop(int userId, int itemId) {

            using GamblingDbContext db = new();

            User? user = db.User.SingleOrDefault(u => u.Id == userId);
            Item? item = db.Item.SingleOrDefault(u => u.Id == itemId);

            user.Balance -= item.Price;

            db.Update(user);
            db.SaveChanges();
        }

        //DELETE
        public static void DeleteUser(int Id) {

            using GamblingDbContext db = new();

            User? user = db.User.SingleOrDefault(u => u.Id == Id);
            if (user != null) {
                db.Remove(user);
                db.SaveChanges();
            }
        }
        #endregion
    }
}

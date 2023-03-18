using CardGames.blackjack;
using CardGames.Entities;
using CardGames.War;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CardGames.Database {
    public static class DbUI {
        
        public static User LogUserIn() {
            Console.Clear();
            Console.WriteLine("Login");
            Console.WriteLine("Username: ");
            string? username = Console.ReadLine();

            Console.WriteLine("Password: ");
            string? password = Console.ReadLine();

            using GamblingDbContext db = new();
            if (db.User.SingleOrDefault(u => u.Name == username) == null) {
                Console.Clear();
                Console.WriteLine("...that user does not exist");
                CardGamesUi.InitProgram();
            }

            var user = db.User.SingleOrDefault(u => u.Name == username);
            if (user.Password != password) {
                Console.Clear();
                Console.WriteLine("...wrong password");
                CardGamesUi.InitProgram();
            }

            Console.Clear();
            Console.WriteLine("Welcome " + user.Name + ", lets gamble");
            CardGamesUi.GambleOrShop(user);
            return user;
        }

        public static User CreateUser() {
            Console.Clear();
            Console.WriteLine("Creating user");
            Console.WriteLine("Enter your username");
            string? username = Console.ReadLine();

            Console.WriteLine("Enter your password");
            Console.CursorVisible = false;
            string? password = Console.ReadLine();
            Console.CursorVisible = true;
            User user = UserUtil.CreateUser(username, password);

            Console.Clear();
            Console.WriteLine("Welcome " + username + ", lets gamble");

            CardGamesUi.GambleOrShop(user);
            return user;
        }
    }
}

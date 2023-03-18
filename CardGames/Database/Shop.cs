using CardGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Database
{
    public class Shop
    {
        public static void BuyOrBye(User user)
        {
            using GamblingDbContext db = new();

            Console.Clear();
            Console.WriteLine("Items in shop:");
    
            List<Item> items = ItemUtil.ReadItems();
            foreach (var item in db.Item)
            {
                Console.WriteLine("Id: " + item.Id + " | Item: " + item.Name + "| Description: " + item.Description + " | Price: " + item.Price);
            }

            int balance = UserUtil.ReadBalance(user.Id);


            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Your balance is: " + balance);
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Buy an item");
            Console.WriteLine("2. Exit shop");

            int userInput;
            userInput = ValidateUserInput();

            switch (userInput)
            {
                case 1:
                    BuyItem(user);
                    break;
                case 2:
                    Console.Clear();
                    CardGamesUi.GambleOrShop(user);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You don't seem too good with numbers, are you sure you wanna gamble?");
                    BuyOrBye(user);
                    break;

            }
        }

        private static int ValidateUserInput() {
            int userChoice;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out userChoice)) {
                userChoice = 99;
            } else {
                userChoice = Convert.ToInt32(input);
            }

            return userChoice;
        }

        private static void BuyItem(User user)
        {
            Console.WriteLine("Enter the ID of your desired item");
            int itemId = (int)Convert.ToInt64(Console.ReadLine());
            int userId = user.Id;
            Item item = ItemUtil.GetItem(itemId);

            if (user.Balance >= item.Price) {
                Console.Clear();
                InventoryUtil.AddItemToInventory(userId, itemId);
                UserUtil.ChangeBalanceFromShop(user.Id, itemId);
                BuyOrBye(user);
            } else {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("You cant afford that, maybe if you stop gambling?");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Thread.Sleep(3000);
                BuyItem(user);
            }


        }
    }
}

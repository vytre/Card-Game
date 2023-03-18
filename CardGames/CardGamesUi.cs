using CardGames.blackjack;
using CardGames.Database;
using CardGames.Entities;
using CardGames.War;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
    internal class CardGamesUi {

        public static void InitProgram() {
            Console.WriteLine("Choose one of the following");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register user");

            int userInput;
            userInput = ValidateUserInput();

            User? user = new();

            switch (userInput) {
                case 1:
                    user = DbUI.LogUserIn();
                    break;
                case 2:
                    user = DbUI.CreateUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please type in 1 or 2");
                    InitProgram();
                    break;
            }
        }

        public static void GambleOrShop(User user) {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Choose game");
            Console.WriteLine("2. Store");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Settings");
            Console.WriteLine("5. Quit");
            int userInput;
            userInput = ValidateUserInput();


            switch (userInput) {
                case 1:
                    ChooseGame(user);
                    break;
                case 2:
                    Shop.BuyOrBye(user);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Your items:");
                    InventoryUtil.ReadUserInventory(user);
                    InventoryChoices(user);
                    break;
                case 4:
                    Settings(user);
                    break;
                case 5:
                    Console.WriteLine("Sayonara " + user.Name + "!");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You don't seem too good with numbers, are you sure you wanna gamble?");
                    GambleOrShop(user);
                    break;
            }
        }

        private static void ChooseGame(User user) {
            int userInput;
            int betAmount = 0;
            GameMenu();
            userInput = ValidateUserInput();

            switch (userInput) {

                case 1:
                    betAmount = BetAmount(user);
                    WarGameUi warGameUi = new();
                    int warWinnings = warGameUi.Start(betAmount);
                    user = UserUtil.ChangeBalanceFromBet(user.Id, warWinnings);
                    ChooseGame(user);
                    break;

                case 2:

                    betAmount = BetAmount(user);
                    Blackjack blackjack = new();
                    int blackJackWinnings = blackjack.Start(betAmount);
                    Console.WriteLine(blackJackWinnings);
                    user = UserUtil.ChangeBalanceFromBet(user.Id, blackJackWinnings);
                    ChooseGame(user);
                    break;

                case 3:
                    Console.WriteLine("Going back to Main Menu");
                    GambleOrShop(user);
                    break;

                default:
                    Console.WriteLine("Please Write Either 1, 2 or 3");
                    ChooseGame(user);
                    break;
            }
        }
        private static void GameMenu() {
            //Console.Clear();
            Console.WriteLine("-- Game Menu --");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. War Game");
            Console.WriteLine("2. BlackJack");
            Console.WriteLine("3. Exit");
        }

        private static int BetAmount(User user) {
            Console.Clear();



            Console.WriteLine("How much do you want to bet?");

            int correctBet = ValidateBet(user, ValidateUserInput());
            return correctBet;
        }

        private static int ValidateBet(User user, int bet) {
            if (bet == 0) {
                Console.WriteLine("Please eneter a value that is greater than 0 and an int");
                Thread.Sleep(3000);
                BetAmount(user);
            } else if (user.Balance < bet) {
                Console.WriteLine($"You only have {user.Balance} please dont bet more than you have!");
                Thread.Sleep(3000);
                BetAmount(user);
            }
            return bet;
        }

        private static int ValidateUserInput() {
            int userChoice;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out userChoice)) {
                userChoice = 0;
            } else {
                userChoice = Convert.ToInt32(input);
            }
            return userChoice;
        }
        private static void InventoryChoices(User user) {
            Console.WriteLine("Enter 1 to exit");
            int userInput;
            userInput = ValidateUserInput();
            Console.Clear();

            switch (userInput) {
                case 1: 
                    Console.Clear();
                    GambleOrShop(user);
                    break;
                default:
                    Console.WriteLine("You don't seem too good with numbers, are you sure you wanna gamble?");
                    InventoryChoices(user);
                    break;
            }
        }

        public static void Settings(User user) {
            Console.Clear();
            Console.WriteLine("Okay " + user.Name + ", what now?");
            Console.WriteLine("1. Change username");
            Console.WriteLine("2. Change password");
            Console.WriteLine("3. Delete this user");
            Console.WriteLine("4. Exit settings");

            int userInput;
            userInput = ValidateUserInput();

            switch (userInput) {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Set new username");
                    string username = Console.ReadLine();
                    user = UserUtil.ChangeUsername(user.Id, username);
                    Console.WriteLine("Okay " + username + ", all done.");
                    Settings(user);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Set new password");
                    string password = Console.ReadLine();
                    user = UserUtil.ChangePassword(user.Id, password);
                    Settings(user);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("I am prod of you " + user.Name + ". You beat the game! Saravada");
                    UserUtil.DeleteUser(user.Id);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Exiting settings");
                    CardGamesUi.GambleOrShop(user);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You don't seem too good with numbers, are you sure you wanna gamble?");
                    Settings(user);
                    break;
            }

        }
    }
}
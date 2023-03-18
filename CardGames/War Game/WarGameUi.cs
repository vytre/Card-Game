namespace CardGames.War {
    internal class WarGameUi {
        #region Fields
        private WarGame _wardeck;
        private int _winnings = 0;

        #endregion

        #region Constructor
        public WarGameUi() {
            _wardeck = new();
        }
        #endregion

        #region Switch Method
        public int Start(int bet) {
            PrintMenu();
            int userInput;
            userInput = ValidateUserInput();

            switch (userInput) {

                case 1:
                    _winnings = _wardeck.PlayWar(bet);
                    break;

                case 2:
                    WarGameUi.ShowGameInfo();
                    Thread.Sleep(3000);
                    Start(bet);
                    break;

                case 3:
                    Console.WriteLine("Thanks For Playing! See you soon!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Please Write Either 1 or 2");
                    Thread.Sleep(3000);
                    Start(bet);
                    break;
            }

            return _winnings;
        }

        private int ValidateUserInput() {
            int userChoice;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out userChoice)) {
                userChoice = 0;
            } else {
                userChoice = Convert.ToInt32(input);
            }
            return userChoice;
        }
        #endregion

        #region Menus
        private static void ShowGameInfo() {
            Console.WriteLine("\n----- Game Info -----");
            Console.WriteLine("War Game");
            Console.WriteLine("You Win by reaching 50 points (rounds won) or if computer runs out of cards.");
            Console.WriteLine("You Lose if the Computer reaches 50 points or if You run out of cards.");
            Console.WriteLine("Each Player (User and Computer) is given 26 cards each face down, then each Player reveals the top card of their deck.\nThe Player with the highest card Wins the round, and adds both cards to the bottom of their deck.");
            Console.WriteLine("If the cards are equal, War commences! Both Players draw 3 cards from their deck face down, and a fourth card face Up.\nThe Player with the highest card Wins the round, and adds all 10 cards (5 from Player 5 from Computer) to the bottom of their deck.");
            Console.WriteLine("If cards are equal again, another war round will commence, and will continue untill one of the Players win, or if one player doesnt have enough cards to play War");
            Console.WriteLine("Ace is lowest, King is highest and Suits are ignored. Jokers are excluded from this card game\n");


        }

        private void PrintMenu() {
            //Console.Clear();
            Console.WriteLine("----- Start -----\nPlease enter a Start Number (1-3)");
            Console.WriteLine("1. Play War");
            Console.WriteLine("2. Game Info");
            Console.WriteLine("3. Exit");
        }
        #endregion
    }
}
using CardGames.Card_UI;

namespace CardGames.War {
    public class WarGame : IDealCards {
        #region Fields

        private GenerateCardDeck _cardGenerator;
        public PrintCardToConsole ui;
        private List<Card> _mainDeck;
        private List<Card> _playerDeck;
        private List<Card> _computerDeck;
        private int _computerRoundsWon;
        private int _playerRoundsWon;
        private int _betInCurrentRound;

        #endregion

        #region Constructor
        public WarGame() {
            ui = new();
            _cardGenerator = new();
            _playerDeck = new List<Card>();
            _computerDeck = new List<Card>();
        }
        #endregion

        #region Game Loop
        /// <summary>
        /// Initializes War Game
        /// </summary>
        /// <param name="bet">Bet promted by User</param>
        /// <returns>Betting Result</returns>
        public int PlayWar(int bet) {
            bool game = true;
            _betInCurrentRound = bet;
            ResetGame();
            GenreateMainDeck();
            DealCards();


            while (game) {
                Console.Clear();
                Console.WriteLine($"Player   has Won {_playerRoundsWon} rounds and has {_playerDeck.Count} Cards in Deck");
                Console.WriteLine($"Computer has Won {_computerRoundsWon} rounds and has {_computerDeck.Count} Cards in Deck \n");

                var playerCardValue = _playerDeck[0].GetValue();
                var playerCardSuit = _playerDeck[0].GetSuit();

                var computerCardValue = _computerDeck[0].GetValue();
                var computerCardSuit = _computerDeck[0].GetSuit();

                WarGameUI(playerCardSuit, playerCardValue, computerCardSuit, computerCardValue);

                if (playerCardValue == computerCardValue) {
                    EqualCard(1);
                } else {
                    EvaluateWinner(playerCardValue, computerCardValue);
                }

                game = CheckGameStatus();
            }
            return _betInCurrentRound;
        }


        /// <summary>
        /// Checks if game should continue. If Player has over 50 points or Computer runs out of Cards, Player Wins.
        /// If Computer has over 50 points or Player runs out of cards, Computers Wins
        /// </summary>
        /// <returns>True or False</returns>
        private bool CheckGameStatus() {

            if (_playerDeck.Count < 1 || _computerRoundsWon > 49) {
                Console.Clear();

                Console.WriteLine("GAME OVER YOU LOST");

                if (_playerDeck.Count < 1) {
                    Console.WriteLine("YOU Ran out of Cards!\n");
                } else {
                    Console.WriteLine("Computer Got to 50 Points before you did!\n");
                    Console.WriteLine("Computer Won: " + _computerRoundsWon + " Rounds");
                    Console.WriteLine("Player Won: " + _playerRoundsWon + " Rounds");
                }

                ResetGame();
                int initialBet = _betInCurrentRound;
                _betInCurrentRound = initialBet - initialBet - initialBet;

                Console.WriteLine($"You lost:{initialBet}\n");
                return false;
            } else if (_computerDeck.Count < 1 || _playerRoundsWon > 49) {
                Console.Clear();

                Console.WriteLine("Congratulations YOU WON");
                if (_computerDeck.Count < 1) {
                    Console.WriteLine("Computer Ran out of Cards!\n");
                } else {
                    Console.WriteLine("You Got to 50 Points before the Computer did!\n");

                    Console.WriteLine("Player Won: " + _playerRoundsWon + " Rounds");
                    Console.WriteLine("Computer Won: " + _computerRoundsWon + " Rounds");
                }
                ResetGame();
                _betInCurrentRound *= 2;
                Console.WriteLine($"Credits Won:{_betInCurrentRound}\n");
                return false;
            }
            return true;
        }

        #endregion

        #region Card Ui
        /// <summary>
        /// Prints Physical cards to Console
        /// </summary>
        /// <param name="playerCardSuit">Player Suit</param>
        /// <param name="playerCardValue">Player Value</param>
        /// <param name="computerCardSuit">Computer Suit</param>
        /// <param name="computerCardValue">Computer Value</param>
        public void WarGameUI(Suits playerCardSuit, Values playerCardValue, Suits computerCardSuit, Values computerCardValue) {

            Console.WriteLine("Player Card");
            Console.WriteLine("     |\n     V\n");

            ui.PrintCard(playerCardSuit, playerCardValue);

            Console.WriteLine("\n\nComputer Card");
            Console.WriteLine("     |\n     V\n");
            ui.PrintCard(computerCardSuit, computerCardValue);

        }
        #endregion

        #region Game Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerCardValue"></param>
        /// <param name="computerCardValue"></param>
        private void EvaluateWinner(Values playerCardValue, Values computerCardValue) {
            if (playerCardValue > computerCardValue) {

                // Player Card is Higher

                _playerDeck.Add(_computerDeck[0]);
                _computerDeck.RemoveAt(0);


                Card firstCard = _playerDeck[0];
                _playerDeck.Add(firstCard);
                _playerDeck.RemoveAt(0);
                RoundWinner(_playerDeck);
            } else {
                // Computer Card is Higher
                _computerDeck.Add(_playerDeck[0]);
                _playerDeck.RemoveAt(0);

                Card firstCard = _computerDeck[0];
                _computerDeck.Add(firstCard);
                _computerDeck.RemoveAt(0);
                RoundWinner(_computerDeck);
            }
        }

        /// <summary>
        /// WAR!
        /// Cards are Equal
        /// </summary>
        /// <param name="warRound"></param>
        private void EqualCard(int warRound) {


            int gameCard = warRound * 4;

            if (_computerDeck.Count >= gameCard + warRound && _playerDeck.Count >= gameCard + warRound) {

                var playerCardValue = _playerDeck[gameCard].GetValue();
                var computerCardValue = _computerDeck[gameCard].GetValue();
                var playerCardSuit = _playerDeck[gameCard].GetSuit();
                var computerCardSuit = _computerDeck[gameCard].GetSuit();

                Console.Clear();

                Console.WriteLine("\n \nWAR! CARDS ARE EQUAL!");
                Console.WriteLine($"Drawing 3 Cards Face Down...");

                Console.Write($"And a a 4th Face Up...\n\n");

                Task.Delay(1500).Wait();

                WarGameUI(playerCardSuit, playerCardValue, computerCardSuit, computerCardValue);

                Task.Delay(2000).Wait();


                if (playerCardValue > computerCardValue) {
                    // Player Wins WarGame

                    for (int i = 0; i < gameCard + warRound; i++) {
                        _playerDeck.Add(_computerDeck[i]);
                    }
                    _computerDeck.RemoveRange(0, gameCard + warRound);
                    RoundWinner(_playerDeck);

                } else if (playerCardValue < computerCardValue) {
                    // Computer Wins WarGame


                    for (int i = 0; i < gameCard + warRound; i++) {
                        _computerDeck.Add(_playerDeck[i]);
                    }
                    _playerDeck.RemoveRange(0, gameCard + warRound);
                    RoundWinner(_computerDeck);

                } else {
                    // Next card is Equal again, we call the method again. With a new WarGame Set
                    warRound++;
                    EqualCard(warRound);
                }
            } else {
                // Not Enough Cards
                if (_playerDeck.Count < gameCard + warRound) {
                    Console.WriteLine("Player ran out of Cards IN WAR, he Lost!");
                    _playerDeck.Clear();
                } else if (_computerDeck.Count < gameCard + warRound) {
                    Console.WriteLine("Computer ran out of Cards IN WAR, he Lost!");
                    _computerDeck.Clear();
                }
            }
        }

        /// <summary>
        /// Prints Winner to Console and increases their score
        /// </summary>
        /// <param name="winnerDeck"></param>
        private void RoundWinner(List<Card> winnerDeck) {

            string winner;
            if (winnerDeck.Equals(_playerDeck)) {
                winner = "Player  ";
                _playerRoundsWon++;
            } else {
                winner = "Computer";
                _computerRoundsWon++;
            }
            Console.WriteLine($" \n\n{winner.ToUpper()} Won The Round!");
            Task.Delay(1000).Wait();
        }
        #endregion

        #region Start Methods

        /// <summary>
        /// Deals 26 cards to Player and 26 Cards to Computer from Main Card Deck
        /// </summary>
        public void DealCards() {

            for (int i = 0; i < 26; i++) { // Player gets index 0-25
                _playerDeck.Add(_mainDeck[i]);
            }


            for (int i = 26; i < 52; i++) { //  26-51
                _computerDeck.Add(_mainDeck[i]);
            }
        }

        /// <summary>
        /// Initializes _mainDeck
        /// </summary>
        private void GenreateMainDeck() {
            _mainDeck = _cardGenerator.GenerateDeck();
        }


        /// <summary>
        /// Clears the Card Decks and sets scores to 0. This Method is called if Player or Computer wins
        /// </summary>
        private void ResetGame() {
            _playerRoundsWon = 0;
            _computerRoundsWon = 0;
            _playerDeck.Clear();
            _computerDeck.Clear();
        }
        #endregion
    }
}
using CardGames.War;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.WarTests {
    internal class WarTest {
        private WarGame? war;
        private List<Card>? _mainDeck;
        private List<Card>? _playerDeck;
        private List<Card>? _computerDeck;
        private GenerateCardDeck? generateCardDeck;
        private int _computerRoundsWon;
        private int _playerRoundsWon;

        [SetUp]
        public void SetUpWar() {
            Console.SetOut(TextWriter.Null);
            war = new WarGame();
            generateCardDeck = new();
            _mainDeck = generateCardDeck.GenerateDeck();
            _computerDeck = new();
            _playerDeck = new();
        }


        [Test]
        public void TestCardDelegation() {
            //Test Fails becuase Console.Clear() is called in WarGame, this causes the tests to crash. But in Debug mode you can see that the Assert is True.

            int winnings = war.PlayWar(200);
            Assert.That(_mainDeck.Count, Is.EqualTo(52));
            Assert.That(_playerDeck.Count, Is.EqualTo(26));
            Assert.That(_computerDeck.Count, Is.EqualTo(26));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.CardLogicTests {
    internal class CardLogicTest {

        [Test]
        public void TestGreaterThan() {
            Card firstCard = new(Values.Two, Suits.Hearts);
            Card secondCard = new(Values.King, Suits.Hearts);
            Assert.That(secondCard.GetValue(), Is.GreaterThan(firstCard.GetValue()));

        }


        [Test]
        public void TestLessThan() {
            Card firstCard = new(Values.Five, Suits.Clubs);
            Card secondCard = new(Values.Four, Suits.Hearts);
            Assert.That(secondCard.GetValue(), Is.LessThan(firstCard.GetValue()));
        }


        [Test]
        public void TestEqualTo() {
            Card firstCard = new(Values.King, Suits.Hearts);
            Card secondCard = new(Values.King, Suits.Hearts);
            Assert.That(secondCard.GetValue(), Is.EqualTo(firstCard.GetValue()));
        }


        [Test]
        public void TestShouldGenereate52Cards() {
            GenerateCardDeck generateCardDeck = new();
            List<Card> cardDeck = generateCardDeck.GenerateDeck();

            Assert.That(cardDeck.Count, Is.EqualTo(52));
        }


        [Test]
        public void TestShouldRemove5Cards() {
            GenerateCardDeck generateCardDeck = new();
            List<Card> cardDeck = generateCardDeck.GenerateDeck();

            cardDeck.RemoveRange(0, 4);

            Assert.That(cardDeck.Count, Is.EqualTo(48));
        }


        [Test]
        public void TestShouldAddCardToEndOfList() {
            GenerateCardDeck generateCardDeck = new();
            List<Card> cardDeck = generateCardDeck.GenerateDeck();

            Card card = cardDeck[0];
            cardDeck.Add(card);
            cardDeck.RemoveAt(0);

            Assert.That(card, Is.EqualTo(cardDeck[51]));
        }


        [Test]
        public void TestShouldCheckForDuplicatedInSuits() {
            GenerateCardDeck generateCardDeck = new();
            List<Card> cardDeck = generateCardDeck.GenerateDeck();

            List<Card> hearts = new();
            List<Card> diamonds = new();
            List<Card> clubs = new();
            List<Card> spades = new();

            foreach (Card card in cardDeck) {
                if (card.GetSuit().Equals((Suits.Hearts))) {
                    hearts.Add(card);
                }
                else if (card.GetSuit().Equals((Suits.Spades))) {
                    spades.Add(card);
                }
                else if (card.GetSuit().Equals((Suits.Clubs))) {
                    clubs.Add(card);
                }
                else if (card.GetSuit().Equals((Suits.Diamonds))) {
                    diamonds.Add(card);
                }
            }

            Assert.That(hearts.Count, Is.EqualTo(13));
            Assert.That(spades.Count, Is.EqualTo(13));
            Assert.That(clubs.Count, Is.EqualTo(13));
            Assert.That(diamonds.Count, Is.EqualTo(13));
        }

        [Test]
        public void TestShouldCheckForDuplicatedInValues() {
            GenerateCardDeck generateCardDeck = new();
            List<Card> cardDeck = generateCardDeck.GenerateDeck();

            List<Card> kings = new();
            List<Card> aces = new();
            List<Card> twos = new();
            List<Card> fives = new();

            foreach (var item in cardDeck) {
                if (item.GetValue().Equals((Values.King))) {
                    kings.Add(item);

                }
                else if (item.GetValue().Equals((Values.Ace))) {
                    aces.Add(item);
                }
                else if (item.GetValue().Equals((Values.Two))) {
                    twos.Add(item);
                }
                else if (item.GetValue().Equals((Values.Five))) {
                    fives.Add(item);
                }
            }

            Assert.That(kings.Count, Is.EqualTo(4));
            Assert.That(aces.Count, Is.EqualTo(4));
            Assert.That(twos.Count, Is.EqualTo(4));
            Assert.That(fives.Count, Is.EqualTo(4));
        }
    }
}

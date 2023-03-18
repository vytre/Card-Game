using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
    public class GenerateCardDeck {

        private List<Card> _deck = new(52);
        
        public List<Card> GenerateDeck() {

            for (int i = 0; i < 13; i++) {
                MakeDeck(i, Suits.Hearts);
                MakeDeck(i, Suits.Spades);
                MakeDeck(i, Suits.Diamonds);
                MakeDeck(i, Suits.Clubs);
            }
            ShuffleDeck();
            return _deck;
        }



        private void MakeDeck(int v, Suits suit) {
            IntToValue value = new(v);

            Card _card = new(value.GetCardValue(), suit);

            // add card object to _deck list
            _deck.Add(_card);
        }


        /// <summary>
        /// Random Bubble Sort, takes a random Card from the Deck and replaces it with the First Card in the Deck 1999 times
        /// Inspired by BubbleSort from Semester 2 Algorithms
        /// https://github.com/bogdanmarculescu/algorithms/blob/master/lessons/src/main/java/org/pg4200/les03/sort/BubbleSort.java
        /// </summary>
        /// <returns>Sorted Card Deck</returns>
        private void ShuffleDeck() {
            Random random = new Random();

            for (int timesShuffled = 0; timesShuffled < 1999; timesShuffled++) {
                int randomInt = random.Next(_deck.Count);

                Card tempCard = _deck[0];

                _deck[0] = _deck[randomInt];
                _deck[randomInt] = tempCard;
            }
        }
    }
}

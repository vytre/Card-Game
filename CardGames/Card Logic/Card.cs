using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
    public class Card {
        // constructor
        public Card(Values value, Suits suits) {
            _value = value;
            _suits = suits;
        }

        // fields
        private Suits _suits;
        private Values _value;

        // operations
        public Suits GetSuit() { return _suits; }
        public Values GetValue() { return _value; }
    }
}


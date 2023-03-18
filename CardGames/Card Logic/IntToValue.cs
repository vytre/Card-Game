using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
    internal class IntToValue {
        // values for cards
        Values _values = new();
        internal IntToValue(int i) {
            // switch
            switch (i) {
                case 0:
                    _values = Values.Ace;
                    break;
                case 1:
                    _values = Values.Two;
                    break;
                case 2:
                    _values = Values.Three;
                    break;
                case 3:
                    _values = Values.Four;
                    break;
                case 4:
                    _values = Values.Five;
                    break;
                case 5:
                    _values = Values.Six;
                    break;
                case 6:
                    _values = Values.Seven;
                    break;
                case 7:
                    _values = Values.Eight;
                    break;
                case 8:
                    _values = Values.Nine;
                    break;
                case 9:
                    _values = Values.Ten;
                    break;
                case 10:
                    _values = Values.Jack;
                    break;
                case 11:
                    _values = Values.Queen;
                    break;
                case 12:
                    _values = Values.King;
                    break;
            }
        }
        // return card values
        internal Values GetCardValue() { return _values; }
    }
}

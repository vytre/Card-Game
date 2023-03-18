using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
    internal class ValueToInt {
        // values for cards
        int intValue;
        internal ValueToInt(Values value) {
            // switch   
            switch (value) {
                case Values.Ace:
                intValue = 1;
                break;
                case Values.Two:
                intValue = 2;
                break;
                case Values.Three:
                intValue = 3;
                break;
                case Values.Four:
                intValue = 4;
                break;
                case Values.Five:
                intValue = 5;
                break;
                case Values.Six:
                intValue = 6;
                break;
                case Values.Seven:
                intValue = 7;
                break;
                case Values.Eight:
                intValue = 8;
                break;
                case Values.Nine:
                intValue = 9;
                break;
                case Values.Ten:
                intValue = 10;
                break;
                case Values.Jack:
                intValue = 11;
                break;
                case Values.Queen:
                intValue = 12;
                break;
                case Values.King:
                intValue = 13;
                break;
            }
        }
        // return card values   
        internal int GetIntValue() { return intValue; }
    }
}

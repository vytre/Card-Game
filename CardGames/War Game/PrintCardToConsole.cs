using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Card_UI {
    public class PrintCardToConsole {
        public string? _printString;
        private int? _intValue;




        public void PrintCard(Suits _suit, Values _value) {
            if (_value == Values.Ace) {
                _printString =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Two) {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Three) {
                _printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Four) {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Five) {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Six) {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Seven) {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Eight) {
                _printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Nine) {
                _printString =
                    " V         " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
            if (_value == Values.Ten || _value == Values.Jack || _value == Values.Queen || _value == Values.King) {
                _printString =
                    " V         " +
                    "    S S    " +
                    "     S     " +
                    "  S S S S  " +
                    "     S     " +
                    "    S S    " +
                    "         V ";
                PrintMethod(_value, _suit);
            }
        }
        public void PrintMethod(Values _value, Suits _suit) {
            bool hasWrittenFirstNumber = false;

            switch (_suit) {
                case Suits.Hearts:
                case Suits.Diamonds:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
                case Suits.Clubs:
                case Suits.Spades:
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            }

            for (int i = 0; i < _printString.Length; i++) {
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 11 == 0 && i != 0) {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                if (_printString[i] == 'S') {
                    switch (_suit) {
                        case Suits.Hearts:
                        Console.Write('♥');
                        break;
                        case Suits.Clubs:
                        Console.Write("♣");
                        break;
                        case Suits.Diamonds:
                        Console.Write("♦");
                        break;
                        case Suits.Spades:
                        Console.Write("♠");
                        break;
                    }
                    continue;
                }
                else if (_printString[i] == 'V') {
                    if (_value == Values.Ten) {
                        if (hasWrittenFirstNumber == false) {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (_value == Values.Jack) {
                        Console.Write("J");
                    }
                    else if (_value == Values.Queen) {
                        Console.Write("Q");
                    }
                    else if (_value == Values.King) {
                        Console.Write("K");
                    }
                    else if (_value == Values.Ace) {
                        Console.Write("A");
                    }
                    else {
                        ValueToInt intValue = new(_value);
                        _intValue = intValue.GetIntValue();
                        Console.Write(_intValue);
                    }
                }
                else {
                    Console.Write(_printString[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

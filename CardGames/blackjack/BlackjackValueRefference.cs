namespace CardGames.blackjack;
// This class use a switch to return an int value
// based on the Values enum it get sent
public class BlackjackValueReference {
	// Attribute
	private int _translatedValue;
	// Operations
	internal int ValueToIntConverter(Values check) {
		switch (check) {
			case Values.Ace:
				_translatedValue = 11;
				break;
			case Values.Two:
				_translatedValue = 2;
				break;
			case Values.Three:
				_translatedValue = 3;
				break;
			case Values.Four:
				_translatedValue = 4;
				break;
			case Values.Five:
				_translatedValue = 5;
				break;
			case Values.Six:
				_translatedValue = 6;
				break;
			case Values.Seven:
				_translatedValue = 7;
				break;
			case Values.Eight:
				_translatedValue = 8;
				break;
			case Values.Nine:
				_translatedValue = 9;
				break;
			case Values.Ten:
				_translatedValue = 10;
				break;
			case Values.Jack:
				_translatedValue = 10;
				break;
			case Values.Queen:
				_translatedValue = 10;
				break;
			case Values.King:
				_translatedValue = 10;
				break;
		}
		// return card values
		return _translatedValue;
	}
}



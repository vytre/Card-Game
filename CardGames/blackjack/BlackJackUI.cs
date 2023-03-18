using System.Text;

namespace CardGames.blackjack;
// inspired by UI solution for blackjack: https://kristiania.instructure.com/courses/8672/files/934184?module_item_id=335524

public class BlackJackUI {

	#region Operations

	#region Input
	public string Str() {
		string? userInput = Console.ReadLine();
		if (userInput == null) {
            userInput = "";
        }
        return userInput;
	}
	public int Intg() {
		return Console.Read();
	}
	#endregion

	#region Output
	public void WL(string ToBeWritten) {
		Console.WriteLine(ToBeWritten);
	}

	public void W(string ToBeWritten) {
		Console.Write(ToBeWritten);
	}

	public void CL() {
		Console.Clear();
	}

	public void WriteOutCards(List<Card> ToBeWritten) {
		foreach (var card in ToBeWritten) {
			Console.WriteLine("{0}: {1} of {2}", card, card.GetValue(), card.GetSuit());
		}
	}
	#endregion

	#region Query
	public bool PlayerHitOrStand() {
		bool b = true;
		string answer = "";
		while (answer != "h" && answer != "s") {
			answer = Str().Trim();
			if (answer == "h") {
				WL("you answered " + answer + " for hit");
			}
			else if (answer == "s") {
				WL("you answered " + answer + " for stand");
				b = false;
			}else{
				WL("you answered " + answer + " for what? Try typing h or s \r\n");
			}
		}
		return b;
	}
	
	#endregion
	
	#endregion
	
}
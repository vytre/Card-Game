namespace CardGames.blackjack; 

public class BlackjackLogic {
	
	#region Attributes
	private BlackjackValueReference? _valueReference;
	private List<Card> changedAce = new();
	#endregion

	#region Operations
	public void CardDraw(List<Card> deck, int amount, List<Card> hand) {
		for (int i = 0; i < amount; i++) {
			hand.Add(deck[0]);

			Card toBeRemoved = deck[0];
			deck.Remove(toBeRemoved);
		}
	}

	#region Setting score
	public  int SetScore(List<Card> toBeChecked) {
		int score = 0;
		bool moreThanTwentyOne;
		foreach (Card card in toBeChecked) {
			_valueReference = new BlackjackValueReference();
			score += _valueReference.ValueToIntConverter(card.GetValue());
			moreThanTwentyOne = MoreThanTwentyOne(score);
			// might need to have an int variable here to store score value for score = AceChanger
			if (moreThanTwentyOne) {
				score = AceChanger(toBeChecked, score);
			}
		}
		changedAce.Clear();
		return score;
	}
	private int AceChanger(List<Card> listCards ,int aceValue) {
		foreach (Card card in listCards) {
			if (aceValue > 21) {
				if (card.GetValue() == Values.Ace && changedAce.Contains(card) == false) {
					aceValue -= 10;
					changedAce.Add(card);
				}
			} 
		}
		return aceValue;
	}
	#endregion

	#region Checking values
	public bool MoreThanTwentyOne(int i) {
		bool b;
		b = false;
		if (i > 21) {
			b = true;
		}
		return b;
	}

	public bool LessThanTwentyOne(int i) {
		bool b;
		b = false;
		if (i < 21) {
			b = true;
		}
		return b;
	}

	public bool IsTwentyOne(int i) {
		bool b;
		b = false;
		if (i == 21) {
			b = true;
		}
		return b;
	}

	public bool DealerLessThanPlayer(int dealerScore,int playerScore) {
		bool b;
		b = false;
		if (dealerScore < playerScore) {
			b = true;
		}
		return b;
	}
	
	public bool WinningScore(int dealerScore, int playerScore) {
		bool b;
		b = false;
		if (MoreThanTwentyOne(playerScore)) {
			b = false;
		}
		else if (MoreThanTwentyOne(dealerScore)) {
			b = true;
		}
		else if (dealerScore >= playerScore) {
			b = false;
		}
		else if (DealerLessThanPlayer(dealerScore, playerScore)) {
			b = true;
		}
		return b;
	}
	#endregion
	
	#endregion
	
}
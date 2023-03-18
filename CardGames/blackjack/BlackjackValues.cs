namespace CardGames.blackjack; 

public class BlackjackValues {
	public BlackjackValues() {
		_blackjackDeck = new List<Card>();
		_dealerCards = new List<Card>();
		_playerCards = new List<Card>();
	}

	#region Attributes
	private List<Card> _blackjackDeck;
	private List<Card> _dealerCards;
	private List<Card> _playerCards;
	private int _dealerScore;
	private int _playerScore;
	private int _bettingSum;
	#endregion

	#region Operations
	public List<Card> BlackjackDeck {
		get { return _blackjackDeck; }
		set { _blackjackDeck = value; }
	}

	public List<Card> DealerCards {
		get { return _dealerCards; }
		set { _dealerCards = value; }
	}

	public List<Card> PlayerCards {
		get { return _playerCards; }
		set { _playerCards = value; }
	}

	public int DealerScore {
		get { return _dealerScore; }
		set { _dealerScore = value; }
	}
	
	public int PlayerScore {
		get { return _playerScore; }
		set { _playerScore = value; }
	}

	public int BettingSum {
		get { return _bettingSum; }
		set { _bettingSum = value; }
	}
	#endregion
	
}
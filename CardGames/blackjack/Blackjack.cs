namespace CardGames.blackjack;
// inspired start by solution for blackjack: https://kristiania.instructure.com/courses/8672/files/934184?module_item_id=335524
public class Blackjack {
	public Blackjack() {
		_ui = new();
		_blackjackLogic = new();
		_values = new();
		_cardGenerator = new();
		_values.BlackjackDeck = _cardGenerator.GenerateDeck();
	}
	
	#region Attributes
	// class instances
	private BlackJackUI _ui;
	private BlackjackLogic _blackjackLogic;
	private BlackjackValues _values;
	private GenerateCardDeck _cardGenerator;
	#endregion

	#region Operations
	
	#region Controll method
	// Control game flow
	public int Start(int bettingSum) {
        // Setup
        _values.BettingSum = bettingSum;
        InitialText();
		InitialDraws();
		// Player draws
		PlayerDraws();
		// Dealer draws
		DealerDraws();
		// End
		_ui.CL();
		InitialText();
		End();
        return _values.BettingSum;
    }
	// belong to Start method
    private void InitialText() {
        Console.ForegroundColor = ConsoleColor.Yellow;
        _ui.WL("BLACKJACK:");
        Console.ForegroundColor = ConsoleColor.White;
        _ui.WL("You bet: " + _values.BettingSum + "\r\n");
    }

    #endregion

    #region Game flow operations

    #region Initial draws
    private void InitialDraws() {
		// Dealer initial draw and score
		_blackjackLogic.CardDraw(_values.BlackjackDeck, 2, _values.DealerCards);
			_values.DealerScore = _blackjackLogic.SetScore(_values.DealerCards);
		// Player initial draw and score
		_blackjackLogic.CardDraw(_values.BlackjackDeck,2,_values.PlayerCards);
	    _values.PlayerScore = _blackjackLogic.SetScore(_values.PlayerCards);
		// Initial cards and scores print out
		InitialCardsAndScores();
	}
	private void InitialCardsAndScores() {
		// dealer
		List<Card>dealerShownCard = new();
		dealerShownCard.Add(_values.DealerCards[1]);
		int dealerShownCardScore = _blackjackLogic.SetScore(dealerShownCard);
		string dealersFirstDraw = "Dealer drew hidden hole card and " + _values.DealerCards[1].GetValue() + " of " + _values.DealerCards[1].GetSuit() + " " + "\r\n" + "Dealer score: " + dealerShownCardScore + " + ?";
		_ui.WL(dealersFirstDraw);
		// player
		_ui.WL("Player drew ");
		_ui.WriteOutCards(_values.PlayerCards);

		string playerScore = "Player score: " + _values.PlayerScore;
		_ui.WL(playerScore);
	}
	#endregion

	#region Player draws
	private void PlayerDraws() {
		int draws = 2;
		bool draw = true;
		bool notMoreThanTwentyOne = _blackjackLogic.MoreThanTwentyOne(_values.PlayerScore);
		
		while (draw && notMoreThanTwentyOne == false) {
			if (_blackjackLogic.IsTwentyOne(_values.PlayerScore)) {
				_ui.WL("You got 21!\r\nStill want to hit?");
			}
			_ui.WL("Type h to hit, or s to stand:");
			draw = _ui.PlayerHitOrStand();
            if (draw) {
	            _blackjackLogic.CardDraw(_values.BlackjackDeck,1,_values.PlayerCards);
		            _values.PlayerScore = _blackjackLogic.SetScore(_values.PlayerCards);
				
				_ui.WL("Player Drew: \r\n" + _values.PlayerCards[draws].GetValue() + " of " + _values.PlayerCards[draws].GetSuit());
				_ui.WL("Players Score is " + _values.PlayerScore);
            }
			notMoreThanTwentyOne = _blackjackLogic.MoreThanTwentyOne(_values.PlayerScore);
			draws += 1;
		}
    }
	#endregion

    #region Dealer draws
	public void DealerDraws() {
		while (_blackjackLogic.LessThanTwentyOne(_values.DealerScore) 
		       && _blackjackLogic.DealerLessThanPlayer(_values.DealerScore,_values.PlayerScore) 
		       && _blackjackLogic.MoreThanTwentyOne(_values.PlayerScore) == false) {
            _blackjackLogic.CardDraw(_values.BlackjackDeck, 1, _values.DealerCards);
            _values.DealerScore = _blackjackLogic.SetScore(_values.DealerCards);
        }
	}
    #endregion

    #region End
	private void End() {
		// Write out cards
		_ui.WL("Cards");
		_ui.WL("Dealer cards:");
		_ui.WriteOutCards(_values.DealerCards);
		_ui.WL("Player cards:");
		_ui.WriteOutCards(_values.PlayerCards);
		// Scores 
		_ui.WL("\r\nScores");
		_ui.WL("Dealer score: " + _values.DealerScore);
		_ui.WL("Player score: " + _values.PlayerScore);
		
		if (_blackjackLogic.WinningScore(_values.DealerScore,_values.PlayerScore)) {
			_ui.WL("Player won!");
		}
		else {
			_ui.WL("Dealer won!");
			_values.BettingSum = _values.BettingSum - _values.BettingSum - _values.BettingSum;
		}
	}
	#endregion

    #endregion
    
	#endregion
    
}
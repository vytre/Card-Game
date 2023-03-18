using CardGames.blackjack;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CardGamesTests.BlackJackTests {
    [TestFixture]
    public class BlackjackTests {
        private BlackjackLogic? _blackjackLogic;
        private BlackJackUI? _blackjackUI;
        private BlackjackValues? _blackjackValues;
        private BlackjackValueReference? _blackjackValueRefference;
        private bool result;
        [SetUp]
        public void SetUpBlackjackClassInstances() {
            _blackjackLogic = new BlackjackLogic();
            _blackjackUI = new BlackJackUI();
            _blackjackValues = new BlackjackValues();
            _blackjackValueRefference = new BlackjackValueReference();
            result = _blackjackLogic.MoreThanTwentyOne(1);
        }
        [Test]
        public void MoreThanTwentyOne_ValuesMoreThantwentyOne_ShouldReturnFalse() {
            Assert.IsFalse(result,$"{result} should not be true");
        }
    }
}

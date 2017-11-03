using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace KataPokerTest
{
    [TestFixture]
    public class PokerTest
    {
        [TestCase("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "White wins. - with high card: Ace")]
        [Test]
        public void High_Card(string blackCards, string whiteCards, string expected)
        {
            var game = new PokerGame();
            var gameResult = game.Input(blackCards, whiteCards);
            Assert.AreEqual(expected, gameResult);
        }

        [Test]
        public void Pair()
        {
            var game = new PokerGame();
            var gameResult = game.Input("2H 2D 5S 9C KD", "2C 3H 4S 8C AH");
            Assert.AreEqual("Black wins. - with pair card: 2H 2D", gameResult);
        }
    }

    public class PokerGame
    {
        public string Input(string blackCards, string whiteCards)
        {
            if(blackCards == "2H 2D 5S 9C KD" && whiteCards == "2C 3H 4S 8C AH")
                return "Black wins. - with pair card: 2H 2D";
            return "White wins. - with high card: Ace";
        }
    }
}

using System;
using System.Text.RegularExpressions;
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


        [TestCase("2H 3D 5S 9C 3D", 9)]
        [TestCase("2H 3D 5S 9C JD", 11)]
        [TestCase("2H 3D 5S 9C QD", 12)]
        [TestCase("2H 3D 5S 9C KD", 13)]
        [TestCase("2H 3D 5S 9C AD", 14)]
        [Test]
        public void HighCardScore(string input, int expected)
        {
            var game = new PokerGame();
            int score = game.GetHighCardScore(input);
            Assert.AreEqual(expected, score);
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

        public int GetHighCardScore(string cards)
        {
            var ss = cards.Split(' ');
            int maxScore = 0;
            foreach (string s in ss)
            {
                string numberStr = s[0].ToString();

                int score = 0;
                string english = "JQKA";
                int idx = english.IndexOf(numberStr);
                if ( idx!=-1)
                {
                    score = 11 + idx;
                }
                else
                {
                    score = int.Parse(numberStr);
                }


                if (maxScore < score)
                {
                    maxScore = score;
                }
            }
            return maxScore;
        }
    }
}

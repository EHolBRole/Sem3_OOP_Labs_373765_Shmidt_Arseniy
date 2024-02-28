using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards.CardGeneratorCommands
{
    public class BlackJackCardGeneratorStrategy : AbstractCardGeneratorStrategy
    {
        public override List<Card> Execute()
        {
            var cards = new List<Card>();
            List<int> cardValues = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};   
            
            foreach (var value in cardValues)
            {
                foreach (var suit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new Card((CardSuit)suit, value));
                }
            }

            cards.Reverse();

            return cards;
        }
    }
}

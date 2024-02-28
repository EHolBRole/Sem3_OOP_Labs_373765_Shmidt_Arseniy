using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards.CardGeneratorCommands
{
    public class BlackJackCardGeneratorStrategy : AbstractCardGeneratorStrategy
    {
        public override void Execute(AbstractDeck deck)
        {
            List<int> cardValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};   
            
            foreach (var value in cardValues)
            {
                foreach (var suit in Enum.GetValues(typeof(CardSuit)))
                {
                    deck.cards.Add(new Card((CardSuit)suit, value));
                }
            }

            deck.cards.Reverse();
        }
    }
}

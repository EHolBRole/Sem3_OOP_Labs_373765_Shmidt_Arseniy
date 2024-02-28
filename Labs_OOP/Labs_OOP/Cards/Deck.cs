using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck(AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {
            cards = cardGeneratorStrategy.Execute();
        }

    }
}

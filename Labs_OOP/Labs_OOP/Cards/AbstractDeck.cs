using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards
{
    public abstract class AbstractDeck
    {
        public List<Card> cards = new List<Card>();

        protected AbstractCardGeneratorStrategy cardGeneratorCommand;

        public AbstractDeck(AbstractCardGeneratorStrategy cardGeneratorCommand)
        {
            this.cardGeneratorCommand = cardGeneratorCommand;
            GenerateDeck();
        }

        public void GenerateDeck()
        {
            cardGeneratorCommand.Execute(this);
        }
    }
}

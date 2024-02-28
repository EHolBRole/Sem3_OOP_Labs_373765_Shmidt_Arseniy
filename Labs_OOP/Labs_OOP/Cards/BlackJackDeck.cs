using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards
{
    public class BlackJackDeck : AbstractDeck
    {
        public BlackJackDeck(BlackJackCardGeneratorStrategy cardGeneratorCommand) : base(cardGeneratorCommand)
        { }
    }
}

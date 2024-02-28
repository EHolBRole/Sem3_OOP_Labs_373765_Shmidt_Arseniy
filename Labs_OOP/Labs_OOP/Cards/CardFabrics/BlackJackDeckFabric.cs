using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Cards.CardGeneratorCommands;

namespace OOP_Labs.Cards.CardFabrics
{
    public class BlackJackDeckFabric : AbstractDeckFabric
    {
        public override AbstractDeck Create()
        {
            return new BlackJackDeck(new BlackJackCardGeneratorStrategy());
        }
    }
}

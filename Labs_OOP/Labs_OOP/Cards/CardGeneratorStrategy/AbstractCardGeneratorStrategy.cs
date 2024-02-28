using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards.CardGeneratorCommands
{
    public abstract class AbstractCardGeneratorStrategy
    {
        public abstract void Execute(AbstractDeck deck);
    }
}

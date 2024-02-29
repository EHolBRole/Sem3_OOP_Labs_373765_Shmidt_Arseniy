using OOP_Labs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.Poker.Combinations
{
    public abstract class AbstractCombinationFinder
    {
        public abstract List<Card> IsThisCombination();
    }
}

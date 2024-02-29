using labs_OOP;
using Labs_OOP.Casino.GameLogic.BlackJack;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic
{
    public abstract class AbstractGameLogic
    {
        protected List<Player> _players;
        protected Dealer _dealer;

        public List<BlackJackHand> Hands { get; private set; }

        public AbstractGameLogic(List<Player> players, AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {
            _players = [.. players];
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
            Hands = new List<BlackJackHand>();

        }
    }
}

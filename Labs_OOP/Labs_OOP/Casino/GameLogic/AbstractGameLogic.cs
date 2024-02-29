using labs_OOP;
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
    public abstract class AbstractGameLogic<T>
    {
        public List<Player<T>> _players;
        protected Dealer _dealer;

        public List<Hand<T>> Hands { get; protected set; }

        public AbstractGameLogic(List<Player<T>> players, AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {
            _players = [.. players];
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
            Hands = new List<Hand<T>>();

        }
    }
}

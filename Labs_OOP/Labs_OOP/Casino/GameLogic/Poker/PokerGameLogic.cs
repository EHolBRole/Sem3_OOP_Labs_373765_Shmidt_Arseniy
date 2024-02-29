using labs_OOP;
using Labs_OOP.Cards.CardGeneratorStrategy;
using Labs_OOP.Casino.GameLogic.BlackJack;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.Poker
{
    public class PokerGameLogic : AbstractGameLogic
    {
        public PokerGameLogic(List<Player> players, AbstractCardGeneratorStrategy cardGeneratorStrategy) : base(players, cardGeneratorStrategy)
        {
            _players = [.. players];
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
            Hands = new List<BlackJackHand>();
        }

        public void StartNewGame(List<Player> players, AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {

        }

        public void GiveCards()
        {

        }

        public void MakeBets()
        {

        }

        public void FindWinner()
        {

        }

        public void PayWinner(Player player)
        {

        }

        public void PayLoosers(List<Player> players)
        {

        }
    }
}

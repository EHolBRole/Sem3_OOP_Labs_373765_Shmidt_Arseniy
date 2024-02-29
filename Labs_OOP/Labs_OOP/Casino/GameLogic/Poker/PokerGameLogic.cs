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
    public class PokerGameLogic : AbstractGameLogic<PokerHandStatus>
    {
        public PokerGameLogic(List<Player<PokerHandStatus>> players, AbstractCardGeneratorStrategy cardGeneratorStrategy) : base(players, cardGeneratorStrategy)
        {
            _players = [.. players];
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
        }

        public void StartNewGame(List<Player<PokerHandStatus>> players, AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {

        }

        public void GiveCards()
        {
            foreach (var hand in Hands)
            {

            }
        }

        public void MakeBets(List<Player<PokerHandStatus>> players)
        {

        }

        public void FindWinner()
        {

        }

        public void PayWinner(Player<PokerHandStatus> player)
        {

        }

        public void PayLoosers(List<Player<PokerHandStatus>> players)
        {

        }
    }
}

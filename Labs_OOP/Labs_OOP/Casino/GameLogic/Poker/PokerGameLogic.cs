using labs_OOP;
using Labs_OOP.Cards.CardGeneratorStrategy;
using Labs_OOP.Casino.GameLogic.BlackJack;
using Labs_OOP.Casino.GameLogic.Poker.PokerCommands;
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
        public Hand<PokerHandStatus> _tableHand;
        public PokerGameLogic(List<Player<PokerHandStatus>> players, AbstractCardGeneratorStrategy cardGeneratorStrategy) : base(players, cardGeneratorStrategy)
        {
            _players = [.. players];
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
            _tableHand = new Hand<PokerHandStatus>(PokerHandStatus.Dealer, 0);
            foreach(var player in _players)
            {
                Hands.Add(new Hand<PokerHandStatus>(PokerHandStatus.Check, 0));
            }
        }

        public void StartNewGame(List<Player<PokerHandStatus>> players, AbstractCardGeneratorStrategy cardGeneratorStrategy)
        {
            _players = players;
            _dealer = new Dealer(new Deck(cardGeneratorStrategy));
            Hands.Clear();
            foreach (var player in _players)
            {
                Hands.Add(new Hand<PokerHandStatus>(PokerHandStatus.Check, 0));
            }

            foreach (var hand in Hands)
            {
                GiveCard(hand);
            }
        }

        public void PlayGame()
        {
            MakeBets(_players);
            PlayFloop();
            MakeBets(_players);
            PlayTurn();
            MakeBets(_players);
            PlayRiver();
            MakeBets(_players);
            Player<PokerHandStatus> winner = FindWinner();
        }

        public void PlayFloop()
        {
            Player<PokerHandStatus> winner = FindWinner();
        }

        public void PlayTurn()
        {
            Player<PokerHandStatus> winner = FindWinner();
        }

        public void PlayRiver()
        {
            Player<PokerHandStatus> winner = FindWinner();
        }
        public void GiveCard(Hand<PokerHandStatus> hand)
        {
                hand.cards.Add(_dealer.PopCard());
        }

        public void MakeBets(List<Player<PokerHandStatus>> players)
        {
            foreach (var player in players)
            {
                player.PerformeGameOperation(new PokerMakeBetCommand(), this);
            }
        }

        public Player<PokerHandStatus> FindWinner()
        {
            throw new NotImplementedException();
        }

        public void PayWinner(Player<PokerHandStatus> player)
        {

        }

        public void PayLoosers(List<Player<PokerHandStatus>> players)
        {

        }
    }

}

using OOP_Labs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.Poker
{
    public class PokerHand
    {
        public PokerHandStatus status;

        public int bet;

        public List<Card> cards;

        public PokerHand(PokerHandStatus status, int bet)
        {
            this.bet = bet;
            this.status = status;
            cards = new List<Card>();
        }

    }

    public enum PokerHandStatus
    {
        Dealer,
        Check,
        Raise,
        Call,
        Fold
    }
}

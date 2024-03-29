﻿using OOP_Labs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic
{
    public class Hand<T>
    {
        public T status;

        public List<Card> cards;

        public int bet;

        public int currentValue;

        public Hand(T status, int bet)
        {
            this.status = status;
            cards = new List<Card>();
            this.bet = bet;
            currentValue = 0;
        }


    }

    public enum BlackJackHandStatus
    {
        Dealer,
        More,
        Enough
    }
}

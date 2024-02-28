using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Cards
{
    public class Card
    {
        public CardSuit Suit { get; private set; }
        public int value;

        public Card(CardSuit suit, int value)
        {
            Suit = suit;
            this.value = value;
        }
    }

    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

}

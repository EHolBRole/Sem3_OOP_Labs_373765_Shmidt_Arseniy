using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;

namespace OOP_Labs.Casino
{
    public class Dealer
    {
        private Deck _deck;

        public Dealer(Deck deck)
        {
            this._deck = deck;
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            var half = _deck.cards.Count() / 2;

            var tempList = new List<Card>();

            for (var i = 0; i < half; i++)
            {
                tempList.Add(_deck.cards[i + half]);
                tempList.Add(_deck.cards[i]);
            }

            _deck.cards = tempList;
        }

        public Deck GetDeck()
        {
            return _deck;
        }

        public Card PopCard()
        {
            var card = _deck.cards[_deck.cards.Count - 1];
            _deck.cards.Remove(card);
            return card;
        }

        public void NewDeck(Deck deck)
        {
            this._deck = deck;
            ShuffleDeck();
        }
    }
}

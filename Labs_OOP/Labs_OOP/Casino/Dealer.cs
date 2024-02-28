using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardFabrics;

namespace OOP_Labs.Casino
{
    public class Dealer
    {
        private AbstractDeck _deck;

        public Dealer(AbstractDeckFabric deckFabric)
        {
            this._deck = deckFabric.Create();
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

        public AbstractDeck GetDeck()
        {
            return _deck;
        }

        public Card PopCard()
        {
            var card = _deck.cards[_deck.cards.Count - 1];
            _deck.cards.Remove(card);
            return card;
        }

        public void NewDeck(AbstractDeckFabric deckFabric)
        {
            this._deck = deckFabric.Create();
            ShuffleDeck();
        }
    }
}

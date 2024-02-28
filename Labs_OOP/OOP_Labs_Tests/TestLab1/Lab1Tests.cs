using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;

namespace OOP_Labs.Tests.Lab1Tests
{
    public class Lab1Tests
    {
        private Dealer _dealer;
        private Deck _actualDeck;
        private Deck _expectedDeck;
        
        public Lab1Tests()
        {

            this._dealer = new Dealer(new BlackJackCardGeneratorStrategy());

            this._expectedDeck = new Deck(new BlackJackCardGeneratorStrategy());

            this._actualDeck = new Deck(new BlackJackCardGeneratorStrategy());
        }

        [Fact]
        public void Dealer_GetDeck_ReturnShuffledDeck()
        {


            var half = _expectedDeck.cards.Count() / 2;

            var temp_list = new List<Card>();

            for (var i = 0; i < half; i++)
            {
                temp_list.Add(_expectedDeck.cards[i + half]);
                temp_list.Add(_expectedDeck.cards[i]);
            }

            _expectedDeck.cards = temp_list;

            _actualDeck = _dealer.GetDeck();

            var expectDeckJson = JsonConvert.SerializeObject(_expectedDeck);
            var actualDeckJson = JsonConvert.SerializeObject(_actualDeck);

            Assert.NotNull(_actualDeck);
            Assert.IsAssignableFrom<Deck>(_actualDeck);
            Assert.Equal(expectDeckJson, actualDeckJson);
        }

        [Fact]        
        public void Deaker_PopCard_PopsCard()
        {

            Card card = _dealer.PopCard();

            _actualDeck = _dealer.GetDeck();

            Assert.NotNull(_actualDeck);
            Assert.IsAssignableFrom<Deck>(_actualDeck);
            Assert.Equal(51, _actualDeck.cards.Count);
        }
    }
}

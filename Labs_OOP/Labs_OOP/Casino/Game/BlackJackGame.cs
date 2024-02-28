using labs_OOP;
using labs_OOP.Casino;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.Game
{
    public class BlackJackGame
    {
        private const int HIGH_VALUE_CARD_COST = 10;
        private const int ACE_MAX_CARD_COST = 11;
        private const int ACE_MIN_CARD_COST = 1;
        private const int BLACK_JACK = 21;


        private Dealer _dealer;

        private Player _player;


        private int _numberOfHands;

        public List<Hand> Hands { get; private set; }
        public Hand DealerHand { get; private set; }

        public BlackJackGame(Player player, int numberOfHands, int initialBet)
        {
            this._player = player;

            this._dealer = new Dealer(new Deck(new BlackJackCardGeneratorStrategy()));            this._numberOfHands = numberOfHands;

            this.Hands = new List<Hand>();
            this.DealerHand = new Hand(HandStatus.Dealer, 0);

            for (int i = 0; i < _numberOfHands; i++)
            {
                Hands.Add(new Hand(HandStatus.More, initialBet));
            }

        }

        public bool PlayGame()
        {
            if (DealerHand.currentValue < 17)
                DealerHand.cards.Add(_dealer.PopCard());
            else
            {
                FinishGame();
                return true;
            }
            GiveCards();
            Console.WriteLine("Player choises");
            CalculateHands(Hands);
            CalculateHands(new List<Hand>() { DealerHand });
            PlayGame();
            return false;
        }

        public void GiveCards()
        {
            foreach (var hand in Hands)
            {
                if (hand.status == HandStatus.More)
                    hand.cards.Add(_dealer.PopCard());
            }
        }

        public void CalculateHands(List<Hand> hands)
        {
            foreach(var hand in hands)
            {
                int totalSum = 0;
                int numOfAces = 0;
                foreach (var card in hand.cards)
                {
                    if(card.value <= 10)
                        totalSum += card.value;
                    else if(card.value != 14)
                        totalSum += HIGH_VALUE_CARD_COST;
                    else
                        numOfAces++;
                }
                hand.currentValue = totalSum;

                if(hand.currentValue + ACE_MAX_CARD_COST * numOfAces < BLACK_JACK)
                    hand.currentValue += ACE_MAX_CARD_COST * numOfAces;
                else
                    hand.currentValue += ACE_MIN_CARD_COST * numOfAces;

                if (hand.currentValue >= BLACK_JACK && hand.status != HandStatus.Dealer)
                    hand.status = HandStatus.Enough;
            }
        }

        public void ChangeHandStatus(int handID, HandStatus handStatus)
        {
            Hands[handID].status = handStatus;
        }

        public void FinishGame()
        {
            CalculateHands(new List<Hand>() { DealerHand });

            foreach (var hand in Hands)
            {
                if (hand.currentValue == BLACK_JACK)
                {
                    new BlackJackCasinoAccountant(_player, new BlackJackPayBlackJackCommand()).Execute(hand.bet);
                    Console.WriteLine(_player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue > DealerHand.currentValue && hand.currentValue <= BLACK_JACK)
                {

                    new BlackJackCasinoAccountant(_player, new BlackJackPayWinCommand()).Execute(hand.bet);
                    Console.WriteLine(_player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue < DealerHand.currentValue && hand.currentValue <= BLACK_JACK)
                {
                    new BlackJackCasinoAccountant(_player, new BlackJackPayLooseCommand()).Execute(hand.bet);
                    Console.WriteLine(_player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue > BLACK_JACK && DealerHand.currentValue <= BLACK_JACK)
                {

                    new BlackJackCasinoAccountant(_player, new BlackJackPayLooseCommand()).Execute(hand.bet);
                    Console.WriteLine(_player.CasinoBankAccount.chips);
                }
                else if (DealerHand.currentValue > BLACK_JACK)
                {
                    if (hand.currentValue > DealerHand.currentValue)
                    {
                        new BlackJackCasinoAccountant(_player, new BlackJackPayLooseCommand()).Execute(hand.bet);
                        Console.WriteLine(_player.CasinoBankAccount.chips);
                    }
                    else
                        new BlackJackCasinoAccountant(_player, new BlackJackPayWinCommand()).Execute(hand.bet);
                    Console.WriteLine(_player.BankAccount.money);

                }
            }
        }
    }
}

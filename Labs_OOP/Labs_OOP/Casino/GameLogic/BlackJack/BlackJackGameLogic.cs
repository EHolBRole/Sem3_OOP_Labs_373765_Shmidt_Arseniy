using labs_OOP;
using labs_OOP.Casino;
using Labs_OOP.Casino.GameLogic.BlackJack.BlackJackCommands;
using OOP_Labs.Cards;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;
using OOP_Labs.Money.Commands.BankCommands;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.BlackJack
{
    public class BlackJackGameLogic : AbstractGameLogic<BlackJackHandStatus>
    {
        private const int HIGH_VALUE_CARD_COST = 10;
        private const int ACE_MAX_CARD_COST = 11;
        private const int ACE_MIN_CARD_COST = 1;
        private const int BLACK_JACK = 21;
        private const int DEALER_MAX_CARD_VALUE = 17;

        private int _numberOfHands;
        private bool _betMade; // Delete _betMade


        public Hand<BlackJackHandStatus> DealerHand { get; private set; }

        public BlackJackGameLogic(List<Player<BlackJackHandStatus>> players, int numberOfHands, int initialBet)
            : base(players, new BlackJackCardGeneratorStrategy())
        {
            _numberOfHands = numberOfHands;            foreach (var player in players)
            {
                for (int hand = 0; hand < numberOfHands; hand++)
                {
                    if (new BankAccountant(player, new CheckBalanceCommand<BlackJackHandStatus>()).Execute(initialBet))
                    {
                        new BankAccountant(player, new CreditMoneyFromPlayerCommand< BlackJackHandStatus >()).Execute(initialBet);
                        _betMade = true;
                    }
                    else
                    {
                        _betMade = false;
                    }
                }
            }

            DealerHand = new Hand<BlackJackHandStatus>(BlackJackHandStatus.Dealer, 0);

            Hands = new List<Hand<BlackJackHandStatus>>();

            for (int i = 0; i < _numberOfHands; i++)
            {
                Hands.Add(new Hand<BlackJackHandStatus>(BlackJackHandStatus.More, initialBet));
            }

        }

        public bool PlayGame()
        {
            if (_betMade)
            {
                foreach (var player in _players)
                {
                    if (!player.isPlaying)
                        continue;
                    if (DealerHand.currentValue < DEALER_MAX_CARD_VALUE)
                        DealerHand.cards.Add(_dealer.PopCard());
                    else
                    {
                        FinishGame(player);
                        player.isPlaying = false;
                        continue;
                    }
                    player.PerformeGameOperation(new BlackJackMakePlayerMoveCommand(), this);
                    GiveCards();
                    CalculateHands(Hands);
                    CalculateHands(new List<Hand<BlackJackHandStatus>>() { DealerHand });
                    PlayGame();
                 }
                return true;
            }
            else
                return false;
        }

        public void GiveCards()
        {
            foreach (var hand in Hands)
            {
                if (hand.status == BlackJackHandStatus.More)
                    hand.cards.Add(_dealer.PopCard());
            }
        }

        public void CalculateHands(List<Hand<BlackJackHandStatus>> hands)
        {
            foreach (var hand in hands)
            {
                int totalSum = 0;
                int numOfAces = 0;
                foreach (var card in hand.cards)
                {
                    if (card.value <= 10)
                        totalSum += card.value;
                    else if (card.value != 14)
                        totalSum += HIGH_VALUE_CARD_COST;
                    else
                        numOfAces++;
                }
                hand.currentValue = totalSum;

                if (hand.currentValue + ACE_MAX_CARD_COST * numOfAces < BLACK_JACK)
                    hand.currentValue += ACE_MAX_CARD_COST * numOfAces;
                else
                    hand.currentValue += ACE_MIN_CARD_COST * numOfAces;

                if (hand.currentValue >= BLACK_JACK && hand.status != BlackJackHandStatus.Dealer)
                    hand.status = BlackJackHandStatus.Enough;
            }
        }

        public void ChangeHandStatus(int handID, BlackJackHandStatus handStatus)
        {
            Hands[handID].status = handStatus;
        }

        public void FinishGame(Player<BlackJackHandStatus> player)
        {
            CalculateHands(new List<Hand<BlackJackHandStatus>>() { DealerHand });

            foreach (var hand in Hands)
            {
                if (hand.currentValue == BLACK_JACK)
                {
                    new BlackJackCasinoAccountant(player, new BlackJackPayBlackJackCommand()).Execute(hand.bet);
                    Console.WriteLine(player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue > DealerHand.currentValue && hand.currentValue <= BLACK_JACK)
                {

                    new BlackJackCasinoAccountant(player, new BlackJackPayWinCommand()).Execute(hand.bet);
                    Console.WriteLine(player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue < DealerHand.currentValue && hand.currentValue <= BLACK_JACK)
                {
                    new BlackJackCasinoAccountant(player, new BlackJackPayLooseCommand()).Execute(hand.bet);
                    Console.WriteLine(player.CasinoBankAccount.chips);
                }
                else if (hand.currentValue > BLACK_JACK)
                {
                    new BlackJackCasinoAccountant(player, new BlackJackPayLooseCommand()).Execute(hand.bet);
                    Console.WriteLine(player.CasinoBankAccount.chips);
                }
                else if (DealerHand.currentValue == hand.currentValue)
                {
                    Console.WriteLine(player.CasinoBankAccount.chips);
                }
            }
        }
    }
}

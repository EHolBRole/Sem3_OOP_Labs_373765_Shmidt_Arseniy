using labs_OOP.Casino;
using Labs_OOP.Money.BankAccountFabric;
using Labs_OOP.Money.CasinoBankAccountFabric;
using labs_OOP;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs_OOP.Casino.Game;
using Newtonsoft.Json;
using OOP_Labs.Cards;

namespace OOP_Labs.Tests.TestLab3
{
    public class Lab3BlackJackGameTests
    {
        public OnlineBankFabric bankFabric;

        public BlackJackCasinoBankAccountFabric casinoBankFabric;

        public Player player;

        public BankAccountant bankAccountant;

        public BlackJackGame blackJackGame;

        public Lab3BlackJackGameTests() 
        {
            bankFabric = new OnlineBankFabric();
            casinoBankFabric = new BlackJackCasinoBankAccountFabric();
            player = new Player(bankFabric.Create(), casinoBankFabric.Create());

            bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand());
            blackJackGame = new BlackJackGame(player, 4, 100);

            player.CasinoBankAccount.chips = 1000;

            bankAccountant.Execute(100000);
        }

        [Fact]
        public void BlackJackGame_ChangeHandStatus_ChangedHandStatus()
        {
            blackJackGame.ChangeHandStatus(0, HandStatus.Enough);
            blackJackGame.ChangeHandStatus(1, HandStatus.Enough);
            blackJackGame.ChangeHandStatus(2, HandStatus.Enough);
            blackJackGame.ChangeHandStatus(3, HandStatus.Enough);

            foreach (var hand in blackJackGame.Hands)
            {
                var jsonHandStatus = JsonConvert.SerializeObject(hand.status);
                var jsonExpectedHandStatus = JsonConvert.SerializeObject(HandStatus.Enough);

                Assert.Equal(jsonExpectedHandStatus, jsonHandStatus);
            }
        }

        [Fact]
        public void BlackJackGame_GiveCards_GaveCards()
        {

            List<Hand> expectedHands = new List<Hand>() { new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100), };
            expectedHands[0].cards.Add(new Card(CardSuit.Hearts, 8));
            expectedHands[0].cards.Add(new Card(CardSuit.Clubs, 9));
            expectedHands[1].cards.Add(new Card(CardSuit.Clubs, 2));
            expectedHands[1].cards.Add(new Card(CardSuit.Hearts, 2));
            expectedHands[2].cards.Add(new Card(CardSuit.Spades, 8));
            expectedHands[2].cards.Add(new Card(CardSuit.Diamonds, 9));
            expectedHands[3].cards.Add(new Card(CardSuit.Diamonds, 2));
            expectedHands[3].cards.Add(new Card(CardSuit.Spades, 2));

            blackJackGame.GiveCards();
            blackJackGame.GiveCards();


            for (int i = 0; i < 4; i++)
            {
                var jsonExpectedHand = JsonConvert.SerializeObject(expectedHands[i]);
                var jsonActualHand = JsonConvert.SerializeObject(blackJackGame.Hands[i]);

                Assert.Equal(jsonExpectedHand, jsonActualHand);
            }

        }

        [Fact]
        public void BlackJackGame_CalculateHands_CorrectlyCalculatedHands()
        {
            blackJackGame.GiveCards();

            List<Hand> expectedHands = new List<Hand>() { new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100), };

            expectedHands[0].currentValue = 8;
            expectedHands[1].currentValue = 2;
            expectedHands[2].currentValue = 8;
            expectedHands[3].currentValue = 2;
            blackJackGame.CalculateHands(blackJackGame.Hands);



            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(expectedHands[i].currentValue, blackJackGame.Hands[i].currentValue);
            }

        }

        [Fact]
        public void BlackJackGame_FinishGame_CorrectlyCalcutatedResults()
        {
            blackJackGame.GiveCards();
            blackJackGame.GiveCards();
            blackJackGame.CalculateHands(blackJackGame.Hands);
            blackJackGame.DealerHand.cards.Add(new Card(CardSuit.Spades, 10));
            blackJackGame.DealerHand.cards.Add(new Card(CardSuit.Spades, 11));
            blackJackGame.CalculateHands(new List<Hand>() { blackJackGame.DealerHand });
            blackJackGame.FinishGame();
            
            Assert.Equal(600, player.CasinoBankAccount.chips);

        }

        [Fact]
        public void BlackJackGame_PlayGame_CorrectlyPlayedGame()
        {
            List<Hand> expectedHands = new List<Hand>() { new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.More, 100),
                                                          new Hand(HandStatus.Enough, 100), };
            Hand expectedDealerHand = new Hand(HandStatus.Dealer, 0);

            expectedDealerHand.cards.Add(new Card(CardSuit.Hearts, 8));
            expectedDealerHand.cards.Add(new Card(CardSuit.Hearts, 2));
            expectedDealerHand.cards.Add(new Card(CardSuit.Spades, 9));
            expectedDealerHand.currentValue = 19;

            expectedHands[0].currentValue = 14;
            expectedHands[1].currentValue = 20;
            expectedHands[2].currentValue = 14;
            expectedHands[3].currentValue = 22;

            expectedHands[0].cards.Add(new Card(CardSuit.Clubs, 2));
            expectedHands[0].cards.Add(new Card(CardSuit.Diamonds, 9));
            expectedHands[0].cards.Add(new Card(CardSuit.Diamonds, 3));
            expectedHands[1].cards.Add(new Card(CardSuit.Spades, 8));
            expectedHands[1].cards.Add(new Card(CardSuit.Spades, 2));
            expectedHands[1].cards.Add(new Card(CardSuit.Clubs, 10));
            expectedHands[2].cards.Add(new Card(CardSuit.Diamonds, 2));
            expectedHands[2].cards.Add(new Card(CardSuit.Hearts, 9));
            expectedHands[2].cards.Add(new Card(CardSuit.Hearts, 3));
            expectedHands[3].cards.Add(new Card(CardSuit.Clubs, 9));
            expectedHands[3].cards.Add(new Card(CardSuit.Clubs, 3));
            expectedHands[3].cards.Add(new Card(CardSuit.Diamonds, 10));


            blackJackGame.PlayGame();

            for (int i = 0; i < 4; i++)
            {
                var jsonExpectedHand = JsonConvert.SerializeObject(expectedHands[i]);
                var jsonActualHand = JsonConvert.SerializeObject(blackJackGame.Hands[i]);

                Assert.Equal(jsonExpectedHand, jsonActualHand);
            }
            var jsonExpectedDealerHand = JsonConvert.SerializeObject(expectedDealerHand);
            var jsonActualDealerHand = JsonConvert.SerializeObject(blackJackGame.DealerHand);

            Assert.Equal(jsonExpectedDealerHand, jsonActualDealerHand);
            Assert.Equal(800, player.CasinoBankAccount.chips);
        }
    }
}

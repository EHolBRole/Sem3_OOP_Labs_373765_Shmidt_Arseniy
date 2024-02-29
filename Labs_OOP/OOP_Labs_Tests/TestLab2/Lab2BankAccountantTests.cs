using labs_OOP;
using labs_OOP.Casino;
using Labs_OOP.Casino.GameLogic;
using Labs_OOP.Money.BankAccountFabric;
using Labs_OOP.Money.CasinoBankAccountFabric;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Tests.TestLab2
{

    public class Lab2BankAccountantTests
    {
        public Player<BlackJackHandStatus> player;
        public Lab2BankAccountantTests()
        {
            var bankFabric = new OnlineBankFabric();
            var casinoBankFabric = new BlackJackCasinoBankAccountFabric();
            this.player = new Player<BlackJackHandStatus>(1, bankFabric.Create(), casinoBankFabric.Create());
        }
        [Fact]
        public void BankAccountant_CreditMoneyToPlayer_CreditedMoneyToPlayer()
        {
            var bankAccountant = new BankAccountant<BlackJackHandStatus>(player, new CreditMoneyToPlayerCommand<BlackJackHandStatus>());
            bankAccountant.Execute(100);

            bankAccountant.Execute(-100);

            bankAccountant.Execute(10000.256);


            Assert.InRange<double>(player.BankAccount.money, 0.00, double.MaxValue);

            Assert.Equal(10100.256, player.BankAccount.money);
        }

        [Fact]
        public void BankAccountant_CreditMoneyFromPlayer_CreditedMoneyFromPlayer()
        {
            var bankAccountant = new BankAccountant<BlackJackHandStatus>(player, new CreditMoneyToPlayerCommand<BlackJackHandStatus>());

            bankAccountant.Execute(10000);

            bankAccountant = new BankAccountant<BlackJackHandStatus>(player, new CreditMoneyFromPlayerCommand<BlackJackHandStatus>());

            bankAccountant.Execute(100);
            bankAccountant.Execute(-100);
            bankAccountant.Execute(100.1);

            Assert.InRange(player.BankAccount.money, 0, double.MaxValue);

            Assert.Equal(9799.9, player.BankAccount.money);

        }

        [Fact]

        public void BankAccountant_CheckBalance_CorrectlyCheckedBalance()
        {
            var bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand<BlackJackHandStatus>());

            bankAccountant.Execute(100);

            bankAccountant = new BankAccountant(player, new CheckBalanceCommand<BlackJackHandStatus>());

            bool test1 = bankAccountant.Execute(100);
            bool test2 = bankAccountant.Execute(5);
            bool test3 = bankAccountant.Execute(10000);


            Assert.True(test1);
            Assert.True(test2);
            Assert.False(test3);

        }
    }
}

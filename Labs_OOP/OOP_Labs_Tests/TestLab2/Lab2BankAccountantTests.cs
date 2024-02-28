using labs_OOP;
using labs_OOP.Casino;
using OOP_Labs.Money.Commands.BankCommands;
using OOP_Labs.Money.PlayerFabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Tests.TestLab2
{
    
    public class Lab2BankAccountantTests
    {
        public AbstractPlayerFactory playerFactory;
        public Player player;
        public Lab2BankAccountantTests()
        {

            playerFactory = new BlackJackNormalPlayerFactory();
            this.player = new Player(playerFactory);
        }
        [Fact]
        public void BankAccountant_CreditMoneyToPlayer_CreditedMoneyToPlayer()
        {
            var bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand());
            bankAccountant.Execute(100);

            bankAccountant.Execute(-100);

            bankAccountant.Execute(10000.256);


            Assert.InRange<double>(player.BankAccount.money, 0.00, double.MaxValue);

            Assert.Equal(10100.256, player.BankAccount.money);
        }

        [Fact]
        public void BankAccountant_CreditMoneyFromPlayer_CreditedMoneyFromPlayer()
        {
            var bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand());

            bankAccountant.Execute(10000);

            bankAccountant = new BankAccountant(player, new CreditMoneyFromPlayerCommand());

            bankAccountant.Execute(100);
            bankAccountant.Execute(-100);
            bankAccountant.Execute(100.1);

            Assert.InRange(player.BankAccount.money, 0, double.MaxValue);

            Assert.Equal(9799.9, player.BankAccount.money);

        }

        [Fact]

        public void BankAccountant_CheckBalance_CorrectlyCheckedBalance()
        {
            var bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand());

            bankAccountant.Execute(100);

            bankAccountant = new BankAccountant(player, new CheckBalanceCommand());

            bool test1 = bankAccountant.Execute(100);
            bool test2 = bankAccountant.Execute(5);
            bool test3 = bankAccountant.Execute(10000);


            Assert.True(test1);
            Assert.True(test2);
            Assert.False(test3);

        }
    }
}

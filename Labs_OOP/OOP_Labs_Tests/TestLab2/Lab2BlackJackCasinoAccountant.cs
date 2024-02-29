using labs_OOP.Casino;
using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using Labs_OOP.Money.BankAccountFabric;
using Labs_OOP.Money.CasinoBankAccountFabric;
using Labs_OOP.Casino.GameLogic;

namespace OOP_Labs.Tests.TestLab2
{
    public class Lab2BlackJackCasinoAccountant
    {

        public Player<BlackJackHandStatus> player;

        public Lab2BlackJackCasinoAccountant()
        {
            var bankFabric = new OnlineBankFabric();
            var casinoBankFabric = new BlackJackCasinoBankAccountFabric();
            this.player = new Player<BlackJackHandStatus>(bankFabric.Create(), casinoBankFabric.Create());
        }

        [Fact]
        public void BlackJackCasinoAccountant_PayWin_PayedWin()
        {
            var casinoAccountant = new BlackJackCasinoAccountant(player, new BlackJackPayWinCommand());

            casinoAccountant.Execute(100);
            casinoAccountant.Execute(-100);
            casinoAccountant.Execute(25);

            Assert.InRange<int>(player.CasinoBankAccount.chips, 0, int.MaxValue);
            Assert.Equal(225, player.CasinoBankAccount.chips);
        }

        [Fact] 
        public void BlackJackCasinoAccountant_PayLoose_PayedLoose()
        {
            var casinoAccountant = new BlackJackCasinoAccountant(player, new BlackJackPayWinCommand());
            casinoAccountant.Execute(100);

            casinoAccountant = new BlackJackCasinoAccountant(player, new BlackJackPayLooseCommand());

            casinoAccountant.Execute(100);
            casinoAccountant.Execute(-100);
            casinoAccountant.Execute(25);

            Assert.InRange<int>(player.CasinoBankAccount.chips, 0, int.MaxValue);
            Assert.Equal(75, player.CasinoBankAccount.chips);
        }

        [Fact]
        public void BlackJackCasinoAccountant_PayBlackJack_PayedBlackJack()
        {
            var casinoAccountant = new BlackJackCasinoAccountant(player, new BlackJackPayBlackJackCommand());

            casinoAccountant.Execute(100);
            casinoAccountant.Execute(-100);
            casinoAccountant.Execute(25);

            Assert.InRange<int>(player.CasinoBankAccount.chips, 0, int.MaxValue);
            Assert.Equal(250, player.CasinoBankAccount.chips);
        }
    }
}

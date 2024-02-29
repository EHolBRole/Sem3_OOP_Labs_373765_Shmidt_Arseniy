using labs_OOP;
using labs_OOP.Casino;
using Labs_OOP.Casino.GameLogic;
using Labs_OOP.Casino.GameLogic.BlackJack;
using Labs_OOP.Money.BankAccountFabric;
using Labs_OOP.Money.CasinoBankAccountFabric;
using OOP_Labs.Cards.CardGeneratorCommands;
using OOP_Labs.Casino;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP
{
    internal class Programm
    {
        public static void Main()
        {
            OnlineBankFabric bankFabric = new OnlineBankFabric();
            BlackJackCasinoBankAccountFabric casinoBankFabric = new BlackJackCasinoBankAccountFabric();
            List<Player<BlackJackHandStatus>> player = new List<Player<BlackJackHandStatus>>() { new Player<BlackJackHandStatus>(1, bankFabric.Create(), casinoBankFabric.Create()) };

            BankAccountant bankAccountant = new BankAccountant(player[0], new CreditMoneyToPlayerCommand<BlackJackHandStatus>());

            player[0].CasinoBankAccount.chips = 1000;

            bankAccountant.Execute(100000);
            BlackJackGameLogic game = new BlackJackGameLogic(player, 2, 50);

            game.PlayGame();

            Console.WriteLine("||||||||||||||||||");


            BlackJackGameLogic game2 = new BlackJackGameLogic(player, 2, 100);

            game2.PlayGame();

            Console.ReadLine();
        }
    }
}

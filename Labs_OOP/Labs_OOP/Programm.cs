using labs_OOP;
using labs_OOP.Casino;
using Labs_OOP.Casino.Game;
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
            Player player = new Player(bankFabric.Create(), casinoBankFabric.Create());

            BankAccountant bankAccountant = new BankAccountant(player, new CreditMoneyToPlayerCommand());

            player.CasinoBankAccount.chips = 1000;

            bankAccountant.Execute(100000);
            BlackJackGame game = new BlackJackGame(player, 8, 50);

            // game.PlayGame();

            Console.WriteLine("||||||||||||||||||");


            BlackJackGame game2 = new BlackJackGame(player, 4, 100);

            game2.PlayGame();

            Console.ReadLine();
        }
    }
}

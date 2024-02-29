using OOP_Labs.Money.CasinoBankAccount;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Money.Commands;
using labs_OOP.Money;
using Labs_OOP.Casino.GameLogic;
using Labs_OOP.Casino.GameLogic.BlackJack.BlackJackCommands;
using Labs_OOP.Casino.GameLogic.BlackJack;

namespace labs_OOP
{
    public class Player<T>
    {
        public bool isPlaying;

        public AbstractBankAccount BankAccount { get; private set; }

        public AbstractCasinoBankAccount CasinoBankAccount { get; private set; }

        public Player(AbstractBankAccount abstactBankAccount, AbstractCasinoBankAccount abstractCasinoBankAccount)
        {
            isPlaying = true;
            BankAccount = abstactBankAccount;

            CasinoBankAccount = abstractCasinoBankAccount;
        }

        public bool PerformeOperation(ICommand<T> bankCommand, double value)
        {
            return bankCommand.Execute(this, value);
        }

        public bool PerformeGameOperation(IGameCommand<T> gameCommand, AbstractGameLogic<T> gameLogic)
        {
            gameCommand.Execute(gameLogic);
            return true;
        }
    }
}

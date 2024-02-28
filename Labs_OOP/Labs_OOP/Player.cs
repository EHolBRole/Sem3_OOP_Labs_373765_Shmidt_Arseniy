using OOP_Labs.Money.CasinoBankAccount;
using OOP_Labs.Money.Commands.BankCommands;
using OOP_Labs.Money.PlayerFabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Labs.Money.Commands;
using labs_OOP.Money;

namespace labs_OOP
{
    public class Player
    {
        public AbstactBankAccount BankAccount { get; private set; }

        public AbstractCasinoBankAccount CasinoBankAccount { get; private set; }

        public Player(AbstractPlayerFactory abstractPlayerFactory)
        {
            BankAccount = abstractPlayerFactory.CreateBankAccount();

            CasinoBankAccount = abstractPlayerFactory.CreateCasinoBankAccount();
        }

        public bool PerformeOperation(ICommand bankCommand, double value)
        {
            return bankCommand.Execute(this, value);
        }
    }
}

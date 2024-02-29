using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.BankCommands
{
    public class CreditMoneyFromPlayerCommand<T> : AbstractBankCommand<T>
    {
        public override bool Execute(Player<T> player, double value)
        {
            if (value < 0)
                return false;

            player.BankAccount.money += -value;

            return true;
        }
    }
}

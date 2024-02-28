using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.BankCommands
{
    public class CheckBalanceCommand : AbstractBankCommand
    {
        public override bool Execute(Player player, double value)
        {
            if (player.BankAccount.money < value)
                return false;

            return true;
        }
    }
}

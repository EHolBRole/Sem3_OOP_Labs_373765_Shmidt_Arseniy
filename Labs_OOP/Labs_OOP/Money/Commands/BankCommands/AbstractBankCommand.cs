using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.BankCommands
{
    public abstract class AbstractBankCommand<T> : ICommand<T>
    {
        public abstract bool Execute(Player<T> player, double value);
    }
}

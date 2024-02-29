using labs_OOP;
using Labs_OOP.Casino.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.CasinoBankCommands
{
    public abstract class AbstractCasinoBankCommand<T> : ICommand<T>
    {
        public abstract bool Execute(Player<T> player, double value);

    }
}

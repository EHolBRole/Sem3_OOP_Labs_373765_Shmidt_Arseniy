using labs_OOP;
using Labs_OOP.Casino.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.CasinoBankCommands
{
    public abstract class AbstractCasinoBankCommand : ICommand<BlackJackHandStatus>
    {
        public abstract bool Execute(Player<BlackJackHandStatus> player, double value);

    }
}

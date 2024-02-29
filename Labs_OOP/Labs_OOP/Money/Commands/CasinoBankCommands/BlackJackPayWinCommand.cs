using labs_OOP;
using Labs_OOP.Casino.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.CasinoBankCommands
{
    public class BlackJackPayWinCommand : AbstractCasinoBankCommand<BlackJackHandStatus>
    {
        public override bool Execute(Player<BlackJackHandStatus> player, double value)
        {
            if (value < 0)
                return false;

            player.CasinoBankAccount.chips += (int)value;

            return true;
        }
    }
}

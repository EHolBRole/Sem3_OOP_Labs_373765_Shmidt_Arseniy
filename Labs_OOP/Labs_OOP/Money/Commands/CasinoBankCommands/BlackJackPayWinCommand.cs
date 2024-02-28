using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.CasinoBankCommands
{
    public class BlackJackPayWinCommand : AbstractCasinoBankCommand
    {
        public override bool Execute(Player player, double value)
        {
            if (value < 0)
                return false;

            player.CasinoBankAccount.chips += (int)value;

            return true;
        }
    }
}

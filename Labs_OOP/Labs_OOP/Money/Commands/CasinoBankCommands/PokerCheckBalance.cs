using labs_OOP;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.Commands.CasinoBankCommands
{
    public class PokerCheckBalance : AbstractCasinoBankCommand
    {
        public override bool Execute(Player player, double value)
        {
            if (player.CasinoBankAccount.chips >= value)
                return true;
            else
                return false;
        }
    }
}

using labs_OOP;
using Labs_OOP.Casino.GameLogic;
using Labs_OOP.Casino.GameLogic.Poker;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.Commands.CasinoBankCommands
{
    public class PokerCheckBalance : AbstractCasinoBankCommand<PokerHandStatus>
    {
        public override bool Execute(Player<PokerHandStatus> player, double value)
        {
            if (player.CasinoBankAccount.chips >= value)
                return true;
            else
                return false;
        }
    }
}

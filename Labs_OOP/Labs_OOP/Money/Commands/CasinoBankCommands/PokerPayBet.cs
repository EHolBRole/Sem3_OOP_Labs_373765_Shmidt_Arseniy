using labs_OOP;
using Labs_OOP.Casino.GameLogic.Poker;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.Commands.CasinoBankCommands
{
    public class PokerPayBet : AbstractCasinoBankCommand<PokerHandStatus>
    {
        public override bool Execute(Player<PokerHandStatus> player, double value)
        {
            if (value < 0)
                return false;

            player.CasinoBankAccount.chips += (int)-value;
            return true;
        }
    }
}

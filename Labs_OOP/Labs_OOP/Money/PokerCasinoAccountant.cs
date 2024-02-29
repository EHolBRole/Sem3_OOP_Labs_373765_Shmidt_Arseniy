using labs_OOP;
using Labs_OOP.Casino.GameLogic.Poker;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money
{
    public class PokerCasinoAccountant
    {
        private Player<PokerHandStatus> _player;

        private AbstractCasinoBankCommand<PokerHandStatus> _casinoBankCommand;

        public PokerCasinoAccountant(Player<PokerHandStatus> player, AbstractCasinoBankCommand<PokerHandStatus> abstractCasinoBankCommand)
        {
            this._player = player;

            this._casinoBankCommand = abstractCasinoBankCommand;
        }

        public void Execute(double value)
        {
            _player.PerformeOperation(_casinoBankCommand, value);
        }
    }
}

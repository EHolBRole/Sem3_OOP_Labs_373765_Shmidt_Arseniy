using Labs_OOP.Casino.GameLogic;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace labs_OOP.Casino
{
    public class BlackJackCasinoAccountant
    {
        private Player<BlackJackHandStatus> _player;
        
        private AbstractCasinoBankCommand<BlackJackHandStatus> _casinoBankCommand;

        public BlackJackCasinoAccountant(Player<BlackJackHandStatus> player, AbstractCasinoBankCommand<BlackJackHandStatus> abstractCasinoBankCommand)
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

using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_OOP.Casino
{
    public class BlackJackCasinoAccountant
    {
        private Player _player;
        
        private AbstractCasinoBankCommand _casinoBankCommand;

        public BlackJackCasinoAccountant(Player player, AbstractCasinoBankCommand abstractCasinoBankCommand)
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

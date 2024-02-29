using Labs_OOP.Casino.GameLogic;
using OOP_Labs.Money.Commands.CasinoBankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_OOP.Casino
{
    public class BlackJackCasinoAccountant<T>
    {
        private Player<T> _player;
        
        private AbstractCasinoBankCommand<T> _casinoBankCommand;

        public BlackJackCasinoAccountant(Player<T> player, AbstractCasinoBankCommand<T> abstractCasinoBankCommand)
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

using Labs_OOP.Casino.GameLogic;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_OOP.Casino
{
    public class BankAccountant<T>
    {
        private Player<T> _player;

        private AbstractBankCommand<T> _abstractBankCommand;

        public BankAccountant(Player<T> player, AbstractBankCommand<T> abstractBankCommand)
        {
            this._player = player;
            this._abstractBankCommand = abstractBankCommand;

        }

        public bool Execute(double value)
        {
            return _player.PerformeOperation(_abstractBankCommand, value);
        }
    }
}

using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_OOP.Casino
{
    public class BankAccountant
    {
        private Player _player; //ReadOnly плюс _

        private AbstractBankCommand _abstractBankCommand;

        public BankAccountant(Player player, AbstractBankCommand abstractBankCommand)
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

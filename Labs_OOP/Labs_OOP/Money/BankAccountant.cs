using Labs_OOP.Casino.GameLogic;
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
        private Player<BlackJackHandStatus> _player;

        private AbstractBankCommand<BlackJackHandStatus> _abstractBankCommand;

        public BankAccountant(Player<BlackJackHandStatus> player, AbstractBankCommand<BlackJackHandStatus> abstractBankCommand)
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

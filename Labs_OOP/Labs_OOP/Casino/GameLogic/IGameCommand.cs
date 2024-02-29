using Labs_OOP.Casino.GameLogic.BlackJack.BlackJackCommands;
using Labs_OOP.Casino.GameLogic.BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic
{
    public interface IGameCommand
    {
        public bool Execute(AbstractGameLogic game);
    }
}

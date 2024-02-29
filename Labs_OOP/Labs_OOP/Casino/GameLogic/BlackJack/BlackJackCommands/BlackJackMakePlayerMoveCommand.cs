using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.BlackJack.BlackJackCommands
{
    public class BlackJackMakePlayerMoveCommand : IGameCommand<BlackJackHandStatus>
    {
        BlackJackUserInputHandler userInputHandler;

        public BlackJackMakePlayerMoveCommand()
        {
            userInputHandler = new BlackJackUserInputHandler();
        }

        public bool Execute(AbstractGameLogic<BlackJackHandStatus> game)
        {
            foreach (var hand in game.Hands)
            {
                var userInput = "More"; // userInputHandler.GetUserInput(). Standart Input for modeling game

                if (userInput == "Incorrect Input!")
                    return false;
                if (userInput == "More" && hand.status != BlackJackHandStatus.Enough)
                    hand.status = BlackJackHandStatus.More;
                else if (userInput == "Enough")
                    hand.status = BlackJackHandStatus.Enough;
                else
                    return false;
            }
            return true;
        }
    }
}

using Labs_OOP.Casino.GameLogic.BlackJack.BlackJackCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.BlackJack
{
    public class BlackJackUserInputHandler
    {
        public virtual string GetUserInput()
        {
            string? userInput = "";

            userInput = Console.ReadLine();

            if (userInput is not null)
                return userInput;
            else
                return "Incorrect input!";
        }
    }
}

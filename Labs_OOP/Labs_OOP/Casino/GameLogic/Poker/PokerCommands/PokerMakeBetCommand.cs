﻿using labs_OOP.Casino;
using OOP_Labs.Money.Commands.BankCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Casino.GameLogic.Poker.PokerCommands
{
    public class PokerMakeBetCommand : IGameCommand<PokerHandStatus>
    {
        public bool Execute(AbstractGameLogic<PokerHandStatus> game, int playerSit)
        {
            try
            {

                int intUserInput = 50; //int.Parse(new UserInputHandler().GetUserInput()); Default input for modelling poker
                foreach (var player in game._players)
                {
                    if (player.playerSeat == playerSit)
                    {
                        new BankAccountant(player, new CheckBalanceCommand())
                    }
                }
                game.Hands[playerSit - 1].bet += intUserInput;
            }
            catch
            {
                Console.WriteLine("Incorrect input!");
                return false;
            }
            return true;
        }
    }
}

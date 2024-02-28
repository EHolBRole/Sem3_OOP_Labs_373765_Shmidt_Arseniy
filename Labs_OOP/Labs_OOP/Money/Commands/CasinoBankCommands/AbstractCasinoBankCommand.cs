﻿using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands.CasinoBankCommands
{
    public abstract class AbstractCasinoBankCommand : ICommand
    {
        public abstract bool Execute(Player player, double value);

    }
}

using labs_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.Commands
{
    public interface ICommand
    {
        public bool Execute(Player player, double value);
    }
}

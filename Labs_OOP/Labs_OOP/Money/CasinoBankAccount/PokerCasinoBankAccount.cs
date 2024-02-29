using OOP_Labs.Money.CasinoBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.CasinoBankAccount
{
    internal class PokerCasinoBankAccount : AbstractCasinoBankAccount
    {
        private const int BASE_CHIPS = 0;

        public PokerCasinoBankAccount()
        {
            chips = BASE_CHIPS;
        }

    }
}

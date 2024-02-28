using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.CasinoBankAccount
{
    public class BlackJackCasinoBankAccount : AbstractCasinoBankAccount
    {
        private const int BASE_CHIPS = 100;
        public BlackJackCasinoBankAccount() 
        {
            chips = BASE_CHIPS;
        }

    }
}

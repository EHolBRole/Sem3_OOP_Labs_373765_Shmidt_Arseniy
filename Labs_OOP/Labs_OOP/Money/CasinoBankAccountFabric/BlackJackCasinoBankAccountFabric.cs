using OOP_Labs.Money.CasinoBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.CasinoBankAccountFabric
{
    public class BlackJackCasinoBankAccountFabric : AbstractCasinoBankAccountFabric
    {
        public override AbstractCasinoBankAccount Create()
        {
            return new BlackJackCasinoBankAccount();
        }
    }
}

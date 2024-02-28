using labs_OOP.Money;
using OOP_Labs.Money.CasinoBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.PlayerFabric
{
    public abstract class AbstractPlayerFactory
    {
        public abstract AbstactBankAccount CreateBankAccount();

        public abstract AbstractCasinoBankAccount CreateCasinoBankAccount();
    }
}

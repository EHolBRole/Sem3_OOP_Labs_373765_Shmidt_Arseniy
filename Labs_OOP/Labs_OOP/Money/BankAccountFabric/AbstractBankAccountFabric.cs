using labs_OOP.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.BankAccountFabric
{
    public abstract class AbstractBankAccountFabric
    {
        public abstract AbstractBankAccount Create();
    }
}

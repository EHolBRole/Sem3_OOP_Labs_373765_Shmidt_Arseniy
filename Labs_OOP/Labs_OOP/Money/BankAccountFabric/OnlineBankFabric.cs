using labs_OOP.Money;
using OOP_Labs.Money.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.BankAccountFabric
{
    public class OnlineBankFabric : AbstractBankAccountFabric
    {
        public override AbstractBankAccount Create()
        {
            return new OnlineBankAccount();
        }
    }
}

using labs_OOP.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.BankAccounts
{
    public class OnlineBankAccount : AbstractBankAccount
    {
        private const double BASE_MONEY = 0;
        public OnlineBankAccount()
        {
            money = BASE_MONEY;
        }
    }
}

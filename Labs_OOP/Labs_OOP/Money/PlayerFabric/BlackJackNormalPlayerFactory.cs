using labs_OOP.Money;
using OOP_Labs.Money.BankAccounts;
using OOP_Labs.Money.CasinoBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs.Money.PlayerFabric
{
    public class BlackJackNormalPlayerFactory : AbstractPlayerFactory
    {
        public override AbstactBankAccount CreateBankAccount()
        {  
            return  new OnlineBankAccount();
        }

        public override AbstractCasinoBankAccount CreateCasinoBankAccount()
        {
            return new BlackJackCasinoBankAccount();
        }
    }
}

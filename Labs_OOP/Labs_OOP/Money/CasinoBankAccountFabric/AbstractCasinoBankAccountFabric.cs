using OOP_Labs.Money.CasinoBankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_OOP.Money.CasinoBankAccountFabric
{
    public abstract class AbstractCasinoBankAccountFabric
    {
        public abstract AbstractCasinoBankAccount Create();
    }
}

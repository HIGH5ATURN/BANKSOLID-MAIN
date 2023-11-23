using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public static class Bank
    {
        public static vector<Customer> CustomerList = new vector<Customer>();

        public static vector<Account> AllAccountList = new vector<Account>();

        public static vector<SavingsAccount> SavingsAccountList = new vector<SavingsAccount>();

        public static vector<CurrentAccount> CurrentAccountList = new vector<CurrentAccount>();

        public static vector<IslamicAccount> IslamicAccountList = new vector<IslamicAccount>();
    }
}

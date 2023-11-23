using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Customer
    {
        
        public string Name { get; set; }
        public int NID { get; set; }

        public string password { get; set; }

        public vector<Account> accounts { get; set; }
        public vector<SavingsAccount> savingsAccounts { get; set; }
        
        public vector<CurrentAccount> currentAccounts { get; set; }

        public vector<IslamicAccount> islamicAccounts { get; set; }
        public Customer(string name, int nID, string password)
        {
            Name = name;
            NID = nID;
            this.password = password;
            accounts= new vector<Account>();
            savingsAccounts= new vector<SavingsAccount>();
            currentAccounts= new vector<CurrentAccount>();
            islamicAccounts= new vector<IslamicAccount>();
        }
        public void ChangePassword(string password)
        {
            this.password = password;
        }

    }
}

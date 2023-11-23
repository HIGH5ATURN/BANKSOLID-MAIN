using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public  class Account
    {
        public int AccountNumber { get; set; }

        public int AccountHolderNID { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }
        
        public Date OpeningDate { get; set; }

        public Account(int accountNumber, int accountHolderNID, string accountHolderName, double balance, Date openingDate)
        {
            AccountNumber = accountNumber;
            AccountHolderNID = accountHolderNID;
            AccountHolderName = accountHolderName;
            Balance = balance;
            OpeningDate = openingDate;
        }

        public virtual String GetAccountType()
        {
            return "";
        }
    }
}

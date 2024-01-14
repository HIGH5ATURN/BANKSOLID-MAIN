using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    //testing navid1111
    public  class Account
    {
        public int AccountNumber { get; set; }

        public int AccountHolderNID { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }
        
        public Date OpeningDate { get; set; }

        public bool isFreezed { get; set; }
        public Account(int accountNumber, int accountHolderNID, string accountHolderName, double balance, Date openingDate,bool isFreezed)
        {
            AccountNumber = accountNumber;
            AccountHolderNID = accountHolderNID;
            AccountHolderName = accountHolderName;
            Balance = balance;
            OpeningDate = openingDate;
            this.isFreezed = isFreezed;
        }
        public Account( int accountHolderNID, string accountHolderName, double balance, Date openingDate)
        {
    
            AccountHolderNID = accountHolderNID;
            AccountHolderName = accountHolderName;
            Balance = balance;
            OpeningDate = openingDate;
            isFreezed = false;
        }

        public virtual String GetAccountType()
        {
            return "";
        }

        public void ShowAccountInfo()
        {
            Console.WriteLine("Account Number: "+AccountNumber);
            Console.WriteLine("Account Holder Name: " + AccountHolderName);
            Console.WriteLine("Account Holder NID: "+AccountHolderNID);
            Console.WriteLine("Account Balance: "+Balance);
            Console.WriteLine("Opening Date(yyyy-mm-dd): "+OpeningDate.Year+"-"+OpeningDate.Month+"-"+OpeningDate.Day);
            Console.WriteLine("Account Status: "+(isFreezed?"Freezed":"Active"));

        }
    }
}

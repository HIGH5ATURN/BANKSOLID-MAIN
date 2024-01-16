using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class WithdrawHistory: ItransactionHistory
    {
        public int UID { get; set; }
        public int AccountNumber { get; set; }

        public int AccountHolderNID { get; set; }

        public double WithdrawnAmount { get; set; }

        public Date WithdrawDate { get; set; }

        public WithdrawHistory(int uID, int accountNumber, int accountHolderNID, double WithdrawnAmount, Date WithdrawDate)
        {
            UID = uID;
            AccountNumber = accountNumber;
            AccountHolderNID = accountHolderNID;
            this.WithdrawnAmount = WithdrawnAmount;
            this.WithdrawDate = WithdrawDate;
        }

        public void ShowAllInfo()
        {
            Console.WriteLine("UID: " + UID);
            Console.WriteLine("Transaction Type: Deposit");
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Holder NID: " + AccountHolderNID);
            Console.WriteLine("Deposited Amount: " + WithdrawnAmount);
            Console.WriteLine("Deposit Date(yyyy-mm-dd): " + WithdrawDate.Year + "-" + WithdrawDate.Month + "-" + WithdrawDate.Day);
        }
    }
}

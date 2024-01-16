using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class DepositHistory:ItransactionHistory
    {
        public int UID { get; set; }
        public int AccountNumber { get; set; }

        public int AccountHolderNID { get; set; }

        public double DepositAmount { get; set; }

        public Date DepositDate { get; set; }

        public DepositHistory(int uID, int accountNumber, int accountHolderNID, double depositAmount, Date depositDate)
        {
            UID = uID;
            AccountNumber = accountNumber;
            AccountHolderNID = accountHolderNID;
            DepositAmount = depositAmount;
            DepositDate = depositDate;
        }

        public void ShowAllInfo()
        {
            Console.WriteLine("UID: "+UID);
            Console.WriteLine("Transaction Type: Deposit");
            Console.WriteLine("Account Number: "+AccountNumber);
            Console.WriteLine("Account Holder NID: "+AccountHolderNID);
            Console.WriteLine("Deposited Amount: "+DepositAmount);
            Console.WriteLine("Deposit Date(yyyy-mm-dd): "+DepositDate.Year+"-"+DepositDate.Month+"-"+DepositDate.Day);
        }
    }
}

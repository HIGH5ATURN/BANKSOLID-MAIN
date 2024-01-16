using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class TransferHistory:ItransactionHistory
    {
        public int UID { get; set; }

        public int giverAccountNumber { get; set; }

        public int recieverAccountNumber { get;  set; }

        public int giverNID { get; set; }

        public double transferAmount { get; set; }

        public Date transferDate { get; set; }

        public TransferHistory(int uID, int giverAccountNumber, int recieverAccountNumber, int giverNID, double transferAmount, Date transferDate)
        {
            UID = uID;
            this.giverAccountNumber = giverAccountNumber;
            this.recieverAccountNumber = recieverAccountNumber;
            this.giverNID = giverNID;
            this.transferAmount = transferAmount;
            this.transferDate = transferDate;
        }


        public void ShowAllInfo()
        {
            Console.WriteLine("UID: " + UID);
            Console.WriteLine("Transaction Type: Deposit");
            Console.WriteLine("Account Number: " + giverAccountNumber);
            Console.WriteLine("Account Holder NID: " + giverNID);
            Console.WriteLine("Reciever Account Number: "+recieverAccountNumber);
            Console.WriteLine("Transferred Amount: " + transferAmount);
            Console.WriteLine("Deposit Date(yyyy-mm-dd): " + transferDate.Year + "-" + transferDate.Month + "-" + transferDate.Day);
        }

    }
}

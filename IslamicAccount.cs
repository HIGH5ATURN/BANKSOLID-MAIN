using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    internal class IslamicAccount : Account,Itransaction
    {
        public int withdrawalLimit { get; set; } = 5;
        private int withdrawalCount = 0;
        public Date LastWithdrawDate;


        public IslamicAccount(int AccountNumber, String AccountHolderName, Double Balance, Date OpeningDate) { 
            this.AccountNumber = AccountNumber;
            this.AccountHolderName = AccountHolderName;
            this.Balance = Balance;
            this.OpeningDate = OpeningDate;
        }
         public void Deposit(double amount)
        {
            if (amount >= 0)
            {
                Balance += amount;

            }
            else
            {
                throw new TransactionException("Given Amount Can't be less than zero bdt");
            }
        }

        public void Transfer(Account account, double Amount)
        {
            if (Balance - Amount >= 1000)
            {
                Balance -= Amount;
                account.Balance += Amount;
            }
            else
            {
                throw new TransactionException("Insufficient Balance!");
            }
        }

        public double Withdraw(double amount, Date withdraw_date)
        {
            if(LastWithdrawDate.DifferenceInDays(withdraw_date)>30)
            {
                withdrawalCount = 0;
            }
            //set a business logic that will check if the withdrawalCount is equal to the withdrawal limit within the month
            //after every month the withdrawal Count will be set to zero

            if (LastWithdrawDate.DifferenceInDays(withdraw_date) <= 30 && withdrawalCount >= withdrawalLimit)
            {
                throw new TransactionException("In Savings Account you can withdraw only 5 times a month!");
            }
            else
            {
                if (Balance - amount >= 1000)
                {
                    Balance -= amount;
                    withdrawalCount++;
                    LastWithdrawDate=withdraw_date;
                }
                else
                {
                    throw new TransactionException("Insufficient Balance!");
                }
            }
            return Balance;
        }

    }
}
  

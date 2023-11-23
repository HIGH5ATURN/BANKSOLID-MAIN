using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BANKSOLID
{
    public class CurrentAccount:Account,Itransaction,Iinterest
    {

        public double InterestRate { get; set; } = 0.02;

        public Date LastInterestDate { get; set; }
        public CurrentAccount(int AccountNumber,int AccountHolderNID, String AccountHolderName, Double Balance,Date OpeningDate): base(AccountNumber, AccountHolderNID, AccountHolderName, Balance, OpeningDate)
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolderNID = AccountHolderNID;
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
            if (Balance - amount >= 1000)
            {
                Balance -= amount;

            }
            else
            {
                throw new TransactionException("Insufficient Balance!");
            }

            return Balance;
        }


        //invoke this method when the program starts
        public void AddInterest()
        {
            Date currentDate = Date.Now;

            if (currentDate.Month > LastInterestDate.Month || currentDate.Year > LastInterestDate.Year)
            {
                int monthsPassed = currentDate.MonthsBetween(LastInterestDate);

                for (int i = 0; i < monthsPassed; i++)
                {
                    Balance += Balance * (InterestRate);
                }
                LastInterestDate = currentDate;
                
            }

        }

        public override String GetAccountType()
        {
           return " Current ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class SavingsAccount : Account, Itransaction,Iinterest
    {
        public int withdrawalLimit { get; set; } = 5;
        public double InterestRate { get; set; } = 0.1;
        public Date LastInterestDate { get; set; }

        private int withdrawalCount = 0;
        public Date LastWithdrawDate { get; set; }


        //first time
        //public SavingsAccount(int AccountNumber, int AccountHolderNID, String AccountHolderName, Double Balance, Date OpeningDate)  : base(AccountNumber, AccountHolderNID, AccountHolderName, Balance, OpeningDate)
        //{
        //    this.AccountNumber = AccountNumber;
        //    this.AccountHolderNID = AccountHolderNID;
        //    this.AccountHolderName = AccountHolderName;
        //    this.Balance = Balance;
        //    this.OpeningDate = OpeningDate;
        //    LastWithdrawDate = OpeningDate;
        //    LastInterestDate = OpeningDate;
        //}

        public SavingsAccount( int AccountHolderNID, String AccountHolderName, Double Balance, Date OpeningDate) : base( AccountHolderNID, AccountHolderName, Balance, OpeningDate)
        {
           
            this.AccountHolderNID = AccountHolderNID;
            this.AccountHolderName = AccountHolderName;
            this.Balance = Balance;
            this.OpeningDate = OpeningDate;
            LastWithdrawDate = OpeningDate;
            LastInterestDate = OpeningDate;
        }

        //fetching from database
        public SavingsAccount(int AccountNumber, int AccountHolderNID, String AccountHolderName, Double Balance, Date OpeningDate,Date LastInterestDate,Date LastWithdrawDate,bool isFreezed) : base(AccountNumber, AccountHolderNID, AccountHolderName, Balance, OpeningDate, isFreezed)
        {
            
            this.AccountHolderNID = AccountHolderNID;
            this.AccountHolderName = AccountHolderName;
            this.Balance = Balance;
            this.OpeningDate = OpeningDate;
            this.LastInterestDate = LastInterestDate;
            this.LastWithdrawDate = LastWithdrawDate;
            this.isFreezed=isFreezed;
        }


        public void Deposit(double amount)
        {
            if(isFreezed)
            {
                Console.WriteLine("The Account is freezed, Can't do any transactions!");
                return;
            }
            if (amount >= 0)
            {
                Balance += amount;
                Console.WriteLine($"Successfully deposited: {amount}; New Balance: {Balance};");
            }
            else
            {
                throw new TransactionException("Given Amount Can't be less than zero bdt");
            }
        }

        public void setWithdrawalCount(int cnt)
        {
            withdrawalCount = cnt;
        }

        public int getWithdrawCount()
        {
            return withdrawalCount;
        }
        public void Transfer(Account account, double Amount)
        {
            if (isFreezed)
            {
                Console.WriteLine("The Account is freezed, Can't do any transactions!");
                return;
            }
            if (Balance - Amount >= 1000 && Amount>0)
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
            if (isFreezed)
            {
                Console.WriteLine("The Account is freezed, Can't do any transactions!");
                return -1;
            }

            if (LastWithdrawDate.DifferenceInDays(withdraw_date)>30)
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
            return " Savings ";
        }
    }
}

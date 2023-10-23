using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BANKSOLID
{
    public class CurrentAccount:Account,Itransaction
    {
        public CurrentAccount(int AccountNumber, String AccountHolderName, Double Balance)
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolderName = AccountHolderName;
            this.Balance = Balance;
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

        public double Withdraw(double amount)
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
    }
}

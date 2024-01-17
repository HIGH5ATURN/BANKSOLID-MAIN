using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class CustomerAccountHandler
    {

        Database db = new Database();
 

        public void Deposit(int accountNumber, Customer customer, double amount)
        {
            try
            {
                Itransaction account = FindAccountForCustomer(customer, accountNumber);

                if (account == null)
                {
                    throw new TransactionException("Incorrect Account Number!");
                }

                
                account.Deposit(amount);

                if (account is SavingsAccount)
                {
                    SavingsAccount s_ac = (SavingsAccount)account;

                    db.TransactionUpdateOnSavingsTable(s_ac);
                }
                else if (account is CurrentAccount)
                {
                    CurrentAccount currentAccount = (CurrentAccount)account;

                    db.TransactionUpdateOnCurrentTable(currentAccount);
                }
                else if (account is IslamicAccount)
                {
                    IslamicAccount islamicAccount = (IslamicAccount)account;

                    db.TransactionUpdateOnIslamicTable(islamicAccount);
                }
                

                db.AddDepositHistory(customer,accountNumber,amount,Date.Now);
                db.LoadDepositHistoryToBankList();
                db.LoadAccountToList();
                db.LoadSavingsAccountToList();
                db.LoadCurrentAccountToList();
                db.LoadIslamicAccountToList();
                Bank.LoadAccountListForRespectiveCustomer(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : "+ex.Message);
            }

        }

     

        public void Withdraw(int accountNumber, Customer customer, double amount)
        {
            try
            {
                Itransaction account = FindAccountForCustomer(customer, accountNumber);

                if (account == null)
                {
                    throw new TransactionException("Incorrect Account Number!");
                }


                account.Withdraw(amount,Date.Now);

                if (account is SavingsAccount)
                {
                    SavingsAccount s_ac = (SavingsAccount)account;

                    db.TransactionUpdateOnSavingsTable(s_ac);
                }
                else if (account is CurrentAccount)
                {
                    CurrentAccount currentAccount = (CurrentAccount)account;

                    db.TransactionUpdateOnCurrentTable(currentAccount);
                }
                else if (account is IslamicAccount)
                {
                    IslamicAccount islamicAccount = (IslamicAccount)account;

                    db.TransactionUpdateOnIslamicTable(islamicAccount);
                }


                db.AddWithdrawHistory(customer, accountNumber, amount, Date.Now);
                db.LoadWithdrawHistoryToBankList();
                db.LoadAccountToList();
                db.LoadSavingsAccountToList();
                db.LoadCurrentAccountToList();
                db.LoadIslamicAccountToList();
                Bank.LoadAccountListForRespectiveCustomer(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
       


       
       
      
        

        public Account FindAccount(int accountNumber)
        {
            for (int i = 0; i < Bank.SavingsAccountList.Count; i++)
            {
                if (accountNumber == Bank.SavingsAccountList[i].AccountNumber)
                {
                    return Bank.SavingsAccountList[i];
                }
            }
            for (int i = 0; i < Bank.CurrentAccountList.Count; i++)
            {
                if (accountNumber == Bank.CurrentAccountList[i].AccountNumber)
                {
                    return Bank.CurrentAccountList[i];
                }
            }
            for (int i = 0; i < Bank.IslamicAccountList.Count; i++)
            {
                if (accountNumber == Bank.IslamicAccountList[i].AccountNumber)
                {
                    return Bank.IslamicAccountList[i]; 
                }
            }

            return null;
        }

        public Itransaction FindAccountForCustomer(Customer customer, int accountNumber)
        {
            for(int i=0;i<customer.savingsAccounts.Count;i++) {
                if (accountNumber == customer.savingsAccounts[i].AccountNumber)
                {
                    return customer.savingsAccounts[i];
                }
            }

            for (int i = 0; i < customer.currentAccounts.Count; i++)
            {
                if (accountNumber == customer.currentAccounts[i].AccountNumber)
                {
                    return customer.currentAccounts[i];
                }
            }
            for (int i = 0; i < customer.islamicAccounts.Count; i++)
            {
                if (accountNumber == customer.islamicAccounts[i].AccountNumber)
                {
                    return customer.islamicAccounts[i];
                }
            }

            return null;
        }
        public void Transfer(int accountNumber, Customer customer, double amount, int recipient_ac_no)
        {
            try
            {
                Account reciver_ac = FindAccount(recipient_ac_no);

                Itransaction giver = FindAccountForCustomer(customer, accountNumber);


                if (reciver_ac == null || giver==null)
                {
                    throw new TransactionException("Invalid account number!");
                }

                giver.Transfer(reciver_ac, amount);

                //giver end // NOTE : here the databaase can also be brought under refactoring and be applied OCP
                if(giver is SavingsAccount)
                {
                    SavingsAccount savings  = (SavingsAccount)giver;

                    db.TransactionUpdateOnSavingsTable(savings);
                }
                else if(giver is CurrentAccount)
                {
                    CurrentAccount current_ac= (CurrentAccount)giver;
                    db.TransactionUpdateOnCurrentTable(current_ac);

                }
                else if(giver is IslamicAccount)
                {
                    IslamicAccount islamicAccount = (IslamicAccount)giver;

                    db.TransactionUpdateOnIslamicTable(islamicAccount);
                }

                //reciever end
                if (reciver_ac is SavingsAccount)
                {
                    SavingsAccount savings = (SavingsAccount)reciver_ac;

                    db.TransactionUpdateOnSavingsTable(savings);
                }
                else if (reciver_ac is CurrentAccount)
                {
                    CurrentAccount current_ac = (CurrentAccount)reciver_ac;
                    db.TransactionUpdateOnCurrentTable(current_ac);

                }
                else if (reciver_ac is IslamicAccount)
                {
                    IslamicAccount islamicAccount = (IslamicAccount)reciver_ac;

                    db.TransactionUpdateOnIslamicTable(islamicAccount);
                }
                
                //now write the transfer history to database here !!!
                db.AddTransferHistory(accountNumber,recipient_ac_no,customer.NID,amount,Date.Now);
                db.LoadTransferHistoryToBankList();

                //just to be safe
                db.LoadAccountToList();
                db.LoadSavingsAccountToList();
                db.LoadCurrentAccountToList();
                db.LoadIslamicAccountToList();
                Bank.LoadAccountListForRespectiveCustomer(customer);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
        public void ShowAccountData(Customer customer)
        {

            Console.WriteLine("Your Accounts are:");

            for (int i = 0; i < customer.savingsAccounts.Count; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Account Number: " + customer.savingsAccounts[i].AccountNumber);
                Console.WriteLine("Account Balance: " + customer.savingsAccounts[i].Balance);
                Console.WriteLine("Account Type: " + customer.savingsAccounts[i].GetAccountType());
                Console.WriteLine("Account status: " + (customer.savingsAccounts[i].isFreezed?"Freezed":"Un-Freezed"));
                Console.WriteLine("-----------------------------------------");
            }

            Console.WriteLine();
            for (int i = 0; i < customer.currentAccounts.Count; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Account Number: " + customer.currentAccounts[i].AccountNumber);
                Console.WriteLine("Account Balance: " + customer.currentAccounts[i].Balance);
                Console.WriteLine("Account Type: " + customer.currentAccounts[i].GetAccountType());
                Console.WriteLine("Account status: " + (customer.currentAccounts[i].isFreezed ? "Freezed" : "Un-Freezed"));
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine();
            for (int i = 0; i < customer.islamicAccounts.Count; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Account Number: " + customer.islamicAccounts[i].AccountNumber);
                Console.WriteLine("Account Balance: " + customer.islamicAccounts[i].Balance);
                Console.WriteLine("Account Type: " + customer.islamicAccounts[i].GetAccountType());
                Console.WriteLine("Account status: " + (customer.islamicAccounts[i].isFreezed ? "Freezed" : "Un-Freezed"));
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine();
        }
    }
}

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

        public bool DepositOnSavings(int accountNumber, Customer customer, double amount)
        {
            for (int i = 0; i < customer.savingsAccounts.Count; i++)
            {
                if (accountNumber == customer.savingsAccounts[i].AccountNumber)
                {

                   


                    customer.savingsAccounts[i].Deposit(amount);

                    db.TransactionUpdateOnSavingsTable(customer.savingsAccounts[i]);                  
                    //just to be safe
                    db.LoadAccountToList();
                    db.LoadSavingsAccountToList();
                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    return true;


                }
            }

            return false;
        }




        public bool DepositOnCurrentAccount(int accountNumber,Customer customer,double amount)
        {

            for(int i=0;i<customer.currentAccounts.Count;i++)
            {

                if (accountNumber == customer.currentAccounts[i].AccountNumber)
                {
                    customer.currentAccounts[i].Deposit(amount);

                    db.TransactionUpdateOnCurrentTable(customer.currentAccounts[i]);

                    
                    db.LoadAccountToList();

                    db.LoadSavingsAccountToList();

                    Bank.LoadAccountListForRespectiveCustomer(customer);

                    return true;
                }

            }


            return false;

        }

        public bool DepositOnIslamicAccount(int accountNumber, Customer customer, double amount)
        {
            for (int i = 0; i < customer.islamicAccounts.Count; i++)
            {
                if (accountNumber == customer.islamicAccounts[i].AccountNumber)
                {


                    
                    customer.islamicAccounts[i].Deposit(amount);

                   //db.TransactionUpdateOnCurrentTable(customer.islamicAccounts[i]);
                   //islamic account er db ekhono hoye nae


                    db.LoadAccountToList();

                    db.LoadSavingsAccountToList();

                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    return true;

                }
            }

            return false;
        }


        public bool WithdrawOnSavingsAccount(int accountNumber, Customer customer, double amount,Date withdrawDate)
        {
            for (int i = 0; i < customer.savingsAccounts.Count; i++)
            {
                if (accountNumber == customer.savingsAccounts[i].AccountNumber)
                {

                  
                    customer.savingsAccounts[i].Withdraw(amount, withdrawDate);

                    db.TransactionUpdateOnSavingsTable(customer.savingsAccounts[i]);

                    //just to be safe
                    db.LoadAccountToList();
                    db.LoadSavingsAccountToList();
                    Bank.LoadAccountListForRespectiveCustomer(customer);

                    return true;
                }
            }

            return false;
        }
        


        public bool WithDrawOnCurrentAccount(int accountNumber, Customer customer, double amount,Date withdrawDate)
        {

            for(int i=0;i<customer.currentAccounts.Count;i++)
            {

                if (accountNumber == customer.currentAccounts[i].AccountNumber)
                {


                    customer.currentAccounts[i].Withdraw(amount,withdrawDate);


                    db.TransactionUpdateOnCurrentTable(customer.currentAccounts[i]);


                    db.LoadAccountToList();

                    db.LoadCurrentAccountToList();

                    Bank.LoadAccountListForRespectiveCustomer(customer);


                    return true;
                }

            }


            return false;

        }
        public bool WithdrawOnIslamicAccount(int accountNumber, Customer customer, double amount,Date withdrawDate)
        {
            for (int i = 0; i < customer.islamicAccounts.Count; i++)
            {
                if (accountNumber == customer.islamicAccounts[i].AccountNumber)
                {


                    customer.islamicAccounts[i].Withdraw(amount, withdrawDate);
                    db.TransactionUpdateOnIslamicTable(customer.islamicAccounts[i]);

                    db.LoadAccountToList();
                    db.LoadIslamicAccountToList();
                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    return true;
                }
            }

            return false;
        }

        public bool Transfer_CurrentToCurrent(int accountNumber, Customer customer, double amount, int recipient_ac_no)
        {

            CurrentAccount receiver = null;

            bool found = false;

            for (int i = 0; i < Bank.CurrentAccountList.Count; i++)
            {

                if (recipient_ac_no == Bank.CurrentAccountList[i].AccountNumber)
                {
                    receiver = Bank.CurrentAccountList[i];

                    found = true;

                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            for (int i = 0; i < customer.currentAccounts.Count; i++)
            {
                if (accountNumber == customer.currentAccounts[i].AccountNumber)
                {


                    customer.currentAccounts[i].Transfer(receiver, amount);


                    db.TransactionUpdateOnCurrentTable(customer.currentAccounts[i]);

                    db.TransactionUpdateOnCurrentTable(receiver);



                    db.LoadAccountToList();

                    db.LoadCurrentAccountToList();

                    Bank.LoadAccountListForRespectiveCustomer(customer);



                    return true;
                }

            }


            return false;
        }

        
        public bool Transfer_IslamicToIslamic(int accountNumber, Customer customer, double amount, int recipient_ac_no)
        {
            return false;

        }
        public bool Transfer_SavingsToSavings(int accountNumber, Customer customer, double amount,int recipient_ac_no)
        {
            SavingsAccount reciever=null;

            bool found =false;
            for(int i=0;i<Bank.SavingsAccountList.Count;i++)
            {
                if(recipient_ac_no == Bank.SavingsAccountList[i].AccountNumber)
                {
                    reciever = Bank.SavingsAccountList[i];
                    found = true; break;
                }
            }
            if(!found)
            {
                return false;
            }
            for (int i = 0; i < customer.savingsAccounts.Count; i++)
            {
                if (accountNumber == customer.savingsAccounts[i].AccountNumber)
                {


                    customer.savingsAccounts[i].Transfer(reciever, amount);

                    db.TransactionUpdateOnSavingsTable(customer.savingsAccounts[i]);
                    db.TransactionUpdateOnSavingsTable(reciever);
                    //just to be safe
                    db.LoadAccountToList();
                    db.LoadSavingsAccountToList();
                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    
                   

                    return true;
                }
            }


            return false;
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
                    throw new TransactionException("Invalid recipient account number!");
                }

                giver.Transfer(reciver_ac, amount);

                //giver end
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

                //just to be safe
                db.LoadAccountToList();
                db.LoadSavingsAccountToList();
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
                Console.WriteLine("-----------------------------------------");
            }

            Console.WriteLine();
            for (int i = 0; i < customer.currentAccounts.Count; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Account Number: " + customer.currentAccounts[i].AccountNumber);
                Console.WriteLine("Account Balance: " + customer.currentAccounts[i].Balance);
                Console.WriteLine("Account Type: " + customer.currentAccounts[i].GetAccountType());
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine();
            for (int i = 0; i < customer.islamicAccounts.Count; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Account Number: " + customer.islamicAccounts[i].AccountNumber);
                Console.WriteLine("Account Balance: " + customer.islamicAccounts[i].Balance);
                Console.WriteLine("Account Type: " + customer.islamicAccounts[i].GetAccountType());
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine();
        }
    }
}

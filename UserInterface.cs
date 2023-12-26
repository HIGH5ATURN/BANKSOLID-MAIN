﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class UserInterface
    {
       
      
        public void CreatingCustomer()
        {
            try
            {
                Customer customer;
                Console.WriteLine("Please give your information to become a Customer in BANKSOLID!\n");

                Console.Write("Set Username: ");
                string username = Console.ReadLine();
                Console.Write("Set NID: ");
                int NID = stringUtils.ConvertToInt(Console.ReadLine());
                Console.Write("Set Password: ");
                string password = Console.ReadLine();

                customer = new Customer(username, NID, password);

                Database db = new Database();

                db.SaveCustomerToDb(customer);
                db.LoadCustomerToBankList();
                Console.WriteLine("created customer successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CustomerPanel()
        {
            try
            {
                Console.WriteLine("Please Log In!");

                Console.Write("Enter NID: ");
                int nid = stringUtils.ConvertToInt(Console.ReadLine());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                bool loggedIn = false;
                Customer customer = null;

                for (int i = 0; i < Bank.CustomerList.Count; i++)
                {
                    if (nid == Bank.CustomerList[i].NID && password == Bank.CustomerList[i].password)
                    {
                        customer = Bank.CustomerList[i];
                        loggedIn = true; break;
                    }
                }


                if (loggedIn)
                {
                    Console.WriteLine("Logged In successfully!");
                    Console.Clear();
                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    CustomerPersonalUI(customer);
                }
                else
                {
                    Console.WriteLine("Incorrect username or password!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public bool ISUniqueAcNo(int ac_no)
        {

            for (int i = 0; i < Bank.AllAccountList.Count; i++)
            {
                if (ac_no == Bank.AllAccountList[i].AccountNumber)
                {
                    Console.WriteLine("This number is Already taken, Please Give Another one");

                    return false;
                }
            }

            return true;
        }


        public void CustomerAccountCreationUI(Customer customer)
        {
            try
            {
                
                    Console.WriteLine("You Haven't Opened an Account Yet!");
                    Console.WriteLine("If You want to open an Account please :");
                    Console.WriteLine("Press (1) to open Savings Account!");
                    Console.WriteLine("Press (2) to open Current Account!");
                    Console.WriteLine("Press (3) to open Islamic Account!");
                    Console.WriteLine("Press (4) to exit!");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {

                        CreateSavingsAccount(customer);

                    }
                    else if (key == 2)
                    {

                    }
                    else if (key == 3)
                    {

                    }
                    else if (key == 4)
                    {
                        Console.Clear();
                        return;
                    }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

        public void CustomerTransactionUI(Customer customer)
        {

            while (true)
            {
                try {

                    
                    
                    ShowAccountData(customer);
                    Console.WriteLine("Press (1) to deposit money in your Bank Account!");
                    Console.WriteLine("Press (2) to withdraw money from your Bank Account!");
                    Console.WriteLine("Press (3) to transfer money to another Bank Account!");
                    Console.WriteLine("Press (4) to return!");
                    int key = 0;
                    key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 4)
                    {
                        Console.Clear();
                        break;
                    }
                    bool updated = false;

                    Console.Write("Give Account Number: ");

                    int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)//deposit money
                    {


                        Console.Write("Give deposit Amount: ");


                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());


                        for (int i = 0; i < customer.savingsAccounts.Count; i++)
                        {
                            if (ac_no == customer.savingsAccounts[i].AccountNumber)
                            {

                                updated = true;
                                Database db = new Database();


                                customer.savingsAccounts[i].Deposit(amount);

                                db.TransactionUpdateOnSavingsTable(customer.savingsAccounts[i]);

                                db.LoadAccountToList();
                                db.LoadSavingsAccountToList();
                                Bank.LoadAccountListForRespectiveCustomer(customer);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            }
                        }

                        for (int i = 0; i < customer.currentAccounts.Count; i++)
                        {
                            if (ac_no == customer.currentAccounts[i].AccountNumber)
                            {

                            }
                        }


                        for (int i = 0; i < customer.islamicAccounts.Count; i++)
                        {
                            if (ac_no == customer.islamicAccounts[i].AccountNumber)
                            {

                            }
                        }

                        if (!updated)
                        {
                            Console.WriteLine("Incorrect Account Number! Please try Again!");
                        }
                    }
                    else if (key == 2)//withdraw
                    {
                        Console.Write("Give withdraw Amount: ");

                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Give withdraw Date (yyyy-mm-dd): ");

                        Date date = stringUtils.ConvertToDate(Console.ReadLine());



                        for (int i = 0; i < customer.savingsAccounts.Count; i++)
                        {
                            if (ac_no == customer.savingsAccounts[i].AccountNumber)
                            {

                                updated = true;
                                Database db = new Database();

                                customer.savingsAccounts[i].Withdraw(amount, date);

                                db.TransactionUpdateOnSavingsTable(customer.savingsAccounts[i]);

                                db.LoadAccountToList();
                                db.LoadSavingsAccountToList();
                                Bank.LoadAccountListForRespectiveCustomer(customer);
                                Console.WriteLine("Press any key to continue...");
                                
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }

                        for (int i = 0; i < customer.currentAccounts.Count; i++)
                        {
                            if (ac_no == customer.currentAccounts[i].AccountNumber)
                            {

                            }
                        }


                        for (int i = 0; i < customer.islamicAccounts.Count; i++)
                        {
                            if (ac_no == customer.islamicAccounts[i].AccountNumber)
                            {

                            }
                        }

                        if (!updated)
                        {
                            Console.WriteLine("Incorrect Account Number! Please try Again!");
                        }
                    }
                    else if (key == 3)//transfer to another account
                    {
                        Console.Write("Give the recipient account number: ");

                        int recipient_AcNo = stringUtils.ConvertToInt(Console.ReadLine());
                        Console.Write("Give transfer Amount: ");


                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());


                        for (int i = 0; i < customer.savingsAccounts.Count; i++)
                        {
                            if (ac_no == customer.savingsAccounts[i].AccountNumber)
                            {

                                updated = true;
                                Database db = new Database();
                                //now do things to transfer the account from this, to recipient

                                db.LoadAccountToList();
                                db.LoadSavingsAccountToList();
                                Bank.LoadAccountListForRespectiveCustomer(customer);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;

                            }
                        }

                        for (int i = 0; i < customer.currentAccounts.Count; i++)
                        {
                            if (ac_no == customer.currentAccounts[i].AccountNumber)
                            {

                            }
                        }


                        for (int i = 0; i < customer.islamicAccounts.Count; i++)
                        {
                            if (ac_no == customer.islamicAccounts[i].AccountNumber)
                            {

                            }
                        }

                        if (!updated)
                        {
                            Console.WriteLine("Incorrect Account Number! Please try Again!");
                        }
                    }
                    else if (key == 4)
                    {
                        Console.Clear();
                        break;

                    }
                    

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }

        
        public void CustomerPersonalUI(Customer customer)
        {
            try
            {
                while (true)
                {
                    Console.Clear ();
                    Console.WriteLine("Press (1) for Account Creation!");
                    Console.WriteLine("Press (2) to check your accounts and do transactions!");
                    Console.WriteLine("Press (3) to return!");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());
                    if (key == 1)
                    {
                        CustomerAccountCreationUI(customer);
                    }
                    else if (key == 2)
                    {
                        if(customer.accounts.Count != 0)
                        {
                            CustomerTransactionUI(customer);
                        }
                        else
                        {
                            Console.WriteLine("You dont have any accounts!");
                        }
                        
                        
                    }
                    else if(key==3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection command!");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public void CreateSavingsAccount(Customer customer)
        {
            Console.WriteLine("Please Fill out the Following Information:");

            Console.WriteLine("Please Enter your desired Account Number:");

            int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            while (!ISUniqueAcNo(ac_no))
            {

                ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            }
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            SavingsAccount savingsAc = new SavingsAccount(ac_no, customer.NID, customer.Name, Balance, Date.Now);

            customer.savingsAccounts.Add(savingsAc);
            customer.accounts.Add(savingsAc);
            //NOW ADD THIS TO ACCOUNT TABLE AND SAVINGS ACCOUNT TABLE
            Database db = new Database();

            db.SaveAccountToDb(savingsAc);

            db.SaveSavingsAccounttoDb(savingsAc);

            db.LoadAccountToList();
            db.LoadSavingsAccountToList();
            Bank.LoadAccountListForRespectiveCustomer(customer);
            
        }


        public void AdminPanel()
        {
            Console.WriteLine("Under Construction!");
        }

        public void EnviromentSetup()
        {
            Database database = new Database();

            database.LoadCustomerToBankList();
            database.LoadAccountToList();
            database.LoadSavingsAccountToList();

        }
    }
}

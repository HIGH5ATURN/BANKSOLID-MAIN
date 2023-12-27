using System;
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
                    
                    Console.Clear();
                    Console.WriteLine("Logged In successfully!");
                    Console.WriteLine();
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


     


        public void CustomerAccountCreationUI(Customer customer)
        {
            try
            {
                    CustomerAccountCreator customerAccountCreator = new CustomerAccountCreator();
                
                    Console.WriteLine("You Haven't Opened an Account Yet!");
                    Console.WriteLine("If You want to open an Account please :");
                    Console.WriteLine("Press (1) to open Savings Account!");
                    Console.WriteLine("Press (2) to open Current Account!");
                    Console.WriteLine("Press (3) to open Islamic Account!");
                    Console.WriteLine("Press (4) to exit!");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {

                       customerAccountCreator.CreateSavingsAccount(customer);

                    }
                    else if (key == 2)
                    {
                        //create current account
                    }
                    else if (key == 3)
                    {
                        //create islamic account
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

                    CustomerAccountHandler customerAccountHandler = new CustomerAccountHandler();

                    customerAccountHandler.ShowAccountData(customer);
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

                        updated = false;
                        Console.Write("Give deposit Amount: ");


                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());



                        updated = customerAccountHandler.DepositOnSavings(ac_no, customer, amount);

                        if (!updated)
                        {
                            updated = customerAccountHandler.DepositOnCurrentAccount(ac_no, customer, amount);
                        }

                        if (!updated)
                        {
                            updated = customerAccountHandler.DepositOnIslamicAccount(ac_no, customer, amount);
                        }

                        if (!updated)
                        {
                            Console.WriteLine("Incorrect Account Number! Please try Again!");
                        }
                    }
                    else if (key == 2)//withdraw
                    {
                        updated = false;
                        //taking inputs
                        Console.Write("Give withdraw Amount: ");

                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Give withdraw Date (yyyy-mm-dd): ");

                        Date date = stringUtils.ConvertToDate(Console.ReadLine());


                        updated=customerAccountHandler.WithdrawOnSavingsAccount(ac_no,customer,amount,date);

                        if (!updated)
                        {
                            updated = customerAccountHandler.WithdrawOnCurrentAccount(ac_no, customer, amount);
                        }

                        if (!updated)
                        {
                            updated = customerAccountHandler.WithdrawOnIslamicAccount(ac_no, customer, amount);
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

                        //Look at all these methods they are same AF. we can create a Itransfer interface that will have a transfer method.
                        //we can implement that Itransfer and have different implementation for different purpose using different class
                        updated = customerAccountHandler.Transfer_SavingsToSavings(ac_no, customer, amount, recipient_AcNo);

                        //do for current to current
                        if (!updated)
                        {
                            updated = customerAccountHandler.Transfer_CurrentToCurrent(ac_no, customer, amount, recipient_AcNo);
                        }
                        //do for islamic to islamic

                        if(!updated)
                        {
                            updated=customerAccountHandler.Transfer_IslamicToIslamic(ac_no, customer, amount,recipient_AcNo);
                        }

                        if (!updated)
                        {
                            Console.WriteLine("Incorrect Account Number! Please try Again!");
                        }
                    }
                    else if (key == 4)
                    {
                        
                        break;

                    }
                    

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    Console.WriteLine("Press any key to contiue..");
                    Console.ReadKey();
                    Console.Clear(); 
                }
            }
            
        }

        
        public void CustomerPersonalUI(Customer customer)
        {
            try
            {
                while (true)
                {
                    // need to show customer info hereeee
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
                            Console.Clear();
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

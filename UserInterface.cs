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

                db.SaveCustomerToDb(customer,Encryption.EncryptPassword(customer.password));
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
            Database db = new Database();
            try
            {
                Console.WriteLine("-----------------------LOG-IN-----------------------");
                Console.WriteLine();

                Console.Write("Enter NID: ");
                int nid = stringUtils.ConvertToInt(Console.ReadLine());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                bool loggedIn = false;
                Customer customer = null;
                if(db.checkPass(nid,Encryption.EncryptPassword(password)))
                {
                    loggedIn = true;
                }
                for (int i = 0; i < Bank.CustomerList.Count; i++)
                {
                    if (nid == Bank.CustomerList[i].NID)
                    {
                        customer = Bank.CustomerList[i];
                         break;
                    }
                }


                if (loggedIn)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Logged In successfully!");
                    Console.WriteLine();
                    Bank.LoadAccountListForRespectiveCustomer(customer);
                    Bank.LoadLoansForRespectiveCustomer(customer);
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
                    Console.Clear();
                Console.WriteLine("-----------------------CUSTOMER-ACCOUNT-CREATION-----------------------");
                Console.WriteLine();
                CustomerAccountCreator customerAccountCreator = new CustomerAccountCreator();
                
                  
                    Console.WriteLine("If You want to open an Account please :");
                    Console.WriteLine("Press (1) to open Savings Account!");
                    Console.WriteLine("Press (2) to open Current Account!");
                    Console.WriteLine("Press (3) to open Islamic Account!");     
                    Console.WriteLine("Press (4) to exit!");
                    Console.Write("Select an option:");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {

                       customerAccountCreator.CreateSavingsAccount(customer);

                    }
                    else if (key == 2)
                    {
                        customerAccountCreator.CreateCurrentAccount(customer);
                    }
                    else if (key == 3)
                    {
                        //create islamic account
                        customerAccountCreator.CreatIslamicAccount(customer);

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
                    Console.WriteLine("-----------------------ACCOUNT-OPERATIONS-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press (1) to deposit money in your Bank Account!");
                    Console.WriteLine("Press (2) to withdraw money from your Bank Account!");
                    Console.WriteLine("Press (3) to transfer money to another Bank Account!");
                    Console.WriteLine("Press (4) to return!");
                    Console.Write("Select an option: ");
                    int key = 0;
                    key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 4)
                    {
                        Console.Clear();
                        break;
                    }
                 

                    Console.Write("Give your Account Number: ");

                    int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

                  
                    
                    if (key == 1)//deposit money
                    {

                       
                        Console.Write("Give deposit Amount: ");


                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());

                       customerAccountHandler.Deposit(ac_no,customer,amount);

                    }
                    else if (key == 2)//withdraw
                    {
                       
                        //taking inputs
                        Console.Write("Give withdraw Amount: ");

                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());
                        Console.WriteLine();

                        customerAccountHandler.Withdraw(ac_no, customer, amount);
                    }
                    else if (key == 3)//transfer to another account
                    {
                        Console.Write("Give the recipient account number: ");

                        int recipient_AcNo = stringUtils.ConvertToInt(Console.ReadLine());
                        Console.Write("Give transfer Amount: ");


                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());

                       
                        customerAccountHandler.Transfer(ac_no, customer, amount, recipient_AcNo);


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
                    Console.WriteLine("-----------------------CUSTOMER-PANEL-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press (1) for Account Creation!");
                    Console.WriteLine("Press (2) to check your accounts and do transactions!");
                    Console.WriteLine("Press (3) to go to loan section!");
                    Console.WriteLine("Press (4) to change your password!");
                    Console.WriteLine("Press (5) to check your transaction History!");
                    Console.WriteLine("Press (6) to return!");
                    Console.Write("Select an option: ");
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
                            Console.WriteLine("You dont have any accounts! But you can always create one! ");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey ();

                        }
                        
                        
                    }
                    else if(key==3)
                    {
                        LoanUI loanui = new LoanUI();
                        //loan er UI 
                            loanui.UI(customer);
                    }
                    
                    else if(key==4)
                    {
                        
                        Database db = new Database();
                        //change password
                        Console.Write("Give your current password: ");
                        string currPass= Console.ReadLine();

                        if(!db.checkPass(customer.NID, Encryption.EncryptPassword(currPass)))
                        {
                            Console.WriteLine("Incorrect current Password!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.Write("Give your new password: ");

                        string newPass= Console.ReadLine();


                        db.UpdateCustomerPassword(customer.NID, Encryption.EncryptPassword(newPass));

                        db.LoadCurrentAccountToList();
                        
                       
                      
                        break;
                       

                    }
                    else if(key==5)
                    {
                        
                        while(true)
                        {
                            Console.Clear();
                            Console.WriteLine("Press (1) to see deposit history!");
                            Console.WriteLine("Press (2) to see withdraw history!");
                            Console.WriteLine("Press (3) to see transfer history!");
                            Console.WriteLine("Press (4) to return!");
                            Console.Write("Select an option: ");

                            int opt = stringUtils.ConvertToInt(Console.ReadLine());

                            if(opt == 1)
                            {
                                Console.WriteLine("Give the account Number :");
                                int acNo = stringUtils.ConvertToInt(Console.ReadLine());
                                Bank.ShowAllDepositHistoryOfthisAccount(acNo);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(opt==2)
                            {
                                Console.WriteLine("Give the account Number :");
                                int acNo = stringUtils.ConvertToInt(Console.ReadLine());
                                Bank.ShowAllWithdrawHistoryOfthisAccount(acNo);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(opt==3)
                            {
                                Console.WriteLine("Give the account Number :");
                                int acNo = stringUtils.ConvertToInt(Console.ReadLine());
                                Bank.ShowAllTransferHistoryOfthisAccount(acNo);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else if(opt==4)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Command!");
                            }

                        }
                        
                       
                    }
                    else if(key==6)
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
            Admin admin = new Admin();
            Database db = new Database();
            Console.WriteLine("what's the password?");
            string pass=Console.ReadLine();

            string realPass = db.FetchAdminPass();
            
            if (Encryption.EncryptPassword(pass)!=realPass)
            {
                Console.WriteLine("Incorrect password");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            
            while(true)
            {
                Console.Clear ();
                Console.WriteLine("-----------------------ADMIN-PANEL-----------------------");
                Console.WriteLine();
                Console.WriteLine("Press (1) to see All the customers!");
                Console.WriteLine("Press (2) to go to accounts section!");
                Console.WriteLine("Press (3) to go to loans section!");
                Console.WriteLine("Press (4) to change admin password!");
                Console.WriteLine("Press (5) to return!");
                Console.Write("Select an option: ");
                int key = stringUtils.ConvertToInt(Console.ReadLine());

                if(key==1)
                {
                    //goes to customer section
                    admin.CustomerSection();
                   
                }
                else if(key==2)
                {
                    //accounts section
                    admin.AccountSection();
                 
                }
                else if(key==3)
                {
                    //loans section
                    admin.LoanSection();
                   
                }
                else if(key==4)
                {
                    admin.ChangeAdminPass(realPass);
                    break;
                }
                else if(key==5)
                {
                    break;
                }
            }


        }

        public void EnviromentSetup()
        {
            Database database = new Database();

            database.LoadCustomerToBankList();
            database.LoadAccountToList();
            database.LoadSavingsAccountToList();
            database.LoadCurrentAccountToList();
            database.LoadIslamicAccountToList();
            
            database.LoadLoansToList("HomeLoan");
            database.LoadLoansToList("EducationLoan");
            Bank.LoanAllLoanList();

            database.LoadDepositHistoryToBankList();
            database.LoadWithdrawHistoryToBankList();
            database.LoadTransferHistoryToBankList();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Admin
    {

        Database db = new Database();
        public void CustomerSection()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Press (1) to see all customer!");
                    Console.WriteLine("Press (2) to search customers by their NID");
                    Console.WriteLine("Press (3) to return!");
                    Console.Write("select an option: ");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {
                        Console.Clear();
                        Bank.ShowAllCustomer();

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else if (key == 2)
                    {
                        Console.Clear();
                        Console.Write("Give NID of the customer: ");
                        int Customer_NID = stringUtils.ConvertToInt(Console.ReadLine());
                        Bank.ShowCustomerByNID(Customer_NID);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else if (key == 3)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void AccountSection()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press (1) to see all Savings Account!");
                Console.WriteLine("Press (2) to see all Current Account!");
                Console.WriteLine("Press (3) to see all Islamic Account!");
                Console.WriteLine("Press (4) to Freeze/Unfreeze an Account!");
                Console.WriteLine("Press (5) to return!");
                Console.Write("select an option: ");
                int key = stringUtils.ConvertToInt(Console.ReadLine());

                if (key == 1)
                {
                    Console.Clear();

                    Bank.ShowAllSavingsAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if (key == 2)
                {
                    Console.Clear();
                  
                    Bank.ShowAllCurrentAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if(key==3)
                {
                    Console.Clear();

                    Bank.ShowAllIslamicAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(key==4)
                {
                    FreezeUnfreezeAccount();
                }
                else if (key == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }
            }
        }

        public void LoanSection()
        {

        }


        public void FreezeUnfreezeAccount()
        {
            try {
                while (true)
                {
                    Console.Clear();


                    Console.WriteLine("Press (1) to freeze the Account");
                    Console.WriteLine("Press (2) to unfreeze the Account");
                    Console.WriteLine("Press (3) to return!");

                    Console.Write("select an option: ");
                    int choice = stringUtils.ConvertToInt(Console.ReadLine());

                    Console.WriteLine("Give the account number: ");
                    int Ac_no = stringUtils.ConvertToInt(Console.ReadLine());


                    if (choice == 1)
                    {


                        Account account = Bank.FindAccount(Ac_no);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid Account Number!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }

                        if (account.isFreezed)
                        {
                            Console.WriteLine("The account is Already Freezed!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        account.isFreezed = true;

                        AlldatabaseMethodCalls(account);
                        Console.WriteLine("Account :" + Ac_no + " has been freezed!");
                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey();

                    }
                    else if (choice == 2)
                    {
                        Account account = Bank.FindAccount(Ac_no);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid Account Number!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }

                        if (!account.isFreezed)
                        {
                            Console.WriteLine("The account is Already in unfreezed state!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        account.isFreezed = false;

                        AlldatabaseMethodCalls(account);

                        Console.WriteLine("Account :" + Ac_no + " has been un-freezed!");
                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey();
                    }
                    else if (choice == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command!");
                    }
                }
                
            }
            catch(Exception ex) 
            {
                
            }
        }


        public void AlldatabaseMethodCalls(Account account)
        {
            db.ActivationUpdateOnAccounts("Accounts", account);
            db.ActivationUpdateOnAccounts("SavingsAccount", account);
            db.ActivationUpdateOnAccounts("IslamicAccount", account);
            db.ActivationUpdateOnAccounts("CurrentAccount", account);
            db.LoadAccountToList();
            db.LoadCurrentAccountToList();
            db.LoadSavingsAccountToList();
            db.LoadIslamicAccountToList();
        }
    }
}

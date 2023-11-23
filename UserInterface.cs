using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                Console.WriteLine("Enter UserName: ");
                int nid = stringUtils.ConvertToInt(Console.ReadLine());

                Console.WriteLine("Enter Password: ");
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

        public void CustomerPersonalUI(Customer customer)
        {
            try
            {
                if (customer.accounts.IsEmpty())
                {
                    Console.WriteLine("You Haven't Opened an Account Yet!");
                    Console.WriteLine("If You want to open an Account please :");
                    Console.WriteLine("Press (1) to open Savings Account!");
                    Console.WriteLine("Press (2) to open Current Account!");
                    Console.WriteLine("Press (3) to open Islamic Account!");

                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {
                        Console.WriteLine("Please Fill out the Following Information:");

                        Console.WriteLine("Please Enter your desired Account Number:");

                        int ac_no  = stringUtils.ConvertToInt(Console.ReadLine());

                        while (!ISUniqueAcNo(ac_no)) 
                        {

                            ac_no = stringUtils.ConvertToInt(Console.ReadLine());

                        }
                        Console.Write("Now State initial Deposit amount : ");

                        double Balance = stringUtils.ConvertToInt(Console.ReadLine());

                        SavingsAccount savingsAc = new SavingsAccount(ac_no, customer.NID, customer.Name, Balance, Date.Now);

                        customer.accounts.Add(savingsAc);

                        //NOW ADD THIS TO ACCOUNT TABLE AND SAVINGS ACCOUNT TABLE
                        Database db = new Database();

                        db.SaveAccountToDb(savingsAc);

                        db.SaveSavingsAccounttoDb(savingsAc);

                    }
                }
                else
                {
                    Console.WriteLine("Your Accounts are:");

                    for(int i=0;i<customer.accounts.Count;i++)
                    {
                        Console.WriteLine("Account no: " + customer.accounts[i].AccountNumber+" Account type: " + customer.accounts[i].GetAccountType());
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
        }
    }
}

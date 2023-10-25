using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class UserInterface
    {
       
        Customer customer;
        public void CreatingCustomer()
        {
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

        public void CustomerPanel()
        {
            Console.WriteLine("Please Log In!");

            Console.WriteLine("Enter UserName: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            bool loggedIn = false;

            for(int i=0;i<Bank.CustomerList.Count;i++)
            {
                if (username == Bank.CustomerList[i].Name && password == Bank.CustomerList[i].password)
                {
                    loggedIn = true; break;
                }
            }



            if (loggedIn)
            {
                Console.WriteLine("Logged In successfully!");
            }
            else
            {
                Console.WriteLine("Incorrect username or password!");
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

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
            
            Console.WriteLine("created customer successfully!");
        }

        public void CustomerPanel()
        {
            Console.WriteLine("Please Log In!");

            Console.WriteLine("Enter UserName: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            if(customer.Name==username && password==customer.password)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Admin
    {

        public void CustomerSection()
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
                else if(key == 3)
                {
                    break;
                }
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
                Console.WriteLine("Press (4) to return!");
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
                else if (key == 4)
                {
                    break;
                }
            }
        }

        public void LoanSection()
        {

        }
    }
}

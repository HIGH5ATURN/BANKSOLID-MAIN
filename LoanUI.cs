using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public static class LoanUI
    {
        public static void UI(Customer customer)
        {
            try 
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("UNDER CONSTRUCTION!!!");
                    Console.WriteLine("Press (1) to apply for Home Loan!");
                    Console.WriteLine("Press (2) to apply for Education Loan!");
                    Console.WriteLine("Press (3) to return!");
                    Console.Write("Select what type of loan do you want to apply for:");

                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {
                        //HomeLoan loan = new HomeLoan();
                        //we need to generate auto number for everything!!!
                        //1) for accounts 
                        //2)for loans


                    }
                    else if (key == 2)
                    {

                    }
                    else if (key == 3)
                    {
                        break;
                    }
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Error "+e.Message);
            }
        }
    }
}

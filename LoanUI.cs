using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public  class LoanUI
    {
        Database db = new Database();
        CustomerLoanHandler CustomerLoanHandler = new CustomerLoanHandler();
        public void UI(Customer customer)
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
                    Console.Write("Select an option: ");

                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {

                       CustomerLoanHandler.ApplyingForHomeLoan(customer);
                        break;
                    }
                    else if (key == 2)
                    {
                        CustomerLoanHandler.ApplyingForEducationLoan(customer);
                        break;

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

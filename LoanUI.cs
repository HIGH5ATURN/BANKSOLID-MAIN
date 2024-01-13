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
        CustomerLoanHandler customerLoanHandler = new CustomerLoanHandler();
        public void UI(Customer customer)
        {
            try 
            {
                while (true)
                {
                    Console.Clear();
                    
                    Console.WriteLine("Press (1) to apply for Home Loan!");
                    Console.WriteLine("Press (2) to apply for Education Loan!");
                    Console.WriteLine("Press (3) to check on your loans!");
                    Console.WriteLine("Press (4) to return!");
                    Console.Write("Select an option: ");

                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {

                        customerLoanHandler.ApplyingForHomeLoan(customer);
                        db.LoadLoansToList("HomeLoan");
                        db.LoadLoansToList("EducationLoan");
                        Bank.LoanAllLoanList();
                        Bank.LoadLoansForRespectiveCustomer(customer);
                        break;
                    }
                    else if (key == 2)
                    {
                        customerLoanHandler.ApplyingForEducationLoan(customer);
                        db.LoadLoansToList("HomeLoan");
                        db.LoadLoansToList("EducationLoan");
                        Bank.LoanAllLoanList();
                        Bank.LoadLoansForRespectiveCustomer(customer);
                        break;

                    }
                    else if(key==3)
                    {
                        Console.Clear() ;
                        customerLoanHandler.ShowLoanInfo(customer);
                        Console.WriteLine("Press any key to Continue...");
                        Console.ReadKey();
                    }
                    else if (key == 4)
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

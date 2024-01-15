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
                    Console.WriteLine("-----------------------LOAN-SECTION-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press (1) to apply for Home Loan!");
                    Console.WriteLine("Press (2) to apply for Education Loan!");
                    Console.WriteLine("Press (3) to check on your loans!");
                    Console.WriteLine("Press (4) to make payment for your loan!");
                    Console.WriteLine("Press (5) to return!");
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
                        Console.WriteLine("-----------------------ALL-TAKEN-LOAN-----------------------");
                        Console.WriteLine();
                        customerLoanHandler.ShowLoanInfo(customer);
                        Console.WriteLine("Press any key to Continue...");
                        Console.ReadKey();
                    }
                    else if(key==4)
                    {
                        Console.Clear();

                        Console.Write("Give the loan ID: ");
                        //now we need to do transaction update on loan!!!! in DATABASE
                        int loan_id = stringUtils.ConvertToInt(Console.ReadLine());

                        Loan loan = Bank.FindLoan(loan_id);

                        if(loan==null)
                        {
                            Console.WriteLine("Incorrect loan ID");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        if (!loan.isApproved)
                        {
                            Console.WriteLine("Your loan is not approved yet!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        Console.Write("Give the amount you want to pay: ");

                        double amount = stringUtils.ConvertToDouble(Console.ReadLine());

                        loan.makePayment(amount);

                        db.UpdateLoanTable("HomeLoan", loan);
                        db.UpdateLoanTable("EducationLoan", loan);

                        db.LoadLoansToList("HomeLoan");
                        db.LoadLoansToList("EducationLoan");
                        Bank.LoanAllLoanList();

                        Console.WriteLine("You have paid :"+amount);
                        Console.WriteLine("Remaining payable "+loan.loan_amount);

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

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
            catch (Exception e) 
            {
                Console.WriteLine("Error "+e.Message);
            }
        }


        
      
    }
}

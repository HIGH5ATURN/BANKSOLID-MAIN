using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class CustomerLoanHandler
    {
        Database db = new Database();
        public void ApplyingForHomeLoan(Customer customer)
        {
            Console.Write("Please state the amount you want for loan: ");
            double loanAmount = stringUtils.ConvertToDouble(Console.ReadLine());

            if (loanAmount < 50000)
            {
                Console.WriteLine("Home loan starts from 50000 bdt!");
                return;
            }

            HomeLoan homeloan = new HomeLoan(loanAmount);
            customer.allLoans.Add(homeloan);
            customer.homeLoans.Add(homeloan);
            db.SaveLoantoDB(homeloan, customer.NID, "HomeLoan");
            Console.WriteLine("Your Home Loan request is up for review! You will be hearing from us very soon");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void ApplyingForEducationLoan(Customer customer)
        {
            Console.Write("Please state the amount you want for loan: ");
            double loanAmount = stringUtils.ConvertToDouble(Console.ReadLine());
            if (loanAmount < 10000)
            {
                Console.WriteLine("Home loan starts from 10000 bdt!");
                return;
            }

            EducationLoan educationLoan = new EducationLoan(loanAmount);
            customer.allLoans.Add(educationLoan);
            customer.educationloans.Add(educationLoan);
            db.SaveLoantoDB(educationLoan, customer.NID, "EducationLoan");
            Console.WriteLine("Your Education Loan request is up for review! You will be hearing from us very soon");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

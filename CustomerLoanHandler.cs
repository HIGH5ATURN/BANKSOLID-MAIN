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
                Console.WriteLine("Application Failed! Home loan starts from 50000 bdt!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            HomeLoan homeloan = new HomeLoan(customer.NID,loanAmount);
            customer.allLoans.Add(homeloan);
            customer.homeLoans.Add(homeloan);
            db.SaveLoantoDB(homeloan, customer.NID, "HomeLoan");
            Console.WriteLine("Your Home Loan request is up for review! You will be hearing from us very soon");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            //missing just to be safe :)

        }

        public void ApplyingForEducationLoan(Customer customer)
        {
            Console.Write("Please state the amount you want for loan: ");
            double loanAmount = stringUtils.ConvertToDouble(Console.ReadLine());
            if (loanAmount < 10000)
            {
                Console.WriteLine("Application Failed! Education loan starts from 10000 bdt!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            EducationLoan educationLoan = new EducationLoan(customer.NID,loanAmount);
            customer.allLoans.Add(educationLoan);
            customer.educationloans.Add(educationLoan);
            db.SaveLoantoDB(educationLoan, customer.NID, "EducationLoan");
            Console.WriteLine("Your Education Loan request is up for review! You will be hearing from us very soon");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowLoanInfo(Customer customer)
        {
            if(customer.allLoans.Count == 0)
            {
                Console.WriteLine("You have not taken any loans!");
                return;
            }
            Console.WriteLine("-----------------------");
            for (int i=0;i<customer.allLoans.Count;i++)
            {
                customer.allLoans[i].getLoanDetails();
                Console.WriteLine("-----------------------");
            }
        }
    }
}

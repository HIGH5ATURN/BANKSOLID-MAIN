using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class EducationLoan : Loan, ILoan, ILoanInterest
    {
        public void getLoanDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Loan Details");
            Console.WriteLine("Loan Type: Education Loan");
            Console.WriteLine("Loan ID: " + loan_id);
            Console.WriteLine("Principle Amount: " + loan_amount);
            Console.WriteLine("Loan taken on: " + starting_date);
            Console.WriteLine("Remaining Payable: " + remaining_loan_amount);
            Console.WriteLine();
        }

        public double interestRate { get; set; } = 0.05;

        public double leastPayment { get; set; } = 1000;


        public double totalPayableAmount(DateOnly date)
        {
            return 0.0;
        }

        public double makePayment(DateOnly paymentDate, double payment)
        {
            return 0.0;
        }

        public EducationLoan(int loan_id, double loan_amount, DateOnly starting_date)
        {
            this.loan_id = loan_id;
            this.loan_amount = loan_amount;
            this.starting_date = starting_date;
            remaining_loan_amount = loan_amount;
        }



    }
}

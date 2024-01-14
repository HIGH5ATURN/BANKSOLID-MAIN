using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class CarLoan : Loan, ILoan, ILoanInterest
    {
        public override void getLoanDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Loan Details");
            Console.WriteLine("Loan Type: Car Loan");
            Console.WriteLine("Loan ID: " + loan_id);
            Console.WriteLine("Principle Amount: " + loan_amount);
            Console.WriteLine("Loan taken on: " + starting_date);
            Console.WriteLine("Remaining Payable: " + remaining_loan_amount);
            Console.WriteLine();
        }

        public double interestRate { get; set; } = 0.05;

        public double leastPayment { get; set; } = 2000;

        public Date lastInterestDate { get; set; }
        public void AddInterest()
        {
            Date currentDate = Date.Now;

            if (currentDate.Month > lastInterestDate.Month || currentDate.Year > lastInterestDate.Year)
            {
                int monthsPassed = currentDate.MonthsBetween(lastInterestDate);

                for (int i = 0; i < monthsPassed; i++)
                {
                    loan_amount += loan_amount * (interestRate);
                }
                lastInterestDate = currentDate;

            }

        }


        public override void makePayment(double payment)
        {
            if (payment > loan_amount)
            {
                throw new LoanException("Payment is greater than Loan amount itself!");
            }
            if (payment < leastPayment && loan_amount >= leastPayment)
            {
                throw new LoanException("Least payment of loan has to be 1000 bdt");
            }
            else
            {
                loan_amount -= payment;

                last_payment_date = Date.Now;
            }

        }

       

        public CarLoan(int loan_id, double loan_amount, Date starting_date)
        {
            this.loan_id = loan_id;
            this.loan_amount = loan_amount;
            this.starting_date = starting_date;
            remaining_loan_amount = loan_amount;
        }


    }
}

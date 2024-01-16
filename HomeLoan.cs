using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class HomeLoan : Loan, ILoan, ILoanInterest
    {
        public override void getLoanDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Loan Details");
            Console.WriteLine("Loan Type: Home Loan");
            Console.WriteLine("Loan ID: " + loan_id);
            Console.WriteLine("Loan Amount: " + loan_amount);
            if(!isApproved)
            {
                Console.WriteLine("The loan is not approved yet!");
            }
            else
            {
                Console.WriteLine("Your Loan was approved!");
            }
            if (starting_date != null)
            {
                Console.WriteLine("Loan taken on: " + starting_date.Year + "-" + starting_date.Month + "-" + starting_date.Day);
            }

            if (starting_date != null)
            {
                Console.WriteLine("Loan taken on: " + last_payment_date.Year + "-" + last_payment_date.Month + "-" + last_payment_date.Day);
            }
            Console.WriteLine();
        }

        public static double interestRate { get; set; } = 0.05;

        public static double leastPayment { get; set; } = 5000;

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
            if(!isApproved)
            {
                Console.WriteLine("Cant make payment, the loan is yet to be approved!");
                return;
            }

            if (payment > loan_amount)
            {
                throw new LoanException("Payment is greater than Loan amount itself!");
            }
            if (payment < leastPayment && loan_amount >= leastPayment)
            {
                throw new LoanException("Least payment of loan has to be 5000 bdt");
            }
            else
            {
                AddInterest();
                loan_amount -= payment;
                if(loan_amount==0)
                {
                    Database db = new Database();

                    db.RejectingLoanRequest("HomeLoan",this);

                    db.LoadLoansToList("HomeLoan");

                }
                last_payment_date = Date.Now;
                
            }

        }

        public HomeLoan(int loan_id, int customer_NID, double loan_amount, bool isApproved, Date starting_date,Date last_payment_Date,Date last_interest_Date)
        {
            this.loan_id = loan_id;
            this.customerNID = customer_NID;
            this.loan_amount = loan_amount;
            this.isApproved= isApproved;
            this.starting_date = starting_date;
            this.last_payment_date = last_payment_Date;
            this.lastInterestDate = last_interest_Date;
            
        }

        public HomeLoan(int customer_NID,double loan_amount)
        {
            this.customerNID = customer_NID;
            this.loan_amount = loan_amount;
            remaining_loan_amount = loan_amount;
            isApproved = false;
        }

        public string getType()
        {
            return this.GetType().Name;
        }
    }
}

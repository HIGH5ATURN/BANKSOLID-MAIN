﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class EducationLoan : Loan, ILoan, ILoanInterest
    {
        public override void getLoanDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Loan Details");
            Console.WriteLine("Loan Type: Education Loan");
            Console.WriteLine("Loan ID: " + loan_id);
            Console.WriteLine("Loan Amount: " + loan_amount);
            if (!isApproved)
            {
                Console.WriteLine("The loan is not approved yet!");
            }
            else
            {
                Console.WriteLine("Your Loan was approved!");
            }
            Console.WriteLine("Loan taken on: " + starting_date);
            Console.WriteLine();
        }

        public static double interestRate { get; set; } = 0.02;

        public static double leastPayment { get; set; } = 1000;

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


        public void makePayment(double payment)
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
                AddInterest();
                loan_amount -= payment;

                last_payment_date = Date.Now;
            }

        }

        public EducationLoan(int loan_id, int customer_NID, double loan_amount, bool isApproved, Date starting_date, Date last_payment_Date, Date last_interest_Date)
        {
            this.loan_id = loan_id;
            this.customerNID = customer_NID;
            this.loan_amount = loan_amount;
            this.isApproved = isApproved;
            this.starting_date = starting_date;
            this.last_payment_date = last_payment_Date;
            this.lastInterestDate = last_interest_Date;

        }

        public EducationLoan(int customer_nid, double loan_amount)
        {
            this.customerNID = customer_nid;
           
            this.loan_amount = loan_amount;
            remaining_loan_amount = loan_amount;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public abstract class Loan
    {
        public int loan_id { get; set; }

        public double loan_amount
        {
            get { return loan_amount; }
            set
            {
                if (value < 5000)
                {
                    throw new LoanException("Minimum loan amount is 5000");
                }
                else
                {
                    loan_amount = value;
                }
            }
        }


        public Date starting_date { get; set; }

        public Date last_payment_date { get; set; }

        public double remaining_loan_amount { get; set; }



    }
}

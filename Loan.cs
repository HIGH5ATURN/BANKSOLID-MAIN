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

        public int customerNID { get; set; }

        public bool isApproved { get; set; } = false;
        public double loan_amount { get; set; }
 

        public Date starting_date { get; set; }

        public Date last_payment_date { get; set; }

        public double remaining_loan_amount { get; set; }


        public abstract void getLoanDetails();
        public abstract void makePayment(double payment);

    }
}

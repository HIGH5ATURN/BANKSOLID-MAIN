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

        public double loan_amount { get; set; }

        public DateOnly starting_date { get; set; }

        public DateOnly last_payment_date { get; set; }

        public double remaining_loan_amount { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class LoanManager
    {
        public void getLoanDetails(ILoan loanType)
        {
            loanType.getLoanDetails();
        }






        //public void makePayment(ILoanInterest loantype, double amount)
        //{
        //    loantype.makePayment(amount);
        //}


    }
}

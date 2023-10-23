using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public interface ILoanInterest
    {

        double interestRate { get; set; }

        double leastPayment { get; set; }
        double totalPayableAmount(DateOnly date);

        double makePayment(DateOnly paymentDate, double payment);
    }
}

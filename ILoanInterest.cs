using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public interface ILoanInterest
    {
        Date lastInterestDate { get; set; }
        static double interestRate { get; set; }

        static double leastPayment { get; set; }
        void AddInterest();

        
    }
}

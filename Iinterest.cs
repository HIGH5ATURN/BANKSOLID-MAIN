using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public interface Iinterest
    {
        public double InterestRate { get; set; }

        public Date LastInterestDate { get; set; }
        public void AddInterest();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class LoanException : Exception
    {
        public LoanException(string message) : base(message)
        {

        }
    }
}

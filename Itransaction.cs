using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public interface Itransaction
    {
        public void Deposit(double amount);

        public double Withdraw(double amount,Date withdraw_date);

        public void Transfer(Account account, double Amount);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Customer
    {
        
        public string Name { get; set; }
        public int NID { get; set; }

        public string password { get; set; }

        public Customer(string name, int nID, string password)
        {
            Name = name;
            NID = nID;
            this.password = password;
        }
        public void ChangePassword(string password)
        {
            this.password = password;
        }

    }
}

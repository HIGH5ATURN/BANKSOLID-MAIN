using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class CustomerAccountCreator
    {
        public bool ISUniqueAcNo(int ac_no)
        {

            for (int i = 0; i < Bank.AllAccountList.Count; i++)
            {
                if (ac_no == Bank.AllAccountList[i].AccountNumber)
                {
                    Console.WriteLine("This number is Already taken, Please Give Another one");

                    return false;
                }
            }

            return true;
        }


        public void CreateSavingsAccount(Customer customer)
        {
            Console.WriteLine("Please Fill out the Following Information:");

            Console.WriteLine("Please Enter your desired Account Number:");

            int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            while (!ISUniqueAcNo(ac_no))
            {

                ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            }
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            SavingsAccount savingsAc = new SavingsAccount(ac_no, customer.NID, customer.Name, Balance, Date.Now);

            customer.savingsAccounts.Add(savingsAc);
            customer.accounts.Add(savingsAc);
            //NOW ADD THIS TO ACCOUNT TABLE AND SAVINGS ACCOUNT TABLE
            Database db = new Database();

            db.SaveAccountToDb(savingsAc);

            db.SaveSavingsAccounttoDb(savingsAc);

            //just to be safe
            db.LoadAccountToList();
            db.LoadSavingsAccountToList();
            Bank.LoadAccountListForRespectiveCustomer(customer);

        }


        public void CreateCurrentAccount(Customer customer)
        {

            Console.WriteLine("Please Fill out the Following Information:");

            Console.WriteLine("Please Enter your desired Account Number:");

            int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            while (!ISUniqueAcNo(ac_no))
            {

                ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            }
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            CurrentAccount currentaccount = new CurrentAccount(ac_no, customer.NID, customer.Name, Balance, Date.Now);

            customer.currentAccounts.Add(currentaccount);

            


            
            Database db = new Database();

            db.SaveAccountToDb(currentaccount);

            db.SaveCurrentAccounttoDb(currentaccount);


            
            db.LoadAccountToList();

            db.LoadCurrentAccountToList();

            Bank.LoadAccountListForRespectiveCustomer(customer);


        }
    }
}

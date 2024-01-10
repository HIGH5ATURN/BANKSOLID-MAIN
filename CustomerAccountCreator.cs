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

            //Console.WriteLine("Please Enter your desired Account Number:");

            //int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //while (!ISUniqueAcNo(ac_no))
            //{

            //    ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //}
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            SavingsAccount savingsAc = new SavingsAccount( customer.NID, customer.Name, Balance, Date.Now);



            //NOW ADD THIS TO ACCOUNT TABLE AND SAVINGS ACCOUNT TABLE
            Database db = new Database();

            

            db.SaveSavingsAccounttoDb(savingsAc);

            //fetch account number then add this to db
            savingsAc.AccountNumber = db.FetchAccountNumber("SavingsAccount");

            Console.WriteLine("Successfully created a Savings Account!");
            Console.WriteLine("Your new Account Number "+savingsAc.AccountNumber);
            Console.WriteLine("Press any key to continue...");
          
            customer.savingsAccounts.Add(savingsAc);
            customer.accounts.Add(savingsAc);

            db.SaveAccountToDb(savingsAc);
       

            //just to be safe
            db.LoadAccountToList();
            db.LoadSavingsAccountToList();
            Bank.LoadAccountListForRespectiveCustomer(customer);
            Console.ReadKey();
        }


        public void CreateCurrentAccount(Customer customer)
        {

            Console.WriteLine("Please Fill out the Following Information:");

            //Console.WriteLine("Please Enter your desired Account Number:");

            //int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //while (!ISUniqueAcNo(ac_no))
            //{

            //    ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //}
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            CurrentAccount currentaccount = new CurrentAccount(customer.NID, customer.Name, Balance, Date.Now);

           

            


            
            Database db = new Database();
            db.SaveCurrentAccounttoDb(currentaccount);

            currentaccount.AccountNumber = db.FetchAccountNumber("CurrentAccount");

            Console.WriteLine("Successfully created a Current Account!");
            Console.WriteLine("Your new Account Number " + currentaccount.AccountNumber);
            Console.WriteLine("Press any key to continue...");
            
            customer.currentAccounts.Add(currentaccount);
            customer.accounts.Add(currentaccount);

            db.SaveAccountToDb(currentaccount);




            //just to be safe
            db.LoadAccountToList();

            db.LoadCurrentAccountToList();

            Bank.LoadAccountListForRespectiveCustomer(customer);

            Console.ReadKey();


        }


        
        public void CreatIslamicAccount(Customer customer)
        {

            Console.WriteLine("Please Fill out the Following Information:");

            //Console.WriteLine("Please Enter your desired Account Number:");

            //int ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //while (!ISUniqueAcNo(ac_no))
            //{

            //    ac_no = stringUtils.ConvertToInt(Console.ReadLine());

            //}
            Console.Write("Now State initial Deposit amount : ");

            double Balance = stringUtils.ConvertToDouble(Console.ReadLine());

            IslamicAccount islamicAccount = new IslamicAccount(customer.NID, customer.Name, Balance, Date.Now);

            Database db = new Database();
            db.SaveIslamicAccounttoDb(islamicAccount);

            islamicAccount.AccountNumber = db.FetchAccountNumber("IslamicAccount");
           
            Console.WriteLine("Successfully created a Islamic Account!");
            Console.WriteLine("Your new Account Number " + islamicAccount.AccountNumber);
            Console.WriteLine("Press any key to continue...");


            customer.islamicAccounts.Add(islamicAccount);
            customer.accounts.Add(islamicAccount);

            db.SaveAccountToDb(islamicAccount);

            

            //just to be safe

            db.LoadAccountToList();

            db.LoadIslamicAccountToList();

            Bank.LoadAccountListForRespectiveCustomer(customer);
            Console.ReadKey();


        }
    }
}



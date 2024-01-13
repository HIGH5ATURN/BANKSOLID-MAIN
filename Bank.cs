using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public static class Bank
    {
        public static vector<Customer> CustomerList = new vector<Customer>();

        public static vector<Account> AllAccountList = new vector<Account>();

        public static vector<SavingsAccount> SavingsAccountList = new vector<SavingsAccount>();

        public static vector<CurrentAccount> CurrentAccountList = new vector<CurrentAccount>();

        public static vector<IslamicAccount> IslamicAccountList = new vector<IslamicAccount>();

        public static vector<Loan> AllLoanList = new vector<Loan>();

        public static vector<HomeLoan> HomeLoanList = new vector<HomeLoan>();

        public static vector<EducationLoan> EducationLoanList = new vector<EducationLoan>();

        
        public static void LoadAccountListForRespectiveCustomer(Customer customer)
        {
            customer.savingsAccounts.Clear();
            customer.currentAccounts.Clear();
            customer.islamicAccounts.Clear();
            customer.accounts.Clear();


            for(int i=0;i< SavingsAccountList.Count;i++)
            {
                if (SavingsAccountList[i].AccountHolderNID==customer.NID)
                {
                    customer.savingsAccounts.Add(SavingsAccountList[i]);
                }
            }

            for (int i = 0; i < CurrentAccountList.Count; i++)
            {
                if (CurrentAccountList[i].AccountHolderNID == customer.NID)
                {
                    customer.currentAccounts.Add(CurrentAccountList[i]);
                }
            }


            for (int i = 0; i < IslamicAccountList.Count; i++)
            {
                if (IslamicAccountList[i].AccountHolderNID == customer.NID)
                {
                    customer.islamicAccounts.Add(IslamicAccountList[i]);
                }
            }

            
            for(int i=0;i<AllAccountList.Count;i++)
            {
                if (AllAccountList[i].AccountHolderNID == customer.NID)
                {
                    customer.accounts.Add(AllAccountList[i]);
                }
            }


        }
    }
}

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

        public static void LoadLoansForRespectiveCustomer(Customer customer)
        {
            customer.allLoans.Clear();
            customer.homeLoans.Clear();
            customer.educationloans.Clear();


            for(int i=0;i< AllLoanList.Count;i++)
            {
                if (AllLoanList[i].customerNID== customer.NID)
                {
                    customer.allLoans.Add(AllLoanList[i]);
                }
            }

            for (int i = 0; i < HomeLoanList.Count; i++)
            {
                if (HomeLoanList[i].customerNID == customer.NID)
                {
                    customer.homeLoans.Add(HomeLoanList[i]);
                }
            }

            for (int i = 0; i < EducationLoanList.Count; i++)
            {
                if (EducationLoanList[i].customerNID == customer.NID)
                {
                    customer.educationloans.Add(EducationLoanList[i]);
                }
            }
        }

        //part_of_just_to_be_safe
        public static void LoanAllLoanList()
        {
            AllLoanList.Clear();
            for (int i = 0; i < HomeLoanList.Count; i++)
            {

                AllLoanList.Add(HomeLoanList[i]);
                
            }

            for (int i = 0; i < EducationLoanList.Count; i++)
            {
               
                    AllLoanList.Add(EducationLoanList[i]);
                
            }
        }
    }
}

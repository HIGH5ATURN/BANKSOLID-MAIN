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

        
        public static vector<DepositHistory> depositHistoryList = new vector<DepositHistory>();

        public static vector<WithdrawHistory> WithdrawHistoryList = new vector<WithdrawHistory>();

        public static vector<TransferHistory> transferHistoryList = new vector<TransferHistory>();

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

        public static void ShowAllCustomer()
        {
            Console.WriteLine("------------------------------------");
            for (int i = 0;i<CustomerList.Count;i++)
            {
                Console.WriteLine("Customer Name: " + CustomerList[i].Name);
                Console.WriteLine("Customer NID: " + CustomerList[i].NID);
                Console.WriteLine("------------------------------------");
            }
            
        }

        public static void ShowCustomerByNID(int nid)
        {
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i].NID == nid)
                {
                    Console.WriteLine("Customer Name: " + CustomerList[i].Name);
                    Console.WriteLine("Customer NID: " + CustomerList[i].NID);
                }
            }
        }

        public static void ShowAllSavingsAccount()
        {
            Console.WriteLine("--------------------------");
            for (int i=0;i<SavingsAccountList.Count;i++)
            {
                SavingsAccountList[i].ShowAccountInfo();
                Console.WriteLine("--------------------------");
            }
        }

        public static void ShowAllCurrentAccount()
        {
            Console.WriteLine("--------------------------");
            for (int i = 0; i < CurrentAccountList.Count; i++)
            {
                CurrentAccountList[i].ShowAccountInfo();
                Console.WriteLine("--------------------------");
            }
        }

        public static void ShowAllIslamicAccount()
        {
            Console.WriteLine("--------------------------");
            for (int i = 0; i < IslamicAccountList.Count; i++)
            {
                IslamicAccountList[i].ShowAccountInfo();
                Console.WriteLine("--------------------------");
            }
        }

        public static Account FindAccount(int ac_no)
        {

            for(int i=0;i<SavingsAccountList.Count;i++)
            {
                if (ac_no == SavingsAccountList[i].AccountNumber)
                {
                    return SavingsAccountList[i];
                }
            }

            for (int i = 0; i < CurrentAccountList.Count; i++)
            {
                if (CurrentAccountList[i].AccountNumber == ac_no)
                {
                    return CurrentAccountList[i];
                }
            }


            for (int i = 0; i < IslamicAccountList.Count; i++)
            {
                if (IslamicAccountList[i].AccountNumber == ac_no)
                {
                  return IslamicAccountList[i];
                }
            }

            return null;
        }

        public static void ShowAllLoanRequests()
        {
            bool isEmpty = true;
            for (int i = 0; i < AllLoanList.Count; i++)
            {
                if (!AllLoanList[i].isApproved)
                {
                    isEmpty= false;break;
                }
            }
            if (isEmpty) {
                Console.WriteLine("NO pending Loan Request!");
                return; }
            Console.WriteLine("---------------------------------------");
            for (int i=0;i<AllLoanList.Count;i++)
            {
                if (!AllLoanList[i].isApproved)
                {
                    Console.WriteLine("Loan ID: " + AllLoanList[i].loan_id);
                    Console.WriteLine("Customer NID: " + AllLoanList[i].customerNID);
                    Console.WriteLine("Loan Amount: " + AllLoanList[i].loan_amount);
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public static void ShowAllGrantedLoans()
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < AllLoanList.Count; i++)
            {
                if (AllLoanList[i].isApproved)
                {
                    Console.WriteLine("Loan ID: " + AllLoanList[i].loan_id);
                    Console.WriteLine("Customer NID: " + AllLoanList[i].customerNID);
                    Console.WriteLine("Loan Amount: " + AllLoanList[i].loan_amount);
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public static Loan FindLoan(int loan_id)
        {
            for(int i=0;i<HomeLoanList.Count;i++)
            {
                if (HomeLoanList[i].loan_id==loan_id)
                {
                    return HomeLoanList[i];
                }
            }

            for (int i = 0; i < EducationLoanList.Count; i++)
            {
                if (EducationLoanList[i].loan_id == loan_id)
                {
                    return EducationLoanList[i];
                }
            }

            return null;
        }

        public static void ShowAllDepositHistoryOfthisAccount(int AccountNo)
        {
            Console.WriteLine("---------------------------------------");
            for (int i=0;i<depositHistoryList.Count;i++)
            {
                if (depositHistoryList[i].AccountNumber == AccountNo)
                {
                    depositHistoryList[i].ShowAllInfo();
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public static void ShowAllWithdrawHistoryOfthisAccount(int AccountNo)
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < WithdrawHistoryList.Count; i++)
            {
                if (WithdrawHistoryList[i].AccountNumber == AccountNo)
                {
                    WithdrawHistoryList[i].ShowAllInfo();
                    Console.WriteLine("---------------------------------------");
                }
            }
        }

        public static void ShowAllTransferHistoryOfthisAccount(int AccountNo)
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < transferHistoryList.Count; i++)
            {
                if (transferHistoryList[i].giverAccountNumber == AccountNo)
                {
                    WithdrawHistoryList[i].ShowAllInfo();
                    Console.WriteLine("---------------------------------------");
                }
            }
        }
    }
}

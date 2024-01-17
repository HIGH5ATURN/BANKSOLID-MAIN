using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BANKSOLID
{
    public class Admin
    {

        Database db = new Database();
        public void CustomerSection()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------ALL-REGISTERED-CUSTOMER-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press (1) to see all customer!");
                    Console.WriteLine("Press (2) to search customers by their NID");
                    Console.WriteLine("Press (3) to return!");
                    Console.Write("select an option: ");
                    int key = stringUtils.ConvertToInt(Console.ReadLine());

                    if (key == 1)
                    {
                        Console.Clear();
                        Bank.ShowAllCustomer();

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else if (key == 2)
                    {
                        Console.Clear();
                        Console.Write("Give NID of the customer: ");
                        int Customer_NID = stringUtils.ConvertToInt(Console.ReadLine());
                        Bank.ShowCustomerByNID(Customer_NID);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else if (key == 3)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void AccountSection()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------ALL-CREATED-ACCOUNT-----------------------");
                Console.WriteLine();
                Console.WriteLine("Press (1) to see all Savings Account!");
                Console.WriteLine("Press (2) to see all Current Account!");
                Console.WriteLine("Press (3) to see all Islamic Account!");
                Console.WriteLine("Press (4) to Freeze/Unfreeze an Account!");
                Console.WriteLine("Press (5) to return!");
                Console.Write("select an option: ");
                int key = stringUtils.ConvertToInt(Console.ReadLine());

                if (key == 1)
                {
                    Console.Clear();

                    Bank.ShowAllSavingsAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if (key == 2)
                {
                    Console.Clear();
                  
                    Bank.ShowAllCurrentAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if(key==3)
                {
                    Console.Clear();

                    Bank.ShowAllIslamicAccount();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(key==4)
                {
                    FreezeUnfreezeAccount();
                }
                else if (key == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }
            }
        }

        public void LoanSection()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------(ADMIN)LOAN-SECTION-----------------------");
                Console.WriteLine();
                Console.WriteLine("Press (1) to see all loan requests!");
                Console.WriteLine("Press (2) to see all accepted loan requests!");
                Console.WriteLine("Press (3) to grant/reject a loan request!");
                Console.WriteLine("Press (4) to return!");

                Console.Write("Select an option: ");

                int key = stringUtils.ConvertToInt(Console.ReadLine());

                if(key == 1)
                {
                    Console.Clear();
                    Bank.ShowAllLoanRequests();
                   
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
                else if(key == 2)
                {
                    Console.Clear() ;
                    Bank.ShowAllGrantedLoans();


                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
                else if(key == 3)
                {
                    //now here admin will accept loan request , thus the loan will be initialized with starting_Date
                    ProcessingLoanRequest();
                }
                else if(key == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }
            }
        }

        public void ProcessingLoanRequest()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------LOAN-PROCESSING-SECTION-----------------------");
                Console.WriteLine();
                Console.WriteLine("Press (1) to grant a loan!");
                Console.WriteLine("Press (2) to reject a loan request!");
                Console.WriteLine("Press (3) to return!");
                Console.Write("Select an option: ");

                int choice= stringUtils.ConvertToInt(Console.ReadLine());

               

               

                if (choice==1)
                {
                    Console.Write("Give the loan ID: ");
                    int loan_id = stringUtils.ConvertToInt(Console.ReadLine());
                    Loan loan = Bank.FindLoan(loan_id);
                    //granting a loan will require to change the status of isApproved to true and will have to assign starting_Date and interest_date;
                    if(loan==null)
                    {
                        Console.WriteLine("No loan exists with this ID");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    if(loan.isApproved)
                    {
                        Console.WriteLine("This loan is already approved!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    loan.starting_date = Date.Now;
                    loan.last_payment_date = Date.Now;
                    loan.isApproved = true;

                    db.AcceptLoanRequest("HomeLoan", loan);
                    db.AcceptLoanRequest("EducationLoan", loan);

                    db.LoadLoansToList("HomeLoan");
                    db.LoadLoansToList("EducationLoan");
                    Bank.LoanAllLoanList();
                    Console.WriteLine("The loan ("+loan_id+") has been granted");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(choice==2)
                {
                    //delete the loan entry from database
                    Console.Write("Give the loan ID: ");
                    int loan_id = stringUtils.ConvertToInt(Console.ReadLine());
                    Loan loan = Bank.FindLoan(loan_id);
                 
                    if (loan == null)
                    {
                        Console.WriteLine("No loan exists with this ID");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    if (loan.isApproved)
                    {
                        Console.WriteLine("This loan is already approved!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    loan.starting_date = Date.Now;
                    loan.last_payment_date = Date.Now;
                    loan.isApproved = true;

                    db.RejectingLoanRequest( "HomeLoan", loan);
                    db.RejectingLoanRequest("EducationLoan", loan);
                    db.LoadLoansToList("HomeLoan");
                    db.LoadLoansToList("EducationLoan");
                    Bank.LoanAllLoanList();
                    Console.WriteLine($"Loan request with ID {loan_id} rejected and entry deleted successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
                else if(choice==3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Command!");
                }

            }
        }

        public void FreezeUnfreezeAccount()
        {
            try {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("-----------------------ACCOUNT-CONTROL-PANEL-----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Press (1) to freeze the Account");
                    Console.WriteLine("Press (2) to unfreeze the Account");
                    Console.WriteLine("Press (3) to return!");

                    Console.Write("select an option: ");
                    int choice = stringUtils.ConvertToInt(Console.ReadLine());

                 


                    if (choice == 1)
                    {
                        Console.WriteLine("Give the account number: ");
                        int Ac_no = stringUtils.ConvertToInt(Console.ReadLine());

                        Account account = Bank.FindAccount(Ac_no);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid Account Number!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }

                        if (account.isFreezed)
                        {
                            Console.WriteLine("The account is Already Freezed!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        account.isFreezed = true;

                        AlldatabaseMethodCalls(account);
                        Console.WriteLine("Account :" + Ac_no + " has been freezed!");
                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey();

                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Give the account number: ");
                        int Ac_no = stringUtils.ConvertToInt(Console.ReadLine());
                        Account account = Bank.FindAccount(Ac_no);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid Account Number!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }

                        if (!account.isFreezed)
                        {
                            Console.WriteLine("The account is Already in unfreezed state!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        account.isFreezed = false;

                        AlldatabaseMethodCalls(account);

                        Console.WriteLine("Account :" + Ac_no + " has been un-freezed!");
                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey();
                    }
                    else if (choice == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command!");
                    }
                }
                
            }
            catch(Exception ex) 
            {
                
            }
        }

        public void ChangeAdminPass(string realPass)
        {
            Console.Clear();
            Console.Write("Give current Password: ");

            string currPass = Console.ReadLine();
            if (Encryption.EncryptPassword(currPass) != realPass)
            {
                Console.WriteLine("Invalid Current Password!");
                return;
            }
            Console.Write("Give new Password: ");

            string newPass = Console.ReadLine();

            db.UpdateAdminPass(Encryption.EncryptPassword(newPass));
            Console.WriteLine("Password has been successfully updated!");
          
        }
        public void AlldatabaseMethodCalls(Account account)
        {
            db.ActivationUpdateOnAccounts("Accounts", account);
            db.ActivationUpdateOnAccounts("SavingsAccount", account);
            db.ActivationUpdateOnAccounts("IslamicAccount", account);
            db.ActivationUpdateOnAccounts("CurrentAccount", account);
            db.LoadAccountToList();
            db.LoadCurrentAccountToList();
            db.LoadSavingsAccountToList();
            db.LoadIslamicAccountToList();
        }
    }
}

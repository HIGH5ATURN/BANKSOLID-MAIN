using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Security.Principal;

namespace BANKSOLID
{
    public class Database
    {

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
        OleDbCommand cmd;
       
        public void SaveCustomerToDb(Customer customer)
        {
            try
            {
                conn.Open();
                string sql = "Insert into Customer(_NID,_uname,_pass) VALUES" + "(@nid,@name,@pass)";

                cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nid", customer.NID.ToString());
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@pass", customer.password);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SaveAccountToDb(Account account)
        {
            try
            {
                conn.Open();

                string sql = "Insert into Accounts(AccountNumber,_AccountHolderName,_AccountHolderNID,_Balance,_Date) values" + "(@acno,@name,@nid,@balance,@date)";
                cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("@acno", account.AccountNumber);
                cmd.Parameters.AddWithValue("@name", account.AccountHolderName);
                cmd.Parameters.AddWithValue("@nid", account.AccountHolderNID);
                cmd.Parameters.AddWithValue("@balance", account.Balance);
                cmd.Parameters.AddWithValue("@date",stringUtils.ConvertDateToString( account.OpeningDate));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        public void LoadAccountToList()
        {
            Bank.AllAccountList.Clear();

            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
                conn.Open();
                string sql = "Select * from Accounts";

                cmd = new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ac_no = stringUtils.ConvertToInt(reader["AccountNumber"].ToString());

                    string name = reader["_AccountHolderName"].ToString();

                    int nid = stringUtils.ConvertToInt(reader["_AccountHolderNID"].ToString());

                    double Balance = stringUtils.ConvertToDouble(reader["_Balance"].ToString());

                    Date date = stringUtils.ConvertToDate(reader["_Date"].ToString());

                    Account account = new Account(ac_no,nid,name,Balance,date);

                    Bank.AllAccountList.Add(account);
                }

                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SaveSavingsAccounttoDb(SavingsAccount savingsAccount)
        {
            try
            {
                conn.Open();

                string sql = "Insert into SavingsAccount(AccountNumber,_AccountHolderName,_AccountHolderNID,_Balance,_Date,_LastInterestDate,_LastWithdrawDate) values" + "(@acno,@name,@nid,@balance,@date,@lastInterestDate,@lastWithdrawDate)";
                cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("@acno", savingsAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@name", savingsAccount.AccountHolderName);
                cmd.Parameters.AddWithValue("@nid", savingsAccount.AccountHolderNID);
                cmd.Parameters.AddWithValue("@balance", savingsAccount.Balance);
                cmd.Parameters.AddWithValue("@date", stringUtils.ConvertDateToString(savingsAccount.OpeningDate));
                cmd.Parameters.AddWithValue("@lastInterestDate", stringUtils.ConvertDateToString(savingsAccount.LastInterestDate));
                cmd.Parameters.AddWithValue("@lastWithdrawDate", stringUtils.ConvertDateToString(savingsAccount.LastWithdrawDate));

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LoadSavingsAccountToList()
        {
            Bank.SavingsAccountList.Clear();

            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
                conn.Open();
                string sql = "Select * from SavingsAccount";

                cmd = new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ac_no = stringUtils.ConvertToInt(reader["AccountNumber"].ToString());

                    string name = reader["_AccountHolderName"].ToString();

                    int nid = stringUtils.ConvertToInt(reader["_AccountHolderNID"].ToString());

                    double Balance = stringUtils.ConvertToDouble(reader["_Balance"].ToString());

                    Date date = stringUtils.ConvertToDate(reader["_Date"].ToString());

                    Date last_interest_date = stringUtils.ConvertToDate(reader["_LastInterestDate"].ToString());

                    Date LastWithdrawDate = stringUtils.ConvertToDate(reader["_LastWithdrawDate"].ToString());

                    SavingsAccount savingsAc = new SavingsAccount(ac_no, nid, name, Balance, date,last_interest_date,LastWithdrawDate);

                    Bank.SavingsAccountList.Add(savingsAc);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoadCustomerToBankList()
        {
            Bank.CustomerList.Clear();
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
                conn.Open ();
                string sql = "Select * from Customer";

                cmd = new OleDbCommand (sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                   int nid  = stringUtils.ConvertToInt(reader["_NID"].ToString());

                    string name = reader["_uname"].ToString();

                    string password = reader["_pass"].ToString();
                   

                    Customer temp = new Customer(name, nid, password);

                    Bank.CustomerList.Add(temp);
                }

                conn.Close ();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void TransactionUpdateOnSavingsTable(int ac_no, double amount)
        {
           
                string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE SavingsAccount SET _Balance = ? WHERE AccountNumber = ?";

                        using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Balance", amount);
                            command.Parameters.AddWithValue("@AccountNumber", ac_no);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Update successful!");
                            }
                            else
                            {
                                Console.WriteLine("Account not found or no update needed.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            
        }
    }
}

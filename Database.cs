﻿using System;
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

        private void TransactionUpdateOnAccountTable(Account account)
        {
            string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE Accounts SET _Balance = ? WHERE AccountNumber = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Balance", account.Balance);

                        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);

                        command.ExecuteNonQuery();   
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void SaveSavingsAccounttoDb(SavingsAccount savingsAccount)
        {
            try
            {
                conn.Open();

                string sql = "Insert into SavingsAccount(AccountNumber,_AccountHolderName,_AccountHolderNID,_Balance,_Date,_LastInterestDate,_LastWithdrawDate,_withdrawCount) values" + "(@acno,@name,@nid,@balance,@date,@lastInterestDate,@lastWithdrawDate,@withdrawCount)";
                cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("@acno", savingsAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@name", savingsAccount.AccountHolderName);
                cmd.Parameters.AddWithValue("@nid", savingsAccount.AccountHolderNID);
                cmd.Parameters.AddWithValue("@balance", savingsAccount.Balance);
                cmd.Parameters.AddWithValue("@date", stringUtils.ConvertDateToString(savingsAccount.OpeningDate));
                cmd.Parameters.AddWithValue("@lastInterestDate", stringUtils.ConvertDateToString(savingsAccount.LastInterestDate));
                cmd.Parameters.AddWithValue("@lastWithdrawDate", stringUtils.ConvertDateToString(savingsAccount.LastWithdrawDate));
                cmd.Parameters.AddWithValue("@withdrawCount", 0);
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
                    savingsAc.setWithdrawalCount(stringUtils.ConvertToInt(reader["_withdrawCount"].ToString()));

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

        public void TransactionUpdateOnSavingsTable(SavingsAccount s_account)
        {
            TransactionUpdateOnAccountTable(s_account);
            string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE SavingsAccount SET _Balance = ?,_withdrawCount= ? ,_LastWithdrawDate= ? WHERE AccountNumber = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Balance", s_account.Balance);

                        command.Parameters.AddWithValue("@withdrawCount", s_account.getWithdrawCount());
                       

                        command.Parameters.AddWithValue("@LastWithdrawDate", stringUtils.ConvertDateToString(s_account.LastWithdrawDate));

                        command.Parameters.AddWithValue("@AccountNumber", s_account.AccountNumber);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Operation Done Successfully!");
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
        public void DepositOnSavingsTable(SavingsAccount s_account)
        {
           
                string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE SavingsAccount SET _Balance = ?,_withdrawCount= ? WHERE AccountNumber = ?";

                        using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Balance", s_account.Balance);
                            command.Parameters.AddWithValue("@withdrawCount",s_account.getWithdrawCount());
                            command.Parameters.AddWithValue("@AccountNumber", s_account.AccountNumber);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Operation Done Successfully!");
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
        


        public void SaveCurrentAccounttoDb(CurrentAccount currentaccount) 
        {

            try
            {

                conn.Open();

                string sql = "Insert into CurrentAccount(AccountNumber,_AccountHolderName,_AccountHolderNID,_Balance,_Date,_LastInterestDate) values" + "(@acno,@name,@nid,@balance,@date,@lastInterestDate)";


                cmd = new OleDbCommand(sql, conn);


                cmd.Parameters.AddWithValue("@acno", currentaccount.AccountNumber);

                cmd.Parameters.AddWithValue("@name", currentaccount.AccountHolderName);

                cmd.Parameters.AddWithValue("@nid", currentaccount.AccountHolderNID);

                cmd.Parameters.AddWithValue("@balance", currentaccount.Balance);

                cmd.Parameters.AddWithValue("@date", stringUtils.ConvertDateToString(currentaccount.OpeningDate));

                cmd.Parameters.AddWithValue("@lastInterestDate", stringUtils.ConvertDateToString(currentaccount.LastInterestDate));

                cmd.ExecuteNonQuery();



                conn.Close();
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);


            }

        }





        public void LoadCurrentAccountToList()
        {

            Bank.CurrentAccountList.Clear();


            try
            {

                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
                conn.Open();

                String sql = "Select * from CurrentAccount";

                cmd=new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {

                    int ac_no = stringUtils.ConvertToInt(reader["AccountNumber"].ToString());

                    string name = reader["_AccountHolderName"].ToString();

                    int nid = stringUtils.ConvertToInt(reader["_AccountHolderNID"].ToString());

                    double balance = stringUtils.ConvertToDouble(reader["_Balance"].ToString());

                    Date date = stringUtils.ConvertToDate(reader["_Date"].ToString());

                    Date LastInterestDate = stringUtils.ConvertToDate(reader["_LastInterestDate"].ToString()) ;

                    CurrentAccount currentAccount = new CurrentAccount(ac_no, nid, name, balance, date, LastInterestDate);

                    Bank.CurrentAccountList.Add(currentAccount);

                }

                conn.Close();

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        



        public void TransactionUpdateOnCurrentTable(CurrentAccount currentaccount)
        {
            TransactionUpdateOnAccountTable(currentaccount);
            string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE CurrentAccount SET _Balance = ? WHERE AccountNumber = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Balance", currentaccount.Balance);


                        command.Parameters.AddWithValue("@AccountNumber", currentaccount.AccountNumber);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Operation Done Successfully!");
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



        public void DepositOnCurrentTable(CurrentAccount currentaccount)
        {

            string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE CurrentAccount SET _Balance = ? WHERE AccountNumber = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Balance", currentaccount.Balance);
                        
                        command.Parameters.AddWithValue("@AccountNumber", currentaccount.AccountNumber);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Operation Done Successfully!");
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


        public void SaveIslamicAccounttoDb(IslamicAccount islamicAccount)
        {


            try
            {
                conn.Open();

                string sql = "Insert into IslamicAccount(AccountNumber,_AccountHolderName,_AccountHolderNID,_Balance,_Date,_LastWithdrawDate,_withdrawCount) values" + "(@acno,@name,@nid,@balance,@date,@lastWithdrawDate,@withdrawCount)";
                cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("@acno", islamicAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@name", islamicAccount.AccountHolderName);
                cmd.Parameters.AddWithValue("@nid", islamicAccount.AccountHolderNID);
                cmd.Parameters.AddWithValue("@balance", islamicAccount.Balance);
                cmd.Parameters.AddWithValue("@date", stringUtils.ConvertDateToString(islamicAccount.OpeningDate));
                cmd.Parameters.AddWithValue("@lastWithdrawDate", stringUtils.ConvertDateToString(islamicAccount.LastWithdrawDate));
                cmd.Parameters.AddWithValue("@withdrawCount", 0);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LoadIslamicAccountToList()
        {
            Bank.IslamicAccountList.Clear();

            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
                conn.Open();
                string sql = "Select * from IslamicAccount";

                cmd = new OleDbCommand(sql, conn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ac_no = stringUtils.ConvertToInt(reader["AccountNumber"].ToString());

                    string name = reader["_AccountHolderName"].ToString();

                    int nid = stringUtils.ConvertToInt(reader["_AccountHolderNID"].ToString());

                    double Balance = stringUtils.ConvertToDouble(reader["_Balance"].ToString());

                    Date date = stringUtils.ConvertToDate(reader["_Date"].ToString());

                    Date LastWithdrawDate = stringUtils.ConvertToDate(reader["_LastWithdrawDate"].ToString());

                    IslamicAccount islamicAc = new IslamicAccount(ac_no, nid, name, Balance, date, LastWithdrawDate);
                    islamicAc.setWithdrawalCount(stringUtils.ConvertToInt(reader["_withdrawCount"].ToString()));

                    Bank.IslamicAccountList.Add(islamicAc);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void TransactionUpdateOnIslamicTable(IslamicAccount islamic_account)
        {
            TransactionUpdateOnAccountTable(islamic_account);
            string connectionString = "Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE IslamicAccount SET _Balance = ?,_withdrawCount= ? ,_LastWithdrawDate= ? WHERE AccountNumber = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Balance", islamic_account.Balance);

                        command.Parameters.AddWithValue("@withdrawCount", islamic_account.getWithdrawalCount());


                        command.Parameters.AddWithValue("@LastWithdrawDate", stringUtils.ConvertDateToString(islamic_account.LastWithdrawDate));

                        command.Parameters.AddWithValue("@AccountNumber", islamic_account.AccountNumber);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Operation Done Successfully!");
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

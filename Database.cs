﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace BANKSOLID
{
    public class Database
    {

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =Bank.accdb");
        OleDbCommand cmd;
       
        public void SaveCustomerToDb(Customer customer)
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
    }
}
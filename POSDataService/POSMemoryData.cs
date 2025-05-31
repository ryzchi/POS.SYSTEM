using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using POSCommon;

namespace POSDataService
{
    public class POSMemoryData : IPOSAccData
    {
        private string connectionString = "Data Source=LAPTOP-ALICAWAY\\SQLEXPRESS01;Initial Catalog=DB_POS;Integrated Security=True;TrustServerCertificate=True;";

        public List<POSAccount> GetAccounts()
        {
            var accounts = new List<POSAccount>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Username, Password FROM Admin";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(new POSAccount
                    {
                        Username = reader["Username"].ToString().Trim(),
                        Password = reader["Password"].ToString().Trim()
                    });
                }
            }

            return accounts;
        }
    }
}

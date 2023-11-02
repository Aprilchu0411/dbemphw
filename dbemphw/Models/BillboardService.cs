using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dbemphw.Models
{
    public class BillboardService
    {
        private readonly string connStr = "Data Source=Aprilchu\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public List<Billboard> GetBillboards() 
        {
            List<Billboard> billboards = new List<Billboard>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Billboard");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Billboard billboard = new Billboard
                    {
                        cId = reader.GetString(reader.GetOrdinal("cId")),
                        bNum = reader.GetString(reader.GetOrdinal("bNum")),
                        bDate = reader.GetDateTime(reader.GetOrdinal("bDate")),
                        bName = reader.GetString(reader.GetOrdinal("bName")),

                    };
                    billboards.Add(billboard);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return billboards;
        }
    }
}
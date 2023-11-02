using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dbemphw.Models
{
    public class SingerService
    {
        private readonly string connStr = "Data Source=Aprilchu\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public List<Singer> GetSingers()
        {
            List<Singer> singers = new List<Singer>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Singer");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Singer singer = new Singer
                    {
                        zId = reader.GetString(reader.GetOrdinal("zId")),
                        zAge = reader.GetString(reader.GetOrdinal("zAge")),
                        zDate = reader.GetDateTime(reader.GetOrdinal("zDate")),
                        zCompany = reader.GetString(reader.GetOrdinal("zCompany")),
                        zName = reader.GetString(reader.GetOrdinal("zName")),
                        zDesc = reader.GetString(reader.GetOrdinal("zDesc")),

                    };
                    singers.Add(singer);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return singers;
        }
        public Singer GetSingerByID(string zId)
        {
            Singer singer = new Singer();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Singer where zId=@zId");
            sqlCommand.Parameters.Add(new SqlParameter("zId", zId));

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    singer = new Singer
                    {
                        zId = reader.GetString(reader.GetOrdinal("zId")),
                        zAge = reader.GetString(reader.GetOrdinal("zAge")),
                        zDate = reader.GetDateTime(reader.GetOrdinal("zDate")),
                        zCompany = reader.GetString(reader.GetOrdinal("zCompany")),
                        zName = reader.GetString(reader.GetOrdinal("zName")),
                        zDesc = reader.GetString(reader.GetOrdinal("zDesc")),
                    };
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return singer;
        }
        public void NewSinger(Singer singer)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Singer(zId,zAge,zDate,zCompany,zName,zDesc)
                                                   VALUES(@zId,@zAge,@zDate,@zCompany,@zName,@zDesc)");
            sqlCommand.Parameters.Add(new SqlParameter("zId", singer.zId));
            sqlCommand.Parameters.Add(new SqlParameter("zAge", singer.zAge));
            sqlCommand.Parameters.Add(new SqlParameter("zDate", singer.zDate));
            sqlCommand.Parameters.Add(new SqlParameter("zCompany", singer.zCompany));
            sqlCommand.Parameters.Add(new SqlParameter("zName", singer.zName));
            sqlCommand.Parameters.Add(new SqlParameter("zDesc", singer.zDesc));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        private void ExecuteCmd(SqlCommand cmd)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateSinger(Singer singer)
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE Singer SET zDesc=@zDesc,zAge=@zAge,zDate=@zDate,zCompany=@zCompany,zName=@zName WHERE zId=@zId");
            sqlCommand.Parameters.Add(new SqlParameter("zId", singer.zId));
            sqlCommand.Parameters.Add(new SqlParameter("zAge", singer.zAge));
            sqlCommand.Parameters.Add(new SqlParameter("zDate", singer.zDate));
            sqlCommand.Parameters.Add(new SqlParameter("zCompany", singer.zCompany));
            sqlCommand.Parameters.Add(new SqlParameter("zName", singer.zName));
            sqlCommand.Parameters.Add(new SqlParameter("zDesc", singer.zDesc));
            ExecuteCmd(sqlCommand);
        } 
        public void DeleteSinger(string id)
    {
        //建立連線
        SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM Singer
                                                    Where zId = @zId");

        sqlCommand.Parameters.Add(new SqlParameter("zId", id));
        ExecuteCmd(sqlCommand);
    }
    }
   
}
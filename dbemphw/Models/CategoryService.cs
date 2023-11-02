using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace dbemphw.Models
{
    public class CategoryService
    {
        private readonly string connStr = "Data Source=Aprilchu\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public List<Category> GetCategory()
        {
            List<Category> categorys = new List<Category>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Category");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category category = new Category
                    {
                        cId = reader.GetString(reader.GetOrdinal("cId")),
                        cName = reader.GetString(reader.GetOrdinal("cName")),
                        cDesc = reader.GetString(reader.GetOrdinal("cDesc")),

                    };
                    categorys.Add(category);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return categorys;
        }
        public Category GetCategoryByID(string cId)
        {
            Category category = new Category();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Category where cId=@cId");
            sqlCommand.Parameters.Add(new SqlParameter("cId", cId));

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    category = new Category
                    {
                        cId = reader.GetString(reader.GetOrdinal("cId")),
                        cName = reader.GetString(reader.GetOrdinal("cName")),
                        cDesc = reader.GetString(reader.GetOrdinal("cDesc")),
                    };
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return category;
        }
        public void NewCategory(Category category)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Category(cId,cName,cDesc)
                                                   VALUES(@cId,@cName,@cDesc)");
            sqlCommand.Parameters.Add(new SqlParameter("cId", category.cId));
            sqlCommand.Parameters.Add(new SqlParameter("cName", category.cName));
            sqlCommand.Parameters.Add(new SqlParameter("cDesc", category.cDesc));
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
        public void UpdateCategory(Category category)
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE Category SET cDesc=@cDesc,cName=@cName WHERE cId=@cId");
            sqlCommand.Parameters.Add(new SqlParameter("cId", category.cId));
            sqlCommand.Parameters.Add(new SqlParameter("cName", category.cName));
            sqlCommand.Parameters.Add(new SqlParameter("cDesc", category.cDesc));
            ExecuteCmd(sqlCommand);
        }
        public void DeleteCategory(string id)
        {
            //建立連線
            SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM Category
                                                    Where cId = @cId");

            sqlCommand.Parameters.Add(new SqlParameter("cId", id));
            ExecuteCmd(sqlCommand);
        }
    }

}
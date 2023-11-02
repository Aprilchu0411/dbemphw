using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Xml.Linq;

namespace dbemphw.Models
{
    public class AlbumService
    {
        private readonly string connStr = "Data Source=Aprilchu\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public List<Album> GetAlbum()
        {
            List<Album> albums = new List<Album>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Album");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Album album = new Album
                    {
                        aId = reader.GetString(reader.GetOrdinal("aId")),
                        aName = reader.GetString(reader.GetOrdinal("aName")),
                        aDate = reader.GetDateTime(reader.GetOrdinal("aDate")),
                        aTurnoner = reader.GetString(reader.GetOrdinal("aTurnoner")),
                        zId = reader.GetString(reader.GetOrdinal("zId")),
                    };
                    albums.Add(album);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return albums;
        }
        public Album GetAlbumByID(string aId)
        {
            Album album = new Album();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Album where aId=@aId");
            sqlCommand.Parameters.Add(new SqlParameter("aId", aId));

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    album = new Album
                    {
                        aId = reader.GetString(reader.GetOrdinal("aId")),
                        aName = reader.GetString(reader.GetOrdinal("aName")),
                        aTurnoner = reader.GetString(reader.GetOrdinal("aTurnoner")),
                        aDate = reader.GetDateTime(reader.GetOrdinal("aDate")),
                        zId = reader.GetString(reader.GetOrdinal("zId")),
                    };
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return album;
        }
        public void NewAlbum(Album album)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Album(aId,aName,aTurnoner,aDate,zId)
                                                   VALUES(@aId,@aName,@aTurnoner,@aDate,@zId)");
            sqlCommand.Parameters.Add(new SqlParameter("aId", album.aId));
            sqlCommand.Parameters.Add(new SqlParameter("aName", album.aName));
            sqlCommand.Parameters.Add(new SqlParameter("aTurnoner", album.aTurnoner));
            sqlCommand.Parameters.Add(new SqlParameter("aDate", album.aDate));
            sqlCommand.Parameters.Add(new SqlParameter("zId", album.zId));
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
        public void UpdateAlbum(Album album)
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE Album SET aName=@aName,aTurnoner=@aTurnoner,aDate=@aDate,zId=@zId WHERE aId=@aId");
            sqlCommand.Parameters.Add(new SqlParameter("aId", album.aId));
            sqlCommand.Parameters.Add(new SqlParameter("aTurnoner", album.aTurnoner));
            sqlCommand.Parameters.Add(new SqlParameter("aDate", album.aDate));
            sqlCommand.Parameters.Add(new SqlParameter("aName", album.aName));
            sqlCommand.Parameters.Add(new SqlParameter("zId", album.zId));
            ExecuteCmd(sqlCommand);
        }
        public void DeleteAlbum(string id)
        {
            //建立連線
            SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM Album
                                                    Where aId = @aId");

            sqlCommand.Parameters.Add(new SqlParameter("aId", id));
            ExecuteCmd(sqlCommand);
        }
    }

}
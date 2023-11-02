using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dbemphw.Models
{
    public class ProductService
    {
        private readonly string connStr = "Data Source=Aprilchu\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public List<Song> GetSongs()
        {
            List<Song> songs = new List<Song>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Song");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Song song = new Song
                    {
                        sId = reader.GetString(reader.GetOrdinal("sId")),
                        sName = reader.GetString(reader.GetOrdinal("sName")),
                        sComposer = reader.GetString(reader.GetOrdinal("sComposer")),
                        sLyricist = reader.GetString(reader.GetOrdinal("sLyricist")),
                        sLyrics = reader.GetString(reader.GetOrdinal("sLyrics")),
                        sMv = reader.GetString(reader.GetOrdinal("sMv")),

                    };
                    songs.Add(song);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return songs;
        }
        public Song GetSongByID(string id)
        {
            Song song = new Song();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Song where sId=@sId");
            sqlCommand.Parameters.Add(new SqlParameter("sId", id));

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    song = new Song
                    {
                        sId = reader.GetString(reader.GetOrdinal("sId")),
                        sName = reader.GetString(reader.GetOrdinal("sName")),
                        sComposer = reader.GetString(reader.GetOrdinal("sComposer")),
                        sLyricist = reader.GetString(reader.GetOrdinal("sLyricist")),
                        sLyrics = reader.GetString(reader.GetOrdinal("sLyrics")),
                        sMv = reader.GetString(reader.GetOrdinal("sMv")),
                    };
                }
            }
            else
            {
                Console.WriteLine("資料庫為空!");
            }
            sqlConnection.Close();
            return song;
        }
        private void ExecuteCmd(SqlCommand cmd)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateSong(Song song)
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE Song SET sName=@sName,sComposer=@sComposer,sLyricist=@sLyricist,sLyrics=@sLyrics,sMv=@sMv WHERE sId=@sId");
            sqlCommand.Parameters.Add(new SqlParameter("sId", song.sId));
            sqlCommand.Parameters.Add(new SqlParameter("sName", song.sName));
            sqlCommand.Parameters.Add(new SqlParameter("sComposer", song.sComposer));
            sqlCommand.Parameters.Add(new SqlParameter("sLyricist", song.sLyricist));
            sqlCommand.Parameters.Add(new SqlParameter("sLyrics", song.sLyrics));
            sqlCommand.Parameters.Add(new SqlParameter("sMv", song.sMv));
            ExecuteCmd(sqlCommand);
        }
        public void NewProduct(Song song)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Song(sId,sName,sComposer,sLyricist,sLyrics,sMv)
                                                   VALUES(@sId,@sName,@sComposer,@sLyricist,@sLyrics,@sMv)");
            sqlCommand.Parameters.Add(new SqlParameter("sId", song.sId));
            sqlCommand.Parameters.Add(new SqlParameter("sName", song.sName));
            sqlCommand.Parameters.Add(new SqlParameter("sComposer", song.sComposer));
            sqlCommand.Parameters.Add(new SqlParameter("sLyricist", song.sLyricist));
            sqlCommand.Parameters.Add(new SqlParameter("sLyrics", song.sLyrics));
            sqlCommand.Parameters.Add(new SqlParameter("sMv", song.sMv));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void DeleteSong(string id)
        {
            //建立連線
            SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM Song
                                                    Where sId = @sId");

            sqlCommand.Parameters.Add(new SqlParameter("sId", id));
            ExecuteCmd(sqlCommand);
        }
    }

    }

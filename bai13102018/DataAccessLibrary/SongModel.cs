using bai13102018.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai13102018.DataAccessLibrary
{
    class SongModel
    {
        public static void Add(Song song)
        {
            using (SqliteConnection db = new SqliteConnection(DataAccess.SQL_CONNECTION_STRING))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Songs (name,thumbnail) VALUES (@name, @thumbnail);";
                insertCommand.Parameters.AddWithValue("@name", song.name);
                insertCommand.Parameters.AddWithValue("@thumbnail", song.thumbnail);
                insertCommand.ExecuteReader();

            

            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
                new SqliteConnection(DataAccess.SQL_CONNECTION_STRING))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Songs", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {

                    //entries.Add(query.GetString(0)); 

                    entries.Add(query.GetString(1));

                    entries.Add(query.GetString(2));

                }


            }

            return entries;
        }
    }
}


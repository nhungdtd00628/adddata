using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai13102018.DataAccessLibrary
{
    class DataAccess
    {
        public static string SQL_CONNECTION_STRING =
              "Filename = song_manager.db";
        public static void InitializeDatabase()

        {
            using (SqliteConnection db =
                new SqliteConnection(SQL_CONNECTION_STRING))
            {
                db.Open();
                // khó hiểu nhể. ko tự tăng - ko auto - cũng thầy bảo nó tự có nhưng của chị nó cho null hết.có sai chỗ nào k?

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Songs (id INTEGER(50) PRIMARY KEY , " +
                    "name NVACHAR(50) , thumbnail NVACHAR(50))";


                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}

    

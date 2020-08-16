using Microsoft.Ajax.Utilities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace ProchaskaHouseAPI.Code
{
    public class DatabaseCode
    {

        public string GetPeople()
        {
            string dbPath = Path.Combine(@"C:\Users\jooj9\source\repos\ProchaskaHouseAPI\Database", "Home.db");
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";
            SqliteConnection db;
            SqliteCommand dbCommand;

            db = new SqliteConnection(cs);
            db.Open();

            string sqlStatement = "Select * from People";
            string returnJSON = "{";

            dbCommand = new SqliteCommand(sqlStatement, db);

            SqliteDataReader dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
            {
                returnJSON += ($"{{\"ID\":{dbReader.GetInt32(0)}\n \"Name\": \"{dbReader.GetString(1)}\"}}");
            }
            

            return returnJSON + "}";

        }
    }
}
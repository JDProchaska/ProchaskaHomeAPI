using Microsoft.Ajax.Utilities;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using ProchaskaHouseAPI.Models;

namespace ProchaskaHouseAPI.Code
{
    public class DatabaseCode
    {
        string dbPath = Path.Combine(@"C:\Users\jooj9\source\repos\ProchaskaHomeAPI\Database", "Home.db");
        SQLiteConnection db;
        SQLiteCommand dbCommand;

        #region Chore Calls
        public List<Chore> GetChores()
        {
            List<Chore> chores = new List<Chore>();
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";

            db = new SQLiteConnection(cs);
            db.Open();

            string sqlStatement = "Select * from ChoresToBeDone";

            dbCommand = new SQLiteCommand(sqlStatement, db);
            using (var transaction = db.BeginTransaction())
            {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while (dbReader.Read())
                {
                    Chore chore = new Chore();
                    chore.Id = dbReader.GetInt32(0);
                    chore.Name = dbReader.GetString(1);
                    chore.Person = dbReader.GetString(2);
                    chore.Added = DateTime.Parse(dbReader.GetValue(3).ToString());
                    chores.Add(chore);
                }
            }


            return chores;
        }

        public bool AddChore(Chore chore)
        {
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";
            bool success = false;

            db = new SQLiteConnection(cs);
            db.Open();

            string sqlStatement = $"Insert into ChoresToBeDone (Id, Name, Person, AddedDate)" +
                $"Values ({chore.Id}, \"{chore.Name}\", \"{chore.Person}\", \"{chore.Added}\")";

            dbCommand = new SQLiteCommand(sqlStatement, db);
            using (var transaction = db.BeginTransaction())
            {
                dbCommand.ExecuteNonQuery();
                transaction.Commit();
                if (db.Changes > 0)
                    success = true;
            }
            db.Close();

            return success;
        }

        public void DeleteChore(Chore chore)
        {
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";

            db = new SQLiteConnection(cs);
            db.Open();

            string sqlStatement = $"Delete from Chore where name like {chore.Name}";
            dbCommand = new SQLiteCommand(sqlStatement, db);
            using (var transaction = db.BeginTransaction())
            {
                dbCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            db.Close();
        }
        #endregion

        #region Shopping List Calls
        public List<ShoppingListItem> GetShoppingList()
        {
            List<ShoppingListItem> items = new List<ShoppingListItem>();
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";

            db = new SQLiteConnection(cs);
            db.Open();

            string sqlStatement = "Select * from ShoppingList";

            dbCommand = new SQLiteCommand(sqlStatement, db);
            using (var transaction = db.BeginTransaction())
            {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while (dbReader.Read())
                {
                    ShoppingListItem item = new ShoppingListItem();
                    item.ID = dbReader.GetInt32(0);
                    item.Name = dbReader.GetString(1);
                    item.Qty = dbReader.GetInt32(2);
                    item.Checked = dbReader.GetInt32(3);
                    items.Add(item);
                }
            }


            return items;
        }
        public ShoppingListItem GetListItem(int id)
        {
            string cs = $"Data Source={dbPath}; Mode=ReadOnly;";
            ShoppingListItem resultItem = new ShoppingListItem();

            db = new SQLiteConnection(cs);
            db.Open();

            string sql = $"Select * from ShoppingList where ID = {id}";

            dbCommand = new SQLiteCommand(sql, db);
            using (var transaction = db.BeginTransaction())
            {
                SQLiteDataReader dbReader = dbCommand.ExecuteReader();

                while (dbReader.Read())
                {
                    ShoppingListItem item = new ShoppingListItem();
                    item.ID = dbReader.GetInt32(0);
                    item.Name = dbReader.GetString(1);
                    item.Qty = dbReader.GetInt32(2);
                    item.Checked = dbReader.GetInt32(3);

                    resultItem = item;
                }
            }

            return resultItem;
        }

        #endregion
    }
}
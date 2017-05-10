using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    class RankTable
    {
        public static string SQL_insert = "INSERT INTO \"Rank\" VALUES( @nazev,@skore)";

        public static bool Insert(string nazev, int skore)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_insert);
            command.Parameters.AddWithValue("@nazev", nazev);
            command.Parameters.AddWithValue("@skore", skore);
            db.ExecuteNonQuery(command);
            db.Close();
            return true;
        }
        public static void ChangeName(string OldName, string NewName, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand("ChangeNameRank");
            command.Parameters.AddWithValue("@oldName", OldName);
            command.Parameters.AddWithValue("@newName", NewName);

            command.CommandType = CommandType.StoredProcedure;

            db.ExecuteNonQuery(command);

            db.Close();
        }

        public static void PrepareCommand(SqlCommand command, Rank rank)
        {
            command.Parameters.AddWithValue("@rID", rank.Rid);
            command.Parameters.AddWithValue("@nazev", rank.Nazev);
            command.Parameters.AddWithValue("@skore", rank.Skore);

        }
    }
}

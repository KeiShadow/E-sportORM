using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    class DetailHraceTable
    {
        public static String SQL_UPDATE = "UPDATE Detail_Hrace set p_Her= @P_her, p_Vyher =@P_vyher, Skore = @skore,Pozice= @pozice where hid=@hid";

        public static void Update(int hid, int pocetHer, int pocetVyher, int skore, int pozice, Database pDb = null) {
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
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.AddWithValue("@hid", hid);
            command.Parameters.AddWithValue("@P_her", pocetHer);
            command.Parameters.AddWithValue("@p_Vyher", pocetVyher);
            command.Parameters.AddWithValue("@Skore", skore);
            command.Parameters.AddWithValue("@Pozice", pozice);

            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
        }

        public static bool RankUP(Database pDb = null) {
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


            SqlCommand command = db.CreateCommand("RankUp");
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();


            if (pDb == null)
            {
                db.Close();
            }

            return  true;
        }


        public static void PrepareCommand(SqlCommand command, Detail_Hrace Dhrac)
        {
            command.Parameters.AddWithValue("@DhId", Dhrac.Dhid);
            command.Parameters.AddWithValue("@hID", Dhrac.hid.Hid);
            command.Parameters.AddWithValue("@rId", Dhrac.rID.Rid);
            command.Parameters.AddWithValue("@P_her", Dhrac.P_her);
            command.Parameters.AddWithValue("@P_vyher", Dhrac.P_vyher);
            command.Parameters.AddWithValue("@skore", Dhrac.Skore);
            command.Parameters.AddWithValue("@pozice", Dhrac.Pozice);
        }


    }
}

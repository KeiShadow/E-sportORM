using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    class DetailTymuTable
    {

        public static String SQL_UPDATE = "UPDATE Detail_Hrace set pocet_her= @P_her, pocet_vyher =@P_vyher, popis=@popis, Pozice= @pozice where dtId = @dtId";

        public static int Update(Detail_tymu detail_tym, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, detail_tym);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;


        }


        private static void PrepareCommand(SqlCommand command, Detail_tymu Dtymu)
        {
            command.Parameters.AddWithValue("@dtId", Dtymu.Dtid);
            command.Parameters.AddWithValue("@pocet_her", Dtymu.Pocet_her);
            command.Parameters.AddWithValue("@pocet_vyher", Dtymu.Pocet_vyher);
            command.Parameters.AddWithValue("@popis", Dtymu.Popis);
            command.Parameters.AddWithValue("@pozice", Dtymu.Pozice);
        }
    }
}

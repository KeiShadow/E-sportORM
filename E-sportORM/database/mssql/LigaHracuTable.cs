using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    public class LigaHracuTable
    {
        public static string SQL_SELECT = "   select Nazev_ligy,pozadavek,ISNULL(pocet_hracu,0) as Pocet_hracu,\"status\",Vyhra,Datum_zacatku,Datum_Konce from Liga_hracu where status = \'Probíhající\'";
        public static string SQL_UPDATE = "UPDATE Liga_hracu SET Pozadavek=@pozadavek, Vyhra=@vyhra where Liga_hracu.Nazev_ligy=@nazevLigy ";

        public static bool CreateLiga(string table, string name, string pozadavek, string status, string vyhra, DateTime od, DateTime _do, Database pDb = null) {
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
            SqlCommand command = db.CreateCommand("CreateLiga");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@table",table);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pozadavek", pozadavek);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@Vyhra", vyhra);
            command.Parameters.AddWithValue("@od", od);
            command.Parameters.AddWithValue("@do", _do);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return true;
        }
        public static void Update(string pozadavek, string vyhra, string nazevLigy, Database pDb = null)
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
            command.Parameters.AddWithValue("@pozadavek", pozadavek);
            command.Parameters.AddWithValue("@vyhra", vyhra);
            command.Parameters.AddWithValue("@nazevLigy", nazevLigy);
            db.ExecuteNonQuery(command);

            db.Close();

        }
        public static Collection<Liga_hracu> DetialLigy()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);
            Collection<Liga_hracu> detail = Read(reader);
            reader.Close();
            db.Close();
            return detail;
        }

        private static Collection<Liga_hracu> Read(SqlDataReader reader)
        {
            Collection<Liga_hracu> polozky = new Collection<Liga_hracu>();
            while (reader.Read())
            {
                Liga_hracu polozka = new Liga_hracu();
                int i = -1;
                polozka.Nazev_ligy = reader.GetString(++i);
                polozka.Pozadavek = reader.GetString(++i);
                polozka.Pocet_hracu = reader.GetInt32(++i);
                polozka.Status = reader.GetString(++i);
                polozka.Vyhra = reader.GetString(++i);
                polozka.Datum_zacatku = reader.GetDateTime(++i);
                polozka.Datum_konce = reader.GetDateTime(++i);
                polozky.Add(polozka);
            }
            return polozky;
        }
        private static void PrepareCommand(SqlCommand command, Liga_hracu liga)
        {
            command.Parameters.AddWithValue("@Nazev", liga.Nazev_ligy);
            command.Parameters.AddWithValue("@pozadavek", liga.Pozadavek);
            command.Parameters.AddWithValue("@poc_tymu", liga.Pocet_hracu);
            command.Parameters.AddWithValue("@status", liga.Status);
            command.Parameters.AddWithValue("@vyhra", liga.Vyhra);
            command.Parameters.AddWithValue("@Datum_zacatku", liga.Datum_zacatku);
            command.Parameters.AddWithValue("@Datum_konce", liga.Datum_konce);
        }
    }
}

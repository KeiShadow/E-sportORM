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
    public class HracTable
    {
        public class tabulkaList
        {
            public string Nick_name { get; set; }

            public string Nazev_tymu { get; set; }

            public int? P_her { get; set; }

            public int? P_vyher { get; set; }
            public int? Skore { get; set; }

            public int? Pozice { get; set; }

            public string Nazev { get; set; }

        }

        public static String TABLE_NAME = "Hrac";
        public static String SQL_INSERT = " INSERT INTO HRAC (Nick_name) VALUES(@Name)";
        public static String SQL_SELECTDetail =
        " SELECT nick_name, dh.p_Her, dh.p_Vyher,dh.Pozice, dh.Skore, r.nazev as \"rank\",ISNULL(t.Nazev_tymu, 'Nepripojen') as Nazev_Tymu from tym t LEFT JOIN TymHrac th on th.Tym_tID =t.tID right JOIN hrac h on h.hID= th.Hrac_hID JOIN Nastaveni_Hrace n on h.hID= n.hId JOIN Detail_Hrace dh on dh.hID= h.hID JOIN \"rank\" r on r.rID = dh.rID and h.Nick_name = @Name";




        public static void Registration(string name, string pass, string email, string lokace, Database pDb = null) {
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

            SqlCommand command = db.CreateCommand("AddPlayer");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@name",name);
            command.Parameters.AddWithValue("@pass",pass);
            command.Parameters.AddWithValue("@email",email);
            command.Parameters.AddWithValue("@loc", lokace);

            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            
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

            SqlCommand command = db.CreateCommand("ChangeName");
            command.Parameters.AddWithValue("@oldName",OldName);
            command.Parameters.AddWithValue("@newName", NewName);

            command.CommandType = CommandType.StoredProcedure;

            db.ExecuteNonQuery(command);

            db.Close();
        }

        public static Collection<tabulkaList> FindPlayer(string parametr = null)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("findplayer");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@parametr", parametr);
            SqlDataReader reader = command.ExecuteReader();

            Collection<tabulkaList> detail = ReadTable(reader);

            reader.Close();
            db.Close();
            return detail;
        }

        public static Collection<tabulkaList> DetialHrace(string Nick)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECTDetail);
            command.Parameters.AddWithValue("@Name", Nick);
            SqlDataReader reader = db.Select(command);
            
            Collection<tabulkaList> detail = ReadDetail(reader);
            reader.Close();
            db.Close();
            return detail;
        }

        private static Collection<tabulkaList> ReadDetail(SqlDataReader reader)
        {
            Collection<tabulkaList> polozky = new Collection<tabulkaList>();

            while (reader.Read())
            {
                tabulkaList polozka = new tabulkaList();
                int i = -1;
                polozka.Nick_name = reader.GetString(++i);
                polozka.P_her = reader.GetInt32(++i);
                polozka.P_vyher = reader.GetInt32(++i);
                polozka.Pozice = reader.GetInt32(++i);
                polozka.Skore = reader.GetInt32(++i);
                polozka.Nazev = reader.GetString(++i);
                polozka.Nazev_tymu = reader.GetString(++i);
                polozky.Add(polozka);
            }
            return polozky;
        }

        private static Collection<tabulkaList> ReadTable(SqlDataReader reader)
        {
            Collection<tabulkaList> polozky = new Collection<tabulkaList>();

            while (reader.Read())
            {
                tabulkaList polozka = new tabulkaList();
                int i = -1;
                polozka.Nick_name = reader.GetString(++i);
                polozka.P_her = reader.GetInt32(++i);
                polozka.Nazev = reader.GetString(++i);
                polozka.Nazev_tymu = reader.GetString(++i);
                polozky.Add(polozka);
            }
            return polozky;
        }

       

        private static Collection<Hrac> Read(SqlDataReader reader)
        {
            Collection<Hrac> hraci = new Collection<Hrac>();

            while (reader.Read())
            {
                Hrac hrac = new Hrac();
                int i = -1;
                hrac.Nick_name = reader.GetString(++i);

                hraci.Add(hrac);
            }
            return hraci;
        }
        private static void PrepareCommand(SqlCommand command, Hrac hrac)
        {
            command.Parameters.AddWithValue("@Name", hrac.Nick_name);
            command.Parameters.AddWithValue("@hid", hrac.Hid);
          
        }
    }
}

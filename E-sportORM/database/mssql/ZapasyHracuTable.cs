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
    class ZapasyHracuTable
    {
        public static string SQL_INSERT = "INSERT INTO Zapasy_hracu VALUES(@idLigy,@HracA,@HracB,@SkoreA,@SkoreB,@Datum)"; 
        public static string SQL_SELECTDetail = "SELECT HracA, HracB, SkoreA, SkoreB, Datum_zapasu FROM Zapasy_hracu where zhID = @idzapasu";

        public static string SQL_SELECTWITHDATE = "select HracA,HracB,Datum_Zapasu from Zapasy_hracu where Datum_zapasu = @parametr";


        public static Collection<Zapasy_Hracu> SeznamZap(DateTime? datum=null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("ListOfHracZapas");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@parametr", datum);
            SqlDataReader reader = command.ExecuteReader();

            Collection<Zapasy_Hracu> zapasy = ReadSeznam(reader);
            reader.Close();
            db.Close();
            return zapasy;
        }


        public static Collection<Zapasy_Hracu> Detail(int idzapasu)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECTDetail);
            command.Parameters.AddWithValue("@idzapasu", idzapasu);
            SqlDataReader reader = db.Select(command);

            Collection<Zapasy_Hracu> zapasy = Read(reader);
            reader.Close();
            db.Close();
            return zapasy;
        }

        public static bool Insert(int liga, string hracA,string hracB, int skoreA, int skoreB,DateTime datum)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            command.Parameters.AddWithValue("@idLigy",liga);
            command.Parameters.AddWithValue("@HracA", hracA);
            command.Parameters.AddWithValue("@HracB", hracB);
            command.Parameters.AddWithValue("@SkoreA", skoreA);
            command.Parameters.AddWithValue("@SkoreB", skoreB);
            command.Parameters.AddWithValue("@Datum", datum);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return true;
        }

        private static Collection<Zapasy_Hracu> ReadSeznam(SqlDataReader reader)
        {
            Collection<Zapasy_Hracu> zapasy = new Collection<Zapasy_Hracu>();

            while (reader.Read())
            {
                Zapasy_Hracu zapas = new Zapasy_Hracu();
                int i = -1;
                zapas.Hraca = reader.GetString(++i);
                zapas.Hracb = reader.GetString(++i);
                zapas.Datum_zapasu = reader.GetDateTime(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }

        private static Collection<Zapasy_Hracu> Read(SqlDataReader reader)
        {
            Collection<Zapasy_Hracu> zapasy = new Collection<Zapasy_Hracu>();

            while (reader.Read())
            {
                Zapasy_Hracu zapas = new Zapasy_Hracu();
                int i = -1;
                zapas.Hraca = reader.GetString(++i);
                zapas.Hracb = reader.GetString(++i);
                zapas.Skorea = reader.GetInt32(++i);
                zapas.Skoreb = reader.GetInt32(++i);
                zapas.Datum_zapasu = reader.GetDateTime(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }


        private static void PrepareCommand(SqlCommand command, Zapasy_Hracu zapas)
        {
            command.Parameters.AddWithValue("@idLigy", zapas.Lhid);
            command.Parameters.AddWithValue("@HracA", zapas.Hraca);
            command.Parameters.AddWithValue("@HracB", zapas.Hracb);
            command.Parameters.AddWithValue("@SkoreA", zapas.Skorea);
            command.Parameters.AddWithValue("@SkoreB", zapas.Skoreb);
            command.Parameters.AddWithValue("@Datum", zapas.Datum_zapasu);

        }
    }
}

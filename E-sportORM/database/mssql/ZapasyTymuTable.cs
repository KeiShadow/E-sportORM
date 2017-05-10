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
    class ZapasyTymuTable
    {
        


        public static string SQL_INSERT = "INSERT INTO Zapasy_Tymu VALUES(@idLigy,@TymA,@TymB,@SkoreA,@SkoreB,@Datum)";
        public static string SQL_SELECTWITHDATE = "SELECT TymA, TymB, Datumzapasu FROM Zapasy_Tymu where Datumzapasu = @parametr";
        public static string SQL_SELECTDetail = "SELECT TymA, TymB, SkoreA, SkoreB, Datumzapasu FROM Zapasy_Tymu where zID = @idzapasu";
       

        public static bool Insert(int liga, string tymA, string tymB, int skoreA, int skoreB, DateTime datum)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            command.Parameters.AddWithValue("@idLigy", liga);
            command.Parameters.AddWithValue("@TymA", tymA);
            command.Parameters.AddWithValue("@TymB", tymB);
            command.Parameters.AddWithValue("@SkoreA", skoreA);
            command.Parameters.AddWithValue("@SkoreB", skoreB);
            command.Parameters.AddWithValue("@Datum", datum);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return true;
        }

        public static Collection<Zapasy_Tymu> SeznamZap(DateTime? datum = null)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("ListOfTymZapas");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@parametr", datum);
            SqlDataReader reader = command.ExecuteReader();

            Collection<Zapasy_Tymu> zapasy = ReadSeznam(reader);
            reader.Close();
            db.Close();
            return zapasy;
        }

        public static Collection<Zapasy_Tymu> Detail(int idzapasu)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECTDetail);
            command.Parameters.AddWithValue("@idzapasu", idzapasu);
            SqlDataReader reader = db.Select(command);

            Collection<Zapasy_Tymu> zapasy = Read(reader);
            reader.Close();
            db.Close();
            return zapasy;
        }

        private static Collection<Zapasy_Tymu> ReadSeznam(SqlDataReader reader)
        {
            Collection<Zapasy_Tymu> zapasy = new Collection<Zapasy_Tymu>();

            while (reader.Read())
            {
                Zapasy_Tymu zapas = new Zapasy_Tymu();
                int i = -1;
                zapas.Tyma = reader.GetString(++i);
                zapas.Tymb = reader.GetString(++i);
               
                zapas.Datumzapasu = reader.GetDateTime(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }
        private static Collection<Zapasy_Tymu> Read(SqlDataReader reader)
        {
            Collection<Zapasy_Tymu> zapasy = new Collection<Zapasy_Tymu>();

            while (reader.Read())
            {
                Zapasy_Tymu zapas = new Zapasy_Tymu();
                int i = -1;
                zapas.Tyma = reader.GetString(++i);
                zapas.Tymb = reader.GetString(++i);
                zapas.Skorea = reader.GetInt32(++i);
                zapas.Skoreb = reader.GetInt32(++i);
                zapas.Datumzapasu = reader.GetDateTime(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }

        private static void PrepareCommand(SqlCommand command, Zapasy_Tymu tym)
        {
            command.Parameters.AddWithValue("@idLigy", tym.Lid);
            command.Parameters.AddWithValue("@TymA", tym.Tyma);
            command.Parameters.AddWithValue("@TymB", tym.Tymb);
            command.Parameters.AddWithValue("@SkoreA", tym.Skorea);
            command.Parameters.AddWithValue("@SkoreB", tym.Skoreb);
            command.Parameters.AddWithValue("@Datum", tym.Datumzapasu);

        }
    }
}

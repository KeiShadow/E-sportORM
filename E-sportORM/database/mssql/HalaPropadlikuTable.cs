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
    class HalaPropadlikuTable
    {
        public class HalaSeznam {
            public int Hid { get; set; }
            public string Nick_name { get; set; }
            public string Popis { get; set; }
            public DateTime Datum_zablokovani { get; set; }
            public DateTime Doba_zablokovani { get; set; }

        }

        public static string SQL_INSERT = "INSERT INTO HALA_PROPADLIKU VALUES(@hID,@popis,@datum_zablokovani,@doba_zablokovani)";
        public static string SQL_SELECT = "SELECT nick_name, popis, Datum_zablokovani, doba_zablokovani from Hala_propadliku hp join hrac h on h.hID = hp.hID";

        public static bool Insert(int hracID, string popis, DateTime zablokovan, DateTime doba)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            command.Parameters.AddWithValue("@hID", hracID);
            command.Parameters.AddWithValue("@popis", popis);
            command.Parameters.AddWithValue("@datum_zablokovani", zablokovan);
            command.Parameters.AddWithValue("@doba_zablokovani", doba);
            SqlDataReader reader = command.ExecuteReader();

            Collection<Hala_propadliku> ligy = Read(reader);
            reader.Close();
            db.Close();
            return true;
        }
        public static Collection<HalaSeznam> Select()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<HalaSeznam> detail = ReadSeznam(reader);
            reader.Close();
            db.Close();
            return detail;
        }

        public static bool ExpiredBan()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand("ExpiredBan");
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            db.Close();
            return true;
        }

        private static Collection<HalaSeznam> ReadSeznam(SqlDataReader reader)
        {
            Collection<HalaSeznam> propadlici = new Collection<HalaSeznam>();

            while (reader.Read())
            {
                HalaSeznam propadlik = new HalaSeznam();
                int i = -1;

                propadlik.Nick_name = reader.GetString(++i);
                propadlik.Popis = reader.GetString(++i);
                propadlik.Datum_zablokovani = reader.GetDateTime(++i);
                propadlik.Doba_zablokovani = reader.GetDateTime(++i);
                propadlici.Add(propadlik);
            }
            return propadlici;
        }

        private static Collection<Hala_propadliku> Read(SqlDataReader reader)
        {
            Collection<Hala_propadliku> propadlici = new Collection<Hala_propadliku>();

            while (reader.Read())
            {
                Hala_propadliku propadlik = new Hala_propadliku();

                int i = -1;
                propadlik.Popis = reader.GetString(++i);
                propadlik.Datum_zablokovani = reader.GetDateTime(++i);
                propadlik.Doba_zablokovani = reader.GetDateTime(++i);
                propadlici.Add(propadlik);
            }
            return propadlici;
        }


        public static void PrepareCommand(SqlCommand command, Hala_propadliku hp)
        {

            command.Parameters.AddWithValue("@popis", hp.Popis);
            command.Parameters.AddWithValue("@datum_zablokovani", hp.Datum_zablokovani);
            command.Parameters.AddWithValue("@doba_zablokovani", hp.Doba_zablokovani);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    class NastaveniHraceTable
    {
        public static String SQL_UPDATE = "UPDATE Nastaveni_Hrace set Jmeno = @jmeno, Prijmeni = @lname, lokace = @lok from hrac h where h.Nick_name=@name";


        public static bool Update(string nick, string jmeno, string lname, string lok,Database pDb = null)
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

            command.Parameters.AddWithValue("@name", nick);
            command.Parameters.AddWithValue("@jmeno", jmeno);
            command.Parameters.AddWithValue("@lname", lname);
            command.Parameters.AddWithValue("@lok", lok);

            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return true;


        }
       

        public static void PrepareCommand(SqlCommand command,  Nastaveni_Hrace Nhrace)
        {
            command.Parameters.AddWithValue("@setID", Nhrace.Setid);
            command.Parameters.AddWithValue("@name", Nhrace.Jmeno);
            command.Parameters.AddWithValue("@lname", Nhrace.Prijmeni);
            command.Parameters.AddWithValue("@pass", Nhrace.Heslo);
            command.Parameters.AddWithValue("@Email", Nhrace.Email);
            command.Parameters.AddWithValue("@datum", Nhrace.Datum_zaregistrovani);
            command.Parameters.AddWithValue("@lok", Nhrace.Lokace);
        }
    }
}

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
    class TymTable
    {
        public class hracInteam {
            public string Nick_name { get; set; }

            public int Hid { get; set; }

            public int Tid { get; set; }

            public int Hrac_hid { get; set; }

            public int Tymy_tid { get; set; }

            public string Nazev_tymu { get; set; }
        }

        public static string SQL_INSERT = "INSERT INTO tymHrac VALUES((SELECT hID from hrac where hrac.Nick_name=@NazevHrace),(SELECT tID from tym where tym.Nazev_tymu=@NazevTymu))";
        public static String SQL_SELECT = "SELECT Nazev_tymu FROM tym";
        public static string SQL_HRACVTYMU = "select h.nick_name from tym t join TymHrac th on th.Tym_tID=t.tID join hrac h on h.hID = th.Hrac_hID and t.Nazev_tymu = @NazevTymu";

        /*Vložení hráče do týmu*/
        public static bool Insert(string NazevHrace, string NazevTymu)
        {
            Database db = new Database();
            db.Connect(); 
            SqlCommand command = db.CreateCommand("JoinToTeam");
            command.Parameters.AddWithValue("@nameOfPlayer", NazevHrace);
            command.Parameters.AddWithValue("@nameOfTeam", NazevTymu);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            db.Close();
            return true;
        }
        /*Vložení týmů do ligy*/
        public static bool JoinToLiga(string nameOfLiga, string team, Database pDb = null)
        {

            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("JoinToLiga");
            command.Parameters.AddWithValue("@nameOfLiga", nameOfLiga);
            command.Parameters.AddWithValue("@team", team);

            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            db.Close();
            return true;
        }

        /*Seznam týmů*/
        public static Collection<Tym> SeznamTymu()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);
          
            SqlDataReader reader = db.Select(command);

            Collection<Tym> detail = Read(reader);
            reader.Close();
            db.Close();
            return detail;
        }

        /*Seznam hráčů v týmu*/
        public static Collection<hracInteam> HraciVtymu(string nazevtymu)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_HRACVTYMU);
            command.Parameters.AddWithValue("@NazevTymu", nazevtymu);
            SqlDataReader reader = db.Select(command);

            Collection<hracInteam> detail = ReadHrac(reader);
            reader.Close();
            db.Close();
            return detail;
        }

        /*Vytvoření týmů*/
        public static void CreateTeam(string name, string popis, Database pDb = null)
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

            SqlCommand command = db.CreateCommand("CreateTeam");
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@popis", popis);
            command.CommandType = CommandType.StoredProcedure;

            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            
            
           
        }

        /*Read pro seznam týmů*/
        private static Collection<Tym> Read(SqlDataReader reader)
        {
            Collection<Tym> teams = new Collection<Tym>();

            while (reader.Read())
            {
                Tym team = new Tym();
                int i = -1;
                team.Nazev_tymu = reader.GetString(++i);

                teams.Add(team);
            }
            return teams;
        }
        /*Read pro hrace v tymu*/
        private static Collection<hracInteam> ReadHrac(SqlDataReader reader)
        {
            Collection<hracInteam> teams = new Collection<hracInteam>();

            while (reader.Read())
            {
                hracInteam team = new hracInteam();
                int i = -1;
                team.Nick_name = reader.GetString(++i);
                teams.Add(team);
            }
            return teams;
        }

        public static void PrepareCommand(SqlCommand command, Tym tymy)
        {
            command.Parameters.AddWithValue("@tId", tymy.Tid);
            command.Parameters.AddWithValue("@lId", tymy.Lid);
            command.Parameters.AddWithValue("@dtId", tymy.Tid);
            command.Parameters.AddWithValue("@Nazev_tymu", tymy.Nazev_tymu);
           
        }
    }
}

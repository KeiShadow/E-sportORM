using E_sportORM.database.mssql;
using E_sportORM.database;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using static E_sportORM.database.mssql.HracTable;
using static E_sportORM.database.mssql.TymTable;
using static E_sportORM.database.mssql.HalaPropadlikuTable;


namespace E_sportORM
{
    class Program
    {
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainMenu());
            /* Z důvodu neaktualizovatelných položek v zápasu týmů a lig, jsem nedělal procedůry pro aktualizaci zápasů.
               Omlouvám se během upravování analýzi jsme si nevšimnul starých funkcí, které jsem zapomněl odstranit.
               Během vývoje ORM jsem si všimnul dvou funkcí aktualizace zápasů lig a týmu, a při dlouhém přemýšlení,
               jsem zjistil že u těch to tabulek nelze nic aktualizovat.
               Děkuji za pochopení.
             */

           
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database.mssql
{
    class TymHracTable
    {
 
        public static void PrepareCommand(SqlCommand command, TymHrac tymH)
        {
            command.Parameters.AddWithValue("@idHrac", tymH.Hrac_hid);
            command.Parameters.AddWithValue("@idHrac", tymH.Tymy_tid);
          

        }
    }
}

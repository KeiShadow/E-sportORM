using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Detail_Hrace
    {
        public int Dhid { get; set; }
        //public int Hid { get; set; }
        public Hrac hid = new Hrac();
        //public int? Rid { get; set; }
        public Rank rID = new Rank();
        public int? P_her { get; set; }
        public int? P_vyher { get; set; }
        public int? Skore { get; set; }
        public int? Pozice { get; set; }
    }
}

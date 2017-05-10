using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Zapasy_Hracu
    {
        public int Zhid { get; set; }
        //public int Lhid { get; set; }
        public Liga_hracu Lhid = new Liga_hracu();
        public string Hraca { get; set;}
        public string Hracb { get; set;}
        public int Skorea { get; set; }
        public int Skoreb { get; set; }
        public DateTime Datum_zapasu { get; set; }
    }
}

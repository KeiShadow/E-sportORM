using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Zapasy_Tymu
    {
        public int Zid { get; set; }
        //public int Lid { get; set; }
        public Liga_Tymu Lid = new Liga_Tymu();
        public string Tyma { get; set;}
        public string Tymb { get; set;}
        public int Skorea { get; set; }
        public int Skoreb { get; set; }
        public DateTime Datumzapasu { get; set; }
    }
}

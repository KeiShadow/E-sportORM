using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Tym
    {
        public int Tid { get; set; }
        //public int? Lid { get; set; }
        public Liga_Tymu Lid = new Liga_Tymu();
        //public int Dtid { get; set; }
        public Detail_tymu dtID = new Detail_tymu();
        public string Nazev_tymu { get; set;}
    }
}

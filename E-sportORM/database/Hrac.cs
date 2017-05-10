using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Hrac
    {
        public int Hid { get; set; }
        public string Nick_name { get; set;}
        //public int? Lhid { get; set; }
        public Liga_hracu lhID = new Liga_hracu();

    }
}

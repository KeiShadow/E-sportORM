using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Detail_tymu
    {
        public int Dtid { get; set; }
        public int? Pocet_her { get; set; }
        public int? Pocet_vyher { get; set; }
        public int? Pozice { get; set; }
        public int? Skore { get; set; }
        public string Popis { get; set;}
        
        public int? Pocet_hracu { get; set; }
}
}

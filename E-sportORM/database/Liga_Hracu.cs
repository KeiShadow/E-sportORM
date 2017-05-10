using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Liga_hracu
    {
        public int Lhid { get; set; }
        public string Nazev_ligy { get; set;}
        public string Pozadavek { get; set;}
        public int? Pocet_hracu { get; set; }
        public string Status { get; set;}
	    public DateTime Datum_zacatku { get; set; }
        public DateTime Datum_konce { get; set; }
        public string Vyhra { get; set; }
    }
}

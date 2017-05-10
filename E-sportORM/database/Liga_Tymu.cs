using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Liga_Tymu
    {
        public int Lid { get; set; }
        public string Nazev_ligy { get; set;}
        public string Pozadavek { get; set;}
        public int Poc_tymu { get; set; }
        public string Status { get; set;}
	    public string Vyhra { get; set;}
	    public DateTime? Datum_zacatku { get; set; }
        public DateTime? Datum_konce { get; set; }
    }
}

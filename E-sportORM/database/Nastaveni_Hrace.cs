using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Nastaveni_Hrace
    {
        public int Setid { get; set; }
        public Hrac Hid = new Hrac();
        public string Jmeno { get; set;}
        public string Prijmeni { get; set; }
        public string Heslo { get; set;}
        public string Email { get; set;}
    	public string Lokace { get; set; }
        public DateTime Datum_zaregistrovani { get; set; }
    }
}

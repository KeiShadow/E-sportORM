using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_sportORM.database
{
    public class Hala_propadliku
    {
        public int Hpid { get; set; }
        //public int Hid { get; set; }
        public Hrac Hid = new Hrac();
        public string Popis { get; set;}
        public DateTime Datum_zablokovani { get; set; }
        public DateTime Doba_zablokovani { get; set; }
    }
}

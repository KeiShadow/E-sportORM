using E_sportORM.database;
using E_sportORM.database.mssql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_sportORM.Forms
{
    public partial class Liga : Form
    {
        public Liga()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Connect();
            string table = typ.SelectedItem.ToString();
            string name = NameOfTeam.Text;
            string pozadavek = Poz.SelectedItem.ToString();
            string status = Status.SelectedItem.ToString();
            string vyhra = Win.Text;
            DateTime od = OD.SelectionRange.Start;
            DateTime _do = DO.SelectionRange.Start;

            if ((table != "" || name != "" || pozadavek != "" || status != "" || vyhra != "") && (od != _do)) {
                if (table == "Týmová liga")
                {
                    LigaTymuTable.CreateLiga(table, name, pozadavek, status, vyhra, od, _do);
                    Console.WriteLine("Seznam ligy týmů");
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-15}{5,-15:D}{6,31:D}", "Název ligy", "Požadavek", "Počet týmů", "Status", "Výhra", "Datum začátku", "Datum konce");
                    Collection<Liga_Tymu> lts = LigaTymuTable.DetialLigy();
                    foreach (Liga_Tymu lt in lts)
                    {
                        Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-15}{5,-15:D}{6,35:D}",
                          lt.Nazev_ligy, lt.Pozadavek, lt.Poc_tymu, lt.Status, lt.Vyhra, lt.Datum_zacatku, lt.Datum_konce);
                    }
                    Console.WriteLine(" ");

                }
                else if (table == "Hráčská liga") {
                    LigaHracuTable.CreateLiga(table, name, pozadavek, status, vyhra, od, _do);
                    Console.WriteLine(" ");
                    Console.WriteLine("Seznam ligy hráčů");
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-15}{5,-15:D}{6,31:D}", "Název ligy", "Požadavek", "Počet hráčů", "Status", "Výhra", "Datum začátku", "Datum konce");
                    Collection<Liga_hracu> lhs = LigaHracuTable.DetialLigy();
                    foreach (Liga_hracu lh in lhs)
                    {
                        Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-15}{5,-15:D}{6,35:D}",
                          lh.Nazev_ligy, lh.Pozadavek, lh.Pocet_hracu, lh.Status, lh.Vyhra, lh.Datum_zacatku, lh.Datum_konce);
                    }
                    Console.WriteLine(" ");
                }
                else
                {
                    MessageBox.Show("Vyplňte všechny údaje!");

                }
            }
            db.Close();

        }
    }
}

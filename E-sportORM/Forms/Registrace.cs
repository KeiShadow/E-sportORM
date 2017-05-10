using E_sportORM.database.mssql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static E_sportORM.database.mssql.HracTable;

namespace E_sportORM.Forms
{
    public partial class Registrace : Form
    {
        public Registrace()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Connect();

           
            string name = Nick.Text;
            string email = Email.Text;
            string heslo = Pass.Text;
            string lokace = State.SelectedItem.ToString();
           

            if (heslo.Length < 6)
            {
                MessageBox.Show("Heslo je krátké, heslo musí být delší než 6 znaků.");
            }
            else if(name.ToString() !="" || name.ToString() != "" || name.ToString() != "") {
                HracTable.Registration(name, email, heslo, lokace);

                Console.WriteLine("Seznam hráčů");
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-15}", "Nick hráče", "Počet her", "Rank", "Název týmu");

                foreach (tabulkaList h in HracTable.FindPlayer())
                {
                    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-15}",
                        h.Nick_name, h.P_her, h.Nazev, h.Nazev_tymu);
                }
                Console.WriteLine(" ");

            }
            else { MessageBox.Show("Vyplňte údaje."); }

            db.Close();
        }
       
    }
}

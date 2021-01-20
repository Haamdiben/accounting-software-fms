using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class Affichpaiemnt : Form
    {
        public Affichpaiemnt(string ch)
        {
            InitializeComponent();
            id = ch;
        }
        string id;
        private void Affichpaiemnt_Load(object sender, EventArgs e)
        {


            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select nom_personnel, prix,date,type_paiement from fms_db.paiement_perso where id_personnel = " + id, ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

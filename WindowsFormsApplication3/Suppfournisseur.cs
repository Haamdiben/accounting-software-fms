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
    public partial class Suppfournisseur : Form
    {
        public Suppfournisseur(string ch1 , string c2)
        {
            InitializeComponent();
            label3.Text = c2+" ?";
            id = ch1;


        }
        string id;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "delete from fms_db.fournisseur  where id_fournisseur = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("fournisseur Supprimer avec succées ");
                this.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Suppfacture : Form
    {
        public Suppfacture(string ch1,string ch2)
        {
            InitializeComponent();
            id = ch1;
            num = ch2;
        }
        string id, num;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void Suppfacture_Load(object sender, EventArgs e)
        {
            label3.Text = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "delete from fms_db.vente  where id_facture = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Facture Supprimer avec succées ");
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

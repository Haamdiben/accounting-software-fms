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
    public partial class AjoutFournisseur : Form
    {
        public AjoutFournisseur()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConString = "datasource=localhost;port=3306;username=root";

            string Query = "insert into fms_db.fournisseur (nom_fournisseur,des_fournisseur) values ('" + this.textBox1.Text + "','" + this.richTextBox1.Text + "');";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Fournisseur ajouter avec succées");
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

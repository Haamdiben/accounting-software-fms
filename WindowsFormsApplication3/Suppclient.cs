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
    public partial class Suppclient : Form
    {
        public Suppclient(string sos,string sa)
        {
            InitializeComponent();
           id = sos;
           nom = sa;
    
        }
        string nom, id;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "delete from fms_db.client  where id_client = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                    ConDataBase.Open();
                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Client Supprimer avec succées ");
                    this.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = nom+" ?";

        }

        private void Suppclient_Load(object sender, EventArgs e)
        {
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
    }
}

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
    public partial class Suppperso : Form
    {
        public Suppperso(string ch,string ch1, string ch2)
        {
            InitializeComponent();
            id = ch;
            nom = ch1;
            prenom = ch2;
        }
        string id, nom, prenom;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = "delete from fms_db.personnel  where id_personnel = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Agent personnel Supprimer avec succées ");
                this.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Suppperso_Load(object sender, EventArgs e)
        {
            label3.Text = nom+" "+ prenom;
        }
    }
}

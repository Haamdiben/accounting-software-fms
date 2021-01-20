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
    public partial class Modiffournisseur : Form
    {
        public Modiffournisseur(string ch )
        {
            InitializeComponent();
            id = ch;
        }
        string id;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string Query = "select * from fms_db.fournisseur  where id_fournisseur = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("nom_fournisseur");
                    string des = myReader.GetString("des_fournisseur");
  

                    textBox1.Text = nom;
                    richTextBox1.Text = des;


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Query = "update fms_db.fournisseur set nom_fournisseur='" + this.textBox1.Text + "',des_fournisseur='" + this.richTextBox1.Text + "' where id_fournisseur = " + id;

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Fournisseur Modifer avec succées");
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

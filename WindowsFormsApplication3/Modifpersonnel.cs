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
    public partial class Modifpersonnel : Form
    {
        public Modifpersonnel(string ch)
        {
            InitializeComponent();
            id = ch;
        }
        string id;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void button1_Click(object sender, EventArgs e)
        {


            string Query = "update fms_db.personnel set nom_personnel='" + this.textBox1.Text + "',prenom_personnel='" + this.textBox2.Text + "',cin='" + this.textBox3.Text + "',adr_personnel='" + this.textBox4.Text + "',tel_personnel='" + this.textBox5.Text + "',mail_personnel='" + this.textBox6.Text + "'  where id_personnel = " + id;

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Agent personnel Modifer avec succées");
                this.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            string Query = "select * from fms_db.personnel  where id_personnel = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    
                    string nom = myReader.GetString("nom_personnel");
                    string pnom = myReader.GetString("prenom_personnel");
                    string cn = myReader.GetString("cin");
                    string adr = myReader.GetString("adr_personnel");
                    string tel = myReader.GetString("tel_personnel");
                    string email = myReader.GetString("mail_personnel");

                    textBox1.Text = nom;
                    textBox2.Text = pnom;
                    textBox3.Text = cn;
                    textBox4.Text = adr;
                    textBox5.Text = tel;
                    textBox6.Text = email;

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

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
    public partial class Modifclient : Form
    {
        public Modifclient(string soc)
        {
            InitializeComponent();
            ch2 = soc;

        }
        string ac;
        string ConString = "datasource=localhost;port=3306;username=root";
        string ch2;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            string Query = "select * from fms_db.client  where id_client = " + ch2 ;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read()) {
                    string nom = myReader.GetString("nom_client");
                    string adr = myReader.GetString("adr_client");
                    string tf = myReader.GetString("telf_client");
                    string tm = myReader.GetString("telm_client");
                    string email = myReader.GetString("mail_client");
                    string mf = myReader.GetString("matricule_fiscale");
                    string mc = myReader.GetString("max_credit");
                     ac = myReader.GetString("activte_client");

                    textBox1.Text = nom;
                    textBox2.Text = adr;
                    textBox3.Text = tf;
                    textBox4.Text = tm;
                    textBox5.Text = email;
                    textBox6.Text = mf;
                    textBox7.Text = mc;

                    if (ac == "Industriel")
                    {
                        this.radioButton2.Checked = true;
                    }
                    else if (ac == "Commercial")
                    {
                        this.radioButton1.Checked = true;

                    }
 
                
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ConString = "datasource=localhost;port=3306;username=root";

            string Query = "update fms_db.client set nom_client='" + this.textBox1.Text + "',adr_client='" + this.textBox2.Text + "',telf_client='" + this.textBox3.Text + "',telm_client='" + this.textBox4.Text + "',mail_client='" + this.textBox5.Text + "',matricule_fiscale='" + this.textBox6.Text + "',max_credit='" + this.textBox7.Text + "', activte_client ='" +ac+ "' where id_client = " + ch2;

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Client Modifer avec succées");
                this.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ac = "Industriel";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ac = "Commercial";

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Modifclient_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

    }
}

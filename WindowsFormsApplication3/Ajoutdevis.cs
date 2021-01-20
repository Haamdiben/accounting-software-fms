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
    public partial class Ajoutdevis : Form
    {
        public Ajoutdevis()
        {
            InitializeComponent();
            d1 = null;
            d2 = null;
            d3 = null;
            d4 = null;
            d5 = null;
            d6 = null;
            d7 = null;
            d8 = null;
            d9 = null;
            d10 = null;
        }

        string idselect, maxc;
        string ConString = "datasource=localhost;port=3306;username=root";
        int rowsNbr;
        string d1, d2, d3, d4, d5, d6, d7, d8, d9, d10;


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Adddec ad = new Adddec(textBox4.Text, textBox8.Text, dateTimePicker2.Text, d2, d3, d4, d5, d6, d7, d8, d9, d10);
            ad.ShowDialog();
            d1 = ad.GetItemCode;
            d2 = ad.GetItemCode2;
            d3 = ad.GetItemCode3;
            d4 = ad.GetItemCode4;
            d5 = ad.GetItemCode5;
            d6 = ad.GetItemCode6;
            d7 = ad.GetItemCode7;
            d8 = ad.GetItemCode8;
            d9 = ad.GetItemCode9;
            d10 = ad.GetItemCode10;
            if (d1 != null)
            {
                int spacePos = d1.IndexOf("No");
                textBox4.Text = d1.Substring(0, spacePos - 1);
                int spacePos2 = d1.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox4.Text.Length + 4);
                textBox8.Text = d1.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker2.Text = d1.Substring(d1.Length - 10, 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d1 = textBox4.Text + " No " + textBox8.Text + " Du " + dateTimePicker2.Text;

            Ajoutdevis2 af2 = new Ajoutdevis2(idselect, label10.Text, dateTimePicker1.Text, comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, textBox5.Text, textBox6.Text, textBox7.Text, comboBox2.Text, richTextBox1.Text, maxc);
            af2.ShowDialog();
            if (af2.GetItemCode1 == 1)
            {
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Query = "select * from fms_db.client where nom_client='" + this.comboBox1.Text + "'";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fid = myReader.GetInt32("id_client").ToString();
                    string addr = myReader.GetString("adr_client");
                    maxc = myReader.GetString("max_credit");
                    idselect = fid;
                    textBox1.Text = addr;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ajoutdevis_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("EUR");
            comboBox2.Items.Add("USD");
            comboBox2.Items.Add("TND");
            label10.Text = "######";



            string Query = "select * from fms_db.client";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fname = myReader.GetString("nom_client");

                    comboBox1.Items.Add(fname);

                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

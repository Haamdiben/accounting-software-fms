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
    public partial class Modiffact : Form
    {
        public Modiffact(string ch)
        {
            InitializeComponent();
            id = ch;
        }
        string id,maxc;
        int rowsNbr;
        int vc = 0;
        string ConString = "datasource=localhost;port=3306;username=root";
        string d1,d2,d3,d4,d5,d6,d7,d8,d9,d10;
            

        private void button1_Click(object sender, EventArgs e)
        {
            d1 = textBox4.Text + " No " + textBox8.Text + " Du " + dateTimePicker2.Text;
            Modiffact2 mf2 = new Modiffact2(id, textBox2.Text, textBox3.Text, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, textBox5.Text, textBox6.Text, textBox7.Text, comboBox2.Text, richTextBox1.Text,label10.Text,vc);
            mf2.ShowDialog();
            if (mf2.GetItemCode1 == 1)
            {
                this.Close();
            }
        }

        private void Modiffact_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("EUR");
            comboBox2.Items.Add("USD");
            comboBox2.Items.Add("TND");
            {
                string Query = "select * from fms_db.vente  where id_facture = " + id;
                MySqlConnection ConDataBase = new MySqlConnection(ConString);
                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    myReader = CmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string factureno = myReader.GetString("num_facture");
                        string date = myReader.GetString("date_facture");
                        string nomclient = myReader.GetString("nom_client");
                        string adrclient = myReader.GetString("adr_client");

                        string marchendise = myReader.GetString("marchendises");
                        string nbrecoli = myReader.GetString("nbre_colis");
                         d1 = myReader.GetString("d1");
                         d2 = myReader.GetString("d2");
                         d3 = myReader.GetString("d3");
                         d4 = myReader.GetString("d4");
                         d5 = myReader.GetString("d5");
                         d6 = myReader.GetString("d6");
                         d7 = myReader.GetString("d7");
                         d8 = myReader.GetString("d8");
                         d9 = myReader.GetString("d9");
                         d10 = myReader.GetString("d10");

                        
                        
                        
                        
                        
                        string poidnet = myReader.GetString("poids_net");
                        string poidbrut = myReader.GetString("poids_brut");
                        string sommev = myReader.GetString("sommev");
                        string valeur = myReader.GetString("valeur");
                        string piecesjointes = myReader.GetString("picesjointes");

                        if (factureno=="######")
                        {

                            string Query2 = "select  count(*) from fms_db.vente_count";
                            MySqlConnection ConDataBase2 = new MySqlConnection(ConString);
                            MySqlCommand CmdDataBase2 = new MySqlCommand(Query2, ConDataBase2);
                            try
                            {
                                ConDataBase2.Open();
                                rowsNbr = Convert.ToInt32(CmdDataBase2.ExecuteScalar());
                                ++rowsNbr;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }


                            label10.Text = rowsNbr.ToString() + "/";
                            label10.Text = "0" + label10.Text + DateTime.Now.Year.ToString();
                            vc = 1;

                        }
                        else
                        {
                            label10.Text = factureno;

                        }

                        label5.Text = date.Substring(0,10);
                        label4.Text = nomclient;
                        label16.Text = adrclient;
                        
                        if (d1 != null)
                        {
                            int spacePos = d1.IndexOf("No");
                            textBox4.Text = d1.Substring(0, spacePos - 1);
                            int spacePos2 = d1.IndexOf("Du");
                            spacePos2 = spacePos2 - (textBox4.Text.Length + 4);
                            textBox8.Text = d1.Substring(spacePos + 3, spacePos2 - 1);
                            dateTimePicker2.Text = d1.Substring(d1.Length - 10, 10);
                        }

                        textBox2.Text = marchendise;
                        textBox3.Text = nbrecoli;
                        textBox5.Text = poidbrut;
                        textBox6.Text = poidnet;
                        textBox7.Text = sommev;
                        comboBox2.Text = valeur;
                        richTextBox1.Text = piecesjointes;











                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Moddec md = new Moddec(d1, d2, d3, d4, d5, d6, d7, d8, d9, d10);
            md.ShowDialog();
            d1 = md.GetItemCode;
            d2 = md.GetItemCode2;
            d3 = md.GetItemCode3;
            d4 = md.GetItemCode4;
            d5 = md.GetItemCode5;
            d6 = md.GetItemCode6;
            d7 = md.GetItemCode7;
            d8 = md.GetItemCode8;
            d9 = md.GetItemCode9;
            d10 = md.GetItemCode10;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
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
    }
}
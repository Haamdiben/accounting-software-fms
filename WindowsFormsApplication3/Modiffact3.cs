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
    public partial class Modiffact3 : Form
    {
        public Modiffact3(string idd, string ch4, string ch5, string d1, string d2, string d3, string d4, string d5, string d6, string d7, string d8, string d9, string d10, string ch6, string ch8, string ch9, string ch110, string ch10, string ch0, string ch1, string ch2, string ch3, string cch4, string cch5, string cch6, string ch7, string cch8, string cch9, string cch10, string ch11, string ch12, string ch13, string ch14, string ch15, string ch16, string ch17, string ch18, string ch19, string ch20, string ch21, string ch22, string ch23, string ch24, string ch25, string ch26, string ch27, string ch28, string ch29, string ch30, string ch31, string ch32, string ch33, string ch34, string ch35, string ch36, string ch37, string ch38, string ch39, string ch40, string ch41, string ch42, string ch43, string ch44, string ch45, string ch46, string ch47, string ch48, string ch49, string ch50,string numf,int v)
        {
            InitializeComponent();
            id = idd;
            marchendise = ch4;
            nbrcolis = ch5;
            dd1 = d1;
            dd2 = d2;
            dd3 = d3;
            dd4 = d4;
            dd5 = d5;
            dd6 = d6;
            dd7 = d7;
            dd8 = d8;
            dd9 = d9;
            dd10 = d10;
            poidsbrut = ch6;
            poidsnet = ch8;
            valeur = ch9;
            sommev = ch110;
            piecesjointes = ch10;

            f1 = ch0;
            f2 = ch1;
            f3 = ch2;
            f4 = ch3;
            f5 = cch4;
            f6 = cch5;
            f7 = cch6;
            f8 = ch7;
            f9 = cch8;
            f10 = cch9;
            f11 = cch10;
            f12 = ch11;
            f13 = ch12;
            f14 = ch13;
            f15 = ch14;
            f16 = ch15;
            f17 = ch16;
            f18 = ch17;
            f19 = ch18;
            f20 = ch19;
            f21 = ch20;
            f22 = ch21;
            f23 = ch22;
            f24 = ch23;
            f25 = ch24;
            c1 = ch25;
            c2 = ch26;
            c3 = ch27;
            c4 = ch28;
            c5 = ch29;
            c6 = ch30;
            c7 = ch31;
            c8 = ch32;
            c9 = ch33;
            c10 = ch34;
            c11 = ch35;
            c12 = ch36;
            c13 = ch37;
            c14 = ch38;
            c15 = ch39;
            c16 = ch40;
            c17 = ch41;
            c18 = ch42;
            c19 = ch43;
            c20 = ch44;
            c21 = ch45;
            c22 = ch46;
            c23 = ch47;
            c24 = ch48;
            c25 = ch49;
            somme = ch50;
            numfact = numf;
            vc = v;
        }
        int vc;
        string sommel, typepaiment,numfact;
        int cl;
        double reste;
        string f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23, f24, f25;
        string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25;
        string id,situation,somme;
        string dd1, dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10;
        int sl;
        string  marchendise, nbrcolis, declaration, poidsbrut, poidsnet, sommev, valeur, piecesjointes;
        string sommetotal;
        string ConString = "datasource=localhost;port=3306;username=root";


        public int GetItemCode
        {
            get { return cl; }
        }

        private void Modiffact_Load(object sender, EventArgs e)
        {
            sommel = Program.converti(float.Parse(somme));

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
                    string date = myReader.GetString("date_facture").Substring(0,10);
                    string nomclient = myReader.GetString("nom_client");
                    string adrclient = myReader.GetString("adr_client");

                     situation = myReader.GetString("situation");
                     typepaiment = myReader.GetString("type_paiement");
                     string montant_paye = myReader.GetString("montant_paye");

                     reste = myReader.GetDouble("reste_paye");

                     string bank = myReader.GetString("Banque");
                     string no = myReader.GetString("No");
  
                   

                    label10.Text = factureno;
                    label4.Text = date;
                    label5.Text = nomclient;
                   label9.Text = adrclient;
                    label12.Text = somme+ " DT";
                    textBox1.Text = montant_paye;
                    textBox2.Text = bank;
                    textBox3.Text = no;

                    if (situation == "Payé")
                    {
                        this.radioButton1.Checked = true;
                    }
                    else if (situation == "Non Payé")
                    {
                        this.radioButton2.Checked = true;

                    }

                    if (typepaiment == "Espéces")
                    {
                        this.radioButton3.Checked = true;
                    }
                    else if (typepaiment == "Cheque")
                    {
                        this.radioButton4.Checked = true;

                    }
                    else if (typepaiment == "Traite")
                    {
                        this.radioButton5.Checked = true;

                    }


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Montant payé est vide.",
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

            }
            else
            {
                reste = float.Parse(somme) - float.Parse(textBox1.Text);
                if (reste >= 0)
                {

                    string ConString = "datasource=localhost;port=3306;username=root";

                    string Query = "update fms_db.vente set marchendises ='" + marchendise + "',num_facture ='" + numfact + "', nbre_colis= '" + nbrcolis + "', d1='" + dd1 + "',d2 ='" + dd2 + "',d3='" + dd3 + "',d4='" + dd4 + "',d5='" + dd5 + "',d6='" + dd6 + "',d7='" + dd7 + "',d8='" + dd8 + "',d9='" + dd9 + "',d10='" + dd10 + "',poids_brut='" + poidsbrut + "' ,sommev= '" + sommev + "', valeur='" + valeur + "', poids_net='" + poidsnet + "', picesjointes= '" + piecesjointes + "', Timbre_declaration_client='" + c1 + "', Timbre_declaration_fms='" + f1 + "', Timbre_dimension_client='" + c2 + "', Timbre_dimension_fms='" + f2 + "', Droits_Douanes_client='" + c3 + "', Droits_Douanes_fms='" + f3 + "', PV_RETARD_client='" + c4 + "', PV_RETARD_fms='" + f4 + "', Autres_PV_client='" + c5 + "', Autres_PV_fms='" + f5 + "', TAV_client='" + c6 + "', TAV_fms='" + f6 + "', Avis_Compagnie_client='" + c7 + "', Avis_Compagnie_fms='" + f7 + "', Frais_magasinage_client='" + c8 + "', Frais_magasinage_fms='" + f8 + "', Assurances_client='" + c9 + "', Assurances_fms='" + f9 + "', Document685_client='" + c10 + "', Document_685_fms='" + f10 + "', Correspandance_client='" + c11 + "', Correspandance_fms='" + f11 + "', Frais_Fixes_client='" + c12 + "', Frais_Fixes_fms='" + f12 + "', Privilege_Fiscale_client='" + c13 + "', Privilege_Fiscale_fms='" + f13 + "', DUCV_client='" + c14 + "', DUCV_fms='" + f14 + "', Frais_visite_client='" + c15 + "', Frais_visite_fms='" + f15 + "', importation_dispense_client='" + c16 + "', importation_dispense_fms='" + f16 + "', Frais_deplacement_client='" + c17 + "', Frais_deplacement_fms='" + f17 + "', Photocopie_client='" + c18 + "', Photocopie_fms='" + f18 + "', Declaration_UC_client='" + c19 + "', Declaration_UC_fms='" + f19 + "', TTN_client='" + c20 + "', TTN_fms='" + f20 + "', Informatique_client='" + c21 + "', Informatique_fms='" + f21 + "', Horaire_client='" + c22 + "', Horaire_fms='" + f22 + "', TVA_client='" + c23 + "', TVA_fms='" + f23 + "', Autres_frais_client='" + c24 + "', Autres_frais_fms='" + f24 + "', Timbre_fiscale_client='" + c25 + "', Timbre_fiscale_fms='" + f25 + "', Total='" + somme + "', Total_letters='" + sommel + "', situation='" + situation + "', type_paiement='" + typepaiment + "', montant_paye='" + this.textBox1.Text + "', reste_paye='" + reste + "' ,Banque='" + this.textBox2.Text + "',No='" + this.textBox3.Text + "' where id_facture = " + id;

                    MySqlConnection ConDataBase = new MySqlConnection(ConString);

                    MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        ConDataBase.Open();
                        myReader = CmdDataBase.ExecuteReader();
                        MessageBox.Show("Facture Modifier avec succées");
                        cl = 1;

                        this.Close();
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (vc==1)
                    {
                    string Query69 = "insert into fms_db.vente_count () values ();";
                    MySqlConnection ConDataBase69 = new MySqlConnection(ConString);
                    MySqlCommand CmdDataBase69 = new MySqlCommand(Query69, ConDataBase69);
                    MySqlDataReader myReader69;
                    try
                    {
                        ConDataBase69.Open();
                        myReader69 = CmdDataBase69.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                        }
                }

            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            typepaiment = "Traite";
            label16.Visible = true;
            textBox3.Visible = true;
            label17.Visible = false;
            textBox2.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            typepaiment = "Cheque";
            label17.Visible = true;
            textBox2.Visible = true;
            label16.Visible = true;
            textBox3.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            typepaiment = "Espéces";
            label17.Visible = false;
            textBox2.Visible = false;
            label16.Visible = false;
            textBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            situation = "Payé";
            radioButton4.Enabled = true;
            radioButton3.Enabled = true;
            radioButton5.Enabled = true;
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            situation = "Non Payé";
            textBox1.Text = "0";
            textBox2.Text = somme;
            radioButton4.Enabled = false;
            radioButton3.Enabled = false;
            radioButton5.Enabled = false;
        }
    }
}

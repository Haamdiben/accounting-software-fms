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
    public partial class Modiffact2 : Form
    {
        public Modiffact2(string idd, string ch4, string ch5, string d1, string d2, string d3, string d4, string d5, string d6, string d7, string d8, string d9, string d10, string ch6, string ch8, string ch9, string ch110, string ch10, string numf,int v)
        {
            InitializeComponent();

            id =idd;
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
            valeur = ch110;
            sommev = ch9;
            piecesjointes = ch10;
            numfact = numf;
            vc = v;
        }
        string dd1, dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10;
        int sl;
        string id, marchendise, nbrcolis, declaration, poidsbrut, poidsnet, sommev, valeur, piecesjointes,numfact;
        string sommetotal;
        string ConString = "datasource=localhost;port=3306;username=root";
        int vc;

        public int GetItemCode1
        {
            get { return sl; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] texts = new TextBox[] { f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23, f24, f25 };
            float sum = 0;

            foreach (TextBox textBox in texts)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    sum += float.Parse(textBox.Text);
                }

            }

            sommetotal = sum.ToString();


            Modiffact3 mf3 = new Modiffact3(id,marchendise,nbrcolis,dd1,dd2,dd3,dd4,dd5,dd6,dd7,dd8,dd9,dd10,poidsbrut,poidsnet,valeur,sommev,piecesjointes, f1.Text, f2.Text, f3.Text, f4.Text, f5.Text, f6.Text, f7.Text, f8.Text, f9.Text, f10.Text, f11.Text, f12.Text, f13.Text, f14.Text, f15.Text, f16.Text, f17.Text, f18.Text, f19.Text, f20.Text, f21.Text, f22.Text, f23.Text, f24.Text, f25.Text, c1.Text, c2.Text, c3.Text, c4.Text, c5.Text, c6.Text, c7.Text, c8.Text, c9.Text, c10.Text, c11.Text, c12.Text, c13.Text, c14.Text, c15.Text, c16.Text, c17.Text, c18.Text, c19.Text, c20.Text, c21.Text, c22.Text, c23.Text, c24.Text, c25.Text,sommetotal,numfact,vc);
            
            mf3.ShowDialog();
            if (mf3.GetItemCode == 1)
            {
                sl = 1;

                this.Close();
            }
        }

        private void Modiffact2_Load(object sender, EventArgs e)
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



                    f1.Text = myReader.GetString("Timbre_declaration_fms");
                    f2.Text = myReader.GetString("Timbre_dimension_fms");
                    f3.Text = myReader.GetString("Droits_Douanes_fms");
                    f4.Text = myReader.GetString("PV_RETARD_fms");
                    f5.Text = myReader.GetString("Autres_PV_fms");
                    f6.Text = myReader.GetString("TAV_fms");
                    f7.Text = myReader.GetString("Avis_Compagnie_fms");
                    f8.Text = myReader.GetString("Frais_magasinage_fms");
                    f9.Text = myReader.GetString("Assurances_fms");
                    f10.Text = myReader.GetString("Document_685_fms");
                    f11.Text = myReader.GetString("Correspandance_fms");
                    f12.Text = myReader.GetString("Frais_Fixes_fms");
                    f13.Text = myReader.GetString("Privilege_Fiscale_fms");
                    f14.Text = myReader.GetString("DUCV_fms");
                    f15.Text = myReader.GetString("Frais_visite_fms");
                    f16.Text = myReader.GetString("importation_dispense_fms");
                    f17.Text = myReader.GetString("Frais_deplacement_fms");
                    f18.Text = myReader.GetString("Photocopie_fms");
                    f19.Text = myReader.GetString("Declaration_UC_fms");
                    f20.Text = myReader.GetString("TTN_fms");
                    f21.Text = myReader.GetString("Informatique_fms");
                    f22.Text = myReader.GetString("Horaire_fms");
                    f23.Text = myReader.GetString("TVA_fms");
                    f24.Text = myReader.GetString("Autres_frais_fms");
                    f25.Text = myReader.GetString("Timbre_fiscale_fms");

                    c1.Text = myReader.GetString("Timbre_declaration_client");
                    c2.Text = myReader.GetString("Timbre_dimension_client");
                    c3.Text = myReader.GetString("Droits_Douanes_client");
                    c4.Text = myReader.GetString("PV_RETARD_client");
                    c5.Text = myReader.GetString("Autres_PV_client");
                    c6.Text = myReader.GetString("TAV_client");
                    c7.Text = myReader.GetString("Avis_Compagnie_client");
                    c8.Text = myReader.GetString("Frais_magasinage_client");
                    c9.Text = myReader.GetString("Assurances_client");
                    c10.Text = myReader.GetString("Document685_client");
                    c11.Text = myReader.GetString("Correspandance_client");
                    c12.Text = myReader.GetString("Frais_Fixes_client");
                    c13.Text = myReader.GetString("Privilege_Fiscale_client");
                    c14.Text = myReader.GetString("DUCV_client");
                    c15.Text = myReader.GetString("Frais_visite_client");
                    c16.Text = myReader.GetString("importation_dispense_client");
                    c17.Text = myReader.GetString("Frais_deplacement_client");
                    c18.Text = myReader.GetString("Photocopie_client");
                    c19.Text = myReader.GetString("Declaration_UC_client");
                    c20.Text = myReader.GetString("TTN_client");
                    c21.Text = myReader.GetString("Informatique_client");
                    c22.Text = myReader.GetString("Horaire_client");
                    c23.Text = myReader.GetString("TVA_client");
                    c24.Text = myReader.GetString("Autres_frais_client");
                    c25.Text = myReader.GetString("Timbre_fiscale_client");


                }
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

        private void c1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c17_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f17_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c18_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f18_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c21_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f21_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c23_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f23_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void c25_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f25_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }
    }
}

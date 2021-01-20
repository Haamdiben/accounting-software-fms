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
    public partial class Ajoutfacture2 : Form
    {

        public Ajoutfacture2(string ch0, string ch1, string ch2, string ch3, string ch4, string ch5, string ch6, string d1, string d2, string d3, string d4, string d5, string d6, string d7, string d8, string d9, string d10, string ch8, string ch9, string ch110, string ch10, string ch11, string mc)
        {



            InitializeComponent();
            factureno = ch1;
            date = ch2;
            nomclient = ch3;
            idclient = ch0;

            adrclient = ch4;
            marchendise = ch5;
            nbrcolis = ch6;
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
            maxc = mc;
            poidsbrut = ch8;
            poidsnet = ch9;
            valeur = ch10;
            sommev = ch110;
            piecesjointes = ch11;
        }
        public int GetItemCode1
        {
            get { return sl; }
        }
        string dd1,dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10 , maxc;
        int sl;
        string factureno, date, nomclient,idclient, adrclient, marchendise, nbrcolis, declaration, poidsbrut, poidsnet, sommev,valeur, piecesjointes;
        string sommetotal;
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
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

            Ajoutfacture4 af4 = new Ajoutfacture4(sommetotal, f1.Text, f2.Text, f3.Text, f4.Text, f5.Text, f6.Text, f7.Text, f8.Text, f9.Text, f10.Text, f11.Text, f12.Text, f13.Text, f14.Text, f15.Text, f16.Text, f17.Text, f18.Text, f19.Text, f20.Text, f21.Text, f22.Text, f23.Text, f24.Text, f25.Text, c1.Text, c2.Text, c3.Text, c4.Text, c5.Text, c6.Text, c7.Text, c8.Text, c9.Text, c10.Text, c11.Text, c12.Text, c13.Text, c14.Text, c15.Text, c16.Text, c17.Text, c18.Text, c19.Text, c20.Text, c21.Text, c22.Text, c23.Text, c24.Text, c25.Text, factureno, date, nomclient, idclient, adrclient, marchendise, nbrcolis, dd1, dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10, poidsbrut, poidsnet, sommev,valeur, piecesjointes,maxc);
           
            af4.ShowDialog();
            if (af4.GetItemCode==1)
            {
                sl = 1;

                this.Close();
            }

        
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Ajoutfacture2_Load(object sender, EventArgs e)
        {
            string ConString = "datasource=localhost;port=3306;username=root";
            string Query = "select * from fms_db.parametres where id_parametres = 1";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    f23.Text = myReader.GetString("tva");
                    f25.Text = myReader.GetString("timbre");


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void c1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c11_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c13_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c19_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c21_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c23_KeyPress(object sender, KeyPressEventArgs e)
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

        private void c25_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f11_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f13_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f19_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f21_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f23_KeyPress(object sender, KeyPressEventArgs e)
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

        private void f25_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void f17_TextChanged(object sender, EventArgs e)
        {

        }

      
        
    }
}

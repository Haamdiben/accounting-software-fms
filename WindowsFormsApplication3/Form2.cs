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


using System.Drawing.Imaging;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

        }
        string day,counter;
        int pay, npay;
        string ConString = "datasource=localhost;port=3306;username=root;convert zero datetime=True";
        float snpay, spay;


        public void sommepay()
        {
            spay = 0;
            string Query = "select * from fms_db.vente where situation = 'Payé' and  datein between '" + dateTimePicker3.Text + "' and '" + dateTimePicker4.Text + "'";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {

                    float cnter = myReader.GetFloat("Total");
                    spay = spay + cnter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

            public void sommeunpay()
            {
                snpay = 0;
                string Query = "select  * from fms_db.vente where situation = 'Non Payé' and  datein between '" + dateTimePicker3.Text + "' and '" + dateTimePicker4.Text + "'";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {

                    float cnooter = myReader.GetFloat("Total");
                    snpay = snpay + cnooter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            }
            }
            public void ppay(){

                string Query2 = "select  count(*) from fms_db.vente where situation = 'Payé' and  datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
            MySqlConnection ConDataBase2 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase2 = new MySqlCommand(Query2, ConDataBase2);
            try
            {
                ConDataBase2.Open();
                pay = Convert.ToInt32(CmdDataBase2.ExecuteScalar());
                ++pay;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            public void nnpay(){
                string Query3 = "select  count(*) from fms_db.vente where situation = 'Non Payé' and  datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
            MySqlConnection ConDataBase3 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase3 = new MySqlCommand(Query3, ConDataBase3);
            try
            {
                ConDataBase3.Open();
                npay = Convert.ToInt32(CmdDataBase3.ExecuteScalar());

                ++npay;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        
        
        public void countvente()
            {

                string Query = "SELECT DATE(datein) Date, COUNT(DISTINCT id_facture) totalCOunt FROM fms_db.vente  where datein between '" + dateTimePicker5.Text + "' and '" + dateTimePicker6.Text + "'";

                MySqlConnection ConDataBase = new MySqlConnection(ConString);
                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    myReader = CmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {

                        day = myReader.GetDateTime("Date").ToString("yyyy-MM-dd");
                        counter = myReader.GetString("totalCOunt");
                        this.chart1.Series["Achat"].Points.AddXY(day, counter);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


           

            }


        public void countachat()
        {
            string Query6 = "SELECT DATE(datein) Date, COUNT(DISTINCT id_achat) totalCOunt FROM fms_db.achat  where  datein between '" + dateTimePicker5.Text + "' and '" + dateTimePicker6.Text + "'";

            MySqlConnection ConDataBase6 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase6 = new MySqlCommand(Query6, ConDataBase6);
            MySqlDataReader myReader6;
            try
            {
                ConDataBase6.Open();
                myReader6 = CmdDataBase6.ExecuteReader();
                while (myReader6.Read())
                {

                    day = myReader6.GetDateTime("Date").ToString("yyyy-MM-dd");
                    counter = myReader6.GetString("totalCOunt");
                    this.chart1.Series["Vente"].Points.AddXY(day, counter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl1.Instance))
            {
                panel3.Controls.Add(UserControl1.Instance);
                UserControl1.Instance.Dock = DockStyle.Fill;
                UserControl1.Instance.BringToFront();
            }
            else
                UserControl1.Instance.BringToFront();
            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Achat";

        }





        	

            // Stores the previously-colored button, if any
            private Button lastButton = null;

            // The event handler for all button's who should have color-changing functionality


        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl2.Instance))
            {
                panel3.Controls.Add(UserControl2.Instance);
                UserControl2.Instance.Dock = DockStyle.Fill;
                UserControl2.Instance.BringToFront();
            }
            else
                UserControl2.Instance.BringToFront();

            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Vente";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl0.Instance))
            {
                panel3.Controls.Add(UserControl0.Instance);
                UserControl0.Instance.Dock = DockStyle.Fill;
                UserControl0.Instance.BringToFront();
            }
            else
                UserControl0.Instance.BringToFront();


            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Acceuil";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int redui = 0;
        private void button7_Click(object sender, EventArgs e)
        {

            if (!panel3.Controls.Contains(UserControl7.Instance))
            {
                panel3.Controls.Add(UserControl7.Instance);
                UserControl7.Instance.Dock = DockStyle.Fill;
                UserControl7.Instance.BringToFront();
            }
            else
                UserControl7.Instance.BringToFront();
            

            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Compte";


        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (redui == 0)
            {
                WindowState = FormWindowState.Maximized;
                redui = 1;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                redui = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl3.Instance))
            {
                panel3.Controls.Add(UserControl3.Instance);
                UserControl3.Instance.Dock = DockStyle.Fill;
                UserControl3.Instance.BringToFront();
            }
            else
                UserControl3.Instance.BringToFront();
            

            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Client";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!panel3.Controls.Contains(UserControl4.Instance))
            {
                panel3.Controls.Add(UserControl4.Instance);
                UserControl4.Instance.Dock = DockStyle.Fill;
                UserControl4.Instance.BringToFront();
            }
            else
                UserControl4.Instance.BringToFront();
            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Fournisseur";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl5.Instance))
            {
                panel3.Controls.Add(UserControl5.Instance);
                UserControl5.Instance.Dock = DockStyle.Fill;
                UserControl5.Instance.BringToFront();
            }
            else
                UserControl5.Instance.BringToFront();
            
            
            
            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Personnel";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl6.Instance))
            {
                panel3.Controls.Add(UserControl6.Instance);
                UserControl6.Instance.Dock = DockStyle.Fill;
                UserControl6.Instance.BringToFront();
            }
            else
                UserControl6.Instance.BringToFront();
            

            
            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Paramétres";


        }

        private void button12_DoubleClick_1(object sender, EventArgs e)
        {
            MessageBox.Show("You are in ");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl0.Instance))
            {
                panel3.Controls.Add(UserControl0.Instance);
                UserControl0.Instance.Dock = DockStyle.Fill;
                UserControl0.Instance.BringToFront();
            }
            else
                UserControl0.Instance.BringToFront();
            label1.Text = "Fast Multi Service - Acceuil";


 
            //compteur des vente
           
            //compteur des achat
           

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            ppay();
            nnpay();
            this.chart2.Series["Vente"].Points.AddXY("Payé", pay-1);
            this.chart2.Series["Vente"].Points.AddXY("Non Payé", npay-1);

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
           ppay();
            nnpay();

            this.chart2.Series["Vente"].Points.AddXY("Payé", pay-1);
            this.chart2.Series["Vente"].Points.AddXY("Non Payé", npay-1);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            sommepay();
            sommeunpay();

            this.chart3.Series["Somme"].Points.AddXY("Payé (dt)", spay);
            this.chart3.Series["Somme"].Points.AddXY("Non Payé (dt)", snpay);

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            sommepay();
            sommeunpay();

            this.chart3.Series["Somme"].Points.AddXY("Payé (dt)", spay);
            this.chart3.Series["Somme"].Points.AddXY("Non Payé (dt)", snpay);
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            countvente();
            countachat();
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            countvente();
            countachat();
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(UserControl8.Instance))
            {
                panel3.Controls.Add(UserControl8.Instance);
                UserControl8.Instance.Dock = DockStyle.Fill;
                UserControl8.Instance.BringToFront();
            }
            else
                UserControl8.Instance.BringToFront();

            // Change the background color of the button that was clicked
            Button current = (Button)sender;
            current.BackColor = Color.LightSteelBlue;

            // Revert the background color of the previously-colored button, if any
            if (lastButton != null)
                lastButton.BackColor = Color.Transparent;

            // Update the previously-colored button
            lastButton = current;
            label1.Text = "Fast Multi Service - Devis";
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication3
{
    public partial class UserControl0 : UserControl
    {

        private static UserControl0 _instance;

        public static UserControl0 Instance
        {

            get
            {
                if (_instance == null)

                    _instance = new UserControl0();
                return _instance;
            }
        }
        public UserControl0()
        {
            InitializeComponent();
        }


        string day, counter;
        int pay, npay;
        string ConString = "datasource=localhost;port=3306;username=root;convert zero datetime=True";
        double snpay, spay;
        string devis = "######";
        
        public void sommepay()
        {
            spay = 0;
            string Query = "select * from fms_db.vente where situation = 'Payé' and num_facture <> '" + devis + "' and  datein between '" + dateTimePicker3.Text + "' and '" + dateTimePicker4.Text + "'";

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
            string Query = "select  * from fms_db.vente where situation = 'Non Payé' and num_facture <> '" + devis + "' and datein between '" + dateTimePicker3.Text + "' and '" + dateTimePicker4.Text + "'";

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
        public void ppay()
        {

            string Query2 = "select  count(*) from fms_db.vente where situation = 'Payé' and num_facture <> '" + devis + "' and datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
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
        public void nnpay()
        {
            string Query3 = "select  count(*) from fms_db.vente where situation = 'Non Payé' and num_facture <> '" + devis + "' and datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ";
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

            string Query = "SELECT DATE(datein) Date, COUNT(DISTINCT id_facture) totalCOunt FROM fms_db.vente  where num_facture <> '" + devis + "' and datein between '" + dateTimePicker5.Text + "' and '" + dateTimePicker6.Text + "' Group By datein";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                 
                while (myReader.Read())
                {
                    if (myReader["Date"] != DBNull.Value)
                     {
                    day = myReader.GetDateTime("Date").ToString("yyyy-MM-dd");
                    counter = myReader.GetString("totalCOunt");

                    this.chart1.Series["Vente"].Points.AddXY(day, counter);

                }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }


        public void countachat()
        {
            string Query6 = "SELECT DATE(datein) Date, COUNT(DISTINCT id_achat) totalCOunt FROM fms_db.achat  where  datein between '" + dateTimePicker5.Text + "' and '" + dateTimePicker6.Text + "' Group By datein ";

            MySqlConnection ConDataBase6 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase6 = new MySqlCommand(Query6, ConDataBase6);
            MySqlDataReader myReader6;
            try
            {
                ConDataBase6.Open();
                myReader6 = CmdDataBase6.ExecuteReader();

                while (myReader6.Read())
                {
                    if (myReader6["Date"] != DBNull.Value)
                    {
                        day = myReader6.GetDateTime("Date").ToString("yyyy-MM-dd");
                        counter = myReader6.GetString("totalCOunt");

                        this.chart1.Series["Achat"].Points.AddXY(day, counter);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }



            sommepay();
            sommeunpay();
            this.chart3.Series["Somme"].Points.AddXY("Payé (dt)", Math.Round(spay, 3));
            this.chart3.Series["Somme"].Points.AddXY("Non Payé (dt)", Math.Round(snpay, 3));
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            sommepay();
            sommeunpay();

            this.chart3.Series["Somme"].Points.AddXY("Payé (dt)", Math.Round(spay, 3));
            this.chart3.Series["Somme"].Points.AddXY("Non Payé (dt)", Math.Round(snpay, 3));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            ppay();
            nnpay();
            this.chart2.Series["Vente"].Points.AddXY("Payé", pay - 1);
            this.chart2.Series["Vente"].Points.AddXY("Non Payé", npay - 1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            ppay();
            nnpay();

            this.chart2.Series["Vente"].Points.AddXY("Payé", pay - 1);
            this.chart2.Series["Vente"].Points.AddXY("Non Payé", npay - 1);
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

        private void UserControl0_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Text = Program.firstday;
            dateTimePicker3.Text = Program.firstday;
            dateTimePicker4.Text = dateTimePicker4.Text;

            dateTimePicker5.Text = Program.firstday;





  

        }

    }
}

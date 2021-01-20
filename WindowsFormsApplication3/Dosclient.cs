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
    public partial class Dosclient : Form
    {
        public Dosclient(string ch)
        {
            InitializeComponent();
            id =ch;
        }
        string id ;
        float somme;
        int rowsNbr;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void Dosclient_Load(object sender, EventArgs e)
        {
            string Query = "select nom_client from fms_db.client  where id_client = " + id; // nom du client
            MySqlConnection ConDataBase2 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase2 = new MySqlCommand(Query, ConDataBase2);
            MySqlDataReader myReader;
            try
            {
                ConDataBase2.Open();
                myReader = CmdDataBase2.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("nom_client");
                    label1.Text = nom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // affiich tableau
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select id_facture, num_facture as 'Numero Facture' , date_facture, nom_client, Total, situation, type_paiement, montant_paye, reste_paye from fms_db.vente where id_client = " +  id , ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["id_facture"].Visible = false;
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Query3 = "select  count(*) from fms_db.vente where id_client = " + id; // nbre factur
            MySqlConnection ConDataBase3 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase3 = new MySqlCommand(Query3, ConDataBase3);
            try
            {
                ConDataBase3.Open();
                rowsNbr = Convert.ToInt32(CmdDataBase3.ExecuteScalar());
                ++rowsNbr;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            label3.Text = (rowsNbr-1).ToString();

            string np = "Non Payé";
            string Query4 = "select  count(*) from fms_db.vente where id_client =  '"+id+"' and situation ='"+np+"' ";
            MySqlConnection ConDataBase4 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase4 = new MySqlCommand(Query4, ConDataBase4);
            try
            {
                ConDataBase4.Open();
                rowsNbr = Convert.ToInt32(CmdDataBase4.ExecuteScalar());
                ++rowsNbr;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            label7.Text = (rowsNbr-1).ToString();

            string Query5 = "select * from fms_db.vente where id_client =  '" + id + "' ";
            MySqlConnection ConDataBase5 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase5 = new MySqlCommand(Query5, ConDataBase5);
            MySqlDataReader myReader5;
            try
            {
                ConDataBase5.Open();
                myReader5 = CmdDataBase5.ExecuteReader();
                while (myReader5.Read())
                {
                    float sm = myReader5.GetFloat("reste_paye");
                    somme = somme+sm;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label5.Text = somme.ToString();

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

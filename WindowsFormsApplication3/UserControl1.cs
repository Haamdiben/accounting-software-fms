using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class UserControl1 : UserControl
    {
        private static UserControl1 _instance;
        string idachat, nomfourn;


        public static UserControl1 Instance
        {
            get
            {
                if (_instance == null )

                    _instance = new UserControl1();
                return _instance;
            }
        }

        public UserControl1()
        {
            InitializeComponent();
            dateTimePicker1.Text = Program.firstday;
        }
        public void affichage()
        {
            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select id_achat, nom_fournisseur, prix_achat, payer_par, image_achat, Banque, No from fms_db.achat where datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "';", ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["id_achat"].Visible = false;
                gridView1.Columns["nom_fournisseur"].Caption = "Nom du fournisseur";
                gridView1.Columns["prix_achat"].Caption = "Prix achat";
                gridView1.Columns["payer_par"].Caption = "Payer par";
                gridView1.Columns["image_achat"].Caption = "Image achat";

                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajoutachat ac = new Ajoutachat();
            ac.ShowDialog();
            affichage();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            affichage();

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
                object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_achat");
                object nom = ((GridView)sender).GetRowCellValue(e.RowHandle, "nom_fournisseur");
                idachat = id.ToString();
                nomfourn = nom.ToString();
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (idachat ==null)
            { }
            else 
            { 
                            Previewachat pa = new Previewachat(idachat, nomfourn);
                            pa.ShowDialog();
            
            }
;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idachat == null)
            { }
            else
            {
                Modifachat ma = new Modifachat(idachat);
                ma.ShowDialog();
                affichage();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idachat == null)
            { }
            else
            {
                Suppachat sa = new Suppachat(idachat, nomfourn);
                sa.ShowDialog();
                affichage();
            }
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            affichage();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            affichage();
        }
    }
}

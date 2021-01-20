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

using DevExpress.XtraGrid.Views.Grid;

namespace WindowsFormsApplication3
{
    public partial class UserControl4 : UserControl
    {


        private static UserControl4 _instance;

        public static UserControl4 Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new UserControl4();
                return _instance;
            }
        }

        public void affichage()
        {


            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select * from fms_db.fournisseur;", ConDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;

                gridView2.Columns["nom_fournisseur"].Caption = "Nom Fournisseur";
                gridView2.Columns["des_fournisseur"].Caption = "Descreption Fournisseur";
                
                gridView2.Columns["id_fournisseur"].Visible = false;

                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public UserControl4()
        {
            InitializeComponent();
        }

        string nomfourn, idfourn;
        private void button1_Click(object sender, EventArgs e)
        {
            AjoutFournisseur afr = new AjoutFournisseur();
            afr.ShowDialog();
            affichage();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

            affichage();


        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_fournisseur");
            object nom = ((GridView)sender).GetRowCellValue(e.RowHandle, "nom_fournisseur");
            idfourn = id.ToString();
            nomfourn = nom.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idfourn == null)
            { }
            else
            {
                Modiffournisseur md = new Modiffournisseur(idfourn);
                md.ShowDialog();
                affichage();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idfourn == null)
            { }
            else
            {
                Suppfournisseur sf = new Suppfournisseur(idfourn,nomfourn);
                sf.ShowDialog();
                affichage();

            }
        }
    }
}

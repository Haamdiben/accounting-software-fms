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
    public partial class UserControl5 : UserControl
    {

        private static UserControl5 _instance;
        string idperso, nomperso, pnomfourn;

        public static UserControl5 Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new UserControl5();
                return _instance;
            }
        }

        public UserControl5()
        {
            InitializeComponent();
        }



        public void affichage()
        {

            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select * from fms_db.personnel;", ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;


                gridView1.Columns["nom_personnel"].Caption = "Nom";
                gridView1.Columns["prenom_personnel"].Caption = "Prenom";
                gridView1.Columns["tel_personnel"].Caption = "Télephone";
                gridView1.Columns["adr_personnel"].Caption = "Adresse";
                gridView1.Columns["mail_personnel"].Caption = "E-mail";
                gridView1.Columns["cin"].Caption = "CIN";


                gridView1.Columns["id_personnel"].Visible = false;
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Ajoutpersonnel ap = new Ajoutpersonnel();
            ap.ShowDialog();
            affichage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Paiementperso pp = new Paiementperso();
            pp.ShowDialog();
            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select * from fms_db.personnel;", ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["id_personnel"].Visible = false;
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            affichage();

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_personnel");
            object nom = ((GridView)sender).GetRowCellValue(e.RowHandle, "nom_personnel");
            object pnom = ((GridView)sender).GetRowCellValue(e.RowHandle, "prenom_personnel");

            idperso = id.ToString();
            nomperso = nom.ToString();
            pnomfourn = pnom.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idperso == null)
            { }
            else
            {
                Modifpersonnel mp = new Modifpersonnel(idperso);
                mp.ShowDialog();
                affichage();


            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idperso == null)
            { }
            else
            {
                Suppperso spp = new Suppperso(idperso,nomperso,pnomfourn);
                spp.ShowDialog();
                affichage();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (idperso == null)
            { }
            else
            {
                Affichpaiemnt ap = new Affichpaiemnt(idperso);
                ap.ShowDialog();

            }
            
        }
    }
}

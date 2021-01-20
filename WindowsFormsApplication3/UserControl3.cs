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

    public partial class UserControl3 : UserControl
    {

        private static UserControl3 _instance;
        string idclient,nomclient;

        public static UserControl3 Instance
        {


            get
            {
                if (_instance == null)

                    _instance = new UserControl3();
                return _instance;
            }
        }

        public UserControl3()
        {
            InitializeComponent();
                gridView1.RowClick += gridView1_RowClick;



        }

        public void affichage()
        {

            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select * from fms_db.client;", ConDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["id_client"].Visible = false;


                gridView1.Columns["nom_client"].Caption = "Nom Client";
                gridView1.Columns["adr_client"].Caption = "Adresse Client";
                gridView1.Columns["telf_client"].Caption = "Télephone Fixe";
                gridView1.Columns["telm_client"].Caption = "Télephone Mobile";
                gridView1.Columns["mail_client"].Caption = "E-mail";
                gridView1.Columns["matricule_fiscale"].Caption = "Matricule Fiscale";
                gridView1.Columns["activte_client"].Caption = "Activité";
                gridView1.Columns["max_credit"].Caption = "MAX Crédit";



                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void UserControl3_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Ajoutclient aj = new Ajoutclient();
            aj.ShowDialog();
            affichage();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            affichage();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_client");
             object nom = ((GridView)sender).GetRowCellValue(e.RowHandle, "nom_client");
             idclient = id.ToString();
             nomclient = nom.ToString();

        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (idclient == null)
            { }
            else
            {
                Modifclient mc = new Modifclient(idclient);
                mc.ShowDialog();
                affichage();


            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
 

            if (idclient == null)
            { }
            else
            {
                Suppclient sc = new Suppclient(idclient, nomclient);
                sc.ShowDialog();
                affichage();

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (idclient == null)
            { }
            else
            {
                Dosclient dc = new Dosclient(idclient);
                dc.ShowDialog();
            }
            
        }

     

 
      
 
    }
}

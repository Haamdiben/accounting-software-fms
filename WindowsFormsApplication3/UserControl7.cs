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
    public partial class UserControl7 : UserControl
    {

        private static UserControl7 _instance;

        public static UserControl7 Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new UserControl7();
                return _instance;
            }
        }

        public UserControl7()
        {
            InitializeComponent();
        }
        string iduser;
        string ConString = "datasource=localhost;port=3306;username=root";


        public void affichage()
        {

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand("Select * from fms_db.admin;", ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["id_admin"].Visible = false;
                gridView1.Columns["pass_admin"].Visible = false;
                gridView1.Columns["user_admin"].Caption = "Nom utilisateur";
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajoutuser au = new Ajoutuser();
            au.ShowDialog();
            affichage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (iduser == null)
            { }
            else
            {
                Modifuser mu = new Modifuser(iduser);
                mu.ShowDialog();
                affichage();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (iduser == null)
            { }
            else
            {
                Suppuser su = new Suppuser(iduser);
                su.ShowDialog();
                affichage();

            }
        }

        private void UserControl7_Load(object sender, EventArgs e)
        {
            affichage();

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
    
                object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_admin");
                iduser = id.ToString();
            
        
        }
    }
}

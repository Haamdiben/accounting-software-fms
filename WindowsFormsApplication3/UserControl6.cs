using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class UserControl6 : UserControl
    {


        private static UserControl6 _instance;

        public static UserControl6 Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new UserControl6();
                return _instance;
            }
        }

        public UserControl6()
        {
            InitializeComponent();
        }
        string ConString = "datasource=localhost;port=3306;username=root";




        private void simpleButton1_Click(object sender, EventArgs e)
            {


            string Query = "update  fms_db.parametres  set tva='" + this.textBox1.Text + "',timbre='" + this.textBox2.Text + "'  where id_parametres = 1";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Paramétres modfier avec succées");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UserControl6_Load(object sender, EventArgs e)
        {
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
                    string tv = myReader.GetString("tva");
                    string timbr = myReader.GetString("timbre");
    
                    
                    textBox1.Text = tv;
                    textBox2.Text = timbr;


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ConString = "server=localhost;user=root;port=3306;database=fms_db; charset=utf8;convert zero datetime=True";
            string file =  Program.curdate +"backup.sql";
            using (MySqlConnection conn = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        MessageBox.Show("Fichier generée avec succés.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                        conn.Close();
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            string ConString = "server=localhost;user=root;port=3306;CharSet=utf8;convert zero datetime=True;database=assb3";
            string file = "backup.sql";
                    using (MySqlConnection conn = new MySqlConnection(ConString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(file);
                                conn.Close();
                            }
                        }
                    }
        }
    }
}

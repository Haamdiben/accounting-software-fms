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
    public partial class Paiementperso : Form
    {
        public Paiementperso()
        {
            InitializeComponent();
        }
        string ConString = "datasource=localhost;port=3306;username=root";
        string idselect,typep;
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Paiementperso_Load(object sender, EventArgs e)
        {




            string Query = "select * from fms_db.personnel";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fname = myReader.GetString("nom_personnel");

                    comboBox1.Items.Add(fname);

                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConString = "datasource=localhost;port=3306;username=root";

            string Query = "insert into fms_db.paiement_perso  (id_personnel,nom_personnel,prix,date,type_paiement) values ('" + idselect + "','" + this.comboBox1.Text + "','" + this.textBox2.Text + "','" + this.dateTimePicker1.Text + "','" + typep + "');";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Paiement créer avec succées");
                this.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Query = "select id_personnel from fms_db.personnel where nom_personnel='" + this.comboBox1.Text + "'";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fid = myReader.GetInt32("id_personnel").ToString();

                    idselect = fid;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            typep = "Salaire";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            typep = "Avance";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == ',')
            {
                e.Handled = true;
            }
        }
    }
}

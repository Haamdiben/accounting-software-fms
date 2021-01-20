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
    public partial class Modifuser : Form
    {
        public Modifuser(string ch)
        {
            InitializeComponent();
            id = ch;

        }
        string id;
                string ConString = "datasource=localhost;port=3306;username=root";
                string passpass;
        private void Modifuser_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Administrateur");
            comboBox1.Items.Add("Utilisateur");
            
            
            string Query = "select * from fms_db.admin where id_admin = " + id;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    passpass = myReader.GetString("pass_admin");

                    string tp = myReader.GetString("type");
                    comboBox1.Text = tp;




                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox4.Text == passpass) && (textBox3.Text == textBox2.Text)) { 
            string Query = "update fms_db.admin set pass_admin='" + this.textBox2.Text + "' ,type='" + this.comboBox1.Text + "' where id_admin = " + id;

                MySqlConnection ConDataBase = new MySqlConnection(ConString);

                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    
                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Utilisateur modifer avec succées");
                    this.Close();

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Erreur: Veuillez verifiez les champs ");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

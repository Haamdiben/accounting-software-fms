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
    public partial class Ajoutuser : Form
    {
        public Ajoutuser()
        {
            InitializeComponent();
        }
                   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            comboBox1.Items.Add("Administrateur");
            comboBox1.Items.Add("Utilisateur");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == textBox3.Text) && (comboBox1.Text!="")) { 
            string ConString = "datasource=localhost;port=3306;username=root";

            string Query = "insert into fms_db.admin (user_admin,pass_admin,type) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.comboBox1.Text + "');";

            MySqlConnection ConDataBase = new MySqlConnection(ConString);

            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                MessageBox.Show("Utilisateur ajouter avec succées");
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

        private void Ajoutuser_Load(object sender, EventArgs e)
        {

        }
    }
}

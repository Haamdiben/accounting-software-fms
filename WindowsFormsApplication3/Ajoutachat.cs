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
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Ajoutachat : Form
    {
        public Ajoutachat()
        {
            InitializeComponent();

        }
        string ConString = "datasource=localhost;port=3306;username=root";
        string picloc,payp,idselect;


        private void button1_Click(object sender, EventArgs e)
        {
            if (picloc == null)
            {
                string Query = "insert into fms_db.achat (nom_fournisseur,prix_achat,payer_par,descreption_achat,id_fournisseur,Banque,No,datein) values ('" + this.comboBox1.Text + "','" + this.textBox2.Text + "','" + payp + "','" + this.richTextBox1.Text + "','" + idselect + "','" + this.textBox1.Text + "','" + this.textBox3.Text + "','" +Program.curdate+ "');";
                MySqlConnection ConDataBase = new MySqlConnection(ConString);
                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Achat ajouter avec succées");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                byte[] imagebt = null;
                FileStream fstream = new FileStream(picloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imagebt = br.ReadBytes((int)fstream.Length);

                string Query = "insert into fms_db.achat (nom_fournisseur,prix_achat,payer_par,descreption_achat,id_fournisseur,Banque,No,datein,image_achat) values ('" + this.comboBox1.Text + "','" + this.textBox2.Text + "','" + payp + "','" + this.richTextBox1.Text + "','" + idselect + "','" + this.textBox1.Text + "','" + this.textBox3.Text + "','" + Program.curdate + "',@IMG);";
                MySqlConnection ConDataBase = new MySqlConnection(ConString);
                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    CmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imagebt));
                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Achat ajouter avec succées");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }





        }

        private void Ajoutachat_Load(object sender, EventArgs e)
        {

            string Query = "select * from fms_db.fournisseur";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fname = myReader.GetString("nom_fournisseur");

                    comboBox1.Items.Add(fname);

                }
               
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                 picloc = dlg.FileName.ToString();
                
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            payp = "Cheque";
            label6.Visible = true;
            textBox1.Visible = true;
            label7.Visible = true;
            textBox3.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            payp = "Traite";
            label6.Visible = false;
            textBox1.Visible = false;
            label7.Visible = true;
            textBox3.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Query = "select * from fms_db.fournisseur where nom_fournisseur='" + this.comboBox1.Text + "'";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {

                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string fid = myReader.GetInt32("id_fournisseur").ToString();
                    idselect = fid;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        



        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            payp = "Espèces";
            label6.Visible = false;
            textBox1.Visible = false;
            label7.Visible = false;
            textBox3.Visible = false;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if ( ch ==',')
            {
                    e.Handled = true;
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

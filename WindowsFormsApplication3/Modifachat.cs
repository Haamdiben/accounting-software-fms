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
    public partial class Modifachat : Form
    {

        public Modifachat(string id)
        {
            InitializeComponent();
            ida = id;


            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        string ida,payp,picloc,idselect;
        string ConString = "datasource=localhost;port=3306;username=root";

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picloc = dlg.FileName.ToString();

            }
        }

        private void Modifachat_Load(object sender, EventArgs e)


        {

            string Query2 = "select * from fms_db.fournisseur";
            MySqlConnection ConDataBase2 = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase2 = new MySqlCommand(Query2, ConDataBase2);
            MySqlDataReader myReader2;
            try
            {

                ConDataBase2.Open();
                myReader2 = CmdDataBase2.ExecuteReader();
                while (myReader2.Read())
                {
                    string fname = myReader2.GetString("nom_fournisseur");
                    comboBox1.Items.Add(fname);

                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Query = "select * from fms_db.achat where id_achat = " + ida;
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = CmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string nomf = myReader.GetString("nom_fournisseur");
                    double pa = myReader.GetDouble("prix_achat");
                    payp = myReader.GetString("payer_par");
                    string da = myReader.GetString("descreption_achat");
                    string banque = myReader.GetString("Banque");
                    string No = myReader.GetString("No");
                    
                    comboBox1.Text = nomf;
                    textBox1.Text = banque;
                    textBox3.Text = No;

                    textBox2.Text = pa.ToString();
                    richTextBox1.Text = da;
                    if (payp == "Traite")
                    {
                        this.radioButton2.Checked = true;
                        label6.Visible = false;
                        textBox1.Visible = false;
                        label7.Visible = true;
                        textBox3.Visible = true;
                    }
                    else if (payp == "Cheque")
                    {
                        this.radioButton1.Checked = true;
                        label6.Visible = true;
                        textBox1.Visible = true;
                        label7.Visible = true;
                        textBox3.Visible = true;

                    }

                    else if (payp == "Espèces")
                    {
                        this.radioButton3.Checked = true;

                    }
 



                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (picloc == null)
            {
                string Query = "update fms_db.achat set nom_fournisseur='" + this.comboBox1.Text + "',prix_achat='" + this.textBox2.Text + "',payer_par='" + payp + "',descreption_achat='" + this.richTextBox1.Text + "',id_fournisseur='" + idselect + "' ,Banque='" + this.textBox1.Text + "', No='" + this.textBox3.Text + "' where id_achat = " + ida;

                MySqlConnection ConDataBase = new MySqlConnection(ConString);

                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    
                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Achat Modifer avec succées");
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
                string Query = "update fms_db.achat set nom_fournisseur='" + this.comboBox1.Text + "',id_fournisseur='" + idselect + "',prix_achat='" + this.textBox2.Text + "',payer_par='" + payp + "',descreption_achat='" + this.richTextBox1.Text + "',Banque='" + this.textBox1.Text + "', No='" + this.textBox3.Text + "',image_achat=@IMG where id_achat = " + ida;

                MySqlConnection ConDataBase = new MySqlConnection(ConString);

                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    CmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imagebt));

                    myReader = CmdDataBase.ExecuteReader();
                    MessageBox.Show("Achat Modifer avec succées");
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            payp = "Espèces";
            label6.Visible = false;
            textBox1.Visible = false;
            label7.Visible = false;
            textBox3.Visible = false;

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

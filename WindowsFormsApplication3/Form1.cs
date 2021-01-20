using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand(" select * from fms_db.admin where user_admin ='"+ this.textEdit2.Text +"' and pass_admin ='" +this.textEdit3.Text+"' ;", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    this.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else if (count > 1)
                {

                    MessageBox.Show("Duplicate");
                }

                else

                    labelControl2.Visible = true;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        private void opennewform(object obj)
        {
            Application.Run(new Form2());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

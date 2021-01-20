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
using System.Drawing.Printing;

namespace WindowsFormsApplication3
{
    public partial class Previewachat : Form
    {
        public Previewachat(string id,string nom)
        {
            InitializeComponent();
            ida = id;

        }
        string ConString = "datasource=localhost;port=3306;username=root";
        string ida;
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            string Query = "select * from fms_db.achat where id_achat =" +ida ;
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
                    label10.Text = fname;
                    string pachat = myReader.GetString("prix_achat");
                    label3.Text = pachat+" Dt";
                    string dachat = myReader.GetString("descreption_achat");
                    label5.Text = dachat;


                    byte[] imgg = (byte[])(myReader["image_achat"]);
                    if (imgg == null)
                        pictureBox2.Image = null;
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                    }



                }

            }


            catch (Exception ex)
            {
            }
        
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
    }
}

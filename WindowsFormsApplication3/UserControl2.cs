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


using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace WindowsFormsApplication3
{
    public partial class UserControl2 : UserControl
    {
        private static UserControl2 _instance;

        public static UserControl2 Instance
        {

            get
            {
                if (_instance == null)

                    _instance = new UserControl2();
                return _instance;
            }
        }
        public UserControl2()
        {

            InitializeComponent();
            dateTimePicker1.Text = Program.firstday;


        }

        public void affichage()
        {


            string ConString = "datasource=localhost;port=3306;username=root";
            MySqlConnection ConDataBase = new MySqlConnection(ConString);
            string devis = "######";

            MySqlCommand CmdDataBase = new MySqlCommand("Select id_facture, num_facture  , date_facture, nom_client, poids_brut, valeur, poids_net, Total, situation, type_paiement, montant_paye, reste_paye from fms_db.vente  where   num_facture <> '" + devis + "' and datein between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "';", ConDataBase);
            try
            {

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = CmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                gridControl1.DataSource = bSource;
                gridView1.Columns["num_facture"].Caption = "NUM Facture";
                gridView1.Columns["date_facture"].Caption = "Date Facture";
                gridView1.Columns["nom_client"].Caption = "Nom Client";
                gridView1.Columns["poids_brut"].Caption = "Poids brut";
                gridView1.Columns["poids_net"].Caption = "Poids net";
                gridView1.Columns["type_paiement"].Caption = "Type Paiement";
                gridView1.Columns["montant_paye"].Caption = "Montant Payé";
                gridView1.Columns["reste_paye"].Caption = "Reste Payé";


                gridView1.Columns["valeur"].Caption = "Valeur";
                gridView1.Columns["situation"].Caption = "Situation";

                gridView1.Columns["id_facture"].Visible = false;
                sda.Update(dbdataset);


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string numfacture, idvente;
        string somme,sommel,sommev;
        string f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23, f24, f25;
        string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25;
        string factureno, date, nomclient, idclient, adrclient, marchendise, nbrcolis, declaration, poidsbrut, poidsnet, valeur, piecesjointes;
        string situation, typepaiment;
        string dd1, dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10;

        private void UserControl2_Load(object sender, EventArgs e)
        {

            affichage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajoutfacture af = new Ajoutfacture();
            af.ShowDialog();
            affichage();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            object id = ((GridView)sender).GetRowCellValue(e.RowHandle, "id_facture");
            object nom = ((GridView)sender).GetRowCellValue(e.RowHandle, "num_facture");
            idvente = id.ToString();
            numfacture = nom.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idvente == null)
            { }
            else
            {
                Suppfacture sf = new Suppfacture(idvente, numfacture);
                sf.ShowDialog();
                affichage();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (idvente == null)
            { }
            else
            {
                string ConString = "datasource=localhost;port=3306;username=root";

                string Query = "select * from fms_db.vente  where id_facture = " +  idvente;
                MySqlConnection ConDataBase = new MySqlConnection(ConString);
                MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    myReader = CmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        factureno = myReader.GetString("num_facture");
                        date = myReader.GetString("date_facture");
                        nomclient = myReader.GetString("nom_client");
                        adrclient= myReader.GetString("adr_client");
                        marchendise = myReader.GetString("marchendises");
                        nbrcolis = myReader.GetString("nbre_colis");
                        //declaration = myReader.GetString("declaration");
                        poidsnet = myReader.GetString("poids_net");
                        poidsbrut = myReader.GetString("poids_brut");
                        valeur = myReader.GetString("valeur");
                        sommev = myReader.GetString("sommev");

                        dd1 = myReader.GetString("d1");
                        dd2 = myReader.GetString("d2");
                        dd3 = myReader.GetString("d3");
                        dd4 = myReader.GetString("d4");
                        dd5 = myReader.GetString("d5");
                        dd6 = myReader.GetString("d6");
                        dd7 = myReader.GetString("d7");
                        dd8 = myReader.GetString("d8");
                        dd9 = myReader.GetString("d9");
                        dd10 = myReader.GetString("d10");
                        piecesjointes = myReader.GetString("picesjointes");

                        f1 = myReader.GetString("Timbre_declaration_fms");
                        f2 = myReader.GetString("Timbre_dimension_fms");
                        f3 = myReader.GetString("Droits_Douanes_fms");
                        f4 = myReader.GetString("PV_RETARD_fms");
                        f5 = myReader.GetString("Autres_PV_fms");
                        f6 = myReader.GetString("TAV_fms");
                        f7 = myReader.GetString("Avis_Compagnie_fms");
                        f8 = myReader.GetString("Frais_magasinage_fms");
                        f9 = myReader.GetString("Assurances_fms");
                        f10 = myReader.GetString("Document_685_fms");
                        f11 = myReader.GetString("Correspandance_fms");
                        f12 = myReader.GetString("Frais_Fixes_fms");
                        f13 = myReader.GetString("Privilege_Fiscale_fms");
                        f14 = myReader.GetString("DUCV_fms");
                        f15 = myReader.GetString("Frais_visite_fms");
                        f16 = myReader.GetString("importation_dispense_fms");
                        f17 = myReader.GetString("Frais_deplacement_fms");
                        f18 = myReader.GetString("Photocopie_fms");
                        f19 = myReader.GetString("Declaration_UC_fms");
                        f20 = myReader.GetString("TTN_fms");
                        f21 = myReader.GetString("Informatique_fms");
                        f22 = myReader.GetString("Horaire_fms");
                        f23 = myReader.GetString("TVA_fms");
                        f24 = myReader.GetString("Autres_frais_fms");
                        f25 = myReader.GetString("Timbre_fiscale_fms");

                        c1 = myReader.GetString("Timbre_declaration_client");
                        c2 = myReader.GetString("Timbre_dimension_client");
                        c3 = myReader.GetString("Droits_Douanes_client");
                        c4 = myReader.GetString("PV_RETARD_client");
                        c5 = myReader.GetString("Autres_PV_client");
                        c6 = myReader.GetString("TAV_client");
                        c7 = myReader.GetString("Avis_Compagnie_client");
                        c8 = myReader.GetString("Frais_magasinage_client");
                        c9 = myReader.GetString("Assurances_client");
                        c10 = myReader.GetString("Document685_client");
                        c11 = myReader.GetString("Correspandance_client");
                        c12 = myReader.GetString("Frais_Fixes_client");
                        c13 = myReader.GetString("Privilege_Fiscale_client");
                        c14 = myReader.GetString("DUCV_client");
                        c15 = myReader.GetString("Frais_visite_client");
                        c16 = myReader.GetString("importation_dispense_client");
                        c17 = myReader.GetString("Frais_deplacement_client");
                        c18 = myReader.GetString("Photocopie_client");
                        c19 = myReader.GetString("Declaration_UC_client");
                        c20 = myReader.GetString("TTN_client");
                        c21 = myReader.GetString("Informatique_client");
                        c22 = myReader.GetString("Horaire_client");
                        c23 = myReader.GetString("TVA_client");
                        c24 = myReader.GetString("Autres_frais_client");
                        c25 = myReader.GetString("Timbre_fiscale_client");
                        somme = myReader.GetString("Total");
                        sommel = myReader.GetString("Total_letters");

                        if ((dd1.Length != 18) && (dd1.Length != 0))
                        {
                            declaration = dd1 + "\r\n";
                        }
                        if ((dd2.Length != 18) && (dd2.Length != 0))
                        {
                            declaration = declaration +dd2 + "\r\n";
                        }
                        if ((dd3.Length != 18) && (dd3.Length != 0))
                        {
                            declaration = declaration + dd3 + "\r\n";
                        }
                        if ((dd4.Length != 18) && (dd4.Length != 0))
                        {
                            declaration = declaration + dd4 + "\r\n";
                        }
                        if ((dd5.Length != 18) && (dd5.Length != 0))
                        {
                            declaration = declaration + dd5 + "\r\n";
                        }
                        if ((dd6.Length != 18) && (dd6.Length != 0))
                        {
                            declaration = declaration + dd6 + "\r\n";
                        }
                        if ((dd7.Length != 18) && (dd7.Length != 0))
                        {
                            declaration = declaration + dd7 + "\r\n";
                        }
                        if ((dd8.Length != 18) && (dd8.Length != 0))
                        {
                            declaration = declaration + dd8 + "\r\n";
                        }
                        if ((dd9.Length != 18) && (dd9.Length != 0))
                        {
                            declaration = declaration + dd9 + "\r\n";
                        }
                        if ((dd10.Length != 18) && (dd10.Length != 0))
                        {
                            declaration = declaration + dd10 ;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                XtraReport1 report = new XtraReport1(0);
                report.Parameters["parameter1"].Value = factureno;
                report.Parameters["parameter1"].Visible = false;
                report.Parameters["parameter2"].Value = date.Substring(0,10);
                report.Parameters["parameter2"].Visible = false;
                report.Parameters["parameter3"].Value = nomclient;
                report.Parameters["parameter3"].Visible = false;
                report.Parameters["parameter4"].Value = adrclient;
                report.Parameters["parameter4"].Visible = false;
                report.Parameters["parameter5"].Value = marchendise;
                report.Parameters["parameter5"].Visible = false;
                report.Parameters["parameter6"].Value = nbrcolis;
                report.Parameters["parameter6"].Visible = false;
                report.Parameters["parameter7"].Value = declaration;
                report.Parameters["parameter7"].Visible = false;
                report.Parameters["parameter8"].Value = poidsbrut;
                report.Parameters["parameter8"].Visible = false;
                report.Parameters["parameter9"].Value = poidsnet;
                report.Parameters["parameter9"].Visible = false;
                report.Parameters["parameter10"].Value = sommev+" "+valeur;
                report.Parameters["parameter10"].Visible = false;

                report.Parameters["parameter11"].Value = piecesjointes;
                report.Parameters["parameter11"].Visible = false;
                
                report.Parameters["parameter12"].Value = c1;
                report.Parameters["parameter12"].Visible = false;
                report.Parameters["parameter13"].Value = c2;
                report.Parameters["parameter13"].Visible = false;
                report.Parameters["parameter14"].Value = c3;
                report.Parameters["parameter14"].Visible = false;
                report.Parameters["parameter15"].Value = c4;
                report.Parameters["parameter15"].Visible = false;
                report.Parameters["parameter16"].Value = c5;
                report.Parameters["parameter16"].Visible = false;
                report.Parameters["parameter17"].Value = c6;
                report.Parameters["parameter17"].Visible = false;
                report.Parameters["parameter18"].Value = c7;
                report.Parameters["parameter18"].Visible = false;
                report.Parameters["parameter19"].Value = c8;
                report.Parameters["parameter19"].Visible = false;
                report.Parameters["parameter20"].Value = c9;
                report.Parameters["parameter20"].Visible = false;
                report.Parameters["parameter21"].Value = c10;
                report.Parameters["parameter21"].Visible = false;
                report.Parameters["parameter22"].Value = c11;
                report.Parameters["parameter22"].Visible = false;
                report.Parameters["parameter23"].Value = c12;
                report.Parameters["parameter23"].Visible = false;
                report.Parameters["parameter24"].Value = c13;
                report.Parameters["parameter24"].Visible = false;
                report.Parameters["parameter25"].Value = c14;
                report.Parameters["parameter25"].Visible = false;
                report.Parameters["parameter26"].Value = c15;
                report.Parameters["parameter26"].Visible = false;
                report.Parameters["parameter27"].Value = c16;
                report.Parameters["parameter27"].Visible = false;
                report.Parameters["parameter28"].Value = c17;
                report.Parameters["parameter28"].Visible = false;
                report.Parameters["parameter29"].Value = c18;
                report.Parameters["parameter29"].Visible = false;
                report.Parameters["parameter30"].Value = c19;
                report.Parameters["parameter30"].Visible = false;
                report.Parameters["parameter31"].Value = c20;
                report.Parameters["parameter31"].Visible = false;
                report.Parameters["parameter32"].Value = c21;
                report.Parameters["parameter32"].Visible = false;
                report.Parameters["parameter33"].Value = c22;
                report.Parameters["parameter33"].Visible = false;
                report.Parameters["parameter34"].Value = c23;
                report.Parameters["parameter34"].Visible = false;
                report.Parameters["parameter35"].Value = c24;
                report.Parameters["parameter35"].Visible = false;
                report.Parameters["parameter36"].Value = c25;
                report.Parameters["parameter36"].Visible = false;
                report.Parameters["parameter37"].Value = f1;
                report.Parameters["parameter37"].Visible = false;
                report.Parameters["parameter38"].Value = f2;
                report.Parameters["parameter38"].Visible = false;
                report.Parameters["parameter39"].Value = f3;
                report.Parameters["parameter39"].Visible = false;
                report.Parameters["parameter40"].Value = f4;
                report.Parameters["parameter40"].Visible = false;
                report.Parameters["parameter41"].Value = f5;
                report.Parameters["parameter41"].Visible = false;
                report.Parameters["parameter42"].Value = f6;
                report.Parameters["parameter42"].Visible = false;
                report.Parameters["parameter43"].Value = f7;
                report.Parameters["parameter43"].Visible = false;
                report.Parameters["parameter44"].Value = f8;
                report.Parameters["parameter44"].Visible = false;
                report.Parameters["parameter45"].Value = f9;
                report.Parameters["parameter45"].Visible = false;
                report.Parameters["parameter46"].Value = f10;
                report.Parameters["parameter46"].Visible = false;
                report.Parameters["parameter47"].Value = f11;
                report.Parameters["parameter47"].Visible = false;
                report.Parameters["parameter48"].Value = f12;
                report.Parameters["parameter48"].Visible = false;
                report.Parameters["parameter49"].Value = f13;
                report.Parameters["parameter49"].Visible = false;
                report.Parameters["parameter50"].Value = f14;
                report.Parameters["parameter50"].Visible = false;
                report.Parameters["parameter51"].Value = f15;
                report.Parameters["parameter51"].Visible = false;
                report.Parameters["parameter52"].Value = f16;
                report.Parameters["parameter52"].Visible = false;
                report.Parameters["parameter53"].Value = f17;
                report.Parameters["parameter53"].Visible = false;
                report.Parameters["parameter54"].Value = f18;
                report.Parameters["parameter54"].Visible = false;
                report.Parameters["parameter55"].Value = f19;
                report.Parameters["parameter55"].Visible = false;
                report.Parameters["parameter56"].Value = f20;
                report.Parameters["parameter56"].Visible = false;
                report.Parameters["parameter57"].Value = f21;
                report.Parameters["parameter57"].Visible = false;
                report.Parameters["parameter58"].Value = f22;
                report.Parameters["parameter58"].Visible = false;
                report.Parameters["parameter59"].Value = f23;
                report.Parameters["parameter59"].Visible = false;
                report.Parameters["parameter60"].Value = f24;
                report.Parameters["parameter60"].Visible = false;
                report.Parameters["parameter61"].Value = f25;
                report.Parameters["parameter61"].Visible = false;
                report.Parameters["parameter62"].Value = somme;
                report.Parameters["parameter62"].Visible = false;
                report.Parameters["parameter63"].Value = sommel;
                report.Parameters["parameter63"].Visible = false;

                /*
               report.Parameters["parameter64"].Value = c21;
               report.Parameters["parameter64"].Visible = false;*/

                


                // Show the report's preview. 
                ReportPrintTool tool = new ReportPrintTool(report);

                tool.ShowPreview();


            }
           






        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idvente == null)
            { }
            else
            {
                Modiffact mf = new Modiffact(idvente);
                mf.ShowDialog();
                affichage();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            affichage();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            affichage();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

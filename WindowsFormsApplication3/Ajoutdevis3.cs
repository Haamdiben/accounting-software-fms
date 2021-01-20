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
    public partial class Ajoutdevis3 : Form
    {
        public Ajoutdevis3(string ch100, string ch0, string ch1, string ch2, string ch3, string ch4, string ch5, string ch6, string ch7, string ch8, string ch9, string ch10, string ch11, string ch12, string ch13, string ch14, string ch15, string ch16, string ch17, string ch18, string ch19, string ch20, string ch21, string ch22, string ch23, string ch24, string ch25, string ch26, string ch27, string ch28, string ch29, string ch30, string ch31, string ch32, string ch33, string ch34, string ch35, string ch36, string ch37, string ch38, string ch39, string ch40, string ch41, string ch42, string ch43, string ch44, string ch45, string ch46, string ch47, string ch48, string ch49, string ch50, string ch51, string ch52, string ch53, string ch54, string ch55, string ch56, string d1, string d2, string d3, string d4, string d5, string d6, string d7, string d8, string d9, string d10, string ch58, string ch59, string ch660, string ch60, string ch61, string mc)
        {
            InitializeComponent();
            somme = ch100;
            maxc = mc;
            f1 = ch0;
            f2 = ch1;
            f3 = ch2;
            f4 = ch3;
            f5 = ch4;
            f6 = ch5;
            f7 = ch6;
            f8 = ch7;
            f9 = ch8;
            f10 = ch9;
            f11 = ch10;
            f12 = ch11;
            f13 = ch12;
            f14 = ch13;
            f15 = ch14;
            f16 = ch15;
            f17 = ch16;
            f18 = ch17;
            f19 = ch18;
            f20 = ch19;
            f21 = ch20;
            f22 = ch21;
            f23 = ch22;
            f24 = ch23;
            f25 = ch24;
            c1 = ch25;
            c2 = ch26;
            c3 = ch27;
            c4 = ch28;
            c5 = ch29;
            c6 = ch30;
            c7 = ch31;
            c8 = ch32;
            c9 = ch33;
            c10 = ch34;
            c11 = ch35;
            c12 = ch36;
            c13 = ch37;
            c14 = ch38;
            c15 = ch39;
            c16 = ch40;
            c17 = ch41;
            c18 = ch42;
            c19 = ch43;
            c20 = ch44;
            c21 = ch45;
            c22 = ch46;
            c23 = ch47;
            c24 = ch48;
            c25 = ch49;
            factureno = ch50;
            date = ch51;
            nomclient = ch52;
            idclient = ch53;

            adrclient = ch54;
            marchendise = ch55;
            nbrcolis = ch56;

            dd1 = d1;
            dd2 = d2;
            dd3 = d3;
            dd4 = d4;
            dd5 = d5;
            dd6 = d6;
            dd7 = d7;
            dd8 = d8;
            dd9 = d9;
            dd10 = d10;


            poidsbrut = ch58;
            poidsnet = ch59;
            sommev = ch660;
            valeur = ch60;
            piecesjointes = ch61;
        }
        public int GetItemCode
        {
            get { return cl; }
        }
        string somme, sommel, sommev, maxc;
        int cl;
        double reste;
        string f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23, f24, f25;
        string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25;
        string factureno, date, nomclient, idclient, adrclient, marchendise, nbrcolis, declaration, poidsbrut, poidsnet, valeur, piecesjointes;
        string situation, typepaiment;
        string dd1, dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10;


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ajoutdevis3_Load(object sender, EventArgs e)
        {
            label12.Text = somme + " DT";
            label10.Text = factureno;
            label4.Text = date;
            label5.Text = nomclient;
            label9.Text = adrclient;

            sommel = Program.converti(float.Parse(somme));
        }

        private void button1_Click(object sender, EventArgs e)
        {



                        string ConString = "datasource=localhost;port=3306;username=root";

                        string Query = "insert into fms_db.vente (num_facture, date_facture, nom_client, id_client, adr_client, marchendises, nbre_colis, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10,poids_brut,sommev, valeur, poids_net, picesjointes, Timbre_declaration_client, Timbre_declaration_fms, Timbre_dimension_client, Timbre_dimension_fms, Droits_Douanes_client, Droits_Douanes_fms, PV_RETARD_client, PV_RETARD_fms, Autres_PV_client, Autres_PV_fms, TAV_client, TAV_fms, Avis_Compagnie_client, Avis_Compagnie_fms, Frais_magasinage_client, Frais_magasinage_fms, Assurances_client, Assurances_fms, Document685_client, Document_685_fms, Correspandance_client, Correspandance_fms, Frais_Fixes_client, Frais_Fixes_fms, Privilege_Fiscale_client, Privilege_Fiscale_fms, DUCV_client, DUCV_fms, Frais_visite_client, Frais_visite_fms, importation_dispense_client, importation_dispense_fms, Frais_deplacement_client, Frais_deplacement_fms, Photocopie_client, Photocopie_fms, Declaration_UC_client, Declaration_UC_fms, TTN_client, TTN_fms, Informatique_client, Informatique_fms, Horaire_client, Horaire_fms, TVA_client, TVA_fms, Autres_frais_client, Autres_frais_fms, Timbre_fiscale_client, Timbre_fiscale_fms, Total, Total_letters,datein) values ('" + factureno + "','" + date + "','" + nomclient + "','" + idclient + "', '" + adrclient + "', '" + marchendise + "', '" + nbrcolis + "','" + dd1 + "','" + dd2 + "','" + dd3 + "','" + dd4 + "','" + dd5 + "','" + dd6 + "','" + dd7 + "','" + dd8 + "','" + dd9 + "','" + dd10 + "', '" + poidsbrut + "',  '" + sommev + "' ,'" + valeur + "' ,'" + poidsnet + "', '" + piecesjointes + "' , '" + c1 + "','" + f1 + "', '" + c2 + "','" + f2 + "','" + c3 + "','" + f3 + "', '" + c4 + "', '" + f4 + "', '" + c5 + "','" + f5 + "', '" + c6 + "','" + f6 + "', '" + c7 + "','" + f7 + "', '" + c8 + "','" + f8 + "', '" + c9 + "', '" + f9 + "', '" + c10 + "','" + f10 + "', '" + c11 + "','" + f11 + "', '" + c12 + "','" + f12 + "', '" + c13 + "','" + f13 + "', '" + c14 + "', '" + f14 + "', '" + c15 + "', '" + f15 + "', '" + c16 + "','" + f16 + "', '" + c17 + "','" + f17 + "', '" + c18 + "','" + f18 + "', '" + c19 + "','" + f19 + "', '" + c20 + "','" + f20 + "', '" + c21 + "', '" + f21 + "', '" + c22 + "','" + f22 + "', '" + c23 + "', '" + f23 + "', '" + c24 + "','" + f24 + "', '" + c25 + "', '" + f25 + "', '" + somme + "','" + sommel + "','" + Program.curdate + "');";

                        MySqlConnection ConDataBase = new MySqlConnection(ConString);

                        MySqlCommand CmdDataBase = new MySqlCommand(Query, ConDataBase);
                        MySqlDataReader myReader;
                        try
                        {
                            ConDataBase.Open();
                            myReader = CmdDataBase.ExecuteReader();
                            MessageBox.Show("Facture créer avec succées");
                            cl = 1;

                            this.Close();
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }



                
            
        }
    }
}

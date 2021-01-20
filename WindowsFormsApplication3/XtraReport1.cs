using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication3
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(int io)
        {
            InitializeComponent();
            test= io;

        }
        int test;

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


                
                if ((xrLabel54.Text == "0") && (xrLabel79.Text == "0"))
                xrTable2.DeleteRow(xrTableRow6);
            if ((xrLabel55.Text == "0") && (xrLabel80.Text == "0"))
                xrTable2.DeleteRow(xrTableRow7);
            if ((xrLabel56.Text == "0") && (xrLabel81.Text == "0"))
                xrTable2.DeleteRow(xrTableRow8);
            if ((xrLabel57.Text == "0") && (xrLabel82.Text == "0"))
                xrTable2.DeleteRow(xrTableRow9);
            if ((xrLabel58.Text == "0") && (xrLabel83.Text == "0"))
                xrTable2.DeleteRow(xrTableRow10);
            if ((xrLabel59.Text == "0") && (xrLabel84.Text == "0"))
                xrTable2.DeleteRow(xrTableRow11);
            if ((xrLabel60.Text == "0") && (xrLabel85.Text == "0"))
                xrTable2.DeleteRow(xrTableRow12);
            if ((xrLabel61.Text == "0") && (xrLabel86.Text == "0"))
                xrTable2.DeleteRow(xrTableRow13);
            if ((xrLabel62.Text == "0") && (xrLabel87.Text == "0"))
                xrTable2.DeleteRow(xrTableRow14);
            if ((xrLabel63.Text == "0") && (xrLabel88.Text == "0"))
                xrTable2.DeleteRow(xrTableRow15);
            if ((xrLabel64.Text == "0") && (xrLabel89.Text == "0"))
                xrTable2.DeleteRow(xrTableRow16);
            if ((xrLabel65.Text == "0") && (xrLabel90.Text == "0"))
                xrTable2.DeleteRow(xrTableRow17);
            if ((xrLabel66.Text == "0") && (xrLabel91.Text == "0"))
                xrTable2.DeleteRow(xrTableRow18);
            if ((xrLabel67.Text == "0") && (xrLabel92.Text == "0"))
                xrTable2.DeleteRow(xrTableRow19);
            if ((xrLabel68.Text == "0") && (xrLabel93.Text == "0"))
                xrTable2.DeleteRow(xrTableRow20);
            if ((xrLabel69.Text == "0") && (xrLabel94.Text == "0"))
                xrTable2.DeleteRow(xrTableRow21);
            if ((xrLabel70.Text == "0") && (xrLabel95.Text == "0"))
                xrTable2.DeleteRow(xrTableRow22);
            if ((xrLabel71.Text == "0") && (xrLabel96.Text == "0"))
                xrTable2.DeleteRow(xrTableRow23);
            if ((xrLabel72.Text == "0") && (xrLabel97.Text == "0"))
                xrTable2.DeleteRow(xrTableRow24);
            if ((xrLabel73.Text == "0") && (xrLabel98.Text == "0"))
                xrTable2.DeleteRow(xrTableRow25);
            if ((xrLabel74.Text == "0") && (xrLabel99.Text == "0"))
                xrTable2.DeleteRow(xrTableRow26);
            if ((xrLabel75.Text == "0") && (xrLabel100.Text == "0"))
                xrTable2.DeleteRow(xrTableRow27);
            if ((xrLabel76.Text == "0") && (xrLabel101.Text == "0"))
                xrTable2.DeleteRow(xrTableRow28);
            if ((xrLabel77.Text == "0") && (xrLabel102.Text == "0"))
                xrTable2.DeleteRow(xrTableRow29);
            if ((xrLabel78.Text == "0") && (xrLabel103.Text == "0"))
                xrTable2.DeleteRow(xrTableRow30);



            
        }

        private void xrTable2_Draw(object sender, DrawEventArgs e)
        {
          
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                // Adjust text watermark settings.
            if (test==1)
            { 
                Watermark.Text = "DEVIS";
                Watermark.Font = new Font(Watermark.Font.FontFamily, 145);
                Watermark.ForeColor = Color.Red;
                Watermark.TextTransparency = 80;
                Watermark.ShowBehind = true;
                Watermark.PageRange = "1,2,3,4,5";
            }
        }



    }
}

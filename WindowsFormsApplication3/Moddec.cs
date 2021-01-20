using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Moddec : Form
    {
        public Moddec(string ch1, string ch2, string ch3, string ch4, string ch5, string ch6, string ch7, string ch8, string ch9, string ch10)
        {
            InitializeComponent();

            dd1 = ch1;
            dd2 = ch2;
            dd3 = ch3;
            dd4 = ch4;
            dd5 = ch5;
            dd6 = ch6;
            dd7 = ch7;
            dd8 = ch8;
            dd9 = ch9;
            dd10 = ch10;

        }
        public string GetItemCode
        {
            get { return d1; }
        }
        public string GetItemCode2
        {
            get { return d2; }
        }
        public string GetItemCode3
        {
            get { return d3; }
        }
        public string GetItemCode4
        {
            get { return d4; }
        }
        public string GetItemCode5
        {
            get { return d5; }
        }
        public string GetItemCode6
        {
            get { return d6; }
        }
        public string GetItemCode7
        {
            get { return d7; }
        }
        public string GetItemCode8
        {
            get { return d8; }
        }
        public string GetItemCode9
        {
            get { return d9; }
        }
        public string GetItemCode10
        {
            get { return d10; }
        }
        string dd1,dd2, dd3, dd4, dd5, dd6, dd7, dd8, dd9, dd10;
                string d1, d2, d3, d4, d5, d6, d7, d8, d9, d10;


        private void Moddec_Load(object sender, EventArgs e)
        {
            if ((dd1 != null) && (dd1.Length != 18) && (dd1 != ""))
            {
                int spacePos = dd1.IndexOf("No");
                textBox4.Text = dd1.Substring(0, spacePos - 1);
                int spacePos2 = dd1.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox4.Text.Length + 4);
                textBox8.Text = dd1.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker2.Text = dd1.Substring(dd1.Length - 10, 10);
            }
            if ((dd2 != null) && (dd2.Length != 18) && (dd2 != ""))
            {
                int spacePos = dd2.IndexOf("No");
                textBox2.Text = dd2.Substring(0, spacePos - 1);
                int spacePos2 = dd2.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox2.Text.Length + 4);
                textBox1.Text = dd2.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker1.Text = dd2.Substring(dd2.Length - 10, 10);
            }
            if ((dd3 != null) && (dd3.Length != 18) && (dd3 != ""))
            {
                int spacePos = dd3.IndexOf("No");
                textBox5.Text = dd3.Substring(0, spacePos - 1);
                int spacePos2 = dd3.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox5.Text.Length + 4);
                textBox3.Text = dd3.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker3.Text = dd3.Substring(dd3.Length - 10, 10);
            }
            if ((dd4 != null) && (dd4.Length != 18) && (dd4!= ""))
            {
                int spacePos = dd4.IndexOf("No");
                textBox7.Text = dd4.Substring(0, spacePos - 1);
                int spacePos2 = dd4.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox7.Text.Length + 4);
                textBox6.Text = dd4.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker4.Text = dd4.Substring(dd4.Length - 10, 10);
            }
            if ((dd5 != null) && (dd5.Length != 18) && (dd5 != ""))
            {
                int spacePos = dd5.IndexOf("No");
                textBox10.Text = dd5.Substring(0, spacePos - 1);
                int spacePos2 = dd5.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox10.Text.Length + 4);
                textBox9.Text = dd5.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker5.Text = dd5.Substring(dd5.Length - 10, 10);
            }
            if ((dd6 != null) && (dd6.Length != 18) && (dd6 != ""))
            {
                int spacePos = dd6.IndexOf("No");
                textBox20.Text = dd6.Substring(0, spacePos - 1);
                int spacePos2 = dd6.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox20.Text.Length + 4);
                textBox19.Text = dd6.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker10.Text = dd6.Substring(dd6.Length - 10, 10);
            }
            if ((dd7 != null) && (dd7.Length != 18) && (dd7 != ""))
            {
                int spacePos = dd7.IndexOf("No");
                textBox18.Text = dd7.Substring(0, spacePos - 1);
                int spacePos2 = dd7.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox18.Text.Length + 4);
                textBox17.Text = dd7.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker9.Text = dd7.Substring(dd7.Length - 10, 10);
            }
            if ((dd8 != null) && (dd8.Length != 18) && (dd8 != ""))
            {
                int spacePos = dd8.IndexOf("No");
                textBox16.Text = dd8.Substring(0, spacePos - 1);
                int spacePos2 = dd8.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox16.Text.Length + 4);
                textBox15.Text = dd8.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker8.Text = dd8.Substring(dd8.Length - 10, 10);
            }
            if ((dd9 != null) && (dd9.Length != 18) && (dd9 != ""))
            {
                int spacePos = dd9.IndexOf("No");
                textBox14.Text = dd9.Substring(0, spacePos - 1);
                int spacePos2 = dd9.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox14.Text.Length + 4);
                textBox13.Text = dd9.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker7.Text = dd9.Substring(dd9.Length - 10, 10);
            }
            if ((dd10 != null) && (dd10.Length != 18) && (dd10 != ""))
            {
                int spacePos = dd10.IndexOf("No");
                textBox12.Text = dd10.Substring(0, spacePos - 1);
                int spacePos2 = dd10.IndexOf("Du");
                spacePos2 = spacePos2 - (textBox12.Text.Length + 4);
                textBox11.Text = dd10.Substring(spacePos + 3, spacePos2 - 1);
                dateTimePicker6.Text = dd10.Substring(dd10.Length - 10, 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d1 = textBox4.Text + " No " + textBox8.Text + " Du " + dateTimePicker2.Text;
            d2 = textBox2.Text + " No " + textBox1.Text + " Du " + dateTimePicker1.Text;
            d3 = textBox5.Text + " No " + textBox3.Text + " Du " + dateTimePicker3.Text;
            d4 = textBox7.Text + " No " + textBox6.Text + " Du " + dateTimePicker4.Text;
            d5 = textBox10.Text + " No " + textBox9.Text + " Du " + dateTimePicker5.Text;
            d6 = textBox20.Text + " No " + textBox19.Text + " Du " + dateTimePicker10.Text;
            d7 = textBox18.Text + " No " + textBox17.Text + " Du " + dateTimePicker9.Text;
            d8 = textBox16.Text + " No " + textBox15.Text + " Du " + dateTimePicker8.Text;
            d9 = textBox14.Text + " No " + textBox13.Text + " Du " + dateTimePicker7.Text;
            d10 = textBox12.Text + " No " + textBox11.Text + " Du " + dateTimePicker6.Text;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

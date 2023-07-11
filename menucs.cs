using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket_Managment
{
    public partial class menucs : Form
    {
        public menucs()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            CrystalReportForm1 crystalReportForm1 = new CrystalReportForm1();
            crystalReportForm1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CrystalReportForm2 crystalReportForm2 = new CrystalReportForm2();
            crystalReportForm2.Show();
        }

        private void Menucs_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

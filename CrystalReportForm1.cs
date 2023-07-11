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
    public partial class CrystalReportForm1 : Form
    {
        CrystalReport6 cr3;
        public CrystalReportForm1()
        {
            InitializeComponent();
        }

        private void CrystalReportForm1_Load(object sender, EventArgs e)
        {
            cr3 = new CrystalReport6();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr3;
        }
    }
}

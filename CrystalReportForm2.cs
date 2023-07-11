using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SuperMarket_Managment
{
    public partial class CrystalReportForm2 : Form
    {
        CrystalReport1 cr4;
        public CrystalReportForm2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cr4.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = cr4;
        }

        private void CrystalReportForm2_Load(object sender, EventArgs e)
        {
            cr4 = new CrystalReport1();

            foreach(ParameterDiscreteValue v in cr4.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

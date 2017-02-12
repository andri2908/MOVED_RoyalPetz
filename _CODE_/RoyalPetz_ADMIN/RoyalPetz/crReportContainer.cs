using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSoft
{
    public partial class crReportContainer : Form
    {
        public crReportContainer()
        {
            InitializeComponent();
            this.Hide();
        }

        private void crReportContainer_Load(object sender, EventArgs e)
        {
            try
            {
                dummyReport rptXMLReport = new dummyReport();
                crystalReportViewer1.ReportSource = rptXMLReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}

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
    public partial class AboutUsForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public AboutUsForm()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutUsForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void AboutUsForm_Activated(object sender, EventArgs e)
        {
            //read application name and version
            String nameapp = Application.ProductName;
            String verapp = Application.ProductVersion;
            String devapp = Application.CompanyName;
            label7.Text = nameapp;
            label8.Text = verapp;
            label9.Text = devapp;
        }
    }
}

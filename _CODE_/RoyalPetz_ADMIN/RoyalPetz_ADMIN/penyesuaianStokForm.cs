using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPetz_ADMIN
{
    public partial class penyesuaianStokForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public penyesuaianStokForm()
        {
            InitializeComponent();
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void penyesuaianStokForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void penyesuaianStokForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

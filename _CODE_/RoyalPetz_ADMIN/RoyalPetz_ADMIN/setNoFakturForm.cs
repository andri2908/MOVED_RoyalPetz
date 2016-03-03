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
    public partial class setNoFakturForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public setNoFakturForm()
        {
            InitializeComponent();
        }

        private void setNoFakturForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void setNoFakturForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }
    }
}

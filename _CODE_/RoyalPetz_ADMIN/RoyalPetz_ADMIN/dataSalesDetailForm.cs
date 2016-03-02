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
    public partial class dataSalesDetailForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public dataSalesDetailForm()
        {
            InitializeComponent();
        }

        private void dataSalesDetailForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}

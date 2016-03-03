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
    public partial class pembayaranHutangForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public pembayaranHutangForm()
        {
            InitializeComponent();
        }

        private void pembayaranHutangForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void pembayaranHutangForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

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
    public partial class pembayaranPiutangForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public pembayaranPiutangForm()
        {
            InitializeComponent();
        }

        private void pembayaranPiutangForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void pembayaranPiutangForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

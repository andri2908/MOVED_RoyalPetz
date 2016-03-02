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
    public partial class IPPusatForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public IPPusatForm()
        {
            InitializeComponent();
        }

        private void IPPusatForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}

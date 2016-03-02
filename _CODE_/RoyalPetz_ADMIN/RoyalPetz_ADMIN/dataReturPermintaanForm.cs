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
    public partial class dataReturPermintaanForm : Form
    {
        private globalUtilities GUTIL = new globalUtilities();

        public dataReturPermintaanForm()
        {
            InitializeComponent();
        }

        private void dataReturPermintaanForm_Load(object sender, EventArgs e)
        {
            GUTIL.reArrangeTabOrder(this);
        }
    }
}

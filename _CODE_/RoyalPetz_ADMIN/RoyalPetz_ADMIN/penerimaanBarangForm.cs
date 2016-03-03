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
    public partial class penerimaanBarangForm : Form
    {
        string selectedPMInvoice;
        private globalUtilities gutil = new globalUtilities();

        public penerimaanBarangForm()
        {
            InitializeComponent();
        }

        public penerimaanBarangForm(string pmInvoice)
        {
            InitializeComponent();

            selectedPMInvoice = pmInvoice;
        }

        private void penerimaanBarangForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void penerimaanBarangForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

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
    public partial class dataInvoiceForm : Form
    {
        public dataInvoiceForm()
        {
            InitializeComponent();
        }

        private void dataInvoiceDataGridView_DoubleClick(object sender, EventArgs e)
        {
            dataReturPenjualanForm displayedForm = new dataReturPenjualanForm();
            displayedForm.ShowDialog(this);
        }
    }
}

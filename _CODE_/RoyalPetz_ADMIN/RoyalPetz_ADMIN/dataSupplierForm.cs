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
    public partial class dataSupplierForm : Form
    {
        public dataSupplierForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {          
            dataSupplierDetailForm displayedForm = new dataSupplierDetailForm();
            displayedForm.ShowDialog(this);
        }
    }
}

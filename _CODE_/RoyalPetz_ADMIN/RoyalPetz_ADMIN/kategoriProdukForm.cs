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
    public partial class kategoriProdukForm : Form
    {
        public kategoriProdukForm()
        {
            InitializeComponent();
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            kategoriProdukDetailForm displayForm = new kategoriProdukDetailForm();
            displayForm.ShowDialog(this);
        }
    }
}

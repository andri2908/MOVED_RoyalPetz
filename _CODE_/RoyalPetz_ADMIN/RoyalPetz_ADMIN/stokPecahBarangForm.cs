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
    public partial class stokPecahBarangForm : Form
    {
        public stokPecahBarangForm()
        {
            InitializeComponent();
        }

        private void newProduk_Click(object sender, EventArgs e)
        {
            dataProdukDetailForm displayForm = new dataProdukDetailForm(globalConstants.STOK_PECAH_BARANG);
            displayForm.ShowDialog(this);
        }

        private void browseProdukButton_Click(object sender, EventArgs e)
        {
            dataProdukForm displayForm = new dataProdukForm(globalConstants.BROWSE_STOK_PECAH_BARANG);
            displayForm.ShowDialog(this);
        }
    }
}

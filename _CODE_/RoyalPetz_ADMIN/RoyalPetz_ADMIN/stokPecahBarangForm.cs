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
            this.Hide();

            dataProdukDetailForm displayForm = new dataProdukDetailForm();
            displayForm.ShowDialog();

            this.Show();
        }

        private void browseProdukButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayForm = new dataProdukForm(globalConstants.STOK_PECAH_BARANG);
            displayForm.Show();

            this.Show();
        }
    }
}

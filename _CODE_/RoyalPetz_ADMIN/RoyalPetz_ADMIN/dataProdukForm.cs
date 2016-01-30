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
    public partial class dataProdukForm : Form
    {
        private int originModuleID = 0;

        public dataProdukForm()
        {
            InitializeComponent();
        }

        public dataProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                case globalConstants.STOK_PECAH_BARANG: 
                    stokPecahBarangForm displaystokPecahBarangForm = new stokPecahBarangForm();
                    displaystokPecahBarangForm.ShowDialog(this);
                    break;

                case globalConstants.PENYESUAIAN_STOK:
                    penyesuaianStokForm penyesuaianStokForm = new penyesuaianStokForm();
                    penyesuaianStokForm.ShowDialog(this);
                    break;

                default: // MASTER DATA PRODUK
                    dataProdukDetailForm displayForm = new dataProdukDetailForm();
                    displayForm.ShowDialog(this);
                    break;
            }   
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            dataProdukDetailForm displayForm = new dataProdukDetailForm();
            displayForm.ShowDialog(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            displaySpecificForm();
        }

        private void tagProdukDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter
            {
                displaySpecificForm();
            }
        }


    }
}

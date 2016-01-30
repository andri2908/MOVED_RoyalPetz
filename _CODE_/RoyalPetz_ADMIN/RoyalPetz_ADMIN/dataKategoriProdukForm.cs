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
    public partial class dataKategoriProdukForm : Form
    {
        private int originModuleID = 0;

        public dataKategoriProdukForm()
        {
            InitializeComponent();
        }

        public dataKategoriProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            newButton.Visible = false;
        }

        private void displaySpecificForm()
        {
            switch(originModuleID)
            {
                case globalConstants.PENGATURAN_KATEGORI_PRODUK:
                    pengaturanKategoriProdukForm pengaturanKategoriForm = new pengaturanKategoriProdukForm();
                        pengaturanKategoriForm.ShowDialog(this);
                    break;
                default:
                        dataKategoriProdukDetailForm displayedForm = new dataKategoriProdukDetailForm();
                        displayedForm.ShowDialog(this);
                    break;
            }
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            dataKategoriProdukDetailForm displayForm = new dataKategoriProdukDetailForm();
            displayForm.ShowDialog(this);
        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            displaySpecificForm();
        }
    }
}

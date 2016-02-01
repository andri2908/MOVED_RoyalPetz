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
    public partial class dataMutasiBarangForm : Form
    {
        private int originModuleID = 0;

        public dataMutasiBarangForm()
        {
            InitializeComponent();
        }

        public dataMutasiBarangForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if ((moduleID != globalConstants.PERMINTAAN_BARANG) && (moduleID != globalConstants.CEK_DATA_MUTASI))
                newButton.Visible = false;
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                        dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm();
                        displayedForm.ShowDialog(this);
                    break;

                case globalConstants.PERMINTAAN_BARANG:
                        permintaanProdukForm permintaanProdukDisplayedForm = new permintaanProdukForm();
                        permintaanProdukDisplayedForm.ShowDialog(this);
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                        penerimaanBarangForm penerimaanBarangDisplayedForm = new penerimaanBarangForm();
                        penerimaanBarangDisplayedForm.ShowDialog(this);
                    break;
            }
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            displaySpecificForm();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            displaySpecificForm();
        }
    }
}

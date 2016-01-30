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
    public partial class dataMutasiBarangDetailForm : Form
    {
        private int originModuleID = 0;

        public dataMutasiBarangDetailForm()
        {
            InitializeComponent();
        }

        public dataMutasiBarangDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                    reprintButton.Visible = false;
                    break;

                case globalConstants.REPRINT_PERMINTAAN_BARANG:
                    approveButton.Visible = false;
                    rejectButton.Visible = false;
                    break;
            }

        }

    
    }
}

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
    public partial class dataGroupForm : Form
    {
        private int originModuleID = 0;

        public dataGroupForm()
        {
            InitializeComponent();
        }

        public dataGroupForm(int moduleID)
        {
            InitializeComponent();
            
            if (moduleID > 50)
                newButton.Visible = false;
            
            originModuleID = moduleID;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataGroupDetailForm displayForm = new dataGroupDetailForm(originModuleID);
            displayForm.ShowDialog(this);
        }

        private void dataGroupForm_Load(object sender, EventArgs e)
        {

        }

        private void dataSalesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            switch (originModuleID)
            { 
                case globalConstants.PENGATURAN_GRUP_AKSES: 
                    groupAccessModuleForm groupAccessForm = new groupAccessModuleForm();
                    groupAccessForm.ShowDialog(this);
                    break;

                case globalConstants.PENGATURAN_POTONGAN_HARGA:
                    pengaturanPotonganHargaForm pengaturanHargaForm = new pengaturanPotonganHargaForm();
                    pengaturanHargaForm.ShowDialog(this);
                    break;

                default: // TAMBAH / HAPUS GROUP
                    dataGroupDetailForm displayForm = new dataGroupDetailForm(originModuleID);
                    displayForm.ShowDialog(this);
                    break;
            }
        }
    }
}

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
    public partial class dataPermintaanForm : Form
    {
        private int originModuleID = 0;

        public dataPermintaanForm()
        {
            InitializeComponent();
        }

        public dataPermintaanForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            switch(originModuleID)
            {
                case globalConstants.PEMBAYARAN_HUTANG:
                        pembayaranHutangForm pembayaranForm = new pembayaranHutangForm();
                        pembayaranForm.ShowDialog(this);
                    break;

                default:
                        dataReturPermintaanForm displayedForm = new dataReturPermintaanForm();
                        displayedForm.ShowDialog(this);
                    break;

            }


        }
    }
}

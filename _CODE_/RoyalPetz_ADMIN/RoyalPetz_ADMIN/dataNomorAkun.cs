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
    public partial class dataNomorAkun : Form
    {
        private int originModuleID = 0;
        private globalUtilities gutil = new globalUtilities();

        public dataNomorAkun()
        {
            InitializeComponent();
        }

        public dataNomorAkun(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            newButton.Visible = false;
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            switch(originModuleID)
            {
                case globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN:
                    break;

                default:
                        dataNomorAkunDetailForm displayedForm = new dataNomorAkunDetailForm();
                        displayedForm.ShowDialog(this);
                    break;
            }
        }

        private void dataNomorAkun_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {

        }

        private void dataNomorAkun_Activated(object sender, EventArgs e)
        {
            //if need something
        }

        private void accountnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataSalesDataGridView.DataSource = null;
            //loaddata
        }
    }
}

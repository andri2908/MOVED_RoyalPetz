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
    public partial class dataGroupDetailForm : Form
    {
        private int originModuleID = 0;
        public dataGroupDetailForm()
        {
            InitializeComponent();
        }

        public dataGroupDetailForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void dataGroupDetailForm_Load(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.TAMBAH_HAPUS_GROUP_PELANGGAN)
            {
                this.Text = "DATA GROUP PELANGGAN";
            }
            else if (originModuleID == globalConstants.TAMBAH_HAPUS_GROUP_USER)
            {
                this.Text = "DATA GROUP USER";
            }
        }
    }
}

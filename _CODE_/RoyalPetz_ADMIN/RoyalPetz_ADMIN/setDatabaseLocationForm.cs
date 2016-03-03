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
    public partial class setDatabaseLocationForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public setDatabaseLocationForm()
        {
            InitializeComponent();
        }

        private void serverIPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void localhostRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void serverIPRadioButton_Click(object sender, EventArgs e)
        {
            if (serverIPRadioButton.Checked)
            {
                ipAddressMaskedTextbox.Enabled = true;
                localhostRadioButton.Checked = false;
                serverIPRadioButton.Checked = true;
            }
            else
            {
                ipAddressMaskedTextbox.Enabled = false;
                localhostRadioButton.Checked = true;
                serverIPRadioButton.Checked = false;
            }
        }

        private void localhostRadioButton_Click(object sender, EventArgs e)
        {
            if (localhostRadioButton.Checked)
            {
                ipAddressMaskedTextbox.Enabled = false;
                localhostRadioButton.Checked = true;
                serverIPRadioButton.Checked = false;
            }
            else
            {
                ipAddressMaskedTextbox.Enabled = true;
                localhostRadioButton.Checked = false;
                serverIPRadioButton.Checked = true;
            }
        }

        private void setDatabaseLocationForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void setDatabaseLocationForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

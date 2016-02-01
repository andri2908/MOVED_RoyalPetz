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
    public partial class dataUserForm : Form
    {
        private int originModuleID = 0;

        public dataUserForm()
        {
            InitializeComponent();
        }

        public dataUserForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            newButton.Visible = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataUserDetailForm displayForm = new dataUserDetailForm();
            displayForm.ShowDialog(this);
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            switch (originModuleID)
            {
                case globalConstants.CHANGE_PASSWORD:
                    changePasswordForm displayedForm = new changePasswordForm();
                    displayedForm.ShowDialog(this);
                    break;

                default:
                    dataUserDetailForm displayForm = new dataUserDetailForm();
                    displayForm.ShowDialog(this);
                    break;
            }
        }
    }
}

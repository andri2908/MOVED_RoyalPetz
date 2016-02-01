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
    public partial class loginForm : Form
    {
        private int originModuleID = 0;

        public loginForm()
        {
            InitializeComponent();
        }

        public loginForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            if (originModuleID == globalConstants.LOGOUT_FORM)
            {
                label1.Visible = false;
                label7.Visible = false;
                shiftCombobox.Visible = false;
            }
        }
    }
}

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
        public dataGroupForm()
        {
            InitializeComponent();
        }

        public dataGroupForm(int operation)
        {
            InitializeComponent();
            if (operation == 1)
            {
                newButton.Visible = false;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupDetailForm displayForm = new dataGroupDetailForm();
            displayForm.ShowDialog();

            this.Show();
        }
    }
}

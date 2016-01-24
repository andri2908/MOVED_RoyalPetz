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
    public partial class dataSalesForm : Form
    {
        public dataSalesForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataSalesDetailForm displayedForm = new dataSalesDetailForm();
            displayedForm.ShowDialog();

            this.Show();
        }
    }
}

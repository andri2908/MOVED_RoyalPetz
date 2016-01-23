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
    public partial class dataProdukForm : Form
    {
        public dataProdukForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukDetailForm displayForm = new dataProdukDetailForm();
            displayForm.ShowDialog();

            this.Show();
        }
    }
}

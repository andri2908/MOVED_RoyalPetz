using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSoft
{
    public partial class penerimaanBarangHelpForm : Form
    {
        public penerimaanBarangHelpForm()
        {
            InitializeComponent();
        }

        private void penerimaanBarangHelpForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }
    }
}

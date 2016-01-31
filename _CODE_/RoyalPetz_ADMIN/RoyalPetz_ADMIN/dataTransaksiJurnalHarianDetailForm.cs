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
    public partial class dataTransaksiJurnalHarianDetailForm : Form
    {
        public dataTransaksiJurnalHarianDetailForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataNomorAkun displayedForm = new dataNomorAkun(globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN);
            displayedForm.ShowDialog(this);
        }
    }
}

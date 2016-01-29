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
    public partial class permintaanProdukForm : Form
    {

        private void fillInDummyData()
        {
        }

        public permintaanProdukForm()
        {
            InitializeComponent();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            MessageBox.Show(saveFileDialog1.FileName);
        }

        private void permintaanProdukForm_Load(object sender, EventArgs e)
        {
            fillInDummyData();
        }

    }
}

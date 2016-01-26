using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Globalization;


namespace RoyalPetz_ADMIN
{
    public partial class adminForm : Form
    {
        private DateTime localDate = DateTime.Now;
        private CultureInfo culture = new CultureInfo("id-ID");

        public adminForm()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void updateLabel()
        {
            localDate = DateTime.Now;
            timeStampStatusLabel.Text = String.Format(culture, "{0:dddd, dd-MM-yyyy - HH:mm:ss}", localDate);
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            updateLabel();
            timer1.Start();
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabel();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void jenisProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            tagProdukForm displayedForm = new tagProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataPelangganForm displayedForm = new dataPelangganForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataSupplierForm displayedForm = new dataSupplierForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataSalesForm displayedForm = new dataSalesForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupForm displayedForm = new dataGroupForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataUserForm displayedForm = new dataUserForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void pecahBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm(globalConstants.STOK_PECAH_BARANG); // display dataProdukForm for browsing purpose only
            displayedForm.ShowDialog();

            this.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

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
            timeStampStatusLabel.Text = String.Format(culture, "{0:dddd, dd-MM-yyyy - HH:mm}", localDate);
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

        private void stokTaggingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {

        }

        private void infoFolderDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            setDatabaseLocationForm displayedForm = new setDatabaseLocationForm(); 
            displayedForm.ShowDialog();

            this.Show();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            backupRestoreDatabaseForm displayedForm = new backupRestoreDatabaseForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataUserForm displayedForm = new dataUserForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupForm displayedForm = new dataGroupForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void pilihPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(cplPath, "/name Microsoft.DevicesAndPrinters");
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = Image.FromFile(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}

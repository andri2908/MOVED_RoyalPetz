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

            kategoriProdukForm displayedForm = new kategoriProdukForm();
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

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stokTaggingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm(globalConstants.STOK_PECAH_BARANG); // display dataProdukForm for browsing purpose only
            displayedForm.ShowDialog();

            this.Show();
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

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.TAMBAH_HAPUS_GROUP_USER);
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
            this.Hide();

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.PENGATURAN_GRUP_AKSES);
            displayedForm.ShowDialog();

            this.Show();
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

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            this.Hide();

            sinkronisasiInformasiForm displayedForm = new sinkronisasiInformasiForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            this.Hide();

            IPPusatForm displayedForm = new IPPusatForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataCabangForm displayedForm = new dataCabangForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataPelangganForm displayedForm = new dataPelangganForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.TAMBAH_HAPUS_GROUP_PELANGGAN);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.PENGATURAN_POTONGAN_HARGA);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataSupplierForm displayedForm = new dataSupplierForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Hide();

            kategoriProdukForm displayedForm = new kategoriProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            this.Hide();

            exportStockOpnameForm displayedForm = new exportStockOpnameForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Hide();

            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_HARGA_JUAL);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            this.Hide();

            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_LIMIT_STOK);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            this.Hide();

            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_NOMOR_RAK);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataSatuanForm displayedForm = new dataSatuanForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            this.Hide();

            konversiSatuanForm displayedForm = new konversiSatuanForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm(globalConstants.PENYESUAIAN_STOK);
            displayedForm.ShowDialog();

            this.Show();
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            this.Hide();

            permintaanProdukForm displayedForm = new permintaanProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }
    }
}

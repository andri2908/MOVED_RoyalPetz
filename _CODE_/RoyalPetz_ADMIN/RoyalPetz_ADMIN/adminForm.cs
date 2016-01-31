﻿using System;
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
            

            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm();
            displayedForm.ShowDialog(this);

            
        }

        private void dataProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog(this);

            
        }

        private void dataPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            dataPelangganForm displayedForm = new dataPelangganForm();
            displayedForm.ShowDialog(this);

            
        }

        private void dataSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            dataSupplierForm displayedForm = new dataSupplierForm();
            displayedForm.ShowDialog(this);

            
        }

        private void dataSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            dataSalesForm displayedForm = new dataSalesForm();
            displayedForm.ShowDialog(this);

            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

            dataGroupForm displayedForm = new dataGroupForm();
            displayedForm.ShowDialog(this);

            
        }

        private void dataUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            dataUserForm displayedForm = new dataUserForm();
            displayedForm.ShowDialog(this);

            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stokTaggingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            

            dataProdukForm displayedForm = new dataProdukForm(globalConstants.STOK_PECAH_BARANG); // display dataProdukForm for browsing purpose only
            displayedForm.ShowDialog(this);

            
        }

        private void infoFolderDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            setDatabaseLocationForm displayedForm = new setDatabaseLocationForm(); 
            displayedForm.ShowDialog(this);

            
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            backupRestoreDatabaseForm displayedForm = new backupRestoreDatabaseForm();
            displayedForm.ShowDialog(this);

            
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            

            dataUserForm displayedForm = new dataUserForm();
            displayedForm.ShowDialog(this);

            
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.TAMBAH_HAPUS_GROUP_USER);
            displayedForm.ShowDialog(this);

            
        }

        private void pilihPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(cplPath, "/name Microsoft.DevicesAndPrinters");
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            

            dataGroupForm displayedForm = new dataGroupForm(globalConstants.PENGATURAN_GRUP_AKSES);
            displayedForm.ShowDialog(this);

            
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
            sinkronisasiInformasiForm displayedForm = new sinkronisasiInformasiForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            IPPusatForm displayedForm = new IPPusatForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            dataCabangForm displayedForm = new dataCabangForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            dataPelangganForm displayedForm = new dataPelangganForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            dataGroupForm displayedForm = new dataGroupForm(globalConstants.TAMBAH_HAPUS_GROUP_PELANGGAN);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            dataGroupForm displayedForm = new dataGroupForm(globalConstants.PENGATURAN_POTONGAN_HARGA);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            dataSupplierForm displayedForm = new dataSupplierForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            exportStockOpnameForm displayedForm = new exportStockOpnameForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_HARGA_JUAL);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_LIMIT_STOK);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            pengaturanProdukForm displayedForm = new pengaturanProdukForm(globalConstants.PENGATURAN_NOMOR_RAK);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            dataSatuanForm displayedForm = new dataSatuanForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            konversiSatuanForm displayedForm = new konversiSatuanForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            dataProdukForm displayedForm = new dataProdukForm(globalConstants.PENYESUAIAN_STOK);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PERMINTAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.CEK_DATA_MUTASI);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            importDataMutasiForm displayedForm = new importDataMutasiForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.REPRINT_PERMINTAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm(globalConstants.PENGATURAN_KATEGORI_PRODUK);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PENERIMAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            setNoFakturForm displayedForm = new setNoFakturForm();
            displayedForm.ShowDialog(this);
        }

        private void pengaturanPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(cplPath, "/name Microsoft.DevicesAndPrinters");
        }

        private void pengaturanGambarLatarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

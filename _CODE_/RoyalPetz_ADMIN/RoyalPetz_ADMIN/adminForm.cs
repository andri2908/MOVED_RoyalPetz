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
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable //color scheme for menustrip
        {
            public override Color MenuItemSelected
            {
                get { return Color.MediumAquamarine; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Aquamarine; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DarkBlue; }
            }
            /*public override Color MenuItemBorder
            {
                get { return Color.Green; }
            }*/
            public override Color MenuStripGradientBegin
            {
                get { return Color.Green; }
            }
            public override Color MenuStripGradientEnd
            {
                get { return Color.DarkGreen; }
            }
            /*public override Color ToolStripGradientBegin
            {
                get { return Color.Black; }
            }
            public override Color ToolStripGradientEnd //ToolStripDropDownBackground
            {
                get { return Color.Black; }
            }*/
            public override Color MenuBorder
            {
                get { return Color.Black; }
            }
        }
       
        private const string BG_IMAGE = "bg.jpg";
        private DateTime localDate = DateTime.Now;
        private CultureInfo culture = new CultureInfo("id-ID");

        private Data_Access DS = new Data_Access();

        private int selectedUserID = 0;
        private globalUtilities gutil = new globalUtilities();

        public adminForm(int userID)
        {
            InitializeComponent();

            selectedUserID = userID;
            loadBGimage();
        }

        private void updateLabel()
        {
            localDate = DateTime.Now;
            timeStampStatusLabel.Text = String.Format(culture, "{0:dddd, dd-MM-yyyy - HH:mm}", localDate);
        }

        private void loadBGimage()
        {

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BackgroundImageLayout = ImageLayout.Stretch;

            try
            {
                this.BackgroundImage = Image.FromFile(BG_IMAGE);
             }
            catch(Exception ex)
            {

            }
        }
        
        private void adminForm_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists("PRODUCT_PHOTO"))
            {
                System.IO.Directory.CreateDirectory("PRODUCT_PHOTO");
            }

            updateLabel();
            timer1.Start();

            welcomeLabel.Text = "WELCOME " + DS.getDataSingleValue("SELECT USER_FULL_NAME FROM MASTER_USER WHERE ID = " + selectedUserID).ToString();
            menuStrip1.Renderer = new MyRenderer();
            gutil.reArrangeTabOrder(this);

            //loadBGimage();
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabel();
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
            //dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PERMINTAAN_BARANG);
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.PERMINTAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            //dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.CEK_DATA_MUTASI);
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.CEK_DATA_MUTASI);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            importDataMutasiForm displayedForm = new importDataMutasiForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
//            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.REPRINT_PERMINTAAN_BARANG);
//            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm(globalConstants.PENGATURAN_KATEGORI_PRODUK);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            
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

                    System.IO.File.Copy(openFileDialog1.FileName, "bg.jpg");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.PerformClick();
            Application.Exit();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            //dataReturPenjualanStokAdjustmentForm displayedForm = new dataReturPenjualanStokAdjustmentForm();
            dataPelangganForm displayedForm = new dataPelangganForm(globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            dataReturPermintaanForm displayedForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER);
            displayedForm.ShowDialog(this);
        }

        private void accountJurnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataNomorAkun displayedForm = new dataNomorAkun();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            dataInvoiceForm displayedForm = new dataInvoiceForm(globalConstants.RETUR_PENJUALAN);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {
            dataInvoiceForm displayedForm = new dataInvoiceForm(globalConstants.PEMBAYARAN_PIUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            pengaturanLimitPajakForm displayedForm = new pengaturanLimitPajakForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            permintaanProdukForm displayedForm = new permintaanProdukForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            cashierForm displayedForm = new cashierForm(1);
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataInvoiceForm displayedForm = new dataInvoiceForm(globalConstants.PEMBAYARAN_PIUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            dataTransaksiJurnalHarianDetailForm displayedForm = new dataTransaksiJurnalHarianDetailForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dataTransaksiJurnalHarianDetailForm displayedForm = new dataTransaksiJurnalHarianDetailForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            dataReturPermintaanForm displayedForm = new dataReturPermintaanForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dataInvoiceForm displayedForm = new dataInvoiceForm();
            displayedForm.ShowDialog(this);
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm displayedForm = new loginForm();
            displayedForm.ShowDialog(this);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePasswordForm displayedForm = new changePasswordForm(selectedUserID);
            displayedForm.ShowDialog(this);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutForm displayedForm = new logoutForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            cashierForm displayedForm = new cashierForm(1);
            displayedForm.ShowDialog(this);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void adminForm_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void adminForm_Activated(object sender, EventArgs e)
        {
            updateLabel();
            timer1.Start();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayForm = new dataMutasiBarangForm(globalConstants.CEK_DATA_MUTASI);
            displayForm.ShowDialog(this); 
            //dataMutasiBarangDetailForm displayForm = new dataMutasiBarangDetailForm(globalConstants.MUTASI_BARANG);
            //displayForm.ShowDialog(this);
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PENERIMAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUsForm displayedform = new AboutUsForm();
            displayedform.ShowDialog();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm(globalConstants.PENERIMAAN_BARANG_DARI_PO);
            displayedForm.ShowDialog(this);
        }

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.Black;
        }

        private void pembelianToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            pembelianToolStripMenuItem.ForeColor = Color.FloralWhite;
        }

        private void pembelianToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            pembelianToolStripMenuItem.ForeColor = Color.Black;
        }

        private void penjualanToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            penjualanToolStripMenuItem.ForeColor = Color.FloralWhite;
        }

        private void penjualanToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            penjualanToolStripMenuItem.ForeColor = Color.Black;
        }

        private void administrasiToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            administrasiToolStripMenuItem.ForeColor = Color.FloralWhite;
        }

        private void administrasiToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            administrasiToolStripMenuItem.ForeColor = Color.Black;
        }

        private void toolStripMenuItem25_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItem25.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem25_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItem25.ForeColor = Color.Black;
        }

        private void toolStripMenuItem74_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItem74.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem74_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItem74.ForeColor = Color.Black;
        }

        private void informasiToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            informasiToolStripMenuItem.ForeColor = Color.FloralWhite;
        }

        private void informasiToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            informasiToolStripMenuItem.ForeColor = Color.Black;
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            dataReturPermintaanForm displayedForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_PUSAT);
            displayedForm.ShowDialog(this);

        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }
        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            dataCabangForm displayedForm = new dataCabangForm(globalConstants.DATA_PIUTANG_MUTASI);
            displayedForm.ShowDialog(this);
        }
    }
}

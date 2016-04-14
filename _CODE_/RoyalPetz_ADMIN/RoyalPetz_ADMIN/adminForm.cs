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
        private const string BG_IMAGE = "bg.jpg";
        private DateTime localDate = DateTime.Now;
        private CultureInfo culture = new CultureInfo("id-ID");
        string appPath = Application.StartupPath;

        private Data_Access DS = new Data_Access();

        private int selectedUserID = 0;
        private int selectedUserGroupID = 0;
        private globalUtilities gutil = new globalUtilities();

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
       
        public adminForm(int userID)
        {
            InitializeComponent();

            selectedUserID = userID;
            loadBGimage();

            selectedUserGroupID = getUserGroupID();

            gutil.setUserID(selectedUserID);
            gutil.setUserGroupID(selectedUserGroupID);

            activateUserAccessRight();
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

        private int getUserGroupID()
        {
            int result;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(GROUP_ID, 0) FROM MASTER_USER WHERE ID = " + selectedUserID));

            return result;
        }
        
        private void adminForm_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(appPath + "\\PRODUCT_PHOTO"))
            {
                System.IO.Directory.CreateDirectory(appPath + "\\PRODUCT_PHOTO");
            }

            updateLabel();
            timer1.Start();

            welcomeLabel.Text = "WELCOME " + DS.getDataSingleValue("SELECT IFNULL(USER_FULL_NAME, 0) FROM MASTER_USER WHERE ID = " + selectedUserID).ToString();
            menuStrip1.Renderer = new MyRenderer();
            gutil.reArrangeTabOrder(this);

            //load last known paper size settings from DB

            //activateUserAccessRight();
            
            //loadBGimage();
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            //write paper size settings last change to DB
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
        //    dataSalesForm displayedForm = new dataSalesForm();
        //    displayedForm.ShowDialog(this);
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
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        //private void toolStripMenuItem16_Click(object sender, EventArgs e)
        //{
        //    IPPusatForm displayedForm = new IPPusatForm();
        //    displayedForm.ShowDialog(this);
        //}

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

        //private void toolStripMenuItem12_Click(object sender, EventArgs e)
        //{
        //    dataGroupForm displayedForm = new dataGroupForm(globalConstants.PENGATURAN_POTONGAN_HARGA);
        //    displayedForm.ShowDialog(this);
        //}

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
        //    importDataMutasiForm displayedForm = new importDataMutasiForm();
        //    displayedForm.ShowDialog(this);
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
            //var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            //System.Diagnostics.Process.Start(cplPath, "/name Microsoft.DevicesAndPrinters");
            SetPrinterForm displayedForm = new SetPrinterForm();
            displayedForm.ShowDialog(this);
        }

        private void pengaturanGambarLatarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "(*.jpg)|*.jpg|(*.bmp)|*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;

                    this.BackgroundImage.Dispose();
                    
                    System.IO.File.Delete(appPath + "\\bg.jpg");
                    System.IO.File.Copy(openFileDialog1.FileName, appPath + "\\bg.jpg");

                    this.BackgroundImage = Image.FromFile(BG_IMAGE);
                    this.BackgroundImageLayout = ImageLayout.Stretch;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MENU_logOut.PerformClick();
            //Application.Exit();
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
            //permintaanProdukForm displayedForm = new permintaanProdukForm();
            dataPOForm displayedForm = new dataPOForm();
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
            //dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.PEMBAYARAN_HUTANG);
            dataPOForm displayedForm = new dataPOForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            //dataTransaksiJurnalHarianDetailForm displayedForm = new dataTransaksiJurnalHarianDetailForm();
            dataTransaksiJurnalHarianDetailForm displayedForm = new dataTransaksiJurnalHarianDetailForm(globalConstants.NEW_DJ,selectedUserID);
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dataTransaksiJurnalHarianDetailForm displayedForm = new dataTransaksiJurnalHarianDetailForm(globalConstants.NEW_DJ, selectedUserID);
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //dataReturPermintaanForm displayedForm = new dataReturPermintaanForm();
            dataReturPermintaanForm displayedForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER);
            displayedForm.ShowDialog(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //dataInvoiceForm displayedForm = new dataInvoiceForm();
            dataInvoiceForm displayedForm = new dataInvoiceForm(globalConstants.RETUR_PENJUALAN);
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
            //logoutForm displayedForm = new logoutForm();
            //displayedForm.ShowDialog(this);

            this.Close();
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

        //private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        //{
        //    dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PENERIMAAN_BARANG);
        //    displayedForm.ShowDialog(this);
        //}

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

        //private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        //{
        //    dataPOForm displayedForm = new dataPOForm(globalConstants.PENERIMAAN_BARANG_DARI_PO);
        //    displayedForm.ShowDialog(this);
        //}

        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_manajemenSistem.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            MAINMENU_manajemenSistem.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            MAINMENU_gudang.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_gudang.ForeColor = Color.Black;
        }

        private void pembelianToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            MAINMENU_pembelian.ForeColor = Color.FloralWhite;
        }

        private void pembelianToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_pembelian.ForeColor = Color.Black;
        }

        private void penjualanToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            MAINMENU_penjualan.ForeColor = Color.FloralWhite;
        }

        private void penjualanToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_penjualan.ForeColor = Color.Black;
        }

        private void administrasiToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            MAINMENU_KEUANGAN.ForeColor = Color.FloralWhite;
        }

        private void administrasiToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_KEUANGAN.ForeColor = Color.Black;
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
            
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            dataCabangForm displayedForm = new dataCabangForm(globalConstants.DATA_PIUTANG_MUTASI);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            importDataCSVForm displayedForm = new importDataCSVForm();
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem11_Click_2(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayedForm = new dataMutasiBarangForm(globalConstants.PENERIMAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem12_Click_2(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm(globalConstants.PENERIMAAN_BARANG_DARI_PO);
            displayedForm.ShowDialog(this);
        }

        private void setAccessibility(int moduleID, ToolStripMenuItem  menuItem)
        {
            int userAccessRight = 0;

            userAccessRight = DS.getUserAccessRight(moduleID, selectedUserGroupID);

            if (userAccessRight <= 0)
                menuItem.Visible = false;
        }

        private void setAccessibility(int moduleID, ToolStripButton menuItem)
        {
            int userAccessRight = 0;

            userAccessRight = DS.getUserAccessRight(moduleID, selectedUserGroupID);

            if (userAccessRight <= 0)
                menuItem.Visible = false;
        }

        
        private void activateUserAccessRight()
        {
            if (selectedUserGroupID == 0)
                return;

            // SET ACCESSIBILITY FOR MANAJEMEN SISTEM MAIN MENU
            setAccessibility(globalConstants.MENU_MANAJEMEN_SISTEM, MAINMENU_manajemenSistem);
            // SUB MENU DATABASE
            setAccessibility(globalConstants.MENU_DATABASE, MENU_backUpRestoreDatabaseToolStripMenuItem);
            setAccessibility(globalConstants.MENU_DATABASE, MENU_pengaturanSistemAplikasiToolStripMenuItem);
            // SUB MENU USER
            setAccessibility(globalConstants.MENU_MANAJEMEN_USER, MENU_manajemenUser);
            // SUB MENU CABANG
            setAccessibility(globalConstants.MENU_MANAJEMEN_CABANG, MENU_manajemenCabang);
            // THE OTHER SUB MENU
            setAccessibility(globalConstants.MENU_SINKRONISASI_INFORMASI, MENU_sinkronisasiInformasi);
            setAccessibility(globalConstants.MENU_PENGATURAN_PRINTER, MENU_pengaturanPrinter);
            setAccessibility(globalConstants.MENU_PENGATURAN_GAMBAR_LATAR, MENU_pengaturanGambarLatar);

            // SET ACCESSIBILITY FOR GUDANG MAIN MENU
            // SUB MENU PRODUK
            setAccessibility(globalConstants.MENU_GUDANG, MAINMENU_gudang);
            setAccessibility(globalConstants.MENU_GUDANG, SHORTCUT_produk); 
            setAccessibility(globalConstants.MENU_PRODUK, MENU_produk);
            setAccessibility(globalConstants.MENU_PRODUK, SHORTCUT_produk); 
            setAccessibility(globalConstants.MENU_TAMBAH_PRODUK, MENU_tambahProduk);
            setAccessibility(globalConstants.MENU_TAMBAH_PRODUK, SHORTCUT_produk); 
            setAccessibility(globalConstants.MENU_PENGATURAN_HARGA, MENU_pengaturanHarga);
            setAccessibility(globalConstants.MENU_PENGATURAN_LIMIT_STOK, MENU_pengaturanLimitStok);
            setAccessibility(globalConstants.MENU_PENGATURAN_KATEGORI_PRODUK, MENU_pengaturanKategoriProduk);
            setAccessibility(globalConstants.MENU_PECAH_SATUAN_PRODUK, MENU_pecahSatuanProduk);
            setAccessibility(globalConstants.MENU_PENGATURAN_NOMOR_RAK, MENU_pengaturanNomorRak);
            // SUB MENU KATEGORI
            setAccessibility(globalConstants.MENU_KATEGORI, MENU_kategori);
            // SUB MENU SATUAN
            setAccessibility(globalConstants.MENU_SATUAN, MENU_satuan);
            setAccessibility(globalConstants.MENU_TAMBAH_SATUAN, MENU_tambahSatuan);
            setAccessibility(globalConstants.MENU_PENGATURAN_KONVERSI, MENU_pengaturanKonversiSatuan);
            // SUB MENU STOK OPNAME            
            setAccessibility(globalConstants.MENU_STOK_OPNAME, MENU_exportDataCSV);
            setAccessibility(globalConstants.MENU_STOK_OPNAME, MENU_importDataCSV);
            setAccessibility(globalConstants.MENU_PENYESUAIAN_STOK, MENU_penyesuaianStok);
            // SUB MENU MUTASI
            setAccessibility(globalConstants.MENU_MUTASI_BARANG, MENU_mutasiBarang);
            setAccessibility(globalConstants.MENU_TAMBAH_MUTASI_BARANG, MENU_tambahMutasiBarang);
            setAccessibility(globalConstants.MENU_CEK_PERMINTAAN_BARANG, MENU_cekPermintaanBarang);
            // SUB MENU PENERIMAAN BARANG
            setAccessibility(globalConstants.MENU_PENERIMAAN_BARANG, MENU_penerimaanBarang);
           // setAccessibility(globalConstants.MENU_PENERIMAAN_BARANG_DARI_MUTASI, MENU_dariMutasiBarang);
           // setAccessibility(globalConstants.MENU_PENERIMAAN_BARANG_DARI_PO, MENU_dariPO);

            // SET ACCESSIBILITY FOR PEMBELIAN MAIN MENU
            setAccessibility(globalConstants.MENU_PEMBELIAN, MAINMENU_pembelian);
            setAccessibility(globalConstants.MENU_PEMBELIAN, SHORTCUT_beli);
            setAccessibility(globalConstants.MENU_PEMBELIAN, SHORTCUT_returBeli);
            // SUB MENU SUPPLIER
            setAccessibility(globalConstants.MENU_SUPPLIER, MENU_supplier);
            // SUB MENU PERMINTAAN PRODUK
            setAccessibility(globalConstants.MENU_REQUEST_ORDER, MENU_requestOrder);
            setAccessibility(globalConstants.MENU_PURCHASE_ORDER, MENU_purchaseOrder);
            setAccessibility(globalConstants.MENU_PURCHASE_ORDER, SHORTCUT_beli);
            setAccessibility(globalConstants.MENU_REPRINT_REQUEST_ORDER, MENU_reprintRequestOrder);
            // SUB MENU RETUR PRODUK
            setAccessibility(globalConstants.MENU_RETUR_PEMBELIAN, MENU_returPembelianKeSupplier);
            setAccessibility(globalConstants.MENU_RETUR_PEMBELIAN, SHORTCUT_returBeli);
            setAccessibility(globalConstants.MENU_RETUR_PERMINTAAN, MENU_returPermintaanKePusat);

            // SET ACCESSIBILITY FOR PENJUALAN MAIN MENU
            setAccessibility(globalConstants.MENU_PENJUALAN, MAINMENU_penjualan);
            setAccessibility(globalConstants.MENU_PENJUALAN, SHORTCUT_jual);
            setAccessibility(globalConstants.MENU_PENJUALAN, SHORTCUT_returJual);
            // SUB MENU PELANGGAN
            setAccessibility(globalConstants.MENU_PELANGGAN, MENU_pelanggan);
            // SUB MENU TRANSAKSI PENJUALAN
            setAccessibility(globalConstants.MENU_TRANSAKSI_PENJUALAN, MENU_transaksiPenjualan);
            setAccessibility(globalConstants.MENU_TRANSAKSI_PENJUALAN, SHORTCUT_jual);
            setAccessibility(globalConstants.MENU_SET_NO_FAKTUR, MENU_setNoFaktur);
            // SUB MENU RETUR PENJUALAN
            setAccessibility(globalConstants.MENU_RETUR_PENJUALAN, MENU_returPenjualan);
            setAccessibility(globalConstants.MENU_RETUR_PENJUALAN_INVOICE, MENU_returByInvoice);
            setAccessibility(globalConstants.MENU_RETUR_PENJUALAN_INVOICE, SHORTCUT_returJual);
            setAccessibility(globalConstants.MENU_RETUR_PENJUALAN_STOK, MENU_returByStokAdjustment);

            // SET ACCESSIBILITY FOR KEUANGAN MAIN MENU
            setAccessibility(globalConstants.MENU_KEUANGAN, MAINMENU_KEUANGAN);
            setAccessibility(globalConstants.MENU_KEUANGAN, SHORTCUT_jurnal);
            setAccessibility(globalConstants.MENU_KEUANGAN, SHORTCUT_piutang);
            setAccessibility(globalConstants.MENU_KEUANGAN, SHORTCUT_hutang);
            // SUB MENU NOMOR AKUN
            setAccessibility(globalConstants.MENU_PENGATURAN_NO_AKUN, MENU_pengaturanNomorAkun);
            // SUB MENU TRANSAKSI
            setAccessibility(globalConstants.MENU_TRANSAKSI, MENU_transaksi);
            setAccessibility(globalConstants.MENU_TRANSAKSI_HARIAN, MENU_tambahTransaksiHarian);
            setAccessibility(globalConstants.MENU_TRANSAKSI_HARIAN, SHORTCUT_jurnal);
            setAccessibility(globalConstants.MENU_TRANSAKSI_HARIAN, MENU_pengaturanLimitPajak);
            setAccessibility(globalConstants.MENU_PEMBAYARAN_PIUTANG, MENU_pembayaranPiutang);
            setAccessibility(globalConstants.MENU_PEMBAYARAN_PIUTANG, SHORTCUT_piutang);
            setAccessibility(globalConstants.MENU_PEMBAYARAN_PIUTANG_MUTASI, MENU_pembayaranPiutangMutasi);
            setAccessibility(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, MENU_pembayaranHutangKeSupplier);
            setAccessibility(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, SHORTCUT_hutang);
        }


        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataSupplierForm displayedForm = new dataSupplierForm(globalConstants.PEMBAYARAN_HUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            dataInvoiceForm displayedForm = new dataInvoiceForm(globalConstants.PEMBAYARAN_PIUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            dataPelangganForm displayedForm = new dataPelangganForm(globalConstants.PEMBAYARAN_PIUTANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {

        }
        private void generatorXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLGeneratorForm displayedform = new XMLGeneratorForm();
            displayedform.ShowDialog(this);
        }

        private void masterUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportUserForm displayedform = new ReportUserForm();
            displayedform.ShowDialog(this);
        }

        private void masterProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportProductForm displayedform = new ReportProductForm();
            displayedform.ShowDialog(this);
        }

        private void masterCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportBranchForm displayedform = new ReportBranchForm();
            displayedform.ShowDialog(this);
        }

        private void masterAkunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAccountForm displayedform = new ReportAccountForm();
            displayedform.ShowDialog(this);

        }

        private void masterKategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCategoryForm displayedform = new ReportCategoryForm();
            displayedform.ShowDialog(this);
        }

        private void masterPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCustomerForm displayedform = new ReportCustomerForm();
            displayedform.ShowDialog(this);
        }

        private void masterGroupUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportGroupUserForm displayedform = new ReportGroupUserForm();
            displayedform.ShowDialog(this);
        }

        private void masterSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSupplierForm displayedform = new ReportSupplierForm();
            displayedform.ShowDialog(this);
        }

        private void masterSatuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportUnitForm displayedform = new ReportUnitForm();
            displayedform.ShowDialog(this);
        }

        private void laporanDaftarProdukDalamKategoriTertentuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportProductCategoryForm displayedform = new ReportProductCategoryForm();
            displayedform.ShowDialog(this);

        }

        private void pengaturanSistemAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetApplicationForm displayedForm = new SetApplicationForm();
            displayedForm.ShowDialog(this);
        }

        private void backUpRestoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backupRestoreDatabaseForm displayedForm = new backupRestoreDatabaseForm();
            displayedForm.ShowDialog(this);
        }

        private void MENU_penerimaanBarang_Click(object sender, EventArgs e)
        {
            penerimaanBarangForm displayedForm = new penerimaanBarangForm();
            displayedForm.ShowDialog(this);
        }
    }
}

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

using Hotkeys;
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
        private bool newMessageFormExist = false;
        private Hotkeys.GlobalHotkey ghk_F1;
        private Hotkeys.GlobalHotkey ghk_F2;
        private Hotkeys.GlobalHotkey ghk_F3;
        private Hotkeys.GlobalHotkey ghk_F4;
        private Hotkeys.GlobalHotkey ghk_F5;
        private Hotkeys.GlobalHotkey ghk_F6;
        private Hotkeys.GlobalHotkey ghk_F7;
        private Hotkeys.GlobalHotkey ghk_F8;
        private Hotkeys.GlobalHotkey ghk_F9;

        private Hotkeys.GlobalHotkey ghk_Ctrl_Enter;

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

        private void captureAll(Keys key)
        {
            int userAccessOptions = 0;
            switch (key)
            {
                case Keys.F1:
                    if (0 != 
                            (
                            DS.getUserAccessRight(globalConstants.MENU_PRODUK, gutil.getUserGroupID()) * 
                            DS.getUserAccessRight(globalConstants.MENU_PURCHASE_ORDER, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_PENJUALAN, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_PEMBAYARAN_PIUTANG, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_TRANSAKSI_HARIAN, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_RETUR_PEMBELIAN, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_RETUR_PENJUALAN, gutil.getUserGroupID()) *
                            DS.getUserAccessRight(globalConstants.MENU_MODULE_MESSAGING, gutil.getUserGroupID())
                            )
                        )
                    { 
                        adminHelpForm displayHelp = new adminHelpForm();
                        displayHelp.ShowDialog(this);
                    }
                    break;
                case Keys.F2:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_PRODUK, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataProdukForm displayedProdukForm = new dataProdukForm();
                        displayedProdukForm.ShowDialog(this);
                    }
                    break;
                case Keys.F3:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_PURCHASE_ORDER, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataPOForm displayedPOForm = new dataPOForm();
                        displayedPOForm.ShowDialog(this);
                    }
                    break;
                case Keys.F4:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_PENJUALAN, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        cashierForm displayedCashierForm = new cashierForm(1);
                        displayedCashierForm.ShowDialog(this);
                    }
                    break;
                case Keys.F5:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_PEMBAYARAN_PIUTANG, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataInvoiceForm displayedInvoiceForm = new dataInvoiceForm(globalConstants.PEMBAYARAN_PIUTANG);
                        displayedInvoiceForm.ShowDialog(this);
                    }
                    break;
                case Keys.F6:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataPOForm displayedPOSupplierForm = new dataPOForm(globalConstants.PEMBAYARAN_HUTANG);
                        displayedPOSupplierForm.ShowDialog(this);
                    }
                    break;
                case Keys.F7:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_TRANSAKSI_HARIAN, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataTransaksiJurnalHarianDetailForm displayedDJForm = new dataTransaksiJurnalHarianDetailForm(globalConstants.NEW_DJ, selectedUserID);
                        displayedDJForm.ShowDialog(this);
                    }
                    break;
                case Keys.F8:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_RETUR_PEMBELIAN, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataReturPermintaanForm displayedRetBeliForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER);
                        displayedRetBeliForm.ShowDialog(this);
                    }
                    break;
                case Keys.F9:
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_RETUR_PENJUALAN, gutil.getUserGroupID());
                    if (userAccessOptions > 0)
                    {
                        dataInvoiceForm displayedRetJualForm = new dataInvoiceForm(globalConstants.RETUR_PENJUALAN);
                        displayedRetJualForm.ShowDialog(this);
                    }
                    break;
            }
        }

        private void captureCtrlModifier(Keys key)
        {
            int userAccessOptions = 0;
            switch (key)
            {
                case Keys.Enter: // CTRL + ENTER
                    userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_MODULE_MESSAGING, gutil.getUserGroupID());
                    if (!newMessageFormExist && userAccessOptions == 1)
                    {
                        if (DialogResult.Yes == MessageBox.Show("DISPLAY MESSAGE ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            messagingForm displayForm = new messagingForm();
                            displayForm.ShowDialog(this);
                       }
                    }
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
                //else if (modifier == Constants.ALT)
                //    captureAltModifier(key);
                else if (modifier == Constants.CTRL)
                    captureCtrlModifier(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_F1 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F1, this);
            ghk_F1.Register();
            ghk_F2 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F2, this);
            ghk_F2.Register();
            ghk_F3 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F3, this);
            ghk_F3.Register();
            ghk_F4 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F4, this);
            ghk_F4.Register();
            ghk_F5 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F5, this);
            ghk_F5.Register();
            ghk_F6 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F6, this);
            ghk_F6.Register();
            ghk_F7 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F7, this);
            ghk_F7.Register();
            ghk_F8 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F8, this);
            ghk_F8.Register();
            ghk_F9 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F9, this);
            ghk_F9.Register();

            ghk_Ctrl_Enter = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Enter, this);
            ghk_Ctrl_Enter.Register();
        }

        private void unregisterGlobalHotkey()
        {
            ghk_F1.Unregister();
            ghk_F2.Unregister();
            ghk_F3.Unregister();
            ghk_F4.Unregister();
            ghk_F5.Unregister();
            ghk_F6.Unregister();
            ghk_F7.Unregister();
            ghk_F8.Unregister();
            ghk_F9.Unregister();

            ghk_Ctrl_Enter.Unregister();
        }

        public adminForm(int userID, int groupID)
        {
            InitializeComponent();

            selectedUserID = userID;
            selectedUserGroupID = groupID;
            loadBGimage();

            
            activateUserAccessRight();
        }

        public void setNewMessageFormExist(bool value)
        {
            newMessageFormExist = value;
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
            gutil.saveSystemDebugLog(0, "adminForm Load");

            if (!System.IO.Directory.Exists(appPath + "\\PRODUCT_PHOTO"))
            {
                System.IO.Directory.CreateDirectory(appPath + "\\PRODUCT_PHOTO");
                gutil.saveSystemDebugLog(0, "CREATE PRODUCT_PHOTO FOLDER");
            }

            //updateLabel();
            //timer1.Start();

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
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.PERMINTAAN_BARANG);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            dataPermintaanForm displayedForm = new dataPermintaanForm(globalConstants.CEK_DATA_MUTASI);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            dataPOForm displayedForm = new dataPOForm(globalConstants.REPRINT_PURCHASE_ORDER);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            dataKategoriProdukForm displayedForm = new dataKategoriProdukForm(globalConstants.PENGATURAN_KATEGORI_PRODUK);
            displayedForm.ShowDialog(this);
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
                    gutil.saveSystemDebugLog(0, "SELECTED PICTURE [" + fileName + "]");

                    if (openFileDialog1.FileName != appPath + "\\bg.jpg")
                    { 
                        if (null!= this.BackgroundImage)
                        {
                            gutil.saveSystemDebugLog(0, "REMOVE CURRENT BACKGROUND IMAGE");
                            this.BackgroundImage.Dispose();
                        }

                        gutil.saveSystemDebugLog(0, "REMOVE CURRENT BACKGROUND IMAGE FILE");
                        System.IO.File.Delete(appPath + "\\bg.jpg");

                        gutil.saveSystemDebugLog(0, "CREATE A COPY OF NEW BACKGROUND IMAGE");
                        System.IO.File.Copy(openFileDialog1.FileName, appPath + "\\bg.jpg");

                        gutil.saveSystemDebugLog(0, "CHANGE BACKGROUND IMAGE");
                        this.BackgroundImage = Image.FromFile(BG_IMAGE);
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                catch (Exception ex)
                {
                    gutil.saveSystemDebugLog(0, "CAN'T READ FILE");
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
            //dataReturPermintaanForm displayedForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_PUSAT);
            //displayedForm.ShowDialog(this);
            dataReturForm displayedForm = new dataReturForm(globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER);
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
            //timer1.Stop();
            unregisterGlobalHotkey();
        }

        private void adminForm_Activated(object sender, EventArgs e)
        {
            updateLabel();
            timer1.Start();

            registerGlobalHotkey();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dataMutasiBarangForm displayForm = new dataMutasiBarangForm(globalConstants.CEK_DATA_MUTASI);
            displayForm.ShowDialog(this); 
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
            MAINMENU_TaxModule.ForeColor = Color.FloralWhite;
        }

        private void toolStripMenuItem74_DropDownOpened(object sender, EventArgs e)
        {
            MAINMENU_TaxModule.ForeColor = Color.Black;
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
            //dataReturPermintaanForm displayedForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_PUSAT);
            //displayedForm.ShowDialog(this);
            dataReturForm displayedForm = new dataReturForm(globalConstants.RETUR_PEMBELIAN_KE_PUSAT);
            displayedForm.ShowDialog(this);
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

            gutil.saveSystemDebugLog(0, "ACTIVATE USER ACCESS RIGHT");

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
            // SUB MENU PENGATURAN LIMIT PAJAK
            setAccessibility(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, MENU_pengaturanLimitPajak);
            setAccessibility(globalConstants.MENU_TAX_MODULE, MAINMENU_TaxModule);
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
            dataPenerimaanBarangForm displayedForm = new dataPenerimaanBarangForm();
            displayedForm.ShowDialog(this);
        }

        private void timerMessage_Tick(object sender, EventArgs e)
        {
            int userAccessOptions;

            userAccessOptions = DS.getUserAccessRight(globalConstants.MENU_MODULE_MESSAGING, gutil.getUserGroupID());
            if (userAccessOptions == 1 && !newMessageFormExist && gutil.checkNewMessageData())
            {
                newMessageFormExist = true;
                newMessageForm newMsgForm = new newMessageForm((Form) this);
                newMsgForm.Top = Screen.PrimaryScreen.Bounds.Height - newMsgForm.Height;
                newMsgForm.Left = Screen.PrimaryScreen.Bounds.Width- newMsgForm.Width;

                newMsgForm.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();

            }
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_SUMMARY);
            displayedForm.ShowDialog(this);
        }

        private void detailedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_DETAILED);
            displayedForm.ShowDialog(this);
        }

        private void perProdukBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_PRODUCT);
            displayedForm.ShowDialog(this);
        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportTopSalesFormSearchForm displayedForm = new ReportTopSalesFormSearchForm(globalConstants.REPORT_TOPSALES_GLOBAL);
            displayedForm.ShowDialog(this);
        }

        private void perJenisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportTopSalesFormSearchForm displayedForm = new ReportTopSalesFormSearchForm(globalConstants.REPORT_TOPSALES_byTAGS);
            displayedForm.ShowDialog(this);
        }

        private void penjualanPertanggalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportTopSalesFormSearchForm displayedForm = new ReportTopSalesFormSearchForm(globalConstants.REPORT_TOPSALES_byDATE);
            displayedForm.ShowDialog(this);
        }

        private void penjualanLabaPertanggalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportTopSalesFormSearchForm displayedForm = new ReportTopSalesFormSearchForm(globalConstants.REPORT_TOPSALES_ByMARGIN);
            displayedForm.ShowDialog(this);
        }

        private void detailedToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReportPurchaseSearchForm displayedForm = new ReportPurchaseSearchForm(globalConstants.REPORT_PURCHASE_DETAILED);
            displayedForm.ShowDialog(this);
        }

        private void summaryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReportPurchaseSearchForm displayedForm = new ReportPurchaseSearchForm(globalConstants.REPORT_PURCHASE_SUMMARY);
            displayedForm.ShowDialog(this);
        }

        private void perProdukBarangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportPurchaseSearchForm displayedForm = new ReportPurchaseSearchForm(globalConstants.REPORT_PURCHASE_ByPRODUCT);
            displayedForm.ShowDialog(this);
        }

        private void omzetPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_OMZET);
            displayedForm.ShowDialog(this);
        }

        private void penjualanKasirPerShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCashierLogSearchForm displayedForm = new ReportCashierLogSearchForm();
            displayedForm.ShowDialog(this);
        }

        private void hutangLewatJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT D.PURCHASE_INVOICE AS 'INVOICE', D.DEBT_NOMINAL AS 'TOTAL', DATE(D.DEBT_DUE_DATE) AS 'JATUHTEMPO', " +
                            "ABS(DATEDIFF(NOW(), D.DEBT_DUE_DATE)) AS 'TERLAMBAT' " +
                            "FROM DEBT D " +
                            "WHERE D.DEBT_PAID = 0 AND DATEDIFF(NOW(), D.DEBT_DUE_DATE)> 0";
            DS.writeXML(sqlCommandx, globalConstants.DebtUnpaidXML);
            ReportDebtUnpaidForm displayedForm = new ReportDebtUnpaidForm();
            displayedForm.ShowDialog(this);
        }

        private void analisaUmurHutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT D.PURCHASE_INVOICE AS 'INVOICE', D.DEBT_NOMINAL AS 'TOTAL', D.DEBT_DUE_DATE AS 'JATUHTEMPO', " +
                            "DATEDIFF(NOW(), D.DEBT_DUE_DATE) AS 'WAKTU' " +
                            "FROM DEBT D WHERE " +
                            "D.DEBT_PAID = 0 AND DATEDIFF(NOW(), D.DEBT_DUE_DATE)< 0";
            DS.writeXML(sqlCommandx, globalConstants.DebtDueXML);
            ReportDebtDueForm displayedForm = new ReportDebtDueForm();
            displayedForm.ShowDialog(this);
        }

        private void analisaUmurPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT C.SALES_INVOICE AS 'INVOICE', C.CREDIT_NOMINAL AS 'TOTAL', C.CREDIT_DUE_DATE AS 'JATUHTEMPO', " +
                            "DATEDIFF(NOW(), C.CREDIT_DUE_DATE) AS 'WAKTU' FROM CREDIT C " +
                            "WHERE C.SALES_INVOICE IS NOT NULL AND C.CREDIT_PAID = 0 AND DATEDIFF(NOW(), C.CREDIT_DUE_DATE)< 0";
            DS.writeXML(sqlCommandx, globalConstants.CreditDueXML);
            ReportCreditDueForm displayedForm = new ReportCreditDueForm();
            displayedForm.ShowDialog(this);
        }

        private void piutangLewatJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT C.SALES_INVOICE AS 'INVOICE', C.CREDIT_NOMINAL AS 'TOTAL', C.CREDIT_DUE_DATE AS 'JATUHTEMPO', " +
                            "ABS(DATEDIFF(NOW(), C.CREDIT_DUE_DATE)) AS 'TERLAMBAT' " +
                            "FROM CREDIT C " +
                            "WHERE C.SALES_INVOICE IS NOT NULL AND C.CREDIT_PAID = 0 AND DATEDIFF(NOW(), C.CREDIT_DUE_DATE)> 0";
            DS.writeXML(sqlCommandx, globalConstants.CreditUnpaidXML);
            ReportCreditUnpaidForm displayedForm = new ReportCreditUnpaidForm();
            displayedForm.ShowDialog(this);
        }

        private void stokDibawahLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT P.PRODUCT_ID AS 'ID', P.PRODUCT_NAME AS 'NAMA PRODUK', P.PRODUCT_DESCRIPTION AS 'DESKRIPSI', P.PRODUCT_BRAND AS 'MERK', " +
                            "P.PRODUCT_SHELVES AS 'NOMOR RAK', P.PRODUCT_STOCK_QTY AS 'STOK', P.PRODUCT_LIMIT_STOCK AS 'LIMIT STOK', U.UNIT_NAME AS 'SATUAN' " +
                            "FROM MASTER_PRODUCT P, MASTER_UNIT U " +
                            "WHERE P.UNIT_ID = U.UNIT_ID AND P.PRODUCT_IS_SERVICE = 0 AND P.PRODUCT_ACTIVE = 1 AND P.PRODUCT_STOCK_QTY <= P.PRODUCT_LIMIT_STOCK";
            DS.writeXML(sqlCommandx, globalConstants.ProductStockLimitXML);
            ReportProductStockLimitForm displayedForm = new ReportProductStockLimitForm();
            displayedForm.ShowDialog(this);
        }

        private void deviasiAdjustmentStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStockInOutSearchForm displayedForm = new ReportStockInOutSearchForm(globalConstants.REPORT_STOCK_DEVIATION);
            displayedForm.ShowDialog(this);
        }

        private void pembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportStockInOutSearchForm displayedForm = new ReportStockInOutSearchForm(globalConstants.REPORT_PURCHASE_RETURN);
            displayedForm.ShowDialog(this);
        }

        private void penjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportStockInOutSearchForm displayedForm = new ReportStockInOutSearchForm(globalConstants.REPORT_SALES_RETURN);
            displayedForm.ShowDialog(this);
        }

        private void permintaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStockInOutSearchForm displayedForm = new ReportStockInOutSearchForm(globalConstants.REPORT_REQUEST_RETURN);
            displayedForm.ShowDialog(this);
        }

        private void mutasiBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStockInOutSearchForm displayedForm = new ReportStockInOutSearchForm(globalConstants.REPORT_PRODUCT_MUTATION);
            displayedForm.ShowDialog(this);
        }

        private void pembayaranHutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPaymentSearchForm displayedForm = new ReportPaymentSearchForm(globalConstants.REPORT_DEBT_PAYMENT);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            cashierForm displayedForm = new cashierForm(globalConstants.DUMMY_TRANSACTION_TAX, true);
            displayedForm.ShowDialog(this);
        }

        private void pembayaranPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPaymentSearchForm displayedForm = new ReportPaymentSearchForm(globalConstants.REPORT_CREDIT_PAYMENT);
            displayedForm.ShowDialog(this);
        }

        private void pembayaranMutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportPaymentSearchForm displayedForm = new ReportPaymentSearchForm(globalConstants.REPORT_MUTATION_PAYMENT);
            displayedForm.ShowDialog(this);
        }

        private void pengeluaranKasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportFinanceSearchForm displayedForm = new ReportFinanceSearchForm(globalConstants.REPORT_FINANCE_OUT);
            displayedForm.ShowDialog(this);
        }

        private void pemasukanKasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportFinanceSearchForm displayedForm = new ReportFinanceSearchForm(globalConstants.REPORT_FINANCE_OUT);
            displayedForm.ShowDialog(this);
        }

        private void labaRugiHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportFinanceSearchForm displayedForm = new ReportFinanceSearchForm(globalConstants.REPORT_MARGIN);
            displayedForm.ShowDialog(this);
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_DETAILED, true);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_SUMMARY, true);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ReportSalesSummarySearchForm displayedForm = new ReportSalesSummarySearchForm(globalConstants.REPORT_SALES_PRODUCT, true);
            displayedForm.ShowDialog(this);
        }

        private void toolStripMenuItem9_Click_1(object sender, EventArgs e)
        {
            dataReturForm displayedForm = new dataReturForm(globalConstants.RETUR_PENJUALAN);
            displayedForm.ShowDialog(this);
        }
    }
}

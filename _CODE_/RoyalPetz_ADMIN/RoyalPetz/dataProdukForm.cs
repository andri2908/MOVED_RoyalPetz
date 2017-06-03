using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using Hotkeys;
using System.Drawing.Printing;
using System.Reflection;

namespace AlphaSoft
{
    public partial class dataProdukForm : Form
    {
        private int originModuleID = 0;
        private int selectedProductID = 0;
        private string selectedkodeProduct = "";
        private string selectedProductName = "";
        private int selectedRowIndex = -1;

        private stokPecahBarangForm parentForm;
        private cashierForm parentCashierForm;
        private penerimaanBarangForm parentPenerimaanBarangForm;
        private purchaseOrderDetailForm parentPOForm;
        private dataMutasiBarangDetailForm parentMutasiForm;
        private permintaanProdukForm parentRequestForm;
        private dataReturPenjualanForm parentReturJualForm;
        private string returJualSearchParam = "";
        private dataReturPermintaanForm parentReturBeliForm;

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        dataProdukDetailForm newProductForm = null;
        dataProdukDetailForm editProductForm = null;
        stokPecahBarangForm displayStokPecahBarangForm = null;
        penyesuaianStokForm displayPenyesuaianStokForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        public dataProdukForm()
        {
            InitializeComponent();
        }

        public dataProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, stokPecahBarangForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, cashierForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentCashierForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, penerimaanBarangForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPenerimaanBarangForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, purchaseOrderDetailForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPOForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, dataMutasiBarangDetailForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentMutasiForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, permintaanProdukForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentRequestForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, dataReturPenjualanForm thisParentForm, string searchParam = "")
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturJualForm = thisParentForm;
            returJualSearchParam = searchParam;
            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, dataReturPermintaanForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturBeliForm = thisParentForm;
            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, cashierForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentCashierForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, dataMutasiBarangDetailForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentMutasiForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, dataReturPenjualanForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1, string searchParam = "")
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturJualForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
            returJualSearchParam = searchParam;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, dataReturPermintaanForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentReturBeliForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, penerimaanBarangForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPenerimaanBarangForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, purchaseOrderDetailForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentPOForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        public dataProdukForm(int moduleID, permintaanProdukForm thisParentForm, string productID = "", string productName = "", int rowIndex = -1)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentRequestForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;

            namaProdukTextBox.Text = productName;
            kodeProductTextBox.Text = productID;
            selectedRowIndex = rowIndex;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
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
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();

            navKeyRegistered = false;
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                case globalConstants.STOK_PECAH_BARANG:
                    if (null == displayStokPecahBarangForm || displayStokPecahBarangForm.IsDisposed)
                        displayStokPecahBarangForm = new stokPecahBarangForm(selectedProductID);

                    displayStokPecahBarangForm.Show();
                    displayStokPecahBarangForm.WindowState = FormWindowState.Normal;
                    break;

                case globalConstants.PENYESUAIAN_STOK:
                    if (null == displayPenyesuaianStokForm || displayPenyesuaianStokForm.IsDisposed)
                        displayPenyesuaianStokForm = new penyesuaianStokForm(selectedProductID);

                    displayPenyesuaianStokForm.Show();
                    displayPenyesuaianStokForm.WindowState = FormWindowState.Normal;
                    break;

                case globalConstants.BROWSE_STOK_PECAH_BARANG:
                    parentForm.setNewSelectedProductID(selectedProductID);
                    this.Close();
                    break;

                case globalConstants.CASHIER_MODULE:
                    parentCashierForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    this.Close();
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                    parentPenerimaanBarangForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    this.Close();
                    break;

                case globalConstants.NEW_PURCHASE_ORDER:
                    parentPOForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    this.Close();
                    break;

                case globalConstants.MUTASI_BARANG:
                    if (globalFeatureList.EXPIRY_MODULE == 1)
                    {
                        parentMutasiForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex, selectedProductID);
                    }
                    else
                    { 
                        parentMutasiForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    }
                    this.Close();
                    break;

                case globalConstants.NEW_REQUEST_ORDER:
                    parentRequestForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    this.Close();
                    break;

                case globalConstants.RETUR_PENJUALAN:
                case globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT:
                    parentReturJualForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex);
                    this.Close();
                    break;

                case globalConstants.RETUR_PEMBELIAN_KE_PUSAT:
                case globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER:
                    parentReturBeliForm.addNewRowFromBarcode(selectedkodeProduct, selectedProductName, selectedRowIndex, selectedProductID);
                    this.Close();
                    break;

                default: // MASTER DATA PRODUK
                    if (null == editProductForm || editProductForm.IsDisposed)
                        editProductForm = new dataProdukDetailForm(globalConstants.EDIT_PRODUK, selectedProductID);

                    editProductForm.Show();
                    editProductForm.WindowState = FormWindowState.Normal;
                    break;
            }   
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (null == newProductForm || newProductForm.IsDisposed)
                newProductForm = new dataProdukDetailForm(globalConstants.NEW_PRODUK);

            newProductForm.Show();
            newProductForm.WindowState = FormWindowState.Normal;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (!namaProdukTextBox.Text.Equals(""))
            {
                loadProdukData();
            }
        }

        private void loadProdukData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string sqlCommand2 = "";

            string namaProductParam = "";
            string kodeProductParam = "";
            string showactive = "";
            bool displayExpiredDate = false;
            DS.mySqlConnect();

            //if (namaProdukTextBox.Text.Equals(""))
            //    return;
            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);
            kodeProductParam = MySqlHelper.EscapeString(kodeProductTextBox.Text);

            if (produknonactiveoption.Checked == false)
            {
                showactive = "AND MP.PRODUCT_ACTIVE = 1 ";
            }

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY', MP.PRODUCT_DESCRIPTION AS 'DESKRIPSI PRODUK' " +
                                    "FROM MASTER_PRODUCT MP, SALES_DETAIL SD " +
                                    "WHERE SD.SALES_INVOICE = '" + returJualSearchParam + "' AND SD.PRODUCT_ID = MP.PRODUCT_ID AND MP.PRODUCT_IS_SERVICE = 0 " + showactive +
                                    "AND MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" +
                                    " GROUP BY MP.PRODUCT_ID";
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY', MP.PRODUCT_DESCRIPTION AS 'DESKRIPSI PRODUK' " +
                                    "FROM MASTER_PRODUCT MP, SALES_DETAIL SD, SALES_HEADER SH " +
                                    "WHERE SH.SALES_INVOICE = SD.SALES_INVOICE AND SD.PRODUCT_ID = MP.PRODUCT_ID AND SH.CUSTOMER_ID = " + Convert.ToInt32(returJualSearchParam) + " AND MP.PRODUCT_IS_SERVICE = 0 " + showactive +
                                    "AND MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" +
                                    " GROUP BY MP.PRODUCT_ID";
            }
            else if (originModuleID == globalConstants.RETUR_PEMBELIAN)
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY' FROM MASTER_PRODUCT MP WHERE MP.PRODUCT_IS_SERVICE = 0 " + showactive + " ORDER BY MP.PRODUCT_NAME ASC";//"AND (MP.PRODUCT_STOCK_QTY - MP.PRODUCT_LIMIT_STOCK > 0) ORDER BY MP.PRODUCT_NAME ASC";
            }
            else if (originModuleID == globalConstants.PENERIMAAN_BARANG || originModuleID == globalConstants.BROWSE_STOK_PECAH_BARANG)
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY', MP.PRODUCT_DESCRIPTION AS 'DESKRIPSI PRODUK' FROM MASTER_PRODUCT MP WHERE MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" + showactive;
            }
            else if ((originModuleID == globalConstants.CASHIER_MODULE) || (originModuleID == globalConstants.NEW_PURCHASE_ORDER) || (originModuleID == globalConstants.NEW_REQUEST_ORDER))
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY' FROM MASTER_PRODUCT MP WHERE MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" + showactive; //MP.PRODUCT_STOCK_QTY > 0 AND 
            }
            else
            {
                if (globalFeatureList.EXPIRY_MODULE == 1)
                {
                    sqlCommand = "SELECT PE.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', PE.PRODUCT_AMOUNT AS 'QTY', DATE_FORMAT(PE.PRODUCT_EXPIRY_DATE, '%d-%M-%Y') AS 'TGL KADALUARSA' FROM MASTER_PRODUCT MP, PRODUCT_EXPIRY PE WHERE MP.PRODUCT_EXPIRABLE = 1 AND PE.PRODUCT_ID = MP.PRODUCT_ID " + showactive + "AND MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'";
                    sqlCommand2 = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY', '' AS 'TGL KADALUARSA' FROM MASTER_PRODUCT MP WHERE PRODUCT_EXPIRABLE = 0 AND MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" + showactive;
                    displayExpiredDate = true;

                    sqlCommand = sqlCommand + " UNION " + sqlCommand2;
                }
                else
                    sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID AS 'PRODUK ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_STOCK_QTY AS 'QTY' FROM MASTER_PRODUCT MP WHERE MP.PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND MP.PRODUCT_NAME LIKE '%" + namaProductParam + "%'" + showactive;
            }

            if (originModuleID == globalConstants.STOK_PECAH_BARANG)
            {
                sqlCommand = sqlCommand + " AND MP.PRODUCT_IS_SERVICE = 0";
            }
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dataProdukGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; //or even better .DisableResizing. Most time consumption enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
                   // dataProdukGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None;
                    
                    dt.Load(rdr);
                    dataProdukGridView.DataSource = dt;

                    dataProdukGridView.Columns["ID"].Visible = false;
                    dataProdukGridView.Columns["PRODUK ID"].Width = 200;
                    dataProdukGridView.Columns["NAMA PRODUK"].Width = 284;
                    if (displayExpiredDate)
                    {
                        dataProdukGridView.Columns["TGL KADALUARSA"].Width = 180;
                    }
                    // dataProdukGridView.Columns["DESKRIPSI PRODUK"].Width = 300;                    
                    //dataProdukGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            highlightZeroQtyRow();
        }

        private void highlightZeroQtyRow()
        {
            for (int i =0;i<dataProdukGridView.Rows.Count;i++)
            {
                if (null != dataProdukGridView.Rows[i].Cells["QTY"].Value && Convert.ToInt32(dataProdukGridView.Rows[i].Cells["QTY"].Value) <= 0)
                    dataProdukGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataProdukGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
            selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            selectedProductName = selectedRow.Cells["NAMA PRODUK"].Value.ToString();
            selectedkodeProduct = selectedRow.Cells["PRODUK ID"].Value.ToString();

            displaySpecificForm();
        }

        private void tagProdukDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == 13) // Enter
            {
                if (dataProdukGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = (dataProdukGridView.SelectedCells[0].RowIndex) - 1;

                DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
                selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm();
            } */
        }

        private void dataProdukGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // Enter
            {
                if (dataProdukGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
                selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                selectedProductName = selectedRow.Cells["NAMA PRODUK"].Value.ToString();
                selectedkodeProduct = selectedRow.Cells["PRODUK ID"].Value.ToString();

                displaySpecificForm();
            }
        }

        private void dataProdukForm_Activated(object sender, EventArgs e)
        {
            if (!namaProdukTextBox.Text.Equals("") || !kodeProductTextBox.Text.Equals(""))
            {
                loadProdukData();
            }

            registerGlobalHotkey();
        }

        private void produknonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataProdukGridView.DataSource = null;
            if (namaProdukTextBox.Text.Equals("") && kodeProductTextBox.Text.Equals(""))
            {             
            } else
            {
                loadProdukData();
            }
        }

        private void dataProdukForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_TAMBAH_PRODUK, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            if (originModuleID == globalConstants.CASHIER_MODULE || originModuleID == globalConstants.PENERIMAAN_BARANG || 
                originModuleID == globalConstants.NEW_PURCHASE_ORDER || originModuleID == globalConstants.MUTASI_BARANG ||
                originModuleID == globalConstants.NEW_REQUEST_ORDER || originModuleID == globalConstants.RETUR_PENJUALAN ||
                originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT || originModuleID == globalConstants.RETUR_PEMBELIAN
                )
            {
                newButton.Visible = false;
                produknonactiveoption.Visible = false;
            }

            gutil.reArrangeTabOrder(this);

            kodeProductTextBox.Select();
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(dataProdukGridView, true, null);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            loadProdukData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dataProdukGridView.Focus();
            }
        }

        private void namaProdukTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dataProdukGridView.Focus();
            }
        }

        private void dataProdukGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataProdukGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }

        private void dataProdukForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataProdukGridView_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void dataProdukGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
       
        }

        private void dataProdukGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            highlightZeroQtyRow();
        }
    }
}

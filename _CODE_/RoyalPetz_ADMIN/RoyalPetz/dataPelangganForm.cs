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

namespace AlphaSoft
{
    public partial class dataPelangganForm : Form
    {
        private int selectedCustomerID = 0;
        private globalUtilities gutil = new globalUtilities();
        cashierForm parentForm;
        int originModuleID = 0;

        private Data_Access DS = new Data_Access();

        dataPelangganDetailForm newPelangganForm = null;
        dataPelangganDetailForm editPelangganForm = null;
        dataReturPenjualanForm returPenjualanForm = null;
        dataReturPenjualanForm unknownCustReturPenjualanForm = null;
        pembayaranLumpSumForm pembayaranPiutangLumpSumForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private Hotkeys.GlobalHotkey ghk_ESC;

        private bool navKeyRegistered = false;

        public dataPelangganForm()
        {
            InitializeComponent();
        }

        public dataPelangganForm(int moduleID)
        {
            int userAccessOption = 0;

            InitializeComponent();

            originModuleID = moduleID;

            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                unknownCustomerButton.Visible = true;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PELANGGAN, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT || originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                newButton.Visible = false;
        }

        public dataPelangganForm(int moduleID, cashierForm originForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = originForm;

            if (originModuleID == globalConstants.CASHIER_MODULE)
            { 
                newButton.Visible = false;
            //    unknownCustomerButton.Visible = false;
                pelanggangnonactiveoption.Visible = false;
            }

            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                unknownCustomerButton.Visible = true;
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
                case Keys.Escape:
                    this.Close();
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

            ghk_ESC = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Escape, this);
            ghk_ESC.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
            ghk_ESC.Unregister();

            navKeyRegistered = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (null == newPelangganForm || newPelangganForm.IsDisposed)
                    newPelangganForm = new dataPelangganDetailForm(globalConstants.NEW_CUSTOMER);

            newPelangganForm.Show();
            newPelangganForm.WindowState = FormWindowState.Normal;
        }

        private void loadCustomerData(int options=0)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string namaPelangganParam = "";

            DS.mySqlConnect();

            namaPelangganParam = MySqlHelper.EscapeString(namaPelangganTextbox.Text);
            if (options == 1)
            {
                sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%M-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'GROSIR', 'PARTAI')) AS 'GROUP CUSTOMER', " +
                    "CUSTOMER_ADDRESS1 AS 'ALAMAT 1', CUSTOMER_ADDRESS2 AS 'ALAMAT 2', CUSTOMER_ADDRESS_CITY AS 'KOTA' " +
                    "FROM MASTER_CUSTOMER";
            }
            else
            {
                if (namaPelangganTextbox.Text.Equals(""))
                    return;
                if (pelanggangnonactiveoption.Checked == true)
                {
                    sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%M-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'GROSIR', 'PARTAI')) AS 'GROUP CUSTOMER', " +
                        "CUSTOMER_ADDRESS1 AS 'ALAMAT 1', CUSTOMER_ADDRESS2 AS 'ALAMAT 2', CUSTOMER_ADDRESS_CITY AS 'KOTA' " +
                        "FROM MASTER_CUSTOMER WHERE CUSTOMER_FULL_NAME LIKE '%" + namaPelangganParam + "%'";
                }
                else {
                    sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%M-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'GROSIR', 'PARTAI')) AS 'GROUP CUSTOMER', " +
                        "CUSTOMER_ADDRESS1 AS 'ALAMAT 1', CUSTOMER_ADDRESS2 AS 'ALAMAT 2', CUSTOMER_ADDRESS_CITY AS 'KOTA' " +
                        "FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1 AND CUSTOMER_FULL_NAME LIKE '%" + namaPelangganParam + "%'";
                }
            }

            sqlCommand = sqlCommand + " ORDER BY CUSTOMER_FULL_NAME ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPelangganDataGridView.DataSource = dt;

                    dataPelangganDataGridView.Columns["CUSTOMER_ID"].Visible = false;
                    //dataPelangganDataGridView.Columns["NAMA PELANGGAN"].Width = 300;
                    //dataPelangganDataGridView.Columns["TANGGAL BERGABUNG"].Width = 200;
                    //dataPelangganDataGridView.Columns["GROUP CUSTOMER"].Width = 200;
                }
            }
        }

        private void dataPelangganForm_Activated(object sender, EventArgs e)
        {
            //loadCustomerData();
            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }

            registerGlobalHotkey();
        }

        private void namaPelangganTextbox_TextChanged(object sender, EventArgs e)
        {
            //loadCustomerData();
            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }
        }

        private void dataPelangganDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataPelangganDataGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataPelangganDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataPelangganDataGridView.Rows[selectedrowindex];
            selectedCustomerID= Convert.ToInt32(selectedRow.Cells["CUSTOMER_ID"].Value);

            if (originModuleID == globalConstants.CASHIER_MODULE)
            {
                parentForm.setCustomerID(selectedCustomerID);
                this.Close();
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
            {
                if (null == returPenjualanForm || returPenjualanForm.IsDisposed)
                        returPenjualanForm = new dataReturPenjualanForm(originModuleID, "", selectedCustomerID);

                returPenjualanForm.Show();
                returPenjualanForm.WindowState = FormWindowState.Normal;
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
            {
                if (null == pembayaranPiutangLumpSumForm || pembayaranPiutangLumpSumForm.IsDisposed)
                        pembayaranPiutangLumpSumForm = new pembayaranLumpSumForm(originModuleID, selectedCustomerID);

                pembayaranPiutangLumpSumForm.Show();
                pembayaranPiutangLumpSumForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (null == editPelangganForm || editPelangganForm.IsDisposed)
                        editPelangganForm = new dataPelangganDetailForm(globalConstants.EDIT_CUSTOMER, selectedCustomerID);

                editPelangganForm.Show();
                editPelangganForm.WindowState = FormWindowState.Normal;
            }
        }

        private void dataPelangganForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void pelanggangnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataPelangganDataGridView.DataSource = null;

            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }
            
        }

        private void dataPelangganDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataPelangganDataGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = dataPelangganDataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataPelangganDataGridView.Rows[selectedrowindex];
                selectedCustomerID = Convert.ToInt32(selectedRow.Cells["CUSTOMER_ID"].Value);

                if (originModuleID == globalConstants.CASHIER_MODULE)
                {
                    parentForm.setCustomerID(selectedCustomerID);
                    this.Close();
                }
                else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                {
                    if (null == returPenjualanForm || returPenjualanForm.IsDisposed)
                        returPenjualanForm = new dataReturPenjualanForm(originModuleID, "", selectedCustomerID);

                    returPenjualanForm.Show();
                    returPenjualanForm.WindowState = FormWindowState.Normal;
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                {
                    if (null == pembayaranPiutangLumpSumForm || pembayaranPiutangLumpSumForm.IsDisposed)
                        pembayaranPiutangLumpSumForm = new pembayaranLumpSumForm(originModuleID, selectedCustomerID);

                    pembayaranPiutangLumpSumForm.Show();
                    pembayaranPiutangLumpSumForm.WindowState = FormWindowState.Normal;
                }
                else 
                {
                    if (null == editPelangganForm || editPelangganForm.IsDisposed)
                        editPelangganForm = new dataPelangganDetailForm(globalConstants.EDIT_CUSTOMER, selectedCustomerID);

                    editPelangganForm.Show();
                    editPelangganForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void unknownCustomerButton_Click(object sender, EventArgs e)
        {
            if (null == unknownCustReturPenjualanForm || unknownCustReturPenjualanForm.IsDisposed)
                    unknownCustReturPenjualanForm = new dataReturPenjualanForm(originModuleID, "", 0);

            unknownCustReturPenjualanForm.Show();
            unknownCustReturPenjualanForm.WindowState = FormWindowState.Normal;
        }

        private void dataPelangganForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPelangganDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPelangganDataGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            loadCustomerData(1);
        }
    }
}

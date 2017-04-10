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
using System.Globalization;

using Hotkeys;

namespace AlphaSoft
{
    public partial class dataInvoiceForm : Form
    {
        private int originModuleID = 0;
        private string selectedSO = "";
        private string selectedCustomerID = "";

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        private bool navKeyRegistered = false;

        public dataInvoiceForm()
        {
            InitializeComponent();
        }

        public dataInvoiceForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
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


        private void dataInvoiceDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataInvoiceDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = dataInvoiceDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataInvoiceDataGridView.Rows[rowSelectedIndex];

            if (selectedRow.Cells["STATUS BAYAR"].Value.ToString() == "LUNAS" && originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                return;

            selectedSO = selectedRow.Cells["NO INVOICE"].Value.ToString();

            switch(originModuleID)
            {
                case globalConstants.PEMBAYARAN_PIUTANG:
                    pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                    pembayaranForm.ShowDialog(this);
                    break;

                case globalConstants.RETUR_PENJUALAN:
                    dataReturPenjualanForm displayedForm = new dataReturPenjualanForm(originModuleID, selectedSO);
                    displayedForm.ShowDialog(this);
                    break;
            }

        }

        private void fillInPelangganCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT * FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1 ORDER BY CUSTOMER_FULL_NAME ASC";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    pelangganCombo.Items.Clear();
                    pelangganComboHidden.Items.Clear();
                    while (rdr.Read())
                    {
                        pelangganCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        pelangganComboHidden.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string noInvoiceParam = "";

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT SALES_INVOICE AS 'NO INVOICE', IFNULL(CUSTOMER_FULL_NAME, 'PELANGGAN UMUM') AS 'NAMA PELANGGAN', IF(SALES_PAID=1,'LUNAS','BELUM LUNAS') AS 'STATUS BAYAR' FROM SALES_HEADER H LEFT OUTER JOIN MASTER_CUSTOMER M ON " +
                                    "(H.CUSTOMER_ID = M.CUSTOMER_ID) WHERE 1 = 1 ";
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT CREDIT.SALES_INVOICE AS 'NO INVOICE', IFNULL(CUSTOMER_FULL_NAME, 'PELANGGAN UMUM') AS 'NAMA PELANGGAN', IF(SALES_PAID=1,'LUNAS','BELUM LUNAS') AS 'STATUS BAYAR' FROM SALES_HEADER H LEFT OUTER JOIN MASTER_CUSTOMER M ON " +
                                    "(H.CUSTOMER_ID = M.CUSTOMER_ID), CREDIT WHERE H.SALES_INVOICE = CREDIT.SALES_INVOICE ";

            if (!showAllCheckBox.Checked)
            {
                if (pelangganCombo.SelectedIndex >= 0)
                {
                    sqlCommand = sqlCommand + "AND H.CUSTOMER_ID = " + selectedCustomerID + " ";
                }

                if (noInvoiceTextBox.Text.Length > 0)
                {
                    noInvoiceParam = MySqlHelper.EscapeString(noInvoiceTextBox.Text);
                    sqlCommand = sqlCommand + "AND H.SALES_INVOICE like '%" + noInvoiceParam + "%' ";
                }

                //sqlCommand = sqlCommand + "AND SALES_PAID = 0";
            }

            using(rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataInvoiceDataGridView.DataSource = dt;

                    dataInvoiceDataGridView.Columns["NO INVOICE"].Width = 200;
                    dataInvoiceDataGridView.Columns["NAMA PELANGGAN"].Width = 300;
                    //dataInvoiceDataGridView.Columns["SALES_PAID"].Visible = false;
                }
            }
            rdr.Close();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void pelangganCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomerID = pelangganComboHidden.Items[pelangganCombo.SelectedIndex].ToString();
        }

        private void pelangganCombo_Validated(object sender, EventArgs e)
        {
            if (!pelangganCombo.Items.Contains(pelangganCombo.Text) && pelangganCombo.Text.Length > 0)
            { 
                pelangganCombo.Focus();
                pelangganCombo.BackColor = Color.Red;
            }
            else
            {
                pelangganCombo.BackColor = Color.White;
            }
        }

        private void dataInvoiceForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            fillInPelangganCombo();
            noInvoiceTextBox.Select();
        }

        private void dataInvoiceDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataInvoiceDataGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = dataInvoiceDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataInvoiceDataGridView.Rows[rowSelectedIndex];

                if (selectedRow.Cells["STATUS BAYAR"].Value.ToString() == "LUNAS" && originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                    return;

                selectedSO = selectedRow.Cells["NO INVOICE"].Value.ToString();

                switch (originModuleID)
                {
                    case globalConstants.PEMBAYARAN_PIUTANG:
                        pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                        pembayaranForm.ShowDialog(this);
                        break;

                    case globalConstants.RETUR_PENJUALAN:
                        dataReturPenjualanForm displayedForm = new dataReturPenjualanForm(originModuleID, selectedSO);
                        displayedForm.ShowDialog(this);
                        break;
                }
            }
        }

        private void dataInvoiceForm_Activated(object sender, EventArgs e)
        {
            if (dataInvoiceDataGridView.Rows.Count <= 0)
                return;

            loadData();

            registerGlobalHotkey();
        }

        private void dataInvoiceForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataInvoiceDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataInvoiceDataGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }

        private void pelangganCombo_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void pelangganCombo_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }
    }
}

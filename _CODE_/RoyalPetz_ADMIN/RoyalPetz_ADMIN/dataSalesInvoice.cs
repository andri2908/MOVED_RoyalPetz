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

namespace RoyalPetz_ADMIN
{
    public partial class dataSalesInvoice : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int customerID = 0;

        private int originModuleID = 0;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        public dataSalesInvoice()
        {
            InitializeComponent();
            originModuleID = globalConstants.COPY_NOTA;
        }

        public dataSalesInvoice(int moduleID)
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

        private void fillInCustomerCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";

            customerCombo.Items.Clear();
            customerHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customerCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        customerHiddenCombo.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadInvoiceData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noInvoiceParam = "";
            string whereClause1 = "";
            string sqlClause1 = "";
            string sqlClause2 = "";

            DS.mySqlConnect();

           
           sqlClause1 = "SELECT ID, SALES_INVOICE AS 'NO INVOICE', CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y')  AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                       "WHERE SH.CUSTOMER_ID = MC.CUSTOMER_ID";

           sqlClause2 = "SELECT ID, SALES_INVOICE AS 'NO INVOICE', '' AS 'CUSTOMER', DATE_FORMAT(SALES_DATE, '%d-%M-%Y') AS 'TGL INVOICE', (SALES_TOTAL - SALES_DISCOUNT_FINAL) AS 'TOTAL' " +
                                       "FROM SALES_HEADER SH " +
                                       "WHERE SH.CUSTOMER_ID = 0";
           
            if (!showAllCheckBox.Checked)
            {
                if (noInvoiceTextBox.Text.Length > 0)
                {
                        whereClause1 = whereClause1 + " AND SH.SALES_INVOICE LIKE '%" + noInvoiceParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));

                whereClause1 = whereClause1 + " AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "'";

                if (customerID > 0)
                {
                        sqlCommand = sqlClause1 + whereClause1 + " AND AND SH.CUSTOMER_ID = " + customerID;
                }
                else
                {
                    sqlCommand = sqlClause1 + whereClause1 + " UNION " + sqlClause2 + whereClause1;
                }
            }
            else
            {
                sqlCommand = sqlClause1 + " UNION " + sqlClause2;
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPenerimaanBarang.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPenerimaanBarang.DataSource = dt;
                    dataPenerimaanBarang.Columns["ID"].Visible = false;
                    
                    dataPenerimaanBarang.Columns["NO INVOICE"].Width = 200;
                    dataPenerimaanBarang.Columns["TGL INVOICE"].Width = 200;
                    dataPenerimaanBarang.Columns["CUSTOMER"].Width = 200;
                    dataPenerimaanBarang.Columns["TOTAL"].Width = 200;

                    dataPenerimaanBarang.Columns["TOTAL"].DefaultCellStyle.FormatProvider = culture;
                    dataPenerimaanBarang.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                }

                rdr.Close();
            }
        }

        private void dataSalesInvoice_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[1];

            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            fillInCustomerCombo();

            arrButton[0] = displayButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadInvoiceData();
        }

        private void customerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(customerHiddenCombo.Items[customerCombo.SelectedIndex].ToString());
        }

        private void dataPenerimaanBarang_DoubleClick(object sender, EventArgs e)
        {
            string noInvoice = "";
            
            if (dataPenerimaanBarang.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
            noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

            cashierForm cashierFormDisplay = new cashierForm(noInvoice, originModuleID);
            cashierFormDisplay.ShowDialog(this);
        }

        private void dataPenerimaanBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string noInvoice = "";

                if (dataPenerimaanBarang.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
                noInvoice = selectedRow.Cells["NO INVOICE"].Value.ToString();

                cashierForm cashierFormDisplay = new cashierForm(noInvoice, originModuleID);
                cashierFormDisplay.ShowDialog(this);
            }
        }

        private void genericControl_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void genericControl_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataSalesInvoice_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void dataSalesInvoice_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPenerimaanBarang_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPenerimaanBarang_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}

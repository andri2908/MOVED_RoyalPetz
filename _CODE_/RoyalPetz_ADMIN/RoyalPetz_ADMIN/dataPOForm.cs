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

namespace RoyalPetz_ADMIN
{
    public partial class dataPOForm : Form
    {
        private int selectedPOID = 0;
        private int supplierID = 0;
        private int originModuleID = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");        

        public dataPOForm()
        {
            InitializeComponent();
        }

        public dataPOForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            purchaseOrderDetailForm displayedForm = new purchaseOrderDetailForm();
            displayedForm.ShowDialog(this);
        }

        private void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";

            supplierCombo.Items.Clear();
            supplierHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("SUPPLIER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("SUPPLIER_ID"));
                    }
                }
            }
        }

        private void loadPOData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, PURCHASE_INVOICE AS 'NO PURCHASE', DATE_FORMAT(PURCHASE_DATETIME, '%d-%M-%Y')  AS 'TANGGAL PURCHASE', " +
                                "IF(PURCHASE_TERM_OF_PAYMENT = 0, 'TUNAI', 'KREDIT') AS 'MODE PEMBAYARAN', " +
                                "DATE_FORMAT(PURCHASE_TERM_OF_PAYMENT_DATE, '%d-%M-%Y') AS 'TANGGAL JATUH TEMPO', " +
                                "M.SUPPLIER_FULL_NAME AS 'NAMA SUPPLIER', PURCHASE_TOTAL AS 'TOTAL', PURCHASE_SENT " +
                                "FROM PURCHASE_HEADER P, MASTER_SUPPLIER M " +
                                "WHERE P.SUPPLIER_ID = M.SUPPLIER_ID AND P.PURCHASE_PAID = 0";

            if (originModuleID == globalConstants.PENERIMAAN_BARANG_DARI_PO)
            {
                sqlCommand = sqlCommand + " AND PURCHASE_SENT = 1 AND PURCHASE_RECEIVED = 0";
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                sqlCommand = sqlCommand + " AND PURCHASE_SENT = 1 AND PURCHASE_RECEIVED = 1";
            }

            if (!showAllCheckBox.Checked)
            {
                if (noPOInvoiceTextBox.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND PURCHASE_INVOICE LIKE '%" + noPOInvoiceTextBox.Text + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "'";

                if (supplierCombo.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND P.SUPPLIER_ID = " + supplierID;
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPurchaseOrder.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPurchaseOrder.DataSource = dt;

                    dataPurchaseOrder.Columns["ID"].Visible = false;
                    dataPurchaseOrder.Columns["PURCHASE_SENT"].Visible = false;

                    dataPurchaseOrder.Columns["NO PURCHASE"].Width = 200;
                    dataPurchaseOrder.Columns["TANGGAL PURCHASE"].Width = 200;
                    dataPurchaseOrder.Columns["TANGGAL JATUH TEMPO"].Width = 200;
                    dataPurchaseOrder.Columns["MODE PEMBAYARAN"].Width = 200;
                    dataPurchaseOrder.Columns["NAMA SUPPLIER"].Width = 200;
                    dataPurchaseOrder.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadPOData();
        }

        private void dataPOForm_Load(object sender, EventArgs e)
        {
            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            fillInSupplierCombo();

            if (originModuleID == globalConstants.PENERIMAAN_BARANG_DARI_PO || originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                newButton.Visible = false;
            }
            
            gUtil.reArrangeTabOrder(this);
        }

        private void dataPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedPurchaseInvoice;

            if (e.KeyCode == Keys.Enter)
            {
                if (dataPurchaseOrder.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataPurchaseOrder.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPurchaseOrder.Rows[rowSelectedIndex];
                

                if (originModuleID == 0)
                {
                    selectedPOID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    purchaseOrderDetailForm displayedForm = new purchaseOrderDetailForm(globalConstants.EDIT_PURCHASE_ORDER, selectedPOID);
                    displayedForm.ShowDialog(this);
                }
                else if (originModuleID == globalConstants.PENERIMAAN_BARANG_DARI_PO)
                {
                    selectedPurchaseInvoice = selectedRow.Cells["NO PURCHASE"].Value.ToString();  
                    penerimaanBarangForm displayedPenerimaanForm = new penerimaanBarangForm(originModuleID, selectedPurchaseInvoice);
                    displayedPenerimaanForm.ShowDialog(this);
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                {
                    selectedPurchaseInvoice = selectedRow.Cells["NO PURCHASE"].Value.ToString();
                    pembayaranHutangForm displayedPembayaranForm = new pembayaranHutangForm(selectedPurchaseInvoice);
                    displayedPembayaranForm.ShowDialog(this);
                }

                loadPOData();
            }
        }

        private void dataPurchaseOrder_DoubleClick(object sender, EventArgs e)
        {
            string selectedPurchaseInvoice;

            if (dataPurchaseOrder.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPurchaseOrder.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPurchaseOrder.Rows[rowSelectedIndex];

            if (originModuleID == 0)
            {
                selectedPOID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                purchaseOrderDetailForm displayedForm = new purchaseOrderDetailForm(globalConstants.EDIT_PURCHASE_ORDER, selectedPOID);
                displayedForm.ShowDialog(this);
            }
            else if (originModuleID == globalConstants.PENERIMAAN_BARANG_DARI_PO)
            {
                selectedPurchaseInvoice = selectedRow.Cells["NO PURCHASE"].Value.ToString();
                penerimaanBarangForm displayedPenerimaanForm = new penerimaanBarangForm(originModuleID, selectedPurchaseInvoice);
                displayedPenerimaanForm.ShowDialog(this);
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                selectedPurchaseInvoice = selectedRow.Cells["NO PURCHASE"].Value.ToString();
                pembayaranHutangForm displayedPembayaranForm = new pembayaranHutangForm(selectedPurchaseInvoice);
                displayedPembayaranForm.ShowDialog(this);
            }

            loadPOData();
        }
        private void dataPOForm_Activated(object sender, EventArgs e)
        {
            if (noPOInvoiceTextBox.Text.Length > 0)
                displayButton.PerformClick();
        }
    }
}

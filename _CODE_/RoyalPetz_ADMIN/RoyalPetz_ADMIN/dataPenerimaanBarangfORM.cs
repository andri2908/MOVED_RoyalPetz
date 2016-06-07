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
    public partial class dataPenerimaanBarangForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int supplierID = 0;

        public dataPenerimaanBarangForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            penerimaanBarangForm displayedForm = new penerimaanBarangForm();
            displayedForm.ShowDialog(this);
        }

        private void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";

            supplierCombo.Items.Clear();
            supplierHiddenCombo.Items.Clear();

            // ADD ENTRY FOR GUDANG PUSAT
            supplierCombo.Items.Add("GUDANG PUSAT");
            supplierHiddenCombo.Items.Add("0");

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

        private void dataPenerimaanBarangForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];

            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            fillInSupplierCombo();

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PENERIMAAN_BARANG, gUtil.getUserGroupID());

            if (userAccessOption == 1)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            arrButton[0] = displayButton;
            arrButton[1] = newButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void dataPenerimaanBarang_DoubleClick(object sender, EventArgs e)
        {
            string selectedPRInvoice;
            string selectedPOInvoice = "";
            string selectedPMInvoice = "";

            if (dataPenerimaanBarang.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
            selectedPRInvoice = selectedRow.Cells["NO PENERIMAAN"].Value.ToString();
            selectedPOInvoice = selectedRow.Cells["PURCHASE_INVOICE"].Value.ToString();
            selectedPMInvoice = selectedRow.Cells["PM_INVOICE"].Value.ToString();

            if (DialogResult.Yes == MessageBox.Show("PRINT RECEIPT ? ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                printReport(selectedPRInvoice, selectedPMInvoice, selectedPOInvoice);

                pleaseWait.Close();
            }
        }

        private void printReport(string invoiceNo, string mutasiNo, string poNo)
        {
            string sqlCommandx = "";
            if (mutasiNo.Length > 0)
            {
                sqlCommandx = "SELECT '1' AS TYPE, '" + mutasiNo + "' AS ORIGIN_INVOICE, DATE(PH.PR_DATE) AS 'TGL', PH.PR_INVOICE AS 'INVOICE', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_BASE_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PR_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM PRODUCTS_RECEIVED_HEADER PH, PRODUCTS_RECEIVED_DETAIL PD, MASTER_PRODUCT MP " +
                                     "WHERE PH.PR_INVOICE = '" + invoiceNo + "' AND PD.PR_INVOICE = PH.PR_INVOICE AND PD.PRODUCT_ID = MP.PRODUCT_ID";
            }
            else if (poNo.Length > 0)
            {
                sqlCommandx = "SELECT '2' AS TYPE, '" + poNo + "' AS ORIGIN_INVOICE, DATE(PH.PR_DATE) AS 'TGL', PH.PR_INVOICE AS 'INVOICE', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_BASE_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PR_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM PRODUCTS_RECEIVED_HEADER PH, PRODUCTS_RECEIVED_DETAIL PD, MASTER_PRODUCT MP " +
                                     "WHERE PH.PR_INVOICE = '" + invoiceNo + "' AND PD.PR_INVOICE = PH.PR_INVOICE AND PD.PRODUCT_ID = MP.PRODUCT_ID";
            }
            else
            {
                sqlCommandx = "SELECT '0' AS TYPE, 'AA' AS ORIGIN_INVOICE, DATE(PH.PR_DATE) AS 'TGL', PH.PR_INVOICE AS 'INVOICE', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_BASE_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PR_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM PRODUCTS_RECEIVED_HEADER PH, PRODUCTS_RECEIVED_DETAIL PD, MASTER_PRODUCT MP " +
                                     "WHERE PH.PR_INVOICE = '" + invoiceNo + "' AND PD.PR_INVOICE = PH.PR_INVOICE AND PD.PRODUCT_ID = MP.PRODUCT_ID";
            }

            //"WHERE PD.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PH.SUPPLIER_ID = MS.SUPPLIER_ID " + supplier + "AND PD.PRODUCT_ID = MP.PRODUCT_ID AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "' " +
            //"ORDER BY TGL,INVOICE,PRODUK";

            DS.writeXML(sqlCommandx, globalConstants.penerimaanBarangXML);
            penerimaanBarangPrintOutForm displayForm = new penerimaanBarangPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void dataPenerimaanBarang_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedPRInvoice = "";
            string selectedPOInvoice = "";
            string selectedPMInvoice = "";

            if (e.KeyCode == Keys.Enter)
            { 
                if (dataPenerimaanBarang.Rows.Count <= 0)
                return;

                int rowSelectedIndex = (dataPenerimaanBarang.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPenerimaanBarang.Rows[rowSelectedIndex];
                selectedPRInvoice = selectedRow.Cells["NO PENERIMAAN"].Value.ToString();
                selectedPOInvoice = selectedRow.Cells["PURCHASE_INVOICE"].Value.ToString();
                selectedPMInvoice = selectedRow.Cells["PM_INVOICE"].Value.ToString();

                if (DialogResult.Yes == MessageBox.Show("PRINT RECEIPT ? ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    smallPleaseWait pleaseWait = new smallPleaseWait();
                    pleaseWait.Show();

                    //  ALlow main UI thread to properly display please wait form.
                    Application.DoEvents();
                    printReport(selectedPRInvoice, selectedPMInvoice, selectedPOInvoice);

                    pleaseWait.Close();
                }
            }
        }

        private void loadPRData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noPOInvoiceParam = "";
            string whereClause1= "";
            string selectClause1;
            string selectClause2;
            DS.mySqlConnect();

            selectClause1 = "SELECT ID, PR_INVOICE AS 'NO PENERIMAAN', DATE_FORMAT(PR_DATE, '%d-%M-%Y')  AS 'TANGGAL PENERIMAAN', " +
                                "M.SUPPLIER_FULL_NAME AS 'ASAL', P.PR_TOTAL AS 'TOTAL', PURCHASE_INVOICE, PM_INVOICE " +
                                "FROM PRODUCTS_RECEIVED_HEADER P, MASTER_SUPPLIER M " +
                                "WHERE P.PR_FROM = M.SUPPLIER_ID ";

            selectClause2 = "SELECT ID, PR_INVOICE AS 'NO PENERIMAAN', DATE_FORMAT(PR_DATE, '%d-%M-%Y')  AS 'TANGGAL PENERIMAAN', " +
                                "'GUDANG PUSAT' AS 'ASAL', P.PR_TOTAL AS 'TOTAL', PURCHASE_INVOICE, PM_INVOICE " +
                                "FROM PRODUCTS_RECEIVED_HEADER P ";

            if (!showAllCheckBox.Checked)
            {
                if (supplierID > 0)
                {
                    sqlCommand = selectClause1;
                    whereClause1 = whereClause1 + " AND P.PR_FROM = " + supplierID;
                }
                else
                { 
                    sqlCommand = selectClause2;
                    whereClause1 = "WHERE 1=1";
                }
                if (noPOInvoiceTextBox.Text.Length > 0)
                {
                    noPOInvoiceParam = MySqlHelper.EscapeString(noPOInvoiceTextBox.Text);
                    whereClause1 = whereClause1 + " AND PR_INVOICE LIKE '%" + noPOInvoiceParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                whereClause1 = whereClause1 + " AND DATE_FORMAT(PR_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PR_DATE, '%Y%m%d')  <= '" + dateTo + "'";

                sqlCommand = sqlCommand + whereClause1;
            }
            else
            {
                sqlCommand = selectClause1 + " UNION " + selectClause2 + " WHERE P.PR_FROM = 0";                
            }


            using (rdr = DS.getData(sqlCommand))
            {
                dataPenerimaanBarang.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPenerimaanBarang.DataSource = dt;

                    dataPenerimaanBarang.Columns["ID"].Visible = false;

                    dataPenerimaanBarang.Columns["NO PENERIMAAN"].Width = 200;
                    dataPenerimaanBarang.Columns["TANGGAL PENERIMAAN"].Width = 200;
                    dataPenerimaanBarang.Columns["ASAL"].Width = 200;
                    dataPenerimaanBarang.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }
    

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadPRData();
        }

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex].ToString());
        }
    }
}

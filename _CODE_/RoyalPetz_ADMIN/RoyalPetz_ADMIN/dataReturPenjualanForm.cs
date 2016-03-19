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
    public partial class dataReturPenjualanForm : Form
    {
        private int originModuleID;
        private int selectedCustomerID;
        private string selectedProductID;
        private string selectedSalesInvoice = " ";
        private double globalTotalValue = 0;
        private bool isLoading = false;
        private bool returnCash = false;
        private List<string> returnQty = new List<string>();
        string previousInput = "";
        double extraAmount = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public dataReturPenjualanForm()
        {
            InitializeComponent();
        }

        public dataReturPenjualanForm(int moduleID, string purchaseInvoice = "", int customerID = 0)
        {
            InitializeComponent();

            originModuleID = moduleID;

            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
            {
                invoiceDateLabel.Visible = false;
                invoiceDateTextBox.Visible = false;
                invoiceTotalLabel.Visible = false;
                invoiceTotalLabelValue.Visible = false;
                invoiceSignLabel.Visible = false;
                selectedCustomerID = customerID;

                invoiceInfoLabel.Text = "NAMA PELANGGAN";
            }
            else
            {
                selectedSalesInvoice = purchaseInvoice;
            }
        }

        private void addDataGridColumn()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn purchaseQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn retailPriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT M.PRODUCT_ID, M.PRODUCT_NAME FROM MASTER_PRODUCT M, SALES_DETAIL SD " +
                                    "WHERE SD.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SD.PRODUCT_ID = M.PRODUCT_ID";
            else
                sqlCommand = "SELECT M.PRODUCT_ID, M.PRODUCT_NAME FROM MASTER_PRODUCT M, SALES_DETAIL SD, SALES_HEADER SH " +
                                    "WHERE PRODUCT_ACTIVE = 1 AND SH.SALES_INVOICE = SD.SALES_INVOICE AND SD.PRODUCT_ID = M.PRODUCT_ID AND SH.CUSTOMER_ID = " + selectedCustomerID + 
                                    " GROUP BY M.PRODUCT_ID";

            productComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
                }
            }

            rdr.Close();

            // PRODUCT NAME COLUMN
            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            detailReturDataGridView.Columns.Add(productNameCmb);

            retailPriceColumn.HeaderText = "SALES PRICE";
            retailPriceColumn.Name = "productPrice";
            retailPriceColumn.Width = 100;
            retailPriceColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(retailPriceColumn);

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                purchaseQtyColumn.HeaderText = "SO QTY";
                purchaseQtyColumn.Name = "SOqty";
                purchaseQtyColumn.Width = 100;
                purchaseQtyColumn.ReadOnly = true;
                detailReturDataGridView.Columns.Add(purchaseQtyColumn);
            }
            
            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            detailReturDataGridView.Columns.Add(stockQtyColumn);

            subtotalColumn.HeaderText = "SUBTOTAL";
            subtotalColumn.Name = "subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(subtotalColumn);

            productIdColumn.HeaderText = "PRODUCT_ID";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 200;
            productIdColumn.Visible = false;
            detailReturDataGridView.Columns.Add(productIdColumn);
        }

        private bool noReturExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM RETURN_SALES_HEADER WHERE RS_INVOICE = '" + noReturTextBox.Text + "'")) > 0)
                result = true;

            return result;
        }

        private void detailReturDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (detailReturDataGridView.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if ((detailReturDataGridView.CurrentCell.ColumnIndex == 2 || detailReturDataGridView.CurrentCell.ColumnIndex == 3) && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private string getProductID(int selectedIndex)
        {
            string productID = "";
            productID = productComboHidden.Items[selectedIndex].ToString();
            return productID;
        }

        private double getProductPriceValue(string productID)
        {
            double result = 0;
            string sqlCommand = "";
            DS.mySqlConnect();

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT PRODUCT_SALES_PRICE FROM SALES_DETAIL WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND PRODUCT_ID = '" + productID + "'";
            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                sqlCommand = "SELECT PRODUCT_RETAIL_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "' AND PRODUCT_ACTIVE = 1";

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getSOQty(string productID)
        {
            double result = 0;
            string sqlCommand = "";
            DS.mySqlConnect();

            sqlCommand = "SELECT PRODUCT_QTY FROM SALES_DETAIL WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND PRODUCT_ID = '" + productID + "'";
            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }
        
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;
            double subTotal = 0;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;

            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            selectedProductID = getProductID(selectedIndex);
            hpp = getProductPriceValue(selectedProductID);

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            selectedRow.Cells["productPrice"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                selectedRow.Cells["SOqty"].Value = getSOQty(selectedProductID);

            selectedRow.Cells["productId"].Value = selectedProductID;

            subTotal = Math.Round((hpp * Convert.ToDouble(Convert.ToDouble(selectedRow.Cells["qty"].Value))), 2);
            selectedRow.Cells["subtotal"].Value = subTotal;

            calculateTotal();
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i < detailReturDataGridView.Rows.Count; i++)
            {
                if (null != detailReturDataGridView.Rows[i].Cells["subtotal"].Value)
                    total = total + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subtotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = "Rp. " + total.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double subTotal = 0;
            double productPrice = 0;
            string productID = "";

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            if (null != selectedRow.Cells["productID"].Value)
                productID = selectedRow.Cells["productID"].Value.ToString();

            if (gutil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                && (dataGridViewTextBoxEditingControl.Text.Length > 0)
                )
            {
                if (returnQty.Count > rowSelectedIndex)
                    returnQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                else
                    returnQty.Add(dataGridViewTextBoxEditingControl.Text);

                previousInput = dataGridViewTextBoxEditingControl.Text;
            }
            else
            {
                if (returnQty.Count >= rowSelectedIndex)
                    dataGridViewTextBoxEditingControl.Text = returnQty[rowSelectedIndex];
                else
                    dataGridViewTextBoxEditingControl.Text = previousInput;

            }

            productPrice = Convert.ToDouble(selectedRow.Cells["productPrice"].Value);

            subTotal = Math.Round((productPrice * Convert.ToDouble(returnQty[rowSelectedIndex])), 2);
            selectedRow.Cells["subtotal"].Value = subTotal;

            calculateTotal();
        }

        private void noReturTextBox_TextChanged(object sender, EventArgs e)
        {
            if (noReturExist())
            {
                errorLabel.Text = "NO RETUR SUDAH ADA";
                noReturTextBox.Focus();
            }
            else
                errorLabel.Text = "";
        }

        private void detailReturDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (isLoading)
                return;

            returnQty.Add("0");
            detailReturDataGridView.Rows[e.RowIndex].Cells["qty"].Value = "0";
        }
        
        private string getInvoiceTotalValue()
        {
            string result = "";

            // GLOBAL SALES TOTAL VALUE WITHOUT ANY PAYMENT / RETURN
            result = DS.getDataSingleValue("SELECT SALES_TOTAL FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'").ToString();

            return result;
        }

        private string getPelangganName()
        {
            string result = "";
            
            result = DS.getDataSingleValue("SELECT CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = "+selectedCustomerID).ToString();

            return result;
        }

        private void loadDataHeader()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            DateTime salesDate = DateTime.Now;

            sqlCommand = "SELECT SALES_INVOICE, SALES_DATE, CUSTOMER_ID FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();

                    invoiceInfoTextBox.Text = selectedSalesInvoice;//rdr.GetString("SALES_INVOICE");
                    salesDate = rdr.GetDateTime("SALES_DATE");
                    invoiceDateTextBox.Text = String.Format(culture, "{0:dd MMM yyyy}", salesDate);
                    selectedCustomerID = rdr.GetInt32("CUSTOMER_ID");
                }
            }
            rdr.Close();
        }

        private void deleteCurrentRow()
        {
            if (detailReturDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

                detailReturDataGridView.Rows.Remove(selectedRow);
            }
        }

        private void detailReturDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                {
                    deleteCurrentRow();
                    calculateTotal();
                }
            }
        }

        private bool dataValidated()
        {
            if (noReturTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO RETUR TIDAK BOLEH KOSONG";
                return false;   
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string returID = "0";
            int customerID = 0;
            string ReturDateTime = "";
            DateTime selectedReturDate;
            double returTotal = 0;
            double hppValue;
            double qtyValue;
            double soQty = 0;
            string descriptionValue;
            MySqlException internalEX = null;
            double totalCredit = 0;

            double returNominal = 0;
            double actualReturAmount = 0;
            double outstandingCreditAmount = 0;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            int rowCounter;
            int currentCreditID;
            bool fullyPaid = false;

            
            int selectedCreditID;

            returID = noReturTextBox.Text;
            customerID = selectedCustomerID;

            selectedReturDate = rsDateTimePicker.Value;
            ReturDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedReturDate);

            returTotal = globalTotalValue;
            returNominal = returTotal;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                    sqlCommand = "INSERT INTO RETURN_SALES_HEADER (RS_INVOICE, CUSTOMER_ID, RS_DATETIME, RS_TOTAL) VALUES " +
                                        "('" + returID + "', " + selectedCustomerID +", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), " + returTotal + ")";
                else
                    sqlCommand = "INSERT INTO RETURN_SALES_HEADER (RS_INVOICE, SALES_INVOICE, CUSTOMER_ID, RS_DATETIME, RS_TOTAL) VALUES " +
                                    "('" + returID + "', '" + selectedSalesInvoice + "', " + selectedCustomerID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), " + returTotal + ")";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < detailReturDataGridView.Rows.Count - 1; i++)
                {
                    hppValue = Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["productPrice"].Value);
                    qtyValue = Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["qty"].Value);

                    if (originModuleID == globalConstants.RETUR_PENJUALAN)
                        soQty = Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["SOqty"].Value);

                    try
                    {
                        descriptionValue = detailReturDataGridView.Rows[i].Cells["description"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        descriptionValue = " ";
                    }

                    sqlCommand = "INSERT INTO RETURN_SALES_DETAIL (RS_INVOICE, PRODUCT_ID, PRODUCT_SALES_PRICE, PRODUCT_SALES_QTY, PRODUCT_RETURN_QTY, RS_DESCRIPTION, RS_SUBTOTAL) VALUES " +
                                        "('" + returID + "', '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + hppValue + ", " + soQty + ", " + qtyValue + ", '" + descriptionValue + "', " + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE MASTER PRODUCT
                    sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + qtyValue + " WHERE PRODUCT_ID = '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                extraAmount = 0;
                // IF THERE'S ANY CREDIT LEFT FOR THAT PARTICULAR INVOICE
                if (originModuleID == globalConstants.RETUR_PENJUALAN)
                {
                    totalCredit = getTotalCredit();
                    selectedCreditID = getCreditID();

                    if (selectedCreditID > 0)
                    {
                        if (totalCredit >= globalTotalValue)
                        {
                            // RETUR VALUE LESS THAN OR EQUAL TOTAL CREDIT
                            // add retur as cash payment with description retur no
                            sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                                "(" + selectedCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + globalTotalValue + ", 'RETUR [" + returID + "]', 1)";
                
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                        else
                        {
                            // RETUR VALUE BIGGER THAN TOTAL CREDIT
                            // return the extra amount as cash
                            extraAmount = globalTotalValue - totalCredit;
                            sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                                "(" + selectedCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + totalCredit + ", 'RETUR [" + noReturTextBox.Text + "]', 1)";
                        
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        if (totalCredit <= globalTotalValue)
                        {
                            // UPDATE SALES HEADER TABLE
                            sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // UPDATE CREDIT TABLE
                            sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                    else
                        extraAmount = globalTotalValue;
                }
                else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                {
                    if (returnCash)
                        extraAmount = globalTotalValue;
                    else
                    {
                        // GET A LIST OF OUTSTANDING SALES CREDIT
                        sqlCommand = "SELECT C.CREDIT_ID, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                            "FROM SALES_HEADER S, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                            "WHERE S.CUSTOMER_ID = " + selectedCustomerID + " AND C.CREDIT_PAID = 0 " +
                                            "AND C.SALES_INVOICE = S.SALES_INVOICE ORDER BY C.CREDIT_ID ASC";

                        using (rdr = DS.getData(sqlCommand))
                        {
                            if (rdr.HasRows)
                                dt.Load(rdr);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            rowCounter = 0;
                            while (returNominal > 0 && rowCounter < dt.Rows.Count)
                            {
                                fullyPaid = false;

                                currentCreditID = Convert.ToInt32(dt.Rows[rowCounter]["CREDIT_ID"].ToString());
                                outstandingCreditAmount = Convert.ToDouble(dt.Rows[rowCounter]["SISA PIUTANG"].ToString());

                                if (outstandingCreditAmount <= returNominal && outstandingCreditAmount > 0)
                                {
                                    actualReturAmount = outstandingCreditAmount;
                                    fullyPaid = true;
                                }
                                else
                                    actualReturAmount = returNominal;

                                sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                                    "(" + currentCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + actualReturAmount + ", 'RETUR [" + returID + "]', 1)";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;

                                if (fullyPaid)
                                {
                                    // UPDATE CREDIT TABLE
                                    sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + currentCreditID;

                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }

                                returNominal = returNominal - actualReturAmount;
                                rowCounter += 1;
                            }
                        }
                    }
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gutil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData()
        {
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private double getTotalCredit()
        {
            double totalPayment = 0;
            double totalSales = 0;
            double totalCredit = 0;
            string sqlCommand = "";

            // get Total sales for that particular Invoice
            sqlCommand = "SELECT IFNULL(SALES_TOTAL, 0) FROM SALES_HEADER WHERE SALES_INVOICE = '" +selectedSalesInvoice + "'";
            totalSales = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            // get Total Payment for that invoice 
            sqlCommand = "SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT, CREDIT WHERE CREDIT.SALES_INVOICE = '" + selectedSalesInvoice + "' AND PAYMENT_CREDIT.CREDIT_ID = CREDIT.CREDIT_ID";
            totalPayment = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            totalCredit = totalSales - totalPayment;

            return totalCredit;
        }

        private int getCreditID()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(CREDIT_ID, 0) FROM CREDIT WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'"));

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
            {
                if (DialogResult.Yes == MessageBox.Show("RETUR BERUPA UANG CASH?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    returnCash = true;
            }

            if (saveData())
            {
                if (extraAmount > 0)
                    MessageBox.Show("JUMLAH YANG DIKEMBALIKAN SEBESAR " + extraAmount.ToString("C", culture));

                errorLabel.Text = "";
                gutil.showSuccess(gutil.INS);
                saveButton.Enabled = false;
            }
        }
        
        private void dataReturPenjualanForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            rsDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            isLoading = true;
            if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                invoiceInfoTextBox.Text = getPelangganName();
            else
            {
                invoiceTotalLabelValue.Text = "Rp. " + getInvoiceTotalValue();
                loadDataHeader();
            }

            addDataGridColumn();

            isLoading = false;

            detailReturDataGridView.EditingControlShowing += detailReturDataGridView_EditingControlShowing;
            gutil.reArrangeTabOrder(this);
        }
        
    }
}

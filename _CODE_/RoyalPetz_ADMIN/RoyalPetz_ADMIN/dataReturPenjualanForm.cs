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
        private List<string> SOreturnQty = new List<string>();
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

            DataGridViewComboBoxColumn productIdCmb = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn purchaseQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn retailPriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            
            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT M.PRODUCT_ID, M.PRODUCT_NAME FROM MASTER_PRODUCT M, SALES_DETAIL SD " +
                                    "WHERE SD.SALES_INVOICE = '" + selectedSalesInvoice + "' AND SD.PRODUCT_ID = M.PRODUCT_ID " + 
                                    "GROUP BY M.PRODUCT_ID";
            else
                sqlCommand = "SELECT M.PRODUCT_ID, M.PRODUCT_NAME FROM MASTER_PRODUCT M, SALES_DETAIL SD, SALES_HEADER SH " +
                                    "WHERE PRODUCT_ACTIVE = 1 AND SH.SALES_INVOICE = SD.SALES_INVOICE AND SD.PRODUCT_ID = M.PRODUCT_ID AND SH.CUSTOMER_ID = " + selectedCustomerID + 
                                    " GROUP BY M.PRODUCT_ID";

            //productComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIdCmb.Items.Add(rdr.GetString("PRODUCT_ID"));
                }
            }

            rdr.Close();

            productIdCmb.HeaderText = "KODE PRODUK";
            productIdCmb.Name = "productID";
            productIdCmb.Width = 200;
            productIdCmb.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(productIdCmb);

            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            productNameCmb.DefaultCellStyle.BackColor = Color.LightBlue;
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
            stockQtyColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(stockQtyColumn);

            subtotalColumn.HeaderText = "SUBTOTAL";
            subtotalColumn.Name = "subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(subtotalColumn);

        }

        private bool noReturExist()
        {
            bool result = false;
            string noReturParam = MySqlHelper.EscapeString(noReturTextBox.Text);

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM RETURN_SALES_HEADER WHERE RS_INVOICE = '" + noReturParam + "'")) > 0)
                result = true;

            return result;
        }

        private void detailReturDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailReturDataGridView.CurrentCell.OwningColumn.Name == "productID" || detailReturDataGridView.CurrentCell.OwningColumn.Name == "productName") && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if (detailReturDataGridView.CurrentCell.OwningColumn.Name == "qty" && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private double getProductPriceValue(string productID)
        {
            double result = 0;
            string sqlCommand = "";
            //DS.mySqlConnect();

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT PRODUCT_SALES_PRICE FROM SALES_DETAIL WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND PRODUCT_ID = '" + productID + "'";
            else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                sqlCommand = "SELECT PRODUCT_RETAIL_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "' AND PRODUCT_ACTIVE = 1";

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getSOQty(string productID)
        {
            double result = 0;
            string sqlCommand = "";
            DS.mySqlConnect();

            sqlCommand = "SELECT SUM(PRODUCT_QTY) FROM SALES_DETAIL WHERE SALES_INVOICE = '" + selectedSalesInvoice + "' AND PRODUCT_ID = '" + productID + "'";
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
            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            DataGridViewComboBoxCell productIDComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productID"];
            DataGridViewComboBoxCell productNameComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productName"];

            if (selectedIndex < 0)
                return;

            selectedProductID = productIDComboCell.Items[selectedIndex].ToString();
            productIDComboCell.Value = productIDComboCell.Items[selectedIndex];
            productNameComboCell.Value = productNameComboCell.Items[selectedIndex];

            hpp = getProductPriceValue(selectedProductID);

            selectedRow.Cells["productPrice"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                selectedRow.Cells["SOqty"].Value = getSOQty(selectedProductID);

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
            totalLabel.Text = total.ToString("C2", culture);//"Rp. " + total.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double subTotal = 0;
            double productPrice = 0;
            //string productID = "";
            double soQTY = 0;
            bool validQty = false;
            string tempString;
            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            //if (null != selectedRow.Cells["productID"].Value)
            //    productID = selectedRow.Cells["productID"].Value.ToString();

            if (isLoading)
                return;

            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                isLoading = true;
                // reset subTotal Value and recalculate total
                selectedRow.Cells["subtotal"].Value = 0;

                if (returnQty.Count > rowSelectedIndex)
                    returnQty[rowSelectedIndex] = "0";
                dataGridViewTextBoxEditingControl.Text = "0";

                calculateTotal();

                dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
                isLoading = false;

                return;
            }

            isLoading = true;
            if (returnQty.Count > rowSelectedIndex)
                previousInput = returnQty[rowSelectedIndex];
            else
                previousInput = "0";

            if (previousInput == "0")
            {
                tempString = dataGridViewTextBoxEditingControl.Text;
                if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0 )
                    dataGridViewTextBoxEditingControl.Text = tempString.Remove(tempString.IndexOf('0'), 1);
            }

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                if (null != selectedRow.Cells["SOqty"].Value)
                    soQTY = Convert.ToDouble(selectedRow.Cells["SOqty"].Value);

                if (soQTY >= Convert.ToDouble(dataGridViewTextBoxEditingControl.Text))
                    validQty = true;
                else
                    validQty = false;
            }
            else
                validQty = true;

            if (gutil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                && (dataGridViewTextBoxEditingControl.Text.Length > 0) && validQty
                )
            {
                if (returnQty.Count > rowSelectedIndex)
                    returnQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                else
                    returnQty.Add(dataGridViewTextBoxEditingControl.Text);
            }
            else
            {
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            productPrice = Convert.ToDouble(selectedRow.Cells["productPrice"].Value);

            subTotal = Math.Round((productPrice * Convert.ToDouble(returnQty[rowSelectedIndex])), 2);
            selectedRow.Cells["subtotal"].Value = subTotal;

            calculateTotal();

            dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
            isLoading = false;
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
            double resultValue = 0;

            // GLOBAL SALES TOTAL VALUE WITHOUT ANY PAYMENT / RETURN
            resultValue = Convert.ToDouble(DS.getDataSingleValue("SELECT SALES_TOTAL FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'"));
            result = resultValue.ToString("C2", culture);

            return result;
        }

        private string getPelangganName()
        {
            string result = "";
            
            if (selectedCustomerID > 0)
                result = DS.getDataSingleValue("SELECT IFNULL(CUSTOMER_FULL_NAME, '') FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = "+selectedCustomerID).ToString();

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

            if (globalTotalValue <= 0)
            {
                errorLabel.Text = "NILAI RETUR 0";
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

            returID = MySqlHelper.EscapeString(noReturTextBox.Text);
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
                                        "('" + returID + "', " + selectedCustomerID +", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), " + gutil.validateDecimalNumericInput(returTotal) + ")";
                else
                    sqlCommand = "INSERT INTO RETURN_SALES_HEADER (RS_INVOICE, SALES_INVOICE, CUSTOMER_ID, RS_DATETIME, RS_TOTAL) VALUES " +
                                    "('" + returID + "', '" + selectedSalesInvoice + "', " + selectedCustomerID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), " + gutil.validateDecimalNumericInput(returTotal) + ")";

                gutil.saveSystemDebugLog(originModuleID, "INSERT INTO RETURN SALES HEADER [" + returID + "]");

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
                                        "('" + returID + "', '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + hppValue + ", " + soQty + ", " + qtyValue + ", '" + descriptionValue + "', " + gutil.validateDecimalNumericInput(Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                    gutil.saveSystemDebugLog(originModuleID, "INSERT INTO RETURN SALES DETAIL [" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + ", " + hppValue + ", " + soQty + ", " + qtyValue + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE MASTER PRODUCT
                    sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + qtyValue + " WHERE PRODUCT_ID = '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'";

                    gutil.saveSystemDebugLog(originModuleID, "UPDATE MASTER PRODUCT QTY ["+ detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                extraAmount = 0;
                // IF THERE'S ANY CREDIT LEFT FOR THAT PARTICULAR INVOICE
                gutil.saveSystemDebugLog(originModuleID, "CHECK FOR ANY OUTSTANDING AMOUNT FOR THE INVOICE");
                if (originModuleID == globalConstants.RETUR_PENJUALAN)
                {
                    totalCredit = getTotalCredit();
                    selectedCreditID = getCreditID();

                    gutil.saveSystemDebugLog(originModuleID, "selectedCreditID [" + selectedCreditID + "]");
                    if (selectedCreditID > 0)
                    {
                        if (totalCredit >= globalTotalValue)
                        {
                            // RETUR VALUE LESS THAN OR EQUAL TOTAL CREDIT
                            // add retur as cash payment with description retur no
                            gutil.saveSystemDebugLog(originModuleID, "RETUR VALUE LESS THAN OR EQUAL TOTAL CREDIT");
                            sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE, PAYMENT_CONFIRMED_DATE) VALUES " +
                                                "(" + selectedCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + gutil.validateDecimalNumericInput(globalTotalValue) + ", 'RETUR [" + returID + "]', 1, STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'))";

                            gutil.saveSystemDebugLog(originModuleID, "INSERT INTO PAYMENT CREDIT [" + selectedCreditID + ", " + gutil.validateDecimalNumericInput(globalTotalValue) + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                        else
                        {
                            // RETUR VALUE BIGGER THAN TOTAL CREDIT
                            gutil.saveSystemDebugLog(originModuleID, "RETUR VALUE BIGGER THAN TOTAL CREDIT");
                            // return the extra amount as cash
                            extraAmount = globalTotalValue - totalCredit;
                            gutil.saveSystemDebugLog(originModuleID, "extraAmount [" + extraAmount + "]");
                            sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE, PAYMENT_CONFIRMED_DATE) VALUES " +
                                                "(" + selectedCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + gutil.validateDecimalNumericInput(totalCredit) + ", 'RETUR [" + noReturTextBox.Text + "]', 1, STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'))";

                            gutil.saveSystemDebugLog(originModuleID, "INSERT INTO PAYMENT CREDIT [" + selectedCreditID + ", " + gutil.validateDecimalNumericInput(totalCredit) + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        if (totalCredit <= globalTotalValue)
                        {
                            gutil.saveSystemDebugLog(originModuleID, "RETUR VALUE BIGGER THAN TOTAL CREDIT VALUE, MEANS FULLY PAID");
                            // UPDATE SALES HEADER TABLE
                            sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + selectedSalesInvoice + "'";
                            gutil.saveSystemDebugLog(originModuleID, "UPDATE SALES HEADER [" + selectedSalesInvoice + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // UPDATE CREDIT TABLE
                            sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;
                            gutil.saveSystemDebugLog(originModuleID, "UPDATE CREDIT [" + selectedCreditID + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                    }
                    else
                        extraAmount = globalTotalValue;
                }
                else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                {
                    gutil.saveSystemDebugLog(originModuleID, "GET LIST OF OUTSTANDING CREDIT AND PAY FROM THE OLDEST CREDIT");
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
                            gutil.saveSystemDebugLog(originModuleID, "AMOUNT OF RETUR ["+ returNominal + "] NUM OF OUTSTANDING CREDIT [" + dt.Rows.Count + "]");
                            rowCounter = 0;
                            while (returNominal > 0 && rowCounter < dt.Rows.Count)
                            {
                                fullyPaid = false;

                                currentCreditID = Convert.ToInt32(dt.Rows[rowCounter]["CREDIT_ID"].ToString());
                                outstandingCreditAmount = Convert.ToDouble(dt.Rows[rowCounter]["SISA PIUTANG"].ToString());

                                gutil.saveSystemDebugLog(originModuleID, "currentCreditID [" + currentCreditID + "] outstandingCreditAmount [" + outstandingCreditAmount + "]");

                                if (outstandingCreditAmount <= returNominal && outstandingCreditAmount > 0)
                                {
                                    gutil.saveSystemDebugLog(originModuleID, "currentCreditID [" + currentCreditID + "] FULLY PAID");
                                    actualReturAmount = outstandingCreditAmount;
                                    fullyPaid = true;
                                }
                                else
                                {
                                    actualReturAmount = returNominal;
                                    gutil.saveSystemDebugLog(originModuleID, "currentCreditID [" + currentCreditID + "] NOT FULLY PAID [" + actualReturAmount + "]");
                                }

                                sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE, PAYMENT_CONFIRMED_DATE) VALUES " +
                                                    "(" + currentCreditID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), 1, " + gutil.validateDecimalNumericInput(actualReturAmount) + ", 'RETUR [" + returID + "]', 1, STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'))";

                                gutil.saveSystemDebugLog(originModuleID, "INSERT TO PAYMENT CREDIT [" + currentCreditID + ", " + gutil.validateDecimalNumericInput(actualReturAmount) + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;

                                if (fullyPaid)
                                {
                                    // UPDATE CREDIT TABLE
                                    sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + currentCreditID;
                                    gutil.saveSystemDebugLog(originModuleID, "UPDATE CREDIT [" + currentCreditID + "] TO FULLY PAID");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }

                                returNominal = returNominal - actualReturAmount;
                                gutil.saveSystemDebugLog(originModuleID, "returNominal [" + returNominal + "]");
                                rowCounter += 1;
                                gutil.saveSystemDebugLog(originModuleID, "rowCounter [" + rowCounter + "]");
                            }
                        }
                    }
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(originModuleID, "EXCEPTION THROWN [" + e.Message + "]");
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

                gutil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN_STOK, "RETURN CASH [" + returnCash.ToString() + "]");
            }

            gutil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "ATTEMPT TO SAVE DATA");
            if (saveData())
            {
                if (extraAmount > 0)
                {
                    MessageBox.Show("JUMLAH YANG DIKEMBALIKAN SEBESAR " + extraAmount.ToString("C", culture));
                    gutil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "extraAmount [" + extraAmount + "]");
                }

                gutil.saveUserChangeLog(globalConstants.MENU_RETUR_PENJUALAN, globalConstants.CHANGE_LOG_INSERT, "RETUR PENJUALAN [" + noReturTextBox.Text + "]");
                errorLabel.Text = "";
                gutil.showSuccess(gutil.INS);
                saveButton.Enabled = false;
                detailReturDataGridView.ReadOnly = true;
                noReturTextBox.Enabled = false;
                rsDateTimePicker.Enabled = false;
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
                invoiceTotalLabelValue.Text = getInvoiceTotalValue();
                loadDataHeader();
            }

            addDataGridColumn();

            isLoading = false;

            detailReturDataGridView.EditingControlShowing += detailReturDataGridView_EditingControlShowing;
            gutil.reArrangeTabOrder(this);
        }

        private void detailReturDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
    }
}

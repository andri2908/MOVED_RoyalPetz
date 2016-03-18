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
    public partial class penerimaanBarangForm : Form
    {
        string selectedInvoice;
        int originModuleId = 0;
        int selectedFromID = 0;
        int selectedToID = 0;
        double globalTotalValue = 0;
        bool isLoading = false;
        
        private List<string> detailRequestQty = new List<string>();
        private List<string> detailHpp = new List<string>();
        string previousInput = "";

        globalUtilities gUtil = new globalUtilities();
        Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        public penerimaanBarangForm()
        {
            InitializeComponent();
        }

        public penerimaanBarangForm(int moduleID, string pmInvoice)
        {
            InitializeComponent();

            originModuleId = moduleID;
            selectedInvoice = pmInvoice;
        }

        private void initializeScreen()
        {
            switch (originModuleId)
            {
                case globalConstants.PENERIMAAN_BARANG_DARI_MUTASI:
                    labelNo.Text = "NO MUTASI";
                    labelTanggal.Text = "TANGGAL MUTASI";
                    labelAsal.Text = "ASAL MUTASI";
                    labelTujuan.Text = "TUJUAN MUTASI";
                    break;

                case globalConstants.PENERIMAAN_BARANG_DARI_PO:
                    labelNo.Text = "NO PO";
                    labelTanggal.Text = "TANGGAL PO";
                    labelAsal.Text = "SUPPLIER";
                    //labelTujuan.Text = "TUJUAN MUTASI";
                    labelTujuan.Visible = false;
                    labelTujuan_1.Visible = false;
                    branchToTextBox.Visible = false;
                    break;
            }
        }

        private void loadDataHeader()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            switch (originModuleId)
            {
                case globalConstants.PENERIMAAN_BARANG_DARI_MUTASI:
                    sqlCommand = "SELECT * FROM PRODUCTS_MUTATION_HEADER WHERE PM_INVOICE = '" + selectedInvoice + "'";
                    using (rdr = DS.getData(sqlCommand))
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                noInvoiceTextBox.Text = rdr.GetString("PM_INVOICE");
                                invoiceDtPicker.Value = rdr.GetDateTime("PM_DATETIME");
                                selectedFromID = rdr.GetInt32("BRANCH_ID_FROM");
                                selectedToID = rdr.GetInt32("BRANCH_ID_TO");
                                labelTotalValue.Text = "Rp. " + rdr.GetString("PM_TOTAL");
                                labelAcceptValue.Text = "Rp. " + rdr.GetString("PM_TOTAL");

                                globalTotalValue = rdr.GetDouble("PM_TOTAL");
                            }
                        }
                    }
                    break;

                case globalConstants.PENERIMAAN_BARANG_DARI_PO:
                    sqlCommand = "SELECT * FROM PURCHASE_HEADER WHERE PURCHASE_INVOICE = '" + selectedInvoice + "'";
                    using (rdr = DS.getData(sqlCommand))
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                noInvoiceTextBox.Text = rdr.GetString("PURCHASE_INVOICE");
                                invoiceDtPicker.Value = rdr.GetDateTime("PURCHASE_DATETIME");
                                selectedFromID = rdr.GetInt32("SUPPLIER_ID");
                                //selectedToID = rdr.GetInt32("BRANCH_ID_TO");
                                labelTotalValue.Text = "Rp. " + rdr.GetString("PURCHASE_TOTAL");
                                labelAcceptValue.Text = "Rp. " + rdr.GetString("PURCHASE_TOTAL");

                                globalTotalValue = rdr.GetDouble("PURCHASE_TOTAL");
                            }
                        }
                    }
                    break;
            }
        }

        private void loadDataDetail()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            switch (originModuleId)
            {
                case globalConstants.PENERIMAAN_BARANG_DARI_MUTASI:
                    sqlCommand = "SELECT PM.*, M.PRODUCT_NAME FROM PRODUCTS_MUTATION_DETAIL PM, MASTER_PRODUCT M WHERE PM_INVOICE = '" + selectedInvoice + "' AND PM.PRODUCT_ID = M.PRODUCT_ID";
                    using (rdr = DS.getData(sqlCommand))
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                detailGridView.Rows.Add(rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PM_SUBTOTAL"), rdr.GetString("PRODUCT_ID"));

                                detailRequestQty.Add(rdr.GetString("PRODUCT_QTY"));
                                detailHpp.Add(rdr.GetString("PRODUCT_BASE_PRICE"));
                            }
                        }
                    }
                    break;

                case globalConstants.PENERIMAAN_BARANG_DARI_PO:
                    sqlCommand = "SELECT PO.*, M.PRODUCT_NAME FROM PURCHASE_DETAIL PO, MASTER_PRODUCT M WHERE PURCHASE_INVOICE = '" + selectedInvoice + "' AND PO.PRODUCT_ID = M.PRODUCT_ID";
                    using (rdr = DS.getData(sqlCommand))
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                detailGridView.Rows.Add(rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PRODUCT_PRICE"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PURCHASE_SUBTOTAL"), rdr.GetString("PRODUCT_ID"));

                                detailRequestQty.Add(rdr.GetString("PRODUCT_QTY"));
                                detailHpp.Add(rdr.GetString("PRODUCT_PRICE"));
                            }
                        }
                    }
                    break;
            }
        }

        private string getBranchName(int branchID)
        {
            string result = "";

            result = DS.getDataSingleValue("SELECT BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ID = " + branchID).ToString();

            return result;
        }

        private string getSupplierName(int suppID)
        {
            string result = "";

            result = DS.getDataSingleValue("SELECT SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ID = " + suppID).ToString();

            return result;
        }

        private void penerimaanBarangForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            PRDtPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            invoiceDtPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            initializeScreen();

            detailGridView.EditingControlShowing += detailGridView_EditingControlShowing;

            isLoading = true;
            
            loadDataHeader();
            loadDataDetail();

            if (originModuleId == globalConstants.PENERIMAAN_BARANG_DARI_MUTASI)
            { 
                branchFromTextBox.Text = getBranchName(selectedFromID);
                branchToTextBox.Text = getBranchName(selectedToID);
            }
            else
            {
                branchFromTextBox.Text = getSupplierName(selectedFromID);
            }

            isLoading = false;

            gUtil.reArrangeTabOrder(this);
        }

        private void detailGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailGridView.CurrentCell.ColumnIndex == 2 || detailGridView.CurrentCell.ColumnIndex == 3) && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;

            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailGridView.Rows[rowSelectedIndex];

            previousInput = "";
            if (detailRequestQty.Count < rowSelectedIndex + 1)
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    if (detailGridView.CurrentCell.ColumnIndex == 2 )
                        detailHpp.Add(dataGridViewTextBoxEditingControl.Text);
                    else
                        detailRequestQty.Add(dataGridViewTextBoxEditingControl.Text);
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
            else
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    if (detailGridView.CurrentCell.ColumnIndex == 2)
                        detailHpp[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                    else
                        detailRequestQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    if (detailGridView.CurrentCell.ColumnIndex == 2)
                        dataGridViewTextBoxEditingControl.Text = detailHpp[rowSelectedIndex];
                    else
                        dataGridViewTextBoxEditingControl.Text = detailRequestQty[rowSelectedIndex];
                }
            }

            try
            {
                if (detailGridView.CurrentCell.ColumnIndex == 2)
                {
                    //changes on hpp
                    hppValue = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);
                    productQty = Convert.ToDouble(selectedRow.Cells["qtyReceived"].Value);
                }
                else
                {
                    //changes on qty
                    productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);
                    hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
                }

                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subtotal"].Value = subTotal;

                calculateTotal();
            }
            catch (Exception ex)
            {
                //dataGridViewTextBoxEditingControl.Text = previousInput;
            }
        }

        private void calculateTotal()
        {
            double total = 0;
            for (int i =0;i<detailGridView.Rows.Count;i++)
            {
                total = total + Convert.ToDouble(detailGridView.Rows[i].Cells["subtotal"].Value);
            }

            globalTotalValue = total;
            labelAcceptValue.Text = "Rp. " + globalTotalValue;
        }

        private bool isNoPRExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM PRODUCTS_RECEIVED_HEADER WHERE PR_INVOICE = '" + prInvoiceTextBox.Text + "'")) > 0)
                result = true;

            return result;
        }

        private void prInvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isNoPRExist())
            {
                errorLabel.Text = "NO PENERIMAAN SUDAH ADA";
            }
            else
                errorLabel.Text = "";
        }

        private bool dataValidated()
        {
            return true;
        }

        private double getCurrentHpp(string productID)
        {
            double result = 0;

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT PRODUCT_BASE_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }
        
        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string PRInvoice = "";
            int branchIDFrom = 0;
            int branchIDTo = 0;
            string PRDateTime = "";
            double PRTotal = 0;
            double currentHPP = 0;
            double newHPP = 0;
            int priceChange = 0;

            string selectedDate = PRDtPicker.Value.ToShortDateString();
            PRDateTime = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));
            
            PRInvoice = prInvoiceTextBox.Text;
            branchIDFrom = selectedFromID;
            branchIDTo = selectedToID;
            PRTotal = globalTotalValue;
            
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                if (originModuleId == globalConstants.PENERIMAAN_BARANG_DARI_MUTASI)
                    sqlCommand = "INSERT INTO PRODUCTS_RECEIVED_HEADER (PR_INVOICE, PR_FROM, PR_TO, PR_DATE, PR_TOTAL, PM_INVOICE) " +
                                        "VALUES ('" + PRInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + PRDateTime + "', '%d-%m-%Y'), " + PRTotal + ", '" + noInvoiceTextBox.Text + "')";
                else
                    sqlCommand = "INSERT INTO PRODUCTS_RECEIVED_HEADER (PR_INVOICE, PR_FROM, PR_TO, PR_DATE, PR_TOTAL, PURCHASE_INVOICE) " +
                                        "VALUES ('" + PRInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + PRDateTime + "', '%d-%m-%Y'), " + PRTotal + ", '" + noInvoiceTextBox.Text + "')";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < detailGridView.Rows.Count; i++)
                {
                    if (null != detailGridView.Rows[i].Cells["productID"].Value)
                    {
                        currentHPP = getCurrentHpp(detailGridView.Rows[i].Cells["productID"].Value.ToString());
                        newHPP = Convert.ToDouble(detailGridView.Rows[i].Cells["hpp"].Value);

                        if (currentHPP > newHPP)
                            priceChange = -1;
                        else if (currentHPP == newHPP)
                            priceChange = 0;
                        else if (currentHPP < newHPP)
                            priceChange = 1;

                        sqlCommand = "INSERT INTO PRODUCTS_RECEIVED_DETAIL (PR_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, PRODUCT_QTY, PRODUCT_ACTUAL_QTY, PR_SUBTOTAL, PRODUCT_PRICE_CHANGE) VALUES " +
                                            "('" + PRInvoice + "', '" + detailGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + newHPP + ", " + Convert.ToDouble(detailGridView.Rows[i].Cells["qtyRequest"].Value) + ", " + Convert.ToDouble(detailGridView.Rows[i].Cells["qtyReceived"].Value) + ", " + Convert.ToDouble(detailGridView.Rows[i].Cells["subtotal"].Value) + ", " + priceChange + ")";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // UPDATE TO MASTER PRODUCT
                        sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_BASE_PRICE = " + newHPP + ", PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + Convert.ToDouble(detailGridView.Rows[i].Cells["qtyReceived"].Value) + " WHERE PRODUCT_ID = '" + detailGridView.Rows[i].Cells["productID"].Value.ToString() + "'";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }
                }

                // UPDATE PRODUCT MUTATION / PO TABLE

                if (originModuleId == globalConstants.PENERIMAAN_BARANG_DARI_MUTASI)
                {
                    sqlCommand = "UPDATE PRODUCTS_MUTATION_HEADER SET PM_RECEIVED = 1 WHERE PM_INVOICE = '" + noInvoiceTextBox.Text + "'";
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }
                else
                {
                    sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_RECEIVED = 1 WHERE PURCHASE_INVOICE = '" + noInvoiceTextBox.Text + "'";
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
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
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "INSERT"); 
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                saveButton.Visible = false;
                gUtil.showSuccess(gUtil.INS);
            }
        }
    }
}
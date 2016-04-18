﻿using System;
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
    public partial class purchaseOrderDetailForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();

        private bool isLoading = false;
        private double globalTotalValue = 0;
        private List<string> detailQty = new List<string>();
        private List<string> detailHpp = new List<string>();

        private CultureInfo culture = new CultureInfo("id-ID");
        string previousInput = "";

        int originModuleID = globalConstants.NEW_PURCHASE_ORDER;
        string selectedROInvoice = "";        
        private int selectedSupplierID = 0;
        private int selectedPOID = 0;
        private string selectedPOInvoice = "";

        public purchaseOrderDetailForm()
        {
            InitializeComponent();
        }

        public purchaseOrderDetailForm(int moduleID, string roInvoice)
        {
            InitializeComponent();
            originModuleID = moduleID;
            selectedROInvoice = roInvoice;
        }

        public purchaseOrderDetailForm(int moduleID, int poID)
        {
            InitializeComponent();
            originModuleID = moduleID;
            selectedPOID = poID;
        }

        private void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    supplierCombo.Items.Clear();
                    supplierHiddenCombo.Items.Clear();

                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("SUPPLIER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("SUPPLIER_ID"));
                    }
                }
            }
        }

        private bool isPOInvoiceExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM PURCHASE_HEADER WHERE PURCHASE_INVOICE = '"+ MySqlHelper.EscapeString(POinvoiceTextBox.Text)+"'")) > 0)
                result = true;

            return result;
        }

        private void addDataGridColumn()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewComboBoxColumn productIdCmb= new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn displaySubTotalColumn = new DataGridViewTextBoxColumn();

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY PRODUCT_NAME ASC";

            //productIDComboHidden.Items.Clear();
            //productNameComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIdCmb.Items.Add(rdr.GetString("PRODUCT_ID"));
                    //productIDComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
                    //productNameComboHidden.Items.Add(rdr.GetString("PRODUCT_NAME"));
                }
            }

            rdr.Close();

            productIdCmb.HeaderText = "KODE PRODUK";
            productIdCmb.Name = "productID";
            productIdCmb.Width = 200;
            productIdCmb.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(productIdCmb);

            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            productNameCmb.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(productNameCmb);

            basePriceColumn.HeaderText = "HARGA POKOK";
            basePriceColumn.Name = "HPP";
            basePriceColumn.Width = 200;
            basePriceColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(basePriceColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            stockQtyColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(stockQtyColumn);

            subTotalColumn.HeaderText = "SUBTOTAL";
            subTotalColumn.Name = "subTotal";
            subTotalColumn.Width = 200;
            subTotalColumn.ReadOnly = true;
            detailPODataGridView.Columns.Add(subTotalColumn);
            
        }

        private void detailPODataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailPODataGridView.CurrentCell.OwningColumn.Name == "productID" || detailPODataGridView.CurrentCell.OwningColumn.Name == "productName") && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if ((detailPODataGridView.CurrentCell.OwningColumn.Name == "HPP" || detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private double getHPPValue(string productID)
        {
            double result = 0;

            //DS.mySqlConnect();

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BASE_PRICE, 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i < detailPODataGridView.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = total.ToString("C2", culture);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;
            double productQty = 0;
            double subTotal = 0;

            if (isLoading)
                return;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;
            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

            DataGridViewComboBoxCell productIDComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productID"];
            DataGridViewComboBoxCell productNameComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productName"];

            if (selectedIndex < 0)
                return;

            selectedProductID = productIDComboCell.Items[selectedIndex].ToString();
            productIDComboCell.Value = productIDComboCell.Items[selectedIndex];
            productNameComboCell.Value = productNameComboCell.Items[selectedIndex];

            hpp = getHPPValue(selectedProductID);

            //selectedRow.Cells["hpp"].Value = hpp.ToString("C", culture);
            selectedRow.Cells["hpp"].Value = hpp.ToString();
            detailHpp[rowSelectedIndex] = hpp.ToString();

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            if (null != selectedRow.Cells["qty"].Value)
            {
                productQty = Convert.ToDouble(selectedRow.Cells["qty"].Value);
                subTotal = Math.Round((hpp * productQty), 2);

                selectedRow.Cells["subTotal"].Value = subTotal;
            }

            calculateTotal();
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

            rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

            if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                previousInput = detailQty[rowSelectedIndex];
            else
                previousInput = detailHpp[rowSelectedIndex];

            if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                && (dataGridViewTextBoxEditingControl.Text.Length > 0))
            {
                if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                {
                    detailQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    detailHpp[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
            }
            else
            {
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            hppValue = Convert.ToDouble(detailHpp[rowSelectedIndex]);
            productQty = Convert.ToDouble(detailQty[rowSelectedIndex]);
            subTotal = Math.Round((hppValue * productQty), 2);

            selectedRow.Cells["subtotal"].Value = subTotal;

            calculateTotal();

            //previousInput = "0";
            //if (detailQty.Count < rowSelectedIndex + 1)
            //{
            //    if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
            //        && (dataGridViewTextBoxEditingControl.Text.Length > 0))
            //    {
            //        if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
            //        {
            //            detailQty.Add(dataGridViewTextBoxEditingControl.Text);
            //            detailHpp.Add(selectedRow.Cells["hpp"].Value.ToString());
            //        }
            //        else
            //        { 
            //            detailHpp.Add(dataGridViewTextBoxEditingControl.Text);
            //            detailQty.Add(selectedRow.Cells["qty"].Value.ToString());
            //        }
            //    }
            //    else
            //    {
            //        dataGridViewTextBoxEditingControl.Text = previousInput;
            //    }
            //}
            //else
            //{
            //    if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
            //        && (dataGridViewTextBoxEditingControl.Text.Length > 0))
            //    {
            //        if (detailPODataGridView.CurrentCell.OwningColumn.Name == "hpp")
            //            detailHpp[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //        else
            //            detailQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //    }
            //    else
            //    {
            //        if (detailPODataGridView.CurrentCell.OwningColumn.Name == "hpp")
            //            dataGridViewTextBoxEditingControl.Text = detailHpp[rowSelectedIndex];
            //        else
            //            dataGridViewTextBoxEditingControl.Text = detailQty[rowSelectedIndex];
            //    }
            //}

            //try
            //{
            //    if (detailPODataGridView.CurrentCell.OwningColumn.Name == "hpp")
            //    {
            //        //changes on hpp
            //        hppValue = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);
            //        productQty = Convert.ToDouble(selectedRow.Cells["qty"].Value);
            //    }
            //    else
            //    {
            //        //changes on qty
            //        productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);
            //        hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
            //    }

            //    subTotal = Math.Round((hppValue * productQty), 2);

            //    selectedRow.Cells["subtotal"].Value = subTotal;

            //    calculateTotal();
            //}
            //catch (Exception ex)
            //{
            //    //dataGridViewTextBoxEditingControl.Text = previousInput;
            //}
        }

        private bool isPOSent()
        {
            bool result = false;

            if (1 == Convert.ToInt32(DS.getDataSingleValue("SELECT PURCHASE_SENT FROM PURCHASE_HEADER WHERE ID = " + selectedPOID)))
                result = true;

            return result;
        }

        private void purchaseOrderDetailForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            errorLabel.Text = "";
            durationTextBox.Enabled = false;

            fillInSupplierCombo();
            PODateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            addDataGridColumn();
            termOfPaymentCombo.SelectedIndex = 0;

            isLoading = true;

            loadDataHeader();
            loadDataDetail();

            isLoading = false;

            if (originModuleID != globalConstants.NEW_PURCHASE_ORDER && originModuleID!= globalConstants.PURCHASE_ORDER_DARI_RO)
            { 
                POinvoiceTextBox.ReadOnly = true;

                if (isPOSent())
                {
                    saveButton.Visible = false;
                    PODateTimePicker.Enabled = false;
                    supplierCombo.Enabled = false;
                    termOfPaymentCombo.Enabled = false;
                    durationTextBox.ReadOnly = true;
                    detailPODataGridView.ReadOnly = true;
                    detailPODataGridView.AllowUserToAddRows = false;
                }

            }
            else
            {
                // NEW PO
                generateButton.Visible = false;
            }

            detailPODataGridView.EditingControlShowing += detailPODataGridView_EditingControlShowing;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PURCHASE_ORDER, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_PURCHASE_ORDER || originModuleID == globalConstants.PURCHASE_ORDER_DARI_RO)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_PURCHASE_ORDER)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            gUtil.reArrangeTabOrder(this);
        }

        private void POinvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (isPOInvoiceExist())
            {
                errorLabel.Text = "NO PO SUDAH ADA";
            }
            else
            {
                errorLabel.Text = "";
            }
        }

        private bool dataValidated()
        {
            bool dataExist = false;
            if (POinvoiceTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO PURCHASE TIDAK BOLEH KOSONG";
                return false;
            }

            if (globalTotalValue <= 0)
            {
                errorLabel.Text = "NILAI PURCHASE KOSONG";
                return false;
            }

            for (int i = 0; i < detailPODataGridView.Rows.Count && !dataExist; i++)
                if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                    dataExist = true;

            if (!dataExist)
            {
                errorLabel.Text = "TIDAK ADA PRODUK YANG DIPILIH";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string POInvoice = "0";
            string roInvoice = "";
            int supplierID = 0;
            string PODateTime = "";
            //string PODueDateTime = "";
            double POTotal = 0;
            int termOfPaymentDuration = 0;
            int termOfPayment;
            int purchasePaid = 0;
            DateTime selectedPODate;
            //DateTime PODueDate;
            MySqlException internalEX = null;

            roInvoice = selectedROInvoice; //ROInvoiceTextBox.Text;
            POInvoice = POinvoiceTextBox.Text;
            supplierID = selectedSupplierID;

            selectedPODate = PODateTimePicker.Value;
            PODateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPODate);

            termOfPayment = termOfPaymentCombo.SelectedIndex;
            termOfPaymentDuration = Convert.ToInt32(durationTextBox.Text);
            //PODueDate = selectedPODate.AddDays(termOfPaymentDuration);
            //PODueDateTime = String.Format(culture, "{0:dd-MM-yyyy}", PODueDate);

            if (termOfPayment == 0)
                purchasePaid = 1;

            POTotal = globalTotalValue;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.PURCHASE_ORDER_DARI_RO:
                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO PURCHASE_HEADER (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                            "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", '" + purchasePaid + ")";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count - 1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            { 
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }

                        // UPDATE REQUEST ORDER TABLE
                        sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        //if (termOfPaymentCombo.SelectedIndex == 1)
                        //{
                        //    // SAVE TO DEBT TABLE
                        //    sqlCommand = "INSERT INTO DEBT (PURCHASE_INVOICE, DEBT_DUE_DATE, DEBT_NOMINAL, DEBT_PAID) VALUES ('" + POInvoice + "', STR_TO_DATE('" + PODueDateTime + "', '%d-%m-%Y'), " + POTotal + ", 0)";
                        //    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        //        throw internalEX;
                        //}

                        break;

                    case globalConstants.NEW_PURCHASE_ORDER:
                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO PURCHASE_HEADER (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                            "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", " + purchasePaid + ")";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count - 1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }

                        //if (termOfPaymentCombo.SelectedIndex == 1)
                        //{
                        //    // SAVE TO DEBT TABLE
                        //    sqlCommand = "INSERT INTO DEBT (PURCHASE_INVOICE, DEBT_DUE_DATE, DEBT_NOMINAL, DEBT_PAID) VALUES ('" + POInvoice + "', STR_TO_DATE('" + PODueDateTime + "', '%d-%m-%Y'), " + POTotal + ", 0)";
                        //    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        //        throw internalEX;
                        //}

                        break;

                    case globalConstants.EDIT_PURCHASE_ORDER:
                        // SAVE HEADER TABLE
                        sqlCommand = "UPDATE PURCHASE_HEADER " +
                                            "SET SUPPLIER_ID = " + supplierID + ", " +
                                            "PURCHASE_DATETIME = STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " +
                                            "PURCHASE_TOTAL = " + gUtil.validateDecimalNumericInput(POTotal) + ", " +
                                            "PURCHASE_TERM_OF_PAYMENT = " + termOfPayment + ", " + 
                                            "PURCHASE_TERM_OF_PAYMENT_DURATION = " + termOfPaymentDuration + ", " +
                                            "PURCHASE_PAID = " + purchasePaid +" " +
                                            "WHERE PURCHASE_INVOICE = '" +POInvoice+ "'";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // DELETE DETAIL TABLE
                        sqlCommand = "DELETE FROM PURCHASE_DETAIL WHERE PURCHASE_INVOICE = '" + POInvoice + "'";
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // RE-INSERT DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count - 1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }

                        ////DELETE DEBT TABLE
                        //sqlCommand = "DELETE FROM DEBT WHERE PURCHASE_INVOICE = '" + POInvoice + "'";

                        //if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        //    throw internalEX;

                        //if (termOfPaymentCombo.SelectedIndex == 1)
                        //{
                        //    // UPDATE DEBT TABLE
                        //    sqlCommand = "UPDATE DEBT " +
                        //                        "SET DEBT_DUE_DATE = STR_TO_DATE('" + PODueDateTime + "', '%d-%m-%Y'), " +
                        //                        "DEBT_NOMINAL = " + POTotal + " " +
                        //                        "WHERE PURCHASE_INVOICE = '" + POInvoice + "'";

                        //    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        //        throw internalEX;
                        //}

                        break;

                    case globalConstants.PRINTOUT_PURCHASE_ORDER:
                        // UPDATE PURCHASE ORDER TABLE
                        sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_SENT = 1 WHERE PURCHASE_INVOICE = '" + POInvoice + "'";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;                        
                        break;
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
                errorLabel.Text = "";
                generateButton.Visible = true;

                saveButton.Visible = false;
                PODateTimePicker.Enabled = false;
                supplierCombo.Enabled = false;
                termOfPaymentCombo.Enabled = false;
                durationTextBox.ReadOnly = true;
                detailPODataGridView.ReadOnly = true;
                detailPODataGridView.AllowUserToAddRows = false;

                gUtil.showSuccess(gUtil.INS);
            }
        }

        private void loadDataPOHeader()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            
            sqlCommand = "SELECT ID, PURCHASE_INVOICE, PURCHASE_DATETIME, " +
                                "PURCHASE_TERM_OF_PAYMENT, " +
                                "PURCHASE_TERM_OF_PAYMENT_DURATION, " +
                                "M.SUPPLIER_FULL_NAME, PURCHASE_TOTAL " + //IFNULL(RO_INVOICE,'') AS RO_INVOICE " +
                                "FROM PURCHASE_HEADER P, MASTER_SUPPLIER M " +
                                "WHERE P.SUPPLIER_ID = M.SUPPLIER_ID AND P.ID = " + selectedPOID;

            using (rdr=DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        POinvoiceTextBox.Text = rdr.GetString("PURCHASE_INVOICE");
                        PODateTimePicker.Value = rdr.GetDateTime("PURCHASE_DATETIME");

                        //ROInvoiceTextBox.Text = rdr.GetString("RO_INVOICE");
                        
                        supplierCombo.Text = rdr.GetString("SUPPLIER_FULL_NAME");
                        termOfPaymentCombo.SelectedIndex = rdr.GetInt32("PURCHASE_TERM_OF_PAYMENT");
                        durationTextBox.Text = rdr.GetString("PURCHASE_TERM_OF_PAYMENT_DURATION");//Convert.ToInt32((rdr.GetDateTime("PURCHASE_TERM_OF_PAYMENT_DATE") - rdr.GetDateTime("PURCHASE_DATETIME")).TotalDays).ToString();
                        totalLabel.Text = rdr.GetString("PURCHASE_TOTAL");
                        globalTotalValue = rdr.GetDouble("PURCHASE_TOTAL");

                        if (rdr.GetInt32("PURCHASE_TERM_OF_PAYMENT") == 1)
                            durationTextBox.Enabled = true;
                    }
                }
            }
        }

        private void loadDataHeader()
        {
            switch (originModuleID)
            {
                case globalConstants.PURCHASE_ORDER_DARI_RO:
        //            ROInvoiceTextBox.Text = selectedROInvoice;
                    break;

                case globalConstants.EDIT_PURCHASE_ORDER:
                    loadDataPOHeader();
                    break;
            }
        }

        private void loadDataRODetail()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT RO.*, M.PRODUCT_NAME FROM REQUEST_ORDER_DETAIL RO, MASTER_PRODUCT M WHERE RO_INVOICE = '" + selectedROInvoice + "' AND RO.PRODUCT_ID = M.PRODUCT_ID";
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while(rdr.Read())
                    {
                        detailPODataGridView.Rows.Add(rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("RO_QTY"), rdr.GetString("RO_SUBTOTAL"));
                    }

                    calculateTotal();
                }
            }

        }

        private void loadDataPODetail()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT PO.*, M.PRODUCT_NAME FROM PURCHASE_DETAIL PO, MASTER_PRODUCT M WHERE PURCHASE_INVOICE = '" + POinvoiceTextBox.Text + "' AND PO.PRODUCT_ID = M.PRODUCT_ID";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        detailPODataGridView.Rows.Add(rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_PRICE"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PURCHASE_SUBTOTAL"));
                    }

                    calculateTotal();
                }
            }
        }

        private void loadDataDetail()
        {
            switch (originModuleID)
            {
                case globalConstants.PURCHASE_ORDER_DARI_RO:
                    loadDataRODetail();
                    break;

                case globalConstants.EDIT_PURCHASE_ORDER:
                    loadDataPODetail();
                    break;
            }
        }

        private void deleteCurrentRow()
        {
            if (detailPODataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

                detailPODataGridView.Rows.Remove(selectedRow);
            }
        }

        private void detailPODataGridView_KeyDown(object sender, KeyEventArgs e)
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

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSupplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex]);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            originModuleID = globalConstants.PRINTOUT_PURCHASE_ORDER;

            if (saveData())
            {
                saveButton.Visible = false;
                POinvoiceTextBox.ReadOnly = true;
                PODateTimePicker.Enabled = false;
                supplierCombo.Enabled = false;
                termOfPaymentCombo.Enabled = false;
                durationTextBox.ReadOnly = true;
                detailPODataGridView.ReadOnly = true;
                detailPODataGridView.AllowUserToAddRows = false;

                gUtil.showSuccess(gUtil.INS);
            }
        }

        private void supplierCombo_Validated(object sender, EventArgs e)
        {
            if (!supplierCombo.Items.Contains(supplierCombo.Text))
                supplierCombo.Focus();
        }

        private void termOfPaymentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (termOfPaymentCombo.SelectedIndex == 0)
                durationTextBox.Enabled = false;
            else
                durationTextBox.Enabled = true;
        }

        private void detailPODataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            detailQty.Add("0");
            detailHpp.Add("0");
        }
    }
}

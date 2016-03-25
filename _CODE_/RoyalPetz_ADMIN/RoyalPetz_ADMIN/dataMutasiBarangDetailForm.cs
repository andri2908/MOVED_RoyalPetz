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
    public partial class dataMutasiBarangDetailForm : Form
    {
        private int originModuleID = 0;
        private int subModuleID = 0;
        private int selectedROID = 0;
        private string selectedPMInvoice = "";
        private int selectedBranchFromID = 0;
        private int selectedBranchToID = 0;
        private string selectedROInvoice = "";
        private bool isLoading = false;
        private double globalTotalValue = 0;
        private bool directMutasiBarang = false;
        private string previousInput = "";

        private Data_Access DS = new Data_Access();
        private List<string> detailRequestQtyApproved = new List<string>();

        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public dataMutasiBarangDetailForm()
        {
            InitializeComponent();
        }

        public void inisialisasiInterface()
        {
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                    //reprintButton.Visible = false;
                    break;

                case globalConstants.REPRINT_PERMINTAAN_BARANG:
                    approveButton.Visible = false;
                    createPOButton.Visible = false;
                    detailRequestOrderDataGridView.ReadOnly = true;
                    break;

                case globalConstants.MUTASI_BARANG:
                    approveButton.Text = "SAVE MUTASI";
                    //reprintButton.Text = "REPRINT DATA MUTASI";
                    createPOButton.Visible = false;

                    directMutasiBarang = true;
                    break;

                case globalConstants.VIEW_PRODUCT_MUTATION:
                    approveButton.Visible = false;
                    createPOButton.Visible = false;
                    //reprintButton.Text = "REPRINT DATA MUTASI";
                    detailRequestOrderDataGridView.ReadOnly = true;
                    break;
            }           
        }

        public dataMutasiBarangDetailForm(int moduleID, int roID = 0)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedROID = roID;

            inisialisasiInterface();            
        }

        public dataMutasiBarangDetailForm(int moduleID, string PMInvoice)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedPMInvoice = PMInvoice;

            inisialisasiInterface();
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;

            if (!directMutasiBarang)
                totalApproved.Text = total.ToString("C", culture);
            else
                totalLabel.Text = total.ToString("C", culture);
        }

        private bool stockIsEnough(string productID, double qtyRequested)
        {
            bool result = false;
            double stockQty = 0;

            stockQty = Convert.ToDouble(DS.getDataSingleValue("SELECT (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            if (stockQty >= qtyRequested)
                result = true;

            return result;
        }

        private void detailRequestOrderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int qtyPosition;

            if (!directMutasiBarang)
                qtyPosition = 2;
            else
                qtyPosition = 1;

            if (detailRequestOrderDataGridView.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if (detailRequestOrderDataGridView.CurrentCell.ColumnIndex == qtyPosition && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private double getHPP(string productID)
        {
            double result = 0;

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT PRODUCT_BASE_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ID = '"+productID+"'"));
            return result;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;
            int cmbSelectedIndex = 0;
            string productID = "";

            if (isLoading)
                return;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;

            rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];
            cmbSelectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;

            // get product id
            productID = productIDHiddenCombo.Items[cmbSelectedIndex].ToString();
            selectedRow.Cells["productID"].Value = productID;

            // get hpp
            hppValue = getHPP(productID);
            selectedRow.Cells["hpp"].Value = hppValue;
            
            productQty = Convert.ToDouble(selectedRow.Cells["qty"].Value);
            hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
            subTotal = Math.Round((hppValue * productQty), 2);

            selectedRow.Cells["subTotal"].Value = subTotal;

            calculateTotal();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;
            bool validInput = false;

            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

            // Condition to check
            // - empty string
            // - non numeric input
            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // reset subTotal Value and recalculate total
                selectedRow.Cells["subTotal"].Value = 0;
                calculateTotal();

                return;
            }

            // get value for previous input
            if (detailRequestQtyApproved.Count >= rowSelectedIndex + 1)
            {
                previousInput = detailRequestQtyApproved[rowSelectedIndex];
            }

            if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
            {
                // if input match RegEx
                try
                {
                    productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);

                    // check if there's a product ID for that particular row
                    if (null != selectedRow.Cells["productID"].Value)
                        if (stockIsEnough(selectedRow.Cells["productID"].Value.ToString(), productQty))
                            validInput = true;

                    // input match RegEx, and Stock is enough
                    if (validInput)
                    {
                        errorLabel.Text = "";
                        // check whether it's a new row or not
                        if (detailRequestQtyApproved.Count < rowSelectedIndex + 1)
                            detailRequestQtyApproved.Add(dataGridViewTextBoxEditingControl.Text); // NEW ROW
                        else
                            detailRequestQtyApproved[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text; // EXISTING ROW

                        previousInput = dataGridViewTextBoxEditingControl.Text;

                        hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
                        subTotal = Math.Round((hppValue * productQty), 2);

                        selectedRow.Cells["subTotal"].Value = subTotal;

                        calculateTotal();
                    }
                    else
                    {
                        // if stock is not enough
                        dataGridViewTextBoxEditingControl.Text = previousInput;
                        errorLabel.Text = "JUMLAH STOK TIDAK MENCUKUPI";
                    }
                }
                catch (Exception ex)
                {
                    dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
            else
            {
                // if input doesn't match RegEx
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }
        }

        private void loadDataHeaderRO()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT * FROM REQUEST_ORDER_HEADER WHERE ID = " + selectedROID;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ROInvoiceTextBox.Text = rdr.GetString("RO_INVOICE");
                        RODateTimePicker.Value = rdr.GetDateTime("RO_DATETIME");
                        ROExpiredDateTimePicker.Value = rdr.GetDateTime("RO_EXPIRED");
                        selectedBranchFromID = rdr.GetInt32("RO_BRANCH_ID_FROM");
                        selectedBranchToID = rdr.GetInt32("RO_BRANCH_ID_TO");

                        selectedROInvoice = rdr.GetString("RO_INVOICE");

                        totalLabel.Text = rdr.GetDouble("RO_TOTAL").ToString("C", culture);
                        totalApproved.Text = rdr.GetDouble("RO_TOTAL").ToString("C", culture);
                        globalTotalValue = rdr.GetDouble("RO_TOTAL");
                    }

                    rdr.Close();
                }
            }
        }

       private void loadDataHeaderPM()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT * FROM PRODUCTS_MUTATION_HEADER WHERE PM_INVOICE = '" + selectedPMInvoice + "'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        noMutasiTextBox.Text = rdr.GetString("PM_INVOICE");
                        PMDateTimePicker.Value = rdr.GetDateTime("PM_DATETIME");
                        ROInvoiceTextBox.Text = rdr.GetString("RO_INVOICE");
                        selectedBranchFromID = rdr.GetInt32("BRANCH_ID_FROM");
                        selectedBranchToID = rdr.GetInt32("BRANCH_ID_TO");

                        selectedROInvoice = rdr.GetString("RO_INVOICE");

                        totalLabel.Text = rdr.GetDouble("PM_TOTAL").ToString("C", culture);
                        totalApproved.Text = rdr.GetDouble("PM_TOTAL").ToString("C", culture);
                        globalTotalValue = rdr.GetDouble("PM_TOTAL");
                    }

                    rdr.Close();
                }
            }
        }

        private void loadDataDetail()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";
            string productName = "";
            double qtyApproved;
            double productQty;
            double subTotal;
            double hpp;

            if (subModuleID == globalConstants.NEW_PRODUCT_MUTATION)
                // load all data from request order
                sqlCommand = "SELECT R.*, M.PRODUCT_NAME, (M.PRODUCT_STOCK_QTY - M.PRODUCT_LIMIT_STOCK) AS PRODUCT_QTY FROM REQUEST_ORDER_DETAIL R, MASTER_PRODUCT M WHERE R.RO_INVOICE = '" + selectedROInvoice + "' AND R.PRODUCT_ID = M.PRODUCT_ID";
            else
                // load all data from product mutation 
                sqlCommand = "SELECT PM.*, M.PRODUCT_NAME FROM PRODUCTS_MUTATION_DETAIL PM, MASTER_PRODUCT M WHERE PM.PM_INVOICE = '" + noMutasiTextBox.Text + "' AND PM.PRODUCT_ID = M.PRODUCT_ID";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productName = rdr.GetString("PRODUCT_NAME");
                    if (subModuleID == globalConstants.NEW_PRODUCT_MUTATION)
                    {
                        qtyApproved = rdr.GetDouble("RO_QTY");
                        productQty = rdr.GetDouble("PRODUCT_QTY");
                        hpp = rdr.GetDouble("PRODUCT_BASE_PRICE");

                        if (productQty < 0)
                            productQty = 0;

                        if ((productQty < qtyApproved) && (productQty >= 0))
                            qtyApproved = productQty;


                        subTotal = Math.Round((hpp*qtyApproved),2);

                        detailRequestOrderDataGridView.Rows.Add(productName, rdr.GetString("RO_QTY"), qtyApproved.ToString(), hpp.ToString(), subTotal.ToString(), rdr.GetString("PRODUCT_ID"));
                        detailRequestQtyApproved.Add(qtyApproved.ToString());
                    }
                    else
                    {
                        detailRequestOrderDataGridView.Rows.Add(productName, "0", rdr.GetString("PRODUCT_QTY"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("PM_SUBTOTAL"), rdr.GetString("PRODUCT_ID"));
                        detailRequestQtyApproved.Add(rdr.GetString("PRODUCT_QTY"));
                    }
                }

                rdr.Close();

                calculateTotal();
            }
        }

        private string getBranchName(int branchID)
        {
            MySqlDataReader rdr;
            string result = "";

            using (rdr = DS.getData("SELECT BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ID = " + branchID))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    result = rdr.GetString("BRANCH_NAME");
                }
            }

            return result;
        }

        private bool isNewRORequest()
        {
            bool result = false;

            if (1 == Convert.ToInt32(DS.getDataSingleValue("SELECT RO_ACTIVE FROM REQUEST_ORDER_HEADER WHERE RO_INVOICE = '" + selectedROInvoice + "'")))
                result = true;

            return result;
        }

        private string getNoMutasi()
        {
            MySqlDataReader rdr;
            string retVal = "";

            using (rdr = DS.getData("SELECT PM_INVOICE FROM PRODUCTS_MUTATION_HEADER WHERE RO_INVOICE = '" + selectedROInvoice + "'"))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    retVal = rdr.GetString("PM_INVOICE");
                }
            }

            return retVal;
        }

        private DateTime getPMDateTimeValue()
        {
            MySqlDataReader rdr;
            DateTime result;

            using (rdr = DS.getData("SELECT PM_DATETIME FROM PRODUCTS_MUTATION_HEADER WHERE RO_INVOICE = '" + selectedROInvoice + "'"))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    result = rdr.GetDateTime("PM_DATETIME");
                }
                else
                    result = DateTime.Now;
            }
            
            
            return result;
        }

        private void fillInBranchCombo(ComboBox comboToFill, ComboBox hiddenComboToFill)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    comboToFill.Items.Clear();
                    comboToFill.Text = "";

                    hiddenComboToFill.Items.Clear();
                    hiddenComboToFill.Text = "";
                    while (rdr.Read())
                    {
                        hiddenComboToFill.Items.Add(rdr.GetString("BRANCH_ID"));
                        comboToFill.Items.Add(rdr.GetString("BRANCH_NAME"));
                    }

                    rdr.Close();
                }
            }
        }

        private void addDataToProductNameCombo(DataGridViewComboBoxColumn comboColumn)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY PRODUCT_NAME ASC";

            productIDHiddenCombo.Items.Clear();
            comboColumn.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    comboColumn.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIDHiddenCombo.Items.Add(rdr.GetString("PRODUCT_ID"));
                }
            }

            rdr.Close();

        }

        private void addColumnToDetailDataGrid()
        {
            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn qtyReqColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn hppColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productIDColumn = new DataGridViewTextBoxColumn();

            DataGridViewComboBoxColumn productNameComboColumn = new DataGridViewComboBoxColumn();

            if (!directMutasiBarang)
            {
                productNameColumn.Name = "productName";
                productNameColumn.HeaderText = "NAMA PRODUK";
                productNameColumn.ReadOnly = true;
                productNameColumn.Width = 300;
                detailRequestOrderDataGridView.Columns.Add(productNameColumn);

                qtyReqColumn.Name = "qtyRequest";
                qtyReqColumn.HeaderText = "QTY REQ";
                qtyReqColumn.ReadOnly = true;
                qtyReqColumn.Width = 150;
                detailRequestOrderDataGridView.Columns.Add(qtyReqColumn);
            }
            else
            {
                productNameComboColumn.Name = "productName";
                productNameComboColumn.HeaderText = "NAMA PRODUK";
                productNameComboColumn.Width = 300;
                addDataToProductNameCombo(productNameComboColumn);

                detailRequestOrderDataGridView.Columns.Add(productNameComboColumn);
            }

            qtyColumn.Name = "qty";
            qtyColumn.HeaderText = "QTY";
            qtyColumn.Width = 150;
            detailRequestOrderDataGridView.Columns.Add(qtyColumn);

            hppColumn.Name = "hpp";
            hppColumn.HeaderText = "HARGA POKOK";
            hppColumn.Width = 200;
            hppColumn.ReadOnly = true;
            detailRequestOrderDataGridView.Columns.Add(hppColumn);

            subtotalColumn.Name = "subtotal";
            subtotalColumn.HeaderText = "SUBTOTAL";
            subtotalColumn.Width = 200;
            subtotalColumn.ReadOnly = true;
            detailRequestOrderDataGridView.Columns.Add(subtotalColumn);

            productIDColumn.Name = "productID";
            productIDColumn.HeaderText = "productID";
            productIDColumn.Width = 100;
            productIDColumn.Visible = false;
            detailRequestOrderDataGridView.Columns.Add(productIDColumn);
        }

        private bool roInvoiceAvailable()
        {
            bool result = false;
            object resultQuery;

            resultQuery = DS.getDataSingleValue("SELECT RO_INVOICE FROM PRODUCTS_MUTATION_HEADER WHERE PM_INVOICE = '" + selectedPMInvoice + "'");

            if (null != resultQuery)
            {
                result = true;
            }
            return result;
        }

        private void dataMutasiBarangDetailForm_Load(object sender, EventArgs e)
        {
            PMDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            RODateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            ROExpiredDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            isLoading = true;

            addColumnToDetailDataGrid();

            if (!directMutasiBarang)
            {
                if (originModuleID == globalConstants.VIEW_PRODUCT_MUTATION)
                    loadDataHeaderPM();
                else
                    loadDataHeaderRO();

                if (originModuleID != globalConstants.VIEW_PRODUCT_MUTATION && isNewRORequest())
                {
                    subModuleID = globalConstants.NEW_PRODUCT_MUTATION;

                    approveButton.Visible = true;
                    createPOButton.Visible = true;
                    //reprintButton.Visible = false;

                    noMutasiTextBox.Focus();
                }
                else
                {
                    detailRequestOrderDataGridView.Columns["qtyRequest"].Visible = false;

                    noMutasiTextBox.ReadOnly = true;
                    PMDateTimePicker.Enabled = false;

                    if (originModuleID != globalConstants.VIEW_PRODUCT_MUTATION)
                    {
                        noMutasiTextBox.Text = getNoMutasi();
                        PMDateTimePicker.Value = getPMDateTimeValue();
                    }

                    detailRequestOrderDataGridView.ReadOnly = true;

                    approveButton.Visible = false;
                    createPOButton.Visible = false;
                    //reprintButton.Visible = true;

                    label1.Visible = false;
                    label14.Visible = false;
                    ROInvoiceTextBox.Visible = false;

                    label9.Visible = false;
                    label6.Visible = false;
                    RODateTimePicker.Visible = false;

                    label7.Visible = false;
                    label5.Visible = false;
                    ROExpiredDateTimePicker.Visible = false;

                    totalApproved.Visible = false;
                    totalApprovedLabel.Visible = false;
                    label13.Visible = false;
                }

                branchFromCombo.Text = getBranchName(selectedBranchFromID);
                branchToCombo.Text = getBranchName(selectedBranchToID);
                branchFromCombo.Enabled = false;
                branchToCombo.Enabled = false;

                loadDataDetail();
            }
            else
            {
                subModuleID = globalConstants.NEW_PRODUCT_MUTATION;

                branchFromCombo.Enabled = true;
                branchToCombo.Enabled = true;

                fillInBranchCombo(branchFromCombo, branchFromComboHidden);
                fillInBranchCombo(branchToCombo, branchToComboHidden);


                detailRequestOrderDataGridView.AllowUserToAddRows = true;

            }

            isLoading = false;

            detailRequestOrderDataGridView.EditingControlShowing += detailRequestOrderDataGridView_EditingControlShowing;

            gUtil.reArrangeTabOrder(this);
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string roInvoice = "0";
            string noMutasi = "";
            int branchIDFrom = 0;
            int branchIDTo = 0;
            string PMDateTime = "";
            double PMTotal = 0;
            double qtyApproved = 0;
            DateTime selectedPMDate;
            
            roInvoice = ROInvoiceTextBox.Text;
            
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (subModuleID)
                {
                    case globalConstants.NEW_PRODUCT_MUTATION:
                        // GET THE DATA
                        noMutasi = noMutasiTextBox.Text;
                        branchIDFrom = selectedBranchFromID;
                        branchIDTo = selectedBranchToID;
                        selectedPMDate = PMDateTimePicker.Value;
                        PMDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPMDate);
                        PMTotal = globalTotalValue;

                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO PRODUCTS_MUTATION_HEADER (PM_INVOICE, BRANCH_ID_FROM, BRANCH_ID_TO, PM_DATETIME, PM_TOTAL, RO_INVOICE) VALUES " +
                                            "('" + noMutasi + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + PMDateTime + "', '%d-%m-%Y'), " + PMTotal + ", '" + roInvoice + "')";
                        DS.executeNonQueryCommand(sqlCommand);

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count - 1; i++)
                        {
                            if (null == detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                                continue;

                            if (null != detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value)
                                qtyApproved = Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value);
                            else
                                qtyApproved = 0;

                            sqlCommand = "INSERT INTO PRODUCTS_MUTATION_DETAIL (PM_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, PRODUCT_QTY, PM_SUBTOTAL) VALUES " +
                                                "('" + noMutasi + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + qtyApproved + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        if (!directMutasiBarang)
                        { 
                            // UPDATE REQUEST ORDER HEADER TABLE
                            sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        // INSERT CREDIT TABLE FOR THAT PARTICULAR BRANCH
                        sqlCommand = "INSERT INTO CREDIT (PM_INVOICE, CREDIT_DUE_DATE, CREDIT_NOMINAL, CREDIT_PAID) VALUES " +
                                            "('" + noMutasi + "', STR_TO_DATE('" + PMDateTime + "', '%d-%m-%Y'), " + PMTotal + ", 0)"; 
                    
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        
                        break;

                    //case globalConstants.REJECT_PRODUCT_MUTATION:
                    //    // UPDATE REQUEST ORDER HEADER TABLE
                    //    sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";
                    //    DS.executeNonQueryCommand(sqlCommand);
                    //    break;
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
                       gUtil.showDBOPError(ex, "ROLLBACK");
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

        private bool dataValidated()
        {
            bool dataExist = false;
            int i = 0;

            if (subModuleID == globalConstants.REJECT_PRODUCT_MUTATION)
                return true;

            if (noMutasiTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO MUTASI TIDAK BOLEH KOSONG";
                return false;
            }

            while ( i < detailRequestOrderDataGridView.Rows.Count)
            { 
                if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                { 
                    dataExist = true;
                    break;
                }

                i++;
            }

            if (!dataExist)
            {
                errorLabel.Text = "TIDAK ADA PRODUK YANG DIPILIH";
                return false;
            }

            return true;
        }

        private bool saveData()
        {
            if (dataValidated())
                return saveDataTransaction();

            return false;
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                //MessageBox.Show("SUCCESS");
                gUtil.showSuccess(gUtil.INS);

                detailRequestOrderDataGridView.ReadOnly = true;

                noMutasiTextBox.ReadOnly = true;
                PMDateTimePicker.Enabled = false;
                approveButton.Visible = false;
                createPOButton.Visible = false;

                //reprintButton.Visible = true;
            }
        }

        private bool noMutasiExist()
        {
            bool result = false;

            if (0 < Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM PRODUCTS_MUTATION_HEADER WHERE PM_INVOICE = '" + noMutasiTextBox.Text + "'")))
                result = true;

            return result;
        }

        private void noMutasiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            noMutasiTextBox.Text = noMutasiTextBox.Text.Trim();

            if (noMutasiExist() && (subModuleID == globalConstants.NEW_PRODUCT_MUTATION))
            {
                errorLabel.Text = "NO MUTASI SUDAH ADA";
                noMutasiTextBox.Focus();
            }
            else
                errorLabel.Text = "";
        }
        
        private void rejectButton_Click(object sender, EventArgs e)
        {
            subModuleID = globalConstants.REJECT_PRODUCT_MUTATION;
            if (saveData())
            {
                totalApproved.Text = "Rp. 0";

                MessageBox.Show("SUCCESS");

                noMutasiTextBox.ReadOnly = true;
                PMDateTimePicker.Enabled = false;
                detailRequestOrderDataGridView.ReadOnly = true;
                approveButton.Visible = false;
                rejectButton.Visible = false;
                //reprintButton.Visible = false;
            }
        }

        private void dataMutasiBarangDetailForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";

        }

        private void deleteCurrentRow()
        {
            if (detailRequestOrderDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

                detailRequestOrderDataGridView.Rows.Remove(selectedRow);
            }
        }

        private void detailRequestOrderDataGridView_KeyDown(object sender, KeyEventArgs e)
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

        private void reprintButton_Click(object sender, EventArgs e)
        {

        }

        private bool isROActive()
        {
            bool result = false;

            if (1 == Convert.ToInt32(DS.getDataSingleValue("SELECT RO_ACTIVE FROM REQUEST_ORDER_HEADER WHERE RO_INVOICE = '"+selectedROInvoice+"'")))
                result = true;

            return result;
        }

        private void createPOButton_Click(object sender, EventArgs e)
        {
            purchaseOrderDetailForm displayedForm = new purchaseOrderDetailForm(globalConstants.PURCHASE_ORDER_DARI_RO, selectedROInvoice);
            displayedForm.ShowDialog(this);

            this.Close();

            /*if (!isROActive())
            {
                detailRequestOrderDataGridView.ReadOnly = true;

                noMutasiTextBox.ReadOnly = true;
                PMDateTimePicker.Enabled = false;
                approveButton.Visible = false;
                createPOButton.Visible = false;
            }
            */
        }

        private void branchFromCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchFromID = Convert.ToInt32(branchFromComboHidden.Items[branchFromCombo.SelectedIndex].ToString());
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchToID = Convert.ToInt32(branchToComboHidden.Items[branchToCombo.SelectedIndex].ToString());
        }
    }
}

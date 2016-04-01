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
    public partial class pembayaranLumpSumForm : Form
    {
        private int selectedBranchID = 0;
        private int selectedCustomerID = 0;
        private int selectedSupplierID = 0;
        private int selectedCreditID = 0;
        private double globalTotalValue = 0;
        private int originModuleID = 0;
        private bool isLoading = false;
        private double changeAmount = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public pembayaranLumpSumForm()
        {
            InitializeComponent();
        }

        public pembayaranLumpSumForm(int moduleID, int selectedID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
            {
                selectedCustomerID = selectedID;
                this.Text = "PEMBAYARAN PIUTANG CUSTOMER";
                label14.Text = "PELANGGAN";
                label3.Text = "TOTAL PIUTANG";
            }
            else if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                selectedBranchID = selectedID;
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                selectedSupplierID = selectedID;
                this.Text = "PEMBAYARAN HUTANG SUPPLIER";
                label14.Text = "SUPPLIER";
                label3.Text = "TOTAL HUTANG";
            }
        }

        private void loadDataBranch()
        {
            string branchName = "";

            branchName = DS.getDataSingleValue("SELECT IFNULL(BRANCH_NAME,' ') FROM MASTER_BRANCH WHERE BRANCH_ID = " + selectedBranchID).ToString();

            cabangNameTextBox.Text = branchName;
        }

        private void loadDataCustomer()
        {
            string customerName = "";

            customerName = DS.getDataSingleValue("SELECT IFNULL(CUSTOMER_FULL_NAME,' ') FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = " + selectedCustomerID).ToString();

            cabangNameTextBox.Text = customerName;
        }

        private double getTotalPayment(int creditID = 0)
        {
            double result = 0;
            string sqlCommand = "";

            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                sqlCommand = "SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                    "WHERE PC.CREDIT_ID = C.CREDIT_ID AND C.PM_INVOICE = PM.PM_INVOICE AND PC.PAYMENT_INVALID = 0 AND PM.BRANCH_ID_TO = " + selectedBranchID;
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT PC, SALES_HEADER SH, CREDIT C " +
                                    "WHERE PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = SH.SALES_INVOICE AND PC.PAYMENT_INVALID = 0 AND SH.CUSTOMER_ID = " + selectedCustomerID;

            if (creditID > 0)
                sqlCommand = sqlCommand + " AND C.CREDIT_ID = " + creditID;

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getTotalCredit()
        {
            double result = 0;
            string sqlCommand = "";

            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                sqlCommand = "SELECT IFNULL(SUM(CREDIT_NOMINAL), 0) FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                    "WHERE C.PM_INVOICE = PM.PM_INVOICE AND PM.BRANCH_ID_TO = " + selectedBranchID;
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT IFNULL(SUM(CREDIT_NOMINAL), 0) FROM SALES_HEADER SH, CREDIT C " +
                                    "WHERE C.SALES_INVOICE = SH.SALES_INVOICE AND SH.CUSTOMER_ID = " + selectedCustomerID;

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private void loadDataPM()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            //sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS TOTAL FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";
            sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS 'TOTAL PIUTANG', (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";

            using (rdr = DS.getData(sqlCommand))
            {
                isLoading = true;

                detailPMDataGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    
                    dt.Load(rdr);
                    detailPMDataGridView.DataSource = dt;

                    detailPMDataGridView.Columns["CREDIT_ID"].Visible = false;
                    detailPMDataGridView.Columns["NO MUTASI"].Width= 200;
                    detailPMDataGridView.Columns["TGL MUTASI"].Width = 200;
                    detailPMDataGridView.Columns["TOTAL PIUTANG"].Width = 200;
                    detailPMDataGridView.Columns["SISA PIUTANG"].Width = 200;

                }
                isLoading = false;
            }
        }

        private void loadDataSO()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            //sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS TOTAL FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";
            sqlCommand = "SELECT C.CREDIT_ID, SH.SALES_INVOICE AS 'SALES INVOICE', DATE_FORMAT(SH.SALES_DATE, '%d-%M-%Y') AS 'TGL SALES', CREDIT_NOMINAL AS 'TOTAL PIUTANG', (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                "FROM SALES_HEADER SH, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                "WHERE SH.CUSTOMER_ID = " + selectedCustomerID+ " AND SH.SALES_INVOICE = C.SALES_INVOICE";

            using (rdr = DS.getData(sqlCommand))
            {
                isLoading = true;
                detailPMDataGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    

                    dt.Load(rdr);
                    detailPMDataGridView.DataSource = dt;

                    detailPMDataGridView.Columns["CREDIT_ID"].Visible = false;
                    detailPMDataGridView.Columns["SALES INVOICE"].Width = 200;
                    detailPMDataGridView.Columns["TGL SALES"].Width = 200;
                    detailPMDataGridView.Columns["TOTAL PIUTANG"].Width = 200;
                    detailPMDataGridView.Columns["SISA PIUTANG"].Width = 200;

                }
                isLoading = false;
            }
        }

        private void loadDataPayment(int creditID)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                sqlCommand = "SELECT PC.PAYMENT_INVALID, PC.PAYMENT_ID, PM.PM_INVOICE AS 'NO INVOICE', IF(PC.PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                    "FROM PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                    "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PC.CREDIT_ID = C.CREDIT_ID AND PM.PM_INVOICE = C.PM_INVOICE AND C.CREDIT_ID = " + creditID;
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT PC.PAYMENT_INVALID, PC.PAYMENT_ID, SH.SALES_INVOICE AS 'NO INVOICE', IF(PC.PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                    "FROM PAYMENT_CREDIT PC, SALES_HEADER SH, CREDIT C " +
                                    "WHERE SH.CUSTOMER_ID = " + selectedCustomerID + " AND PC.CREDIT_ID = C.CREDIT_ID AND SH.SALES_INVOICE = C.SALES_INVOICE AND C.CREDIT_ID = " + creditID;

            using (rdr = DS.getData(sqlCommand))
            {
                detailPaymentInfoDataGrid.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPaymentInfoDataGrid.DataSource = dt;

                    detailPaymentInfoDataGrid.Columns["PAYMENT_ID"].Visible= false;
                    detailPaymentInfoDataGrid.Columns["PAYMENT_INVALID"].Visible = false;
                    detailPaymentInfoDataGrid.Columns["NO INVOICE"].Width = 200;
                    detailPaymentInfoDataGrid.Columns["TGL PEMBAYARAN"].Width = 200;
                    detailPaymentInfoDataGrid.Columns["JUMLAH"].Width = 200;
                    detailPaymentInfoDataGrid.Columns["DESKRIPSI"].Width = 300;

                    for (int i =0;i<detailPaymentInfoDataGrid.Rows.Count;i++)
                    {
                        if (detailPaymentInfoDataGrid.Rows[i].Cells["STATUS"].Value.ToString().Equals("N") && detailPaymentInfoDataGrid.Rows[i].Cells["PAYMENT_INVALID"].Value.ToString().Equals("0"))
                            detailPaymentInfoDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void paymentMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            paymentMaskedTextBox.Text = gutil.allTrim(paymentMaskedTextBox.Text);
        }

        private void detailPMDataGridView_Click(object sender, EventArgs e)
        {
            int creditID = 0;
            if (detailPMDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPMDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPMDataGridView.Rows[rowSelectedIndex];
            creditID = Convert.ToInt32(selectedRow.Cells["CREDIT_ID"].Value);

            loadDataPayment(creditID);
        }

        private bool dataValidated()
        {
            if (Convert.ToDouble(paymentMaskedTextBox.Text) <= 0)
            {
                errorLabel.Text = "JUMLAH PEMBAYARAN HARUS LEBIH BESAR DARI 0";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string paymentDateTime = "";
            DateTime selectedPaymentDate;
            double paymentNominal = 0;
            double actualPaymentAmount = 0;
            double outstandingCreditAmount = 0;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            int rowCounter;
            int currentCreditID;
            bool fullyPaid = false;
            int paymentConfirmed = 0;
            string salesInvoice = "";

            string paymentDescription = "";

            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(paymentMaskedTextBox.Text);
            paymentDescription = descriptionTextBox.Text;

            changeAmount = 0;
            
            if (paymentNominal > globalTotalValue)
            {
                changeAmount = paymentNominal - globalTotalValue;
                paymentNominal = globalTotalValue;
            }

            if (paymentCombo.SelectedIndex == 0)
                paymentConfirmed = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // GET A LIST OF OUTSTANDING MUTATION CREDIT
                if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                    sqlCommand = "SELECT C.CREDIT_ID, C.PM_INVOICE, C.SALES_INVOICE, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                        "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                        "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND C.CREDIT_PAID = 0 " +
                                        "AND PM.PM_INVOICE = C.PM_INVOICE ORDER BY C.CREDIT_ID ASC";
                else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                    sqlCommand = "SELECT C.CREDIT_ID, C.PM_INVOICE, C.SALES_INVOICE, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                        "FROM SALES_HEADER SH, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                        "WHERE SH.CUSTOMER_ID = " + selectedCustomerID + " AND C.CREDIT_PAID = 0 " +
                                        "AND SH.SALES_INVOICE = C.SALES_INVOICE ORDER BY C.CREDIT_ID ASC";
                
                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                        dt.Load(rdr);
                }

                if (dt.Rows.Count > 0)
                {
                    rowCounter = 0;
                    while (paymentNominal > 0 && rowCounter < dt.Rows.Count)
                    {
                        fullyPaid = false;

                        currentCreditID = Convert.ToInt32(dt.Rows[rowCounter]["CREDIT_ID"].ToString());
                        outstandingCreditAmount = Convert.ToDouble(dt.Rows[rowCounter]["SISA PIUTANG"].ToString());

                        if (outstandingCreditAmount <= 0)
                            continue;

                        if (outstandingCreditAmount <= paymentNominal && outstandingCreditAmount > 0)
                        {
                            actualPaymentAmount = outstandingCreditAmount;
                            fullyPaid = true;
                        }
                        else
                            actualPaymentAmount = paymentNominal;

                        sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                            "(" + currentCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), 1, " + actualPaymentAmount + ", '" + paymentDescription + "', " + paymentConfirmed + ")";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (fullyPaid && (paymentConfirmed == 1)) // for cash payment
                        {
                            // UPDATE CREDIT TABLE
                            sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + currentCreditID;

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                            {
                                salesInvoice = DS.getDataSingleValue("SELECT IFNULL(SALES_INVOICE, '') FROM CREDIT WHERE CREDIT_ID = " + currentCreditID).ToString();
                                if (salesInvoice.Length > 0)
                                {
                                    // UPDATE SALES HEADER TABLE
                                    sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + salesInvoice + "'";

                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                        }

                        paymentNominal = paymentNominal - actualPaymentAmount;
                        rowCounter += 1;
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
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                if (changeAmount > 0)
                    MessageBox.Show("UANG KEMBALI SEBESAR " + changeAmount.ToString("C", culture));

                gutil.showSuccess(gutil.INS);

                if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                    loadDataPM();
                else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                    loadDataSO();

                calculateGlobalOutstandingCredit();
                detailPaymentInfoDataGrid.DataSource = null;
            }
        }

        private void calculateGlobalOutstandingCredit()
        {
            double totalCredit = 0;
            double totalPayment = 0;
            
            totalCredit = getTotalCredit();
            totalPayment = getTotalPayment();
            globalTotalValue = totalCredit - totalPayment;
            totalLabel.Text = (globalTotalValue).ToString("C", culture);

            if (globalTotalValue <= 0)
                saveButton.Enabled = false;
            else
                saveButton.Enabled = true;

        }

        private void dataPiutangMutasiForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            fillInPaymentMethod();
            
            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
            {
                loadDataPM();
                loadDataBranch();
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
            { 
                loadDataSO();
                loadDataCustomer();
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {

            }
            
            paymentCombo.SelectedIndex = 0;
            paymentCombo.Text = paymentCombo.Items[0].ToString();
//            loadDataPayment();

            calculateGlobalOutstandingCredit();
            
            gutil.reArrangeTabOrder(this);
        }

        private void detailPMDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int creditID = 0;
            if (detailPMDataGridView.Rows.Count <= 0)
                return;

            if (isLoading)
                return;

            int rowSelectedIndex = detailPMDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPMDataGridView.Rows[rowSelectedIndex];
            creditID = Convert.ToInt32(selectedRow.Cells["CREDIT_ID"].Value);
            selectedCreditID = creditID;
            loadDataPayment(creditID);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (detailPaymentInfoDataGrid.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPaymentInfoDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPaymentInfoDataGrid.Rows[rowSelectedIndex];

            if (!selectedRow.Cells["STATUS"].Value.ToString().Equals("N") || !selectedRow.Cells["PAYMENT_INVALID"].Value.ToString().Equals("0"))
            {
                invalidPayment.Enabled = false;
                confirmBayar.Enabled = false;
            }
            else
            {
                invalidPayment.Enabled = true;
                confirmBayar.Enabled = true;
            }
        }

        private bool confirmPembayaran(string paymentID)
        {
            bool result = false;
            string sqlCommand;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "UPDATE PAYMENT_CREDIT SET PAYMENT_CONFIRMED = 1 WHERE PAYMENT_ID = " + paymentID;
            
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

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
        
        private bool checkCreditStatus()
        {
            bool result = true;
            string sqlCommand;
            int numOfUnconfirmedPayment;
            double totalCreditPayment = 0;
            double totalCreditAmount = 0;
            string salesInvoice = "";
            MySqlException internalEX = null;

            sqlCommand = "SELECT COUNT(1) FROM PAYMENT_CREDIT WHERE CREDIT_ID = " + selectedCreditID + " AND PAYMENT_CONFIRMED = 0 AND PAYMENT_INVALID = 0";
            numOfUnconfirmedPayment = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            if (numOfUnconfirmedPayment <= 0)
            {
                // CHECK IS THERE ANY OUTSTANDING AMOUNT FOR THAT PARTICULAR CREDIT
                totalCreditAmount = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(CREDIT_NOMINAL, 0) FROM CREDIT WHERE CREDIT_ID = " + selectedCreditID));
                totalCreditPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT WHERE PAYMENT_CONFIRMED = 1 AND PAYMENT_INVALID = 0 AND CREDIT_ID = " + selectedCreditID));

                if (totalCreditAmount <= totalCreditPayment)
                {
                    // CREDIT FULLY PAID
                    DS.beginTransaction();

                    try
                    {
                        DS.mySqlConnect();

                        // UPDATE CREDIT TABLE
                        sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                        { 
                            salesInvoice = DS.getDataSingleValue("SELECT IFNULL(SALES_INVOICE, '') FROM CREDIT WHERE CREDIT_ID = " + selectedCreditID).ToString();
                            if (salesInvoice.Length > 0)
                            {
                                // UPDATE SALES HEADER TABLE
                                sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + salesInvoice + "'";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
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
                }
            }

            return result;
        }

        private void confirmBayar_Click(object sender, EventArgs e)
        {
            string selectedPaymentID = "";

            if (detailPaymentInfoDataGrid.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPaymentInfoDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPaymentInfoDataGrid.Rows[rowSelectedIndex];

            if (selectedRow.Cells["STATUS"].Value.ToString().Equals("N"))
            {
                selectedRow.DefaultCellStyle.BackColor = Color.Red;

                if (DialogResult.Yes == MessageBox.Show("KONFIRMASI PEMBAYARAN ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    selectedPaymentID = selectedRow.Cells["PAYMENT_ID"].Value.ToString();

                    if (confirmPembayaran(selectedPaymentID))
                    {
                        calculateGlobalOutstandingCredit();
                        if (checkCreditStatus())
                        {
                            gutil.showSuccess(gutil.INS);
                        }

                        loadDataPayment(selectedCreditID);

                        if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                            loadDataPM();
                        else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                            loadDataSO();

                    }
                }
                selectedRow.DefaultCellStyle.BackColor = Color.White;
            }

        }

        private bool invalidPembayaran(string paymentID)
        {
            bool result = false;
            string sqlCommand;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "UPDATE PAYMENT_CREDIT SET PAYMENT_INVALID = 1 WHERE PAYMENT_ID = " + paymentID;

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

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

        private void invalidPayment_Click(object sender, EventArgs e)
        {
            string selectedPaymentID = "";

            if (detailPaymentInfoDataGrid.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPaymentInfoDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPaymentInfoDataGrid.Rows[rowSelectedIndex];

            selectedRow.DefaultCellStyle.BackColor = Color.Red;

            if (DialogResult.Yes == MessageBox.Show("PEMBAYARAN TIDAK VALID ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                selectedPaymentID = selectedRow.Cells["PAYMENT_ID"].Value.ToString();

                if (invalidPembayaran(selectedPaymentID))
                {
                    //calculateTotalCredit(true);
                    calculateGlobalOutstandingCredit();
                    if (checkCreditStatus())
                    {
                        gutil.showSuccess(gutil.INS);
                    }

                    loadDataPayment(selectedCreditID);

                    if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                        loadDataPM();
                    else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                        loadDataSO();
                }
            }

            selectedRow.DefaultCellStyle.BackColor = Color.White;
        }

        private void fillInPaymentMethod()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT PM_NAME FROM PAYMENT_METHOD";

            using(rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    paymentCombo.Items.Clear();
                    while (rdr.Read())
                        paymentCombo.Items.Add(rdr.GetString("PM_NAME"));

                    paymentCombo.Text = paymentCombo.Items[0].ToString();
                }
            }
        }
    }
}

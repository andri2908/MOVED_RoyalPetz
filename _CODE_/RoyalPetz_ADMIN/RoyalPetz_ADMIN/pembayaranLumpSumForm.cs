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

        private void loadDataSupplier()
        {
            string supplierName = "";

            supplierName = DS.getDataSingleValue("SELECT IFNULL(SUPPLIER_FULL_NAME,' ') FROM MASTER_SUPPLIER WHERE SUPPLIER_ID = " + selectedSupplierID).ToString();

            cabangNameTextBox.Text = supplierName;
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
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                sqlCommand = "SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_DEBT PD, PURCHASE_HEADER PH, DEBT D " +
                                    "WHERE PD.DEBT_ID = D.DEBT_ID AND D.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PD.PAYMENT_INVALID = 0 AND PH.SUPPLIER_ID = " + selectedSupplierID;

            if (creditID > 0)
            { 
                if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                    sqlCommand = sqlCommand + " AND D.debt_ID = " + creditID;
                else
                    sqlCommand = sqlCommand + " AND C.CREDIT_ID = " + creditID;
            }

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getTotalCredit()
        {
            double result = 0;
            string sqlCommand = "";

            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                sqlCommand = "SELECT IFNULL(SUM(CREDIT_NOMINAL), 0) FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                    "WHERE C.PM_INVOICE = PM.PM_INVOICE AND C.CREDIT_PAID = 0 AND PM.BRANCH_ID_TO = " + selectedBranchID;
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT IFNULL(SUM(CREDIT_NOMINAL), 0) FROM SALES_HEADER SH, CREDIT C " +
                                    "WHERE C.SALES_INVOICE = SH.SALES_INVOICE AND C.CREDIT_PAID = 0 AND SH.CUSTOMER_ID = " + selectedCustomerID;
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                sqlCommand = "SELECT IFNULL(SUM(DEBT_NOMINAL), 0) FROM PURCHASE_HEADER PH, DEBT D " +
                                    "WHERE D.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND D.DEBT_PAID = 0 AND PH.SUPPLIER_ID = " + selectedSupplierID;

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private void loadDataPM(bool displayFullyPaid = false)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            //sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS TOTAL FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";
            sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS 'TOTAL PIUTANG', (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";

            if (!displayFullyPaid)
            {
                sqlCommand = sqlCommand + " AND C.CREDIT_PAID = 0";
            }

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

        private void loadDataSO(bool displayFullyPaid = false)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            //sqlCommand = "SELECT C.CREDIT_ID, PM.PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM.PM_DATETIME, '%d-%M-%Y') AS 'TGL MUTASI', CREDIT_NOMINAL AS TOTAL FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";
            sqlCommand = "SELECT C.CREDIT_ID, SH.SALES_INVOICE AS 'SALES INVOICE', DATE_FORMAT(SH.SALES_DATE, '%d-%M-%Y') AS 'TGL SALES', CREDIT_NOMINAL AS 'TOTAL PIUTANG', IF(C.CREDIT_PAID = 0, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)), 0) AS 'SISA PIUTANG' " +
                                "FROM SALES_HEADER SH, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                "WHERE SH.CUSTOMER_ID = " + selectedCustomerID+ " AND SH.SALES_INVOICE = C.SALES_INVOICE";

            if (!displayFullyPaid)
            {
                sqlCommand = sqlCommand + " AND SH.SALES_PAID = 0";
            }

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

                    detailPMDataGridView.AutoResizeColumns();
                }
                isLoading = false;
            }
        }

        private void loadDataPO(bool displayFullyPaid = false)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            //sqlCommand = "SELECT D.DEBT_ID, PH.PURCHASE_INVOICE AS 'PURCHASE INVOICE', DATE_FORMAT(PH.PURCHASE_TERM_OF_PAYMENT_DATE, '%d-%M-%Y') AS 'TGL JATUH TEMPO', DEBT_NOMINAL AS 'TOTAL HUTANG', (DEBT_NOMINAL - IFNULL(PD.PAYMENT, 0)) AS 'SISA HUTANG' " +
            //                    "FROM PURCHASE_HEADER PH, DEBT D LEFT OUTER JOIN (SELECT DEBT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_DEBT WHERE PAYMENT_INVALID = 0 GROUP BY DEBT_ID) PD ON PD.DEBT_ID = D.DEBT_ID  " +
            //                    "WHERE PH.SUPPLIER_ID = " + selectedSupplierID + " AND PH.PURCHASE_INVOICE = D.PURCHASE_INVOICE";

            sqlCommand = "SELECT D.DEBT_ID, D.PURCHASE_INVOICE AS 'PURCHASE INVOICE', DATE_FORMAT(D.DEBT_DUE_DATE, '%d-%M-%Y') AS 'TGL JATUH TEMPO', DEBT_NOMINAL AS 'TOTAL HUTANG', IF(D.DEBT_PAID = 0, (DEBT_NOMINAL - IFNULL(PD.PAYMENT, 0)), 0) AS 'SISA HUTANG' " +
                                "FROM PURCHASE_HEADER PH, DEBT D LEFT OUTER JOIN (SELECT DEBT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_DEBT WHERE PAYMENT_INVALID = 0 GROUP BY DEBT_ID) PD ON PD.DEBT_ID = D.DEBT_ID  " +
                                "WHERE PH.SUPPLIER_ID = " + selectedSupplierID + " AND PH.PURCHASE_INVOICE = D.PURCHASE_INVOICE";

            if (!displayFullyPaid)
            {
                //sqlCommand = sqlCommand + " AND PH.PURCHASE_PAID = 0";
                sqlCommand = sqlCommand + " AND D.DEBT_PAID = 0";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                isLoading = true;
                detailPMDataGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPMDataGridView.DataSource = dt;

                    detailPMDataGridView.Columns["DEBT_ID"].Visible = false;
                    detailPMDataGridView.Columns["PURCHASE INVOICE"].Width = 200;
                    detailPMDataGridView.Columns["TGL JATUH TEMPO"].Width = 200;
                    detailPMDataGridView.Columns["TOTAL HUTANG"].Width = 200;
                    detailPMDataGridView.Columns["SISA HUTANG"].Width = 200;

                    detailPMDataGridView.AutoResizeColumns();
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
                sqlCommand = "SELECT PC.PAYMENT_INVALID, PC.PAYMENT_ID, PM.PM_INVOICE AS 'NO INVOICE', IF(PC.PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                    "FROM PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                    "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PC.CREDIT_ID = C.CREDIT_ID AND PM.PM_INVOICE = C.PM_INVOICE AND C.CREDIT_ID = " + creditID;
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT PC.PAYMENT_INVALID, PC.PAYMENT_ID, SH.SALES_INVOICE AS 'NO INVOICE', IF(PC.PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                    "FROM PAYMENT_CREDIT PC, SALES_HEADER SH, CREDIT C " +
                                    "WHERE SH.CUSTOMER_ID = " + selectedCustomerID + " AND PC.CREDIT_ID = C.CREDIT_ID AND SH.SALES_INVOICE = C.SALES_INVOICE AND C.CREDIT_ID = " + creditID;
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                sqlCommand = "SELECT PD.PAYMENT_INVALID, PD.PAYMENT_ID, PH.PURCHASE_INVOICE AS 'NO INVOICE', IF(PD.PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                    "FROM PAYMENT_DEBT PD, PURCHASE_HEADER PH, DEBT D " +
                                    "WHERE PH.SUPPLIER_ID = " + selectedSupplierID + " AND PD.DEBT_ID = D.DEBT_ID AND PH.PURCHASE_INVOICE = D.PURCHASE_INVOICE AND D.DEBT_ID = " + creditID;

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

                    detailPaymentInfoDataGrid.AutoResizeColumns();

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
            //int creditID = 0;
            //if (detailPMDataGridView.Rows.Count <= 0)
            //    return;

            //int rowSelectedIndex = detailPMDataGridView.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = detailPMDataGridView.Rows[rowSelectedIndex];

            //if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            //    creditID = Convert.ToInt32(selectedRow.Cells["DEBT_ID"].Value);
            //else
            //    creditID = Convert.ToInt32(selectedRow.Cells["CREDIT_ID"].Value);

            //loadDataPayment(creditID);
        }

        private int getBranchID()
        {
            int result;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(BRANCH_ID, 0) FROM SYS_CONFIG WHERE ID = 2"));

            return result;
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
            string noInvoice = "";
            int branchID = 0;
            string paymentDueDateTime = "";
            DateTime selectedPaymentDueDate;

            string paymentDescription = "";

            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(paymentMaskedTextBox.Text);
            paymentDescription = MySqlHelper.EscapeString(descriptionTextBox.Text);

            changeAmount = 0;
            
            if (paymentNominal > globalTotalValue)
            {
                changeAmount = paymentNominal - globalTotalValue;
                paymentNominal = globalTotalValue;
            }

            if (paymentCombo.SelectedIndex < 3) //0, 1, 2
            {
                // TUNAI, KARTU KREDIT, KARTU DEBIT
                paymentConfirmed = 1;
                paymentDueDateTime = paymentDateTime;

                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : PAYMENT BY CASH");
            }
            else if (paymentCombo.SelectedIndex == 3) //3
            {
                // TRANSFER
                paymentDueDateTime = paymentDateTime;

                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : PAYMENT BY TRANSFER");
            }
            else if (paymentCombo.SelectedIndex > 3) // 4, 5
            {
                // CEK, BG
                selectedPaymentDueDate = cairDTPicker.Value;
                paymentDueDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDueDate);
                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : PAYMENT BY CHEQUE OR BG");
            }

            branchID = getBranchID();

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // GET A LIST OF OUTSTANDING MUTATION CREDIT
                if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                { 
                    sqlCommand = "SELECT C.CREDIT_ID AS NO_ID, C.PM_INVOICE, C.SALES_INVOICE, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA' " +
                                        "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                        "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND C.CREDIT_PAID = 0 " +
                                        "AND PM.PM_INVOICE = C.PM_INVOICE ORDER BY C.CREDIT_ID ASC";
                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG_MUTASI, "PEMBAYARAN LUMPSUM : GET A LIST OF OUTSTANDING MUTASI CREDIT");
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                {
                    sqlCommand = "SELECT C.CREDIT_ID AS NO_ID, C.PM_INVOICE, C.SALES_INVOICE, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA' " +
                                        "FROM SALES_HEADER SH, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                        "WHERE SH.CUSTOMER_ID = " + selectedCustomerID + " AND C.CREDIT_PAID = 0 " +
                                        "AND SH.SALES_INVOICE = C.SALES_INVOICE ORDER BY C.CREDIT_ID ASC";
                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "PEMBAYARAN LUMPSUM : GET A LIST OF OUTSTANDING CREDIT");
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                {
                        sqlCommand = "SELECT D.DEBT_ID AS NO_ID, D.PURCHASE_INVOICE, (DEBT_NOMINAL - IFNULL(PD.PAYMENT, 0)) AS 'SISA' " +
                                        "FROM PURCHASE_HEADER PH, DEBT D LEFT OUTER JOIN (SELECT DEBT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_DEBT WHERE PAYMENT_INVALID = 0 GROUP BY DEBT_ID) PD ON PD.DEBT_ID = D.DEBT_ID  " +
                                        "WHERE PH.SUPPLIER_ID = " + selectedSupplierID + " AND D.DEBT_PAID = 0 " +
                                        "AND PH.PURCHASE_INVOICE = D.PURCHASE_INVOICE ORDER BY D.DEBT_ID ASC";
                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, "PEMBAYARAN LUMPSUM : GET A LIST OF OUTSTANDING DEBT");
                }

                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                        dt.Load(rdr);
                }

                if (dt.Rows.Count > 0)
                {
                    gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : NUM OF OUTSTANDING DATA [" + dt.Rows.Count + "]");
                    rowCounter = 0;
                    while (paymentNominal > 0 && rowCounter < dt.Rows.Count)
                    {
                        fullyPaid = false;
                        gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : rowCounter ["+ rowCounter + "] paymentNominal  [" + paymentNominal + "]");

                        currentCreditID = Convert.ToInt32(dt.Rows[rowCounter]["NO_ID"].ToString());
                        outstandingCreditAmount = Convert.ToDouble(dt.Rows[rowCounter]["SISA"].ToString());

                        gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : currentCreditID [" + currentCreditID + "] outstandingCreditAmount [" + outstandingCreditAmount + "]");

                        if (outstandingCreditAmount <= 0)
                        {
                            rowCounter++;
                            continue;
                        }
                        if (outstandingCreditAmount <= paymentNominal && outstandingCreditAmount > 0)
                        {
                            actualPaymentAmount = outstandingCreditAmount;
                            fullyPaid = true;
                        }
                        else
                            actualPaymentAmount = paymentNominal;

                        if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                        { 
                            sqlCommand = "INSERT INTO PAYMENT_DEBT (DEBT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE) VALUES " +
                                                "(" + currentCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), 1, " + gutil.validateDecimalNumericInput(actualPaymentAmount) + ", '" + paymentDescription + "', " + paymentConfirmed + ", STR_TO_DATE('" + paymentDueDateTime + "', '%d-%m-%Y'))";
                            gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : INSERT INTO PAYMENT DEBT ["+ currentCreditID + ", "+ gutil.validateDecimalNumericInput(actualPaymentAmount) + "]");
                        }
                        else
                        {
                            sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE) VALUES " +
                                            "(" + currentCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), 1, " + gutil.validateDecimalNumericInput(actualPaymentAmount) + ", '" + paymentDescription + "', " + paymentConfirmed + ", STR_TO_DATE('" + paymentDueDateTime + "', '%d-%m-%Y'))";
                            gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : INSERT INTO PAYMENT CREDIT [" + currentCreditID + ", " + gutil.validateDecimalNumericInput(actualPaymentAmount) + "]");
                        }

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (fullyPaid && (paymentConfirmed == 1)) // for cash payment
                        {
                            if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                            {
                                // UPDATE DEBT TABLE
                                sqlCommand = "UPDATE DEBT SET DEBT_PAID = 1 WHERE DEBT_ID = " + currentCreditID;
                                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : UPDATE DEBT SET FULLY PAID [" + currentCreditID + "]");
                            }
                            else
                            {
                                // UPDATE CREDIT TABLE
                                sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + currentCreditID;
                                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : UPDATE CREDIT SET FULLY PAID [" + currentCreditID + "]");
                            }

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                            {
                                noInvoice = DS.getDataSingleValue("SELECT IFNULL(SALES_INVOICE, '') FROM CREDIT WHERE CREDIT_ID = " + currentCreditID).ToString();
                                if (noInvoice.Length > 0)
                                {
                                    // UPDATE SALES HEADER TABLE
                                    sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + noInvoice + "'";

                                    gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : UPDATE SALES HEADER SET FULLY PAID [" + noInvoice + "]");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;

                                    // UPDATE SALES HEADER TAX TABLE
                                    sqlCommand = "UPDATE SALES_HEADER_TAX SET SALES_PAID = 1 WHERE ORIGIN_SALES_INVOICE = '" + noInvoice + "'";

                                    gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : UPDATE SALES HEADER TAX SET FULLY PAID [" + noInvoice + "]");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                            {
                                noInvoice = DS.getDataSingleValue("SELECT IFNULL(PURCHASE_INVOICE, '') FROM DEBT WHERE DEBT_ID = " + currentCreditID).ToString();
                                if (noInvoice.Length > 0)
                                {
                                    // UPDATE PURCHASE HEADER TABLE
                                    sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_PAID = 1 WHERE PURCHASE_INVOICE = '" + noInvoice + "'";

                                    gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : UPDATE PURCHASE HEADER SET FULLY PAID [" + noInvoice + "]");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                        }

                        if(paymentCombo.SelectedIndex == 0 && originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                        {
                            // PAYMENT IN CASH THEREFORE ADDING THE AMOUNT OF CASH IN THE CASH REGISTER
                            // ADD A NEW ENTRY ON THE DAILY JOURNAL TO KEEP TRACK THE ADDITIONAL CASH AMOUNT 
                            noInvoice = DS.getDataSingleValue("SELECT IFNULL(SALES_INVOICE, '') FROM CREDIT WHERE CREDIT_ID = " + currentCreditID).ToString();
                            sqlCommand = "INSERT INTO DAILY_JOURNAL (ACCOUNT_ID, JOURNAL_DATETIME, JOURNAL_NOMINAL, BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID) " +
                                                               "VALUES (1, STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y')" + ", " + actualPaymentAmount + ", " + branchID + ", 'PEMBAYARAN PIUTANG " + noInvoice + "', '" + gutil.getUserID() + "', 1)";

                            gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : INSERT INTO DAILY JOURNAL [" + actualPaymentAmount + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        paymentNominal = paymentNominal - actualPaymentAmount;

                        rowCounter += 1;
                    }
                }

                if (paymentCombo.SelectedIndex == 0 && changeAmount > 0 && originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                {
                    // PAYMENT IN CASH THEREFORE ADDING THE AMOUNT OF CASH IN THE CASH REGISTER
                    // ADD A NEW ENTRY ON THE DAILY JOURNAL TO KEEP TRACK THE ADDITIONAL CASH AMOUNT 
                    sqlCommand = "INSERT INTO DAILY_JOURNAL (ACCOUNT_ID, JOURNAL_DATETIME, JOURNAL_NOMINAL, BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID) " +
                                        "VALUES (1, STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y')" + ", " + gutil.validateDecimalNumericInput(changeAmount) + ", " + selectedBranchID + ", 'SISA PIUTANG MUTASI" + noInvoice + "', '" + gutil.getUserID() + "', 1)";

                    gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : INSERT INTO DAILY JOURNAL [" + actualPaymentAmount + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : EXCEPTION THROWN [" + e.Message + "]");

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
            gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : ATTEMPT TO SAVE DATA PAYMENT");

            if (saveData())
            {
                gutil.saveSystemDebugLog(0, "PEMBAYARAN LUMPSUM : DATA PAYMENT SAVED");

                if (changeAmount > 0 && originModuleID != globalConstants.DATA_PIUTANG_MUTASI)
                    MessageBox.Show("UANG KEMBALI SEBESAR " + changeAmount.ToString("C2", culture));

                gutil.showSuccess(gutil.INS);

                if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                {
                    gutil.saveUserChangeLog(globalConstants.MENU_PEMBAYARAN_PIUTANG_MUTASI, globalConstants.CHANGE_LOG_INSERT, "PEMBAYARAN PIUTANG MUTASI SEBESAR " + paymentMaskedTextBox.Text); 
                    loadDataPM();
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                {
                    gutil.saveUserChangeLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, globalConstants.CHANGE_LOG_PAYMENT_CREDIT, "PEMBAYARAN PIUTANG SEBESAR " + paymentMaskedTextBox.Text);
                    loadDataSO();
                }
                else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                {
                    gutil.saveUserChangeLog(globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER, globalConstants.CHANGE_LOG_PAYMENT_DEBT, "PEMBAYARAN HUTANG SEBESAR " + paymentMaskedTextBox.Text);
                    loadDataPO();
                }

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
            totalLabel.Text = (globalTotalValue).ToString("C2", culture);

            if (globalTotalValue <= 0)
                saveButton.Enabled = false;
            else
                saveButton.Enabled = true;

        }

        private void dataPiutangMutasiForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            cairDTPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            fillInPaymentMethod();
            
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
            if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                creditID = Convert.ToInt32(selectedRow.Cells["DEBT_ID"].Value);
            else
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
            DateTime selectedPaymentDate;
            string paymentDateTime;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                { 
                    sqlCommand = "UPDATE PAYMENT_DEBT SET PAYMENT_CONFIRMED = 1, PAYMENT_CONFIRMED_DATE = STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y')  WHERE PAYMENT_ID = " + paymentID;
                }
                else
                { 
                    sqlCommand = "UPDATE PAYMENT_CREDIT SET PAYMENT_CONFIRMED = 1, PAYMENT_CONFIRMED_DATE = STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y')  WHERE PAYMENT_ID = " + paymentID;
                }

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
            string sqlCommand = "";
            int numOfUnconfirmedPayment;
            double totalCreditPayment = 0;
            double totalCreditAmount = 0;
            string noInvoice = "";
            MySqlException internalEX = null;

            if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                sqlCommand = "SELECT COUNT(1) FROM PAYMENT_DEBT WHERE DEBT_ID = " + selectedCreditID + " AND PAYMENT_CONFIRMED = 0 AND PAYMENT_INVALID = 0";
            else
                sqlCommand = "SELECT COUNT(1) FROM PAYMENT_CREDIT WHERE CREDIT_ID = " + selectedCreditID + " AND PAYMENT_CONFIRMED = 0 AND PAYMENT_INVALID = 0";

            numOfUnconfirmedPayment = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            if (numOfUnconfirmedPayment <= 0)
            {
                // CHECK IS THERE ANY OUTSTANDING AMOUNT FOR THAT PARTICULAR CREDIT
                if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                {
                    totalCreditAmount = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(DEBT_NOMINAL, 0) FROM DEBT WHERE DEBT_ID = " + selectedCreditID));
                    totalCreditPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_DEBT WHERE PAYMENT_CONFIRMED = 1 AND PAYMENT_INVALID = 0 AND DEBT_ID = " + selectedCreditID));
                }
                else
                {
                    totalCreditAmount = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(CREDIT_NOMINAL, 0) FROM CREDIT WHERE CREDIT_ID = " + selectedCreditID));
                    totalCreditPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT WHERE PAYMENT_CONFIRMED = 1 AND PAYMENT_INVALID = 0 AND CREDIT_ID = " + selectedCreditID));
                }

                if (totalCreditAmount <= totalCreditPayment)
                {
                    // CREDIT FULLY PAID
                    DS.beginTransaction();

                    try
                    {
                        DS.mySqlConnect();

                        if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                            sqlCommand = "UPDATE DEBT SET DEBT_PAID = 1 WHERE DEBT_ID = " + selectedCreditID;
                        else
                            // UPDATE CREDIT TABLE
                            sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                        {
                            noInvoice = DS.getDataSingleValue("SELECT IFNULL(SALES_INVOICE, '') FROM CREDIT WHERE CREDIT_ID = " + selectedCreditID).ToString();
                            if (noInvoice.Length > 0)
                            {
                                // UPDATE SALES HEADER TABLE
                                sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + noInvoice + "'";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }
                        else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                        {
                            noInvoice = DS.getDataSingleValue("SELECT IFNULL(PURCHASE_INVOICE, '') FROM DEBT WHERE DEBT_ID = " + selectedCreditID).ToString();
                            if (noInvoice.Length > 0)
                            {
                                // UPDATE SALES HEADER TABLE
                                sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_PAID = 1 WHERE PURCHASE_INVOICE = '" + noInvoice + "'";

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
                        else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                            loadDataPO();
                    }
                }

                if (detailPaymentInfoDataGrid.Rows[rowSelectedIndex].Cells["STATUS"].Value.ToString().Equals("Y"))
                    detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.LightBlue;
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
                if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                    sqlCommand = "UPDATE PAYMENT_DEBT SET PAYMENT_INVALID = 1 WHERE PAYMENT_ID = " + paymentID;
                else
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
                    else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                        loadDataPO();
                }
            }

            if (detailPaymentInfoDataGrid.Rows[rowSelectedIndex].Cells["STATUS"].Value.ToString().Equals("Y"))
                detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.White;
            else
                detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.LightBlue;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            detailPaymentInfoDataGrid.DataSource = null;

            if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                loadDataPO(checkBox1.Checked);
            else if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                loadDataPM(checkBox1.Checked);
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                loadDataSO(checkBox1.Checked);
        }

        private void paymentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paymentCombo.SelectedIndex > 3)
            {
                labelCair.Visible = true;
                cairDTPicker.Visible = true;
                cairDTPicker.Value = DateTime.Now;
            }
            else
            {
                labelCair.Visible = false;
                cairDTPicker.Visible = false;
            }
        }

        private void pembayaranLumpSumForm_Activated(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
            {
                loadDataPM(checkBox1.Checked);
                loadDataBranch();
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
            {
                loadDataSO(checkBox1.Checked);
                loadDataCustomer();
            }
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                loadDataPO(checkBox1.Checked);
                loadDataSupplier();
            }

            paymentCombo.SelectedIndex = 0;
            paymentCombo.Text = paymentCombo.Items[0].ToString();
            //            loadDataPayment();

            calculateGlobalOutstandingCredit();
        }

        private void detailPMDataGridView_DoubleClick(object sender, EventArgs e)
        {
            string selectedPurchaseInvoice= "";
            string selectedSO = "";

            if (detailPMDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPMDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPMDataGridView.Rows[rowSelectedIndex];

            if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
            {
                if (selectedRow.Cells["SISA PIUTANG"].Value.ToString() == "0")
                    return;

                selectedSO = selectedRow.Cells["SALES INVOICE"].Value.ToString();

                pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                pembayaranForm.ShowDialog(this);
             
             }
            else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
            {
                if (selectedRow.Cells["SISA HUTANG"].Value.ToString() == "0")
                    return;

                selectedPurchaseInvoice = selectedRow.Cells["PURCHASE INVOICE"].Value.ToString();
                pembayaranHutangForm displayedPembayaranForm = new pembayaranHutangForm(selectedPurchaseInvoice);
                displayedPembayaranForm.ShowDialog(this);
            }
        }

        private void detailPMDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedPurchaseInvoice = "";
            string selectedSO = "";
            int rowSelectedIndex = 0;

            if (detailPMDataGridView.Rows.Count <= 0)
                return;

            if (e.KeyCode == Keys.Enter)
            { 
                rowSelectedIndex = detailPMDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailPMDataGridView.Rows[rowSelectedIndex];

                if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                {
                    if (selectedRow.Cells["SISA PIUTANG"].Value.ToString() == "0")
                        return;

                    selectedSO = selectedRow.Cells["SALES INVOICE"].Value.ToString();

                    pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                    pembayaranForm.ShowDialog(this);

                }
                else if (originModuleID == globalConstants.PEMBAYARAN_HUTANG)
                {
                    if (selectedRow.Cells["SISA HUTANG"].Value.ToString() == "0")
                        return;

                    selectedPurchaseInvoice = selectedRow.Cells["PURCHASE INVOICE"].Value.ToString();
                    pembayaranHutangForm displayedPembayaranForm = new pembayaranHutangForm(selectedPurchaseInvoice);
                    displayedPembayaranForm.ShowDialog(this);
                }
            }
        }

        private void paymentMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                paymentMaskedTextBox.SelectAll();
            });
        }
    }
}

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
    public partial class pembayaranPiutangLumpSumForm : Form
    {
        private int selectedBranchID = 0;
        private int selectedCustomerID = 0;
        private double globalTotalValue = 0;
        private int originModuleID = 0;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public pembayaranPiutangLumpSumForm()
        {
            InitializeComponent();
        }

        public pembayaranPiutangLumpSumForm(int moduleID, int selectedID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                selectedCustomerID = selectedID;
            else if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                selectedBranchID = selectedID;
        }

        private void loadDataBranch()
        {
            string branchName = "";

            branchName = DS.getDataSingleValue("SELECT IFNULL(BRANCH_NAME,' ') FROM MASTER_BRANCH WHERE BRANCH_ID = " + selectedBranchID).ToString();

            cabangNameTextBox.Text = branchName;
        }

        private double getTotalPayment(int creditID = 0)
        {
            double result = 0;
            string sqlCommand;

            sqlCommand = "SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) FROM PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                "WHERE PC.CREDIT_ID = C.CREDIT_ID AND C.PM_INVOICE = PM.PM_INVOICE ";

            if (creditID > 0)
                sqlCommand = sqlCommand + "AND C.CREDIT_ID = " + creditID;

            result = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        private double getTotalCredit()
        {
            double result = 0;
            string sqlCommand;

            sqlCommand = "SELECT IFNULL(SUM(CREDIT_NOMINAL), 0) FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                "WHERE C.PM_INVOICE = PM.PM_INVOICE AND PM.BRANCH_ID_TO = " + selectedBranchID;

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
                                "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PM.PM_INVOICE = C.PM_INVOICE";

            using (rdr = DS.getData(sqlCommand))
            {
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
            }
        }

        private void loadDataPayment(int creditID)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            sqlCommand = "SELECT PM.PM_INVOICE AS 'NO_MUTASI', DATE_FORMAT(PAYMENT_DATE, '%d-%M-%Y') AS 'TGL PEMBAYARAN', PAYMENT_NOMINAL AS 'JUMLAH', PAYMENT_DESCRIPTION AS DESKRIPSI " +
                                "FROM PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PM, CREDIT C " +
                                "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND PC.CREDIT_ID = C.CREDIT_ID AND PM.PM_INVOICE = C.PM_INVOICE AND C.CREDIT_ID = " + creditID;

            using (rdr = DS.getData(sqlCommand))
            {
                detailPaymentInfoDataGrid.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPaymentInfoDataGrid.DataSource = dt;

                    detailPMDataGridView.Columns["NO MUTASI"].Width = 200;
                    detailPMDataGridView.Columns["TGL PEMBAYARAN"].Width = 200;
                    detailPMDataGridView.Columns["JUMLAH"].Width = 200;
                    detailPMDataGridView.Columns["DESKRIPSI"].Width = 300;
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

            string paymentDescription = "";

            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(paymentMaskedTextBox.Text);
            paymentDescription = descriptionTextBox.Text;

            if (paymentNominal > globalTotalValue)
                paymentNominal = globalTotalValue;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // GET A LIST OF OUTSTANDING MUTATION CREDIT
                sqlCommand = "SELECT C.CREDIT_ID, C.PM_INVOICE, C.SALES_INVOICE, (CREDIT_NOMINAL - IFNULL(PC.PAYMENT, 0)) AS 'SISA PIUTANG' " +
                                    "FROM PRODUCTS_MUTATION_HEADER PM, CREDIT C LEFT OUTER JOIN (SELECT CREDIT_ID, SUM(PAYMENT_NOMINAL) AS PAYMENT FROM PAYMENT_CREDIT GROUP BY CREDIT_ID) PC ON PC.CREDIT_ID = C.CREDIT_ID  " +
                                    "WHERE PM.BRANCH_ID_TO = " + selectedBranchID + " AND C.CREDIT_PAID = 0 " +
                                    "AND PM.PM_INVOICE = C.PM_INVOICE ORDER BY C.CREDIT_ID ASC";
                
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

                        if (outstandingCreditAmount <= paymentNominal && outstandingCreditAmount > 0)
                        {
                            actualPaymentAmount = outstandingCreditAmount;
                            fullyPaid = true;
                        }
                        else
                            actualPaymentAmount = paymentNominal;

                        sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                            "(" + currentCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), 1, " + actualPaymentAmount + ", '" + paymentDescription + "', 1)";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (fullyPaid)
                        {
                            // UPDATE CREDIT TABLE
                            sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + currentCreditID;

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
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
                gutil.showSuccess(gutil.INS);
                loadDataPM();

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

        }

        private void dataPiutangMutasiForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            loadDataBranch();
            loadDataPM();
            calculateGlobalOutstandingCredit();
            
            gutil.reArrangeTabOrder(this);
        }

        
    }
}

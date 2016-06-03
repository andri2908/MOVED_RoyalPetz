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
using System.Drawing.Printing;

namespace RoyalPetz_ADMIN
{
    public partial class pembayaranPiutangForm : Form
    {
        private string selectedSOInvoice = "";
        private int selectedCreditID = 0;
        private int selectedCustomerID = 0;
        private double globalTotalValue = 0;
        private bool isLoading = false;
        private bool isPaymentExceed = false;

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public pembayaranPiutangForm()
        {
            InitializeComponent();
        }

        public pembayaranPiutangForm(string SOInvoice)
        {
            InitializeComponent();

            selectedSOInvoice = SOInvoice;
        }

        private void loadDataHeaderSO()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            DateTime salesDate;

            sqlCommand = "SELECT * FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSOInvoice + "'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        invoiceNoTextBox.Text = rdr.GetString("SALES_INVOICE");
                        selectedCustomerID = rdr.GetInt32("CUSTOMER_ID");
                        salesDate = rdr.GetDateTime("SALES_DATE");
                        invoiceDateTextBox.Text = String.Format(culture, "{0:dd MMM yyyy}", salesDate);
                        globalTotalValue = rdr.GetDouble("SALES_TOTAL");
                    }
               }
            }
        }

        private string getPelangganName()
        {
            string result = "";

            if (selectedCustomerID != 0)
                result = DS.getDataSingleValue("SELECT IFNULL(CUSTOMER_FULL_NAME, ' ') FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = " + selectedCustomerID).ToString();

            return result;
        }

        private int getCreditID()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(CREDIT_ID, 0) FROM CREDIT WHERE SALES_INVOICE = '"+selectedSOInvoice+"'"));

            return result;
        }

        private int getBranchID()
        {
            int result;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(BRANCH_ID, 0) FROM SYS_CONFIG WHERE ID = 2"));

            return result;
        }

        private void loadDataDetailSO()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            sqlCommand = "SELECT D.PRODUCT_NAME AS 'NAMA PRODUK', PRODUCT_SALES_PRICE AS 'HARGA JUAL', PRODUCT_QTY AS 'QTY', SALES_SUBTOTAL AS 'SUBTOTAL' FROM SALES_DETAIL S, MASTER_PRODUCT D WHERE S.PRODUCT_ID = D.PRODUCT_ID AND S.SALES_INVOICE = '" + selectedSOInvoice + "'";
            using (rdr = DS.getData(sqlCommand))
            {
                if(rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailSalesOrderDataGridView.DataSource = dt;

                    detailSalesOrderDataGridView.Columns["NAMA PRODUK"].Width = 300;
                    detailSalesOrderDataGridView.Columns["HARGA JUAL"].Width = 200;
                    detailSalesOrderDataGridView.Columns["QTY"].Width = 200;
                    detailSalesOrderDataGridView.Columns["SUBTOTAL"].Width = 200;
                }
            }

        }

        private void loadDataDetailPayment()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            sqlCommand = "SELECT PAYMENT_INVALID, PAYMENT_ID, PM_NAME AS 'TIPE', IF(PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'TANGGAL PEMBAYARAN', PAYMENT_NOMINAL AS 'NOMINAL', PAYMENT_DESCRIPTION AS 'DESKRIPSI' FROM PAYMENT_CREDIT PC, PAYMENT_METHOD PM WHERE PC.PM_ID = PM.PM_ID AND CREDIT_ID = " + selectedCreditID;
            using (rdr = DS.getData(sqlCommand))
            {
                detailPaymentInfoDataGrid.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPaymentInfoDataGrid.DataSource = dt;

                    detailPaymentInfoDataGrid.Columns["PAYMENT_INVALID"].Visible = false;
                    detailPaymentInfoDataGrid.Columns["PAYMENT_ID"].Visible= false;
                    detailPaymentInfoDataGrid.Columns["TANGGAL PEMBAYARAN"].Width = 200;
                    detailPaymentInfoDataGrid.Columns["NOMINAL"].Width = 200;                    
                    detailPaymentInfoDataGrid.Columns["DESKRIPSI"].Width = 300;

                    for (int i = 0; i < detailPaymentInfoDataGrid.Rows.Count; i++)
                    {
                        if (detailPaymentInfoDataGrid.Rows[i].Cells["STATUS"].Value.ToString().Equals("N") && detailPaymentInfoDataGrid.Rows[i].Cells["PAYMENT_INVALID"].Value.ToString().Equals("0"))
                            detailPaymentInfoDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
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

        private void calculateTotalCredit(bool globalCalculation = false)
        {
            double totalPayment = 0;
            int creditPaid = 0;

            creditPaid = Convert.ToInt32(DS.getDataSingleValue("SELECT CREDIT_PAID FROM CREDIT WHERE SALES_INVOICE = '" + selectedSOInvoice + "'"));

            if (creditPaid == 0)
            { 
                if (globalCalculation)
                {
                    globalTotalValue = Convert.ToDouble(DS.getDataSingleValue("SELECT SALES_TOTAL FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSOInvoice+"'"));
                }
            
                totalPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) AS PAYMENT FROM PAYMENT_CREDIT WHERE PAYMENT_INVALID = 0 AND CREDIT_ID = " + selectedCreditID));

                globalTotalValue = globalTotalValue - totalPayment;
            }
            else
            {
                globalTotalValue = 0;
            }

            totalLabel.Text = globalTotalValue.ToString("C2", culture);

            if (globalTotalValue <= 0)
                saveButton.Enabled = false;
            
        }

        private bool dataValidated()
        {
            double nominalPayment;

            nominalPayment = Convert.ToDouble(paymentMaskedTextBox.Text);
            if (nominalPayment > globalTotalValue)
            {
                if (DialogResult.Yes == MessageBox.Show("PEMBAYARAN MELEBIHI JUMLAH CREDIT, LANJUTKAN ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    isPaymentExceed = true;
                }
                else
                   return false;
            }

            return true;
        }

        public bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            int paymentMethod = 0;
            string paymentDateTime = "";
            DateTime selectedPaymentDate;
            string paymentDueDateTime = "";
            DateTime selectedPaymentDueDate;
            double paymentNominal = 0;
            int branchID = 0;

            string paymentDescription = "";
            int paymentConfirmed = 0;
            
            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(paymentMaskedTextBox.Text);
            paymentMethod = paymentCombo.SelectedIndex + 1;
            paymentDescription = MySqlHelper.EscapeString(descriptionTextBox.Text);

            if (paymentNominal > globalTotalValue)
                paymentNominal = globalTotalValue;

            if (paymentMethod <= 3) //1, 2, 3
            {
                // TUNAI, KARTU KREDIT, KARTU DEBIT
                paymentConfirmed = 1;
                paymentDueDateTime = paymentDateTime;

                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "PAYMENT CREDIT BY CASH");
            }
            else if (paymentMethod == 4)
            {
                // TRANSFER
                paymentDueDateTime = paymentDateTime;

                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "PAYMENT CREDIT BY TRANSFER");
            }
            else if (paymentMethod > 4) // 5, 6
            {
                // CEK, BG
                selectedPaymentDueDate = cairDTPicker.Value;
                paymentDueDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDueDate);

                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "PAYMENT CREDIT BY CHEQUE OR BG");
            }

            branchID = getBranchID();

            gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "BRANCH ID [" + branchID + "]");

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED, PAYMENT_DUE_DATE) VALUES " +
                                    "(" + selectedCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), " + paymentMethod + ", " + gutil.validateDecimalNumericInput(paymentNominal) + ", '" + paymentDescription + "', " + paymentConfirmed + ", STR_TO_DATE('" + paymentDueDateTime + "', '%d-%m-%Y'))";

                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "INSERT INTO PAYMENT CREDIT [" + selectedCreditID + ", " + gutil.validateDecimalNumericInput(paymentNominal) + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                if (paymentMethod <= 3 && paymentNominal == globalTotalValue)
                {
                    //  PAYMENT BY CASH AND FULLY PAID

                    // UPDATE CREDIT TABLE
                    sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "UPDATE CREDIT SET TO FULLY PAID [" + selectedCreditID + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE SALES HEADER TABLE
                    sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + selectedSOInvoice + "'";

                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "UPDATE SALES HEADER SET TO FULLY PAID [" + selectedSOInvoice + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE SALES HEADER TAX TABLE
                    sqlCommand = "UPDATE SALES_HEADER_TAX SET SALES_PAID = 1 WHERE ORIGIN_SALES_INVOICE = '" + selectedSOInvoice + "'";

                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "UPDATE SALES HEADER TAX SET TO FULLY PAID [" + selectedSOInvoice + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                if (paymentMethod == 1)
                {
                    // PAYMENT IN CASH THEREFORE ADDING THE AMOUNT OF CASH IN THE CASH REGISTER
                    // ADD A NEW ENTRY ON THE DAILY JOURNAL TO KEEP TRACK THE ADDITIONAL CASH AMOUNT 
                    sqlCommand = "INSERT INTO DAILY_JOURNAL (ACCOUNT_ID, JOURNAL_DATETIME, JOURNAL_NOMINAL, BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID) " +
                                                   "VALUES (1, STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y')" + ", " + gutil.validateDecimalNumericInput(paymentNominal) + ", " + branchID + ", 'PEMBAYARAN PIUTANG " + selectedSOInvoice + "', '" + gutil.getUserID() + "', 1)";

                    gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "CASH TRANSACTION, INSERT INTO DAILY JOURNAL [" + gutil.validateDecimalNumericInput(paymentNominal) + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "EXCEPTION THROWN [" + e.Message + "]");
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
            bool result = false;
            if (dataValidated())
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return false;
        }
        
        private void printReceipt()
        {
            int paperLength;

            paperLength = calculatePageLength();
            PaperSize psize = new PaperSize("Custom", 320, paperLength);//820);
            printDocument1.DefaultPageSettings.PaperSize = psize;
            DialogResult result;
            printPreviewDialog1.Width = 512;
            printPreviewDialog1.Height = 768;
            result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "ATTEMPT TO SAVE PAYMENT CREDIT");

            if (saveData())
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "PAYMENT CREDIT DATA SAVED");
                gutil.saveUserChangeLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, globalConstants.CHANGE_LOG_PAYMENT_CREDIT, "PEMBAYARAN PIUTANG [" + invoiceNoTextBox.Text + "]");
                gutil.showSuccess(gutil.INS);

                if (isPaymentExceed)
                {
                    MessageBox.Show("UANG KEMBALI SEBESAR " + (Convert.ToDouble(paymentMaskedTextBox.Text) - globalTotalValue).ToString("C2", culture));
                }

                if (DialogResult.Yes == MessageBox.Show("PRINT RECEIPT ?", "WARNING", MessageBoxButtons.YesNo))
                {
                    printReceipt();
                }

                loadDataDetailPayment();
                calculateTotalCredit(true);
            }
        }

        private void paymentMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            paymentMaskedTextBox.Text = gutil.allTrim(paymentMaskedTextBox.Text);
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
                sqlCommand = "UPDATE PAYMENT_CREDIT SET PAYMENT_CONFIRMED = 1, PAYMENT_CONFIRMED_DATE = STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y') WHERE PAYMENT_ID = " + paymentID;
            
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

        private bool checkCreditStatus()
        {
            bool result = true;
            string sqlCommand;
            int numOfUnconfirmedPayment;
            MySqlException internalEX = null;

            sqlCommand = "SELECT COUNT(1) FROM PAYMENT_CREDIT WHERE CREDIT_ID = " + selectedCreditID + " AND PAYMENT_CONFIRMED = 0";
            numOfUnconfirmedPayment = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            if (numOfUnconfirmedPayment <= 0)
            {
                if (globalTotalValue <= 0)
                {
                    DS.beginTransaction();

                    try
                    {
                        DS.mySqlConnect();

                        // UPDATE CREDIT TABLE
                        sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // UPDATE SALES HEADER TABLE
                        sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + selectedSOInvoice + "'";

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
                }
            }

            return result;
        }
        
        private void detailPaymentInfoDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedPaymentID = "";

            if (detailPaymentInfoDataGrid.Rows.Count <= 0)
                return;

            int rowSelectedIndex = detailPaymentInfoDataGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPaymentInfoDataGrid.Rows[rowSelectedIndex];


            if (e.KeyCode == Keys.F5)
            {
                if (selectedRow.Cells["STATUS"].Value.ToString().Equals("N") && selectedRow.Cells["PAYMENT_INVALID"].Value.ToString().Equals("0"))
                {
                    selectedRow.DefaultCellStyle.BackColor = Color.Red;

                    if (DialogResult.Yes == MessageBox.Show("KONFIRMASI PEMBAYARAN ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        selectedPaymentID = selectedRow.Cells["PAYMENT_ID"].Value.ToString();

                        if (confirmPembayaran(selectedPaymentID))
                        {
                            calculateTotalCredit(true);
                            if (checkCreditStatus())
                            { 
                                gutil.showSuccess(gutil.INS);
                            }

                            loadDataDetailPayment();
                        }
                    }

                    selectedRow.DefaultCellStyle.BackColor = Color.White;
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (selectedRow.Cells["STATUS"].Value.ToString().Equals("N") && selectedRow.Cells["PAYMENT_INVALID"].Value.ToString().Equals("0"))
                { 
                    selectedRow.DefaultCellStyle.BackColor = Color.Red;

                    if (DialogResult.Yes == MessageBox.Show("PEMBAYARAN TIDAK VALID ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        selectedPaymentID = selectedRow.Cells["PAYMENT_ID"].Value.ToString();

                        if (invalidPembayaran(selectedPaymentID))
                        {
                            calculateTotalCredit(true);
                            if (checkCreditStatus())
                            {
                                gutil.showSuccess(gutil.INS);
                            }

                            loadDataDetailPayment();
                        }
                    }
                }

                selectedRow.DefaultCellStyle.BackColor = Color.White;

            }

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
                        calculateTotalCredit(true);
                        if (checkCreditStatus())
                        {
                            gutil.showSuccess(gutil.INS);
                        }

                        loadDataDetailPayment();
                    }
                }

                if (detailPaymentInfoDataGrid.Rows[rowSelectedIndex].Cells["STATUS"].Value.ToString().Equals("Y"))
                    detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
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
                    calculateTotalCredit(true);
                    if (checkCreditStatus())
                    {
                        gutil.showSuccess(gutil.INS);
                    }

                    loadDataDetailPayment();
                }
            }

            if (detailPaymentInfoDataGrid.Rows[rowSelectedIndex].Cells["STATUS"].Value.ToString().Equals("Y"))
                detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.White;
            else
                detailPaymentInfoDataGrid.Rows[rowSelectedIndex].DefaultCellStyle.BackColor = Color.LightBlue;
        }
        
        private void pembayaranPiutangForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            cairDTPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            fillInPaymentMethod();

            isLoading = true;
            
            loadDataHeaderSO();
            loadDataDetailSO();

            selectedCreditID = getCreditID();
            loadDataDetailPayment();

            pelangganNameTextBox.Text = getPelangganName();
            calculateTotalCredit();

            isLoading = false;

            gutil.reArrangeTabOrder(this);
        }

        private void pembayaranPiutangForm_Activated(object sender, EventArgs e)
        {
            //if need something
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

        private void paymentMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                paymentMaskedTextBox.SelectAll();
            });
        }

        private void loadInfoToko(int opt, out string namatoko, out string almt, out string telepon, out string email)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            namatoko = ""; almt = ""; telepon = ""; email = "";
            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(BRANCH_ID,0) AS 'BRANCH_ID', IFNULL(HQ_IP4,'') AS 'IP', IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    gutil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "CASHIER FORM : loadInfoToko");
                    while (rdr.Read())
                    {
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            namatoko = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ADDRESS")))
                        {
                            almt = rdr.GetString("ADDRESS");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("PHONE")))
                        {
                            telepon = rdr.GetString("PHONE");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("EMAIL")))
                        {
                            email = rdr.GetString("EMAIL");
                        }
                    }
                }
            }
        }

        private void loadNamaUser(int user_id, out string nama)
        {
            nama = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT USER_NAME AS 'NAME' FROM MASTER_USER WHERE ID=" + user_id))
            {
                if (rdr.HasRows)
                {
                    gutil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "CASHIER FORM : loadNamaUser");

                    rdr.Read();
                    nama = rdr.GetString("NAME");
                }
            }
        }

        private int calculatePageLength()
        {
            string nm, almt, tlpn, email;
            //event printing

            int startY = 5;
            int Offset = 15;
            int offset_plus = 3;
            string sqlCommand;
            int totalLengthPage = startY + Offset; ;

            //HEADER

            //set allignemnt

            loadInfoToko(2, out nm, out almt, out tlpn, out email);

            Offset = Offset + 12;

            Offset = Offset + 10;

            if (!email.Equals(""))
            {
                Offset = Offset + 10;
            }

            Offset = Offset + 13;
            //end of header

            //start of content
            MySqlDataReader rdr;

            Offset = Offset + 12;
            //SET TO LEFT MARGIN

            //2. CUSTOMER NAME
            Offset = Offset + 12;

            Offset = Offset + 13;

            Offset = Offset + 12;

            Offset = Offset + 15 + offset_plus;

            Offset = Offset + 12;

            Offset = Offset + 12;

            Offset = Offset + 12;

            Offset = Offset + 13;

            // DISPLAY ALL PAYMENT FOR THE INVOICE
            sqlCommand = "SELECT DATE_FORMAT(PC.PAYMENT_DATE, '%d-%M-%Y') AS 'PAYMENT_DATE', PC.PAYMENT_NOMINAL, PC.PAYMENT_DESCRIPTION FROM PAYMENT_CREDIT PC, CREDIT C WHERE PC.PAYMENT_CONFIRMED = 1 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = '" + selectedSOInvoice + "'";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Offset = Offset + 15;
                    }
                }
            }

            Offset = Offset + 13;

            Offset = Offset + 15;

            Offset = Offset + 13;

            Offset = Offset + 15;

            //eNd of content

            //FOOTER

            Offset = Offset + 13;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            totalLengthPage = totalLengthPage + Offset + 15;

            //gutil.saveSystemDebugLog(globalConstants.MENU_PENJUALAN, "CASHIER FORM : calculatePageLength, totalLengthPage [" + totalLengthPage + "]");
            return totalLengthPage;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String ucapan = "";
            string nm, almt, tlpn, email;

            //event printing

            gutil.saveSystemDebugLog(globalConstants.MENU_PEMBAYARAN_PIUTANG, "printDocument1_PrintPage, print POS size receipt");

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 5;
            int colxwidth = 93; //31x3
            int totrowwidth = 310; //310/10=31
            int totrowheight = 20;
            int startY = 5;
            int Offset = 15;
            int offset_plus = 3;
            string sqlCommand;
            string customer = "";
            string tgl = "";
            string group = "";
            double total = 0;
            string paymentDesc = "";
            double totalPayment = 0;

            //HEADER

            //set allignemnt
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //set whole printing area
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(startX, startY + Offset, totrowwidth, totrowheight);
            //set right print area
            System.Drawing.RectangleF rectright = new System.Drawing.RectangleF(totrowwidth - colxwidth - startX, startY + Offset, colxwidth, totrowheight);
            //set middle print area
            System.Drawing.RectangleF rectcenter = new System.Drawing.RectangleF((startX + (totrowwidth / 2) - colxwidth - startX), startY + Offset, (totrowwidth / 2) - startX, totrowheight);

            loadInfoToko(2, out nm, out almt, out tlpn, out email);

            graphics.DrawString(nm, new Font("Courier New", 9),
                                new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            graphics.DrawString(almt,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 10;
            rect.Y = startY + Offset;
            graphics.DrawString(tlpn,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            if (!email.Equals(""))
            {
                Offset = Offset + 10;
                rect.Y = startY + Offset;
                graphics.DrawString(email,
                         new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            }

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            String underLine = "-------------------------------------";  //37 character
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);
            //end of header

            //start of content
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();
            //load customer id
            sqlCommand = "SELECT S.SALES_INVOICE AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER',DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE',S.SALES_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP' FROM SALES_HEADER S,MASTER_CUSTOMER C WHERE S.CUSTOMER_ID = C.CUSTOMER_ID AND S.SALES_INVOICE = '" + selectedSOInvoice + "'" +
                " UNION " +
                "SELECT S.SALES_INVOICE AS 'INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE', S.SALES_TOTAL AS 'TOTAL', 'RETAIL' AS 'GROUP' FROM SALES_HEADER S WHERE S.CUSTOMER_ID = 0 AND S.SALES_INVOICE = '" + selectedSOInvoice + "'" +
                "ORDER BY DATE ASC";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    customer = rdr.GetString("CUSTOMER");
                    tgl = rdr.GetString("DATE");
                    total = rdr.GetDouble("TOTAL");
                    group = rdr.GetString("GROUP");
                }
            }
            DS.mySqlClose();

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            //SET TO LEFT MARGIN
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "PEMBAYARAN PIUTANG";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            //2. CUSTOMER NAME
            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "PELANGGAN : " + customer + " [" + group + "]";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            rect.Width = totrowwidth;
            ucapan = "BUKTI PEMBAYARAN";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15 + offset_plus;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "NO. NOTA : " + selectedSOInvoice;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "TOTAL    : " + total.ToString("C2", culture);
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "TANGGAL  : " + tgl;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            string nama = "";
            loadNamaUser(gutil.getUserID(), out nama);
            ucapan = "OPERATOR : " + nama;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            // JUMLAH TOTAL INVOICE
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;

            // DISPLAY ALL PAYMENT FOR THE INVOICE
            sqlCommand = "SELECT DATE_FORMAT(PC.PAYMENT_DATE, '%d-%M-%Y') AS 'PAYMENT_DATE', PC.PAYMENT_NOMINAL, PC.PAYMENT_DESCRIPTION FROM PAYMENT_CREDIT PC, CREDIT C WHERE PC.PAYMENT_CONFIRMED = 1 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = '" + selectedSOInvoice + "'";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Offset = Offset + 15;
                        rect.Y = startY + Offset;
                        rect.X = startX + 15;
                        rect.Width = 280;
                        sf.LineAlignment = StringAlignment.Near;
                        sf.Alignment = StringAlignment.Near;

                        paymentDesc = rdr.GetString("PAYMENT_DESCRIPTION");
                        totalPayment = totalPayment + rdr.GetDouble("PAYMENT_NOMINAL");
                        ucapan = "[" + rdr.GetString("PAYMENT_DATE") + "] " + rdr.GetDouble("PAYMENT_NOMINAL").ToString("C2", culture) + " " + paymentDesc;
                        if (ucapan.Length > 30)
                        {
                            ucapan = ucapan.Substring(0, 30); //maximum 30 character
                        }
                        //
                        graphics.DrawString(ucapan, new Font("Courier New", 7),
                                 new SolidBrush(Color.Black), rect, sf);
                    }
                }
            }

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "    JUMLAH PEMBAYARAN  :";
            rectcenter.Y = rect.Y;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectcenter, sf);
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;
            ucapan = totalPayment.ToString("C2", culture);
            rectright.Y = Offset - startY + 1;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectright, sf);

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "        TOTAL PIUTANG  :";
            rectcenter.Y = rect.Y;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectcenter, sf);
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;
            ucapan = (total - totalPayment).ToString("C2", culture);
            rectright.Y = Offset - startY + 1;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectright, sf);

            //eNd of content

            //FOOTER

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TERIMA KASIH ATAS KUNJUNGAN ANDA";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "MAAF BARANG YANG SUDAH DIBELI";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TIDAK DAPAT DITUKAR/ DIKEMBALIKKAN";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            //end of footer
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("PRINT RECEIPT ?", "WARNING", MessageBoxButtons.YesNo))
            {
                printReceipt();
            }
        }
    }
}

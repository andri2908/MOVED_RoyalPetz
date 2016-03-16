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

            result = DS.getDataSingleValue("SELECT CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = " + selectedCustomerID).ToString();

            return result;
        }

        private int getCreditID()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(CREDIT_ID, 0) FROM CREDIT WHERE SALES_INVOICE = '"+selectedSOInvoice+"'"));

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

            sqlCommand = "SELECT PAYMENT_ID, PM_NAME AS 'TIPE', IF(PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DATE, '%d-%M-%Y') AS 'TANGGAL', PAYMENT_NOMINAL AS 'NOMINAL', PAYMENT_DESCRIPTION AS 'DESKRIPSI' FROM PAYMENT_CREDIT PC, PAYMENT_METHOD PM WHERE PC.PM_ID = PM.PM_ID AND CREDIT_ID = " + selectedCreditID;
            using (rdr = DS.getData(sqlCommand))
            {
                detailPaymentInfoDataGrid.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPaymentInfoDataGrid.DataSource = dt;

                    detailPaymentInfoDataGrid.Columns["PAYMENT_ID"].Visible= false;
                    detailPaymentInfoDataGrid.Columns["TANGGAL"].Width = 200;
                    detailPaymentInfoDataGrid.Columns["NOMINAL"].Width = 200;                    
                    detailPaymentInfoDataGrid.Columns["DESKRIPSI"].Width = 300;
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
            
            if (globalCalculation)
            {
                globalTotalValue = Convert.ToDouble(DS.getDataSingleValue("SELECT SALES_TOTAL FROM SALES_HEADER WHERE SALES_INVOICE = '" + selectedSOInvoice+"'"));
            }
            
            totalPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) AS PAYMENT FROM PAYMENT_CREDIT WHERE CREDIT_ID = " + selectedCreditID));

            globalTotalValue = globalTotalValue - totalPayment;

            totalLabel.Text = globalTotalValue.ToString("C", culture);

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
            double paymentNominal = 0;

            string paymentDescription = "";
            int paymentConfirmed = 0;
            
            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(paymentMaskedTextBox.Text);
            paymentMethod = paymentCombo.SelectedIndex + 1;
            paymentDescription = descriptionTextBox.Text;

            if (paymentNominal > globalTotalValue)
                paymentNominal = globalTotalValue;

            if (paymentMethod == 1)
                paymentConfirmed = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO PAYMENT_CREDIT (CREDIT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                    "(" + selectedCreditID + ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), " + paymentMethod + ", " + paymentNominal + ", '" + paymentDescription + "', " + paymentConfirmed + ")";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                if (paymentMethod == 1 && paymentNominal == globalTotalValue)
                {
                    //  PAYMENT BY CASH AND FULLY PAID

                    // UPDATE CREDIT TABLE
                    sqlCommand = "UPDATE CREDIT SET CREDIT_PAID = 1 WHERE CREDIT_ID = " + selectedCreditID;

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE SALES HEADER TABLE
                    sqlCommand = "UPDATE SALES_HEADER SET SALES_PAID = 1 WHERE SALES_INVOICE = '" + selectedSOInvoice + "'";

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

                if (isPaymentExceed)
                {
                    MessageBox.Show("UANG KEMBALI SEBESAR " + (Convert.ToDouble(paymentMaskedTextBox.Text) - globalTotalValue).ToString("C", culture));
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

            if (e.KeyCode == Keys.F5)
            {
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

                    selectedRow.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void pembayaranPiutangForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
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

    }
}

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
    public partial class pembayaranHutangForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        private string selectedPOInvoice = "";
        private int selectedSupplierID = 0;
        private double globalTotalValue = 0;
        private int selectedDebtID = 0;
        private bool isLoading = false;
        private bool isPaymentExceed = false;

        public pembayaranHutangForm()
        {
            InitializeComponent();
        }

        public pembayaranHutangForm(string poInvoice)
        {
            InitializeComponent();
            selectedPOInvoice = poInvoice;
        }
        
        private void loadDataHeaderPO()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            DateTime poDate;

            sqlCommand = "SELECT H.*, M.SUPPLIER_FULL_NAME FROM PURCHASE_HEADER H, MASTER_SUPPLIER M WHERE PURCHASE_INVOICE = '" + selectedPOInvoice + "' AND H.SUPPLIER_ID = M.SUPPLIER_ID";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        poInvoiceTextBox.Text = rdr.GetString("PURCHASE_INVOICE");
                        selectedSupplierID = rdr.GetInt32("SUPPLIER_ID");
                        supplierNameTextBox.Text = rdr.GetString("SUPPLIER_FULL_NAME");
                        poDate = rdr.GetDateTime("PURCHASE_DATETIME");
                        poDateTextBox.Text = String.Format(culture, "{0:dd MMM yyyy}", poDate);
                        globalTotalValue = rdr.GetDouble("PURCHASE_TOTAL");
                    }
                }
            }
        }

        private int getDebtID()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(DEBT_ID, 0) FROM DEBT WHERE PURCHASE_INVOICE = '" + selectedPOInvoice + "'"));

            return result;
        }

        private void loadDataDetailPO()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            sqlCommand = "SELECT D.PRODUCT_NAME AS 'NAMA PRODUK', PRODUCT_PRICE AS 'HARGA BELI', PRODUCT_QTY AS 'QTY', PURCHASE_SUBTOTAL AS 'SUBTOTAL' FROM PURCHASE_DETAIL S, MASTER_PRODUCT D WHERE S.PRODUCT_ID = D.PRODUCT_ID AND S.PURCHASE_INVOICE = '" + selectedPOInvoice + "'";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPurchaseOrderDataGridView.DataSource = dt;

                    detailPurchaseOrderDataGridView.Columns["NAMA PRODUK"].Width = 300;
                    detailPurchaseOrderDataGridView.Columns["HARGA BELI"].Width = 200;
                    detailPurchaseOrderDataGridView.Columns["QTY"].Width = 200;
                    detailPurchaseOrderDataGridView.Columns["SUBTOTAL"].Width = 200;
                }
            }

        }

        private void loadDataDetailPayment()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            sqlCommand = "SELECT PAYMENT_ID, PM_NAME AS 'TIPE', IF(PAYMENT_CONFIRMED = 1, 'Y', 'N') AS STATUS, DATE_FORMAT(PAYMENT_DATE, '%d-%M-%Y') AS 'TANGGAL', PAYMENT_NOMINAL AS 'NOMINAL', PAYMENT_DESCRIPTION AS 'DESKRIPSI' FROM PAYMENT_DEBT PC, PAYMENT_METHOD PM WHERE PC.PM_ID = PM.PM_ID AND DEBT_ID = " + selectedDebtID;
            using (rdr = DS.getData(sqlCommand))
            {
                detailPaymentDataGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    detailPaymentDataGridView.DataSource = dt;

                    detailPaymentDataGridView.Columns["PAYMENT_ID"].Visible = false;
                    detailPaymentDataGridView.Columns["TANGGAL"].Width = 200;
                    detailPaymentDataGridView.Columns["NOMINAL"].Width = 200;
                    detailPaymentDataGridView.Columns["DESKRIPSI"].Width = 300;
                }
            }
        }

        private void calculateTotalDebt(bool globalCalculation = false)
        {
            double totalPayment = 0;

            if (globalCalculation)
            {
                globalTotalValue = Convert.ToDouble(DS.getDataSingleValue("SELECT PURCHASE_TOTAL FROM PURCHASE_HEADER WHERE PURCHASE_INVOICE = '" + selectedPOInvoice + "'"));
            }

            totalPayment = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PAYMENT_NOMINAL), 0) AS PAYMENT FROM PAYMENT_DEBT WHERE DEBT_ID = " + selectedDebtID));

            globalTotalValue = globalTotalValue - totalPayment;

            totalLabel.Text = globalTotalValue.ToString("C", culture);

            if (globalTotalValue <= 0)
                saveButton.Enabled = false;
        }

        private void totalPaymentMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            totalPaymentMaskedTextBox.Text = gutil.allTrim(totalPaymentMaskedTextBox.Text);
        }
        
        private bool dataValidated()
        {
            double nominalPayment;

            nominalPayment = Convert.ToDouble(totalPaymentMaskedTextBox.Text);
            if (nominalPayment > globalTotalValue)
            {
                if (DialogResult.Yes == MessageBox.Show("PEMBAYARAN MELEBIHI JUMLAH HUTANG, LANJUTKAN ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
            string paymentDateTime = "";
            DateTime selectedPaymentDate;
            double paymentNominal = 0;

            string paymentDescription = "";
            int paymentConfirmed = 0;

            MySqlException internalEX = null;

            selectedPaymentDate = paymentDateTimePicker.Value;
            paymentDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPaymentDate);
            paymentNominal = Convert.ToDouble(totalPaymentMaskedTextBox.Text);
            paymentDescription = descriptionTextBox.Text;

            if (paymentNominal > globalTotalValue)
                paymentNominal = globalTotalValue;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO PAYMENT_DEBT (DEBT_ID, PAYMENT_DATE, PM_ID, PAYMENT_NOMINAL, PAYMENT_DESCRIPTION, PAYMENT_CONFIRMED) VALUES " +
                                    "(" + selectedDebtID+ ", STR_TO_DATE('" + paymentDateTime + "', '%d-%m-%Y'), 1, " + paymentNominal + ", '" + paymentDescription + "', " + paymentConfirmed + ")";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                if (paymentNominal == globalTotalValue)
                {
                    // UPDATE CREDIT TABLE
                    sqlCommand = "UPDATE DEBT SET DEBT_PAID = 1 WHERE DEBT_ID = " + selectedDebtID;

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // UPDATE SALES HEADER TABLE
                    sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_PAID = 1 WHERE PURCHASE_INVOICE = '" + selectedPOInvoice + "'";

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
                    MessageBox.Show("UANG KEMBALI SEBESAR " + (Convert.ToDouble(totalPaymentMaskedTextBox.Text) - globalTotalValue).ToString("C", culture));
                }

                loadDataDetailPayment();
                calculateTotalDebt(true);
            }
        }

        private void pembayaranHutangForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            paymentDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            isLoading = true;

            loadDataHeaderPO();
            loadDataDetailPO();

            selectedDebtID = getDebtID();
            loadDataDetailPayment();

            calculateTotalDebt();

            isLoading = false;

            gutil.reArrangeTabOrder(this);
        }

        private void pembayaranHutangForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}

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

namespace AlphaSoft
{
    public partial class ReportPaymentSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportPaymentSearchForm()
        {
            InitializeComponent();
        }
        public ReportPaymentSearchForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void LoadSupplier()
        {
            SupplierNameCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER";
            }
            else
            {
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    SupplierNameCombobox.Visible = true;
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    SupplierNameCombobox.DataSource = dt;
                    SupplierNameCombobox.ValueMember = "ID";
                    SupplierNameCombobox.DisplayMember = "NAME";
                    SupplierNameCombobox.SelectedIndex = 0;
                }
                else
                {
                    SupplierNameCombobox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void LoadBranch()
        {
            BranchcomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT BRANCH_ID AS 'ID', BRANCH_NAME AS 'NAME' FROM MASTER_BRANCH";
            }
            else
            {
                SQLcommand = "SELECT BRANCH_ID AS 'ID', BRANCH_NAME AS 'NAME' FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    BranchcomboBox.Visible = true;
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    BranchcomboBox.DataSource = dt;
                    BranchcomboBox.ValueMember = "ID";
                    BranchcomboBox.DisplayMember = "NAME";
                    BranchcomboBox.SelectedIndex = 0;
                }
                else
                {
                    BranchcomboBox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void LoadCustomer()
        {
            CustomercomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER";
            }
            else
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    CustomercomboBox.Visible = true;
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    CustomercomboBox.DataSource = dt;
                    CustomercomboBox.ValueMember = "ID";
                    CustomercomboBox.DisplayMember = "NAME";
                    CustomercomboBox.SelectedIndex = 0;
                }
                else
                {
                    CustomercomboBox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void ReportPaymentSearchForm_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            switch (originModuleID)
            {
                case globalConstants.REPORT_DEBT_PAYMENT:
                    LabelOptions.Text = "Supplier";
                    SupplierNameCombobox.Visible = true;
                    CustomercomboBox.Visible = false;
                    BranchcomboBox.Visible = false;
                    LoadSupplier();
                    break;
                case globalConstants.REPORT_CREDIT_PAYMENT:
                    LabelOptions.Text = "Pelanggan";
                    CustomercomboBox.Visible = true;
                    SupplierNameCombobox.Visible = false;
                    BranchcomboBox.Visible = false;
                    LoadCustomer();
                    break;
                case globalConstants.REPORT_MUTATION_PAYMENT:
                    LabelOptions.Text = "Cabang";
                    CustomercomboBox.Visible = false;
                    SupplierNameCombobox.Visible = false;
                    BranchcomboBox.Visible = true;
                    LoadBranch();
                    break;
            }
            gutil.reArrangeTabOrder(this);
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            bool result;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";
            string supplier = "";
            string customer = "";
            string branch = "";
            if (ErrorLabel.Visible != true && checkBox1.Checked == true)
            {
                supplier = "AND PH.SUPPLIER_ID = " + SupplierNameCombobox.SelectedValue + " ";
                customer = "AND SH.CUSTOMER_ID = " + CustomercomboBox.SelectedValue + " ";
                branch = "AND PH.BRANCH_ID_TO = " + BranchcomboBox.SelectedValue + " ";
            }
            switch (originModuleID)
            {
                case globalConstants.REPORT_DEBT_PAYMENT:
                    sqlCommandx = "SELECT D.DEBT_ID AS' ID', D.DEBT_DUE_DATE AS 'JT', D.DEBT_NOMINAL AS 'TOTAL', D.PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', " +
                                    "MAX(PD.PAYMENT_CONFIRMED_DATE) AS 'TANGGALLUNAS' " +
                                    "FROM DEBT D, PURCHASE_HEADER PH, MASTER_SUPPLIER MS, PAYMENT_DEBT PD " +
                                    "WHERE D.DEBT_PAID = 1 AND D.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PH.SUPPLIER_ID = MS.SUPPLIER_ID AND D.DEBT_ID = PD.DEBT_ID " + supplier + 
                                    "AND DATE_FORMAT(PD.PAYMENT_CONFIRMED_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(PD.PAYMENT_CONFIRMED_DATE, '%Y%m%d') <= '" + dateTo + "'";
                    DS.writeXML(sqlCommandx, globalConstants.DebtPaidXML);
                    ReportDebtPaidForm displayedForm1 = new ReportDebtPaidForm();
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_CREDIT_PAYMENT:
                    sqlCommandx = "SELECT C.SALES_INVOICE AS 'INVOICE', C.CREDIT_NOMINAL AS 'TOTAL', C.CREDIT_DUE_DATE AS 'JT', " +
                                    "MAX(PC.PAYMENT_CONFIRMED_DATE) AS 'LUNAS', MC.CUSTOMER_FULL_NAME " +
                                    "FROM CREDIT C, PAYMENT_CREDIT PC, SALES_HEADER SH, MASTER_CUSTOMER MC " +
                                    "WHERE C.SALES_INVOICE IS NOT NULL AND C.CREDIT_PAID = 1 AND C.CREDIT_ID = PC.CREDIT_ID AND C.SALES_INVOICE = SH.SALES_INVOICE AND SH.CUSTOMER_ID = MC.CUSTOMER_ID " + customer +
                                    "AND DATE_FORMAT(PC.PAYMENT_CONFIRMED_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(PC.PAYMENT_CONFIRMED_DATE, '%Y%m%d') <= '" + dateTo + "'";
                    DS.writeXML(sqlCommandx, globalConstants.CreditPaidXML);
                    ReportCreditPaidForm displayedForm2 = new ReportCreditPaidForm();
                    displayedForm2.ShowDialog(this);
                    break;
                case globalConstants.REPORT_MUTATION_PAYMENT:
                    sqlCommandx = "SELECT C.PM_INVOICE AS 'INVOICE', C.CREDIT_NOMINAL AS 'TOTAL', C.CREDIT_DUE_DATE AS 'JT', " +
                                    "MAX(PC.PAYMENT_CONFIRMED_DATE) AS 'LUNAS', MB.BRANCH_NAME " +
                                    "FROM CREDIT C, PAYMENT_CREDIT PC, PRODUCTS_MUTATION_HEADER PH, MASTER_BRANCH MB " +
                                    "WHERE C.PM_INVOICE IS NOT NULL AND C.CREDIT_PAID = 1 AND C.CREDIT_ID = PC.CREDIT_ID AND C.PM_INVOICE = PH.PM_INVOICE AND PH.BRANCH_ID_TO = MB.BRANCH_ID " + branch +
                                    "AND DATE_FORMAT(PC.PAYMENT_CONFIRMED_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(PC.PAYMENT_CONFIRMED_DATE, '%Y%m%d') <= '" + dateTo + "'";
                    DS.writeXML(sqlCommandx, globalConstants.MutationPaidXML);
                    ReportCreditPaidForm displayedForm3 = new ReportCreditPaidForm();
                    displayedForm3.ShowDialog(this);
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_DEBT_PAYMENT:
                        SupplierNameCombobox.Enabled = true;
                        break;
                    case globalConstants.REPORT_CREDIT_PAYMENT:
                        CustomercomboBox.Enabled = true;
                        break;
                    case globalConstants.REPORT_MUTATION_PAYMENT:
                        BranchcomboBox.Enabled = true;
                        break;
                }
            }
            else
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_DEBT_PAYMENT:
                        SupplierNameCombobox.Enabled = false;
                        break;
                    case globalConstants.REPORT_CREDIT_PAYMENT:
                        CustomercomboBox.Enabled = false;
                        break;
                    case globalConstants.REPORT_MUTATION_PAYMENT:
                        BranchcomboBox.Enabled = false;
                        break;
                }
            }
        }
    }
}

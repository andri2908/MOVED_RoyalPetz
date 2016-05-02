using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace RoyalPetz_ADMIN
{
    public partial class ReportSalesSummarySearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportSalesSummarySearchForm()
        {
            InitializeComponent();
        }

        public ReportSalesSummarySearchForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void loadcustomer()
        {
            CustNameCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER";
            } else
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1"; 
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    DataRow workRow = dt.NewRow();
                    workRow["ID"] = "0";
                    workRow["NAME"] = "P-UMUM";
                    dt.Load(rdr);
                    dt.Rows.Add(workRow);
                    CustNameCombobox.DataSource = dt;
                    CustNameCombobox.ValueMember = "ID";
                    CustNameCombobox.DisplayMember = "NAME";
                }
                else
                {
                    CustNameCombobox.ValueMember = "ID";
                    CustNameCombobox.DisplayMember = "NAME";
                    CustNameCombobox.Items.Insert(0, "P-UMUM");
                }
            }
            //CustNameCombobox.SelectedIndex = 0;
            CustNameCombobox.SelectedIndex = CustNameCombobox.FindStringExact("P-UMUM");
        }

        private void ReportSalesSummarySearchForm_Load(object sender, EventArgs e)
        {
            //load data customer
            loadcustomer();
            gutil.reArrangeTabOrder(this);
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            int cust_id = 0;
            bool result = int.TryParse(CustNameCombobox.Items[CustNameCombobox.SelectedIndex].ToString(), out cust_id);
            if (result)
            {

            } else
            {
                cust_id = 0;
            }
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            if (originModuleID == globalConstants.REPORT_SALES_SUMMARY)
            {
                string sqlCommandx = "SELECT SALES_INVOICE AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE',S.SALES_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP' " +
                                        "FROM SALES_HEADER S,MASTER_CUSTOMER C " +
                                        "WHERE S.CUSTOMER_ID = C.CUSTOMER_ID AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' AND S.CUSTOMER_ID = " + cust_id + " " +
                                        "UNION " +
                                        "SELECT S.SALES_INVOICE AS 'INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE', S.SALES_TOTAL AS 'TOTAL', 'RETAIL' AS 'GROUP' " +
                                        "FROM SALES_HEADER S " +
                                        "WHERE DATE_FORMAT(S.SALES_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(S.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' AND S.CUSTOMER_ID = 0";
                DS.writeXML(sqlCommandx, globalConstants.SalesSummaryXML);
                ReportSalesSummaryForm displayedForm = new ReportSalesSummaryForm();
                displayedForm.ShowDialog(this);
            } else
            {
                string sqlCommandx = "SELECT SD.ID, SH.SALES_DATE AS 'DATE', SD.SALES_INVOICE AS 'INVOICE', MC.CUSTOMER_FULL_NAME AS 'CUSTOMER', M.PRODUCT_NAME AS 'PRODUCT', PRODUCT_QTY AS 'QTY', " +
                "PRODUCT_SALES_PRICE AS 'PRICE', ROUND((PRODUCT_QTY * PRODUCT_SALES_PRICE) - SALES_SUBTOTAL, 2) AS 'POTONGAN', SALES_SUBTOTAL AS 'SUBTOTAL', SH.SALES_PAYMENT AS 'PAYMENT', SH.SALES_PAYMENT_CHANGE AS 'CHANGE' " +
                "FROM SALES_HEADER SH, SALES_DETAIL SD, MASTER_PRODUCT M, MASTER_CUSTOMER MC WHERE SD.PRODUCT_ID = M.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "' AND SH.CUSTOMER_ID = " + cust_id +
                " UNION " +
                "SELECT SD.ID, SH.SALES_DATE AS 'DATE', SD.SALES_INVOICE AS 'INVOICE', 'P-UMUM' AS 'CUSTOMER', M.PRODUCT_NAME AS 'PRODUCT', PRODUCT_QTY AS 'QTY', PRODUCT_SALES_PRICE AS 'PRICE', " +
                "ROUND((PRODUCT_QTY * PRODUCT_SALES_PRICE) - SALES_SUBTOTAL, 2) AS 'POTONGAN', SALES_SUBTOTAL AS 'SUBTOTAL', SH.SALES_PAYMENT AS 'PAYMENT', SH.SALES_PAYMENT_CHANGE AS 'CHANGE' " +
                "FROM SALES_HEADER SH, SALES_DETAIL SD, MASTER_PRODUCT M WHERE SD.PRODUCT_ID = M.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND SH.CUSTOMER_ID = 0 AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d')  <= '" + dateTo + "'";
                DS.writeXML(sqlCommandx, globalConstants.SalesDetailedXML);
                ReportSalesDetailedForm displayedForm = new ReportSalesDetailedForm();
                displayedForm.ShowDialog(this);

            }
        }

        private void nonactivecheckbox_CheckedChanged(object sender, EventArgs e)
        {
            loadcustomer();
        }
    }
}

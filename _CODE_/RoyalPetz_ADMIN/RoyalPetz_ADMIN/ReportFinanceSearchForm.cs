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
    public partial class ReportFinanceSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportFinanceSearchForm()
        {
            InitializeComponent();
        }

        public ReportFinanceSearchForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";

            switch (originModuleID)
            {
                case globalConstants.REPORT_FINANCE_IN:
                    sqlCommandx = "SELECT DJ.JOURNAL_DATETIME AS 'TGL', MA.ACCOUNT_NAME AS 'AKUN', DJ.JOURNAL_NOMINAL AS 'JML', DJ.JOURNAL_DESCRIPTION AS 'DESKRIPSI' " +
                                    "FROM DAILY_JOURNAL DJ, MASTER_ACCOUNT MA " +
                                    "WHERE DJ.ACCOUNT_ID = MA.ACCOUNT_ID AND MA.ACCOUNT_TYPE_ID = 1 AND DJ.BRANCH_ID = 0 " +
                                    "AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') <= '" + dateTo + "'";
                    DS.writeXML(sqlCommandx, globalConstants.FinanceInXML);
                    ReportCashierLogForm displayedForm1 = new ReportCashierLogForm();
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_FINANCE_OUT:
                    sqlCommandx = "SELECT DJ.JOURNAL_DATETIME AS 'TGL', MA.ACCOUNT_NAME AS 'AKUN', DJ.JOURNAL_NOMINAL AS 'JML', DJ.JOURNAL_DESCRIPTION AS 'DESKRIPSI' " +
                                    "FROM DAILY_JOURNAL DJ, MASTER_ACCOUNT MA " +
                                    "WHERE DJ.ACCOUNT_ID = MA.ACCOUNT_ID AND MA.ACCOUNT_TYPE_ID = 2 AND DJ.BRANCH_ID = 0 " +
                                    "AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') <= '" + dateTo + "'";
                    DS.writeXML(sqlCommandx, globalConstants.FinanceOutXML);
                    ReportFinanceOutForm displayedForm2 = new ReportFinanceOutForm();
                    displayedForm2.ShowDialog(this);
                    break;
                case globalConstants.REPORT_MARGIN:
                    sqlCommandx = "SELECT DATE(SH.SALES_DATE) AS 'TGL', SUM((SD.SALES_SUBTOTAL-(SD.PRODUCT_QTY*SD.PRODUCT_PRICE))) AS 'MARGIN' " +
                                    "FROM SALES_HEADER SH, SALES_DETAIL SD " +
                                    "WHERE SH.SALES_PAID = 1 AND SH.SALES_INVOICE = SD.SALES_INVOICE " +
                                    "AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY DATE(SH.SALES_DATE)";
                    DS.writeXML(sqlCommandx, globalConstants.MarginXML);
                    ReportMarginForm displayedForm3 = new ReportMarginForm();
                    displayedForm3.ShowDialog(this);
                    break;
            }
            
        }

        private void ReportFinanceSearchForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}

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

        public int caritanggal(int mode=0) //0=start 1=finish
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            int rslt = 0;
            string sqlcommand = "SELECT ";
            if (mode == 0)
            {
                sqlcommand = sqlcommand + "MIN";
            }
            else
            {
                sqlcommand = sqlcommand + "MAX";
            }
            sqlcommand = sqlcommand + "(TGL) AS 'TGL_OUT' FROM daysmonth";

            DS.mySqlConnect();
            using (rdr = DS.getData(sqlcommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        rslt = rdr.GetInt16("TGL_OUT");
                    }
                }
            }
            return rslt;
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
                case globalConstants.REPORT_MONTHLY_BALANCE:
                    int days = DateTime.DaysInMonth(Int32.Parse(MonthPicker.Value.ToString("yyyy")), Int32.Parse(MonthPicker.Value.ToString("MM")));
                    string monthname = MonthPicker.Value.ToString("MMMM");
                    DS.beginTransaction();
                    try
                    {
                        DS.mySqlConnect(); sqlCommandx = "DROP TABLE `daysmonth`";
                        DS.executeNonQueryCommand(sqlCommandx);
                        sqlCommandx = "CREATE TABLE `daysmonth` (" +
                                      "`TGL` tinyint(4) unsigned NOT NULL," +
                                      "PRIMARY KEY (`TGL`)" +
                                      ") ENGINE = InnoDB DEFAULT CHARSET = utf8";
                        DS.executeNonQueryCommand(sqlCommandx);
                        for (int i = 1; i <= days; i++)
                        {
                            sqlCommandx = "INSERT INTO `daysmonth` (`TGL`) VALUES (" + i + ")";
                            DS.executeNonQueryCommand(sqlCommandx);
                        }
                        DS.commit();
                    }
                    catch (Exception excp)
                    {
                        try
                        {
                            //myTrans.Rollback();
                        }
                        catch (MySqlException ex)
                        {
                            if (DS.getMyTransConnection() != null)
                            {
                                MessageBox.Show("An exception of type " + ex.GetType() +
                                                  " was encountered while attempting to roll back the transaction.");
                            }
                        }

                        MessageBox.Show("An exception of type " + e.GetType() +
                                          " was encountered while inserting the data.");
                        MessageBox.Show("Neither record was written to database.");
                    }
                    finally
                    {
                        DS.mySqlClose();
                    }

                    sqlCommandx = "SELECT tab1.TGL,tab1.DEBET,IF(tab2.KREDIT IS NULL,0,tab2.KREDIT) AS 'KREDIT' from " +
                                    "(SELECT tab1.TGL, IF(tab1.DEBET IS NULL, 0, tab1.DEBET) + IF(tab2.debet IS NULL, 0, tab2.DEBET) as 'DEBET' FROM " +
                                    "(SELECT TAB1.TGL, TAB2.DEBET from(SELECT TGL from daysmonth) tab1 left outer join(SELECT DATE_FORMAT(DJ.JOURNAL_DATETIME, '%d') AS 'TGL', " +
                                    "DJ.JOURNAL_NOMINAL AS 'DEBET' FROM DAILY_JOURNAL DJ, MASTER_ACCOUNT MA " +
                                    "WHERE DJ.ACCOUNT_ID = MA.ACCOUNT_ID AND MA.ACCOUNT_TYPE_ID = 1 AND DJ.BRANCH_ID = 0 " +
                                    "AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') <= '" + dateTo + "') tab2 " +
                                    "on tab1.TGL = tab2.TGL) tab1 " +
                                    "left outer join " +
                                    "(SELECT DATE_FORMAT(SH.SALES_DATE, '%d') AS 'TGL', IF(SUM((SD.SALES_SUBTOTAL - (SD.PRODUCT_QTY * SD.PRODUCT_PRICE))) IS NULL, 0, SUM((SD.SALES_SUBTOTAL - (SD.PRODUCT_QTY * SD.PRODUCT_PRICE)))) AS 'DEBET' " +
                                    "FROM SALES_HEADER SH, SALES_DETAIL SD " +
                                    "WHERE SH.SALES_PAID = 1 AND SH.SALES_INVOICE = SD.SALES_INVOICE " +
                                    "AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(SH.SALES_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY DATE(SH.SALES_DATE)) tab2 " +
                                    "on tab1.TGL = tab2.TGL) tab1 " +
                                    "left outer join " +
                                    "(SELECT DATE_FORMAT(DJ.JOURNAL_DATETIME, '%d') AS 'TGL', IF(SUM(DJ.JOURNAL_NOMINAL) IS NULL, 0, -SUM(DJ.JOURNAL_NOMINAL)) AS 'KREDIT' " +
                                    "FROM DAILY_JOURNAL DJ, MASTER_ACCOUNT MA " +
                                    "WHERE DJ.ACCOUNT_ID = MA.ACCOUNT_ID AND MA.ACCOUNT_TYPE_ID = 2 AND DJ.BRANCH_ID = 0 " +
                                    "AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(DJ.JOURNAL_DATETIME, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY DATE(DJ.JOURNAL_DATETIME)) tab2 " +
                                    "on tab1.TGL = tab2.TGL";
                    DS.writeXML(sqlCommandx, globalConstants.MonthlyBalanceXML);
                    ReportMonthlyBalanceForm displayedForm4 = new ReportMonthlyBalanceForm(monthname);
                    displayedForm4.ShowDialog(this);
                    break;
            }
            
        }

        private void ReportFinanceSearchForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            if (originModuleID == globalConstants.REPORT_MONTHLY_BALANCE)
            {
                label2.Visible = false;
                datetoPicker.Visible = false;
                datefromPicker.Visible = false;
                MonthPicker.Visible = true;
                MonthPicker.CustomFormat = globalUtilities.CUSTOM_MONTH_FORMAT;
                MonthPicker.ShowUpDown = true;
            }
        }
    }
}

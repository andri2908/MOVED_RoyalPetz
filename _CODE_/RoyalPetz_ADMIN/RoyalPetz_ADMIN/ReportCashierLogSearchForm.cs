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
    public partial class ReportCashierLogSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();

        public ReportCashierLogSearchForm()
        {
            InitializeComponent();
        }

        private void LoadUserID()
        {
            UserIDCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = "SELECT ID AS 'ID', USER_FULL_NAME AS 'NAME' FROM MASTER_USER";
            }
            else
            {
                SQLcommand = "SELECT ID AS 'ID', USER_FULL_NAME AS 'NAME' FROM MASTER_USER WHERE USER_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    UserIDCombobox.Visible = true;
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    UserIDCombobox.DataSource = dt;
                    UserIDCombobox.ValueMember = "ID";
                    UserIDCombobox.DisplayMember = "NAME";
                    UserIDCombobox.SelectedIndex = 0;
                }
                else
                {
                    UserIDCombobox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void ReportCashierLogSearchForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            ErrorLabel.Text = "";
            LoadUserID();
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
            if (ErrorLabel.Visible == true)
            {
                supplier = "AND PH.SUPPLIER_ID = '" + UserIDCombobox.SelectedValue + "' ";
            }
            sqlCommandx = "SELECT PH.PURCHASE_DATETIME AS 'TGL', PH.PURCHASE_DATE_RECEIVED AS 'TERIMA', PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', PH.PURCHASE_TOTAL AS 'TOTAL', IF(PH.PURCHASE_TERM_OF_PAYMENT>0,'KREDIT','TUNAI') AS 'TOP', PH.PURCHASE_TERM_OF_PAYMENT_DURATION AS 'HARI', IF(PH.PURCHASE_PAID>0,'LUNAS','BELUM LUNAS') AS 'STATUS' " +
                                        "FROM PURCHASE_HEADER PH, MASTER_SUPPLIER MS " +
                                        "WHERE PH.SUPPLIER_ID = MS.SUPPLIER_ID " + supplier + "AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "' " +
                                        "ORDER BY TGL";
            DS.writeXML(sqlCommandx, globalConstants.CashierLogXML);
            ReportPurchaseSummaryForm displayedForm1 = new ReportPurchaseSummaryForm();
            displayedForm1.ShowDialog(this);
        }
    }
}

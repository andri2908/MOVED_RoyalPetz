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

namespace AlphaSoft
{
    public partial class ReportCustomerSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportCustomerSearchForm()
        {
            InitializeComponent();
        }

        private void loadCustomer()
        {
            customerComboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            
            string SQLcommand = "SELECT CUSTOMER_ID as 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER ";
            if (nonactivecheckbox.Checked)
            {
                SQLcommand = SQLcommand + "ORDER BY CUSTOMER_FULL_NAME ASC";
            }
            else
            {
                SQLcommand = SQLcommand + "WHERE CUSTOMER_ACTIVE = 1 ORDER BY CUSTOMER_FULL_NAME ASC";
            }
            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    customerComboBox.DataSource = dt;
                    customerComboBox.ValueMember = "ID";
                    customerComboBox.DisplayMember = "NAME";
                    customerComboBox.SelectedIndex = 0;
                }
                else
                {
                    ErrorLabel.Visible = true;
                    customerComboBox.Visible = false;
                    nonactivecheckbox.Visible = false;
                }
            }
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string sqlCommandx = "";
            sqlCommandx = "SELECT CUSTOMER_FULL_NAME AS 'NAMA CUSTOMER', CUSTOMER_ADDRESS1 AS 'ALAMAT 1', CUSTOMER_ADDRESS2 AS 'ALAMAT 2', " +
                                    "CUSTOMER_ADDRESS_CITY AS 'KOTA', CUSTOMER_PHONE AS 'TELEPON', CUSTOMER_FAX AS 'FAX', CUSTOMER_EMAIL AS 'EMAIL', " +
                                    "IF(CUSTOMER_GROUP = 1, 'ECER', IF(CUSTOMER_GROUP = 2, 'GROSIR', 'PARTAI')) AS 'GROUP' FROM MASTER_CUSTOMER " +
                                    "WHERE CUSTOMER_ACTIVE = 1 AND CUSTOMER_FULL_NAME = '" + customerComboBox.Text + "' ORDER BY CUSTOMER_FULL_NAME ASC";
            DS.writeXML(sqlCommandx, globalConstants.CustomerXML);
            ReportCustomerForm displayedform = new ReportCustomerForm();
            displayedform.ShowDialog(this);
        }

        private void nonactivecheckbox_CheckedChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void ReportCustomerSearchForm_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }
    }
}

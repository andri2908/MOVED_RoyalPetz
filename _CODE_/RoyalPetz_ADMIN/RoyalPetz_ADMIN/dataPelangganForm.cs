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

namespace RoyalPetz_ADMIN
{
    public partial class dataPelangganForm : Form
    {
        private int selectedCustomerID = 0;
        private globalUtilities gutil = new globalUtilities();
        cashierForm parentForm;
        int originModuleID = 0;

        private Data_Access DS = new Data_Access();

        public dataPelangganForm()
        {
            InitializeComponent();
        }

        public dataPelangganForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            if (originModuleID == globalConstants.CASHIER_MODULE)
                newButton.Visible = false;
        }

        public dataPelangganForm(int moduleID, cashierForm originForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = originForm;

            if (originModuleID == globalConstants.CASHIER_MODULE)
                newButton.Visible = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataPelangganDetailForm displayForm = new dataPelangganDetailForm(globalConstants.NEW_CUSTOMER);
            displayForm.ShowDialog(this);
        }

        private void loadCustomerData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            if (namaPelangganTextbox.Text.Equals(""))
                return;

            if (pelanggangnonactiveoption.Checked == true)
            {
                sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%M-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'PARTAI', 'GROSIR')) AS 'GROUP CUSTOMER' FROM MASTER_CUSTOMER WHERE CUSTOMER_FULL_NAME LIKE '%" + namaPelangganTextbox.Text + "%'";
            }
            else {
                sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%M-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'PARTAI', 'GROSIR')) AS 'GROUP CUSTOMER' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1 AND CUSTOMER_FULL_NAME LIKE '%" + namaPelangganTextbox.Text + "%'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPelangganDataGridView.DataSource = dt;

                    dataPelangganDataGridView.Columns["CUSTOMER_ID"].Visible = false;
                    dataPelangganDataGridView.Columns["NAMA PELANGGAN"].Width = 300;
                    dataPelangganDataGridView.Columns["TANGGAL BERGABUNG"].Width = 200;
                    dataPelangganDataGridView.Columns["GROUP CUSTOMER"].Width = 200;
                }
            }
        }

        private void dataPelangganForm_Activated(object sender, EventArgs e)
        {
            //loadCustomerData();
            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }
        }

        private void namaPelangganTextbox_TextChanged(object sender, EventArgs e)
        {
            //loadCustomerData();
            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }
        }

        private void dataPelangganDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataPelangganDataGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataPelangganDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataPelangganDataGridView.Rows[selectedrowindex];
            selectedCustomerID= Convert.ToInt32(selectedRow.Cells["CUSTOMER_ID"].Value);

            if (originModuleID == globalConstants.CASHIER_MODULE)
            {
                parentForm.setCustomerID(selectedCustomerID);
                this.Close();
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
            {
                dataReturPenjualanForm displayedReturForm = new dataReturPenjualanForm(originModuleID, "", selectedCustomerID);
                displayedReturForm.ShowDialog(this);
            }
            else
            {
                dataPelangganDetailForm displayedForm = new dataPelangganDetailForm(globalConstants.EDIT_CUSTOMER, selectedCustomerID);
                displayedForm.ShowDialog(this);
            }
        }

        private void dataPelangganForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void pelanggangnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataPelangganDataGridView.DataSource = null;

            if (!namaPelangganTextbox.Text.Equals(""))
            {
                loadCustomerData();
            }
            
        }

        private void dataPelangganDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataPelangganDataGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = dataPelangganDataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataPelangganDataGridView.Rows[selectedrowindex];
                selectedCustomerID = Convert.ToInt32(selectedRow.Cells["CUSTOMER_ID"].Value);

                if (originModuleID == globalConstants.CASHIER_MODULE)
                {
                    parentForm.setCustomerID(selectedCustomerID);
                    this.Close();
                }
                else if (originModuleID == globalConstants.RETUR_PENJUALAN_STOCK_ADJUSTMENT)
                {
                    dataReturPenjualanForm displayDataReturPenjualan = new dataReturPenjualanForm(originModuleID, "", selectedCustomerID);
                    displayDataReturPenjualan.ShowDialog(this);
                }
                else 
                {
                    dataPelangganDetailForm displayedForm = new dataPelangganDetailForm(globalConstants.EDIT_CUSTOMER, selectedCustomerID);
                    displayedForm.ShowDialog(this);
                }
            }
        }
    }
}

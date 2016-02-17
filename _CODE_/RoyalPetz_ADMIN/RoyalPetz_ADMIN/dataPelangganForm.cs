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

        private Data_Access DS = new Data_Access();

        public dataPelangganForm()
        {
            InitializeComponent();
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

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME AS 'NAMA PELANGGAN', DATE_FORMAT(CUSTOMER_JOINED_DATE,'%d-%m-%Y') AS 'TANGGAL BERGABUNG', IF(CUSTOMER_GROUP = 1,'ECER', IF(CUSTOMER_GROUP = 2,'PARTAI', 'GROSIR')) AS 'GROUP CUSTOMER' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1 AND CUSTOMER_FULL_NAME LIKE '%" + namaPelangganTextbox.Text + "%'";
            
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
            loadCustomerData();
        }

        private void namaPelangganTextbox_TextChanged(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void dataPelangganDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataPelangganDataGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataPelangganDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataPelangganDataGridView.Rows[selectedrowindex];
            selectedCustomerID= Convert.ToInt32(selectedRow.Cells["CUSTOMER_ID"].Value);

            dataPelangganDetailForm displayedForm = new dataPelangganDetailForm(globalConstants.EDIT_CUSTOMER, selectedCustomerID);
            displayedForm.ShowDialog(this);
        }
    }
}

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
    public partial class dataInvoiceForm : Form
    {
        private int originModuleID = 0;
        private string selectedSO = "";
        private string selectedCustomerID = "";

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        public dataInvoiceForm()
        {
            InitializeComponent();
        }

        public dataInvoiceForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void dataInvoiceDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataInvoiceDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = dataInvoiceDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataInvoiceDataGridView.Rows[rowSelectedIndex];
            selectedSO = selectedRow.Cells["SALES_INVOICE"].Value.ToString();

            switch(originModuleID)
            {
                case globalConstants.PEMBAYARAN_PIUTANG:
                    pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                    pembayaranForm.ShowDialog(this);
                    break;

                case globalConstants.RETUR_PENJUALAN:
                    dataReturPenjualanForm displayedForm = new dataReturPenjualanForm(originModuleID, selectedSO);
                    displayedForm.ShowDialog(this);
                    break;
            }

        }

        private void fillInPelangganCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT * FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    pelangganCombo.Items.Clear();
                    pelangganComboHidden.Items.Clear();
                    while (rdr.Read())
                    {
                        pelangganCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        pelangganComboHidden.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            if (originModuleID == globalConstants.RETUR_PENJUALAN)
                sqlCommand = "SELECT SALES_INVOICE, CUSTOMER_FULL_NAME FROM SALES_HEADER H LEFT OUTER JOIN MASTER_CUSTOMER M ON " +
                                    "(H.CUSTOMER_ID = M.CUSTOMER_ID) WHERE 1 = 1 ";
            else if (originModuleID == globalConstants.PEMBAYARAN_PIUTANG)
                sqlCommand = "SELECT CREDIT.SALES_INVOICE, CUSTOMER_FULL_NAME FROM SALES_HEADER H LEFT OUTER JOIN MASTER_CUSTOMER M ON " +
                                    "(H.CUSTOMER_ID = M.CUSTOMER_ID), CREDIT WHERE H.SALES_INVOICE = CREDIT.SALES_INVOICE ";

            if (!showAllCheckBox.Checked)
            {
                if (pelangganCombo.SelectedIndex >= 0)
                {
                    sqlCommand = sqlCommand + "AND H.CUSTOMER_ID = " + selectedCustomerID + " ";
                }

                if (noInvoiceTextBox.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + "AND H.SALES_INVOICE like '%" + noInvoiceTextBox.Text + "%' ";
                }

                sqlCommand = sqlCommand + "AND SALES_PAID = 0";
            }

            using(rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataInvoiceDataGridView.DataSource = dt;

                    dataInvoiceDataGridView.Columns["SALES_INVOICE"].Width = 200;
                    dataInvoiceDataGridView.Columns["CUSTOMER_FULL_NAME"].Width = 300;
                }
            }
            rdr.Close();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void pelangganCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomerID = pelangganComboHidden.Items[pelangganCombo.SelectedIndex].ToString();
        }

        private void pelangganCombo_Validated(object sender, EventArgs e)
        {
            if (!pelangganCombo.Items.Contains(pelangganCombo.Text))
            { 
                pelangganCombo.Focus();
                pelangganCombo.BackColor = Color.Red;
            }
            else
            {
                pelangganCombo.BackColor = Color.White;
            }
        }

        private void dataInvoiceForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            fillInPelangganCombo();
        }

        private void dataInvoiceDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataInvoiceDataGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = dataInvoiceDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataInvoiceDataGridView.Rows[rowSelectedIndex];
                selectedSO = selectedRow.Cells["SALES_INVOICE"].Value.ToString();

                switch (originModuleID)
                {
                    case globalConstants.PEMBAYARAN_PIUTANG:
                        pembayaranPiutangForm pembayaranForm = new pembayaranPiutangForm(selectedSO);
                        pembayaranForm.ShowDialog(this);
                        break;

                    case globalConstants.RETUR_PENJUALAN:
                        dataReturPenjualanForm displayedForm = new dataReturPenjualanForm(originModuleID, selectedSO);
                        displayedForm.ShowDialog(this);
                        break;
                }
            }
        }

    }
}

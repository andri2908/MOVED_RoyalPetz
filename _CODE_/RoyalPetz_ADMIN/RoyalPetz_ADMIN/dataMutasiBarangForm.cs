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
    public partial class dataMutasiBarangForm : Form
    {
        private int originModuleID = 0;
        private string selectedROID;

        private Data_Access DS = new Data_Access();

        public dataMutasiBarangForm()
        {
            InitializeComponent();
        }

        public dataMutasiBarangForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if (moduleID != globalConstants.CEK_DATA_MUTASI)
                newButton.Visible = false;
        }

        private void displaySpecificForm(string PMInvoice = "")
        {
            int subModuleID;
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                    if (!PMInvoice.Equals(""))
                        subModuleID = globalConstants.VIEW_PRODUCT_MUTATION;
                    else
                        subModuleID = globalConstants.MUTASI_BARANG;

                        dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm(subModuleID, PMInvoice);
                        displayedForm.ShowDialog(this);
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                        penerimaanBarangForm penerimaanBarangDisplayedForm = new penerimaanBarangForm();
                        penerimaanBarangDisplayedForm.ShowDialog(this);
                    break;
            }
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataRequestOrderGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
            selectedROID = selectedRow.Cells["NO MUTASI"].Value.ToString();

            displaySpecificForm(selectedROID);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            displaySpecificForm();
        }

        private void loadROdata()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            //sqlCommand = "SELECT ID, RO_INVOICE AS 'NO PERMINTAAN', RO_DATETIME AS 'TANGGAL PERMINTAAN', RO_EXPIRED AS 'TANGGAL EXPIRED', M1.BRANCH_NAME AS 'ASAL PERMINTAAN', M2.BRANCH_NAME AS 'TUJUAN PERMINTAAN', RO_TOTAL AS 'TOTAL' " +
             //                   "FROM REQUEST_ORDER_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (RO_BRANCH_ID_FROM = M1.BRANCH_ID) " +
              //                  "LEFT OUTER JOIN MASTER_BRANCH M2 ON (RO_BRANCH_ID_TO = M2.BRANCH_ID) " +
               //                 "WHERE RO_ACTIVE = 1 AND RO_EXPIRED > '" + DateTime.Now + "'";

            sqlCommand = "SELECT ID, PM_INVOICE AS 'NO MUTASI', PM_DATETIME AS 'TANGGAL MUTASI', M1.BRANCH_NAME AS 'ASAL MUTASI', M2.BRANCH_NAME AS 'TUJUAN MUTASI', PM_TOTAL AS 'TOTAL', RO_INVOICE AS 'NO PERMINTAAN' " +
                                "FROM PRODUCTS_MUTATION_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (BRANCH_ID_FROM = M1.BRANCH_ID) " +
                                "LEFT OUTER JOIN MASTER_BRANCH M2 ON (BRANCH_ID_TO = M2.BRANCH_ID) " +
                                "ORDER BY PM_DATETIME ASC";                                

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataRequestOrderGridView.DataSource = dt;

                    dataRequestOrderGridView.Columns["ID"].Visible = false;

                    dataRequestOrderGridView.Columns["NO MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TANGGAL MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["ASAL MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TUJUAN MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TOTAL"].Width = 200;
                    dataRequestOrderGridView.Columns["NO PERMINTAAN"].Width = 200;
                }

                rdr.Close();
            }


        }

        private void dataMutasiBarangForm_Load(object sender, EventArgs e)
        {

        }

        private void dataMutasiBarangForm_Deactivate(object sender, EventArgs e)
        {

        }

        private void dataMutasiBarangForm_Activated(object sender, EventArgs e)
        {
            loadROdata();
        }

        private void dataRequestOrderGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataRequestOrderGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataRequestOrderGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
                selectedROID = selectedRow.Cells["NO MUTASI"].Value.ToString();

                displaySpecificForm(selectedROID);
            }
        }
    }
}

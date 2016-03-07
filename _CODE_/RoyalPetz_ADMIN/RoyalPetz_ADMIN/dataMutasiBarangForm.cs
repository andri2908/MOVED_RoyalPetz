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
    public partial class dataMutasiBarangForm : Form
    {
        private int originModuleID = 0;
        private string selectedROID;
        private int selectedBranchFromID = 0;
        private int selectedBranchToID = 0;
        private CultureInfo culture = new CultureInfo("id-ID");
        private globalUtilities gutil = new globalUtilities();
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
                        penerimaanBarangForm penerimaanBarangDisplayedForm = new penerimaanBarangForm(globalConstants.PENERIMAAN_BARANG_DARI_MUTASI, selectedROID);
                        penerimaanBarangDisplayedForm.ShowDialog(this);
                    break;
            }

            loadROdata();
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
            string dateFrom;
            string dateTo;

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM_DATETIME,'%d-%M-%Y') AS 'TGL MUTASI', M1.BRANCH_NAME AS 'ASAL MUTASI', M2.BRANCH_NAME AS 'TUJUAN MUTASI', PM_TOTAL AS 'TOTAL', RO_INVOICE AS 'NO PERMINTAAN' " +
                                "FROM PRODUCTS_MUTATION_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (BRANCH_ID_FROM = M1.BRANCH_ID) " +
                                "LEFT OUTER JOIN MASTER_BRANCH M2 ON (BRANCH_ID_TO = M2.BRANCH_ID) " +
                                "WHERE 1 = 1 AND PM_RECEIVED = 0";

            if (!showAllCheckBox.Checked)
            {
                if (noMutasiTextBox.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND PM_INVOICE LIKE '%" + noMutasiTextBox.Text + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PMDtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PMDtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(PM_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PM_DATETIME, '%Y%m%d')  <= '" + dateTo + "'";

                if (branchFromCombo.SelectedIndex > 0)
                {
                    sqlCommand = sqlCommand + " AND BRANCH_ID_FROM = " + selectedBranchFromID;
                }

                if (branchToCombo.SelectedIndex > 0)
                {
                    sqlCommand = sqlCommand + " AND BRANCH_ID_TO = " + selectedBranchToID;
                }
            }
                
            sqlCommand = sqlCommand + " ORDER BY PM_DATETIME ASC";                                

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataRequestOrderGridView.DataSource = dt;

                    dataRequestOrderGridView.Columns["ID"].Visible = false;

                    dataRequestOrderGridView.Columns["NO MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TGL MUTASI"].Width = 200;
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
            PMDtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PMDtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            gutil.reArrangeTabOrder(this);
        }

        private void dataMutasiBarangForm_Deactivate(object sender, EventArgs e)
        {

        }

        private void dataMutasiBarangForm_Activated(object sender, EventArgs e)
        {
            //loadROdata();
            fillInBranchCombo(branchFromCombo, branchFromComboHidden);
            fillInBranchCombo(branchToCombo, branchToComboHidden);
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

        private void fillInBranchCombo(ComboBox visibleCombo, ComboBox hiddenCombo)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1 ORDER BY BRANCH_NAME ASC";

            visibleCombo.Items.Clear();
            hiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    visibleCombo.Items.Add(rdr.GetString("BRANCH_NAME"));
                    hiddenCombo.Items.Add(rdr.GetString("BRANCH_ID"));
                }
            }

            rdr.Close();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadROdata();
        }

        private void branchFromCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchFromID = Convert.ToInt32(branchFromComboHidden.Items[branchFromCombo.SelectedIndex]);
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchToID = Convert.ToInt32(branchToComboHidden.Items[branchToCombo.SelectedIndex]);
        }


    }
}

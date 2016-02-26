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
    public partial class dataPermintaanForm : Form
    {
        private int originModuleID = 0;
        private int selectedBranchFromID = 0;
        private int selectedBranchToID = 0;
        private int selectedROID = 0;

        private Data_Access DS = new Data_Access();

        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

        public dataPermintaanForm()
        {
            InitializeComponent();
        }

        public dataPermintaanForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if (moduleID == globalConstants.CEK_DATA_MUTASI)
                newButton.Visible = false;
        }
        
        private void displaySpecificForm(int roID = 0)
        {
            switch (originModuleID)
            {
                case globalConstants.PERMINTAAN_BARANG:
                    if (roID == 0)
                    {
                        permintaanProdukForm requestOrderForm = new permintaanProdukForm(globalConstants.NEW_REQUEST_ORDER);
                        requestOrderForm.ShowDialog(this);
                    }
                    else
                    {
                        permintaanProdukForm editRequestOrderForm = new permintaanProdukForm(globalConstants.EDIT_REQUEST_ORDER, roID);
                        editRequestOrderForm.ShowDialog(this);
                    }
                    break;

                case globalConstants.CEK_DATA_MUTASI:
                    dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm(globalConstants.CEK_DATA_MUTASI, roID);
                    displayedForm.ShowDialog(this);
                    break;




                case globalConstants.PEMBAYARAN_HUTANG:
                    pembayaranHutangForm pembayaranForm = new pembayaranHutangForm();
                    pembayaranForm.ShowDialog(this);
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                    penerimaanBarangForm penerimaanBarangDisplayedForm = new penerimaanBarangForm();
                    penerimaanBarangDisplayedForm.ShowDialog(this);
                    break;

                default:
                    dataReturPermintaanForm returPermintaanBarangDisplayedForm = new dataReturPermintaanForm();
                    returPermintaanBarangDisplayedForm.ShowDialog(this);
                    break;

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
        
        private void loadROdata(bool showAll = false)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string dateFrom, dateTo;

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, RO_INVOICE AS 'NO PERMINTAAN', DATE_FORMAT(RO_DATETIME, '%d-%m-%Y')  AS 'TANGGAL PERMINTAAN', RO_EXPIRED AS 'TANGGAL EXPIRED', M1.BRANCH_NAME AS 'ASAL PERMINTAAN', M2.BRANCH_NAME AS 'TUJUAN PERMINTAAN', RO_TOTAL AS 'TOTAL' " +
                                "FROM REQUEST_ORDER_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (RO_BRANCH_ID_FROM = M1.BRANCH_ID) " +
                                "LEFT OUTER JOIN MASTER_BRANCH M2 ON (RO_BRANCH_ID_TO = M2.BRANCH_ID) " +
                                "WHERE 1 = 1";

            if (!showAll)
            {
                if (showExpiredCheckBox.Checked)
                {
                    sqlCommand = sqlCommand + " AND RO_EXPIRED > '" + DateTime.Now + "'";
                }

                if (!showApprovedROCheckbox.Checked)
                {
                    sqlCommand = sqlCommand + " AND RO_ACTIVE = 1";
                }

                if (noROInvoiceTextBox.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND RO_INVOICE LIKE '%" + noROInvoiceTextBox.Text + "%'";
                }

                dateFrom = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(RODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(RODtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(RO_DATETIME, '%d-%m-%Y')  >= '" + dateFrom + "' AND DATE_FORMAT(RO_DATETIME, '%d-%m-%Y')  <= '" + dateTo + "'";

                if (branchFromCombo.SelectedIndex > 0)
                {
                    sqlCommand = sqlCommand + " AND RO_BRANCH_ID_FROM = " + selectedBranchFromID;
                }

                if (branchToCombo.SelectedIndex > 0)
                {
                    sqlCommand = sqlCommand + " AND RO_BRANCH_ID_TO = " + selectedBranchToID;
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataRequestOrderGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataRequestOrderGridView.DataSource = dt;

                    dataRequestOrderGridView.Columns["ID"].Visible = false;

                    dataRequestOrderGridView.Columns["NO PERMINTAAN"].Width = 200;
                    dataRequestOrderGridView.Columns["TANGGAL PERMINTAAN"].Width = 200;
                    dataRequestOrderGridView.Columns["TANGGAL EXPIRED"].Width = 200;
                    dataRequestOrderGridView.Columns["ASAL PERMINTAAN"].Width = 200;
                    dataRequestOrderGridView.Columns["TUJUAN PERMINTAAN"].Width = 200;
                    dataRequestOrderGridView.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            if (showAllCheckBox.Checked)
            {
                loadROdata(true);
            }
            else
                loadROdata();
        }

        private void dataPermintaanForm_Load(object sender, EventArgs e)
        {
            fillInBranchCombo(branchFromCombo, branchFromHiddenCombo);
            fillInBranchCombo(branchToCombo, branchToHiddenCombo);

            gUtil.reArrangeTabOrder(this);
        }

        private void dataRequestOrderGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataRequestOrderGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
            selectedROID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            displaySpecificForm(selectedROID);
        }

        private void dataRequestOrderGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dataRequestOrderGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataRequestOrderGridView.SelectedCells[0].RowIndex)-1;
                DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
                selectedROID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm(selectedROID);
            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            displaySpecificForm();
        }

        private void branchFromCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchFromID = Convert.ToInt32(branchFromHiddenCombo.Items[branchFromCombo.SelectedIndex]);
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchToID = Convert.ToInt32(branchToHiddenCombo.Items[branchToCombo.SelectedIndex]);
        }

    }
}

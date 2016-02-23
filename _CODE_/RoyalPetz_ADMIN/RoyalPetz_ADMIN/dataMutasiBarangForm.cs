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
        private int selectedROID = 0;

        private Data_Access DS = new Data_Access();

        public dataMutasiBarangForm()
        {
            InitializeComponent();
        }

        public dataMutasiBarangForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if ((moduleID != globalConstants.PERMINTAAN_BARANG) && (moduleID != globalConstants.CEK_DATA_MUTASI))
                newButton.Visible = false;

            if (moduleID != globalConstants.PERMINTAAN_MUTASI_BARANG)
                importButton.Visible = false;
        }

        private void displaySpecificForm(int roID = 0)
        {
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                        dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm();
                        displayedForm.ShowDialog(this);
                    break;

                case globalConstants.PERMINTAAN_BARANG:
                        if (roID == 0)
                        { 
                            permintaanProdukForm permintaanProdukDisplayedForm = new permintaanProdukForm(globalConstants.NEW_REQUEST_ORDER);
                            permintaanProdukDisplayedForm.ShowDialog(this);
                        }
                        else
                        { 
                            permintaanProdukForm editPermintaanProdukDisplayedForm = new permintaanProdukForm(globalConstants.EDIT_REQUEST_ORDER, roID);
                            editPermintaanProdukDisplayedForm.ShowDialog(this);
                        }
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
            selectedROID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

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

            sqlCommand = "SELECT ID, RO_INVOICE AS 'NO PERMINTAAN', RO_DATETIME AS 'TANGGAL PERMINTAAN', RO_EXPIRED AS 'TANGGAL EXPIRED', M1.BRANCH_NAME AS 'ASAL PERMINTAAN', M2.BRANCH_NAME AS 'TUJUAN PERMINTAAN', RO_TOTAL AS 'TOTAL' " +
                                "FROM REQUEST_ORDER_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (RO_BRANCH_ID_FROM = M1.BRANCH_ID) " +
                                "LEFT OUTER JOIN MASTER_BRANCH M2 ON (RO_BRANCH_ID_TO = M2.BRANCH_ID) " +
                                "WHERE RO_ACTIVE = 1 AND RO_EXPIRED > '" + DateTime.Now + "'";

            using (rdr = DS.getData(sqlCommand))
            {
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
            if (e.KeyChar == 13)
            {
                if (dataRequestOrderGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
                selectedROID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm(selectedROID);
            }
        }
    }
}

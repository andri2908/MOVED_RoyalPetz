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
    public partial class dataProdukForm : Form
    {
        private int originModuleID = 0;
        private int selectedProductID = 0;
        private stokPecahBarangForm parentForm;
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        public dataProdukForm()
        {
            InitializeComponent();
        }

        public dataProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        public dataProdukForm(int moduleID, stokPecahBarangForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisParentForm;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                case globalConstants.STOK_PECAH_BARANG: 
                    stokPecahBarangForm displaystokPecahBarangForm = new stokPecahBarangForm(selectedProductID);
                    displaystokPecahBarangForm.ShowDialog(this);
                    break;

                case globalConstants.PENYESUAIAN_STOK:
                    penyesuaianStokForm penyesuaianStokForm = new penyesuaianStokForm(selectedProductID);
                    penyesuaianStokForm.ShowDialog(this);
                    break;

                case globalConstants.BROWSE_STOK_PECAH_BARANG:
                    parentForm.setNewSelectedProductID(selectedProductID);
                    this.Close();
                    break;

                default: // MASTER DATA PRODUK
                    dataProdukDetailForm displayForm = new dataProdukDetailForm(globalConstants.EDIT_PRODUK, selectedProductID);
                    displayForm.ShowDialog(this);
                    break;
            }   
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataProdukDetailForm displayForm = new dataProdukDetailForm(globalConstants.NEW_PRODUK);
            displayForm.ShowDialog(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (!namaProdukTextBox.Text.Equals(""))
            {
                loadProdukData();
            }
        }

        private void loadProdukData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string namaProductParam = "";
            string kodeProductParam = "";

            DS.mySqlConnect();

            //if (namaProdukTextBox.Text.Equals(""))
            //    return;
            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);
            kodeProductParam = MySqlHelper.EscapeString(textBox1.Text);

            sqlCommand = "SELECT ID, PRODUCT_ID AS 'PRODUK ID', PRODUCT_NAME AS 'NAMA PRODUK', PRODUCT_DESCRIPTION AS 'DESKRIPSI PRODUK' FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_ID LIKE '%" + kodeProductParam + "%' AND PRODUCT_NAME LIKE '%" + namaProductParam + "%'";
            
            if (originModuleID == globalConstants.STOK_PECAH_BARANG)
            {
                sqlCommand = sqlCommand + " AND PRODUCT_IS_SERVICE = 0";
            }
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataProdukGridView.DataSource = dt;

                    dataProdukGridView.Columns["ID"].Visible = false;
                    dataProdukGridView.Columns["PRODUK ID"].Width = 200;
                    dataProdukGridView.Columns["NAMA PRODUK"].Width = 200;
                    dataProdukGridView.Columns["DESKRIPSI PRODUK"].Width = 300;                    
                }
            }
        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataProdukGridView.Rows.Count <= 0)
                    return;

            int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
            selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            displaySpecificForm();
            
        }

        private void tagProdukDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == 13) // Enter
            {
                if (dataProdukGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = (dataProdukGridView.SelectedCells[0].RowIndex) - 1;

                DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
                selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm();
            } */
        }

        private void dataProdukGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // Enter
            {
                if (dataProdukGridView.Rows.Count <= 0)
                    return;

                int selectedrowindex = dataProdukGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataProdukGridView.Rows[selectedrowindex];
                selectedProductID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm();
            }
        }
        private void dataProdukForm_Activated(object sender, EventArgs e)
        {
            if (!namaProdukTextBox.Text.Equals(""))
            {
                loadProdukData();
            }
        }

        private void produknonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataProdukGridView.DataSource = null;
            if (!namaProdukTextBox.Text.Equals(""))
            {
                loadProdukData();
            }
        }

        private void dataProdukForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_TAMBAH_PRODUK, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            loadProdukData();
        }
    }
}

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
    public partial class dataKategoriProdukForm : Form
    {
        private int originModuleID = 0;
        private int selectedCategoryID = 0;

        Data_Access DS = new Data_Access();

        public dataKategoriProdukForm()
        {
            InitializeComponent();
        }

        public dataKategoriProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            newButton.Visible = false;
        }

        private void loadKategoriData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            if (categoryNameTextBox.Text.Equals(""))
                return;

            DS.mySqlConnect();

            sqlCommand = "SELECT CATEGORY_ID, CATEGORY_NAME AS 'NAMA KATEGORI', CATEGORY_DESCRIPTION AS 'DESKRIPSI KATEGORI' FROM MASTER_CATEGORY WHERE CATEGORY_ACTIVE = 1 AND CATEGORY_NAME LIKE '%" + categoryNameTextBox.Text + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);

                    kategoriProdukDataGridView.DataSource = dt;

                    kategoriProdukDataGridView.Columns["CATEGORY_ID"].Visible = false;
                    kategoriProdukDataGridView.Columns["NAMA KATEGORI"].Width = 200;
                    kategoriProdukDataGridView.Columns["DESKRIPSI KATEGORI"].Width = 300;
                }
            }
        }

        private void displaySpecificForm()
        {
            switch(originModuleID)
            {
                case globalConstants.PENGATURAN_KATEGORI_PRODUK:
                    pengaturanKategoriProdukForm pengaturanKategoriForm = new pengaturanKategoriProdukForm();
                        pengaturanKategoriForm.ShowDialog(this);
                    break;
                default:
                    dataKategoriProdukDetailForm displayedForm = new dataKategoriProdukDetailForm(globalConstants.EDIT_CATEGORY, selectedCategoryID);
                        displayedForm.ShowDialog(this);
                    break;
            }
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            dataKategoriProdukDetailForm displayForm = new dataKategoriProdukDetailForm(globalConstants.NEW_CATEGORY);
            displayForm.ShowDialog(this);
        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = kategoriProdukDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = kategoriProdukDataGridView.Rows[selectedrowindex];
            selectedCategoryID = Convert.ToInt32(selectedRow.Cells["CATEGORY_ID"].Value);

            displaySpecificForm();
        }

        private void categoryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            loadKategoriData();
        }

        private void dataKategoriProdukForm_Activated(object sender, EventArgs e)
        {
            loadKategoriData();
        }
    }
}

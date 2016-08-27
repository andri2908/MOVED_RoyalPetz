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
using Hotkeys;

namespace RoyalPetz_ADMIN
{
    public partial class dataKategoriProdukForm : Form
    {
        private int originModuleID = 0;
        private int selectedCategoryID = 0;

        private dataProdukDetailForm parentForm;
        private globalUtilities gutil = new globalUtilities();
        Data_Access DS = new Data_Access();

        pengaturanKategoriProdukForm displayPengaturanKategoriForm = null;
        dataKategoriProdukDetailForm editKategoriForm = null;
        dataKategoriProdukDetailForm newKategoriForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        public dataKategoriProdukForm()
        {
            InitializeComponent();
        }

        public dataKategoriProdukForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            //newButton.Visible = false;
        }

        public dataKategoriProdukForm(int moduleID, dataProdukDetailForm thisForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisForm;
            //newButton.Visible = false;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();

            navKeyRegistered = false;
        }

        private void loadKategoriData(int options = 0)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string categoryNameParam;

            if (options !=1 && categoryNameTextBox.Text.Equals(""))
                return;

            DS.mySqlConnect();
            if (options == 1)
            {
                sqlCommand = "SELECT CATEGORY_ID, CATEGORY_NAME AS 'NAMA KATEGORI', CATEGORY_DESCRIPTION AS 'DESKRIPSI KATEGORI' FROM MASTER_CATEGORY";
            }
            else
            {
                categoryNameParam = MySqlHelper.EscapeString(categoryNameTextBox.Text);
                if (tagnonactiveoption.Checked == true)
                {
                    sqlCommand = "SELECT CATEGORY_ID, CATEGORY_NAME AS 'NAMA KATEGORI', CATEGORY_DESCRIPTION AS 'DESKRIPSI KATEGORI' FROM MASTER_CATEGORY WHERE CATEGORY_NAME LIKE '%" + categoryNameParam + "%'";
                }
                else
                {
                    sqlCommand = "SELECT CATEGORY_ID, CATEGORY_NAME AS 'NAMA KATEGORI', CATEGORY_DESCRIPTION AS 'DESKRIPSI KATEGORI' FROM MASTER_CATEGORY WHERE CATEGORY_ACTIVE = 1 AND CATEGORY_NAME LIKE '%" + categoryNameParam + "%'";
                }
            }

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
            int selectedrowindex = kategoriProdukDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = kategoriProdukDataGridView.Rows[selectedrowindex];
            selectedCategoryID = Convert.ToInt32(selectedRow.Cells["CATEGORY_ID"].Value);
            
            switch(originModuleID)
            {
                case globalConstants.PRODUK_DETAIL_FORM:
                    parentForm.addSelectedKategoriID(selectedCategoryID);
                    this.Close();
                    break;

                case globalConstants.PENGATURAN_KATEGORI_PRODUK:
                    if (null == displayPengaturanKategoriForm || displayPengaturanKategoriForm.IsDisposed)
                            displayPengaturanKategoriForm = new pengaturanKategoriProdukForm(selectedCategoryID);

                    displayPengaturanKategoriForm.Show();
                    displayPengaturanKategoriForm.WindowState = FormWindowState.Normal;
                    break;

                default:
                    if (null == editKategoriForm || editKategoriForm.IsDisposed)
                        editKategoriForm = new dataKategoriProdukDetailForm(globalConstants.EDIT_CATEGORY, selectedCategoryID);

                    editKategoriForm.Show();
                    editKategoriForm.WindowState = FormWindowState.Normal;
                    break;
            }
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            if (null == newKategoriForm || newKategoriForm.IsDisposed)
                 newKategoriForm = new dataKategoriProdukDetailForm(globalConstants.NEW_CATEGORY);

            newKategoriForm.Show();
            newKategoriForm.WindowState = FormWindowState.Normal;
        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (kategoriProdukDataGridView.Rows.Count > 0)
                displaySpecificForm();
        }

        private void categoryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!categoryNameTextBox.Text.Equals(""))
            {
                loadKategoriData();
            }
        }

        private void dataKategoriProdukForm_Activated(object sender, EventArgs e)
        {
            if (!categoryNameTextBox.Text.Equals(""))
            {
                loadKategoriData();
            }

            registerGlobalHotkey();
        }

        private void dataKategoriProdukForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_KATEGORI, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;
        }

        private void groupnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            kategoriProdukDataGridView.DataSource = null;
            if (!categoryNameTextBox.Text.Equals(""))
            {
                loadKategoriData();
            }
        }

        private void kategoriProdukDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (kategoriProdukDataGridView.Rows.Count > 0)
                    displaySpecificForm();
        }

		private void AllButton_Click(object sender, EventArgs e)
        {
            loadKategoriData(1);
        }
		
        private void dataKategoriProdukForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void kategoriProdukDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void kategoriProdukDataGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}

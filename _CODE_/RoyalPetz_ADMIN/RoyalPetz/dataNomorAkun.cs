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

namespace AlphaSoft
{
    public partial class dataNomorAkun : Form
    {
        private int originModuleID = 0;
        private globalUtilities gutil = new globalUtilities();
        private int selectedAccountID = 0;
        private dataTransaksiJurnalHarianDetailForm parentForm;
        private Data_Access DS = new Data_Access();

        dataNomorAkunDetailForm newNoAkunForm = null;
        dataNomorAkunDetailForm editNoAkunForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private Hotkeys.GlobalHotkey ghk_ESC;
        private bool navKeyRegistered = false;


        public dataNomorAkun()
        {
            InitializeComponent();
        }

        public dataNomorAkun(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            newButton.Visible = false;
        }

        public dataNomorAkun(int moduleID, dataTransaksiJurnalHarianDetailForm thisForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisForm;
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
                case Keys.Escape:
                    this.Close();
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

            ghk_ESC = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Escape, this);
            ghk_ESC.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
            ghk_ESC.Unregister();

            navKeyRegistered = false;
        }

        private void displaySpecificForm()
        {
            int selectedrowindex = dataAccountGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells["KODE AKUN"].Value);

            switch (originModuleID)
            {
                case globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN:
                    parentForm.addSelectedAccountID(selectedAccountID);
                    this.Close();
                    break;
                default:
                    if (null == editNoAkunForm || editNoAkunForm.IsDisposed)
                        editNoAkunForm = new dataNomorAkunDetailForm(globalConstants.EDIT_AKUN, selectedAccountID);

                    editNoAkunForm.Show();
                    editNoAkunForm.WindowState = FormWindowState.Normal;
                    break;
            }
        }

        private void loadAccountData(string accountnameParam, int options = 0)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string accountName = MySqlHelper.EscapeString(accountnameParam);

            DS.mySqlConnect();
            if (options == 1)
            {
                sqlCommand = "SELECT MASTER_ACCOUNT.ID AS 'ID', MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID";
            }
            else
            {
                if (accountnonactiveoption.Checked)
                {
                    sqlCommand = "SELECT MASTER_ACCOUNT.ID AS 'ID', MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ACCOUNT_NAME LIKE '%" + accountName + "%'";
                }
                else
                {
                    sqlCommand = "SELECT MASTER_ACCOUNT.ID AS 'ID', MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_ACTIVE = 1 AND MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ACCOUNT_NAME LIKE '%" + accountName + "%'";
                }
            }            
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataAccountGridView.DataSource = dt;

                    dataAccountGridView.Columns["ID"].Visible = false;
                    dataAccountGridView.Columns["KODE AKUN"].Width = 150;
                    dataAccountGridView.Columns["DESKRIPSI"].Width = 250;
                    dataAccountGridView.Columns["TIPE"].Width = 100;
                }
            }
        }

        private void dataNomorAkun_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PENGATURAN_NO_AKUN, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            namaAccountTextbox.Select();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (null == newNoAkunForm || newNoAkunForm.IsDisposed)
                newNoAkunForm = new dataNomorAkunDetailForm(globalConstants.NEW_AKUN, 0);

            newNoAkunForm.Show();
            newNoAkunForm.WindowState = FormWindowState.Normal;
        }

        private void dataNomorAkun_Activated(object sender, EventArgs e)
        {
            //if need something
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }

            registerGlobalHotkey();
        }

        private void accountnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataAccountGridView.DataSource = null;
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }
            //loaddata
        }
           
        private void namaAccountTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }
        }

        private void dataAccountGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataAccountGridView.Rows.Count > 0)
                displaySpecificForm();

           /* int selectedrowindex = dataAccountGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            dataNomorAkunDetailForm displayedForm = new dataNomorAkunDetailForm(globalConstants.EDIT_AKUN, selectedAccountID);
            displayedForm.ShowDialog(this);

            */
        }

        private void dataAccountGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (dataAccountGridView.Rows.Count > 0)
                    displaySpecificForm();
        }

        private void dataAccountGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataAccountGridView.Rows.Count > 0)
                displaySpecificForm();
        }

		private void AllButton_Click(object sender, EventArgs e)
        {
            loadAccountData("",1);
        }
		
        private void dataNomorAkun_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataAccountGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataAccountGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                unregisterGlobalHotkey();
        }
    }
}

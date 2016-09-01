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
    public partial class dataCabangForm : Form
    {
        private int selectedBranchID = 0;
        private int originModuleID = 0;

        private Data_Access DS = new Data_Access();

        private globalUtilities gutil = new globalUtilities();

        dataCabangDetailForm newBranchForm = null;
        dataCabangDetailForm editBranchForm = null;
        pembayaranLumpSumForm pembayaranPiutangForm = null;

        private bool navKeyRegistered = false;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public dataCabangForm()
        {
            InitializeComponent();
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

        public dataCabangForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            newButton.Visible = false;
        }

        private void loadBranchData(string branchNameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string branchName = MySqlHelper.EscapeString(branchNameParam);

            DS.mySqlConnect();
            if (branchNameParam.Equals("All"))
            {
                sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME AS 'NAMA CABANG', branch_ip4 AS 'ALAMAT IP CABANG' FROM MASTER_BRANCH";
            }
            else
            {
                if (cabangnonactiveoption.Checked)
                {
                    sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME AS 'NAMA CABANG', branch_ip4 AS 'ALAMAT IP CABANG' FROM MASTER_BRANCH WHERE BRANCH_NAME LIKE '%" + branchName + "%'";
                }
                else
                {
                    sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME AS 'NAMA CABANG', branch_ip4 AS 'ALAMAT IP CABANG' FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1 AND BRANCH_NAME LIKE '%" + branchName + "%'";
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataCabangGridView.DataSource = dt;

                    dataCabangGridView.Columns["BRANCH_ID"].Visible = true;
                    dataCabangGridView.Columns["NAMA CABANG"].Width = 200;
                    dataCabangGridView.Columns["ALAMAT IP CABANG"].Width = 200;
                }
            }
        }

        private void dataCabangForm_Activated(object sender, EventArgs e)
        {
            if (!namaBranchTextbox.Text.Equals(""))  //for showing all???
                loadBranchData(namaBranchTextbox.Text);

            registerGlobalHotkey();
        }

        private void namaBranchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaBranchTextbox.Text.Equals(""))
                loadBranchData(namaBranchTextbox.Text);
        }

        private void dataCabangGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
            selectedBranchID = Convert.ToInt32(selectedRow.Cells["BRANCH_ID"].Value);

            if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
            {
                if (null == pembayaranPiutangForm || pembayaranPiutangForm.IsDisposed)
                    pembayaranPiutangForm = new pembayaranLumpSumForm(originModuleID, selectedBranchID);

                pembayaranPiutangForm.Show();
                pembayaranPiutangForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (null == editBranchForm || editBranchForm.IsDisposed)
                        editBranchForm = new dataCabangDetailForm(globalConstants.EDIT_BRANCH, selectedBranchID);

                editBranchForm.Show();
                editBranchForm.WindowState = FormWindowState.Normal;
            }
        }

        private void cabangnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataCabangGridView.DataSource = null;
           
            if (!namaBranchTextbox.Text.Equals(""))
                loadBranchData(namaBranchTextbox.Text);
        }

        private void dataCabangForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_MANAJEMEN_CABANG, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;

            namaBranchTextbox.Select();
        }

        private void dataCabangGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = dataCabangGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataCabangGridView.Rows[selectedrowindex];
                selectedBranchID = Convert.ToInt32(selectedRow.Cells["BRANCH_ID"].Value);

                if (originModuleID == globalConstants.DATA_PIUTANG_MUTASI)
                {
                    gutil.saveSystemDebugLog(0, "CREATE PEMBAYARAN PIUTANG MUTASI, BRANCH ID [" + selectedBranchID + "]");

                    if (null == pembayaranPiutangForm || pembayaranPiutangForm.IsDisposed)
                        pembayaranPiutangForm = new pembayaranLumpSumForm(originModuleID, selectedBranchID);

                    pembayaranPiutangForm.Show();
                    pembayaranPiutangForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    gutil.saveSystemDebugLog(0, "CREATE DATA BRANCH DETAIL, BRANCH ID [" + selectedBranchID + "]");
                    if (null == editBranchForm || editBranchForm.IsDisposed)
                            editBranchForm = new dataCabangDetailForm(globalConstants.EDIT_BRANCH, selectedBranchID);

                    editBranchForm.Show();
                    editBranchForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void newButton_Click_1(object sender, EventArgs e)
        {
            dataCabangDetailForm displayedForm = new dataCabangDetailForm(globalConstants.NEW_BRANCH, 0);
            displayedForm.ShowDialog(this);
            dataCabangGridView.DataSource = null;
            if (!namaBranchTextbox.Text.Equals(""))
                loadBranchData(namaBranchTextbox.Text);
        }
		
		private void AllButton_Click(object sender, EventArgs e)
        {
            loadBranchData("ALL");
        }

        private void dataCabangForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

		private void newButton_Click_2(object sender, EventArgs e)
        {
            dataCabangDetailForm displayedForm = new dataCabangDetailForm(globalConstants.NEW_BRANCH, 0);
            displayedForm.ShowDialog(this);
            dataCabangGridView.DataSource = null;
            if (!namaBranchTextbox.Text.Equals(""))
                loadBranchData(namaBranchTextbox.Text);
        }
		
        private void dataCabangGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataCabangGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }

        private void dataCabangGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

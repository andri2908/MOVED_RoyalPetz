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
    public partial class dataUserForm : Form
    {
        private int originModuleID = 0;
        private int selectedUserID = 0;
        private string sqlCommandx = ""; 

        Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        dataUserDetailForm newUserForm = null;
        dataUserDetailForm editUserForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        public dataUserForm()
        {
            InitializeComponent();
        }

        public dataUserForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            newButton.Visible = false;
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

        private void loadUserData(string userNameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string sqlfiltergroup, filtergroup;
            string userName = "";

            userName = MySqlHelper.EscapeString(userNameParam);
            
            filtergroup = groupcombobox.SelectedValue.ToString();
            if (filtergroup.Equals("0"))
            {
                sqlfiltergroup = "";
            } else
            {
                sqlfiltergroup = "AND U.GROUP_ID = '" + MySqlHelper.EscapeString(filtergroup) + "' ";
            }
            DS.mySqlConnect();

            if (usernonactiveoption.Checked)
            {
                sqlCommand = "SELECT U.ID AS 'ID', U.USER_NAME AS 'USER NAME', U.USER_FULL_NAME AS 'USER FULL NAME', G.GROUP_USER_NAME AS 'NAMA GROUP' " +
                                "FROM MASTER_USER U, MASTER_GROUP G " +
                                "WHERE U.GROUP_ID = G.GROUP_ID " + sqlfiltergroup + "AND UPPER(U.USER_NAME) LIKE '%" + userName + "%'";
                sqlCommandx = "SELECT U.USER_NAME AS 'USER', U.USER_FULL_NAME AS 'NAMA', U.USER_PHONE AS 'TELEPON', G.GROUP_USER_NAME AS 'GROUP' FROM MASTER_USER U, MASTER_GROUP G WHERE U.GROUP_ID = G.GROUP_ID " 
                    + sqlfiltergroup + "AND UPPER(U.USER_NAME) LIKE '%" + userName + "%'";
            }
            else
            {
                sqlCommand = "SELECT U.ID AS 'ID', U.USER_NAME AS 'USER NAME', U.USER_FULL_NAME AS 'USER FULL NAME', G.GROUP_USER_NAME AS 'NAMA GROUP' " +
                                "FROM MASTER_USER U, MASTER_GROUP G " +
                                "WHERE U.USER_ACTIVE = 1 AND U.GROUP_ID = G.GROUP_ID " + sqlfiltergroup + "AND UPPER(U.USER_NAME) LIKE '%" + userName + "%'";
                sqlCommandx = "SELECT U.USER_NAME AS 'USER', U.USER_FULL_NAME AS 'NAMA', U.USER_PHONE AS 'TELEPON', G.GROUP_USER_NAME AS 'GROUP' FROM MASTER_USER U, MASTER_GROUP G WHERE U.GROUP_ID = G.GROUP_ID "
                    + "AND U.USER_ACTIVE = 1 " + sqlfiltergroup + "AND UPPER(U.USER_NAME) LIKE '%" + userName + "%'";
            }
            

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataUserGridView.DataSource = dt;

                    dataUserGridView.Columns["ID"].Visible = false;
                    dataUserGridView.Columns["USER NAME"].Width = 200;
                    dataUserGridView.Columns["USER FULL NAME"].Width = 300;
                    dataUserGridView.Columns["NAMA GROUP"].Width = 200;
                }
            }

        }

        private void loadGroupUser()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();
            sqlCommand = "SELECT GROUP_ID AS 'ID', GROUP_USER_NAME AS 'NAME' " +
                                "FROM MASTER_GROUP " +
                                "WHERE GROUP_USER_ACTIVE = 1";
                                    
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Columns.Add("ID", typeof(string));
                    dt.Columns.Add("NAME", typeof(string));
                    dt.Load(rdr);
                    dt.Rows.Add("0", "ALL");
                    groupcombobox.ValueMember = "ID";
                    groupcombobox.DisplayMember = "NAME";
                    groupcombobox.DataSource = dt;
                }
            }

        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                default:
                    gutil.saveSystemDebugLog(0, "CREATE DATA USER DETAIL FORM, UID [" + selectedUserID + "]");

                    if (null == editUserForm || editUserForm.IsDisposed)
                            editUserForm = new dataUserDetailForm(globalConstants.EDIT_USER, selectedUserID);

                    editUserForm.Show();
                    editUserForm.WindowState = FormWindowState.Normal;
                    break;
            }
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            if (null == newUserForm || newUserForm.IsDisposed)
                    newUserForm = new dataUserDetailForm(globalConstants.NEW_USER);

            newUserForm.Show();
            newUserForm.WindowState = FormWindowState.Normal;
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataUserGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataUserGridView.Rows[selectedrowindex];
            selectedUserID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            displaySpecificForm();
        }

        private void dataUserForm_Activated(object sender, EventArgs e)
        {
            loadGroupUser();
            groupcombobox.SelectedValue = "0";
            groupcombobox.Text = "ALL";
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);

            registerGlobalHotkey();
        }

        private void namaUserTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void usernonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataUserGridView.DataSource = null;
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void groupcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataUserGridView.DataSource = null;
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void dataUserGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = dataUserGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataUserGridView.Rows[selectedrowindex];
                selectedUserID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                displaySpecificForm();
            }
        }

        private void dataUserForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_MANAJEMEN_USER, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;
        }

        private void CetakButton_Click(object sender, EventArgs e)
        {
            //preview laporan
            DS.mySqlConnect();
            DS.writeXML(sqlCommandx,globalConstants.UserXML);
            ReportUserForm displayedform = new ReportUserForm();
            displayedform.ShowDialog(this);
        }

        private void genericControl_Enter(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void genericControl_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void dataUserForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void dataUserGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataUserGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}

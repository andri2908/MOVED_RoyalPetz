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
    public partial class dataNomorAkunDetailForm : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private int originModuleID = 0;
        private int options = 0;
        private int selectedAccountID =0;
        private Data_Access DS = new Data_Access();

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public dataNomorAkunDetailForm()
        {
            InitializeComponent();
        }

        public dataNomorAkunDetailForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        public dataNomorAkunDetailForm(int moduleID, int AccountID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedAccountID = AccountID;
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
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
        }

        private void dataNomorAkunDetailForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PENGATURAN_NO_AKUN, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_AKUN)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_AKUN)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            arrButton[0] = saveButton;
            arrButton[1] = ResetButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void loadAccountData()
        {
            //loadtypeaccount();

            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE', MASTER_ACCOUNT.ACCOUNT_ACTIVE AS 'ACTIVE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ID='" + selectedAccountID + "'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        kodeTextbox.Text = rdr.GetString("KODE AKUN");
                        DeskripsiTextbox.Text = rdr.GetString("DESKRIPSI");
                        //TipeComboBox.Text = rdr.GetString("TIPE");
                        TipeComboBox.SelectedIndex = TipeComboBox.FindString(rdr.GetString("TIPE"));
                        //cbxCategory.SelectedIndex = cbxCategory.Items.IndexOf("New") 
                        if (rdr.GetString("ACTIVE").Equals("1"))
                            NonactiveCheckbox.Checked = false;
                        else
                            NonactiveCheckbox.Checked = true;
                    }
                }
            }
        }

        private void loadtypeaccount()
        {
            TipeComboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT ACCOUNT_TYPE_ID as 'ID', ACCOUNT_TYPE_NAME AS 'NAME' FROM MASTER_ACCOUNT_TYPE"))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    TipeComboBox.DataSource = dt;
                    TipeComboBox.ValueMember = "ID";
                    TipeComboBox.DisplayMember = "NAME";
                }
            }
            TipeComboBox.SelectedIndex = 1;
        }

        private void dataNomorAkunDetailForm_Activated(object sender, EventArgs e)
        {
            //if need something
            loadtypeaccount();
            errorLabel.Text = "";
            switch (originModuleID)
            {
                case globalConstants.NEW_AKUN:
                    options = gUtil.INS;
                    NonactiveCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_AKUN:
                    options = gUtil.UPD;
                    NonactiveCheckbox.Enabled = true;
                    loadAccountData();
                    break;
            }
            registerGlobalHotkey();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);
            originModuleID = globalConstants.NEW_AKUN;
            options = gUtil.INS;
        }

        private bool dataValidated()
        {
            if (kodeTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "KODE AKUN TIDAK BOLEH KOSONG. ";
                return false;
            }

            if (!gUtil.matchRegEx(kodeTextbox.Text.Trim(), globalUtilities.REGEX_ALPHANUMERIC_ONLY))
            {
                errorLabel.Text = "KODE AKUN HARUS ALPHA NUMERIC";
                return false;
            }

            if (DeskripsiTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "DESKRIPSI AKUN TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string kodeakun = kodeTextbox.Text.Trim();
            string deskripsiakun = MySqlHelper.EscapeString(DeskripsiTextbox.Text.Trim());
            int tipeakun = Int32.Parse(TipeComboBox.SelectedValue.ToString());
            int nonactive = 1;
            if (NonactiveCheckbox.Checked == true)
            {
                nonactive = 0;
            }

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_AKUN:
                        sqlCommand = "INSERT INTO MASTER_ACCOUNT (ACCOUNT_ID, ACCOUNT_NAME, ACCOUNT_TYPE_ID, ACCOUNT_ACTIVE) " +
                                            "VALUES ('" + kodeakun + "', '" + deskripsiakun + "', '" + tipeakun + "', " + nonactive + ")";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NO_AKUN, "INSERT DATA TO MASTER ACCOUNT [" + kodeakun + "]");
                        break;
                    case globalConstants.EDIT_AKUN:
                        sqlCommand = "UPDATE MASTER_ACCOUNT SET " +
                                            "ACCOUNT_ID = '" + kodeakun + "', " +
                                            "ACCOUNT_NAME = '" + deskripsiakun + "', " +
                                            "ACCOUNT_TYPE_ID = '" + tipeakun + "', " +
                                            "ACCOUNT_ACTIVE = '" + nonactive + "' " +
                                            "WHERE ID = '" + selectedAccountID + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NO_AKUN, "UPDATE DATA ON MASTER ACCOUNT [" + selectedAccountID + "]");
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NO_AKUN, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData()
        {
            bool result = false;
            if (dataValidated())
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return result;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //save data
            gUtil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NO_AKUN, "ATTEMPT TO SAVE DATA");
            if (saveData())
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NO_AKUN, "DATA SAVED");
                if (originModuleID == globalConstants.NEW_AKUN)
                    gUtil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_NO_AKUN, globalConstants.CHANGE_LOG_INSERT, "NEW NOMOR AKUN [" + kodeTextbox.Text + "]");
                else
                {
                    if (NonactiveCheckbox.Checked == true)
                        gUtil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_NO_AKUN, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NOMOR AKUN [" + kodeTextbox.Text + "] STATUS NON-AKTIF");
                    else
                        gUtil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_NO_AKUN, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NOMOR AKUN [" + kodeTextbox.Text + "] STATUS AKTIF");
                }

                gUtil.showSuccess(options);
                gUtil.ResetAllControls(this);
                originModuleID = globalConstants.NEW_AKUN;
                options = gUtil.INS;
            }
        }

        private void TipeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string tmp = TipeComboBox.SelectedIndex.ToString();
            //selectedtipeakun = 1 + Int32.Parse(tmp);
        }

        private void dataNomorAkunDetailForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void TipeComboBox_Enter(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void TipeComboBox_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }
    }
}

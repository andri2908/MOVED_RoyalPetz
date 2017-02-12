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
    public partial class dataSatuanDetailForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private int options = 0;
        private int originModuleID = 0;
        private int selectedUnitID = 0;

        private Data_Access DS = new Data_Access();

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public dataSatuanDetailForm()
        {
            InitializeComponent();
        }

        public dataSatuanDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataSatuanDetailForm(int moduleID, int unitID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedUnitID = unitID;
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

        private void loadUnitData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_UNIT WHERE UNIT_ID = " + selectedUnitID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        unitNameTextBox.Text = rdr.GetString("UNIT_NAME");
                        unitDescriptionTextBox.Text = rdr.GetString("UNIT_DESCRIPTION");

                        if (rdr.GetString("UNIT_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private void dataSatuanDetailForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton= new Button[2];

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);
        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string unitName = MySqlHelper.EscapeString(unitNameTextBox.Text.Trim());
            string unitDesc = MySqlHelper.EscapeString(unitDescriptionTextBox.Text.Trim());
            byte unitStatus = 0;

            if (nonAktifCheckbox.Checked)
                unitStatus = 0;
            else
                unitStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_UNIT:
                        sqlCommand = "INSERT INTO MASTER_UNIT (UNIT_NAME, UNIT_DESCRIPTION, UNIT_ACTIVE) VALUES ('" + unitName+ "', '" + unitDesc+ "', " + unitStatus+ ")";
                        gutil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "ADD NEW UNIT [" + unitName + "]");
                        break;
                    case globalConstants.EDIT_UNIT:
                        sqlCommand = "UPDATE MASTER_UNIT SET UNIT_NAME = '" + unitName + "', UNIT_DESCRIPTION = '" + unitDesc + "', UNIT_ACTIVE = " + unitStatus + " WHERE UNIT_ID = " + selectedUnitID;
                        gutil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "UPDATE UNIT [" + selectedUnitID + "] [" + unitName + ", " + unitDesc + ", " + unitStatus + "]");
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gutil.showDBOPError(e, "INSERT");
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
            if (saveData())
            {
                switch(originModuleID)
                {
                    case globalConstants.NEW_UNIT:
                        gutil.saveUserChangeLog(globalConstants.MENU_SATUAN, globalConstants.CHANGE_LOG_INSERT, "INSERT NEW SATUAN [" + unitNameTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_UNIT:
                        if (nonAktifCheckbox.Checked == true)
                            gutil.saveUserChangeLog(globalConstants.MENU_SATUAN, globalConstants.CHANGE_LOG_UPDATE, "UPDATE SATUAN [" + unitNameTextBox.Text + "] STATUS UNIT NON-AKTIF");
                        else
                            gutil.saveUserChangeLog(globalConstants.MENU_SATUAN, globalConstants.CHANGE_LOG_UPDATE, "UPDATE SATUAN [" + unitNameTextBox.Text + "] STATUS UNIT AKTIF");
                        break;
                }

                gutil.showSuccess(options);
                gutil.ResetAllControls(this);
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void dataSatuanDetailForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            switch (originModuleID)
            {
                case globalConstants.NEW_UNIT:
                    options = gutil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_UNIT:
                    options = gutil.UPD;
                    nonAktifCheckbox.Enabled = true;
                    loadUnitData(); 
                    break;
            }
            registerGlobalHotkey();

        }

        private void dataSatuanDetailForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }
    }
}

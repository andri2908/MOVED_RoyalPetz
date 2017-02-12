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
    public partial class groupAccessModuleForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private int selectedGroupID = 0;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        private void fillInDummyData()
        {
            groupAccessDataGridView.Rows.Add("PENGATURAN LOKASI DATABASE", false);
            groupAccessDataGridView.Rows.Add("BACKUP/RESTORE DATABASE", false);
            groupAccessDataGridView.Rows.Add("TAMBAH USER", false);
            groupAccessDataGridView.Rows.Add("HAPUS USER", false);
            groupAccessDataGridView.Rows.Add("EDIT USER", false);
        }
            
        public groupAccessModuleForm()
        {
            InitializeComponent();
        }

        public groupAccessModuleForm(int groupID)
        {
            InitializeComponent();

            selectedGroupID = groupID;
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

        public void setSelectedGroupID(int groupID)
        {
            selectedGroupID = groupID;
        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            dataGroupDetailForm displayForm = new dataGroupDetailForm(globalConstants.PENGATURAN_GRUP_AKSES, this);
            displayForm.ShowDialog(this);

            loadGroupUserInformation();
        }

        private void loadGroupUserInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_GROUP WHERE GROUP_ID = " + selectedGroupID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        namaGroupTextBox.Text = rdr.GetString("GROUP_USER_NAME");
                        deskripsiTextBox.Text = rdr.GetString("GROUP_USER_DESCRIPTION");
                    }
                }
            }
        }

        private void loadUserAccessInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            int moduleFeatures;
            int userAccess;

            DS.mySqlConnect();

            sqlCommand = "SELECT MM.MODULE_ID, MM.MODULE_NAME, MM.MODULE_FEATURES, IFNULL(UAM.USER_ACCESS_OPTION,0) AS USER_ACCESS_OPTION " +
                                "FROM MASTER_MODULE MM LEFT OUTER JOIN USER_ACCESS_MANAGEMENT UAM ON (MM.MODULE_ID = UAM.MODULE_ID AND UAM.GROUP_ID = " + selectedGroupID + ") " +
                                "WHERE MM.MODULE_ACTIVE = 1";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    groupAccessDataGridView.Rows.Clear();
                    while (rdr.Read())
                    {
                        moduleFeatures = rdr.GetInt32("MODULE_FEATURES");
                        userAccess = rdr.GetInt32("USER_ACCESS_OPTION");

                        switch(moduleFeatures)
                        {
                            case 1: // ACCESS ONLY 
                                // ACCESS = 1
                                if (userAccess == 1)
                                    groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "1");                     
                                else
                                    groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "1");                     
                                break;

                            case 3: // ACCESS + INSERT, UPDATE
                                // INSERT OPERATION = 2
                                // UPDATE OPERATION = 4
                                if ( (userAccess == 2) || (userAccess == 6) )
                                    groupAccessDataGridView.Rows.Add("[INSERT] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "2");  
                                else
                                    groupAccessDataGridView.Rows.Add("[INSERT] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "2"); 
                                
                                if ((userAccess == 4) || (userAccess == 6))
                                    groupAccessDataGridView.Rows.Add("[UPDATE] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "4"); 
                                else
                                    groupAccessDataGridView.Rows.Add("[UPDATE] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "4");
                                break;

                            case 4: // VIEW ONLY
                                // VIEW = 8
                                if (userAccess == 8)
                                    groupAccessDataGridView.Rows.Add("[LAPORAN] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "8"); 
                                else
                                    groupAccessDataGridView.Rows.Add("[LAPORAN] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "8"); 
                                break;

                            case 7: // VIEW + ACCESS + INSERT, UPDATE, DELETE
                                if ((userAccess == 2) || (userAccess == 6) || (userAccess == 10) || (userAccess == 14))
                                    groupAccessDataGridView.Rows.Add("[INSERT] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "2");    
                                else
                                    groupAccessDataGridView.Rows.Add("[INSERT] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "2");   

                                if ((userAccess == 4) || (userAccess == 6) || (userAccess == 12) || (userAccess == 14))
                                    groupAccessDataGridView.Rows.Add("[UPDATE] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "4");  
                                else
                                    groupAccessDataGridView.Rows.Add("[UPDATE] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "4"); 

                                if ((userAccess == 8) || (userAccess == 10) || (userAccess == 12) || (userAccess == 14))
                                    groupAccessDataGridView.Rows.Add("[LAPORAN] - " + rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "8");
                                else
                                    groupAccessDataGridView.Rows.Add("[LAPORAN] - " + rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "8");
                                break;
                        }
                    }
                }
            }
        }

        private void groupAccessModuleForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            loadGroupUserInformation();
            loadUserAccessInformation();

            arrButton[0] = saveButton;
            arrButton[1] = newGroupButton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);
        }

        private bool saveData()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            int i=0;
            int moduleIdValue = 0;
            int tempModuleID = 0;
            int userAccessValue = 0;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                i = 0;

                while (i<groupAccessDataGridView.Rows.Count)
                {
                    tempModuleID = Convert.ToInt32(groupAccessDataGridView.Rows[i].Cells["moduleID"].Value);
                    if (moduleIdValue != tempModuleID)
                    {
                        if (moduleIdValue != 0)
                        { 
                            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM USER_ACCESS_MANAGEMENT WHERE MODULE_ID = " + moduleIdValue + " AND GROUP_ID = " + selectedGroupID)) == 0)
                            {
                                // INSERT MODE
                                sqlCommand = "INSERT INTO USER_ACCESS_MANAGEMENT (GROUP_ID, MODULE_ID, USER_ACCESS_OPTION) VALUES (" + selectedGroupID + ", " + moduleIdValue + ", " + userAccessValue + ")";

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                            else
                            {
                                // EDIT MODE
                                sqlCommand = "UPDATE USER_ACCESS_MANAGEMENT SET USER_ACCESS_OPTION = " + userAccessValue + " WHERE GROUP_ID = " + selectedGroupID + " AND MODULE_ID = " + moduleIdValue;

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }

                        moduleIdValue = tempModuleID;
                        userAccessValue = 0;
                    }

                    if (Convert.ToBoolean(groupAccessDataGridView.Rows[i].Cells["hakAkses"].Value))
                        userAccessValue = userAccessValue + Convert.ToInt32(groupAccessDataGridView.Rows[i].Cells["featureID"].Value);
                    
                    i++;
                }

                // INSERT / UPDATE 
                if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM USER_ACCESS_MANAGEMENT WHERE MODULE_ID = " + moduleIdValue + " AND GROUP_ID = " + selectedGroupID)) == 0)
                {
                    // INSERT MODE
                    sqlCommand = "INSERT INTO USER_ACCESS_MANAGEMENT (GROUP_ID, MODULE_ID, USER_ACCESS_OPTION) VALUES (" + selectedGroupID + ", " + moduleIdValue + ", " + userAccessValue + ")";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }
                else
                {
                    // EDIT MODE
                    sqlCommand = "UPDATE USER_ACCESS_MANAGEMENT SET USER_ACCESS_OPTION = " + userAccessValue + " WHERE GROUP_ID = " + selectedGroupID + " AND MODULE_ID = " + moduleIdValue;

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                //DS.executeNonQueryCommand(sqlCommand);

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                //MessageBox.Show("SUCCESS");

                gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE GROUP ACCESS VALUE");
                gutil.showSuccess(gutil.UPD);
                MessageBox.Show("RE-LOGIN UNTUK MENGAKTIFKAN HAK AKSES YANG BARU", "INFORMASI",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupAccessModuleForm_Activated(object sender, EventArgs e)
        {
            //if need something
            registerGlobalHotkey();
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i=0;i<groupAccessDataGridView.Rows.Count;i++)
                groupAccessDataGridView.Rows[i].Cells["hakAkses"].Value = checkAll.Checked;
        }

        private void groupAccessModuleForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void groupAccessDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void groupAccessDataGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}

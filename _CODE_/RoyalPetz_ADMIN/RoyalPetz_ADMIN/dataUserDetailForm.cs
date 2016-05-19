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
    public partial class dataUserDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedUserID = 0;
        private int selectedGroupID = 0;

        Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private int options = 0;

        public dataUserDetailForm()
        {
            InitializeComponent();
        }

        public dataUserDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataUserDetailForm(int moduleID, int userID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedUserID = userID;
        }

        public void setSelectedGroupID(int groupID)
        {
            selectedGroupID = groupID;
        }

        private void loadUserDataInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_USER, MASTER_GROUP WHERE MASTER_USER.GROUP_ID = MASTER_GROUP.GROUP_ID AND ID = " + selectedUserID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        userNameTextBox.Text = rdr.GetString("USER_NAME");
                        userFullNameTextBox.Text = rdr.GetString("USER_FULL_NAME");
                        
                        groupNameTextBox.Text = rdr.GetString("GROUP_USER_NAME");
                        selectedGroupID = rdr.GetInt32("GROUP_ID");

                        if (rdr.GetString("USER_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;

                        userPhoneTextBox.Text = rdr.GetString("USER_PHONE");
                    }
                }
            }
        }

        private void displayUserGroupName()
        {
            string groupName = "";
            DS.mySqlConnect();
            
            groupName = DS.getDataSingleValue("SELECT GROUP_USER_NAME FROM MASTER_GROUP WHERE GROUP_ID = " + selectedGroupID).ToString();

            groupNameTextBox.Text = groupName;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataGroupForm displayForm = new dataGroupForm(globalConstants.TAMBAH_HAPUS_USER, this);
            displayForm.ShowDialog(this);

            displayUserGroupName();
        }

        private bool dataValidated()
        {
            if (userNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "USER NAME TIDAK BOLEH KOSONG";
                return false;
            }

            if (userFullNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "USER FULL NAME TIDAK BOLEH KOSONG";
                return false;
            }

            if (passwordTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "PASSWORD TIDAK BOLEH KOSONG";
                return false;
            }

            if (!gutil.matchRegEx(userNameTextBox.Text, globalUtilities.REGEX_ALPHANUMERIC_ONLY))
            {
                errorLabel.Text = "USERNAME HARUS ALPHA NUMERIC";
                return false;
            }

            if (!gutil.matchRegEx(passwordTextBox.Text, globalUtilities.REGEX_ALPHANUMERIC_ONLY))
            {
                errorLabel.Text = "PASSWORD HARUS ALPHA NUMERIC";
                return false;
            }

            if (selectedGroupID == 0)
            {
                errorLabel.Text = "USER HARUS TERMASUK DI DALAM SALAH SATU GRUP";
                return false;
            }

            if (!passwordTextBox.Text.Equals(password2TextBox.Text))
            {
                errorLabel.Text = "INPUT PASSWORD DAN RE-TYPE PASSWORD HARUS SAMA";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string userName = userNameTextBox.Text.Trim();
            string userFullName = MySqlHelper.EscapeString(userFullNameTextBox.Text.Trim());
            string password = passwordTextBox.Text.Trim();
            string userPhone = MySqlHelper.EscapeString(userPhoneTextBox.Text.Trim());
            byte userStatus = 0;

            if (nonAktifCheckbox.Checked)
                userStatus  = 0;
            else
                userStatus  = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_USER:
                        sqlCommand = "INSERT INTO MASTER_USER (USER_NAME, USER_FULL_NAME, USER_PASSWORD, USER_PHONE, USER_ACTIVE, GROUP_ID) " +
                                            "VALUES ('"+userName+"', '"+userFullName+"', '"+password+"', '"+userPhone+"', "+userStatus+", "+selectedGroupID+")";
                        break;
                    case globalConstants.EDIT_USER:
                        sqlCommand = "UPDATE MASTER_USER " +
                                            "SET USER_NAME = '" + userName + "', " +
                                            "USER_FULL_NAME = '" + userFullName + "', " +
                                            "USER_PASSWORD = '" + password + "', " +
                                            "USER_PHONE = '" + userPhone + "', " +
                                            "USER_ACTIVE = " + userStatus + ", " +
                                            "GROUP_ID = " + selectedGroupID + " " +
                                            "WHERE ID = " + selectedUserID;
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

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

        private bool saveData()
        {
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                switch (originModuleID)
                {
                    case globalConstants.NEW_USER:
                        gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_INSERT, "ADD NEW USER [" + userNameTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_USER:
                        if (nonAktifCheckbox.Checked == true)
                            gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NEW USER [" + userNameTextBox.Text + "] USER STATUS = AKTIF");
                        else
                            gutil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_USER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NEW USER [" + userNameTextBox.Text + "] USER STATUS = NON AKTIF");
                        break;
                }

                gutil.showSuccess(options);
                gutil.ResetAllControls(this);
                errorLabel.Text = "";
                originModuleID = globalConstants.NEW_USER;
                options = gutil.INS;
            }
        }

        private void dataUserDetailForm_Activated(object sender, EventArgs e)
        {
            //loadUserDataInformation();
            switch (originModuleID)
            {
                case globalConstants.NEW_USER:
                    options = gutil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_USER:
                    options = gutil.UPD;
                    nonAktifCheckbox.Enabled = false;
                    loadUserDataInformation();
                    break;
            }
        }

        private void dataUserDetailForm_Load(object sender, EventArgs e)
        {
            int userAccessOption;
            Button[] arrButton = new Button[2];

            errorLabel.Text = "";

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_MANAJEMEN_USER, gutil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_USER)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gutil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_USER)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gutil.setReadOnlyAllControls(this);
                }
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            originModuleID = globalConstants.NEW_USER;
            options = gutil.INS;
            gutil.ResetAllControls(this);
            errorLabel.Text = "";
        }
    }
}

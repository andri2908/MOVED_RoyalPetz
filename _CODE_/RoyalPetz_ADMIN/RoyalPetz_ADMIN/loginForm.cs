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
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class loginForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private globalCryptographyMethod gCrypto = new globalCryptographyMethod();
        private string licenseFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\license.lic";//Application.StartupPath + "\\license.lic";

        private int selectedUserID = 0;
        private int selectedUserGroupID = 0;
        private int originModuleID = 0;

        //private globalUtilities gUtil = new globalUtilities();

        public loginForm()
        {
            InitializeComponent();
        }

        public loginForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            if (originModuleID == globalConstants.LOGOUT_FORM)
            {
                //label1.Visible = false;
                //label7.Visible = false;
                //shiftCombobox.Visible = false;
            }
        }

        private bool checkUserNamePassword()
        {
            bool retVal = false;
            string userName;
            string password;
            object result;
            
            string sqlCommand = "";

            userName = gutil.allTrim(userNameTextBox.Text);
            userName = MySqlHelper.EscapeString(userName);

            password = gutil.allTrim(passwordTextBox.Text);
            password = MySqlHelper.EscapeString(password);


            sqlCommand = "SELECT ID FROM MASTER_USER WHERE USER_NAME = '"+userName+"' AND USER_PASSWORD = '" + password + "'";
            result = DS.getDataSingleValue(sqlCommand);

            if (result != null)
            {
                selectedUserID = Convert.ToInt32(result);
                retVal = true;
            }

            return retVal;
        }

        private bool checkUserActive()
        {
            bool retVal = false;
            string userName;
            object result;

            string sqlCommand;

            userName = gutil.allTrim(userNameTextBox.Text);
            userName = MySqlHelper.EscapeString(userName);

            sqlCommand = "SELECT ID FROM MASTER_USER WHERE USER_NAME = '" + userName + "' AND USER_ACTIVE = '1'";
            result = DS.getDataSingleValue(sqlCommand);

            if (result != null)
            {
                retVal = true;
            }

            return retVal;
        }

        private bool checkUserExist()
        {
            bool retVal = false;
            string userName;
            object result;

            string sqlCommand;

            userName = gutil.allTrim(userNameTextBox.Text);
            userName = MySqlHelper.EscapeString(userName);

            sqlCommand = "SELECT ID FROM MASTER_USER WHERE USER_NAME = '" + userName + "'";
            result = DS.getDataSingleValue(sqlCommand);

            if (result != null)
            {
                retVal = true;
            }

            return retVal;
        }

        private bool checkTextBox()
        {
            bool retVal = false;
            string userName;
            string password;

            userName = userNameTextBox.Text;
            password = passwordTextBox.Text;

            if (userName !="" & password != "")
            {
                retVal = true;
            }

            return retVal;
        }

        private int getUserGroupID()
        {
            int result;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(GROUP_ID, 0) FROM MASTER_USER WHERE ID = " + selectedUserID));

            return result;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
            {
                if (checkUserActive())
                {
                    gutil.saveSystemDebugLog(0, "USER = " + gutil.allTrim(userNameTextBox.Text) + " IS ACTIVE");
                    if (checkUserNamePassword())
                    {
                        this.Hide();

                        selectedUserGroupID = getUserGroupID();

                        gutil.setUserID(selectedUserID);
                        gutil.setUserGroupID(selectedUserGroupID);

                        gutil.saveSystemDebugLog(0, "USER ID = " + selectedUserID + " LOGIN SUCCESSFULLY");
                        gutil.saveUserChangeLog(0, globalConstants.CHANGE_LOG_LOGIN, "USER LOGIN FROM LOGIN FORM");

                        if (gutil.userIsCashier() == 1)
                        {
                            cashierLoginForm newCashierForm = new cashierLoginForm(0);
                            gutil.saveSystemDebugLog(0, "DISPLAY CASHIER LOGIN FORM");
                            newCashierForm.ShowDialog(this);
                        }
                        else
                        { 
                            adminForm displayAdminForm = new adminForm(selectedUserID, selectedUserGroupID);
                            gutil.saveSystemDebugLog(0, "DISPLAY ADMIN FORM");
                            displayAdminForm.ShowDialog(this);
                        }

                        gutil.saveSystemDebugLog(0, "USER ID = " + selectedUserID + "LOGOUT");
                        gutil.saveUserChangeLog(0, globalConstants.CHANGE_LOG_LOGOUT, "USER LOGOUT");

                        //logoutForm displayLogOutForm = new logoutForm();
                        //displayLogOutForm.ShowDialog(this);

                        userNameTextBox.Text = "";
                        passwordTextBox.Text = "";
                        errorLabel.Text = "";
                        
                        this.Show();

                        userNameTextBox.Focus();
                    }
                    else
                    {
                        errorLabel.Text = "LOGIN FAILED." + Environment.NewLine + "Please check username or password!";
                    }
                }
                else
                {
                    errorLabel.Text = "USER NON ACTIVE." + Environment.NewLine + "Please contact Administrator!";
                }
            }
            else
            {
                errorLabel.Text = "INPUT ERROR";
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            arrButton[0] = loginButton;
            arrButton[1] = resetbutton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);

            if (!gCrypto.checkLicenseFile(licenseFilePath))
            {
                gutil.showError("LICENSE FILE NOT FOUND");
                Application.Exit();
            }

            if (!DS.firstMySqlConnect()) //one time checked at load application
            {
                gutil.showError("DB fail to connect!");

                createConfigFileForm displayedForm = new createConfigFileForm();
                displayedForm.ShowDialog();
            }
        }
        
        private void userNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Text = "";
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (checkUserExist())
                {
                    passwordTextBox.Focus();
                }
                else {
                    errorLabel.Text = "USER NOT EXIST." + Environment.NewLine + "Please Contact Adminstrator!";
                }
            }

        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loginButton.PerformClick();
            }

        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void loginForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";

        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gutil.renameLogFile();
        }
    }
}

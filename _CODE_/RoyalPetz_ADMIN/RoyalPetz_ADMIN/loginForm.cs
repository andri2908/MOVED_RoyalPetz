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
    public partial class loginForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        private int selectedUserID;
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
            
            string sqlCommand;

            userName = gutil.allTrim(userNameTextBox.Text);
            password = gutil.allTrim(passwordTextBox.Text);

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
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
            {
                if (checkUserActive())
                {
                    if (checkUserNamePassword())
                    {
                        this.Hide();

                        adminForm displayAdminForm = new adminForm(selectedUserID);
                        displayAdminForm.ShowDialog(this);

                        logoutForm displayLogOutForm = new logoutForm();
                        displayLogOutForm.ShowDialog(this);

                        userNameTextBox.Text = "";
                        passwordTextBox.Text = "";
                        errorLabel.Text = "";
                        userNameTextBox.Focus();

                        this.Show();
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
            gutil.reArrangeTabOrder(this);

            if (!DS.mySqlConnect()) //one time checked at load application
            {
                gutil.showError("DB fail to connect!");
                this.Close();
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
    }
}

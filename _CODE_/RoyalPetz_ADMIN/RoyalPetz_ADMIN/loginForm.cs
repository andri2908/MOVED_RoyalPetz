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
        private int originModuleID = 0;
        private Data_Access DS = new Data_Access();

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
                label1.Visible = false;
                label7.Visible = false;
                shiftCombobox.Visible = false;
            }
        }

        public string allTrim(string valueToTrim)
        {
            string temp = "";

            temp = valueToTrim.Replace(" ", "");

            return temp;
        }

        private bool checkUserNamePassword()
        {
            bool retVal = false;
            string userName;
            string password;
            object result;
            
            string sqlCommand;

            userName = allTrim(userNameTextBox.Text);
            password = allTrim(passwordTextBox.Text);

            sqlCommand = "SELECT COUNT(1) FROM MASTER_USER WHERE USER_NAME = '"+userName+"' AND USER_PASSWORD = '"+password+"'";
            result = DS.getDataSingleValue(sqlCommand);

            if (result != null)
            {
                if (Convert.ToInt32(result) == 1)
                    retVal = true;
            }

            return retVal;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkUserNamePassword())
            { 
                this.Hide();

                adminForm displayAdminForm = new adminForm();
                displayAdminForm.ShowDialog(this);

                this.Show();
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (!DS.mySqlConnect())
            {
                MessageBox.Show("CAN'T CONNECT");
            }
        }
    }
}

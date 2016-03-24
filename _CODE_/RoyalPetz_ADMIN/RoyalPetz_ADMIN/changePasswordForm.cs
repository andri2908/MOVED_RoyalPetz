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
    public partial class changePasswordForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        
        private int selectedUserID = 0;

        public changePasswordForm(int userID)
        {
            InitializeComponent();

            selectedUserID = userID;
        }

        private bool validateOldPassword()
        {
            string oldPassword = oldPasswordTextBox.Text;
            int result;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_USER WHERE ID = " + selectedUserID + " AND USER_PASSWORD = '" + oldPassword + "'"));
            if (result != 0)
                return true;

            return false;
        }

        private bool dataValidated()
        {
            if (oldPasswordTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "OLD PASSWORD TIDAK BOLEH KOSONG";
                return false;
            }

            if (!validateOldPassword())
            {
                errorLabel.Text = "OLD PASSWORD SALAH";
                return false;
            }
            
            if (newPasswordTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NEW PASSWORD TIDAK BOLEH KOSONG";
                return false;
            }

            if (!newPasswordTextBox.Text.Equals(newPassword2TextBox.Text))
            {
                errorLabel.Text = "NEW PASSWORD DAN RE-TYPE PASSWORD HARUS SAMA";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string newPassword = newPasswordTextBox.Text;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                sqlCommand = "UPDATE MASTER_USER SET USER_PASSWORD = '"+newPassword+"' WHERE ID = " + selectedUserID;

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

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                gutil.showSuccess(gutil.UPD);
                gutil.ResetAllControls(this);                
            }
        }

        private void changePasswordForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }
        private void changePasswordForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";
        }
    }
}

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
                            nonAktifCheckbox.Checked = true;
                        else
                            nonAktifCheckbox.Checked = false;

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

            string userName = userNameTextBox.Text.Trim();
            string userFullName = userFullNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string userPhone = userPhoneTextBox.Text.Trim();
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

                DS.executeNonQueryCommand(sqlCommand);

                DS.commit();
            }
            catch (Exception e)
            {
                try
                {
                    //myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        MessageBox.Show("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }

                MessageBox.Show("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                MessageBox.Show("Neither record was written to database.");
            }
            finally
            {
                DS.mySqlClose();
                result = true;
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
                MessageBox.Show("SUCCESS");
                
                this.Close();
            }
        }

        private void dataUserDetailForm_Activated(object sender, EventArgs e)
        {
            //loadUserDataInformation();
        }

        private void dataUserDetailForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            loadUserDataInformation();
        }
    }
}

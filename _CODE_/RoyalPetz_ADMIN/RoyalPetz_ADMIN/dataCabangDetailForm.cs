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
    public partial class dataCabangDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedBranchID = 0;

        private Data_Access DS = new Data_Access();

        public dataCabangDetailForm()
        {
            InitializeComponent();
        }

        public dataCabangDetailForm(int moduleID, int branchID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedBranchID = branchID;
        }
        
        private void loadBranchDataInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_BRANCH WHERE BRANCH_ID =  " + selectedBranchID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        branchNameTextBox.Text = rdr.GetString("BRANCH_NAME");
                        ipAddressMaskedTextbox.Text = rdr.GetString("BRANCH_IP4");
                        branchAddress1TextBox.Text = rdr.GetString("BRANCH_ADDRESS_1");
                        branchAddress2TextBox.Text = rdr.GetString("BRANCH_ADDRESS_2");
                        branchAddressCityTextBox.Text = rdr.GetString("BRANCH_ADDRESS_CITY");
                        branchTelephoneTextBox.Text = rdr.GetString("BRANCH_TELEPHONE");
                        
                        if (rdr.GetString("BRANCH_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private bool dataValidated()
        {
            if (branchNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA CABANG TIDAK BOLEH KOSONG";
                return false;
            }

            if (ipAddressMaskedTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "IP ADDRESS CABANG TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string branchName = branchNameTextBox.Text.Trim();
            string branchIPv4 = ipAddressMaskedTextbox.Text.Trim();
            string branchAddress1 = branchAddress1TextBox.Text.Trim();
            string branchAddress2 = branchAddress2TextBox.Text.Trim();
            string branchAddressCity = branchAddressCityTextBox.Text.Trim();
            string branchPhone = branchTelephoneTextBox.Text.Trim();

            byte branchStatus = 0;

            if (nonAktifCheckbox.Checked)
                branchStatus = 0;
            else
                branchStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_BRANCH:
                        sqlCommand = "INSERT INTO MASTER_BRANCH (BRANCH_NAME, BRANCH_ADDRESS_1, BRANCH_ADDRESS_2, BRANCH_ADDRESS_CITY, BRANCH_TELEPHONE, BRANCH_IP4, BRANCH_ACTIVE) " +
                                            "VALUES ('" + branchName + "', '" + branchAddress1 + "', '" + branchAddress2 + "', '" + branchAddressCity + "', '" + branchPhone + "', '" + branchIPv4 + "', " + branchStatus + ")";
                        break;
                    case globalConstants.EDIT_BRANCH:
                        sqlCommand = "UPDATE MASTER_BRANCH SET " +
                                            "BRANCH_NAME = '" + branchName + "', " +
                                            "BRANCH_ADDRESS_1 = '" + branchAddress1 + "', " +
                                            "BRANCH_ADDRESS_2 = '" + branchAddress2 + "', " +
                                            "BRANCH_ADDRESS_CITY = '" + branchAddressCity + "', " +
                                            "BRANCH_TELEPHONE = '" + branchPhone + "', " +
                                            "BRANCH_IP4 = '" + branchIPv4 + "', " +
                                            "BRANCH_ACTIVE = '" + branchStatus + "' " +
                                            "WHERE BRANCH_ID = '" + selectedBranchID + "'";
                        //sqlCommand = "UPDATE `sys_pos`.`master_branch` SET `BRANCH_ACTIVE`='1' WHERE `BRANCH_ID`='3';";
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
                foreach (Control ctl in this.Controls)
                {
                    switch (ctl.GetType().ToString())
                    {
                        case "TextBox":
                            ctl.Text = null;
                            break;
                        case "ComboBox":
                            ctl.Text = null;
                            break;
                    }
                }
            }
        }

        private void dataCabangDetailForm_Load(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.EDIT_BRANCH)
            {
                nonAktifCheckbox.Enabled = true;
                loadBranchDataInformation();
            }
            else
            {
                nonAktifCheckbox.Enabled = false;
            }

            errorLabel.Text = "";
        }


    }
}

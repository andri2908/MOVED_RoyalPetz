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
        private globalUtilities gUtil = new globalUtilities();
        private int options = 0;
        private Data_Access DS = new Data_Access();
        private string selectedIP = "";
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
            string ip1, ip2, ip3, ip4;

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_BRANCH WHERE BRANCH_ID =  " + selectedBranchID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        branchNameTextBox.Text = rdr.GetString("BRANCH_NAME");
                        selectedIP = rdr.GetString("BRANCH_IP4");
                        branchAddress1TextBox.Text = rdr.GetString("BRANCH_ADDRESS_1");
                        branchAddress2TextBox.Text = rdr.GetString("BRANCH_ADDRESS_2");
                        branchAddressCityTextBox.Text = rdr.GetString("BRANCH_ADDRESS_CITY");
                        branchTelephoneTextBox.Text = rdr.GetString("BRANCH_TELEPHONE");
                        
                        if (rdr.GetString("BRANCH_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;

                        string tmp = selectedIP;
                        int pos = tmp.IndexOf(".");
                        string tmp2 = tmp.Substring(0, pos);
                        ip1 = tmp2;
                        ip1Textbox.Text = ip1;
                        tmp = tmp.Substring(pos + 1);
                        pos = tmp.IndexOf(".");
                        tmp2 = tmp.Substring(0, pos);
                        ip2 = tmp2;
                        ip2Textbox.Text = ip2;
                        tmp = tmp.Substring(pos + 1);
                        pos = tmp.IndexOf(".");
                        tmp2 = tmp.Substring(0, pos);
                        ip3 = tmp2;
                        ip3Textbox.Text = ip3;
                        tmp = tmp.Substring(pos + 1);
                        ip4 = tmp;
                        ip4Textbox.Text = ip4;
                    }
                }
            }
        }

        private bool ipAddressExist()
        {
            bool result = false;
            int rowCount;
            string ipAddress = ip1Textbox.Text.Trim() + "." + ip2Textbox.Text.Trim() + "." + ip3Textbox.Text.Trim() + "." + ip4Textbox.Text.Trim();

            rowCount = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_BRANCH WHERE BRANCH_IP4 = '" + ipAddress + "'"));

            if (rowCount > 0)
                result = true;

            return result;
        }

        private bool dataValidated()
        {
            if (branchNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA CABANG TIDAK BOLEH KOSONG";
                return false;
            }

            if (ip1Textbox.Text.Trim().Equals("") || ip2Textbox.Text.Trim().Equals("") || ip3Textbox.Text.Trim().Equals("") || ip4Textbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "IP ADDRESS TIDAK VALID";
                return false;
            }

            //if (ipAddressExist())
           // {
            //    errorLabel.Text = "IP ADDRESS SUDAH TERDAFTAR";
             //   return false;
           // }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string branchName = MySqlHelper.EscapeString(branchNameTextBox.Text.Trim());
            string branchIPv4 = ip1Textbox.Text.Trim() + "." + ip2Textbox.Text.Trim() + "." + ip3Textbox.Text.Trim() + "." + ip4Textbox.Text.Trim();
            string branchAddress1 = MySqlHelper.EscapeString(branchAddress1TextBox.Text.Trim());
            string branchAddress2 = MySqlHelper.EscapeString(branchAddress2TextBox.Text.Trim());
            string branchAddressCity = MySqlHelper.EscapeString(branchAddressCityTextBox.Text.Trim());
            string branchPhone = MySqlHelper.EscapeString(branchTelephoneTextBox.Text.Trim());

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
                //MessageBox.Show("SUCCESS");

                switch(originModuleID)
                {
                    case globalConstants.NEW_BRANCH:
                        gUtil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_CABANG, globalConstants.CHANGE_LOG_INSERT, "ADD NEW CABANG [" + branchNameTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_BRANCH:
                        if (nonAktifCheckbox.Checked == true)
                            gUtil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_CABANG, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NEW CABANG [" + branchNameTextBox.Text + "] CABANG STATUS = AKTIF");
                        else
                            gUtil.saveUserChangeLog(globalConstants.MENU_MANAJEMEN_CABANG, globalConstants.CHANGE_LOG_UPDATE, "UPDATE NEW CABANG [" + branchNameTextBox.Text + "] CABANG STATUS = NON AKTIF");
                        break;
                }

                gUtil.showSuccess(options);
                gUtil.ResetAllControls(this);

                originModuleID = globalConstants.NEW_BRANCH;
                options = gUtil.INS;
            }
        }

        private void dataCabangDetailForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];
                        
            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_MANAJEMEN_CABANG, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_BRANCH)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_BRANCH)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gUtil.reArrangeButtonPosition(arrButton, 343, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);

            originModuleID = globalConstants.NEW_BRANCH;
            options = gUtil.INS;
        }

        private void dataCabangDetailForm_Activated(object sender, EventArgs e)
        {    
            switch (originModuleID)
            {
                case globalConstants.NEW_BRANCH:
                    options = gUtil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_BRANCH:
                    options = gUtil.UPD;
                    nonAktifCheckbox.Enabled = true;
                    loadBranchDataInformation();
                    break;
            }
            errorLabel.Text = "";
        }

        private void ip1Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip2Textbox.Focus();
        }

        private void ip2Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip3Textbox.Focus();
        }

        private void ip3Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip4Textbox.Focus();
        }
    }
}

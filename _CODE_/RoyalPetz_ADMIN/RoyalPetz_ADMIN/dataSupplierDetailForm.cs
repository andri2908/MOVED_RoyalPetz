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
using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    public partial class dataSupplierDetailForm : Form
    {
        private int selectedSupplierID;
        private int originModuleID;

        private string previousInputPhone = "";
        private string previousInputFax = "";

        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private int options = 0;
        
        public dataSupplierDetailForm()
        {
            InitializeComponent();
        }

        public dataSupplierDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataSupplierDetailForm(int moduleID, int supplierID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedSupplierID = supplierID;
        }

        private void loadSupplierData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_SUPPLIER WHERE SUPPLIER_ID =  " + selectedSupplierID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        supplierNameTextBox.Text = rdr.GetString("SUPPLIER_FULL_NAME");
                        supplierAddress1TextBox.Text = rdr.GetString("SUPPLIER_ADDRESS1");
                        supplierAddress2TextBox.Text = rdr.GetString("SUPPLIER_ADDRESS2");
                        supplierAddressCityTextBox.Text = rdr.GetString("SUPPLIER_ADDRESS_CITY");
                        supplierPhoneTextBox.Text = rdr.GetString("SUPPLIER_PHONE");
                        supplierFaxTextBox.Text = rdr.GetString("SUPPLIER_FAX");
                        supplierEmailTextBox.Text = rdr.GetString("SUPPLIER_EMAIL");

                        if (rdr.GetString("SUPPLIER_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private void dataSupplierDetailForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private bool dataValidated()
        {
            if (supplierNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA SUPPLIER TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string suppName = MySqlHelper.EscapeString(supplierNameTextBox.Text.Trim());

            string suppAddress1 = MySqlHelper.EscapeString(supplierAddress1TextBox.Text.Trim());
            if (suppAddress1.Equals(""))
                suppAddress1 = " ";

            string suppAddress2 = MySqlHelper.EscapeString(supplierAddress2TextBox.Text.Trim());
            if (suppAddress2.Equals(""))
                suppAddress2 = " ";

            string suppAddressCity = MySqlHelper.EscapeString(supplierAddressCityTextBox.Text.Trim());
            if (suppAddressCity.Equals(""))
                suppAddressCity = " ";

            string suppPhone = supplierPhoneTextBox.Text.Trim();
            if (suppPhone.Equals(""))
                suppPhone = " ";

            string suppFax = supplierFaxTextBox.Text.Trim();
            if (suppFax.Equals(""))
                suppFax = " ";

            string suppEmail = MySqlHelper.EscapeString(supplierEmailTextBox.Text.Trim());
            if (suppEmail.Equals(""))
                suppEmail = " ";

            byte suppStatus = 0;

            if (nonAktifCheckbox.Checked)
                suppStatus = 0;
            else
                suppStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_SUPPLIER:
                        sqlCommand = "INSERT INTO MASTER_SUPPLIER " +
                                            "(SUPPLIER_FULL_NAME, SUPPLIER_ADDRESS1, SUPPLIER_ADDRESS2, SUPPLIER_ADDRESS_CITY, SUPPLIER_PHONE, SUPPLIER_FAX, SUPPLIER_EMAIL, SUPPLIER_ACTIVE) " +
                                            "VALUES ('" + suppName + "', '" + suppAddress1 + "', '" + suppAddress2 + "', '" + suppAddressCity + "', '" + suppPhone + "', '" + suppFax + "', '" + suppEmail + "', " + suppStatus + ")";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_SUPPLIER, "INSERT NEW SUPPLIER [" + suppName + "]");
                        break;
                    case globalConstants.EDIT_SUPPLIER:

                        sqlCommand = "UPDATE MASTER_SUPPLIER SET " +
                                            "SUPPLIER_FULL_NAME = '" + suppName + "', " +
                                            "SUPPLIER_ADDRESS1 = '" + suppAddress1 + "', " +
                                            "SUPPLIER_ADDRESS2 = '" + suppAddress2 + "', " +
                                            "SUPPLIER_ADDRESS_CITY = '" + suppAddressCity + "', " +
                                            "SUPPLIER_PHONE = '" + suppPhone + "', " +
                                            "SUPPLIER_FAX = '" + suppFax + "', " +
                                            "SUPPLIER_EMAIL = '" + suppEmail + "', " +
                                            "SUPPLIER_ACTIVE = " + suppStatus + " " +
                                            "WHERE SUPPLIER_ID = " + selectedSupplierID;
                        gUtil.saveSystemDebugLog(globalConstants.MENU_SUPPLIER, "UPDATE SUPPLIER [" + selectedSupplierID+ "]");
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_SUPPLIER, "EXCEPTION THROWN [" + e.Message + "]");
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
            gUtil.saveSystemDebugLog(globalConstants.MENU_SUPPLIER, "ATTEMPT TO SAVE");
            if (saveData())
            {
                switch (originModuleID)
                {
                    case globalConstants.NEW_SUPPLIER:
                        gUtil.saveUserChangeLog(globalConstants.MENU_SUPPLIER, globalConstants.CHANGE_LOG_INSERT, "INSERT NEW SUPPLIER [" + supplierNameTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_SUPPLIER:
                        if (nonAktifCheckbox.Checked == true)
                            gUtil.saveUserChangeLog(globalConstants.MENU_SUPPLIER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE SUPPLIER [" + supplierNameTextBox.Text + "] STATUS NON-AKTIF");
                        else
                            gUtil.saveUserChangeLog(globalConstants.MENU_SUPPLIER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE SUPPLIER [" + supplierNameTextBox.Text + "] STATUS AKTIF");
                        break;
                }
                gUtil.showSuccess(options);
                gUtil.ResetAllControls(this);
                originModuleID = globalConstants.NEW_SUPPLIER;
                options = gUtil.INS;
            }
        }

        private void supplierPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gUtil.matchRegEx(supplierPhoneTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputPhone = supplierPhoneTextBox.Text;
            }
            else
            {
                supplierPhoneTextBox.Text = previousInputPhone;
            }
        }

        private void supplierFaxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gUtil.matchRegEx(supplierFaxTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputFax = supplierFaxTextBox.Text;
            }
            else
            {
                supplierFaxTextBox.Text = previousInputFax;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);
            originModuleID = globalConstants.NEW_SUPPLIER;
            options = gUtil.INS;
        }

        private void dataSupplierDetailForm_Activated(object sender, EventArgs e)
        {
            /*if (selectedSupplierID != 0)  //old code
                loadSupplierData(); */
            errorLabel.Text = "";
            switch (originModuleID)
            {
                case globalConstants.NEW_SUPPLIER:
                    options = gUtil.INS;
                    nonAktifCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_SUPPLIER:
                    options = gUtil.UPD;
                    nonAktifCheckbox.Enabled = true;
                    loadSupplierData();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    public partial class dataPelangganDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedCustomerID = 0;

        private string previousInput = "";
        private string previousInputPhone = "";
        private string previousInputFax = "";
        
        private DateTime localDate = DateTime.Now;
        private CultureInfo culture = new CultureInfo("id-ID");

        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private int options = 0;
        

        public dataPelangganDetailForm()
        {
            InitializeComponent();
        }

        public dataPelangganDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataPelangganDetailForm(int moduleID, int customerID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedCustomerID = customerID;
        }

        private void loadCustomerData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_CUSTOMER WHERE CUSTOMER_ID =  " + selectedCustomerID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        dateJoinedDateTimePicked.Value = rdr.GetDateTime("CUSTOMER_JOINED_DATE");

                        custNameTextBox.Text = rdr.GetString("CUSTOMER_FULL_NAME");
                        custAddress1TextBox.Text = rdr.GetString("CUSTOMER_ADDRESS1");
                        custAddress2TextBox.Text = rdr.GetString("CUSTOMER_ADDRESS2");
                        custAddressCityTextBox.Text = rdr.GetString("CUSTOMER_ADDRESS_CITY");
                        custTelTextBox.Text = rdr.GetString("CUSTOMER_PHONE");
                        custFaxTextBox.Text = rdr.GetString("CUSTOMER_FAX");
                        custEmailTextBox.Text = rdr.GetString("CUSTOMER_EMAIL");
                        custTotalSalesTextBox.Text = rdr.GetString("CUSTOMER_TOTAL_SALES_COUNT");

                        groupPelangganCombo.SelectedIndex = rdr.GetInt32("CUSTOMER_GROUP") - 1;

                        if (rdr.GetString("CUSTOMER_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private void dataPelangganDetailForm_Load(object sender, EventArgs e)
        {
            dateJoinedDateTimePicked.Format = DateTimePickerFormat.Custom;
            dateJoinedDateTimePicked.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            gUtil.reArrangeTabOrder(this);
        }

        private bool dataValidated()
        {
            if (custNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA CUSTOMER TIDAK BOLEH KOSONG";
                return false;
            }

            if (custNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA CUSTOMER TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string selectedDate = dateJoinedDateTimePicked.Value.ToShortDateString();
            string custJoinedDate = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));
            string custName = custNameTextBox.Text.Trim();

            string custAddress1 = custAddress1TextBox.Text.Trim();
            if (custAddress1.Equals(""))
                custAddress1 = " ";

            string custAddress2 = custAddress2TextBox.Text.Trim();
            if (custAddress2.Equals(""))
                custAddress2 = " ";
            
            string custAddressCity = custAddressCityTextBox.Text.Trim();
            if (custAddressCity.Equals(""))
                custAddressCity = " ";

            string custPhone = custTelTextBox.Text.Trim();
            if (custPhone.Equals(""))
                custPhone = " ";

            string custFax = custFaxTextBox.Text.Trim();
            if (custFax.Equals(""))
                custFax = " ";

            string custEmail = custEmailTextBox.Text.Trim();
            if (custEmail.Equals(""))
                custEmail = " ";

            string custTotalSales = custTotalSalesTextBox.Text.Trim();
            if (custTotalSales.Equals(""))
                custTotalSales = "0";
            
            int custGroup = groupPelangganCombo.SelectedIndex + 1;

            byte custStatus = 0;

            if (nonAktifCheckbox.Checked)
                custStatus = 0;
            else
                custStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_CUSTOMER:
                        sqlCommand = "INSERT INTO MASTER_CUSTOMER " +
                                            "(CUSTOMER_FULL_NAME, CUSTOMER_ADDRESS1, CUSTOMER_ADDRESS2, CUSTOMER_ADDRESS_CITY, CUSTOMER_PHONE, CUSTOMER_FAX, CUSTOMER_EMAIL, CUSTOMER_ACTIVE, CUSTOMER_JOINED_DATE, CUSTOMER_TOTAL_SALES_COUNT, CUSTOMER_GROUP) " +
                                            "VALUES ('" + custName + "', '" + custAddress1 + "', '" + custAddress2 + "', '" + custAddressCity+ "', '" + custPhone + "', '" + custFax + "', '" + custEmail + "', "+custStatus+", STR_TO_DATE('"+custJoinedDate+"', '%d-%m-%Y'), "+custTotalSales+", "+custGroup+")";
                        break;
                    case globalConstants.EDIT_CUSTOMER:

                        sqlCommand = "UPDATE MASTER_CUSTOMER SET " +
                                            "CUSTOMER_FULL_NAME = '" + custName + "', " +
                                            "CUSTOMER_ADDRESS1 = '" + custAddress1 + "', " +
                                            "CUSTOMER_ADDRESS2 = '" + custAddress2 + "', " +
                                            "CUSTOMER_ADDRESS_CITY = '" + custAddressCity + "', " +
                                            "CUSTOMER_PHONE = '" + custPhone + "', " +
                                            "CUSTOMER_FAX = '" + custFax + "', " +
                                            "CUSTOMER_EMAIL = '" + custEmail + "', " +
                                            "CUSTOMER_ACTIVE = " + custStatus + ", " +
                                            "CUSTOMER_JOINED_DATE = STR_TO_DATE('" + custJoinedDate + "', '%d-%m-%Y'), " +
                                            "CUSTOMER_TOTAL_SALES_COUNT = " + custTotalSales + ", " +
                                            "CUSTOMER_GROUP = " + custGroup + " " +
                                            "WHERE CUSTOMER_ID = " + selectedCustomerID;
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
                gUtil.showSuccess(options);
                gUtil.ResetAllControls(this);
            }
        }

        private void custTotalSalesTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gUtil.matchRegEx(custTotalSalesTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInput = custTotalSalesTextBox.Text;
            }
            else
            {
                custTotalSalesTextBox.Text = previousInput;
            }
        }

        private void custTelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gUtil.matchRegEx(custTelTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputPhone = custTelTextBox.Text;
            }
            else
            {
                custTelTextBox.Text = previousInputPhone;
            }
        }

        private void custFaxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gUtil.matchRegEx(custFaxTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputFax= custFaxTextBox.Text;
            }
            else
            {
                custFaxTextBox.Text = previousInputFax;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);
        }

        private void dataPelangganDetailForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            switch (originModuleID)
            {
                case globalConstants.NEW_CUSTOMER:
                    nonAktifCheckbox.Enabled = false;
                    groupPelangganCombo.SelectedIndex = 0;
                    options = gUtil.INS;
                    break;

                case globalConstants.EDIT_CUSTOMER:
                    nonAktifCheckbox.Enabled = true;
                    loadCustomerData();
                    options = gUtil.UPD;
                    break;
            }
        }
    }
}

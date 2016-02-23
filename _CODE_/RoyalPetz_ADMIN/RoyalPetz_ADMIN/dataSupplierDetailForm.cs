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
            if (selectedSupplierID != 0)
                loadSupplierData();

            errorLabel.Text = "";
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

            string suppName = supplierNameTextBox.Text.Trim();

            string suppAddress1 = supplierAddress1TextBox.Text.Trim();
            if (suppAddress1.Equals(""))
                suppAddress1 = " ";

            string suppAddress2 = supplierAddress2TextBox.Text.Trim();
            if (suppAddress2.Equals(""))
                suppAddress2 = " ";

            string suppAddressCity = supplierAddressCityTextBox.Text.Trim();
            if (suppAddressCity.Equals(""))
                suppAddressCity = " ";

            string suppPhone = supplierPhoneTextBox.Text.Trim();
            if (suppPhone.Equals(""))
                suppPhone = " ";

            string suppFax = supplierFaxTextBox.Text.Trim();
            if (suppFax.Equals(""))
                suppFax = " ";

            string suppEmail = supplierEmailTextBox.Text.Trim();
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
            }
        }

        private void supplierPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            //string regExValue = "";

            //regExValue = @"^[0-9]*$";
            //Regex r = new Regex(regExValue); // This is the main part, can be altered to match any desired form or limitations
            //Match m = r.Match(supplierPhoneTextBox.Text);

            //if (m.Success)
            if (gUtil.matchRegEx(supplierPhoneTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputPhone = supplierPhoneTextBox.Text;
            }
            else
            {
                supplierPhoneTextBox.Text = previousInputPhone;
            }
        }

        private void supplierFaxTextBox_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void supplierFaxTextBox_TextChanged(object sender, EventArgs e)
        {
            //string regExValue = "";

            //regExValue = @"^[0-9]*$";
            //Regex r = new Regex(regExValue); // This is the main part, can be altered to match any desired form or limitations
            //Match m = r.Match(supplierFaxTextBox.Text);

            //if (m.Success)
            if (gUtil.matchRegEx(supplierFaxTextBox.Text, globalUtilities.REGEX_NUMBER_ONLY))
            {
                previousInputFax = supplierFaxTextBox.Text;
            }
            else
            {
                supplierFaxTextBox.Text = previousInputFax;
            }
        }

    }
}

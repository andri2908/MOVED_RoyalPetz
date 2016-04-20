using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    class globalUtilities
    {
        public const string REGEX_NUMBER_WITH_2_DECIMAL = @"^[0-9]+\.?\d{0,2}$";
        public const string REGEX_NUMBER_ONLY = @"^[0-9]*$";
        public const string REGEX_ALPHANUMERIC_ONLY = @"^[0-9A-Za-z]*$";
        public const string CUSTOM_DATE_FORMAT = "dd MMM yyyy";
        public int INS = 1;
        public int UPD = 2;
        private Data_Access DS = new Data_Access();
        private static int userID = 0;
        private static int userGroupID = 0;
        private static int papermode = 0; //0 = cashier mode, 1 = 1/2 kwarto, 2 = kwarto

        public void setUserID(int selectedUserID)
        {
            userID = selectedUserID;
        }

        public int getUserID()
        {
            return userID;
        }

        public void setPaper(int selectedpaper)
        {
            papermode = selectedpaper;
        }

        public int getPaper()
        {
            return papermode;
        }
        public void setUserGroupID(int selectedUserGroupID)
        {
            userGroupID = selectedUserGroupID;
        }

        public int getUserGroupID()
        {
            return userGroupID;
        }

        public string allTrim(string valueToTrim)
        {
            string temp = "";

            temp = valueToTrim.Replace(" ", "");

            return temp;
        }

        public bool matchRegEx(string textToMatch, string regExValue)
        {
            Regex r = new Regex(regExValue); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(textToMatch);

            return m.Success;
        }

        public int loadbranchID(int opt,out string namacabang)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DS.mySqlConnect();
            namacabang = "PUSAT";
            int rslt = 0;
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(S.BRANCH_ID,0) AS 'ID', B.BRANCH_NAME AS 'NAME' FROM SYS_CONFIG S, MASTER_BRANCH B WHERE S.BRANCH_ID = B.BRANCH_ID AND ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            namacabang = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ID")))
                        {
                            rslt = rdr.GetInt32("ID");
                        }
                    if (rslt == 0 )
                    {
                        namacabang = "PUSAT";
                    }
                    
                }
            }
            return rslt;
        }

        public bool loadinfotoko(int opt, out string NamaToko, out string AlamatToko, out string TeleponToko, out string EmailToko)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            //string NamaToko, AlamatToko, TeleponToko, EmailToko;
            DS.mySqlConnect();
            NamaToko = "";
            AlamatToko = "";
            TeleponToko = "";
            EmailToko = "";
            bool rslt = false;
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    rslt = true;
                    while (rdr.Read())
                    {
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            NamaToko = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ADDRESS")))
                        {
                            AlamatToko = rdr.GetString("ADDRESS");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("PHONE")))
                        {
                            TeleponToko = rdr.GetString("PHONE");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("EMAIL")))
                        {
                            EmailToko = rdr.GetString("EMAIL");
                        }
                    }
                } else
                {
                    rslt = false;
                }
            }
            return rslt;
        }

        public void ClearControls(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedtextBox = (MaskedTextBox)control;
                    maskedtextBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                    { 
                        comboBox.SelectedIndex = 0;
                        comboBox.Text = "";
                    }
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }

        public void ResetAllControls(Control form)
        {
            String typectrl = "";
            ClearControls(form); //if controls are not nested
            for (int i = 0; i <= form.Controls.Count - 1; i++) //if controls are nested
            {

                typectrl = "" + form.Controls[i].GetType();
                //MessageBox.Show(typectrl);
                if ((typectrl.Equals("System.Windows.Forms.Panel")) || (typectrl.Equals("System.Windows.Forms.TableLayoutPanel")))
                {
                    Control ctrl = form.Controls[i];
                    //MessageBox.Show("" + ctrl.Controls.Count);
                    //ClearControls(ctrl);
                   ResetAllControls(ctrl);
                }
            }
        }

        public void disableControls(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.ReadOnly = true;
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedtextBox = (MaskedTextBox)control;
                    maskedtextBox.ReadOnly = true;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.Enabled = false;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Enabled = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.Enabled = false;
                }

                if (control is DataGridView)
                {
                    DataGridView dgView = (DataGridView)control;
                    dgView.Enabled = false;
                }

                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Enabled = false;
                }
            }
        }

        public void setReadOnlyAllControls(Control form)
        {
            String typectrl = "";
            disableControls(form); //if controls are not nested
            for (int i = 0; i <= form.Controls.Count - 1; i++) //if controls are nested
            {

                typectrl = "" + form.Controls[i].GetType();
                //MessageBox.Show(typectrl);
                if ((typectrl.Equals("System.Windows.Forms.Panel")) || (typectrl.Equals("System.Windows.Forms.TableLayoutPanel")))
                {
                    Control ctrl = form.Controls[i];
                    //MessageBox.Show("" + ctrl.Controls.Count);
                    //ClearControls(ctrl);
                    setReadOnlyAllControls(ctrl);
                }
            }
        }

        public string validateDecimalNumericInput(double inputNumeric)
        {
            char charToCheck = ',';
            char replacementChar = '.';
            string tempInputNumeric = "";
            string inputNumericString = inputNumeric.ToString();

            tempInputNumeric = inputNumericString.Replace(charToCheck, replacementChar);

            return tempInputNumeric; 
        }

        public void reArrangeTabOrder(Control form)
        {
            TabOrderManager.TabScheme scheme;
            scheme = TabOrderManager.TabScheme.DownFirst;
            TabOrderManager tom = new TabOrderManager(form);
            tom.SetTabOrder(scheme);

        }

        public void showError(string errormessage)
        {
            String errorcaption = "POS Error Message";
            DialogResult res1 = MessageBox.Show(errormessage, errorcaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showDBOPError(Exception ex, string dbOp)
        {
            String errorcaption = "POS Error Message";
            string displayedErrorMessage;
            
            displayedErrorMessage = "An exception of type " + ex.GetType() + " and message [" + ex.Message +"] was encountered while " + dbOp +" the data.";

            DialogResult res1 = MessageBox.Show(displayedErrorMessage, errorcaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showSuccess(int options)
        {
            String successcaption = "POS Success Message";
            String successmessage = "";
            if (options == INS) //insert success
            {
                successmessage = "Saving data to table success!";
            }
            else
            {
                if (options == UPD)
                {
                    successmessage = "Update data to table success!";

                }
            }

            DialogResult res1 = MessageBox.Show(successmessage, successcaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void showError()
        {
            String errorcaption = "IO Error Message";
            /*if (options == 1)
            {
                errorcaption = "POS Error Message";
            }
            else
            {
                errorcaption = "IO Error Message";
            }*/
            String errormessage = "File Read/Write Error Message";
            /*if (options == 1)
            {
                errormessage = "POS Error Message";
            }
            else
            {
                errormessage = "File Read/Write Error Message";
            }*/

            DialogResult res1 = MessageBox.Show(errormessage, errorcaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

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
using System.Globalization;
using System.IO;

namespace RoyalPetz_ADMIN
{
    class globalUtilities
    {
        public const string REGEX_NUMBER_WITH_2_DECIMAL = @"^[0-9]+\.?\d{0,2}$";
        public const string REGEX_NUMBER_ONLY = @"^[0-9]*$";
        public const string REGEX_ALPHANUMERIC_ONLY = @"^[0-9A-Za-z]*$";
        public const string CUSTOM_DATE_FORMAT = "dd MMM yyyy";
        private const string logFileName = "system.log";

        public int INS = 1;
        public int UPD = 2;
        private Data_Access DS = new Data_Access();
        private static int userID = 0;
        private static int userGroupID = 0;
        private static string userName = "";
        private static int papermode = 0; //0 = cashier mode, 1 = 1/2 kwarto, 2 = kwarto
        private static StreamWriter sw = null;

        private CultureInfo culture = new CultureInfo("id-ID");

        public void setUserID(int selectedUserID)
        {
            userID = selectedUserID;

            userName = DS.getDataSingleValue("SELECT IFNULL(USER_NAME, '') FROM MASTER_USER WHERE ID = "+userID).ToString();
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

        public int userIsCashier()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT GROUP_IS_CASHIER FROM MASTER_GROUP WHERE GROUP_ID = " + getUserGroupID()));

            return result;
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
                    textBox.Text = "";
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedtextBox = (MaskedTextBox)control;
                    maskedtextBox.Text = "";
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
                Control ctrl = form.Controls[i];
                //MessageBox.Show(typectrl);
                if ((typectrl.Equals("System.Windows.Forms.Panel")) || (typectrl.Equals("System.Windows.Forms.TableLayoutPanel")))
                {
                    //MessageBox.Show("" + ctrl.Controls.Count);
                    //ClearControls(ctrl);
                    ResetAllControls(ctrl);
                }
                else
                    ClearControls(ctrl);
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

        public bool checkNewMessageData()
        {
            int moduleID = 0;
            string sqlCommand = "";
            string dateToday = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(DateTime.Now));
            string roExpiredDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now.AddDays(7));

            // PULL SALES INVOICE THAT'S DUE TODAY
            moduleID = globalConstants.MENU_TRANSAKSI_PENJUALAN;
            sqlCommand = "SELECT COUNT(1) FROM SALES_HEADER WHERE SALES_PAID = 0 AND DATE_FORMAT(SALES_TOP_DATE, '%Y%m%d')  <= '" + dateToday + "' AND SALES_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            // PULL PURCHASE INVOICE THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PURCHASE_ORDER;
            sqlCommand = "SELECT COUNT(1) FROM PURCHASE_HEADER WHERE PURCHASE_PAID = 0 AND PURCHASE_RECEIVED = 1 AND DATE_FORMAT(PURCHASE_TERM_OF_PAYMENT_DATE, '%Y%m%d')  <= '" + dateToday + "'  AND PURCHASE_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            // PULL PAYMENT CREDIT THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PEMBAYARAN_PIUTANG;
            sqlCommand = "SELECT COUNT(1) FROM SALES_HEADER SH, CREDIT C, PAYMENT_CREDIT PC WHERE C.CREDIT_PAID = 0 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = SH.SALES_INVOICE AND PC.PAYMENT_CONFIRMED = 0 AND PC.PAYMENT_INVALID = 0 AND DATE_FORMAT(PC.PAYMENT_DUE_DATE, '%Y%m%d')  <= '" + dateToday + "'  AND SH.SALES_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            // PULL PAYMENT DEBT THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER;
            sqlCommand = "SELECT COUNT(1) FROM PURCHASE_HEADER PH, DEBT D, PAYMENT_DEBT PD WHERE D.DEBT_PAID = 0 AND PD.DEBT_ID = D.DEBT_ID AND D.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PD.PAYMENT_CONFIRMED = 0 AND PD.PAYMENT_INVALID = 0 AND DATE_FORMAT(PD.PAYMENT_DUE_DATE, '%Y%m%d')  <= '" + dateToday + "'   AND PH.PURCHASE_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            // PULL REQUEST ORDER THAT'LL EXPIRE NEXT WEEK OR EARLIER
            moduleID = globalConstants.MENU_REQUEST_ORDER;
            sqlCommand = "SELECT COUNT(1) FROM REQUEST_ORDER_HEADER WHERE RO_ACTIVE = 1 AND DATE_FORMAT(RO_EXPIRED, '%Y%m%d')  <= '" + roExpiredDate + "'  AND RO_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            // PULL PRODUCT_ID THAT ALREADY HIT LIMIT STOCK
            moduleID = globalConstants.MENU_PRODUK;
            sqlCommand = "SELECT COUNT(1) FROM  MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_IS_SERVICE = 0 AND PRODUCT_STOCK_QTY <= PRODUCT_LIMIT_STOCK AND PRODUCT_ID NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                return true;

            return false;
        }

        public void reArrangeTabOrder(Control form)
        {
            TabOrderManager.TabScheme scheme;
            scheme = TabOrderManager.TabScheme.DownFirst;
            TabOrderManager tom = new TabOrderManager(form);
            tom.SetTabOrder(scheme);

        }

        public void reArrangeButtonPosition(Button []buttonArr, int startPositionY, int formWidth)
        {
            int buttonCount = 0;
            int buttonTotalWidth = 0;
            int buttonDistancePixel = 5;
            int startPositionX = 0;
            double startingPoint = 0;
            int i = 0;

            for (i =0;i<buttonArr.GetLength(0); i++)
            {
                if (buttonArr[i].Visible == true)
                { 
                    buttonCount++;
                    buttonTotalWidth += buttonArr[i].Width;
                    buttonTotalWidth += buttonDistancePixel;
                }
            }

            if (buttonTotalWidth > 0)
                buttonTotalWidth -= buttonDistancePixel;

            startingPoint = (formWidth / 2) - (buttonTotalWidth / 2);
            startPositionX = Convert.ToInt32(Math.Round(startingPoint)); 

            if (startPositionX > 0)
            {
                for (i = 0; i < buttonArr.Count(); i++)
                {
                    if (buttonArr[i].Visible == true)
                    {
                        buttonArr[i].Left = startPositionX;
                        buttonArr[i].Top = startPositionY;
                        startPositionX += buttonArr[i].Width;
                        startPositionX += buttonDistancePixel;
                    }
                }
            }
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

        public void saveUserChangeLog(int moduleID, int changeID, string changeDescription)
        {
            string sqlCommand = "";
            string dateTimeNow = String.Format(culture, "{0:dd-M-yyyy HH:mm}", DateTime.Now);

            DS.beginTransaction();

            try
            { 
                sqlCommand = "INSERT INTO USER_CHANGE_LOG (USER_ID, MODULE_ID, CHANGE_ID, CHANGE_DATETIME, CHANGE_DESCRIPTION) VALUES (" + getUserID() + ", " +moduleID + ", " + changeID + ", STR_TO_DATE('" + dateTimeNow + "', '%d-%m-%Y %H:%i'), '" + changeDescription + "')";
                DS.executeNonQueryCommand(sqlCommand);

                DS.commit();
            }
            catch(Exception ex)
            {}
        }

        public void saveSystemDebugLog(int moduleID, string logMessage)
        {
            string messageToWrite;
            string dateTimeLog = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            string moduleName = "";

            try
            {
                if (moduleID > 0)
                    moduleName = DS.getDataSingleValue("SELECT IFNULL(MODULE_NAME, '') FROM MASTER_MODULE WHERE MODULE_ID = " + moduleID).ToString();

                messageToWrite = "[" + userName + "] [" + dateTimeLog + "] [" + moduleName + "] " + logMessage;

                // if (sw == null)
                {
                    if (!File.Exists(Application.StartupPath + "\\" + logFileName))
                        sw = File.CreateText(Application.StartupPath + "\\" + logFileName);
                    else
                        sw = File.AppendText(Application.StartupPath + "\\" + logFileName);
                }

                sw.WriteLine(messageToWrite);
                sw.Close();
            }
            catch (Exception e)
            { }
        }

        public void renameLogFile()
        {
            if (!Directory.Exists(Application.StartupPath + "\\LOG_FILE"))
                Directory.CreateDirectory(Application.StartupPath + "\\LOG_FILE");

            string oldPath = Application.StartupPath + "\\" + logFileName;
            string dateTimeValue = String.Format(culture, "{0:ddMMyyyyHHmm}", DateTime.Now);
            string newPath = Application.StartupPath + "\\LOG_FILE\\logFile_" + dateTimeValue + ".log";
            if (File.Exists(oldPath))
                File.Move(oldPath, newPath);
        }
    }
}

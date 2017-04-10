﻿using System;
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
using System.Globalization;

using Hotkeys;

namespace AlphaSoft
{
    public partial class cashierLoginForm : Form
    {
        private int loginState = 0;
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private globalUtilities gUtil = new globalUtilities();
        private int logEntryID = 0;
        private DateTime dateTimeLogin;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public cashierLoginForm(int status)
        {
            InitializeComponent();
            loginState = status;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
        }

        private bool dataValidated()
        {
            //if (startAmountBox.Text.Length <= 0 && loginState == 0)
            string textInput = "";

            if (loginState == 0)
            {
                if (textBox1.Text.Length <= 0)
                {
                    errorLabel.Text = "START AMOUNT TIDAK BOLEH KOSONG";
                    return false;
                }

                textInput = gUtil.allTrim(textBox1.Text);
                textInput = textInput.Replace(",", "");
                textInput = textInput.Replace(".", "");

                if (!gUtil.matchRegEx(textInput, globalUtilities.REGEX_NUMBER_ONLY))
                {
                    errorLabel.Text = "INPUT START AMOUNT SALAH";
                    return false;
                }
            }

            //if (endAmountBox.Text.Length <= 0 && loginState == 1)
            if (loginState == 1)
            {
                if (textBox2.Text.Length <= 0 )
                {
                    errorLabel.Text = "END AMOUNT TIDAK BOLEH KOSONG";
                    return false;
                }

                textInput = gUtil.allTrim(textBox2.Text);
                textInput = textInput.Replace(",", "");
                textInput = textInput.Replace(".", "");

                if (!gUtil.matchRegEx(textInput, globalUtilities.REGEX_NUMBER_ONLY))
                {
                    errorLabel.Text = "INPUT END AMOUNT SALAH";
                    return false;
                }
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string dateLogin;
            string dateLogOut;
            string dateTimeFrom;
            string dateTimeTo;
            double totalCashTransaction = 0;
            double totalNonCashTransaction = 0;
            double totalOtherTransaction = 0;
            MySqlException internalEX = null;
            double startAmount = 0;
            string startAmountInput = "";

            double endAmount = 0;
            string endAmountInput = "";

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                if (loginState == 0)
                {
                    //startAmount = Convert.ToDouble(gUtil.allTrim(startAmountBox.Text));
                    startAmountInput = gUtil.allTrim(textBox1.Text);
                    startAmountInput = startAmountInput.Replace(",", "");
                    startAmountInput = startAmountInput.Replace(".", "");
                    startAmount = Convert.ToDouble(startAmountInput);

                    dateLogin = gUtil.getCustomStringFormatDate(DateTime.Now);//String.Format(culture, "{0:dd-M-yyyy HH:mm}", DateTime.Now);

                    // INSERT TO CASHIER LOG
                    sqlCommand = "INSERT INTO CASHIER_LOG (USER_ID, DATE_LOGIN, AMOUNT_START) VALUES (" + gUtil.getUserID() + ", STR_TO_DATE('" + dateLogin + "', '%d-%m-%Y %H:%i'), "+ startAmount + ")";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    gUtil.saveSystemDebugLog(0, "INSERT DATA FOR A NEW CASHIER SESSION, SA="+ startAmount);
                }
                else if (loginState == 1)
                {
                    endAmountInput = gUtil.allTrim(textBox2.Text);
                    endAmountInput = endAmountInput.Replace(",", "");
                    endAmountInput = endAmountInput.Replace(".", "");
                    endAmount = Convert.ToDouble(endAmountInput);

                    dateLogOut = gUtil.getCustomStringFormatDate(DateTime.Now); //String.Format(culture, "{0:dd-M-yyyy HH:mm}", DateTime.Now);

                    dateTimeFrom = String.Format(culture, "{0:yyyyMMddHHmm}", dateTimeLogin);
                    dateTimeTo = String.Format(culture, "{0:yyyyMMddHHmm}", DateTime.Now);

                    //GET TOTAL CASH TRANSACTION
                    sqlCommand = "SELECT IFNULL(SUM(SALES_TOTAL), 0) FROM SALES_HEADER " +
                                           "WHERE SALES_TOP = 1 AND SALES_PAYMENT_METHOD = 0 " +
                                           "AND DATE_FORMAT(SALES_DATE, '%Y%m%d%H%i') >= '" + dateTimeFrom + "' " +
                                           "AND DATE_FORMAT(SALES_DATE, '%Y%m%d%H%i') <= '" + dateTimeTo + "'";
                    totalCashTransaction = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

                    //GET TOTAL NON CASH TRANSACTION
                    sqlCommand = "SELECT IFNULL(SUM(SALES_TOTAL), 0) FROM SALES_HEADER " +
                                           "WHERE SALES_TOP = 1 AND SALES_PAYMENT_METHOD > 0 " +
                                           "AND DATE_FORMAT(SALES_DATE, '%Y%m%d%H%i') >= '" + dateTimeFrom + "' " +
                                           "AND DATE_FORMAT(SALES_DATE, '%Y%m%d%H%i') <= '" + dateTimeTo + "'";
                    totalNonCashTransaction = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

                    //GET TOTAL OTHER TRANSACTION
                    sqlCommand = "SELECT IFNULL(SUM(JOURNAL_NOMINAL), 0) FROM DAILY_JOURNAL DJ, MASTER_ACCOUNT MA " +
                                           "WHERE DJ.PM_ID = 1 AND DJ.ACCOUNT_ID = MA.ACCOUNT_ID AND MA.ACCOUNT_TYPE_ID = 2 " +
                                           "AND DATE_FORMAT(JOURNAL_DATETIME, '%Y%m%d%H%i') >= '" + dateTimeFrom + "' " +
                                           "AND DATE_FORMAT(JOURNAL_DATETIME, '%Y%m%d%H%i') <= '" + dateTimeTo + "'";
                    totalOtherTransaction = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

                    sqlCommand = "UPDATE CASHIER_LOG SET DATE_LOGOUT = STR_TO_DATE('" + dateLogOut + "', '%d-%m-%Y %H:%i'), AMOUNT_END = " + endAmount + ", COMMENT = '" + remarkTextBox.Text + "', TOTAL_CASH_TRANSACTION = " + totalCashTransaction + ", TOTAL_NON_CASH_TRANSACTION = " + totalNonCashTransaction + ", TOTAL_OTHER_TRANSACTION = " + totalOtherTransaction + " WHERE ID = " + logEntryID;
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    gUtil.saveSystemDebugLog(0, "UPDATE DATA FOR CASHIER END SESSION, EA="+ endAmount + ", TC = " +totalCashTransaction+", TN="+totalNonCashTransaction+", TO="+totalOtherTransaction);

                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
            return result;
        }

        private bool saveData()
        {
            bool result = false;
            if (dataValidated())
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return result;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            string messagePrompt = "";

            if (loginState == 0)
                messagePrompt = "SHIFT KASIR MULAI?";
            if (loginState == 2)
                messagePrompt = "SHIFT KASIR DILANJUTKAN";
            else
                messagePrompt = "SHIFT KASIR BERAKHIR?";

           // if (DialogResult.Yes == MessageBox.Show("WARNING", messagePrompt, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (saveData())
                { 
                    this.Hide();

                    gUtil.saveUserChangeLog(0, globalConstants.CHANGE_LOG_CASHIER_LOGIN, "CASHIER LOGIN");

                    if (loginState == 0 || loginState == 2)
                    {
                        adminForm displayAdminForm = new adminForm(gUtil.getUserID(), gUtil.getUserGroupID());
                        displayAdminForm.ShowDialog(this);
                    }

                    if (loginState != 1)
                    {
                        loginState = 1;

                        loadLogData();

                        endAmountBox.Focus();
                        this.Show();
                    }
                    else
                    {
                        gUtil.saveUserChangeLog(0, globalConstants.CHANGE_LOG_CASHIER_LOGOUT, "CASHIER LOGOUT");
                        this.Close();
                    }
                }
                else
                {
                   // this.Close();
                }
            }
        }

        private bool userLoggedOutSuccessfully(int userID)
        {
            bool result = true;

            if (0 < Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM CASHIER_LOG WHERE ISNULL(DATE_LOGOUT) AND USER_ID = "+userID)))
                result = false;
            
            return result;
        }

        private void loadLogData()
        {
            string startTimeValue;
            string endTimeValue;

            if (loginState == 0 && userLoggedOutSuccessfully(gUtil.getUserID()))
            {
                // LOGIN 
                // KEY IN THE STARTING AMOUNT FOR CASHIER MONEY
                gUtil.saveSystemDebugLog(0, "DISPLAY CASHIER LOG SCREEN FOR CASHIER LOGIN");

                //startAmountBox.ReadOnly = false;
                //endAmountBox.ReadOnly = true;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
                remarkTextBox.ReadOnly = true;

                startTimeValue = String.Format(culture, "{0:dd-M-yyyy HH:mm}", DateTime.Now);
                startTimeTextBox.Text = startTimeValue;
            }
            else
            {
                // KEY IN THE END AMOUNT FOR CASHIER MONEY
                gUtil.saveSystemDebugLog(0, "DISPLAY CASHIER LOG SCREEN FOR CASHIER LOGOUT");

                //startAmountBox.ReadOnly = true;
                //endAmountBox.ReadOnly = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                remarkTextBox.ReadOnly = false;

                endTimeValue = String.Format(culture, "{0:dd-M-yyyy HH:mm}", DateTime.Now);
                endTimeTextBox.Text = endTimeValue;

                dateTimeLogin = Convert.ToDateTime(DS.getDataSingleValue("SELECT IFNULL(DATE_LOGIN, NOW()) FROM CASHIER_LOG WHERE ISNULL(DATE_LOGOUT) AND USER_ID = " + gUtil.getUserID() + " ORDER BY DATE_LOGIN DESC LIMIT 1"));
                startTimeValue = String.Format(culture, "{0:dd-M-yyyy HH:mm}", dateTimeLogin);
                startTimeTextBox.Text = startTimeValue;

                //startAmountBox.Text = DS.getDataSingleValue("SELECT IFNULL(AMOUNT_START, 0) FROM CASHIER_LOG WHERE ISNULL(DATE_LOGOUT) AND USER_ID = " + gUtil.getUserID() + " ORDER BY DATE_LOGIN DESC LIMIT 1").ToString();
                textBox1.Text = DS.getDataSingleValue("SELECT IFNULL(AMOUNT_START, 0) FROM CASHIER_LOG WHERE ISNULL(DATE_LOGOUT) AND USER_ID = " + gUtil.getUserID() + " ORDER BY DATE_LOGIN DESC LIMIT 1").ToString();
                genericKeyUp(textBox1);

                logEntryID = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(ID, 0) FROM CASHIER_LOG WHERE ISNULL(DATE_LOGOUT) AND USER_ID = " + gUtil.getUserID() + " ORDER BY DATE_LOGIN DESC LIMIT 1"));

                // LOGOUT or USER HASN'T LOGGED OUT YET
                if (loginState == 0)
                {
                    // USER HASN'T LOGGED OUT YET
                    if (DialogResult.Yes == MessageBox.Show("USER BELUM LOG OUT, CONTINUE ?", "WARNING", MessageBoxButtons.YesNo))
                    {
                        loginState = 2;
                        //endAmountBox.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        remarkTextBox.ReadOnly = true;
                        endTimeTextBox.Text = "";

                        gUtil.saveSystemDebugLog(0, "CASHIER CONTINUE SESSION");
                    }
                    else
                    {
                        loginState = 1;
                        MessageBox.Show("PLEASE LOG OUT AND RELOGIN");
                    }
                }
            }
        }

        private void cashierLoginForm_Load(object sender, EventArgs e)
        {
            //string sqlCommand = "";

            errorLabel.Text = "";
            loadLogData();

            gUtil.reArrangeTabOrder(this);

        }

        private void cashierLoginForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void cashierLoginForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey(); 
        }

        private void genericKeyUp(TextBox textBoxInput)
        {
            string textInput = gUtil.allTrim(textBoxInput.Text);
            textInput = textInput.Replace(",", "");
            textInput = textInput.Replace(".", "");
            double startAmount = 0;

            if (gUtil.matchRegEx(textInput, globalUtilities.REGEX_NUMBER_ONLY))
            {
                startAmount = Convert.ToDouble(textInput);
                textBoxInput.Text = startAmount.ToString(globalUtilities.CELL_FORMATTING_NUMERIC_FORMAT);

                textBoxInput.Select(textBoxInput.Text.Length, 1);
                errorLabel.Text = "";
            }
            else if (textInput.Length >0)
            {
                errorLabel.Text = "INPUT SALAH";
            }
        }

        private void genericKeyDown(TextBox textBoxInput)
        {
            string textInput = gUtil.allTrim(textBoxInput.Text);
            textInput = textInput.Replace(",", "");
            textInput = textInput.Replace(".", "");

            textBoxInput.Text = textInput;

            textBoxInput.Select(textInput.Length, 1);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                genericKeyUp(textBox1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                genericKeyDown(textBox1);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                genericKeyDown(textBox2);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                genericKeyUp(textBox2);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //genericKeyDown(textBox1);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //genericKeyDown(textBox2);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            genericKeyUp(textBox1);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            genericKeyUp(textBox2);
        }
    }
}

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

using Hotkeys;
//using System.Text.RegularExpressions;

namespace AlphaSoft
{
    public partial class konversiSatuanForm : Form
    {
        private int selectedUnit1_ID = 0;
        private int selectedUnit2_ID = 0;

        private const int NEW_CONVERSION = 1;
        private const int EDIT_CONVERSION = 2;
        private string previousInput = "";

        private int currentMode = NEW_CONVERSION;
        private bool isLoading = false;
        
        private globalUtilities gUtil = new globalUtilities();

        Data_Access DS = new Data_Access();

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private bool navKeyRegistered = false;

        public konversiSatuanForm()
        {
            InitializeComponent();
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

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();

            navKeyRegistered = false;
        }

        private void loadUnitData(ComboBox comboControlVisible, ComboBox comboControlHidden, int excludeID = 0)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            comboControlVisible.Items.Clear();
            comboControlHidden.Items.Clear();

            DS.mySqlConnect();

            if (excludeID == 0)
                sqlCommand = "SELECT UNIT_ID, UNIT_NAME FROM MASTER_UNIT WHERE UNIT_ACTIVE = 1 ORDER BY UNIT_NAME ASC";
            else
                sqlCommand = "SELECT UNIT_ID, UNIT_NAME FROM MASTER_UNIT WHERE UNIT_ACTIVE = 1 AND UNIT_ID <> "+excludeID+" ORDER BY UNIT_NAME ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    comboControlVisible.Items.Add(rdr.GetString("UNIT_NAME"));
                    comboControlHidden.Items.Add(rdr.GetString("UNIT_ID"));
                }
            }
        }

        private void konversiSatuanForm_Load(object sender, EventArgs e)
        {
            gUtil.reArrangeTabOrder(this);
        }

        private void displayCurrentSavedConversion(int selectedID)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT CONVERT_UNIT_ID_2, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT', CONVERT_MULTIPLIER AS 'NILAI KONVERSI' FROM UNIT_CONVERT, MASTER_UNIT WHERE CONVERT_UNIT_ID_2 = UNIT_ID AND CONVERT_UNIT_ID_1 = "+selectedUnit1_ID+" ORDER BY UNIT_NAME ASC";

            dataConvertGridView.DataSource = null;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);

                    dataConvertGridView.DataSource = dt;

                    dataConvertGridView.Columns["CONVERT_UNIT_ID_2"].Visible = false;
                    dataConvertGridView.Columns["NAMA UNIT"].Width= 200;
                    dataConvertGridView.Columns["DESKRIPSI UNIT"].Width= 300;
                    dataConvertGridView.Columns["NILAI KONVERSI"].Width = 300;
                }
            }
        }

        private void unit1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;

            selectedIndex = unit1Combo.SelectedIndex;
            selectedUnit1_ID = Convert.ToInt32(unit1ComboHidden.Items[selectedIndex]);

            displayCurrentSavedConversion(selectedUnit1_ID);
            loadUnitData(unit2Combo, unit2ComboHidden, selectedUnit1_ID);
            selectedUnit2_ID = 0;
            unit2Combo.Text = "";

            currentMode = NEW_CONVERSION;
        }

        private void unit2Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;

            selectedIndex = unit2Combo.SelectedIndex;
            selectedUnit2_ID = Convert.ToInt32(unit2ComboHidden.Items[selectedIndex]);
            
            currentMode = NEW_CONVERSION;
        }

        private bool dataValidated()
        {
            if (selectedUnit2_ID == 0)
            {
                errorLabel.Text = "PILIH UNIT 2 DULU";
                return false;
            }

            if (convertValueTextBox.Text.Equals(""))
            {
                errorLabel.Text = "NILAI KONVERSI HARUS DIISI";
                return false;
            }

            return true;
        }

        private double getConvertValue()
        {
            double retVal = 0;
            int dotPos = 0;

            string convertValueText = convertValueTextBox.Text;
            dotPos = convertValueText.IndexOf(".");
            
            if (dotPos == convertValueText.Length - 1)
                convertValueText = convertValueText.Substring(0, dotPos);

            retVal = Convert.ToDouble(convertValueText);

            return retVal;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            double unitConversion = getConvertValue();
            
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (currentMode)
                {
                    case NEW_CONVERSION:
                        sqlCommand = "INSERT INTO UNIT_CONVERT (CONVERT_UNIT_ID_1, CONVERT_UNIT_ID_2, CONVERT_MULTIPLIER) VALUES (" + selectedUnit1_ID + ", " + selectedUnit2_ID + ", " + unitConversion + ")";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "ADD NEW UNIT CONVERT [" + selectedUnit1_ID + "/" + selectedUnit2_ID + "/" + unitConversion + "]");
                        break;
                    case EDIT_CONVERSION:
                        sqlCommand = "UPDATE UNIT_CONVERT SET CONVERT_MULTIPLIER = " + unitConversion + " WHERE CONVERT_UNIT_ID_1 = " + selectedUnit1_ID + " AND CONVERT_UNIT_ID_2 = "+selectedUnit2_ID;
                        gUtil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "UPDATE UNIT CONVERT [" + selectedUnit1_ID + "/" + selectedUnit2_ID + "/" + unitConversion + "]"); break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                        gUtil.showDBOPError(ex, "ROLLBACK");
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

        private void newButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                gUtil.saveUserChangeLog(globalConstants.MENU_SATUAN, globalConstants.CHANGE_LOG_UPDATE, "SET KONVERSI SATUAN [" + unit1Combo.Text + " = " + convertValueTextBox.Text + " " + unit2Combo.Text + "]");
                //MessageBox.Show("SUCCESS");
                gUtil.showSuccess(gUtil.UPD);
                displayCurrentSavedConversion(selectedUnit1_ID);
            }
        }

        private void dataConvertGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataConvertGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataConvertGridView.Rows[selectedrowindex];
            selectedUnit2_ID = Convert.ToInt32(selectedRow.Cells["CONVERT_UNIT_ID_2"].Value);

            unit2Combo.Text = selectedRow.Cells["NAMA UNIT"].Value.ToString();
            convertValueTextBox.Text = selectedRow.Cells["NILAI KONVERSI"].Value.ToString();

            currentMode = EDIT_CONVERSION;
        }

        private void convertValueTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;

            isLoading = true;
            if (convertValueTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                previousInput = "0";
                convertValueTextBox.Text = "0";

                convertValueTextBox.SelectionStart = convertValueTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (convertValueTextBox.Text.IndexOf('0') == 0 && convertValueTextBox.Text.Length > 1 && convertValueTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = convertValueTextBox.Text;
                convertValueTextBox.Text = tempString.Remove(0, 1);
            }

            if (gUtil.matchRegEx(convertValueTextBox.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
            {
                previousInput = convertValueTextBox.Text;
            }
            else
            {
                convertValueTextBox.Text = previousInput;
            }

            convertValueTextBox.SelectionStart = convertValueTextBox.Text.Length;

            isLoading = false;
        }

        private void konversiSatuanForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            loadUnitData(unit1Combo, unit1ComboHidden);

            registerGlobalHotkey();
        }

        private void unit1Combo_Validated(object sender, EventArgs e)
        {
            if (!unit1Combo.Items.Contains(unit1Combo.Text))
                unit1Combo.Focus();
        }

        private void unit2Combo_Validated(object sender, EventArgs e)
        {
            if (!unit2Combo.Items.Contains(unit2Combo.Text))
                unit2Combo.Focus();
        }

        private void genericControl_Enter(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void genericControl_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void konversiSatuanForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void dataConvertGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataConvertGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}

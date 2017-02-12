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

namespace AlphaSoft
{
    public partial class pengaturanLimitPajakForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        bool isLoading = false;
        private string omsetPenjualanValue = "";
        private string omsetPembelianValue = "";
        private string rasioToleransiValue = "";
        private Data_Access DS = new Data_Access();

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public pengaturanLimitPajakForm()
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
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
        }

        private void loadData()
        {
            int dataCount = 0;
            MySqlDataReader rdr;
            dataCount = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM SYS_CONFIG_TAX"));

            if (dataCount > 0)
            {
                using (rdr = DS.getData("SELECT * FROM SYS_CONFIG_TAX"))
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        persentasePenjualan.Text = rdr.GetString("PERSENTASE_PENJUALAN");
                        persentasePembelian.Text = rdr.GetString("PERSENTASE_PEMBELIAN");
                        omsetPenjualan.Text = rdr.GetString("AVERAGE_PENJUALAN_HARIAN");
                        omsetPembelian.Text = rdr.GetString("AVERAGE_PEMBELIAN_HARIAN");
                        rasioToleransi.Text = rdr.GetString("RASIO_TOLERANSI");
                    }
                }
            }
        }

        private void pengaturanLimitPajakForm_Load(object sender, EventArgs e)
        {
            loadData();

            Button[] arrButton = new Button[2];

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void pengaturanLimitPajakForm_Activated(object sender, EventArgs e)
        {
            //if need something
            registerGlobalHotkey();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            if (gutil.allTrim(persentasePenjualan.Text) != "0")
                persentasePenjualan.Text = "0";

            isLoading = true;
            if (omsetPenjualan.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                omsetPenjualanValue = "0";
                omsetPenjualan.Text = "0";

                omsetPenjualan.SelectionStart = omsetPenjualan.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (omsetPenjualan.Text.IndexOf('0') == 0 && omsetPenjualan.Text.Length > 1 && omsetPenjualan.Text.IndexOf("0.") < 0)
            {
                tempString = omsetPenjualan.Text;
                omsetPenjualan.Text = tempString.Remove(0, 1);
            }

            if (gutil.matchRegEx(omsetPenjualan.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                omsetPenjualanValue= omsetPenjualan.Text;
            else
                omsetPenjualan.Text = omsetPenjualanValue;

            omsetPenjualan.SelectionStart = omsetPenjualan.Text.Length;
            isLoading = false;
        }

        private void omsetPembelian_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            if (gutil.allTrim(persentasePembelian.Text) != "0")
                persentasePembelian.Text = "0";

            isLoading = true;
            if (omsetPembelian.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                omsetPembelianValue= "0";
                omsetPembelian.Text = "0";

                omsetPembelian.SelectionStart = omsetPembelian.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (omsetPembelian.Text.IndexOf('0') == 0 && omsetPembelian.Text.Length > 1 && omsetPembelian.Text.IndexOf("0.") < 0)
            {
                tempString = omsetPembelian.Text;
                omsetPembelian.Text = tempString.Remove(0, 1);
            }

            if (gutil.matchRegEx(omsetPembelian.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                omsetPembelianValue = omsetPembelian.Text;
            else
                omsetPembelian.Text = omsetPembelianValue;

            omsetPembelian.SelectionStart = omsetPembelian.Text.Length;
            isLoading = false;
        }

        private void rasioToleransi_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (rasioToleransi.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                rasioToleransiValue = "0";
                rasioToleransi.Text = "0";

                rasioToleransi.SelectionStart = rasioToleransi.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (rasioToleransi.Text.IndexOf('0') == 0 && rasioToleransi.Text.Length > 1 && rasioToleransi.Text.IndexOf("0.") < 0)
            {
                tempString = rasioToleransi.Text;
                rasioToleransi.Text = tempString.Remove(0, 1);
            }

            if (gutil.matchRegEx(rasioToleransi.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                rasioToleransiValue = rasioToleransi.Text;
            else
                rasioToleransi.Text = rasioToleransiValue;

            rasioToleransi.SelectionStart = rasioToleransi.Text.Length;
            isLoading = false;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            int dataCount = 0;
            string sqlCommand = "";

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                dataCount = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM SYS_CONFIG_TAX"));
                if (dataCount > 0)
                { 
                    // UPDATE
                    sqlCommand = "UPDATE SYS_CONFIG_TAX SET PERSENTASE_PENJUALAN = " + gutil.allTrim(persentasePenjualan.Text) + ", PERSENTASE_PEMBELIAN = " + gutil.allTrim(persentasePembelian.Text) + ", " +
                                        "AVERAGE_PENJUALAN_HARIAN = " + omsetPenjualan.Text + ", AVERAGE_PEMBELIAN_HARIAN = " + omsetPembelian.Text + ", RASIO_TOLERANSI = " + rasioToleransi.Text;
                    gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, "UPDATE SYS CONFIG WITH NEW DATA");
                }
                else
                { 
                    // INSERT
                    sqlCommand = "INSERT INTO SYS_CONFIG_TAX (PERSENTASE_PENJUALAN, PERSENTASE_PEMBELIAN, AVERAGE_PENJUALAN_HARIAN, AVERAGE_PEMBELIAN_HARIAN, RASIO_TOLERANSI) " +
                                        "VALUES (" + gutil.allTrim(persentasePenjualan.Text) + ", " + gutil.allTrim(persentasePembelian.Text) + ", " + omsetPenjualan.Text + ", " + omsetPembelian.Text + ", " + rasioToleransi.Text + ")";
                    gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, "INSERT SYS CONFIG WITH NEW DATA");
                }
                DS.executeNonQueryCommand(sqlCommand);
                DS.commit();

                result = true;
            }
            catch(Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, "EXCEPTION THROWN [" + e.Message + "]");

                result = false;
                MessageBox.Show(e.Message);
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, "ATTEMPT TO SAVE DATA LIMIT PAJAK");

            if (saveDataTransaction())
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, "DATA LIMIT PAJAK SAVED");
                gutil.showSuccess(gutil.INS);
                gutil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_LIMIT_PAJAK, globalConstants.CHANGE_LOG_UPDATE, "PENGATURAN LIMIT PAJAK");
            }
        }

        private void persentasePenjualan_TextChanged(object sender, EventArgs e)
        {
            if ((omsetPenjualan.Text.Length > 0) && (omsetPenjualan.Text != "0"))
                omsetPenjualan.Text = "0";
        }

        private void persentasePembelian_TextChanged(object sender, EventArgs e)
        {
            if ((omsetPembelian.Text.Length > 0) && (omsetPembelian.Text != "0"))
                omsetPembelian.Text = "0";
        }

        private void pengaturanLimitPajakForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }
    }
}

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
using System.IO;
using Hotkeys;

namespace AlphaSoft
{
    public partial class createConfigFileForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private string appPath = Application.StartupPath;
        private bool configFileSaved = false;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        private string ipAddress = "";

        public createConfigFileForm()
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

        private bool testConnection(bool skipMessage = false)
        {
            bool result = false;
            MySqlException internalEX = null;

            if (localhostRadioButton.Checked)
                ipAddress = "localhost";
            else
                ipAddress = gUtil.allTrim(ip1Textbox.Text) + "." + gUtil.allTrim(ip2Textbox.Text) + "." + gUtil.allTrim(ip3Textbox.Text) + "." + gUtil.allTrim(ip4Textbox.Text);

            DS.setConfigFileConnectionString(ipAddress);

            result = DS.testConfigConnectionString(ref internalEX);

            if (!skipMessage)
            { 
                if (!result)
                    MessageBox.Show("CONNECTION ERROR [" + internalEX.Message + "]");
                else
                    MessageBox.Show("CONNECTION SUCCESS");
            }

            return result;
        }

        private void saveConfigFile()
        {
            string fileName = appPath + "\\pos.cfg";
            string line = ipAddress;
            StreamWriter sw = null;

            if (!File.Exists(fileName))
                sw = File.CreateText(fileName);
            else
            {
                File.Delete(fileName);
                sw = File.CreateText(fileName);
            }

            sw.WriteLine(line);
            sw.Close();
        }

        private void createConfigFileForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];
            errorLabel.Text = "";

            arrButton[0] = button1;
            arrButton[1] = saveButton;
            gUtil.reArrangeButtonPosition(arrButton, 193, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testConnection();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (testConnection(true))
            {
                saveConfigFile();
                configFileSaved = true;
            }

            this.Close();
        }

        private void IPMasked_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip2Textbox.Focus();
        }

        private void IPMasked_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip3Textbox.Focus();
        }

        private void IPMasked_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip4Textbox.Focus();
        }

        private void createConfigFileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!configFileSaved)
                Application.Exit();
        }

        private void serverIPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (serverIPRadioButton.Checked)
            {
                ip1Textbox.Visible = true;
                ip2Textbox.Visible = true;
                ip3Textbox.Visible = true;
                ip4Textbox.Visible = true;
            }
            else
            {
                ip1Textbox.Visible = false;
                ip2Textbox.Visible = false;
                ip3Textbox.Visible = false;
                ip4Textbox.Visible = false;
            }
        }

        private void ip1Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip1Textbox.SelectAll();
            });
        }

        private void ip2Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip2Textbox.SelectAll();
            });
        }

        private void ip3Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip3Textbox.SelectAll();
            });
        }

        private void ip4Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip4Textbox.SelectAll();
            });
        }

        private void createConfigFileForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void createConfigFileForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }
    }
}
